#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Controls;
using RT2020.DAL;
using Westwind.Globalization;
using System.Threading;
using System.Globalization;
using RT2020.Helper;
using Westwind.Globalization.Web.Administration;
using System.Linq;

#endregion

namespace RT2020.Components.Layout
{
    public partial class TopPane : UserControl
    {
        private ContextMenu _LanguageMenu = new ContextMenu();

        public TopPane()
        {
            InitializeComponent();
        }

        private void TopPane_Load(object sender, EventArgs e)
        {
            SetAttributes();
        }

        /// <summary>
        /// 為咗方便 designer view，有啲 Attributes 喺 codebehide 搞
        /// </summary>
        private void SetAttributes()
        {
            toolTip.SetToolTip(butPower, WestwindHelper.GetWord("logout", "Menu"));
            toolTip.SetToolTip(butLanguage, WestwindHelper.GetWord("language.switcher", "Menu"));
            toolTip.SetToolTip(butTheme, WestwindHelper.GetWord("theme.switcher", "Menu"));

            picLogo.BackgroundImage = new ImageResourceHandle("logo.png");
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.Cursor = Cursors.Hand;
            picLogo.Click += Logo_OnClick;

            pnlTaskbarLeft.Dock = DockStyle.Left;
            butDrawer.Image = new IconResourceHandle("24x24.power_24.png");
            butDrawer.Click += Drawer_OnClick;
            butDrawer.Visible = false;

            pnlTaskbarRight.Dock = DockStyle.Fill;
            butPower.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("fa-power-off.32.png"));
            butPower.Click += Power_OnClick;
            //
            butTheme.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("fa-adjust.32.png"));
            butTheme.Click += Theme_OnClick;
            //
            butLanguage.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("zmdi-translate.32.png"));
            SetLanguageMenu();
        }

        private void SetLanguageMenu()
        {
            var localeId = CookieHelper.CurrentLocaleId;
            var localeList = WestwindHelper.GetLocaleList();

            var i = 0;
            foreach (var item in localeList)
            {
                var menuitem = new MenuItem()
                {
                    Checked = (localeId == item.Key) ? true : false,
                    Index = i,
                    Tag = item.Key,
                    Text = item.Value
                };
                menuitem.Click += Language_OnClick;

                _LanguageMenu.MenuItems.Add(menuitem);
                i++;
            }

            _LanguageMenu.AllowDrop = true;
            butLanguage.DropDownMenu = _LanguageMenu;
        }

        private void Logo_OnClick(object sender, EventArgs e)
        {
            Help.About oAbout = new RT2020.Help.About();
            oAbout.ShowDialog();
        }

        private void Language_OnClick(object sender, EventArgs e)
        {
            var target = (MenuItem)sender;
            var tag = (String)target.Tag;

            // Modify the Current Culture
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tag);

            // lagacy RT2008
            switch (tag.ToLower())
            {
                case "zh-cn":
                    System.Web.HttpContext.Current.Session["UserLanguage"] = "zh-CHS";
                    break;
                case "zh-hk":
                    System.Web.HttpContext.Current.Session["UserLanguage"] = "zh-CHT";
                    break;
                case "en":
                default:
                    System.Web.HttpContext.Current.Session["UserLanguage"] = "en-US";
                    break;
            }

            // 2020.08.28 paulus: RT2020
            CookieHelper.CurrentLocaleId = tag;

            Context.Redirect("Desktop.wgx");
        }

        private void Theme_OnClick(object sender, EventArgs e)
        {
            if ((Utility.Default.CurrentTheme.ToLower() == "vista") || (Utility.Default.CurrentTheme.ToLower() == "light"))
            {
                VWGContext.Current.CurrentTheme = "Graphite";
                this.Context.CurrentTheme = "Graphite";
                Utility.Default.CurrentTheme = "dark";
            }
            else
            {
                VWGContext.Current.CurrentTheme = "Vista";
                this.Context.CurrentTheme = "Vista";
                Utility.Default.CurrentTheme = "light";
            }
        }

        private void Power_OnClick(object sender, EventArgs e)
        {
            DAL.Common.Config.CurrentUserId = Guid.Empty;

            Log4net.LogInfo(Log4net.LogAction.Logout, this.ToString());

            // set the IsLoggedOn to false will redirect to Logon Page.
            this.Context.Session.IsLoggedOn = false;
            VWGContext.Current.HttpContext.Session.Abandon();

            VWGContext.Current.Transfer(new Public.Logon());
        }

        private void Drawer_OnClick(object sender, EventArgs e)
        {
            Help.About oAbout = new RT2020.Help.About();
            oAbout.ShowDialog();
        }
    }
}