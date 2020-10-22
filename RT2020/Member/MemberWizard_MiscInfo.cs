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

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_MiscInfo : UserControl
    {
        string mstrDirectory = string.Empty;

        public MemberWizard_MiscInfo()
        {
            InitializeComponent();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("RTImages"), "Member");
        }

        #region Properties
        private Guid memberId = System.Guid.Empty;
        public Guid MemberId
        {
            get
            {
                return memberId;
            }
            set
            {
                memberId = value;
            }
        }
        #endregion

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