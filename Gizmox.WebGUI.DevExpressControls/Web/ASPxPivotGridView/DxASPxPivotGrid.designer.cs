using System;
namespace Gizmox.WebGUI.DevExpressControls.Web.ASPxPivotGridView
{
    partial class DxASPxPivotGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region AspControl Box members

        /// <summary>
        /// Return 
        /// </summary>
        protected override Type HostedControlType
        {
            get
            {
                return typeof(DevExpress.Web.ASPxPivotGrid.ASPxPivotGrid);
            }
        }

        /// <summary>
        /// Returns the hosted DevExpress aspx grid.
        /// </summary>
        protected DevExpress.Web.ASPxPivotGrid.ASPxPivotGrid HostedASPxPivotGrid
        {
            get
            {
                return (DevExpress.Web.ASPxPivotGrid.ASPxPivotGrid)base.HostedControl;
            }
        }

        #endregion

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
}
