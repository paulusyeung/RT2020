#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using RT2020.Controls;
using Gizmox.WebGUI.Common.Resources;
using System.Security.AccessControl;
using RT2020.Helper;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_Misc : UserControl
    {
        string mstrDirectory = string.Empty;
        public RT2020.Controls.RTImage imgMemberPicture;

        #region Properties
        private Guid _MemberId = System.Guid.Empty;
        public Guid MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        #endregion

        public MemberWizard_Misc()
        {
            InitializeComponent();

            SetCaptions();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("RTImages"), "Member");

            LoadRTImage();
        }

        #region SetCaptions & SetAttributes
        private void SetCaptions()
        {
            lblMemo.Text = WestwindHelper.GetWordWithColon("member.misc.memo", "Model");
            lblPicFileName.Text = WestwindHelper.GetWordWithColon("member.misc.pictureFileName", "Model");
            gbPicture.Text = WestwindHelper.GetWord("member.misc.picture", "Model");
        }

        private void SetAttributes()
        {

        }
        #endregion

        private void LoadRTImage()
        {
            imgMemberPicture = new RT2020.Controls.RTImage()
            {
                Image = null,
                ImageName = string.Empty,
                Location = new Point(6, 19),
                Size = new Size(388, 227),
                SizeMode = PictureBoxSizeMode.Normal,
            };
            gbPicture.Controls.Add(imgMemberPicture);
        }

        private void btnFindPic_Click(object sender, EventArgs e)
        {
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.Title = "Upload Member Picture";
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtPicFileName.Text = Utility.UploadFile(openFileDialog, mstrDirectory);
            imgMemberPicture.ImageName = Path.Combine(mstrDirectory, txtPicFileName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            imgMemberPicture.ImageName = string.Empty;
            imgMemberPicture.Image = null;

            if (imgMemberPicture.Image == null)
            {
                try
                {
                    string imgPath = Path.Combine(mstrDirectory, txtPicFileName.Text);
                    File.Delete(imgPath);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            imgMemberPicture.ImageName = Path.Combine(mstrDirectory, txtPicFileName.Text);
        }
    }
}