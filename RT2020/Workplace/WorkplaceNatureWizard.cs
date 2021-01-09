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

namespace RT2020.Workplace
{
    public partial class WorkplaceNatureWizard : Form
    {
        #region Properties
        private Guid _NatureId = System.Guid.Empty;
        public Guid WorkplaceNatureId
        {
            get { return _NatureId; }
            set { _NatureId = value; }
        }
        #endregion

        public WorkplaceNatureWizard()
        {
            InitializeComponent();
        }

        private void WorkplaceNatureWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetToolBar();

            FillParentNatureList();
            BindWorkplaceNatureList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("workplaceNature.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colNatureCode.Text = WestwindHelper.GetWord("workplaceNature.code", "Model");
            colParent.Text = WestwindHelper.GetWord("workplaceNature.parent", "Model");
            colNatureName.Text = WestwindHelper.GetWord("workplaceNature.name", "Model");
            colNatureNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colNatureNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblNatureCode.Text = WestwindHelper.GetWordWithColon("workplaceNature.code", "Model");
            lblNatureName.Text = WestwindHelper.GetWordWithColon("workplaceNature.name", "Model");
            lblNatureNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNatureNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentNature.Text = WestwindHelper.GetWordWithColon("workplaceNature.parent", "Model");
        }

        private void SetAttributes()
        {
            lvNatureList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colNatureCode.TextAlign = HorizontalAlignment.Left;
            colNatureCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colParent.TextAlign = HorizontalAlignment.Center;
            colParent.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNatureName.TextAlign = HorizontalAlignment.Left;
            colNatureName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNatureNameAlt1.TextAlign = HorizontalAlignment.Left;
            colNatureNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNatureNameAlt2.TextAlign = HorizontalAlignment.Left;
            colNatureNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblNatureNameAlt2.Visible = txtNatureNameAlt2.Visible = false;
                    colNatureNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentNature.Location = new Point(lblParentNature.Location.X, lblNatureNameAlt2.Location.Y);
                    cboParentNature.Location = new Point(cboParentNature.Location.X, txtNatureNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblNatureNameAlt1.Visible = lblNatureNameAlt2.Visible = txtNatureNameAlt2.Visible = false;
                    colNatureNameAlt1.Visible = colNatureNameAlt2.Visible = false;
                    // push parent dept up
                    lblParentNature.Location = new Point(lblParentNature.Location.X, lblNatureNameAlt1.Location.Y);
                    cboParentNature.Location = new Point(cboParentNature.Location.X, txtNatureNameAlt1.Location.Y);
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

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.save", "General"));
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (_NatureId == Guid.Empty)
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
                            BindWorkplaceNatureList();
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

        #region WorkplaceNature Code
        private void SetCtrlEditable()
        {
            txtNatureCode.BackColor = (_NatureId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtNatureCode.ReadOnly = (_NatureId != Guid.Empty);

            ClearError();
        }
    
        private void ClearError()
        {
            errorProvider.SetError(txtNatureCode, string.Empty);
        }

        private void Clear()
        {
            txtNatureCode.Text = txtNatureName.Text = txtNatureNameAlt1.Text = txtNatureNameAlt2.Text = string.Empty;

            _NatureId = Guid.Empty;
            FillParentNatureList();
            SetCtrlEditable();
        }
        #endregion

        #region Fill Combo List
        private void FillParentNatureList()
        {
            string sql = "NatureId NOT IN ('" + _NatureId.ToString() + "')";
            string[] orderBy = new string[] { "NatureCode" };
            ModelEx.WorkplaceNatureEx.LoadCombo(ref cboParentNature, "NatureCode", true, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindWorkplaceNatureList()
        {
            this.lvNatureList.ListViewItemSorter = new ListViewItemSorter(lvNatureList);
            this.lvNatureList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.WorkplaceNature.OrderBy(x => x.NatureCode).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    var parent = item.ParentNature.HasValue ? ctx.WorkplaceNature.Find(item.ParentNature.Value) : null;
                    var parentName = parent == null ?
                        "" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                        parent.NatureName_Cht : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                        parent.NatureName_Chs :
                        parent.NatureName;
                    ListViewItem objItem = this.lvNatureList.Items.Add(item.NatureId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.NatureCode);
                    objItem.SubItems.Add(parentName);
                    objItem.SubItems.Add(item.NatureName);
                    objItem.SubItems.Add(item.NatureName_Chs);
                    objItem.SubItems.Add(item.NatureName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;
            errorProvider.SetError(txtNatureCode, string.Empty);

            #region CountryCode 唔可以吉
            if (txtNatureCode.Text.Length == 0)
            {
                errorProvider.SetError(txtNatureCode, "Cannot be blank!");
                result = false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            if (_NatureId == Guid.Empty)
            {
                if (ModelEx.WorkplaceNatureEx.IsNatureCodeInUse(txtNatureCode.Text.Trim()))
                {
                    errorProvider.SetError(txtNatureCode, "Nature Code in use");
                    errorProvider.SetIconAlignment(txtNatureCode, ErrorIconAlignment.TopLeft);
                    result = false;
                }
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var wn = ctx.WorkplaceNature.Find(_NatureId);

                if (wn == null)
                {
                    wn = new EF6.WorkplaceNature();
                    wn.NatureId = Guid.NewGuid();
                    wn.NatureCode = txtNatureCode.Text.Trim();

                    ctx.WorkplaceNature.Add(wn);
                }
                wn.NatureName = txtNatureName.Text.Trim();
                wn.NatureName_Chs = txtNatureNameAlt1.Text.Trim();
                wn.NatureName_Cht = txtNatureNameAlt2.Text.Trim();
                if ((Guid)cboParentNature.SelectedValue != Guid.Empty) wn.ParentNature = (Guid)cboParentNature.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var m = ctx.WorkplaceNature.Find(_NatureId);
                    if (m != null)
                    {
                        ctx.WorkplaceNature.Remove(m);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvWorkplaceNatureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNatureList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvNatureList.SelectedItem.Text, out id))
                {
                    _NatureId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var w = ctx.WorkplaceNature.Find(_NatureId);
                        if (w != null)
                        {
                            FillParentNatureList();

                            txtNatureCode.Text = w.NatureCode;
                            txtNatureName.Text = w.NatureName;
                            txtNatureNameAlt1.Text = w.NatureName_Chs;
                            txtNatureNameAlt2.Text = w.NatureName_Cht;
                            cboParentNature.SelectedValue = w.ParentNature.HasValue ? w.ParentNature : Guid.Empty;

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

                BindWorkplaceNatureList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}