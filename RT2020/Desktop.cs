#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using System.Diagnostics;
using System.Reflection;
using RT2020.Controls;
using RT2020.DAL;
using System.Web.Caching;
using RT2020.Components.Layout;

#endregion

namespace RT2020
{
    public partial class Desktop : Form
    {
        private enum AtsStyle { Inventory, Purchasing, Product, MemberMgmt, PriceMgmt, Settings };

        public Desktop()
        {
            InitializeComponent();

            SetTheme();
            SetAttributes();

            SetNavPanes();
        }

        private void SetAttributes()
        {
            nxStudio.BaseClass.WordDict oDict = new nxStudio.BaseClass.WordDict(Common.Config.CurrentWordDict, Common.Config.CurrentLanguageId);

            amsFile.Text = oDict.GetWord("file_main_menu");
            amsView.Text = oDict.GetWord("view_main_menu");
            amsViewChs.Text = oDict.GetWord("chs_main_menu");
            amsViewCht.Text = oDict.GetWord("cht_main_menu");
            amsHelp.Text = oDict.GetWord("help_main_menu");
            amsFileExit.Text = oDict.GetWord("exit_main_menu");
            amsHelpAbout.Text = oDict.GetWord("about_main_menu");

            navTabs.Dock = DockStyle.Fill;

            wspPane.Text = oDict.GetWord("dashboard");
            wspPane.Dock = DockStyle.Fill;

            this.Menu = null;
            atsPane.Height = 68;
            //
            var oTopPane = new TopPane();
            oTopPane.Dock = DockStyle.Fill;
            atsPane.Controls.Add(oTopPane);
        }

        /** 廢棄
        private void SetTaskbar()
        {
            var taskbar = new Panel()
            {
                Dock = DockStyle.Fill
            };
            var user = new Button()
            {
                Anchor = AnchorStyles.Right,
                Image = new IconResourceHandle("24x24.Settings_24x24.gif"),
                ImageAlign = ContentAlignment.MiddleCenter,
                Location = new Point(16, 0),
                Size = new Size(36, 36),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true
            };
            var theme = new Button()
            {
                Anchor = AnchorStyles.Right,
                Image = new IconResourceHandle("24x24.Services_24x24.gif"),
                ImageAlign = ContentAlignment.MiddleCenter,
                Location = new Point(56, 0),
                Size = new Size(36, 36),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true
            };
            taskbar.Controls.AddRange(new Control[] { user, theme });
            atsPane.Controls.Add(taskbar);
        }
        */

        private void SetTheme()
        {
            ImageResourceHandle bgImage = new ImageResourceHandle("RT2020.jpg");

            //this.picBgImage.Image = bgImage;
            this.picBgImage.Dock = DockStyle.Fill;
            this.picBgImage.BackgroundImage = bgImage;
            this.picBgImage.BackgroundImageLayout = ImageLayout.Center;

            /**
             * 2020.03.20 paulus: 根據個 theme 改個 background color
             */
            Context.CurrentTheme = Helper.ThemeHelper.CurrentThemeVWGName;
            wspPane.BackColor = Helper.ThemeHelper.TopPanel_BackgroundColor;
        }

        private void SetNavPanes()
        {
            RT2020.NavPane.NavMenu.FillNavPane(ref this.navTabs);
        }

        #region Close Button

        /** 廢棄
        private void SetCloseButton()
        {
            Button cmdClose = new Button();
            cmdClose.Name = "cmdClose";
            cmdClose.Location = new System.Drawing.Point(this.Width - 43, 3);
            cmdClose.Size = new System.Drawing.Size(38, 38);
            cmdClose.Image = new IconResourceHandle("32x32.shutdown32.png");
            cmdClose.ImageAlign = ContentAlignment.MiddleCenter;
            cmdClose.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            cmdClose.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));

            cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            this.Controls.Add(cmdClose);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Shutdown();
        }
        */

        private void Shutdown()
        {
            DAL.Common.Config.CurrentUserId = System.Guid.Empty;

            RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Logout, this.ToString());

            // set the IsLoggedOn to false will redirect to Logon Page.
            this.Context.Session.IsLoggedOn = false;
            VWGContext.Current.HttpContext.Session.Abandon();
            //VWGContext.Current.Transfer(new Desktop());
            // 2020.0812 paulus: 直接跳去 logon
            VWGContext.Current.Transfer(new Public.Logon());
        }
        #endregion

