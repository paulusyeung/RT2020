#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using System.Data.SqlClient;
using System.IO;
using RT2020.Controls;
using System.Threading;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Misc : UserControl
    {
        string mstrDirectory = string.Empty;

        public ProductWizard_Misc(Guid productId)
        {
            InitializeComponent();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("RTImages"), "Product");
            this.ProductId = productId;
        }

        #region Properties
        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
        #endregion

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

                        string sql = "ProductId = '" + productId.ToString() + "' AND Photo = '" + txtPicFileName.Text + "'";
                        ProductRemarks oRemarks = ProductRemarks.LoadWhere(sql);
                        if (oRemarks != null)
                        {
                            oRemarks.Photo = oRemarks.Photo2;
                            oRemarks.Photo2 = oRemarks.Photo3;
                            oRemarks.Photo3 = oRemarks.Photo4;
                            oRemarks.Photo4 = oRemarks.Photo5;
                            oRemarks.Photo5 = string.Empty;

                            oRemarks.Save();

                            imgProductPic.ImageName = Path.Combine("Product", oRemarks.Photo);

                            MessageBox.Show("The picture '" + txtPicFileName.Text + "' is deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("The picture does not exist in database.", "Delete Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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