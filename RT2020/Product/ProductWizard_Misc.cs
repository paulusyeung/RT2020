#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Data.SqlClient;
using System.IO;
using RT2020.Controls;
using System.Threading;
using System.Linq;
using RT2020.Common.Helper;
using System.Data.Entity;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Misc : UserControl
    {
        #region Public Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _ProductId = Guid.Empty;
        public Guid ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        #endregion

        string mstrDirectory = string.Empty;
        public RT2020.Controls.RTImage imgProductPic;

        public ProductWizard_Misc()
        {
            InitializeComponent();

            LoadRTImage();
        }

        private void ProductWizard_Misc_Load(object sender, EventArgs e)
        {
            SetCaptions();

            mstrDirectory = Path.Combine(Context.Config.GetDirectory("RTImages"), "Product");

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadData();
                    break;
            }
        }

        #region SetCaptions
        private void SetCaptions()
        {
            lblPicFileName.Text = WestwindHelper.GetWordWithColon("misc.pictureFile", "Product");
            lblPicSize.Text = WestwindHelper.GetWordWithColon("misc.pictureSize", "Product");

            toolTip1.SetToolTip(btnRefresh, WestwindHelper.GetWord("edit.refresh", "General"));
            toolTip1.SetToolTip(btnFind, WestwindHelper.GetWord("edit.new", "General"));
            toolTip1.SetToolTip(btnDelete, WestwindHelper.GetWord("edit.delete", "General"));
        }
        #endregion

        #region Load Data
        public void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + _ProductId.ToString() + "'";
                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == _ProductId).AsNoTracking().FirstOrDefault();
                if (oRemarks != null)
                {
                    txtMemo.Text = oRemarks.Notes;

                    // 2009.12.29 david: 如果为网络路径，则直接显示。
                    string photoPath = Path.Combine(Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), oRemarks.Photo);
                    try
                    {
                        Uri uri = new Uri(oRemarks.Photo);
                        if (uri.IsUnc)
                        {
                            imgProductPic.ImageName = uri.LocalPath;
                        }
                        else
                        {
                            imgProductPic.ImageName = photoPath;
                        }
                    }
                    catch { }
                    finally
                    {
                        imgProductPic.ImageName = photoPath;
                    }

                    txtPicFileName.Text = oRemarks.Photo;
                }
            }
        }
        #endregion

        #region Save Data
        public bool SaveData()
        {
            var result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + _ProductId.ToString() + "'";
                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == _ProductId).FirstOrDefault();
                if (oRemarks == null)
                {
                    oRemarks = new EF6.ProductRemarks();
                    oRemarks.ProductRemarksId = Guid.NewGuid();
                    oRemarks.ProductId = _ProductId;

                    ctx.ProductRemarks.Add(oRemarks);
                }
                oRemarks.Notes = txtMemo.Text;

                // 將新圖片置頂
                if (string.IsNullOrEmpty(oRemarks.Photo))
                {
                    oRemarks.Photo = txtPicFileName.Text;
                }
                else if (oRemarks.Photo != txtPicFileName.Text)
                {
                    oRemarks.Photo5 = oRemarks.Photo4;
                    oRemarks.Photo4 = oRemarks.Photo3;
                    oRemarks.Photo3 = oRemarks.Photo2;
                    oRemarks.Photo2 = oRemarks.Photo;
                    oRemarks.Photo = txtPicFileName.Text;
                }

                ctx.SaveChanges();
            }

            return result;
        }
        #endregion

        private void LoadRTImage()
        {
            imgProductPic = new RT2020.Controls.RTImage()
            {
                Image = null,
                ImageName = string.Empty,
                Location = new Point(20, 19),
                Size = new Size(356, 236),
                SizeMode = PictureBoxSizeMode.Normal,
            };
            this.Controls.Add(imgProductPic);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Product Picture Upload Wizard";
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtPicFileName.Text = Utility.UploadFile(openFileDialog, mstrDirectory);
            imgProductPic.ImageName = Path.Combine(mstrDirectory, txtPicFileName.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            imgProductPic.ImageName = Path.Combine(mstrDirectory, txtPicFileName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                string picPath = Path.Combine(mstrDirectory, txtPicFileName.Text);
                imgProductPic.ImageName = Path.Combine(VWGContext.Current.Config.GetDirectory("Images"), "no_photo.jpg");

                if (File.Exists(picPath))
                {
                    try
                    {
                        File.Delete(picPath);

                        using (var ctx = new EF6.RT2020Entities())
                        {
                            //string sql = "ProductId = '" + productId.ToString() + "' AND Photo = '" + txtPicFileName.Text + "'";
                            var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == _ProductId && x.Photo == txtPicFileName.Text).FirstOrDefault();
                            if (oRemarks != null)
                            {
                                oRemarks.Photo = oRemarks.Photo2;
                                oRemarks.Photo2 = oRemarks.Photo3;
                                oRemarks.Photo3 = oRemarks.Photo4;
                                oRemarks.Photo4 = oRemarks.Photo5;
                                oRemarks.Photo5 = string.Empty;

                                ctx.SaveChanges();

                                imgProductPic.ImageName = Path.Combine("Product", oRemarks.Photo);

                                MessageBox.Show("The picture '" + txtPicFileName.Text + "' is deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("The picture does not exist in database.", "Delete Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Delete Failed!");
                    }
                }
            }
        }
    }
}