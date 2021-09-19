#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;


using RT2020.NavPane;
using System.Linq;

using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Settings
{
    public partial class SystemLabels : UserControl
    {
        public SystemLabels()
        {
            InitializeComponent();
        }

        #region Load Labels
        private void LoadLabels()
        {
            LoadLabel();
            LoadLabel_Chs();
            LoadLabel_Cht();
        }

        // Default, English
        private void LoadLabel()
        {
            var oLabel = SystemLabelEx.GetByLanguageCode("en-US");
            if (oLabel != null)
            {
                this.txtStockCode.Text = oLabel.STKCODE;
                this.txtAppendix1.Text = oLabel.APPENDIX1;
                this.txtAppendix2.Text = oLabel.APPENDIX2;
                this.txtAppendix3.Text = oLabel.APPENDIX3;
                this.txtClass1.Text = oLabel.CLASS1;
                this.txtClass2.Text = oLabel.CLASS2;
                this.txtClass3.Text = oLabel.CLASS3;
                this.txtClass4.Text = oLabel.CLASS4;
                this.txtClass5.Text = oLabel.CLASS5;
                this.txtClass6.Text = oLabel.CLASS6;
                this.txtSerialNumber.Text = oLabel.SERIALNO;
                this.txtVITEMNO.Text = oLabel.VITEMNO;
                this.txtCouponNumber.Text = oLabel.COUPONNO;
                this.txtDLFlag.Text = oLabel.DLFLAG;
                this.txtRemarks1.Text = oLabel.REMARK1;
                this.txtRemarks2.Text = oLabel.REMARK2;
                this.txtRemarks3.Text = oLabel.REMARK3;
                this.txtRemarks4.Text = oLabel.REMARK4;
                this.txtRemarks5.Text = oLabel.REMARK5;
                this.txtRemarks6.Text = oLabel.REMARK6;
            }
        }

        private void LoadLabel_Chs()
        {
            var oLabel = SystemLabelEx.GetByLanguageCode("zh-CHS");
            if (oLabel != null)
            {
                this.txtStockCode_Chs.Text = oLabel.STKCODE;
                this.txtAppendix1_Chs.Text = oLabel.APPENDIX1;
                this.txtAppendix2_Chs.Text = oLabel.APPENDIX2;
                this.txtAppendix3_Chs.Text = oLabel.APPENDIX3;
                this.txtClass1_Chs.Text = oLabel.CLASS1;
                this.txtClass2_Chs.Text = oLabel.CLASS2;
                this.txtClass3_Chs.Text = oLabel.CLASS3;
                this.txtClass4_Chs.Text = oLabel.CLASS4;
                this.txtClass5_Chs.Text = oLabel.CLASS5;
                this.txtClass6_Chs.Text = oLabel.CLASS6;
                this.txtSerialNumber_Chs.Text = oLabel.SERIALNO;
                this.txtVITEMNO_Chs.Text = oLabel.VITEMNO;
                this.txtCouponNumber_Chs.Text = oLabel.COUPONNO;
                this.txtDLFlag_Chs.Text = oLabel.DLFLAG;
                this.txtRemarks1_Chs.Text = oLabel.REMARK1;
                this.txtRemarks2_Chs.Text = oLabel.REMARK2;
                this.txtRemarks3_Chs.Text = oLabel.REMARK3;
                this.txtRemarks4_Chs.Text = oLabel.REMARK4;
                this.txtRemarks5_Chs.Text = oLabel.REMARK5;
                this.txtRemarks6_Chs.Text = oLabel.REMARK6;
            }
        }

        private void LoadLabel_Cht()
        {
            var oLabel = SystemLabelEx.GetByLanguageCode("zh-CHT");
            if (oLabel != null)
            {
                this.txtStockCode_Cht.Text = oLabel.STKCODE;
                this.txtAppendix1_Cht.Text = oLabel.APPENDIX1;
                this.txtAppendix2_Cht.Text = oLabel.APPENDIX2;
                this.txtAppendix3_Cht.Text = oLabel.APPENDIX3;
                this.txtClass1_Cht.Text = oLabel.CLASS1;
                this.txtClass2_Cht.Text = oLabel.CLASS2;
                this.txtClass3_Cht.Text = oLabel.CLASS3;
                this.txtClass4_Cht.Text = oLabel.CLASS4;
                this.txtClass5_Cht.Text = oLabel.CLASS5;
                this.txtClass6_Cht.Text = oLabel.CLASS6;
                this.txtSerialNumber_Cht.Text = oLabel.SERIALNO;
                this.txtVITEMNO_Cht.Text = oLabel.VITEMNO;
                this.txtCouponNumber_Cht.Text = oLabel.COUPONNO;
                this.txtDLFlag_Cht.Text = oLabel.DLFLAG;
                this.txtRemarks1_Cht.Text = oLabel.REMARK1;
                this.txtRemarks2_Cht.Text = oLabel.REMARK2;
                this.txtRemarks3_Cht.Text = oLabel.REMARK3;
                this.txtRemarks4_Cht.Text = oLabel.REMARK4;
                this.txtRemarks5_Cht.Text = oLabel.REMARK5;
                this.txtRemarks6_Cht.Text = oLabel.REMARK6;
            }
        }
        #endregion

        #region Save Labels
        // Default, English
        private void SaveLabel()
        {
            bool isNew = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oLabel = ctx.SystemLabel.Where(x => x.LanguageCode == "en-US").FirstOrDefault();
                if (oLabel == null)
                {
                    oLabel = new EF6.SystemLabel();
                    oLabel.LabelId = Guid.NewGuid();
                    oLabel.LanguageCode = "en-US";

                    ctx.SystemLabel.Add(oLabel);
                    isNew = true;
                }
                oLabel.STKCODE = this.txtStockCode.Text.Trim();
                oLabel.APPENDIX1 = this.txtAppendix1.Text.Trim();
                oLabel.APPENDIX2 = this.txtAppendix2.Text.Trim();
                oLabel.APPENDIX3 = this.txtAppendix3.Text.Trim();
                oLabel.CLASS1 = this.txtClass1.Text.Trim();
                oLabel.CLASS2 = this.txtClass2.Text.Trim();
                oLabel.CLASS3 = this.txtClass3.Text.Trim();
                oLabel.CLASS4 = this.txtClass4.Text.Trim();
                oLabel.CLASS5 = this.txtClass5.Text.Trim();
                oLabel.CLASS6 = this.txtClass6.Text.Trim();
                oLabel.SERIALNO = this.txtSerialNumber.Text.Trim();
                oLabel.VITEMNO = this.txtVITEMNO.Text.Trim();
                oLabel.COUPONNO = this.txtCouponNumber.Text.Trim();
                oLabel.REMARK1 = this.txtRemarks1.Text.Trim();
                oLabel.REMARK2 = this.txtRemarks2.Text.Trim();
                oLabel.REMARK3 = this.txtRemarks3.Text.Trim();
                oLabel.REMARK4 = this.txtRemarks4.Text.Trim();
                oLabel.REMARK5 = this.txtRemarks5.Text.Trim();
                oLabel.REMARK6 = this.txtRemarks6.Text.Trim();

                if (isNew)
                {
                    oLabel.DLFLAG = "A";
                }
                else
                {
                    oLabel.DLFLAG = "M";
                }

                ctx.SaveChanges();
            }
        }

        private void SaveLabel_Chs()
        {
            bool isNew = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oLabel = ctx.SystemLabel.Where(x => x.LanguageCode == "zh-CHS").FirstOrDefault();
                if (oLabel == null)
                {
                    oLabel = new EF6.SystemLabel();
                    oLabel.LabelId = Guid.NewGuid();
                    oLabel.LanguageCode = "zh-CHS";

                    ctx.SystemLabel.Add(oLabel);
                    isNew = true;
                }
                oLabel.STKCODE = this.txtStockCode_Chs.Text.Trim();
                oLabel.APPENDIX1 = this.txtAppendix1_Chs.Text.Trim();
                oLabel.APPENDIX2 = this.txtAppendix2_Chs.Text.Trim();
                oLabel.APPENDIX3 = this.txtAppendix3_Chs.Text.Trim();
                oLabel.CLASS1 = this.txtClass1_Chs.Text.Trim();
                oLabel.CLASS2 = this.txtClass2_Chs.Text.Trim();
                oLabel.CLASS3 = this.txtClass3_Chs.Text.Trim();
                oLabel.CLASS4 = this.txtClass4_Chs.Text.Trim();
                oLabel.CLASS5 = this.txtClass5_Chs.Text.Trim();
                oLabel.CLASS6 = this.txtClass6_Chs.Text.Trim();
                oLabel.SERIALNO = this.txtSerialNumber_Chs.Text.Trim();
                oLabel.VITEMNO = this.txtVITEMNO_Chs.Text.Trim();
                oLabel.COUPONNO = this.txtCouponNumber_Chs.Text.Trim();
                oLabel.REMARK1 = this.txtRemarks1_Chs.Text.Trim();
                oLabel.REMARK2 = this.txtRemarks2_Chs.Text.Trim();
                oLabel.REMARK3 = this.txtRemarks3_Chs.Text.Trim();
                oLabel.REMARK4 = this.txtRemarks4_Chs.Text.Trim();
                oLabel.REMARK5 = this.txtRemarks5_Chs.Text.Trim();
                oLabel.REMARK6 = this.txtRemarks6_Chs.Text.Trim();

                if (isNew)
                {
                    oLabel.DLFLAG = "A";
                }
                else
                {
                    oLabel.DLFLAG = "M";
                }

                ctx.SaveChanges();
            }
        }

        private void SaveLabel_Cht()
        {
            bool isNew = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oLabel = ctx.SystemLabel.Where(x => x.LanguageCode == "zh-CHT").FirstOrDefault();
                if (oLabel == null)
                {
                    oLabel = new EF6.SystemLabel();
                    oLabel.LabelId = Guid.NewGuid();
                    oLabel.LanguageCode = "zh-CHT";

                    ctx.SystemLabel.Add(oLabel);
                    isNew = true;
                }
                oLabel.STKCODE = this.txtStockCode_Cht.Text.Trim();
                oLabel.APPENDIX1 = this.txtAppendix1_Cht.Text.Trim();
                oLabel.APPENDIX2 = this.txtAppendix2_Cht.Text.Trim();
                oLabel.APPENDIX3 = this.txtAppendix3_Cht.Text.Trim();
                oLabel.CLASS1 = this.txtClass1_Cht.Text.Trim();
                oLabel.CLASS2 = this.txtClass2_Cht.Text.Trim();
                oLabel.CLASS3 = this.txtClass3_Cht.Text.Trim();
                oLabel.CLASS4 = this.txtClass4_Cht.Text.Trim();
                oLabel.CLASS5 = this.txtClass5_Cht.Text.Trim();
                oLabel.CLASS6 = this.txtClass6_Cht.Text.Trim();
                oLabel.SERIALNO = this.txtSerialNumber_Cht.Text.Trim();
                oLabel.VITEMNO = this.txtVITEMNO_Cht.Text.Trim();
                oLabel.COUPONNO = this.txtCouponNumber_Cht.Text.Trim();
                oLabel.REMARK1 = this.txtRemarks1_Cht.Text.Trim();
                oLabel.REMARK2 = this.txtRemarks2_Cht.Text.Trim();
                oLabel.REMARK3 = this.txtRemarks3_Cht.Text.Trim();
                oLabel.REMARK4 = this.txtRemarks4_Cht.Text.Trim();
                oLabel.REMARK5 = this.txtRemarks5_Cht.Text.Trim();
                oLabel.REMARK6 = this.txtRemarks6_Cht.Text.Trim();

                if (isNew)
                {
                    oLabel.DLFLAG = "A";
                }
                else
                {
                    oLabel.DLFLAG = "M";
                }

                ctx.SaveChanges();
            }
        }
        #endregion

        #region Refresh Nav Bar
        private void Refresh()
        {
            Desktop desktop = null;
            //Panel navPane = null;
            //NavigationTabs navTabs = null;
            //InventoryNav invtNav = null;
            TreeView tv = null;

            if (this.Parent.Parent != null)
                desktop = this.Parent.Parent as Desktop;

            // 2009-12-30 david: 在查询NavigationTabs时，出现错误。
            //if (desktop != null)
            //{
            //    Gizmox.WebGUI.Forms.Control[] ctrlList = desktop.Controls.Find("navPane", true);
            //    if (ctrlList.Length > 0)
            //    {
            //        navPane = ctrlList[0] as Panel;
            //    }
            //}

            //if (navPane != null)
            //{
            //    Gizmox.WebGUI.Forms.Control[] ctrlList = navPane.Controls.Find("navTabs", true);
            //    if (ctrlList.Length > 0)
            //    {
            //        navTabs = ctrlList[0] as NavigationTabs;
            //    }
            //}

            //if (navTabs != null)
            //{
            //    if (navTabs.TabPages[0].Controls.Count > 0)
            //    {
            //        invtNav = navTabs.TabPages[0].Controls[0] as InventoryNav;
            //    }
            //}

            //if (invtNav != null)
            //{
            //    if (invtNav.Controls.Count > 0)
            //    {
            //        tv = invtNav.Controls[0] as TreeView;
            //    }
            //}

            if (desktop != null)
            {
                // 2009-12-30 david: 直接去找TreeView Control（"navInvt"）
                Gizmox.WebGUI.Forms.Control[] ctrlList = desktop.Controls.Find("navInvt", true);
                for (int i = 0; i < ctrlList.Length; i++)
                {
                    if (ctrlList[i] is TreeView)
                    {
                        tv = ctrlList[i] as TreeView;
                        break;
                    }
                }
            }

            if (tv != null)
            {
                tv.Nodes.Clear();
                NavPane.NavMenu.FillNavTree("inventory", tv.Nodes);
            }
        }
        #endregion

        private void SystemLabels_Load(object sender, EventArgs e)
        {
            LoadLabels();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveLabel();
            MessageBox.Show("Save successfully!", "Message", new EventHandler(RefreshEventHandler));
        }

        private void cmdSave_Chs_Click(object sender, EventArgs e)
        {
            SaveLabel_Chs();
            MessageBox.Show("Save successfully!", "Message", new EventHandler(RefreshEventHandler));
        }

        private void cmdSave_Cht_Click(object sender, EventArgs e)
        {
            SaveLabel_Cht();
            MessageBox.Show("Save successfully!", "Message", new EventHandler(RefreshEventHandler));
        }

        private void RefreshEventHandler(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}