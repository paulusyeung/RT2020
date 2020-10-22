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
using RT2020.DAL;

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
            txtOfficeNumber.Text = SystemInfo.CurrentInfo.Default.SysInfo.ShopNumber;
            txtCompanyInitial.Text = SystemInfo.CurrentInfo.Default.SysInfo.CompanyNameInitial;
            txtPhoneNumber.Text = SystemInfo.CurrentInfo.Default.SysInfo.TEL;
            txtFaxNumber.Text = SystemInfo.CurrentInfo.Default.SysInfo.FAX;
            txtEmail.Text = SystemInfo.CurrentInfo.Default.SysInfo.EMail;
            txtInternetUrl.Text = SystemInfo.CurrentInfo.Default.SysInfo.URL;

            // Address Info.
            // English
            txtCompanyNameEn.Text = SystemInfo.CurrentInfo.Default.SysInfo.CompanyName;
            txtAddressEn.Text = SystemInfo.CurrentInfo.Default.SysInfo.CompanyAddess;

            // Chinese
            txtCompanyNameChn.Text = SystemInfo.CurrentInfo.Default.SysInfo.CompanyName_Chs;
            txtAddressChn.Text = SystemInfo.CurrentInfo.Default.SysInfo.CompanyAddress_Chs;

            // System Info.
            txtLastAPMonthEnd.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtLastAPYearEnd.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtLastARMonthEnd.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtLastARYearEnd.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtLastMonthEnd.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtLastYearEnd.BackColor = SystemInfo.ControlBackColor.DisabledBox;

            txtLastMonthEnd.Text = SystemInfo.CurrentInfo.Default.LastMonthEnd;
            txtLastYearEnd.Text = SystemInfo.CurrentInfo.Default.LastYearEnd;
            txtLastARMonthEnd.Text = SystemInfo.CurrentInfo.Default.SysInfo.LastMonthEnd_AR == 0 ? "" : SystemInfo.CurrentInfo.Default.SysInfo.LastMonthEnd_AR.ToString();
            txtLastARYearEnd.Text = SystemInfo.CurrentInfo.Default.SysInfo.LastYearEnd_AR == 0 ? "" : SystemInfo.CurrentInfo.Default.SysInfo.LastYearEnd_AR.ToString();
            txtLastAPMonthEnd.Text = SystemInfo.CurrentInfo.Default.SysInfo.LastMonthEnd_AP == 0 ? "" : SystemInfo.CurrentInfo.Default.SysInfo.LastMonthEnd_AP.ToString();
            txtLastAPYearEnd.Text = SystemInfo.CurrentInfo.Default.SysInfo.LastYearEnd_AP == 0 ? "" : SystemInfo.CurrentInfo.Default.SysInfo.LastYearEnd_AP.ToString();

            // Logo
            txtCompanyLogo.Text = SystemInfo.CurrentInfo.Default.SysInfo.LOGO;
            imgLogo.ImageName = SystemInfo.CurrentInfo.Default.SysInfo.LOGO;

            // Letter Head
            txtLetterHead.Text = SystemInfo.CurrentInfo.Default.SysInfo.LetterHead;
            imgLetterHead.ImageName = SystemInfo.CurrentInfo.Default.SysInfo.LetterHead;

            // Others
            txtTransferHHTMode.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtPacketType.BackColor = SystemInfo.ControlBackColor.DisabledBox;

            txtTaxRate.Text = SystemInfo.CurrentInfo.Default.SysInfo.TaxRate.ToString("n2");
            txtTaxRegisterNumber.Text = SystemInfo.CurrentInfo.Default.SysInfo.TaxRegisterNumber;
            chkPriceTagIncludeTax.Checked = SystemInfo.CurrentInfo.Default.SysInfo.PriceTag_TaxInclusive;

            txtDomesticCurrency.Text = SystemInfo.CurrentInfo.Default.SysInfo.BasicCurrency;
            txtOTBClassLevel.Text = SystemInfo.CurrentInfo.Default.SysInfo.OTBClassLevel;
            txtBarcodeLabelFormat.Text = SystemInfo.CurrentInfo.Default.SysInfo.BarcodeLabelFormat;
            txtTransferHHTMode.Text = string.IsNullOrEmpty(SystemInfo.CurrentInfo.Default.SysInfo.HotSyncMode_HHT) ? "F" : SystemInfo.CurrentInfo.Default.SysInfo.HotSyncMode_HHT;
            txtPacketType.Text = string.IsNullOrEmpty(SystemInfo.CurrentInfo.Default.SysInfo.PacketType) ? "UNICODE" : SystemInfo.CurrentInfo.Default.SysInfo.PacketType;
            chkUseMultiplePricebook.Checked = SystemInfo.CurrentInfo.Default.SysInfo.AllowMultiplePricebook;

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
                            txtCtrl.BackColor = SystemInfo.ControlBackColor.DisabledBox;
                        }
                        else
                        {
                            txtCtrl.BackColor = SystemInfo.ControlBackColor.RequiredBox;
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

                        RT2020.DAL.SystemInfo oSysInfo = RT2020.DAL.SystemInfo.Load(SystemInfo.CurrentInfo.Default.SysInfo.InfoId);
                        if (oSysInfo != null)
                        {
                            oSysInfo.LOGO = string.Empty;

                            oSysInfo.Save();

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

                        RT2020.DAL.SystemInfo oSysInfo = RT2020.DAL.SystemInfo.Load(SystemInfo.CurrentInfo.Default.SysInfo.InfoId);
                        if (oSysInfo != null)
                        {
                            oSysInfo.LetterHead = string.Empty;

                            oSysInfo.Save();

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
            SystemQueueCollection queueList = SystemQueue.LoadCollection();
            for (int i = 0; i < queueList.Count; i++)
            {
                SystemQueue queue = queueList[i];
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

        #endregion

        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            RT2020.DAL.SystemInfo oSysInfo = RT2020.DAL.SystemInfo.Load(SystemInfo.CurrentInfo.Default.SysInfo.InfoId);
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
                oSysInfo.CompanyName_Chs = txtCompanyNameChn.Text;
                oSysInfo.CompanyAddress_Chs = txtAddressChn.Text;
                oSysInfo.CompanyName_Cht = txtCompanyNameChn.Text;
                oSysInfo.CompanyAddress_Cht = txtAddressChn.Text;

                // Logo
                oSysInfo.LOGO = txtCompanyLogo.Text;

                // Letter Head
                oSysInfo.LetterHead = txtLetterHead.Text;

                // Others

                oSysInfo.TaxRate = Common.Utility.IsNumeric(txtTaxRate.Text) ? Convert.ToDecimal(txtTaxRate.Text.Trim()) : 0;
                oSysInfo.TaxRegisterNumber = txtTaxRegisterNumber.Text;
                oSysInfo.PriceTag_TaxInclusive = chkPriceTagIncludeTax.Checked;

                oSysInfo.BasicCurrency = txtDomesticCurrency.Text;
                oSysInfo.OTBClassLevel = txtOTBClassLevel.Text;
                oSysInfo.BarcodeLabelFormat = txtBarcodeLabelFormat.Text;
                oSysInfo.HotSyncMode_HHT = txtTransferHHTMode.Text;
                oSysInfo.PacketType = txtPacketType.Text;
                oSysInfo.AllowMultiplePricebook = chkUseMultiplePricebook.Checked;

                oSysInfo.Save();
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
                            string sql = "QueuingType = '" + queueType + "'";
                            SystemQueue queue = SystemQueue.LoadWhere(sql);
                            if (queue == null)
                            {
                                queue = new SystemQueue();
                                queue.QueuingType = queueType;
                                queue.LastNumber = "0".PadLeft(12, '0');
                            }

                            if (Common.Utility.IsNumeric(txtCtrl.Text))
                            {
                                queue.LastNumber = txtCtrl.Text.ToString();
                            }

                            queue.Save();
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