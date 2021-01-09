#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Helper;

#endregion

namespace RT2020.Workplace
{
    public partial class ChangePassword : Form
    {
        #region public properties
        private Guid _WorkplaceId = Guid.Empty; 
        public Guid WorkplaceId
        {
            get { return _WorkplaceId; }
            set { _WorkplaceId = value; }
        }

        private bool _IsCompleted = false;
        public bool IsCompleted
        {
            get { return _IsCompleted; }
            set { _IsCompleted = value; }
        }

        private string _Password = string.Empty;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            SetCaptions();

            if (_WorkplaceId != Guid.Empty)
            {
                var password = ModelEx.WorkplaceEx.GetWorkplacePasswordById(_WorkplaceId);
                if (password != "")
                {
                    _Password = password;
                    txtOldPwd.Focus();
                }
            }
        }

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("password.setup", "General");

            lblOldPwd.Text = WestwindHelper.GetWordWithColon("password.old", "General");
            lblNewpwd.Text = WestwindHelper.GetWordWithColon("password.new", "General");
            lblComPwd.Text = WestwindHelper.GetWordWithColon("password.confirm", "General");

            btnAccept.Text = WestwindHelper.GetWord("dialog.accept", "General");
            btnCancel.Text = WestwindHelper.GetWord("dialog.cancel", "General");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_WorkplaceId == System.Guid.Empty)
            {
                if (txtNewPwd.Text.Trim() == txtCNewPwd.Text.Trim())
                {
                    _IsCompleted = true;
                    _Password = txtNewPwd.Text.Trim();
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("New password haven't be confirmed! Please input again.", "Password not confirmed"); 
                }
            }
            else
            {
                if (txtOldPwd.Text.Trim().Equals(_Password))
                {
                    if (txtNewPwd.Text.Trim() == txtCNewPwd.Text.Trim())
                    {
                        _IsCompleted = true;
                        _Password = txtNewPwd.Text.Trim();
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("New password haven't be confirmed! Please input again.", "Try again"); 
                    }
                }
                else
                {
                    MessageBox.Show("Old Password is not true!", "Error");
                    txtOldPwd.Text = "";
                    txtNewPwd.Text = "";
                    txtCNewPwd.Text = "";
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void txtNewPwd_GotFocus(object sender, EventArgs e)
        {
            if (_Password.Length > 0)
            {
                MessageBox.Show("Please input old password before changing it!", "Warning");
                txtOldPwd.Focus();
            }
        }
    }
}