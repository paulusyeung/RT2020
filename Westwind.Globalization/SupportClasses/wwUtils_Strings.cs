using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.Win32;

using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Web;
using System.Collections;

namespace Westwind.Tools
{
    // *** String specific code

    internal partial class wwUtils
    {
        /// <summary>
        /// Replaces and  and Quote characters to HTML safe equivalents.
        /// </summary>
        /// <param name="Html">HTML to convert</param>
        /// <returns>Returns an HTML string of the converted text</returns>
        public static string FixHTMLForDisplay(string Html)
        {
            Html = Html.Replace("<", "&lt;");
            Html = Html.Replace(">", "&gt;");
            Html = Html.Replace("\"", "&quot;");
            return Html;
        }

        /// <summary>
        /// Strips HTML tags out of an HTML string and returns just the text.
        /// </summary>
        /// <param name="Html">Html String</param>
        /// <returns></returns>
        public static string StripHtml(string Html)
        {
            Html = Regex.Replace(Html, @"<(.|\n)*?>", string.Empty);
            Html = Html.Replace("\t", " ");
            Html = Html.Replace("\r\n", "");
            Html = Html.Replace("   ", " ");
            return Html.Replace("  ", " ");
        }

        /// <summary>
        /// Fixes a plain text field for display as HTML by replacing carriage returns 
        /// with the appropriate br and p tags for breaks.
        /// </summary>
        /// <param name="String Text">Input string</param>
        /// <returns>Fixed up string</returns>
        public static string DisplayMemo(string HtmlText)
        {
            HtmlText = HtmlText.Replace("\r\n", "\r");
            HtmlText = HtmlText.Replace("\n", "\r");
            //HtmlText = HtmlText.Replace("\r\r","<p>");
            HtmlText = HtmlText.Replace("\r", "<br />");
            return HtmlText;
        }

        /// <summary>
        /// Method that handles handles display of text by breaking text.
        /// Unlike the non-encoded version it encodes any embedded HTML text
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string DisplayMemoEncoded(string Text)
        {
            bool PreTag = false;
            if (Text.IndexOf("<pre>") > -1)
            {
                Text = Text.Replace("<pre>", "__pre__");
                Text = Text.Replace("</pre>", "__/pre__");
                PreTag = true;
            }

            // *** fix up line breaks into <br><p>
            Text = Westwind.Tools.wwUtils.DisplayMemo(HttpUtility.HtmlEncode(Text));

            if (PreTag)
            {
                Text = Text.Replace("__pre__", "<pre>");
                Text = Text.Replace("__/pre__", "</pre>");
            }

            return Text;
        }

        /// <summary>
        /// Expands links into HTML hyperlinks inside of text or HTML.
        /// </summary>
        /// <param name="Text">The text to expand</param>
        /// <param name="Target">Target frame where output is displayed</param>
        /// <returns></returns>
        public static string ExpandUrls(string Text, string Target)
        {
            ExpandUrlsParser Parser = new ExpandUrlsParser();
            Parser.Target = Target;
            return Parser.ExpandUrls(Text);
        }

        public static string ExpandUrls(string Text)
        {
            return ExpandUrls(Text, null);
        }

        /// <summary>
        /// Create an Href HTML link
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Url"></param>
        /// <param name="Target"></param>
        /// <param name="AdditionalMarkup"></param>
        /// <returns></returns>
        public static string Href(string Text, string Url, string Target, string AdditionalMarkup)
        {
            return "<a href=\"" + Url + "\" " +
                (string.IsNullOrEmpty(Target) ? "" : "target=\"" + Target + "\" ") +
                (string.IsNullOrEmpty(AdditionalMarkup) ? "" : AdditionalMarkup) +
                ">" + Text + "</a>";
        }

        /// <summary>
        /// Created an Href HTML link
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string Href(string Text, string Url)
        {
            return Href(Text, Url, null, null);
        }

        /// <summary>
        /// Extracts a string from between a pair of delimiters. Only the first 
        /// instance is found.
        /// </summary>
        /// <param name="Source">Input String to work on</param>
        /// <param name="StartDelim">Beginning delimiter</param>
        /// <param name="EndDelim">ending delimiter</param>
        /// <param name="CaseInsensitive">Determines whether the search for delimiters is case sensitive</param>
        /// <returns>Extracted string or ""</returns>
        public static string ExtractString(string Source, string BeginDelim, string EndDelim, bool CaseSensitive, bool AllowMissingEndDelimiter)
        {
            int At1, At2;

            if (string.IsNullOrEmpty(Source))
                return "";

            if (CaseSensitive)
            {
                At1 = Source.IndexOf(BeginDelim);
                if (At1 == -1)
                    return "";

                At2 = Source.IndexOf(EndDelim, At1 + BeginDelim.Length);
            }
            else
            {
                string Lower = Source.ToLower();
                At1 = Lower.IndexOf(BeginDelim.ToLower());
                if (At1 == -1)
                    return "";

                At2 = Lower.IndexOf(EndDelim.ToLower(), At1 + BeginDelim.Length);
            }

            if (AllowMissingEndDelimiter && At2 == -1)
                return Source.Substring(At1 + BeginDelim.Length);

            if (At1 > -1 && At2 > 1)
                return Source.Substring(At1 + BeginDelim.Length, At2 - At1 - BeginDelim.Length);

            return "";
        }

