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
using System.IO;
using RT2020.Controls;

using RT2020.Helper;
using System.Linq;
using RT2020.ModelEx;

#endregion

namespace RT2020.Settings
{
    public partial class SystemInfoForm : UserControl
    {
        string mstrDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfoForm"/> class.
        /// </summary>
        public SystemInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the SystemInfoForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SystemInfoForm_Load(object sender, EventArgs e)
        {
            mstrDirectory = Context.Config.GetDirectory("Images");

            this.SetToolBar();
            this.SetAttributes();
            this.LoadLastTxNumber();
        }

        #region Set Attributes

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        private void SetAttributes()
        {

            // Company Info.
            txtOfficeNumber.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.ShopNumber;
            txtCompanyInitial.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.CompanyNameInitial;
            txtPhoneNumber.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.TEL;
            txtFaxNumber.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.FAX;
            txtEmail.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.EMail;
            txtInternetUrl.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.URL;

            #region Address Info.

            #region Default
            gbAddressDefault.Text = WestwindHelper.GetWord("language.en", "Menu");

            txtCompanyNameEn.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.CompanyName;
            txtAddressEn.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.CompanyAddess;
            #endregion

            #region Alt-1
            if (LanguageHelper.AlternateLanguagesUsed >= 1)
            {
                // 攞個 Alt1，不過唔用個 Value (NativeName)，去 Westwind 搵自己叫嘅名
                gbAddressAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");

                txtCompanyNameAlt1.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.CompanyName_Chs;
                txtAddressAlt1.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.CompanyAddress_Chs;
            }
            else
            {
                gbAddressAlt1.Visible = false;
            }
            #endregion

            #region Alt-2
            if (LanguageHelper.AlternateLanguagesUsed >= 2)
            {
                // 攞個 Alt2，不過唔用個 Value (NativeName)，去 Westwind 搵自己叫嘅名
                gbAddressAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

                txtCompanyNameAlt2.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.CompanyName_Cht;
                txtAddressAlt2.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.CompanyAddress_Cht;
            }
            else
            {
                gbAddressAlt2.Visible = false;
            }
            #endregion

            #endregion

            // System Info.
            txtLastAPMonthEnd.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtLastAPYearEnd.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtLastARMonthEnd.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtLastARYearEnd.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtLastMonthEnd.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtLastYearEnd.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            txtLastMonthEnd.Text = SystemInfoEx.CurrentInfo.Default.LastMonthEnd;
            txtLastYearEnd.Text = SystemInfoEx.CurrentInfo.Default.LastYearEnd;
            txtLastARMonthEnd.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.LastMonthEnd_AR == 0 ? "" : SystemInfoEx.CurrentInfo.Default.SysInfo.LastMonthEnd_AR.ToString();
            txtLastARYearEnd.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.LastYearEnd_AR == 0 ? "" : SystemInfoEx.CurrentInfo.Default.SysInfo.LastYearEnd_AR.ToString();
            txtLastAPMonthEnd.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.LastMonthEnd_AP == 0 ? "" : SystemInfoEx.CurrentInfo.Default.SysInfo.LastMonthEnd_AP.ToString();
            txtLastAPYearEnd.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.LastYearEnd_AP == 0 ? "" : SystemInfoEx.CurrentInfo.Default.SysInfo.LastYearEnd_AP.ToString();

            // Logo
            txtCompanyLogo.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.LOGO;
            imgLogo.ImageName = SystemInfoEx.CurrentInfo.Default.SysInfo.LOGO;

            // Letter Head
            txtLetterHead.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.LetterHead;
            imgLetterHead.ImageName = SystemInfoEx.CurrentInfo.Default.SysInfo.LetterHead;

            // Others
            txtTransferHHTMode.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtPacketType.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            txtTaxRate.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.TaxRate.Value.ToString("n2");
            txtTaxRegisterNumber.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.TaxRegisterNumber;
            chkPriceTagIncludeTax.Checked = SystemInfoEx.CurrentInfo.Default.SysInfo.PriceTag_TaxInclusive.Value;

            txtDomesticCurrency.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.BasicCurrency;
            txtOTBClassLevel.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.OTBClassLevel;
            txtBarcodeLabelFormat.Text = SystemInfoEx.CurrentInfo.Default.SysInfo.BarcodeLabelFormat;
            txtTransferHHTMode.Text = string.IsNullOrEmpty(SystemInfoEx.CurrentInfo.Default.SysInfo.HotSyncMode_HHT) ? "F" : SystemInfoEx.CurrentInfo.Default.SysInfo.HotSyncMode_HHT;
            txtPacketType.Text = string.IsNullOrEmpty(SystemInfoEx.CurrentInfo.Default.SysInfo.PacketType) ? "UNICODE" : SystemInfoEx.CurrentInfo.Default.SysInfo.PacketType;
            chkUseMultiplePricebook.Checked = SystemInfoEx.CurrentInfo.Default.SysInfo.AllowMultiplePricebook.Value;

            this.SetBackColor();
        }

