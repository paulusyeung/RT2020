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
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Settings
{
    public partial class MarketSectorWizard : Form
    {
        public MarketSectorWizard()
        {
            InitializeComponent();
        }

        private void MarketSectorWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillParentSectorList();
            BindMarketSectorList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colMarketSectorCode.Text = WestwindHelper.GetWord("marketSector.code", "Model");
            colMarketSectorName.Text = WestwindHelper.GetWord("marketSector.name", "Model");
            colMarketSectorNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colMarketSectorNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblMarketSectorCode.Text = WestwindHelper.GetWordWithColon("marketSector.code", "Model");
            lblMarketSectorName.Text = WestwindHelper.GetWordWithColon("marketSector.name", "Model");
            lblMarketSectorNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblMarketSectorNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentSector.Text = WestwindHelper.GetWord("marketSector.parent", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colMarketSectorCode.TextAlign = HorizontalAlignment.Left;
            colMarketSectorCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colMarketSectorName.TextAlign = HorizontalAlignment.Left;
            colMarketSectorName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colMarketSectorNameAlt1.TextAlign = HorizontalAlignment.Left;
            colMarketSectorNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colMarketSectorNameAlt2.TextAlign = HorizontalAlignment.Left;
            colMarketSectorNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblMarketSectorNameAlt2.Visible = txtMarketSectorNameAlt2.Visible = false;
                    colMarketSectorNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblMarketSectorNameAlt1.Visible = lblMarketSectorNameAlt2.Visible = txtMarketSectorNameAlt1.Visible = txtMarketSectorNameAlt2.Visible = false;
                    colMarketSectorNameAlt1.Visible = colMarketSectorNameAlt2.Visible = false;
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

            if (MarketSectorId == System.Guid.Empty)
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
                            BindMarketSectorList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindMarketSectorList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region MarketSector Code
        private void SetCtrlEditable()
        {
            txtMarketSectorCode.BackColor = (this.MarketSectorId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtMarketSectorCode.ReadOnly = (this.MarketSectorId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtMarketSectorCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentSectorList()
        {
            string sql = "MarketSectorId NOT IN ('" + this.MarketSectorId.ToString() + "')";
            string[] orderBy = new string[] { "MarketSectorCode" };

            ModelEx.MarketSectorEx.LoadCombo(ref cboParentSector, "MarketSectorCode", false, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindMarketSectorList()
        {
            this.lvMarketSectorList.ListViewItemSorter = new ListViewItemSorter(lvMarketSectorList);
            this.lvMarketSectorList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.MarketSector.OrderBy(x => x.MarketSectorCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var objItem = this.lvMarketSectorList.Items.Add(item.MarketSectorId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.MarketSectorCode);
                    objItem.SubItems.Add(item.MarketSectorName);
                    objItem.SubItems.Add(item.MarketSectorName_Chs);
                    objItem.SubItems.Add(item.MarketSectorName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = false;

            #region CountryCode 唔可以吉
            errorProvider.SetError(txtMarketSectorCode, string.Empty);
            if (txtMarketSectorCode.Text.Length == 0)
            {
                errorProvider.SetError(txtMarketSectorCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            errorProvider.SetError(txtMarketSectorCode, string.Empty);
            if (this.MarketSectorId == System.Guid.Empty && ModelEx.MarketSectorEx.IsMarketSectorCodeInUse(txtMarketSectorCode.Text.Trim()))
            {
                errorProvider.SetError(txtMarketSectorCode, "Market Sector Code in use");
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
                var m = ctx.MarketSector.Find(this.MarketSectorId);

                if (m == null)
                {
                    m = new EF6.MarketSector();
                    m.MarketSectorId = new Guid();

                    ctx.MarketSector.Add(m);
                    m.MarketSectorCode = txtMarketSectorCode.Text;
                }
                m.MarketSectorName = txtMarketSectorName.Text;
                m.MarketSectorName_Chs = txtMarketSectorNameAlt1.Text;
                m.MarketSectorName_Cht = txtMarketSectorNameAlt2.Text;
                m.ParentSector = (cboParentSector.SelectedValue == null) ? Guid.Empty : new Guid(cboParentSector.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            MarketSectorWizard wizMarket = new MarketSectorWizard();
            wizMarket.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid MarketSectorId
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
                    var m = ctx.MarketSector.Find(this.MarketSectorId);
                    if (m != null)
                    {
                        ctx.MarketSector.Remove(m);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvMarketSectorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMarketSectorList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvMarketSectorList.SelectedItem.Text, out id))
                {
                    this.MarketSectorId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var m = ctx.MarketSector.Find(this.MarketSectorId);
                        if (m != null)
                        {
                            FillParentSectorList();

                            txtMarketSectorCode.Text = m.MarketSectorCode;
                            txtMarketSectorName.Text = m.MarketSectorName;
                            txtMarketSectorNameAlt1.Text = m.MarketSectorName_Chs;
                            txtMarketSectorNameAlt2.Text = m.MarketSectorName_Cht;
                            if (m.ParentSector != null) cboParentSector.SelectedValue = m.ParentSector;

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

                BindMarketSectorList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}