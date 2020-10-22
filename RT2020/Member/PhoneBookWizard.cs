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
using System.Data.SqlClient;
using RT2020.DAL;
using System.Configuration;

#endregion

namespace RT2020.Member
{
    public partial class PhoneBookWizard : Form
    {
        public PhoneBookWizard(Guid memberId, Guid addressTypeId)
        {
            InitializeComponent();
            this.MemberId = memberId;
            this.AddressTypeId = addressTypeId;
            SetToolBar();
            InitialPhoneTag();
            LoadPhoneBook();
        }

        private void InitialPhoneTag()
        {
            RT2020.Controls.PhoneTag oTag = new RT2020.Controls.PhoneTag(this);
            oTag.SetPhoneTag();
        }

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", "New");
            cmdNew.Tag = "New";
            cmdNew.Enabled = false;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (AddressTypeId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Delete);
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "new":
                        break;
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveConfirmationHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Load
        private void LoadPhoneBook()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT VipNumber, ISNULL(PhoneBook, '') AS PhoneBook, AddressTypeCode, Phone_W, Phone_H, Fax, Phone_Other, Phone_P ");
            sql.Append(" FROM vwPhonebookList ");
            sql.Append(" WHERE ");
            sql.Append(" MemberId = '").Append(this.MemberId.ToString()).Append("'");
            sql.Append(" AND ");
            sql.Append(" AddressTypeId = '").Append(this.AddressTypeId.ToString()).Append("'");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    txtVipNumber.Text = reader.GetString(0);
                    txtPhoneBook.Text = reader.GetString(1);
                    txtType.Text = reader.GetString(2);
                    txtPhoneTag1.Text = reader.GetString(3);
                    txtPhoneTag2.Text = reader.GetString(4);
                    txtPhoneTag3.Text = reader.GetString(5);
                    txtPhoneTag4.Text = reader.GetString(6);
                    txtPhoneTag5.Text = reader.GetString(7);
                }
            }
        }
        #endregion

        #region Save
        private void Save()
        {
            SavePhoneBook();
        }

        private void SavePhoneBook()
        {
            RT2020.DAL.Member oMember = RT2020.DAL.Member.Load(this.MemberId);
            if (oMember != null)
            {
                oMember.ModifiedBy = Common.Config.CurrentUserId;
                oMember.ModifiedOn = DateTime.Now;
                oMember.Save();

                PhoneDetails();
            }
        }

        private void PhoneDetails()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" MemberId = '").Append(this.MemberId.ToString()).Append("'");

            MemberVipData oVip = MemberVipData.LoadWhere(sql.ToString());
            if (oVip != null)
            {
                oVip.SetMetadata("Address_Phone_Pager_" + this.AddressTypeId.ToString().Replace("-", ""), txtPhoneTag5.Text);
                oVip.Save();
            }

            sql.Append(" AND ");
            sql.Append(" AddressTypeId = '").Append(this.AddressTypeId.ToString()).Append("'");

            MemberAddress oAddress = MemberAddress.LoadWhere(sql.ToString());
            if (oAddress != null)
            {
                oAddress.PhoneTag1Value = txtPhoneTag1.Text;
                oAddress.PhoneTag2Value = txtPhoneTag2.Text;
                oAddress.PhoneTag3Value = txtPhoneTag3.Text;
                oAddress.PhoneTag4Value = txtPhoneTag4.Text;
                oAddress.Save();
            }
        }
        #endregion

        #region properties
        private Guid memberId = System.Guid.Empty;
        public Guid MemberId
        {
            get
            {
                return memberId;
            }
            set
            {
                memberId = value;
            }
        }

        private Guid addressTypeId = System.Guid.Empty;
        public Guid AddressTypeId
        {
            get
            {
                return addressTypeId;
            }
            set
            {
                addressTypeId = value;
            }
        }
        #endregion

        private void SaveConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                //Delete();
            }
        }
    }
}