using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;

using RT2020.DAL;

namespace RT2020.Client
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (DisplayLoginForm() == DialogResult.OK)
			{
				sslUserName.Text += Properties.Settings.Default.username;
				sslCurrentDate.Text += DateTime.Now.ToString("d", Thread.CurrentThread.CurrentUICulture);

                ShowDashboard();
			}
			else
			{
				Application.Exit();
			}
		}

		#region Display LoginForm
		private DialogResult DisplayLoginForm()
		{
			// now it's time for the user to login
			// note: that we are passing the web service wrapper instance
			// and the user information. you'll see a lot of this
			// because the wrapper very important.
			Login lForm = new Login();
			DialogResult lFormResult = lForm.ShowDialog();
			this.Refresh();

			// the login form will not close unless the user
			// is authenticated or the user cancels
			// if the user canceled, close the app
			return lFormResult;
		}
		#endregion

        #region Show Dashboard
        private void ShowDashboard()
        {
            //Dashboard oDashboard = new Dashboard();
            //WindowsMDIShow(oDashboard, "");
        }
        #endregion

		#region Breadcrumb Caption
		private void BreadcrumbCaption(string type)
		{
			panel1.Visible = true;
			bcmBreadcrumb.Caption = type;
            bcmBreadcrumb.ThemeFormat.BorderColor = Common.Theme.Breadcrumb.BorderColor();
            bcmBreadcrumb.ThemeFormat.NormalColorTwo = Common.Theme.Breadcrumb.BackColor();
		}
		#endregion

		#region Windows MDI Show
		public void WindwosMDIClose()
		{
			foreach (System.Windows.Forms.Form frm in this.MdiChildren)
			{
				frm.Close();
			}
		}

		private void WindowsMDIShow(Form formWin, string type)
		{
			foreach (System.Windows.Forms.Form frm in this.MdiChildren)
			{
				frm.Close();
			}

			//NewInOut(type);
			BreadcrumbCaption(type);

			formWin.MdiParent = this;
			//formWin.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			formWin.ControlBox = false;
			//formWin.Font = global::e2J_JE.Properties.Settings.Default.GlobalFont;
            formWin.BackColor = Common.Theme.Workspace.BackColor();
			formWin.WindowState = FormWindowState.Maximized;
			formWin.Show();
        }

        public void MdiChildCallback(string msg)
        {
            switch (msg)
            {
                case "CAP":
                    WindowsMDIShow(new Inventory.GoodsReceive.Default(), "Inventory > Goods Receive");
                    break;
                //
                default:
                    MessageBox.Show(msg);
                    break;
            }
        }
        #endregion

        #region Popup Windows
        private void ShowPopups(Form popup)
        {
            popup.ShowDialog();
        }
        #endregion

        #region AppMenuStrip Click
        private void amsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void amsMain_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem oItem = (ToolStripMenuItem)sender;
            string arg = oItem.Name.Substring(3);
            switch (arg)
            {
                default:
                    MessageBox.Show(arg);
                    break;
            }
        }

        private void amsHelpAbout_Click(object sender, EventArgs e)
        {
            RT2020.Client.Help.About HelpAbout = new RT2020.Client.Help.About();
            HelpAbout.Show();
        }
		#endregion

        #region AppToolStrip Click
        private void atsMain_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem oItem = (ToolStripMenuItem)sender;
            string arg = oItem.Name.Substring(3);

            Cursor.Current = Cursors.WaitCursor;
            switch (arg)
            {
                case "NewCAP":
                    ShowPopups(new Inventory.GoodsReceive.Wizard());
                    break;
                case "NewPOM": // Purchase Order (Multi-Locations)
                    ShowPopups(new Purchasing.Wizard.ByMultipleLocation());
                    break;
                case "NewPOS": // Purchase Order
                    ShowPopups(new Purchasing.Wizard.PurchaseOrder());
                    break;
                case "NewPOR": // Purchase Order receiving
                    ShowPopups(new Purchasing.Wizard.ReceivingFind());
                    break;
                case "Product": // Product
                    ShowPopups(new Products.Wizard.ProductWizard());
                    break;
                case "ProductFast": // Product fast version
                    ShowPopups(new Products.Wizard.ProductWizard_FastCreation());
                    break;
                case "ProductBatch": // Product batch version
                    ShowPopups(new Products.Wizard.ProductWizard_Batch());
                    break;
                case "ProductMU": // Mass Update product
                    ShowPopups(new Products.Wizard.ProductWizard_MassUpdate());
                    break;
                default:
                    MessageBox.Show(arg);
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region NavTree Click
        private void tvwInventory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string msg = e.Node.Name.Substring(3);

            Cursor.Current = Cursors.WaitCursor;
            switch (msg)
            {
                case "CAP":
                    WindowsMDIShow(new Inventory.GoodsReceive.Default(), "Inventory > Goods Receive");
                    break;
            }
        }

        private void tvwPurchasing_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string msg = e.Node.Name.Substring(3);

            Cursor.Current = Cursors.WaitCursor;
            switch (msg)
            {
                case "POS": // Purchase Order
                    WindowsMDIShow(new Purchasing.DefaultPOList(), "Purchasing > Orders ");
                    break;
                case "POR": // Purchase Order receiving
                    WindowsMDIShow(new Purchasing.DefaultRECList(), "Purchasing > Receiving Orders ");
                    break;
            }
        }

        private void tvwProduct_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string msg = e.Node.Name.Substring(3);

            Cursor.Current = Cursors.WaitCursor;
            switch (msg)
            {
                case "Product":
                    WindowsMDIShow(new Products.Default(), "Product");
                    break;
            }
        }

        #endregion
    }
}