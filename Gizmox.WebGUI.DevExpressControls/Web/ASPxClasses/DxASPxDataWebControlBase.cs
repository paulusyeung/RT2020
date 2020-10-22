#region Using

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using DevExpress.Web;
using DevExpress.Web.Data;
using DevExpress.Data;
using System.Web.UI;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using DevExpress.Web.Internal;
using DevExpress.Web.Rendering;
using System.Drawing;
using DevExpress.Utils.Design;
using DevExpress.Web.Design;

#endregion

namespace Gizmox.WebGUI.DevExpressControls.Web.ASPxClasses
{
    public class DxASPxDataWebControlBase : DxASPxWebControl
    {
        #region C'tor

        public DxASPxDataWebControlBase()
        {
        }

        #endregion

        #region Methods

        public void DataBind()
        {
            this.HostedASPxDataWebControlBase.DataBind();
        }

        #endregion

        #region Events

        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool Bound
        {
            get
            {
                return (bool)this.GetProperty("Bound");
            }
            set
            {
                this.SetProperty("Bound", value);
            }
        }

        [AutoFormatDisable, Category("Data"), Themeable(false), DefaultValue((string)null), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("Gets or sets the object from which the data-bound control retrieves its list of data items. "), Bindable(false)]
        public virtual object DataSource
        {
            get
            {
                return (object)this.GetProperty("DataSource");
            }
            set
            {
                this.SetProperty("DataSource", value);
            }
        }

        [DefaultValue(""), Themeable(false), Category("Data"), Description("Gets or sets the ID of the control from which the data-bound control retrieves its list of data items. "), AutoFormatDisable]
        public virtual string DataSourceID
        {
            get
            {
                return (string)this.GetProperty("DataSourceID");
            }
            set
            {
                this.SetProperty("DataSourceID", value);
            }
        }

        #endregion

        #region AspControl Box members

        /// <summary>
        /// Return 
        /// </summary>
        protected override Type HostedControlType
        {
            get
            {
                return typeof(DevExpress.Web.ASPxDataWebControlBase);
            }
        }

        /// <summary>
        /// Returns the hosted ASPxDataWebControlBase control.
        /// </summary>
        protected DevExpress.Web.ASPxDataWebControlBase HostedASPxDataWebControlBase
        {
            get
            {
                return (DevExpress.Web.ASPxDataWebControlBase)this.HostedControl;
            }
        }

        //protected override bool IsStatelessHostedControl
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        //protected override void RestoreState()
        //{
        //    base.RestoreState();

        //    if (this.DataSource != null)
        //    {
        //        this.DataBind();
        //    }
        //}

        #endregion
    }
}