        /// <summary>
        /// Sets the color of the back.
        /// </summary>
        private void SetBackColor()
        {
            for (int i = 0; i < lastTxNumberPane.Controls.Count; i++)
            {
                Control ctrl = lastTxNumberPane.Controls[i];

                if (ctrl is GroupBox)
                {
                    GroupBox gbCtrl = ctrl as GroupBox;
                    if (gbCtrl != null)
                    {
                        this.SetBackColor(gbCtrl);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the color of the back.
        /// </summary>
        /// <param name="gbCtrl">The gb CTRL.</param>
        private void SetBackColor(GroupBox gbCtrl)
        {
            for (int i = 0; i < gbCtrl.Controls.Count; i++)
            {
                Control ctrl = gbCtrl.Controls[i];

                if (ctrl is TextBox)
                {
                    TextBox txtCtrl = ctrl as TextBox;
                    if (txtCtrl != null)
                    {
                        if (txtCtrl.Name == "txtPricePromotion")
                        {
                            txtCtrl.Enabled = false;
                            txtCtrl.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
                        }
                        else
                        {
                            txtCtrl.BackColor = SystemInfoHelper.ControlBackColor.RequiredBox;
                        }
                    }
                }
            }
        }

        #endregion

        #region ToolBar

        /// <summary>
        /// Sets the tool bar.
        /// </summary>
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);
            this.tbWizardAction.Buttons.Add(sep);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        /// <summary>
        /// Handles the ButtonClick event of the tbWizardAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        this.Save();
                        this.SaveQueuingNumber();

                        MessageBox.Show("Save successfully!", "Message");
                        break;
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnaddlogo":
                            if (openFileDialog_Logo.ShowDialog() == DialogResult.OK)
                            {
                                txtCompanyLogo.Text = openFileDialog_Logo.FileName;
                                imgLogo.ImageName = openFileDialog_Logo.FileName;
                            }
                            break;
                        case "btnaddletterhead":
                            if (openFileDialog_LetterHead.ShowDialog() == DialogResult.OK)
                            {
                                txtLetterHead.Text = openFileDialog_LetterHead.FileName;
                                imgLetterHead.ImageName = openFileDialog_LetterHead.FileName;
                            }
                            break;
                        case "btndeletelogo":
                            MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteLogoConfirmationHandler));
                            break;
                        case "btndeleteletterhead":
                            MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteLetterHeadConfirmationHandler));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the logo confirmation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DeleteLogoConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                string picPath = Path.Combine(mstrDirectory, txtCompanyLogo.Text);

                imgLogo.ImageName = Path.Combine(VWGContext.Current.Config.GetDirectory("Images"), "no_photo.jpg");

