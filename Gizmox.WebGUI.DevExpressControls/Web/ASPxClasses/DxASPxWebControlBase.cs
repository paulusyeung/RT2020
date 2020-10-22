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
    public class DxASPxWebControlBase : Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
    {
        #region C'tor

        public DxASPxWebControlBase()
        {
        }

        #endregion

        #region Methods

        public void DataBind()
        {
            this.HostedASPxWebControlBase.DataBind();
        }

        //public bool IsDesignMode()
        //{
        //    return this.HostedASPxWebControlBase.IsDesignMode();
        //}

        public bool IsEnabled()
        {
            return this.HostedASPxWebControlBase.IsEnabled();
        }

        public bool IsLoading()
        {
            return this.HostedASPxWebControlBase.IsLoading();
        }

        public bool IsViewStateStoring()
        {
            return this.HostedASPxWebControlBase.IsViewStateStoring();
        }

        public void ResetViewStateStoringFlag()
        {
            this.HostedASPxWebControlBase.ResetViewStateStoringFlag();
        }

        public void SetViewStateStoringFlag()
        {
            this.HostedASPxWebControlBase.SetViewStateStoringFlag();
        }
        
        #endregion

        #region Events

        #endregion

        #region Properties

        // 2007.12.21 paulus: changed from ControlCollection to System.Web.UI.ControlCollection
        [Description("Gets the web control's collection of child controls.")]
        public System.Web.UI.ControlCollection Controls
        {
            get
            {
                return (System.Web.UI.ControlCollection)this.GetProperty("Controls");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool Initialized
        {
            get
            {
                return (bool)this.GetProperty("Initialized");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool PreRendered
        {
            get
            {
                return (bool)this.GetProperty("PreRendered");
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool ViewStateLoading
        {
            get
            {
                return (bool)this.GetProperty("ViewStateLoading");
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
                return typeof(DevExpress.Web.ASPxWebControlBase);
            }
        }

        /// <summary>
        /// Returns the hosted ASPxWebControlBase control.
        /// </summary>
        protected DevExpress.Web.ASPxWebControlBase HostedASPxWebControlBase
        {
            get
            {
                return (DevExpress.Web.ASPxWebControlBase)this.HostedControl;
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
