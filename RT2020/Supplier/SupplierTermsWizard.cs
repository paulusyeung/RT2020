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
using RT2020.DAL;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierTermsWizard : Form
    {
        public SupplierTermsWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentTermsList();
            BindSupplierTermsList();
            SetCtrlEditable();
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
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

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

            if (SupplierTermsId == System.Guid.Empty)
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
                        Clear();
                        SetCtrlEditable();
                        break;
                    case "save":
                        if (Save())
                        {
                            Clear();
                            BindSupplierTermsList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindSupplierTermsList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region SupplierTerms Code
        private void SetCtrlEditable()
        {
            txtSupplierTermsCode.BackColor = (this.SupplierTermsId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtSupplierTermsCode.ReadOnly = (this.SupplierTermsId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtSupplierTermsCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentTermsList()
        {
            string sql = "TermsId NOT IN ('" + this.SupplierTermsId.ToString() + "')";
            string[] orderBy = new string[] { "TermsCode" };
            ModelEx.SupplierTermsEx.LoadCombo(ref cboParentTerms, "TermsCode", true, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindSupplierTermsList()
        {
            this.lvSupplierTermsList.ListViewItemSorter = new ListViewItemSorter(lvSupplierTermsList);
            this.lvSupplierTermsList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT TermsId,  ROW_NUMBER() OVER (ORDER BY TermsCode) AS rownum, ");
            sql.Append(" TermsCode, TermsName, TermsName_Chs, TermsName_Cht ");
            sql.Append(" FROM SupplierTerms ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvSupplierTermsList.Items.Add(reader.GetGuid(0).ToString()); // SupplierTermsId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // SupplierTermsCode
                    objItem.SubItems.Add(reader.GetString(3)); // SupplierTerms Name
                    objItem.SubItems.Add(reader.GetString(4)); // SupplierTerms Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // SupplierTerms Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Terms Code 唔可以吉
            errorProvider.SetError(txtSupplierTermsCode, string.Empty);
            if (txtSupplierTermsCode.Text.Length == 0)
            {
                errorProvider.SetError(txtSupplierTermsCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Terms Code 係咪 in use
            errorProvider.SetError(txtSupplierTermsCode, string.Empty);
            if (ModelEx.SupplierTermsEx.IsTermsCodeInUse(txtSupplierTermsCode.Text.Trim()))
            {
                errorProvider.SetError(txtSupplierTermsCode, "Terms Code in use");
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
                var item = ctx.SupplierTerms.Find(this.SupplierTermsId);

                if (item == null)
                {
                    item = new EF6.SupplierTerms();
                    item.TermsId = new Guid();
                    item.TermsCode = txtSupplierTermsCode.Text;

                    ctx.SupplierTerms.Add(item);
                }
                item.TermsName = txtSupplierTermsName.Text;
                item.TermsName_Chs = txtSupplierTermsNameChs.Text;
                item.TermsName_Cht = txtSupplierTermsNameCht.Text;
                if ((Guid)cboParentTerms.SelectedValue != Guid.Empty) item.ParentTerms = (Guid)cboParentTerms.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            SupplierTermsWizard wizTerms = new SupplierTermsWizard();
            wizTerms.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid SupplierTermsId
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

        private bool Delete()
        {
            bool result = true;

            result = ModelEx.SupplierTermsEx.Delete(this.SupplierTermsId);

            if (!result)
            {
                MessageBox.Show("Cannot delete...the record might be in use!", "Delete Warning");
            }

            return result;
        }

        private void lvSupplierTermsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSupplierTermsList.SelectedItem != null)
            {
                Guid id = Guid.Empty;

                if (Guid.TryParse(lvSupplierTermsList.SelectedItem.Text, out id))
                {
                    var oSupplierTerms = ModelEx.SupplierTermsEx.Get(id);
                    if (oSupplierTerms != null)
                    {
                        this.SupplierTermsId = oSupplierTerms.TermsId;

                        FillParentTermsList();

                        txtSupplierTermsCode.Text = oSupplierTerms.TermsCode;
                        txtSupplierTermsName.Text = oSupplierTerms.TermsName;
                        txtSupplierTermsNameChs.Text = oSupplierTerms.TermsName_Chs;
                        txtSupplierTermsNameCht.Text = oSupplierTerms.TermsName_Cht;
                        cboParentTerms.SelectedValue = oSupplierTerms.ParentTerms;

                        SetCtrlEditable();
                        SetToolBar();
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Delete())
                {
                    BindSupplierTermsList();
                    Clear();
                    SetCtrlEditable();
                }
                else
                {
                    MessageBox.Show("The item is being used! Cannot be deleted!", "Delete Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}