                if (File.Exists(picPath))
                {
                    try
                    {
                        File.Delete(picPath);

                        if (ModelEx.SystemInfoEx.ClearLogoInfo(SystemInfoEx.CurrentInfo.Default.SysInfo.InfoId))
                        {
                            MessageBox.Show("The picture '" + txtCompanyLogo.Text + "' is deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("The picture does not exist in database.", "Delete Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Delete Failed!");
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the letter head confirmation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DeleteLetterHeadConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                string picPath = Path.Combine(mstrDirectory, txtLetterHead.Text);

                imgLogo.ImageName = Path.Combine(VWGContext.Current.Config.GetDirectory("Images"), "no_photo.jpg");

                if (File.Exists(picPath))
                {
                    try
                    {
                        File.Delete(picPath);

                        if (ModelEx.SystemInfoEx.ClearLogoInfo(SystemInfoEx.CurrentInfo.Default.SysInfo.InfoId))
                        {
                            MessageBox.Show("The picture '" + txtLetterHead.Text + "' is deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("The picture does not exist in database.", "Delete Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Delete Failed!");
                    }
                }
            }
        }

        /// <summary>
        /// Handles the FileOk event of the openFileDialog_LetterHead control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void openFileDialog_LetterHead_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtLetterHead.Text = Utility.UploadFile(openFileDialog_LetterHead, mstrDirectory);
            imgLetterHead.ImageName = Path.Combine(mstrDirectory, txtLetterHead.Text);
        }

        /// <summary>
        /// Handles the FileOk event of the openFileDialog_Logo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void openFileDialog_Logo_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtCompanyLogo.Text = Utility.UploadFile(openFileDialog_Logo, mstrDirectory);
            imgLogo.ImageName = Path.Combine(mstrDirectory, txtCompanyLogo.Text);
        } 

        #endregion

        #region Load Last TxNumber

        /// <summary>
        /// Loads the last tx number.
        /// </summary>
        private void LoadLastTxNumber()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var queueList = ctx.SystemQueue.ToList();
                foreach (var queue in queueList)
                {
                    string key = "txt" + queue.QueuingType;

                    Control[] ctrlList = lastTxNumberPane.Controls.Find(key, true);
                    if (ctrlList.Length > 0)
                    {
                        if (ctrlList[0] is TextBox)
                        {
                            TextBox txtCtrl = ctrlList[0] as TextBox;
                            if (txtCtrl != null)
                            {
                                txtCtrl.Text = queue.LastNumber.ToString().PadLeft(12, '0');

                                if (txtCtrl.Name == "txtPMS")
                                {
                                    txtPricePromotion.Text = txtCtrl.Text;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oSysInfo = ctx.SystemInfo.Find(SystemInfoEx.CurrentInfo.Default.SysInfo.InfoId);
                if (oSysInfo != null)
                {
                    // Company Info.
                    oSysInfo.ShopNumber = txtOfficeNumber.Text;
                    oSysInfo.CompanyNameInitial = txtCompanyInitial.Text;
                    oSysInfo.TEL = txtPhoneNumber.Text;
                    oSysInfo.FAX = txtFaxNumber.Text;
                    oSysInfo.EMail = txtEmail.Text;
                    oSysInfo.URL = txtInternetUrl.Text;

                    // Address Info.
                    // English
                    oSysInfo.CompanyName = txtCompanyNameEn.Text;
                    oSysInfo.CompanyAddess = txtAddressEn.Text;

                    // Chinese
                    oSysInfo.CompanyName_Chs = txtCompanyNameAlt1.Text;
                    oSysInfo.CompanyAddress_Chs = txtAddressAlt1.Text;
                    oSysInfo.CompanyName_Cht = txtCompanyNameAlt1.Text;
                    oSysInfo.CompanyAddress_Cht = txtAddressAlt1.Text;

                    // Logo
                    oSysInfo.LOGO = txtCompanyLogo.Text;

                    // Letter Head
                    oSysInfo.LetterHead = txtLetterHead.Text;

                    // Others

                    oSysInfo.TaxRate = txtTaxRate.Text.All(char.IsNumber) ? Convert.ToDecimal(txtTaxRate.Text.Trim()) : 0;
                    oSysInfo.TaxRegisterNumber = txtTaxRegisterNumber.Text;
                    oSysInfo.PriceTag_TaxInclusive = chkPriceTagIncludeTax.Checked;

                    oSysInfo.BasicCurrency = txtDomesticCurrency.Text;
                    oSysInfo.OTBClassLevel = txtOTBClassLevel.Text;
                    oSysInfo.BarcodeLabelFormat = txtBarcodeLabelFormat.Text;
                    oSysInfo.HotSyncMode_HHT = txtTransferHHTMode.Text;
                    oSysInfo.PacketType = txtPacketType.Text;
                    oSysInfo.AllowMultiplePricebook = chkUseMultiplePricebook.Checked;

                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Saves the queuing number.
        /// </summary>
        private void SaveQueuingNumber()
        {
            for (int i = 0; i < lastTxNumberPane.Controls.Count; i++)
            {
                Control ctrl = lastTxNumberPane.Controls[i];

                if (ctrl is GroupBox)
                {
                    GroupBox gbCtrl = ctrl as GroupBox;
                    if (gbCtrl != null)
                    {
                        this.SaveQueuingNumber(gbCtrl);
                    }
                }
            }
        }

        /// <summary>
        /// Saves the queuing number.
        /// </summary>
        /// <param name="gbCtrl">The gb CTRL.</param>
        private void SaveQueuingNumber(GroupBox gbCtrl)
        {
            for (int i = 0; i < gbCtrl.Controls.Count; i++)
            {
                Control ctrl = gbCtrl.Controls[i];
                if (ctrl is TextBox)
                {
                    TextBox txtCtrl = ctrl as TextBox;
                    if (txtCtrl != null)
                    {
                        string queueType = txtCtrl.Name.Remove(0, 3);

                        if (queueType.Length == 3)
                        {
                            using (var ctx = new EF6.RT2020Entities())
                            {
                                var queue = ctx.SystemQueue.Where(x => x.QueuingType == queueType).FirstOrDefault();
                                if (queue == null)
                                {
                                    queue = new EF6.SystemQueue();
                                    queue.QueueId = Guid.NewGuid();
                                    queue.QueuingType = queueType;
                                    queue.LastNumber = "0".PadLeft(12, '0');
                                    ctx.SystemQueue.Add(queue);
                                }
                                
                                if (txtCtrl.Text.All(char.IsNumber))
                                //if (Common.Utility.IsNumeric(txtCtrl.Text))
                                {
                                    queue.LastNumber = txtCtrl.Text.ToString();
                                }

                                ctx.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtPMS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtPMS_TextChanged(object sender, EventArgs e)
        {
            txtPricePromotion.Text = txtPMS.Text;
        }
    }
}