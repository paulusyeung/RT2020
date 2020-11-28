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
    public partial class ZoneWizard : Form
    {
        public ZoneWizard()
        {
            InitializeComponent();
        }

        private void ZoneWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillComboList();
            BindZoneList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("workplaceZone.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colParent.Text = WestwindHelper.GetWord("workplaceZone.parent", "Model");
            colZoneCode.Text = WestwindHelper.GetWord("workplaceZone.code", "Model");
            colZoneName.Text = WestwindHelper.GetWord("workplaceZone.name", "Model");
            colZoneNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colZoneNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblZoneCode.Text = WestwindHelper.GetWordWithColon("workplaceZone.code", "Model");
            lblZoneInitial.Text = WestwindHelper.GetWordWithColon("workplaceZone.alias", "Model");
            lblZoneName.Text = WestwindHelper.GetWordWithColon("workplaceZone.name", "Model");
            lblZoneNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblZoneNameAtl2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblCurrency.Text = WestwindHelper.GetWordWithColon("currency.code", "Model");
            lblPrimaryZone.Text = WestwindHelper.GetWordWithColon("workplaceZone.primary", "Model");
            lblParentZone.Text = WestwindHelper.GetWordWithColon("workplaceZone.parent", "Model");
            lblRemarks.Text = WestwindHelper.GetWordWithColon("workplaceZone.remarks", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colParent.TextAlign = HorizontalAlignment.Left;
            colParent.ContentAlign = ExtendedHorizontalAlignment.Center;
            colZoneCode.TextAlign = HorizontalAlignment.Left;
            colZoneCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colZoneName.TextAlign = HorizontalAlignment.Left;
            colZoneName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colZoneNameAlt1.TextAlign = HorizontalAlignment.Left;
            colZoneNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colZoneNameAlt2.TextAlign = HorizontalAlignment.Left;
            colZoneNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblZoneNameAtl2.Visible = txtZoneNameAlt2.Visible = false;
                    colZoneNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentZone.Location = new Point(lblParentZone.Location.X, lblZoneNameAtl2.Location.Y);
                    cboParent.Location = new Point(cboParent.Location.X, txtZoneNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblZoneNameAlt1.Visible = lblZoneNameAtl2.Visible = txtZoneNameAlt1.Visible = txtZoneNameAlt2.Visible = false;
                    colZoneNameAlt1.Visible = colZoneNameAlt2.Visible = false;
                    // push parent dept up
                    lblParentZone.Location = new Point(lblParentZone.Location.X, lblZoneNameAlt1.Location.Y);
                    cboParent.Location = new Point(cboParent.Location.X, txtZoneNameAlt1.Location.Y);
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

            if (ZoneId == System.Guid.Empty)
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
                        if (Save())
                        {
                            Clear();
                            BindZoneList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindZoneList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region WorkplaceZone Code
        private void SetCtrlEditable()
        {
            txtZoneCode.BackColor = (this.ZoneId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtZoneCode.ReadOnly = (this.ZoneId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtZoneCode, string.Empty);
        }
        #endregion

        #region Binding
        private void BindZoneList()
        {
            this.lvZoneList.ListViewItemSorter = new ListViewItemSorter(lvZoneList);
            this.lvZoneList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.WorkplaceZone.OrderBy(x => x.ZoneCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var objItem = this.lvZoneList.Items.Add(item.ZoneId.ToString());
                    objItem.SubItems.Add(iCount.ToString());
                    objItem.SubItems.Add(item.ParentZone.HasValue ?
                        ModelEx.WorkplaceZoneEx.GetZoneNameById(item.ParentZone.Value) : "");
                    objItem.SubItems.Add(item.ZoneCode);
                    objItem.SubItems.Add(item.ZoneName);
                    objItem.SubItems.Add(item.ZoneName_Chs);
                    objItem.SubItems.Add(item.ZoneName_Cht);

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
            ModelEx.CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false);
        }

        private void FillParentLineList()
        {
            string sql = "ZoneId NOT IN ('" + this.ZoneId.ToString() + "')";
            string[] orderBy = new string[] { "ZoneCode" };
            ModelEx.WorkplaceZoneEx.LoadCombo(ref cboParent, "ZoneCode", true, false, "", sql, orderBy);
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region ZoneCode 唔可以吉
            errorProvider.SetError(txtZoneCode, string.Empty);
            if (txtZoneCode.Text.Length == 0)
            {
                errorProvider.SetError(txtZoneCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check ZoneCode 係咪 in use
            errorProvider.SetError(txtZoneCode, string.Empty);
            if (ModelEx.WorkplaceZoneEx.IsZoneCodeInUse(txtZoneCode.Text.Trim()))
            {
                errorProvider.SetError(txtZoneCode, "Zone Code in use");
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
                var zone = ctx.WorkplaceZone.Find(this.ZoneId);

                if (zone == null)
                {
                    zone = new EF6.WorkplaceZone();
                    zone.ZoneId = new Guid();

                    ctx.WorkplaceZone.Add(zone);
                    zone.ZoneCode = txtZoneCode.Text;
                }
                zone.ZoneInitial = txtZoneInitial.Text;
                zone.ZoneName = txtZoneName.Text;
                zone.ZoneName_Chs = txtZoneNameAlt1.Text;
                zone.ZoneName_Cht = txtZoneNameAlt2.Text;
                zone.CurrencyCode = cboCurrency.Text;
                zone.PromaryZone = chkPrimaryZone.Checked;
                zone.ParentZone = (cboParent.SelectedValue == null) ? Guid.Empty : new Guid(cboParent.SelectedValue.ToString());
                zone.Notes = txtRemarks.Text;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            ZoneWizard wizZone = new ZoneWizard();
            wizZone.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid ZoneId
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
                    var zone = ctx.WorkplaceZone.Find(this.ZoneId);
                    if (zone != null)
                    {
                        ctx.WorkplaceZone.Remove(zone);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvZoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvZoneList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvZoneList.SelectedItem.Text, out id))
                {
                    this.ZoneId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var zone = ctx.WorkplaceZone.Find(this.ZoneId);
                        if (zone != null)
                        {
                            FillComboList();

                            txtZoneCode.Text = zone.ZoneCode;
                            txtZoneInitial.Text = zone.ZoneInitial;
                            txtZoneName.Text = zone.ZoneName;
                            txtZoneNameAlt1.Text = zone.ZoneName_Chs;
                            txtZoneNameAlt2.Text = zone.ZoneName_Cht;
                            cboCurrency.Text = zone.CurrencyCode;
                            chkPrimaryZone.Checked = zone.PromaryZone;
                            cboParent.SelectedValue = zone.ParentZone.HasValue ? zone.ParentZone : Guid.Empty;
                            txtRemarks.Text = zone.Notes;

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

                BindZoneList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}