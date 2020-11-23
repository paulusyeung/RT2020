#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.EF6;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using VWG.Community.Util;
using RT2020.Helper;

#endregion

namespace RT2020.Settings.SuperUser
{
    public partial class Phone : UserControl
    {
        static Random rand = new Random();

        Gizmox.WebGUI.Forms.Timer _Timer = new Gizmox.WebGUI.Forms.Timer();     // 利用每 Tick 嚟更新個 UI
        int _Counter = 0;
        bool _IsAllItemsProcessed = false;
        String _CurrentItem = "", _AllCountries = "";

        public Phone()
        {
            InitializeComponent();

            cmdGenCountryCode.ClickOnce = cmdGenRegionCode.ClickOnce = cmdGenPhoneNumbers.ClickOnce = true;

            progressBar1.Dock = DockStyle.Top;
            progressBar1.CustomStyle = "Flat";
            progressBar1.Visible = false;

            _Timer.Interval = 100;
            _Timer.Tick += Timer_Tick;
            _Timer.Stop();

        }

        /// <summary>
        /// 每一 Tick，update 個 UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_IsAllItemsProcessed)
            {
                #region Task AsyncCallback 話搞掂
                _Timer.Stop();

                cmdGenCountryCode.Enabled = cmdGenRegionCode.Enabled = cmdGenPhoneNumbers.Enabled = true;
                progressBar1.Visible = false;

                MessageBox.Show(_AllCountries);
                #endregion
            }
            else
            {
                #region Task AsyncCallback 仲搞緊，繼續 update 隻 progress bar
                _Counter += 1;
                if (_Counter > 100)
                {
                    _Counter = 0;
                }
                progressBar1.Value = _Counter;
                if (!cmdGenCountryCode.Enabled)
                    cmdGenCountryCode.Text = (_CurrentItem != String.Empty) ? _CurrentItem : "Please wait...";
                if (!cmdGenPhoneNumbers.Enabled)
                    cmdGenPhoneNumbers.Text = (_CurrentItem != String.Empty) ? _CurrentItem : "Please wait...";
                #endregion
            }
        }

        private void cmdGenCountryCode_Click(object sender, EventArgs e)
        {
            DoCountryCodeGen();
        }

        private void cmdGenPhoneNumbers_Click(object sender, EventArgs e)
        {
            /** debug
            for (int i = 0; i < 20; i++)
            {
                var number = GetRandomPhoneNumber_Others();
            }

            var phoneNumber = GetRandomPhoneNumber_HK();

            cmdGenPhoneNumbers.Text = phoneNumber;
            */

            // 2020.11.13 paulus: 改用 Bot Server，Hangefire 以 background job 完成
            //DoPhoneGen();
            var result = BotHelper.PostSuperUser_GenPhonenumbers(DAL.Common.Config.CurrentUserId);
            var msg = result ?
                "Successfully sent to Bot Server" + Environment.NewLine + "Process takes time...Please check Member record later, say, next day." :
                "Failed sending to Bot Server" + Environment.NewLine + "Job aborted...Please check";
            MessageBox.Show(msg);
        }

        /// refer: https://www.codeproject.com/articles/426120/calling-a-method-in-csharp-asynchronously-using-de
        ///        http://web.archive.org/web/20150315055253/http://wiki.visualwebgui.com/pages/index.php/HtmlBox_CodeSample_-_Asynchronous_loading_of_contents
        public delegate void LongTimeTask_Delegate(string s);

        #region Gen Country Code：Task + AsyncCallback
        private void DoCountryCodeGen()
        {
            // 我想 update 個 UI，用咗 Task + AsyncCallback 嚟分開 UI 同 server job
            LongTimeTask_Delegate d = new LongTimeTask_Delegate(LTT_CountryCode);
            IAsyncResult R = d.BeginInvoke("GenCountryCodes", new AsyncCallback(TC_CountryCode), null);   //invoking the method

            progressBar1.Visible = true;
            _Timer.Start();
        }

