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

namespace RT2020.Settings
{
    public partial class LineOfOperationWizard : Form
    {
        public LineOfOperationWizard()
        {
            InitializeComponent();
        }

        private void LineOfOperationWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillComboList();
            BindLineOfOperationList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("lineOfOperation.setup", "Model");

            this.Text = WestwindHelper.GetWord("lineOfOperation", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colLineOfOperationCode.Text = WestwindHelper.GetWord("lineOfOperation.code", "Model");
            colLineOfOperationName.Text = WestwindHelper.GetWord("lineOfOperation.name", "Model");
            colLineOfOperationNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colLineOfOperationNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblLineOfOperationCode.Text = WestwindHelper.GetWordWithColon("lineOfOperation.code", "Model");
            lblLineOfOperationName.Text = WestwindHelper.GetWordWithColon("lineOfOperation.name", "Model");
            lblLineOfOperationNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblLineOfOperationNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblCurrency.Text = WestwindHelper.GetWord("currency", "Model");
            lblPrimaryLine.Text = WestwindHelper.GetWord("lineOfOperation.primary", "Model");
            lblParentLine.Text = WestwindHelper.GetWord("lineOfOperation.parent", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colLineOfOperationCode.TextAlign = HorizontalAlignment.Left;
            colLineOfOperationCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLineOfOperationName.TextAlign = HorizontalAlignment.Left;
            colLineOfOperationName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLineOfOperationNameAlt1.TextAlign = HorizontalAlignment.Left;
            colLineOfOperationNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLineOfOperationNameAlt2.TextAlign = HorizontalAlignment.Left;
            colLineOfOperationNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblLineOfOperationNameAlt2.Visible = txtLineOfOperationNameAlt2.Visible = false;
                    colLineOfOperationNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblLineOfOperationNameAlt1.Visible = lblLineOfOperationNameAlt2.Visible = txtLineOfOperationNameAlt1.Visible = txtLineOfOperationNameAlt2.Visible = false;
                    colLineOfOperationNameAlt1.Visible = colLineOfOperationNameAlt2.Visible = false;
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
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.refresh", "General"));
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (LineOfOperationId == System.Guid.Empty)
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
                        SetCtrlEditable();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            Clear();
                            BindLineOfOperationList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindLineOfOperationList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region LineOfOperation Code
        private void SetCtrlEditable()
        {
            txtLineOfOperationCode.BackColor = (this.LineOfOperationId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtLineOfOperationCode.ReadOnly = (this.LineOfOperationId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtLineOfOperationCode, string.Empty);
        }
        #endregion

        #region Binding
        private void BindLineOfOperationList()
        {
            this.lvLineOfOperationList.ListViewItemSorter = new ListViewItemSorter(lvLineOfOperationList);
            this.lvLineOfOperationList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.LineOfOperation.OrderBy(x => x.LineOfOperationCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var objItem = this.lvLineOfOperationList.Items.Add(item.LineOfOperationId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.LineOfOperationCode);
                    objItem.SubItems.Add(item.LineOfOperationName);
                    objItem.SubItems.Add(item.LineOfOperationName_Chs);
                    objItem.SubItems.Add(item.LineOfOperationName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillCurrencyList();
            FillParentLineList();
        }

        private void FillCurrencyList()
        {
            ModelEx.CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false, true, "", "");
        }

        private void FillParentLineList()
        {
            string sql = "LineOfOperationId NOT IN ('" + this.LineOfOperationId.ToString() + "')";
            string[] orderBy = new string[] { "LineOfOperationCode" };
            ModelEx.LineOfOperationEx.LoadCombo(ref cboParentLine, "LineOfOperationCode", true, true, "", sql, orderBy);
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Group Code 唔可以吉
            errorProvider.SetError(txtLineOfOperationCode, string.Empty);
            if (txtLineOfOperationCode.Text.Length == 0)
            { 
                errorProvider.SetError(txtLineOfOperationCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Group Code 係咪 in use
            errorProvider.SetError(txtLineOfOperationCode, string.Empty);
            if (this.LineOfOperationId == Guid.Empty && ModelEx.LineOfOperationEx.IsLineOfOperationCodeInUse(txtLineOfOperationCode.Text.Trim()))
            {
                errorProvider.SetError(txtLineOfOperationCode, "Group Code in use");
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
                var m = ctx.LineOfOperation.Find(this.LineOfOperationId);

                if (m == null)
                {
                    m = new EF6.LineOfOperation();
                    m.LineOfOperationId = new Guid();

                    ctx.LineOfOperation.Add(m);
                    m.LineOfOperationCode = txtLineOfOperationCode.Text;
                }
                m.LineOfOperationName = txtLineOfOperationName.Text;
                m.LineOfOperationName_Chs = txtLineOfOperationNameAlt1.Text;
                m.LineOfOperationName_Cht = txtLineOfOperationNameAlt2.Text;
                m.CurrencyCode = cboCurrency.Text;
                m.PrimaryLine = chkPrimaryLine.Checked;
                m.ParentLine = (cboParentLine.SelectedValue == null) ? Guid.Empty : new Guid(cboParentLine.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            LineOfOperationWizard wizLOC = new LineOfOperationWizard();
            wizLOC.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid LineOfOperationId
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
                    var m = ctx.LineOfOperation.Find(this.LineOfOperationId);
                    if (m != null)
                    {
                        ctx.LineOfOperation.Remove(m);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvLineOfOperationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLineOfOperationList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvLineOfOperationList.SelectedItem.Text, out id))
                {
                    this.LineOfOperationId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var m = ctx.LineOfOperation.Find(this.LineOfOperationId);
                        if (m != null)
                        {
                            FillComboList();

                            txtLineOfOperationCode.Text = m.LineOfOperationCode;
                            txtLineOfOperationName.Text = m.LineOfOperationName;
                            txtLineOfOperationNameAlt1.Text = m.LineOfOperationName_Chs;
                            txtLineOfOperationNameAlt2.Text = m.LineOfOperationName_Cht;
                            cboCurrency.Text = m.CurrencyCode;
                            chkPrimaryLine.Checked = m.PrimaryLine;
                            cboParentLine.SelectedValue = m.ParentLine;

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

                BindLineOfOperationList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}