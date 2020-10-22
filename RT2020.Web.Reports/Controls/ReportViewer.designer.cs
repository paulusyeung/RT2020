namespace RT2020.Web.Reports.Controls.Reporting
{
	partial class ReportViewer
	{
		#region Fields
		
        /// <summary>
        /// Required designer variable.
        /// </summary>
		private System.ComponentModel.IContainer components = null;

		#endregion

		#region Visual WebGui Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}

		#endregion	
		
		#region Properties
		
		/// <summary>
        /// Get the hosted control type
        /// </summary>
        protected override System.Type HostedControlType
        {
            get
            {
                return typeof(Microsoft.Reporting.WebForms.ReportViewer);
            }
        }
        
        /// <summary>
        /// Get hosted control typed instance
        /// </summary>
        protected Microsoft.Reporting.WebForms.ReportViewer HostedReportViewer
        {
            get
            {
                return (Microsoft.Reporting.WebForms.ReportViewer)this.HostedControl;
            }
        }
        
        		
		/// <summary>
		/// Determines whether the document map is visible or collapsed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines whether the document map is visible or collapsed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean DocumentMapCollapsed
        {
            get
            {
                return (System.Boolean)this.GetProperty("DocumentMapCollapsed");
            }
            set
            {
                this.SetProperty("DocumentMapCollapsed", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether the document map is visible or collapsed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DocumentMapCollapsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDocumentMapCollapsed()
        {
			return this.ShouldSerialize("DocumentMapCollapsed");
        }
        
        
        /// <summary>
		/// Resets the Determines whether the document map is visible or collapsed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DocumentMapCollapsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDocumentMapCollapsed()
        {
			this.Reset("DocumentMapCollapsed");
        }
        
		
		/// <summary>
		/// Determines the visibility of the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines the visibility of the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowToolBar
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowToolBar");
            }
            set
            {
                this.SetProperty("ShowToolBar", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowToolBar property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowToolBar()
        {
			return this.ShouldSerialize("ShowToolBar");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowToolBar property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowToolBar()
        {
			this.Reset("ShowToolBar");
        }
        
		
		/// <summary>
		/// Determines whether parameter prompts should be displayed during remote processing.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines whether parameter prompts should be displayed during remote processing.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowParameterPrompts
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowParameterPrompts");
            }
            set
            {
                this.SetProperty("ShowParameterPrompts", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether parameter prompts should be displayed during remote processing. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowParameterPrompts property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowParameterPrompts()
        {
			return this.ShouldSerialize("ShowParameterPrompts");
        }
        
        
        /// <summary>
		/// Resets the Determines whether parameter prompts should be displayed during remote processing. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowParameterPrompts property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowParameterPrompts()
        {
			this.Reset("ShowParameterPrompts");
        }
        
		
		/// <summary>
		/// Determines whether credential prompts should be displayed during remote processing.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines whether credential prompts should be displayed during remote processing.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowCredentialPrompts
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowCredentialPrompts");
            }
            set
            {
                this.SetProperty("ShowCredentialPrompts", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether credential prompts should be displayed during remote processing. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowCredentialPrompts property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowCredentialPrompts()
        {
			return this.ShouldSerialize("ShowCredentialPrompts");
        }
        
        
        /// <summary>
		/// Resets the Determines whether credential prompts should be displayed during remote processing. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowCredentialPrompts property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowCredentialPrompts()
        {
			this.Reset("ShowCredentialPrompts");
        }
        
		
		/// <summary>
		/// Determines whether the prompt area is visible or collapsed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines whether the prompt area is visible or collapsed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean PromptAreaCollapsed
        {
            get
            {
                return (System.Boolean)this.GetProperty("PromptAreaCollapsed");
            }
            set
            {
                this.SetProperty("PromptAreaCollapsed", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether the prompt area is visible or collapsed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the PromptAreaCollapsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializePromptAreaCollapsed()
        {
			return this.ShouldSerialize("PromptAreaCollapsed");
        }
        
        
        /// <summary>
		/// Resets the Determines whether the prompt area is visible or collapsed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the PromptAreaCollapsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetPromptAreaCollapsed()
        {
			this.Reset("PromptAreaCollapsed");
        }
        
		
		/// <summary>
		/// Determines if the report content is rendered.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines if the report content is rendered.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowReportBody
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowReportBody");
            }
            set
            {
                this.SetProperty("ShowReportBody", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines if the report content is rendered. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowReportBody property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowReportBody()
        {
			return this.ShouldSerialize("ShowReportBody");
        }
        
        
        /// <summary>
		/// Resets the Determines if the report content is rendered. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowReportBody property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowReportBody()
        {
			this.Reset("ShowReportBody");
        }
        
		
		/// <summary>
		/// Determines the width of the document map.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines the width of the document map.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.Unit DocumentMapWidth
        {
            get
            {
                return (System.Web.UI.WebControls.Unit)this.GetProperty("DocumentMapWidth");
            }
            set
            {
                this.SetProperty("DocumentMapWidth", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the width of the document map. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DocumentMapWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDocumentMapWidth()
        {
			return this.ShouldSerialize("DocumentMapWidth");
        }
        
        
        /// <summary>
		/// Resets the Determines the width of the document map. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DocumentMapWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDocumentMapWidth()
        {
			this.Reset("DocumentMapWidth");
        }
        
		
		/// <summary>
		/// Determines the visibility of the document map button on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the document map button on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowDocumentMapButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowDocumentMapButton");
            }
            set
            {
                this.SetProperty("ShowDocumentMapButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the document map button on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowDocumentMapButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowDocumentMapButton()
        {
			return this.ShouldSerialize("ShowDocumentMapButton");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the document map button on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowDocumentMapButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowDocumentMapButton()
        {
			this.Reset("ShowDocumentMapButton");
        }
        
		
		/// <summary>
		/// Determines the visibility of the prompt area button on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the prompt area button on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowPromptAreaButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowPromptAreaButton");
            }
            set
            {
                this.SetProperty("ShowPromptAreaButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the prompt area button on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowPromptAreaButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowPromptAreaButton()
        {
			return this.ShouldSerialize("ShowPromptAreaButton");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the prompt area button on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowPromptAreaButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowPromptAreaButton()
        {
			this.Reset("ShowPromptAreaButton");
        }
        
		
		/// <summary>
		/// Determines the visibility of the page navigation controls on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the page navigation controls on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowPageNavigationControls
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowPageNavigationControls");
            }
            set
            {
                this.SetProperty("ShowPageNavigationControls", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the page navigation controls on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowPageNavigationControls property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowPageNavigationControls()
        {
			return this.ShouldSerialize("ShowPageNavigationControls");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the page navigation controls on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowPageNavigationControls property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowPageNavigationControls()
        {
			this.Reset("ShowPageNavigationControls");
        }
        
		
		/// <summary>
		/// Determines the visibility of the back button on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the back button on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowBackButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowBackButton");
            }
            set
            {
                this.SetProperty("ShowBackButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the back button on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowBackButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowBackButton()
        {
			return this.ShouldSerialize("ShowBackButton");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the back button on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowBackButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowBackButton()
        {
			this.Reset("ShowBackButton");
        }
        
		
		/// <summary>
		/// Determines the visibility of the refresh button on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the refresh button on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowRefreshButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowRefreshButton");
            }
            set
            {
                this.SetProperty("ShowRefreshButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the refresh button on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowRefreshButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowRefreshButton()
        {
			return this.ShouldSerialize("ShowRefreshButton");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the refresh button on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowRefreshButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowRefreshButton()
        {
			this.Reset("ShowRefreshButton");
        }
        
		
		/// <summary>
		/// Determines the visibility of the print, print layout, and page setup buttons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the print, print layout, and page setup buttons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowPrintButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowPrintButton");
            }
            set
            {
                this.SetProperty("ShowPrintButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the print, print layout, and page setup buttons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowPrintButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowPrintButton()
        {
			return this.ShouldSerialize("ShowPrintButton");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the print, print layout, and page setup buttons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowPrintButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowPrintButton()
        {
			this.Reset("ShowPrintButton");
        }
        
		
		/// <summary>
		/// Determines the visibility of the export button on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the export button on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowExportControls
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowExportControls");
            }
            set
            {
                this.SetProperty("ShowExportControls", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the export button on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowExportControls property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowExportControls()
        {
			return this.ShouldSerialize("ShowExportControls");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the export button on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowExportControls property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowExportControls()
        {
			this.Reset("ShowExportControls");
        }
        
		
		/// <summary>
		/// Determines the visibility of the zoom button on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the zoom button on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowZoomControl
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowZoomControl");
            }
            set
            {
                this.SetProperty("ShowZoomControl", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the zoom button on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowZoomControl property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowZoomControl()
        {
			return this.ShouldSerialize("ShowZoomControl");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the zoom button on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowZoomControl property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowZoomControl()
        {
			this.Reset("ShowZoomControl");
        }
        
		
		/// <summary>
		/// Determines the visibility of the find controls on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("ToolBar")]
        [System.ComponentModel.Description("Determines the visibility of the find controls on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowFindControls
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowFindControls");
            }
            set
            {
                this.SetProperty("ShowFindControls", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the visibility of the find controls on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowFindControls property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowFindControls()
        {
			return this.ShouldSerialize("ShowFindControls");
        }
        
        
        /// <summary>
		/// Resets the Determines the visibility of the find controls on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowFindControls property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowFindControls()
        {
			this.Reset("ShowFindControls");
        }
        
		
		/// <summary>
		/// Color of the background of the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Color of the background of the control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color BackColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("BackColor");
            }
            set
            {
                this.SetProperty("BackColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Color of the background of the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the BackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeBackColor()
        {
			return this.ShouldSerialize("BackColor");
        }
        
        
        /// <summary>
		/// Resets the Color of the background of the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the BackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetBackColor()
        {
			this.Reset("BackColor");
        }
        
		
		/// <summary>
		/// Determines the font of the wait message.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines the font of the wait message.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.Web.UI.WebControls.FontInfo WaitMessageFont
        {
            get
            {
                return (System.Web.UI.WebControls.FontInfo)this.GetProperty("WaitMessageFont");
            }
        }
        
		
		/// <summary>
		/// The border style between major areas of the report viewer.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border style between major areas of the report viewer.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.BorderStyle InternalBorderStyle
        {
            get
            {
                return (System.Web.UI.WebControls.BorderStyle)this.GetProperty("InternalBorderStyle");
            }
            set
            {
                this.SetProperty("InternalBorderStyle", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border style between major areas of the report viewer. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the InternalBorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeInternalBorderStyle()
        {
			return this.ShouldSerialize("InternalBorderStyle");
        }
        
        
        /// <summary>
		/// Resets the The border style between major areas of the report viewer. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the InternalBorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetInternalBorderStyle()
        {
			this.Reset("InternalBorderStyle");
        }
        
		
		/// <summary>
		/// The border color between major areas of the report viewer.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border color between major areas of the report viewer.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color InternalBorderColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("InternalBorderColor");
            }
            set
            {
                this.SetProperty("InternalBorderColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border color between major areas of the report viewer. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the InternalBorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeInternalBorderColor()
        {
			return this.ShouldSerialize("InternalBorderColor");
        }
        
        
        /// <summary>
		/// Resets the The border color between major areas of the report viewer. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the InternalBorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetInternalBorderColor()
        {
			this.Reset("InternalBorderColor");
        }
        
		
		/// <summary>
		/// The border width between major areas of the report viewer.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border width between major areas of the report viewer.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.Unit InternalBorderWidth
        {
            get
            {
                return (System.Web.UI.WebControls.Unit)this.GetProperty("InternalBorderWidth");
            }
            set
            {
                this.SetProperty("InternalBorderWidth", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border width between major areas of the report viewer. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the InternalBorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeInternalBorderWidth()
        {
			return this.ShouldSerialize("InternalBorderWidth");
        }
        
        
        /// <summary>
		/// Resets the The border width between major areas of the report viewer. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the InternalBorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetInternalBorderWidth()
        {
			this.Reset("InternalBorderWidth");
        }
        
		
		/// <summary>
		/// The border style of icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border style of icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.BorderStyle ToolBarItemBorderStyle
        {
            get
            {
                return (System.Web.UI.WebControls.BorderStyle)this.GetProperty("ToolBarItemBorderStyle");
            }
            set
            {
                this.SetProperty("ToolBarItemBorderStyle", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border style of icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemBorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemBorderStyle()
        {
			return this.ShouldSerialize("ToolBarItemBorderStyle");
        }
        
        
        /// <summary>
		/// Resets the The border style of icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemBorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemBorderStyle()
        {
			this.Reset("ToolBarItemBorderStyle");
        }
        
		
		/// <summary>
		/// The border color of icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border color of icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color ToolBarItemBorderColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("ToolBarItemBorderColor");
            }
            set
            {
                this.SetProperty("ToolBarItemBorderColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border color of icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemBorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemBorderColor()
        {
			return this.ShouldSerialize("ToolBarItemBorderColor");
        }
        
        
        /// <summary>
		/// Resets the The border color of icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemBorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemBorderColor()
        {
			this.Reset("ToolBarItemBorderColor");
        }
        
		
		/// <summary>
		/// The border width of icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border width of icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.Unit ToolBarItemBorderWidth
        {
            get
            {
                return (System.Web.UI.WebControls.Unit)this.GetProperty("ToolBarItemBorderWidth");
            }
            set
            {
                this.SetProperty("ToolBarItemBorderWidth", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border width of icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemBorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemBorderWidth()
        {
			return this.ShouldSerialize("ToolBarItemBorderWidth");
        }
        
        
        /// <summary>
		/// Resets the The border width of icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemBorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemBorderWidth()
        {
			this.Reset("ToolBarItemBorderWidth");
        }
        
		
		/// <summary>
		/// The border style of pressed icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border style of pressed icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.BorderStyle ToolBarItemPressedBorderStyle
        {
            get
            {
                return (System.Web.UI.WebControls.BorderStyle)this.GetProperty("ToolBarItemPressedBorderStyle");
            }
            set
            {
                this.SetProperty("ToolBarItemPressedBorderStyle", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border style of pressed icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemPressedBorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemPressedBorderStyle()
        {
			return this.ShouldSerialize("ToolBarItemPressedBorderStyle");
        }
        
        
        /// <summary>
		/// Resets the The border style of pressed icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemPressedBorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemPressedBorderStyle()
        {
			this.Reset("ToolBarItemPressedBorderStyle");
        }
        
		
		/// <summary>
		/// The border color of pressed icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border color of pressed icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color ToolBarItemPressedBorderColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("ToolBarItemPressedBorderColor");
            }
            set
            {
                this.SetProperty("ToolBarItemPressedBorderColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border color of pressed icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemPressedBorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemPressedBorderColor()
        {
			return this.ShouldSerialize("ToolBarItemPressedBorderColor");
        }
        
        
        /// <summary>
		/// Resets the The border color of pressed icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemPressedBorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemPressedBorderColor()
        {
			this.Reset("ToolBarItemPressedBorderColor");
        }
        
		
		/// <summary>
		/// The border width of pressed icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The border width of pressed icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.Unit ToolBarItemPressedBorderWidth
        {
            get
            {
                return (System.Web.UI.WebControls.Unit)this.GetProperty("ToolBarItemPressedBorderWidth");
            }
            set
            {
                this.SetProperty("ToolBarItemPressedBorderWidth", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The border width of pressed icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemPressedBorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemPressedBorderWidth()
        {
			return this.ShouldSerialize("ToolBarItemPressedBorderWidth");
        }
        
        
        /// <summary>
		/// Resets the The border width of pressed icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemPressedBorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemPressedBorderWidth()
        {
			this.Reset("ToolBarItemPressedBorderWidth");
        }
        
		
		/// <summary>
		/// The background color of icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The background color of icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color ToolBarItemHoverBackColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("ToolBarItemHoverBackColor");
            }
            set
            {
                this.SetProperty("ToolBarItemHoverBackColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The background color of icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemHoverBackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemHoverBackColor()
        {
			return this.ShouldSerialize("ToolBarItemHoverBackColor");
        }
        
        
        /// <summary>
		/// Resets the The background color of icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemHoverBackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemHoverBackColor()
        {
			this.Reset("ToolBarItemHoverBackColor");
        }
        
		
		/// <summary>
		/// The background color of pressed icons on the toolbar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The background color of pressed icons on the toolbar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color ToolBarItemPressedHoverBackColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("ToolBarItemPressedHoverBackColor");
            }
            set
            {
                this.SetProperty("ToolBarItemPressedHoverBackColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The background color of pressed icons on the toolbar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarItemPressedHoverBackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarItemPressedHoverBackColor()
        {
			return this.ShouldSerialize("ToolBarItemPressedHoverBackColor");
        }
        
        
        /// <summary>
		/// Resets the The background color of pressed icons on the toolbar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarItemPressedHoverBackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarItemPressedHoverBackColor()
        {
			this.Reset("ToolBarItemPressedHoverBackColor");
        }
        
		
		/// <summary>
		/// The color of disabled links in the toolbar and prompt areas.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The color of disabled links in the toolbar and prompt areas.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color LinkDisabledColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("LinkDisabledColor");
            }
            set
            {
                this.SetProperty("LinkDisabledColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The color of disabled links in the toolbar and prompt areas. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the LinkDisabledColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeLinkDisabledColor()
        {
			return this.ShouldSerialize("LinkDisabledColor");
        }
        
        
        /// <summary>
		/// Resets the The color of disabled links in the toolbar and prompt areas. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the LinkDisabledColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetLinkDisabledColor()
        {
			this.Reset("LinkDisabledColor");
        }
        
		
		/// <summary>
		/// The color of active links in the toolbar and prompt areas.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The color of active links in the toolbar and prompt areas.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color LinkActiveColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("LinkActiveColor");
            }
            set
            {
                this.SetProperty("LinkActiveColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The color of active links in the toolbar and prompt areas. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the LinkActiveColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeLinkActiveColor()
        {
			return this.ShouldSerialize("LinkActiveColor");
        }
        
        
        /// <summary>
		/// Resets the The color of active links in the toolbar and prompt areas. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the LinkActiveColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetLinkActiveColor()
        {
			this.Reset("LinkActiveColor");
        }
        
		
		/// <summary>
		/// The color of active links in the toolbar and prompt areas while the mouse is hovering over the text.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The color of active links in the toolbar and prompt areas while the mouse is hovering over the text.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color LinkActiveHoverColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("LinkActiveHoverColor");
            }
            set
            {
                this.SetProperty("LinkActiveHoverColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The color of active links in the toolbar and prompt areas while the mouse is hovering over the text. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the LinkActiveHoverColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeLinkActiveHoverColor()
        {
			return this.ShouldSerialize("LinkActiveHoverColor");
        }
        
        
        /// <summary>
		/// Resets the The color of active links in the toolbar and prompt areas while the mouse is hovering over the text. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the LinkActiveHoverColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetLinkActiveHoverColor()
        {
			this.Reset("LinkActiveHoverColor");
        }
        
		
		/// <summary>
		/// Determines if the report area has a fixed size or is the size of the report content.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines if the report area has a fixed size or is the size of the report content.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean SizeToReportContent
        {
            get
            {
                return (System.Boolean)this.GetProperty("SizeToReportContent");
            }
            set
            {
                this.SetProperty("SizeToReportContent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines if the report area has a fixed size or is the size of the report content. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the SizeToReportContent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeSizeToReportContent()
        {
			return this.ShouldSerialize("SizeToReportContent");
        }
        
        
        /// <summary>
		/// Resets the Determines if the report area has a fixed size or is the size of the report content. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the SizeToReportContent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetSizeToReportContent()
        {
			this.Reset("SizeToReportContent");
        }
        
		
		/// <summary>
		/// Determines whether report processing occurs locally or on a report server.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Determines whether report processing occurs locally or on a report server.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public Microsoft.Reporting.WebForms.ProcessingMode ProcessingMode
        {
            get
            {
                return (Microsoft.Reporting.WebForms.ProcessingMode)this.GetProperty("ProcessingMode");
            }
            set
            {
                this.SetProperty("ProcessingMode", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether report processing occurs locally or on a report server. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ProcessingMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeProcessingMode()
        {
			return this.ShouldSerialize("ProcessingMode");
        }
        
        
        /// <summary>
		/// Resets the Determines whether report processing occurs locally or on a report server. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ProcessingMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetProcessingMode()
        {
			this.Reset("ProcessingMode");
        }
        
		
		/// <summary>
		/// Remote processing properties.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Remote processing properties.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public Microsoft.Reporting.WebForms.ServerReport ServerReport
        {
            get
            {
                return (Microsoft.Reporting.WebForms.ServerReport)this.GetProperty("ServerReport");
            }
        }
        
		
		/// <summary>
		/// Local processing properties.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Local processing properties.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public Microsoft.Reporting.WebForms.LocalReport LocalReport
        {
            get
            {
                return (Microsoft.Reporting.WebForms.LocalReport)this.GetProperty("LocalReport");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.Int32 CurrentPage
        {
            get
            {
                return (System.Int32)this.GetProperty("CurrentPage");
            }
            set
            {
                this.SetProperty("CurrentPage", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if  should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the CurrentPage property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeCurrentPage()
        {
			return this.ShouldSerialize("CurrentPage");
        }
        
        
        /// <summary>
		/// Resets the  property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the CurrentPage property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetCurrentPage()
        {
			this.Reset("CurrentPage");
        }
        
		
		/// <summary>
		/// Determines the type of zoom applied to the report.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines the type of zoom applied to the report.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public Microsoft.Reporting.WebForms.ZoomMode ZoomMode
        {
            get
            {
                return (Microsoft.Reporting.WebForms.ZoomMode)this.GetProperty("ZoomMode");
            }
            set
            {
                this.SetProperty("ZoomMode", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the type of zoom applied to the report. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ZoomMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeZoomMode()
        {
			return this.ShouldSerialize("ZoomMode");
        }
        
        
        /// <summary>
		/// Resets the Determines the type of zoom applied to the report. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ZoomMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetZoomMode()
        {
			this.Reset("ZoomMode");
        }
        
		
		/// <summary>
		/// Determines the percentage of zoom applied to the report when ZoomMode is set to Percent.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines the percentage of zoom applied to the report when ZoomMode is set to Percent.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 ZoomPercent
        {
            get
            {
                return (System.Int32)this.GetProperty("ZoomPercent");
            }
            set
            {
                this.SetProperty("ZoomPercent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the percentage of zoom applied to the report when ZoomMode is set to Percent. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ZoomPercent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeZoomPercent()
        {
			return this.ShouldSerialize("ZoomPercent");
        }
        
        
        /// <summary>
		/// Resets the Determines the percentage of zoom applied to the report when ZoomMode is set to Percent. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ZoomPercent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetZoomPercent()
        {
			this.Reset("ZoomPercent");
        }
        
		
		/// <summary>
		/// Determines if the report is rendered asynchronously from the rest of the web page.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Determines if the report is rendered asynchronously from the rest of the web page.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AsyncRendering
        {
            get
            {
                return (System.Boolean)this.GetProperty("AsyncRendering");
            }
            set
            {
                this.SetProperty("AsyncRendering", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines if the report is rendered asynchronously from the rest of the web page. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AsyncRendering property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAsyncRendering()
        {
			return this.ShouldSerialize("AsyncRendering");
        }
        
        
        /// <summary>
		/// Resets the Determines if the report is rendered asynchronously from the rest of the web page. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AsyncRendering property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAsyncRendering()
        {
			this.Reset("AsyncRendering");
        }
        
		
		/// <summary>
		/// The target window of the hyperlinks in the report.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The target window of the hyperlinks in the report.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String HyperlinkTarget
        {
            get
            {
                return (System.String)this.GetProperty("HyperlinkTarget");
            }
            set
            {
                this.SetProperty("HyperlinkTarget", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The target window of the hyperlinks in the report. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the HyperlinkTarget property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHyperlinkTarget()
        {
			return this.ShouldSerialize("HyperlinkTarget");
        }
        
        
        /// <summary>
		/// Resets the The target window of the hyperlinks in the report. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the HyperlinkTarget property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHyperlinkTarget()
        {
			this.Reset("HyperlinkTarget");
        }
        
		
		/// <summary>
		/// Determines which mime types are exported as attachments.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Determines which mime types are exported as attachments.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public Microsoft.Reporting.WebForms.ContentDisposition ExportContentDisposition
        {
            get
            {
                return (Microsoft.Reporting.WebForms.ContentDisposition)this.GetProperty("ExportContentDisposition");
            }
            set
            {
                this.SetProperty("ExportContentDisposition", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines which mime types are exported as attachments. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ExportContentDisposition property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeExportContentDisposition()
        {
			return this.ShouldSerialize("ExportContentDisposition");
        }
        
        
        /// <summary>
		/// Resets the Determines which mime types are exported as attachments. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ExportContentDisposition property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetExportContentDisposition()
        {
			this.Reset("ExportContentDisposition");
        }
        
		
		/// <summary>
		/// Programmatic name of the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Programmatic name of the control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String ID
        {
            get
            {
                return (System.String)this.GetProperty("ID");
            }
            set
            {
                this.SetProperty("ID", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Programmatic name of the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ID property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeID()
        {
			return this.ShouldSerialize("ID");
        }
        
        
        /// <summary>
		/// Resets the Programmatic name of the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ID property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetID()
        {
			this.Reset("ID");
        }
        
		
		/// <summary>
		/// The collection of child controls owned by the control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The collection of child controls owned by the control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Web.UI.ControlCollection Controls
        {
            get
            {
                return (System.Web.UI.ControlCollection)this.GetProperty("Controls");
            }
        }
        

        
        #endregion
        
        #region Methods
		
        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
	    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
				

        /// <summary>
        /// 
        /// </summary>
        public void JumpToDocumentMapId(System.String documentMapId)
        {
            this.HostedReportViewer.JumpToDocumentMapId( documentMapId);
        }
		

        /// <summary>
        /// 
        /// </summary>
        public void PerformBack()
        {
            this.HostedReportViewer.PerformBack();
        }
		

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            this.HostedReportViewer.Reset();
        }
		

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.HostedReportViewer.Dispose();
        }
		

        /// <summary>
        /// 
        /// </summary>
        public void JumpToBookmark(System.String bookmarkId)
        {
            this.HostedReportViewer.JumpToBookmark( bookmarkId);
        }
		

        /// <summary>
        /// 
        /// </summary>
        public void DataBind()
        {
            this.HostedReportViewer.DataBind();
        }

		
		#endregion
		
		#region Events
		
		
        /// <summary>
        /// Occurs when the user changes the displayed page of the report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user changes the displayed page of the report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.PageNavigationEventHandler PageNavigation
        {
            add
            {
                this.AddEventHandler("PageNavigation", value);
            }
            remove
            {
                this.RemoveEventHandler("PageNavigation", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user navigates back to the parent report of a drillthrough report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user navigates back to the parent report of a drillthrough report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.BackEventHandler Back
        {
            add
            {
                this.AddEventHandler("Back", value);
            }
            remove
            {
                this.RemoveEventHandler("Back", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user navigates to a document map entry in the report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user navigates to a document map entry in the report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.DocumentMapNavigationEventHandler DocumentMapNavigation
        {
            add
            {
                this.AddEventHandler("DocumentMapNavigation", value);
            }
            remove
            {
                this.RemoveEventHandler("DocumentMapNavigation", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user navigates to a bookmark in the report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user navigates to a bookmark in the report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.BookmarkNavigationEventHandler BookmarkNavigation
        {
            add
            {
                this.AddEventHandler("BookmarkNavigation", value);
            }
            remove
            {
                this.RemoveEventHandler("BookmarkNavigation", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user toggles an item in the report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user toggles an item in the report.")]
        [System.ComponentModel.Browsable(true)] 
        public event System.ComponentModel.CancelEventHandler Toggle
        {
            add
            {
                this.AddEventHandler("Toggle", value);
            }
            remove
            {
                this.RemoveEventHandler("Toggle", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user performs a drillthrough to a new report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user performs a drillthrough to a new report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.DrillthroughEventHandler Drillthrough
        {
            add
            {
                this.AddEventHandler("Drillthrough", value);
            }
            remove
            {
                this.RemoveEventHandler("Drillthrough", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user performs a sort on the report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user performs a sort on the report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.SortEventHandler Sort
        {
            add
            {
                this.AddEventHandler("Sort", value);
            }
            remove
            {
                this.RemoveEventHandler("Sort", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user searches for text in the report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user searches for text in the report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.SearchEventHandler Search
        {
            add
            {
                this.AddEventHandler("Search", value);
            }
            remove
            {
                this.RemoveEventHandler("Search", value);
            }
        }
        

        /// <summary>
        /// Occurs when the user refreshes the report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when the user refreshes the report.")]
        [System.ComponentModel.Browsable(true)] 
        public event System.ComponentModel.CancelEventHandler ReportRefresh
        {
            add
            {
                this.AddEventHandler("ReportRefresh", value);
            }
            remove
            {
                this.RemoveEventHandler("ReportRefresh", value);
            }
        }
        

        /// <summary>
        /// Occurs when errors are encountered while rendering a report.
        /// </summary>
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Occurs when errors are encountered while rendering a report.")]
        [System.ComponentModel.Browsable(true)] 
        public event Microsoft.Reporting.WebForms.ReportErrorEventHandler ReportError
        {
            add
            {
                this.AddEventHandler("ReportError", value);
            }
            remove
            {
                this.RemoveEventHandler("ReportError", value);
            }
        }
        

		
		#endregion
		
	}
}
