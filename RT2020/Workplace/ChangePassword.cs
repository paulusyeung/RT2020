#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Workplace
{
    public partial class ChangePassword : Form
    {
        private System.Guid workplaceID = System.Guid.Empty; 

        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(System.Guid WorkplaceID)
        {
            InitializeComponent();

            workplaceID = WorkplaceID;
            if (WorkplaceID != System.Guid.Empty)
            {
                var password = ModelEx.WorkplaceEx.GetWorkplacePasswordById(WorkplaceID);
                if (password != "")
                {
                    this.Password = password;
                    txtOldPwd.Focus();
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (workplaceID == System.Guid.Empty)
            {
                if (txtNewPwd.Text.Trim() == txtCNewPwd.Text.Trim())
                {
                    this.IsCompleted = true;
                    this.Password = txtNewPwd.Text.Trim();
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("New password haven't be confirmed! Please input again.", "Password not confirmed"); 
                }
            }
            else
            {
                if (txtOldPwd.Text.Trim().Equals(password))
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

        #region Properties

        private bool isCompleted = false;
        public bool IsCompleted
        {
            get
            {
                return isCompleted;
            }
            set
            {
                isCompleted = value;
            }
        }

        private string password = string.Empty;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        #endregion

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