        private void amsMain_MenuClick(object objSource, MenuItemEventArgs objArgs)
        {
            MenuItemEventArgs oArg = (MenuItemEventArgs)objArgs;
            string strAction = oArg.MenuItem.Tag as string;
            if (strAction != null)
            {
                switch (strAction)
                {
                    #region Section: File
                    case "amsFileExit":
                    case "File.Exit":
                    case "RT2020.Quit":
                        //RT2020.DAL.Common.Config.CurrentUserId = System.Guid.Empty;
                        // While setting the IsLoggedOn to false, will redirect to Logon Page.
                        //this.Context.Session.IsLoggedOn = false;
                        // VWGContext.Current.HttpContext.Session.Abandon();
                        //Context.Redirect("Desktop.wgx");
                        Shutdown();
                        break;
                    case "Print":
//                        MessageBox.Show(((Gizmox.WebGUI.Common.Interfaces.ISessionRegistry)this.Context.Session).Count.ToString());
                        break;
                    #endregion

                    #region Section: Help
                    case "amsHelpAbout":
                    case "Help.About":
                    case "RT2020.About":
                        Help.About oAbout = new RT2020.Help.About();
                        oAbout.ShowDialog();
                        break;
                    #endregion
                    
                    #region Section View
                    case "amsViewEn": // English
                    case "View.English":
                        //VWGContext.Current.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                        System.Web.HttpContext.Current.Session["UserLanguage"] = "en-US";
                        Context.Redirect("Desktop.wgx");
                        break;
                    case "amsViewChs": // Simplified Chinese
                    case "View.SimplifiedChinese":
                        //VWGContext.Current.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
                        System.Web.HttpContext.Current.Session["UserLanguage"] = "zh-CHS";
                        Context.Redirect("Desktop.wgx");
                        break;
                    case "amsViewCht": // Tradictional Chinese
                    case "View.TraditionalChinese":
                        //VWGContext.Current.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHT");
                        System.Web.HttpContext.Current.Session["UserLanguage"] = "zh-CHT";
                        Context.Redirect("Desktop.wgx");
                        break;
                    case "amsViewWinXP":
                    case "View.WinXPTheme":
                        this.Context.CurrentTheme = "iOS";          // Theme.Default;
                        break;
                    case "amsViewVista":
                    case "View.VistaTheme":
                        this.Context.CurrentTheme = "Vista";        // new Theme("Vista");
                        break;
                    case "amsViewBlack":
                    case "View.BlackTheme":
                        this.Context.CurrentTheme = "Graphite";     // new Theme("Black");
                        break;
                    #endregion

                    default:
                        //MessageBox.Show(strAction);
                        break;
                }
            }
        }

        #region Deselect selected TreeNodes on switching navTabs
        private void DeSelectTreeNodes()
        {
            Control[] invt = this.Form.Controls.Find("navInvt", true);
            if (invt.Length > 0)
            {
                TreeView tvInvt = (TreeView)invt[0];
                tvInvt.SelectedNode = null;
            }
            Control[] purchase = this.Form.Controls.Find("navPurchasing", true);
            if (purchase.Length > 0)
            {
                TreeView tvInvt = (TreeView)purchase[0];
                tvInvt.SelectedNode = null;
            }
            Control[] mbrMgmt = this.Form.Controls.Find("navMemberMgmt", true);
            if (mbrMgmt.Length > 0)
            {
                TreeView tvInvt = (TreeView)mbrMgmt[0];
                tvInvt.SelectedNode = null;
            }
            Control[] prcMgmt = this.Form.Controls.Find("navPriceMgmt", true);
            if (prcMgmt.Length > 0)
            {
                TreeView tvInvt = (TreeView)prcMgmt[0];
                tvInvt.SelectedNode = null;
            }
            Control[] settings = this.Form.Controls.Find("navSettings", true);
            if (settings.Length > 0)
            {
                TreeView tvInvt = (TreeView)settings[0];
                tvInvt.SelectedNode = null;
            }
        }
        #endregion

        private void navTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeSelectTreeNodes();
        }
    }
}