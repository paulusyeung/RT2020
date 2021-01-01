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

namespace RT2020.Staff
{
    public partial class ChangePassword : Form
    {
        #region public Properties
        private bool _IsCompleted = false;
        public bool IsCompleted
        {
            get
            {
                return _IsCompleted;
            }
            set
            {
                _IsCompleted = value;
            }
        }

        private string _Password = string.Empty;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        private Guid _StaffId = System.Guid.Empty; 
        public Guid StaffId
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }
        #endregion

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            SetCaptions();

            if (_StaffId != Guid.Empty)
            {
                var Staff = ModelEx.StaffEx.GetByStaffId(_StaffId);
                if (Staff != null)
                {
                    this.Password = Staff.Password;
                }
            }

            txtOldPwd.Focus();
        }

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("password.setup", "General");

            lblOldPwd.Text = WestwindHelper.GetWordWithColon("password.old", "General");
            lblNewpwd.Text = WestwindHelper.GetWordWithColon("password.new", "General");
            lblComPwd.Text = WestwindHelper.GetWordWithColon("password.confirm", "General");

            btnAccept.Text = WestwindHelper.GetWordWithColon("dialog.accept", "General");
            btnCancel.Text = WestwindHelper.GetWordWithColon("dialog.cancel", "General");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_StaffId == System.Guid.Empty)
            {
                if (txtNewPwd.Text.Trim() == txtCNewPwd.Text.Trim())
                {
                    this.IsCompleted = true;
                    this.Password = txtNewPwd.Text.Trim();
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("New password haven't be confirmed! Please input again.", "Password not confirm"); 
                }
            }
            else
            {
                if (txtOldPwd.Text.Trim().Equals(_Password))
                {
                    if (txtNewPwd.Text.Trim() == txtCNewPwd.Text.Trim())
                    {
                        this.IsCompleted = true;
                        this.Password = txtNewPwd.Text.Trim();
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
            if (this.Password.Length > 0)
            {
                MessageBox.Show("Please input old password before changing it!", "Warning");
                txtOldPwd.Focus();
            }
        }
    }
}