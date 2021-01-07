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
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Member
{
    public partial class MemberAddressTypeWizard : Form
    {
        #region Properties
        private Guid _AddressTypeId = System.Guid.Empty;
        public Guid AddressTypeId
        {
            get
            {
                return _AddressTypeId;
            }
            set
            {
                _AddressTypeId = value;
            }
        }
        #endregion

        public MemberAddressTypeWizard()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            SetToolBar();
            BindAddressTypeList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("memberAddressType.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colAddressTypeCode.Text = WestwindHelper.GetWord("memberAddressType.code", "Model");
            colPriority.Text = WestwindHelper.GetWord("memberAddressType.priority", "Model");
            colAddressTypeName.Text = WestwindHelper.GetWord("memberAddressType.name", "Model");
            colAddressTypeNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colAddressTypeNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblAddressTypeCode.Text = WestwindHelper.GetWordWithColon("memberAddressType.code", "Model");
            lblAddressTypeName.Text = WestwindHelper.GetWordWithColon("memberAddressType.name", "Model");
            lblAddressTypeNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblAddressTypeNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblPriority.Text = WestwindHelper.GetWordWithColon("memberAddressType.priority", "Model");
        }

        private void SetAttributes()
        {
            lvAddressTypeList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colAddressTypeCode.TextAlign = HorizontalAlignment.Left;
            colAddressTypeCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPriority.TextAlign = HorizontalAlignment.Center;
            colPriority.ContentAlign = ExtendedHorizontalAlignment.Center;
            colAddressTypeName.TextAlign = HorizontalAlignment.Left;
            colAddressTypeName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colAddressTypeNameAlt1.TextAlign = HorizontalAlignment.Left;
            colAddressTypeNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colAddressTypeNameAlt2.TextAlign = HorizontalAlignment.Left;
            colAddressTypeNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblAddressTypeNameAlt2.Visible = txtAddressTypeNameAlt2.Visible = false;
                    colAddressTypeNameAlt2.Visible = false;
                    // push parent dept. up
                    lblPriority.Location = new Point(lblPriority.Location.X, lblAddressTypeNameAlt1.Location.Y);
                    txtPriority.Location = new Point(txtPriority.Location.X, txtAddressTypeNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblAddressTypeNameAlt1.Visible = lblAddressTypeNameAlt2.Visible = txtAddressTypeNameAlt2.Visible = false;
                    colAddressTypeNameAlt1.Visible = colAddressTypeNameAlt2.Visible = false;
                    // push parent dept up
                    lblPriority.Location = new Point(lblPriority.Location.X, lblAddressTypeNameAlt1.Location.Y);
                    txtPriority.Location = new Point(txtPriority.Location.X, txtAddressTypeNameAlt1.Location.Y);
                    break;
            }
        }

        #endregion

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
            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.refresh", "General"));
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (_AddressTypeId == System.Guid.Empty)
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
                        break;
                    case "save":
                        if (Verify())
                        {
                            Save();
                            Clear();
                            BindAddressTypeList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        Clear();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region MemberAddressType Code
        private void SetCtrlEditable()
        {
            txtAddressTypeCode.BackColor = (_AddressTypeId == System.Guid.Empty) ? SystemInfo.ControlBackColor.RequiredBox : SystemInfo.ControlBackColor.DisabledBox;
            txtAddressTypeCode.ReadOnly = (_AddressTypeId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtAddressTypeCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }

        private void Clear()
        {
            txtAddressTypeCode.Text = txtAddressTypeName.Text = txtAddressTypeNameAlt1.Text = txtAddressTypeNameAlt2.Text = txtPriority.Text = string.Empty;

            _AddressTypeId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Binding
        private void BindAddressTypeList()
        {
            //this.lvAddressTypeList.ListViewItemSorter = new ListViewItemSorter(lvAddressTypeList);
            this.lvAddressTypeList.ListViewItemSorter = new Sorter();   // 參考：https://stackoverflow.com/a/1214333
            this.lvAddressTypeList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.MemberAddressType.OrderBy(x => x.Priority).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvAddressTypeList.Items.Add(item.AddressTypeId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.AddressTypeCode);
                    objItem.SubItems.Add(item.Priority.ToString());
                    objItem.SubItems.Add(item.AddressTypeName);
                    objItem.SubItems.Add(item.AddressTypeName_Chs);
                    objItem.SubItems.Add(item.AddressTypeName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool Verify()
        {
            bool result = true;
            errorProvider.SetError(txtAddressTypeCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);

            if (txtAddressTypeCode.Text.Length == 0)
            {
                errorProvider.SetError(txtAddressTypeCode, "Cannot be blank!");
                result = false;
            }
            if (txtPriority.Text.Length == 0)
            {
                errorProvider.SetError(txtPriority, "Cannot be blank!");
                result = false;
            }
            if (!(txtPriority.Text.All(char.IsNumber)))
            {
                errorProvider.SetError(txtPriority, Resources.Common.DigitalNeeded);
                result = false;
            }
            if (ModelEx.MemberAddressTypeEx.IsTypeCodeInUse(txtAddressTypeCode.Text))
            {
                errorProvider.SetError(txtAddressTypeCode, "Type Code in use");
                result = false;
            }

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oAddressType = ctx.MemberAddressType.Find(_AddressTypeId);
                if (oAddressType == null)
                {
                    oAddressType = new EF6.MemberAddressType();
                    oAddressType.AddressTypeId = Guid.NewGuid();
                    oAddressType.AddressTypeCode = txtAddressTypeCode.Text;

                    ctx.MemberAddressType.Add(oAddressType);
                }
                oAddressType.AddressTypeName = txtAddressTypeName.Text;
                oAddressType.AddressTypeName_Chs = txtAddressTypeNameAlt1.Text;
                oAddressType.AddressTypeName_Cht = txtAddressTypeNameAlt2.Text;
                oAddressType.Priority = Convert.ToInt32(txtPriority.Text);

                ctx.SaveChanges();

                result = true;
            }

            return result;
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oAddressType = ctx.MemberAddressType.Find(_AddressTypeId);
                if (oAddressType != null)
                {
                    try
                    {
                        ctx.MemberAddressType.Remove(oAddressType);
                    }
                    catch
                    {
                        MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                    }
                }
            }
        }
        #endregion

        private void lvAddressTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAddressTypeList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvAddressTypeList.SelectedItem.Text, out id))
                {
                    _AddressTypeId = id;

                    var oAddressType = ModelEx.MemberAddressTypeEx.Get(id);
                    if (oAddressType != null)
                    {
                        txtAddressTypeCode.Text = oAddressType.AddressTypeCode;
                        txtAddressTypeName.Text = oAddressType.AddressTypeName;
                        txtAddressTypeNameAlt1.Text = oAddressType.AddressTypeName_Chs;
                        txtAddressTypeNameAlt2.Text = oAddressType.AddressTypeName_Cht;
                        txtPriority.Text = oAddressType.Priority.ToString();

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
                Delete();

                BindAddressTypeList();
                Clear();
                SetCtrlEditable();
            }
        }

        private void lvAddressTypeList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 參考：https://stackoverflow.com/a/1214333
            Sorter s = (Sorter)lvAddressTypeList.ListViewItemSorter;
            s.Column = e.Column;

            if (s.Order == Gizmox.WebGUI.Forms.SortOrder.Ascending)
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Descending;
            }
            else
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Ascending;
            }
            lvAddressTypeList.Sort();
        }
    }
}