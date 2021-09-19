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
using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Settings
{
    public partial class SalutationWizard : Form
    {
        #region Properties
        private Guid _SalutationId = System.Guid.Empty;
        public Guid SalutationId
        {
            get { return _SalutationId; }
            set { _SalutationId = value; }
        }
        #endregion

        public SalutationWizard()
        {
            InitializeComponent();
        }

        private void SalutationWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillParentSalutationList();
            BindSalutationList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("salutation.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colParent.Text = WestwindHelper.GetWord("salutation.parent", "Model");
            colSalutationCode.Text = WestwindHelper.GetWord("salutation.code", "Model");
            colSalutationName.Text = WestwindHelper.GetWord("salutation.name", "Model");
            colSalutationNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colSalutationNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblSalutationCode.Text = WestwindHelper.GetWordWithColon("salutation.code", "Model");
            lblSalutationName.Text = WestwindHelper.GetWordWithColon("salutation.name", "Model");
            lblSalutationNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblSalutationNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentSalutation.Text = WestwindHelper.GetWordWithColon("salutation.parent", "Model");
        }

        private void SetAttributes()
        {
            lvSalutationList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colParent.TextAlign = HorizontalAlignment.Left;
            colParent.ContentAlign = ExtendedHorizontalAlignment.Center;
            colSalutationCode.TextAlign = HorizontalAlignment.Left;
            colSalutationCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colSalutationName.TextAlign = HorizontalAlignment.Left;
            colSalutationName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colSalutationNameAlt1.TextAlign = HorizontalAlignment.Left;
            colSalutationNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colSalutationNameAlt2.TextAlign = HorizontalAlignment.Left;
            colSalutationNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblSalutationNameAlt2.Visible = txtSalutationNameAlt2.Visible = false;
                    colSalutationNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentSalutation.Location = new Point(lblParentSalutation.Location.X, lblSalutationNameAlt1.Location.Y);
                    cboParentSalutation.Location = new Point(cboParentSalutation.Location.X, txtSalutationNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblSalutationNameAlt1.Visible = lblSalutationNameAlt2.Visible = txtSalutationNameAlt2.Visible = false;
                    colSalutationNameAlt1.Visible = colSalutationNameAlt2.Visible = false;
                    // push parent dept up
                    cboParentSalutation.Location = new Point(lblParentSalutation.Location.X, lblSalutationNameAlt1.Location.Y);
                    cboParentSalutation.Location = new Point(cboParentSalutation.Location.X, txtSalutationNameAlt1.Location.Y);
                    break;
            }

            // 2020.12.29 paulus: 唔使咁複雜
            lblParentSalutation.Visible = cboParentSalutation.Visible = colParent.Visible = false;
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

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

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

            if (_SalutationId == Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
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
                        if (IsValid())
                        {
                            Save();
                            Clear();
                            BindSalutationList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        Clear();
                        BindSalutationList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Clear/ Set
        private void SetCtrlEditable()
        {
            txtSalutationCode.BackColor = (_SalutationId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtSalutationCode.ReadOnly = (_SalutationId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtSalutationCode, string.Empty);
        }

        private void Clear()
        {
            txtSalutationCode.Text = txtSalutationName.Text = txtSalutationNameAlt1.Text = txtSalutationNameAlt2.Text = string.Empty;
            _SalutationId = Guid.Empty;

            FillParentSalutationList();
            SetCtrlEditable();
        }
        #endregion

        #region Fill Combo List
        private void FillParentSalutationList()
        {
            string sql = "SalutationId NOT IN ('" + _SalutationId.ToString() + "')";
            string[] orderBy = new string[] { "SalutationCode" };
            SalutationEx.LoadCombo(ref cboParentSalutation, "SalutationCode", false, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindSalutationList()
        {
            this.lvSalutationList.ListViewItemSorter = new ListViewItemSorter(lvSalutationList);
            this.lvSalutationList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Salutation.OrderBy(x => x.SalutationCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var parent = SalutationEx.GetParentName(item);

                    ListViewItem objItem = this.lvSalutationList.Items.Add(item.SalutationId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.SalutationCode);
                    objItem.SubItems.Add(item.SalutationName);
                    objItem.SubItems.Add(item.SalutationName_Chs);
                    objItem.SubItems.Add(item.SalutationName_Cht);
                    objItem.SubItems.Add(parent);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Salutation Code 唔可以吉
            errorProvider.SetError(txtSalutationCode, string.Empty);
            if (txtSalutationCode.Text.Length == 0)
            {
                errorProvider.SetError(txtSalutationCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Salutation Code 係咪 in use
            errorProvider.SetError(txtSalutationCode, string.Empty);
            if (_SalutationId == Guid.Empty && SalutationEx.IsSalutationCodeInUse(txtSalutationCode.Text.Trim()))
            {
                errorProvider.SetError(txtSalutationCode, "Salutation Code in use");
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
                var item = ctx.Salutation.Find(_SalutationId);

                if (item == null)
                {
                    item = new EF6.Salutation();
                    item.SalutationId = new Guid();
                    item.SalutationCode = txtSalutationCode.Text;

                    ctx.Salutation.Add(item);
                }
                item.SalutationName = txtSalutationName.Text;
                item.SalutationName_Chs = txtSalutationNameAlt1.Text;
                item.SalutationName_Cht = txtSalutationNameAlt2.Text;
                if ((Guid)cboParentSalutation.SelectedValue == Guid.Empty) item.ParentSalutation = (Guid)cboParentSalutation.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result; ;
        }
        #endregion

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.Salutation.Find(_SalutationId);
                    if (item != null)
                    {
                        ctx.Salutation.Remove(item);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvSalutationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSalutationList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvSalutationList.SelectedItem.Text, out id))
                {
                    _SalutationId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var item = ctx.Salutation.Find(_SalutationId);
                        if (item != null)
                        {
                            FillParentSalutationList();

                            txtSalutationCode.Text = item.SalutationCode;
                            txtSalutationName.Text = item.SalutationName;
                            txtSalutationNameAlt1.Text = item.SalutationName_Chs;
                            txtSalutationNameAlt2.Text = item.SalutationName_Cht;
                            cboParentSalutation.SelectedValue = item.ParentSalutation.HasValue ? item.ParentSalutation.Value : Guid.Empty;

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

                BindSalutationList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}