        /// <summary>
        /// Generate dbo.Country. Write your time consuming task here
        /// </summary>
        /// <param name="s"></param>
        public void LTT_CountryCode(string s)
        {
            using (var ctx = new RT2020Entities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                #region Generate missing dbo.Country from VWG.Community.Util.CountryCodes
                var dboCounttries = ctx.Country.ToList();
                var ccodes = new CountryCodes();
                var codelist = ccodes.GetList();
                OpenCC.Load();

                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in codelist)
                        {
                            //! CountryCode = ISO3166_1_Alpha_2，CountryName = CLDR_displayname
                            if (item.ISO3166_1_Alpha_2 == String.Empty) continue;
                            var exist = ctx.Country.Where(x => x.CountryCode == item.FIPS).FirstOrDefault();
                            if (exist == null)
                            {
                                exist = new Country();
                                exist.CountryId = Guid.NewGuid();
                                exist.CountryCode = item.ISO3166_1_Alpha_2;
                                exist.CountryName = item.CLDR_displayname;
                                if (!String.IsNullOrEmpty(item.official_name_cn))
                                {
                                    exist.CountryName_Chs = item.official_name_cn;
                                    exist.CountryName_Cht = OpenCC.Convert(item.official_name_cn, OpenCCType.s2hk.ToString("g"));
                                }
                                ctx.Country.Add(exist);
                                ctx.SaveChanges();
                            }
                            else
                            {
                                exist.CountryName = item.CLDR_displayname;
                                exist.CountryName_Chs = item.official_name_cn;
                                exist.CountryName_Cht = OpenCC.Convert(item.official_name_cn, OpenCCType.s2hk.ToString("g"));
                                ctx.SaveChanges();
                            }
                            _CurrentItem = exist.CountryName;
                        }
                        scope.Commit();
                    }
                    catch
                    {
                        scope.Rollback();
                    }
                }
                #endregion
            }
        }

        public void TC_CountryCode(IAsyncResult R)
        {
            _IsAllItemsProcessed = true;    // tell Timer the job is done
        }
        #endregion


        #region Gen Country/Province/City Code for China/ Hong Kong/ Taiwan
        private void cmdGenRegionCode_Click(object sender, EventArgs e)
        {
            if (chkChina.Checked)
            {
                _IsAllItemsProcessed = false;

                LongTimeTask_Delegate d = new LongTimeTask_Delegate(LTT_RegionCode);
                IAsyncResult R = d.BeginInvoke("GenRegionCodes", new AsyncCallback(TC_RegionCode), null);   //invoking the method

                progressBar1.Visible = true;
                _Timer.Start();
            }
            if (chkHongKong.Checked)
            {
                _IsAllItemsProcessed = false;

                LongTimeTask_Delegate d = new LongTimeTask_Delegate(LTT_RegionCode);
                IAsyncResult R = d.BeginInvoke("GenRegionCodes", new AsyncCallback(TC_RegionCode), null);   //invoking the method

                progressBar1.Visible = true;
                _Timer.Start();
            }
            if (chkMacao.Checked)
            {
                _IsAllItemsProcessed = false;

                LongTimeTask_Delegate d = new LongTimeTask_Delegate(LTT_RegionCode);
                IAsyncResult R = d.BeginInvoke("GenRegionCodes", new AsyncCallback(TC_RegionCode), null);   //invoking the method

                progressBar1.Visible = true;
                _Timer.Start();
            }
            if (chkTaiwan.Checked)
            {
                _IsAllItemsProcessed = false;

                LongTimeTask_Delegate d = new LongTimeTask_Delegate(LTT_RegionCode);
                IAsyncResult R = d.BeginInvoke("GenRegionCodes", new AsyncCallback(TC_RegionCode), null);   //invoking the method

                progressBar1.Visible = true;
                _Timer.Start();
            }
        }

        public void LTT_RegionCode(string s)
        {
            if (chkChina.Checked) Helper.GenData.ChinaData.WriteDefaultValues();
            if (chkHongKong.Checked) Helper.GenData.HongKongData.WriteDefaultValues();
            if (chkMacao.Checked) Helper.GenData.MacaoData.WriteDefaultValues();
            if (chkTaiwan.Checked) Helper.GenData.TaiwanData.WriteDefaultValues();
        }

        public void TC_RegionCode(IAsyncResult R)
        {
            _IsAllItemsProcessed = true;    // tell Timer the job is done
        }
        #endregion


        #region 本地 Gen Phone Numbers，已經唔再用，改為 Bot Server Hangfire background job

        #region Gen Member Phone Numbers：Task + AsyncCallback
        private void DoPhoneGen()
        {
            // 我想 update 個 UI，用咗 Task + AsyncCallback 嚟分開 UI 同 server job
            LongTimeTask_Delegate d = new LongTimeTask_Delegate(LTT_MemberPhoneNumber);
            IAsyncResult R = d.BeginInvoke("GenPhoneNumbers", new AsyncCallback(TC_MemberPhoneNumber), null);   //invoking the method

            progressBar1.Visible = true;
            _Timer.Start();
        }

        #region Task & AsyncCallback 負責做苦工（generate Phone Number & update MemberAddress）
        /// <summary>
        /// 將費時嘅工序放喺呢度做
        /// </summary>
        /// <param name="s"></param>
        public void LTT_MemberPhoneNumber(string s)
        {
            // Write your time consuming task here
            using (var ctx = new RT2020Entities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                #region Generate random phone numbers for each Member
                var mbrAddresses = ctx.MemberAddress.Where(x => x.PhoneTag1Value != "" || x.PhoneTag2Value != "");
                var counts = mbrAddresses.Count();
                if (counts > 0)
                {
                    OpenCC.Load();
                    var ccodes = new CountryCodes();
                    var codelist = ccodes.GetList();

                    using (var scope = ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            List<String> countries = new List<string>();
                            foreach (var item in mbrAddresses)
                            {
                                /* 假設條件（address 先決）：
                                 * 1. 非 ASCII 地址就係中國
                                 * 2. 由 Address 找到所屬 Country，分為：中國﹑香港﹑其他
                                 * 3. 如果 match 唔倒，當係 香港
                                 */
                                String country = "", areacode = "", number1 = "", number2 = "";

                                country = IsChinese(item.Address) ? "china" : StripCountry(item.Address);
                                if (country != String.Empty)
                                {
                                    country = country.ToLower().Replace(".", "");

                                    var validCountry = ccodes.FindByDisplayName(country);
                                    var found = validCountry != null ? true : false;
                                    if (!found) country = "hong kong";

                                    var inList = countries.Where(x => x == country).FirstOrDefault();
                                    if (inList == null) countries.Add(country);
                                }
                                _CurrentItem = (--counts).ToString();

                                //ctx.SaveChanges();
                            }

                            #region 顯示結果：countries 有哂啲 unique 嘅名，轉做 array 再轉為 json string 方便顯示個 result
                            var str = String.Join("; ", countries.OrderBy(x => x).ToArray());
                            _AllCountries = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(str)).Replace("?", "");
                            #endregion

                            //scope.Commit();
                        }
                        catch
                        {
                            //scope.Rollback();
                        }
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// 將費時嘅工序完成
        /// </summary>
        /// <param name="R"></param>
        public void TC_MemberPhoneNumber(IAsyncResult R)
        {
            _IsAllItemsProcessed = true;    // tell Timer the job is done
        }
        #endregion

        #endregion

        /// <summary>
        /// 假如唔係 ASCII 就當係中文
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool IsChinese(String source)
        {
            // Encoding.ASCII.GetBytes 會將 non-ascii 轉變為 ?
            var stripped = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(source));
            // 如果有 ? 就當係中文
            return (stripped.Contains("?"));
        }

        /// <summary>
        /// 抽出最後嗰行當係 Country
        /// 中文地址係 country 行先，所以要先用 IsChinese 過濾咗啲中文地址
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private String StripCountry(String source)
        {
            var result = "";
            var rows = source.Split(new string[] { "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
            var lastRow = rows.Length == 0 ? "" : rows.Length > 1 ? rows[rows.Length - 1] : rows[0];

            if (lastRow != String.Empty)
            {
                var words = lastRow.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var lastWord = words.Length == 0 ? "" : words.Length > 1 ? words[words.Length - 1] : words[0];

                // 唔要 numeric，唔要前後 spaces
                result = Regex.Replace(lastWord, "[0-9]", "").Trim();
            }

            return result;
        }

        /// <summary>
        /// 其他國家：Gen 10 位數字，唔要符號
        /// </summary>
        /// <returns></returns>
        private static String GetRandomPhoneNumber_Others()
        {
            StringBuilder telNo = new StringBuilder(10);
            int number;
            for (int i = 0; i < 3; i++)
            {
                number = rand.Next(0, 8); // digit between 0 (incl) and 8 (excl)
                telNo = telNo.Append(number.ToString());
            }
            //telNo = telNo.Append("-");
            number = rand.Next(0, 743); // number between 0 (incl) and 743 (excl)
            telNo = telNo.Append(String.Format("{0:D3}", number));
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        /// <summary>
        /// 中國：Gen 10 位數字，唔要符號
        /// </summary>
        /// <returns></returns>
        private static String GetRandomPhoneNumber_CN()
        {
            StringBuilder telNo = new StringBuilder(10);
            int number = 86;
            //telNo = telNo.Append(number.ToString());
            //telNo = telNo.Append("-");
            for (int i = 0; i < 3; i++)
            {
                number = rand.Next(0, 8); // digit between 0 (incl) and 8 (excl)
                telNo = telNo.Append(number.ToString());
            }
            //telNo = telNo.Append("-");
            number = rand.Next(0, 1000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D3}", number));
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        /// <summary>
        /// 香港：Gen 8 位數字，唔要符號
        /// </summary>
        /// <returns></returns>
        private static String GetRandomPhoneNumber_HK()
        {
            StringBuilder telNo = new StringBuilder(8);
            int number = 852;

            //telNo = telNo.Append(number.ToString());
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        #endregion
    }
}