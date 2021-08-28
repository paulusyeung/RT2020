﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Html;
using System.Threading.Tasks;
using System.Linq;
using FastReport.Web.Controllers;
using FastReport.Web.Application;
using System.Drawing;

namespace FastReport.Web
{
    public enum WebReportMode
    {
        Preview,
#if DESIGNER
        Designer,
#endif
#if DIALOGS
        Dialog,
#endif
    }

    public partial class WebReport
    {
        private string localizationFile;

#if DIALOGS
        internal Dialog Dialog {
            get;
        }
#endif

#region Public Properties

        /// <summary>
        /// Unique ID of this instance.
        /// Automatically generates on creation.
        /// </summary>
        public string ID { get; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// Adds "display: inline-*" to html container.
        /// Default value: true.
        /// </summary>
        public bool Inline { get; set; } = true;

        /// <summary>
        /// Current report
        /// </summary>
        public Report Report
        {
            get { return Tabs[CurrentTabIndex].Report; }
            set { Tabs[CurrentTabIndex].Report = value; }
        }

        /// <summary>
        /// Gets or sets the WebReport's locale
        /// </summary>
        public string LocalizationFile
        {
            get => localizationFile;
            set
            {
                localizationFile = value;
                string path = WebUtils.MapPath(localizationFile);
                Res.LoadLocale(path);
            }
        }

        internal WebRes Res { get; set; } = new WebRes();


        /// <summary>
        /// Active report tab
        /// </summary>
        public ReportTab CurrentTab
        {
            get => Tabs[CurrentTabIndex];
            set => Tabs[CurrentTabIndex] = value;
        }

        /// <summary>
        /// Active tab index
        /// </summary>
        public int CurrentTabIndex
        {
            get
            {
                if (currentTabIndex >= Tabs.Count)
                    currentTabIndex = Tabs.Count - 1;
                if (currentTabIndex < 0)
                    currentTabIndex = 0;
                return currentTabIndex;
            }
            set => currentTabIndex = value;
        }

        /// <summary>
        /// Page index of current report
        /// </summary>
        public int CurrentPageIndex
        {
            get => CurrentTab?.CurrentPageIndex ?? 0;
            set
            {
                var tab = CurrentTab;
                if (tab != null)
                    tab.CurrentPageIndex = value;
            }
        }

        /// <summary>
        /// Is current report prepared(.fpx) or not(.frx)
        /// </summary>
        public bool ReportPrepared
        {
            get => CurrentTab?.ReportPrepared ?? false;
            set
            {
                var tab = CurrentTab;
                if (tab != null)
                    tab.ReportPrepared = value;
            }
        }

        /// <summary>
        /// Total prepared pages of current report
        /// </summary>
        public int TotalPages => Report?.PreparedPages?.Count ?? 0;

        /// <summary>
        /// List of report tabs
        /// </summary>
        public ReportTabCollection Tabs { get; } = new ReportTabCollection() { new ReportTab() { Report = new Report(), Closeable = false } };

        /// <summary>
        /// Switches beetwen Preview and Designer modes
        /// </summary>
        public WebReportMode Mode { get; set; } = WebReportMode.Preview;

        /// <summary>
        /// Property to store user data
        /// </summary>
        public object UserData { get; set; } = null;

        public bool SinglePage { get; set; } = false;
        public bool Layers { get; set; } = true;
        public bool EnableMargins { get; set; } = true;
        public string Width { get; set; } = "";
        public string Height { get; set; } = "";
        public bool Pictures { get; set; } = true;
        public bool EmbedPictures { get; set; } = false;


        #region ToolbarSettings

        /// <summary>
        /// Toolbar settings
        /// </summary>
        public ToolbarSettings Toolbar { get; set; } = ToolbarSettings.Default; 

        [Obsolete("Please, use Toolbar.Show")]
        public bool ShowToolbar { get => Toolbar.Show; set => Toolbar.Show = value; }
        [Obsolete("Please, use Toolbar.ShowPrevButton")]
        public bool ShowPrevButton { get => Toolbar.ShowPrevButton; set => Toolbar.ShowPrevButton = value; }
        [Obsolete("Please, use Toolbar.ShowNextButton")]
        public bool ShowNextButton { get => Toolbar.ShowNextButton; set => Toolbar.ShowNextButton = value; }
        [Obsolete("Please, use Toolbar.ShowFirstButton")]
        public bool ShowFirstButton { get => Toolbar.ShowFirstButton; set => Toolbar.ShowFirstButton = value; }
        [Obsolete("Please, use Toolbar.ShowLastButton")]
        public bool ShowLastButton { get => Toolbar.ShowLastButton; set => Toolbar.ShowLastButton = value; }

        [Obsolete("Please, use Toolbar.Exports.Show")]
        public bool ShowExports { get => Toolbar.Exports.Show; set => Toolbar.Exports.Show = value; }

        [Obsolete("Please, use Toolbar.ShowRefreshButton")]
        public bool ShowRefreshButton { get => Toolbar.ShowRefreshButton; set => Toolbar.ShowRefreshButton = value; }
        [Obsolete("Please, use Toolbar.ShowZoomButton")]
        public bool ShowZoomButton { get => Toolbar.ShowZoomButton; set => Toolbar.ShowZoomButton = value; }

        [Obsolete("Please, use Toolbar.ShowPrint")]
        public bool ShowPrint { get => Toolbar.ShowPrint; set => Toolbar.ShowPrint = value; }
        [Obsolete("Please, use Toolbar.PrintInHtml")]
        public bool PrintInHtml { get => Toolbar.PrintInHtml; set => Toolbar.PrintInHtml = value; }
#if !OPENSOURCE
        [Obsolete("Please, use Toolbar.PrintInPdf")]
        public bool PrintInPdf { get => Toolbar.PrintInPdf; set => Toolbar.PrintInPdf = value; }
#endif

        public bool ShowBottomToolbar { get => Toolbar.ShowBottomToolbar; set => Toolbar.ShowBottomToolbar = value; }

        public Color ToolbarColor { get => Toolbar.Color; set => Toolbar.Color = value; }

        #endregion

        public float Zoom { get; set; } = 1.0f;
        public bool Debug { get; set; }
#if DEBUG
            = true;
#else
            = false;
#endif
        internal bool Canceled { get; set; } = false;

        /// <summary>
        /// Shows sidebar with outline.
        /// Default value: true.
        /// </summary>
        public bool Outline { get; set; } = true;

#endregion

#region Non-public

        // TODO
        private string ReportFile { get; set; } = null;
        private string ReportPath { get; set; } = null;
        private string ReportResourceString { get; set; } = null;

        /// <summary>
        /// Toolbar height in pixels
        /// </summary>
        public int ToolbarHeight { get; set; } = 40;

        internal readonly Dictionary<string, byte[]> PictureCache = new Dictionary<string, byte[]>();
        int currentTabIndex;

#endregion

        public WebReport()
        {
            string path = WebUtils.MapPath(LocalizationFile);
            Res.LoadLocale(path);
            WebReportCache.Instance.Add(this);
#if DIALOGS
            Dialog = new Dialog(this);
#endif
        }

        static WebReport()
        {
            ScriptSecurity = new ScriptSecurity(new ScriptChecker());
        }


        public HtmlString RenderSync()
        {
            return Task.Run(() => Render()).Result;
        }

        public async Task<HtmlString> Render()
        {
            if (Report == null)
                throw new Exception("Report is null");

            return Render(false);
        }

        public void LoadPrepared(string filename)
        {
            Report.LoadPrepared(filename);
            ReportPrepared = true;
        }

        public void LoadPrepared(Stream stream)
        {
            Report.LoadPrepared(stream);
            ReportPrepared = true;
        }

        internal HtmlString Render(bool renderBody)
        {
            switch (Mode)
            {
#if DIALOGS
                case WebReportMode.Dialog:
#endif
                case WebReportMode.Preview:
                    return new HtmlString(template_render(renderBody));
#if DESIGNER
                case WebReportMode.Designer:
                    return RenderDesigner();
#endif
                default:
                    throw new Exception($"Unknown mode: {Mode}");
            }
        }

        /// <summary>
        /// Force report to be removed from internal cache
        /// </summary>
        public void RemoveFromCache()
        {
            WebReportCache.Instance.Remove(this);
        }

        // TODO
        // void ReportLoad()
        // void RegisterData()

#region Navigation

        /// <summary>
        /// Force go to next report page
        /// </summary>
        public void NextPage()
        {
            if (CurrentPageIndex < TotalPages - 1)
                CurrentPageIndex++;
        }

        /// <summary>
        /// Force go to previous report page
        /// </summary>
        public void PrevPage()
        {
            if (CurrentPageIndex > 0)
                CurrentPageIndex--;
        }

        /// <summary>
        /// Force go to first report page
        /// </summary>
        public void FirstPage()
        {
            CurrentPageIndex = 0;
        }

        /// <summary>
        /// Force go to last report page
        /// </summary>
        public void LastPage()
        {
            CurrentPageIndex = TotalPages - 1;
        }

        /// <summary>
        /// Force go to "value" report page
        /// </summary>
        public void GotoPage(int value)
        {
            if (value >= 0 && value < TotalPages)
                CurrentPageIndex = value;
        }

#endregion

#region Script Security

        private static ScriptSecurity ScriptSecurity = null;

#endregion
    }
}