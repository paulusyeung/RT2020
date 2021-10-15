using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace RT2020.Common.Helper
{
    public class PivotHelper
    {
        #region private properties: QuickStartHtmlFilePath
        private static string _QuickStartHtml = "WebPivotTable\\quick-start.html";

        private static string QuickStartHtmlFilePath
        {
            get { return Path.Combine(VWGContext.Current.Config.GetDirectory("Assets"), _QuickStartHtml); }
        }
        #endregion

        /// <summary>
        /// 提供 WebPivotTable 的 quick-start.html
        /// </summary>
        /// <param name="id"></param>
        /// <returns>quick-start.html</returns>
        public static string QuickStart()
        {
            var result = "";

            if (File.Exists(QuickStartHtmlFilePath))
            {
                var wptQuickStartHtml = File.ReadAllText(QuickStartHtmlFilePath);

                /** wpt.js
                CDN 找到的：src="https://cdn.jsdelivr.net/npm/webpivottable@6.0.3/public/dist/wpt.js"
                在官方說的：src="https://webpivottable.com/releases/latest/dist/wpt.js"
                我揀自己嘅，有酬需要時可以改
                */
                var wptJs = (new GeneralResourceHandle("Resources/Assets/WebPivotTable/dist/wpt.js")).ToString();

                /** localeFilePath
                 * 由於 VWG 唔准你直接 browse & retrieve 佢管轄下嘅檔案，要利用 GeneralResourceHandle 嚟搞個 Url，
                 * 因為我淨係要個 directory path，個尾多咗 &CT=，ContentType 要刪除
                 */
                var localeFilePath = (new GeneralResourceHandle("Resources/Assets/WebPivotTable/lang/")).ToString().Replace(@"&CT=", "");

                var locale = CookieHelper.CurrentLocaleId;

                result = wptQuickStartHtml
                    .Replace("#wptJs#", wptJs)
                    .Replace("#localeFilePath#", localeFilePath)
                    .Replace("#locale#", locale);
            }

            return result;
        }

        /// <summary>
        /// 1. 搵出隻 Wpt Template（原稿）
        /// 2. 因為隻 Wpt Template 係英文生成嘅，要根據 lang 轉換 locale
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static string GetLocalizedWptFile(string filename, string lang)
        {
            var result = "";

            // 如果 RT2020 call 會有 VWGContext，RT2020.Api call 就冇 VWGContext，咁就要用 AppSettings
            var directory = VWGContext.Current != null ? 
                VWGContext.Current.Config.GetDirectory("Reports") : 
                ConfigHelper.ReportsBox;

            /** optional: 用 NetworkConnection 嚟做 impersonation
            #region 用 NetworkConnection: 來自於 NetworkConnection.cs 用嚟做 impersonation
            var readCreditials = new NetworkCredential(ConfigHelper.Impersonate_UserName, ConfigHelper.Impersonate_UserPassword);
            #endregion
            */

            using (new Impersonate(directory, ConfigHelper.Impersonate_UserName, ConfigHelper.Impersonate_UserPassword))
            {
                // 喺個 directory path 內搵出隻 wpt template file，用[搵]，咁啲 Wpt Files 唔使一定要擺喺同一個 folder
                var wptFilePath = Directory.GetFiles(ConfigHelper.ReportsBox, "*.wpt", SearchOption.AllDirectories)
                .Where(x => Path.GetFileNameWithoutExtension(x) == filename)
                .FirstOrDefault();
                if (wptFilePath != null)
                {
                    if (File.Exists(wptFilePath))
                    {
                        var text = File.ReadAllText(wptFilePath);
                        if (text != "")
                        {
                            if (lang == "en")
                            {
                                result = text;
                            }
                            else
                            {
                                if (filename.StartsWith("SA1340")) result = ReplaceLocale_SA1340(text, lang);
                                // if 其他 reports
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static string ReplaceLocale_SA1340(string text, string lang)
        {
            var origin = GlobalVars.BaseLocale;

            return text
                .Replace(WestwindHelper.GetWord("article.code", "Product", origin), WestwindHelper.GetWord("article.code", "Product", lang))
                .Replace(WestwindHelper.GetWord("appendix.appendix1", "Product", origin), WestwindHelper.GetWord("appendix.appendix1", "Product", lang))
                .Replace(WestwindHelper.GetWord("appendix.appendix2", "Product", origin), WestwindHelper.GetWord("appendix.appendix2", "Product", lang))
                .Replace(WestwindHelper.GetWord("appendix.appendix3", "Product", origin), WestwindHelper.GetWord("appendix.appendix3", "Product", lang))
                .Replace(WestwindHelper.GetWord("inventory.bfQty", "Product", origin), WestwindHelper.GetWord("inventory.bfQty", "Product", lang))
                .Replace(WestwindHelper.GetWord("inventory.bfAmount", "Product", origin), WestwindHelper.GetWord("inventory.bfAmount", "Product", lang))
                .Replace(WestwindHelper.GetWord("inventory.cdQty", "Product", origin), WestwindHelper.GetWord("inventory.cdQty", "Product", lang))
                .Replace(WestwindHelper.GetWord("inventory.cdAmount", "Product", origin), WestwindHelper.GetWord("inventory.cdAmount", "Product", lang))
                .Replace(WestwindHelper.GetWord("transaction.date", "Transaction", origin), WestwindHelper.GetWord("transaction.date", "Transaction", lang))
                .Replace(WestwindHelper.GetWord("glossary.year", "General", origin), WestwindHelper.GetWord("glossary.year", "General", lang))
                .Replace(WestwindHelper.GetWord("glossary.month", "General", origin), WestwindHelper.GetWord("glossary.month", "General", lang))
                .Replace(WestwindHelper.GetWord("glossary.day", "General", origin), WestwindHelper.GetWord("glossary.day", "General", lang))
                .Replace(WestwindHelper.GetWord("transaction.type", "Transaction", origin), WestwindHelper.GetWord("transaction.type", "Transaction", lang))
                .Replace(WestwindHelper.GetWord("transaction.cost", "Transaction", origin), WestwindHelper.GetWord("transaction.cost", "Transaction", lang))
                .Replace(WestwindHelper.GetWord("transaction.number", "Transaction", origin), WestwindHelper.GetWord("transaction.number", "Transaction", lang))
                .Replace(WestwindHelper.GetWord("workplace", "Model", origin), WestwindHelper.GetWord("workplace", "Model", lang))
                .Replace(WestwindHelper.GetWord("glossary.sequencyNumber", "General", origin), WestwindHelper.GetWord("glossary.sequencyNumber", "General", lang))
                .Replace(WestwindHelper.GetWord("article.description", "Product", origin), WestwindHelper.GetWord("article.description", "Product", lang))
                ;
        }
    }
}
