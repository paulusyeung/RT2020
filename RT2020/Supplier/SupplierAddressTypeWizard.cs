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
using System.Configuration;
using RT2020.Helper;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierAddressTypeWizard : Form
    {
        public SupplierAddressTypeWizard()
        {
            InitializeComponent();
            SetCtrlEditable();
            SetToolBar();
            BindAddressTypeList();
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
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", "Refresh");
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
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
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
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
                        Clear();
                        SetCtrlEditable();
                        break;
                    case "save":
                        if (Save())
                        {
                            Clear();
                            BindAddressTypeList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindAddressTypeList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region SupplierAddressType Code
        private void SetCtrlEditable()
        {
            txtAddressTypeCode.BackColor = (this.AddressTypeId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtAddressTypeCode.ReadOnly = (this.AddressTypeId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtAddressTypeCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }
        #endregion

        #region Binding
        private void BindAddressTypeList()
        {
            this.lvAddressTypeList.ListViewItemSorter = new ListViewItemSorter(lvAddressTypeList);
            this.lvAddressTypeList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT AddressTypeId,  ROW_NUMBER() OVER (ORDER BY AddressTypeCode) AS rownum, ");
            sql.Append(" AddressTypeCode, AddressTypeName, AddressTypeName_Chs, AddressTypeName_Cht ");
            sql.Append(" FROM SupplierAddressType ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvAddressTypeList.Items.Add(reader.GetGuid(0).ToString()); // AddressTypeId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // AddressTypeCode
                    objItem.SubItems.Add(reader.GetString(3)); // SupplierAddressType Name
                    objItem.SubItems.Add(reader.GetString(4)); // SupplierAddressType Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // SupplierAddressType Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Type Code 唔可以吉
            errorProvider.SetError(txtAddressTypeCode, string.Empty);
            if (txtAddressTypeCode.Text.Length == 0)
            {
                errorProvider.SetError(txtAddressTypeCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Type Code 係咪 in use
            errorProvider.SetError(txtAddressTypeCode, string.Empty);
            if (ModelEx.SupplierAddressTypeEx.IsCodeInUse(txtAddressTypeCode.Text.Trim()))
            {
                errorProvider.SetError(txtAddressTypeCode, "Type Code in use");
                return false;
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierAddressType.Find(this.AddressTypeId);

                if (item == null)
                {
                    item = new EF6.SupplierAddressType();
                    item.AddressTypeId = new Guid();
                    item.AddressTypeCode = txtAddressTypeCode.Text;

                    ctx.SupplierAddressType.Add(item);
                }
                item.AddressTypeName = txtAddressTypeName.Text;
                item.AddressTypeName_Chs = txtAddressTypeNameChs.Text;
                item.AddressTypeName_Cht = txtAddressTypeNameCht.Text;
                item.Priority = Convert.ToInt32(txtPriority.Text);

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            SupplierAddressTypeWizard wizType = new SupplierAddressTypeWizard();
            wizType.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid AddressTypeId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
            }
        }
        #endregion

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.SupplierAddressType.Find(this.AddressTypeId);
                    if (item != null)
                    {
                        ctx.SupplierAddressType.Remove(item);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvAddressTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAddressTypeList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvAddressTypeList.SelectedItem.Text, out id))
                {
                    this.AddressTypeId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var item = ctx.SupplierAddressType.Find(id);
                        if (item != null)
                        {
                            txtAddressTypeCode.Text = item.AddressTypeCode;
                            txtAddressTypeName.Text = item.AddressTypeName;
                            txtAddressTypeNameChs.Text = item.AddressTypeName_Chs;
                            txtAddressTypeNameCht.Text = item.AddressTypeName_Cht;
                            txtPriority.Text = item.Priority.ToString();

                            SetCtrlEditable();
                            SetToolBar();
                        }
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindAddressTypeList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}