        /// <summary>
        /// Extracts a string from between a pair of delimiters. Only the first
        /// instance is found.
        /// <seealso>Class wwUtils</seealso>
        /// </summary>
        /// <param name="Source">
        /// Input String to work on
        /// </param>
        /// <param name="BeginDelim"></param>
        /// <param name="EndDelim">
        /// ending delimiter
        /// </param>
        /// <param name="CaseInSensitive"></param>
        /// <returns>String</returns>
        public static string ExtractString(string Source, string BeginDelim, string EndDelim, bool CaseSensitive)
        {
            return ExtractString(Source, BeginDelim, EndDelim, CaseSensitive, false);
        }

        /// <summary>
        /// Extracts a string from between a pair of delimiters. Only the first 
        /// instance is found. Search is case insensitive.
        /// </summary>
        /// <param name="Source">
        /// Input String to work on
        /// </param>
        /// <param name="StartDelim">
        /// Beginning delimiter
        /// </param>
        /// <param name="EndDelim">
        /// ending delimiter
        /// </param>
        /// <returns>Extracted string or ""</returns>
        public static string ExtractString(string Source, string BeginDelim, string EndDelim)
        {
            return wwUtils.ExtractString(Source, BeginDelim, EndDelim, false, false);
        }


        /// <summary>
        /// Determines whether a string is empty (null or zero length)
        /// </summary>
        /// <param name="String">Input string</param>
        /// <returns>true or false</returns>
        public static bool Empty(string String)
        {
            if (String == null || String.Trim().Length == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Determines wheter a string is empty (null or zero length)
        /// </summary>
        /// <param name="StringValue">Input string (in object format)</param>
        /// <returns>true or false/returns>
        public static bool Empty(object StringValue)
        {
            string String = (string)StringValue;
            if (String == null || String.Trim().Length == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Return a string in proper Case format
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string ProperCase(string Input)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Input);
        }

        /// <summary>
        /// Returns an abstract of the provided text by returning up to Length characters
        /// of a text string. If the text is truncated a ... is appended.
        /// </summary>
        /// <param name="Text">Text to abstract</param>
        /// <param name="Length">Number of characters to abstract to</param>
        /// <returns>string</returns>
        public static string TextAbstract(string Text, int Length)
        {
            if (Text.Length <= Length)
                return Text;

            Text = Text.Substring(0, Length);

            Text = Text.Substring(0, Text.LastIndexOf(" "));
            return Text + "...";
        }

        /// <summary>
        /// Creates an Abstract from an HTML document. Strips the 
        /// HTML into plain text, then creates an abstract.
        /// </summary>
        /// <param name="Html"></param>
        /// <returns></returns>
        public static string HtmlAbstract(string Html, int Length)
        {
            return TextAbstract(StripHtml(Html), Length);
        }

        /// <summary>
        /// Simple Logging method that allows quickly writing a string to a file
        /// </summary>
        /// <param name="Output"></param>
        /// <param name="Filename"></param>
        public static void LogString(string Output, string Filename)
        {
            StreamWriter Writer = new StreamWriter(Filename, true);
            Writer.WriteLine(DateTime.Now.ToString() + " - " + Output);
            Writer.Close();
        }

        /// <summary>
        /// Creates short string id based on a GUID hashcode.
        /// Not guaranteed to unique across machines, but unlikely
        /// to duplicate in medium volume situations.
        /// </summary>
        /// <returns></returns>
        public static string NewStringId()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }

     
    }
}


public class ExpandUrlsParser
{
    public string Target = "";

    /// <summary>
    /// Expands links into HTML hyperlinks inside of text or HTML.
    /// </summary>
    /// <param name="Text">The text to expand</param>
    /// <param name="Target">Target frame where output is displayed</param>
    /// <returns></returns>
    public string ExpandUrls(string Text)
    {

        string pattern = @"([""'=]|&quot;)?(http://|ftp://|https://|www\.|ftp\.[\w]+)([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])";

        //string pattern = @"[""'=]?(http://|ftp://|https:/[\w]+)([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])|((www\.)|(ftp\.)).*?((\.com)|(\.net)|(\.org))((.|\?|\#)+\s)?";        
        //string pattern = @"[""'=]?(http://|ftp://|https://|mailto:)[\w]+(.[\w]+)([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])|((www\.)|(ftp\.)).*?((\.com)|(\.net)|(\.org))";

        // *** Expand embedded hyperlinks
        System.Text.RegularExpressions.RegexOptions options = 
                                                              RegexOptions.Multiline |
                                                              RegexOptions.IgnoreCase;
            
        MatchEvaluator MatchEval = new MatchEvaluator(this.ExpandUrlsRegExEvaluator);
        return Regex.Replace(Text, pattern, MatchEval,options);
    }

    /// <summary>
    /// Internal RegExEvaluator callback
    /// </summary>
    /// <param name="M"></param>
    /// <returns></returns>
    private string ExpandUrlsRegExEvaluator(System.Text.RegularExpressions.Match M)
    {
        string Href = M.Value; // M.Groups[0].Value;
                
        // *** if string starts within an HREF don't expand it
        if (Href.StartsWith("=") ||
            Href.StartsWith("'") ||
            Href.StartsWith("\"") ||
            Href.StartsWith("&quot;") )
            return Href;

        string Text = Href;

        if (Href.IndexOf("://") < 0)
        {
            if (Href.StartsWith("www."))
                Href = "http://" + Href;
            else if (Href.StartsWith("ftp"))
                Href = "ftp://" + Href;
            else if (Href.IndexOf("@") > -1)
                Href = "mailto:" + Href;
        }

        string Targ = !string.IsNullOrEmpty(this.Target) ? " target='" + this.Target + "'" : "";

        return "<a href='" + Href + "'" + Targ +
                ">" + Text + "</a>";
    }

}

