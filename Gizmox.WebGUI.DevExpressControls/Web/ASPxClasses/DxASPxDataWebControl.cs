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
    public class DxASPxDataWebControl : DxASPxDataWebControlBase

    {
        #region C'tor

        public DxASPxDataWebControl()
        {
        }

        #endregion

        #region Methods
                        
        #endregion

        #region Events

        #endregion

        #region Properties

        [Description("Gets or sets the name of the list of data that the data-bound control binds to, in instances where the data source contains more than one distinct list of data items. "), DefaultValue(""), Themeable(false), Category("Data"), AutoFormatDisable]
        public virtual string DataMember
        {
            get
            {
                return (string)this.GetProperty("DataMember");
            }
            set
            {
                this.SetProperty("DataMember", value);
            }
        }

        [IDReferenceProperty(typeof(DataSourceControl)), Description("This member overrides the ASPxDataWebControlBase.DataSourceID. ")]
        public override string DataSourceID
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
                return typeof(DevExpress.Web.ASPxDataWebControl);
            }
        }

        /// <summary>
        /// Returns the hosted ASPxDataWebControl control.
        /// </summary>
        protected DevExpress.Web.ASPxDataWebControl HostedASPxDataWebControl
        {
            get
            {
                return (DevExpress.Web.ASPxDataWebControl)this.HostedControl;
            }
        }

        //protected override bool IsStatelessHostedControl
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        #endregion
    }
}