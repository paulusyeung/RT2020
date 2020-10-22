using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.IO;
using System.Reflection;

namespace Westwind.Globalization
{
    /// <summary>
    /// The wwDbResourceControl class provides Page level Resource Administration
    /// support to localizable ASP.NET pages. This control allows bringing up
    /// the localization Administration Form that shows all localizable resources
    /// for editing and translation.
    /// 
    /// The control also provides the ability to show icons next to each control
    /// to jump directly to the appropriate control in the Admin form. The control
    /// can automatically detect Page, Control, Master Page (any template control)
    /// resources and jump directly to the appropriate resource entry if it exists.
    /// 
    /// Note the control shows all Localizable controls, but there's no guarantee
    /// that the controls are actually hooked up for localization in the ASP.NET
    /// page, control, master etc. resource. You need to ensure either implicit
    /// or explicit resources are actually configured on the pages.
    /// 
    /// For the control to work it merely should be placed on any form that is
    /// localizable. Display of the control is globally controlled via the 
    /// wwDbResourceConfiguration object (and the wwDbResourceConfigurationSection in
    /// Web.config by default) which allows toggling display of the control in the UI
    /// and toggling the display of the individual resource icons.
    /// 
    /// The Administration form relies on the availability of the Administration
    /// form (LocalizeForm.aspx) and a configuration entry that points at this
    /// control. This form must be distributed with your Web application.
    /// </summary>
    [ToolboxData("<{0}:wwDbResourceControl runat=server />")]
    [Localizable(false)]
    public class wwDbResourceControl : CompositeControl
    {
        protected LinkButton btnEditResources = new LinkButton();        
        protected CheckBox chkShowIcons = new CheckBox();
        
        protected bool ShowIcons = true;

        /// <summary>
        /// The default control constructor.
        /// </summary>
        public wwDbResourceControl()
        {            
        }

        protected new bool DesignMode
        {
            get { return (HttpContext.Current == null) ; }
        }

        
        /// <summary>
        ///  Determines the initial state of the ShowLocalization Icons Text box.
        /// </summary>
        [Description("Determines the initial state of the ShowLocalization Icons Text box.")]
        [Category("Localization"), DefaultValue(typeof(ShowLocalizationStates),"InheritFromProvider")]
        public ShowLocalizationStates ShowIconsInitially
        {
            get { return _ShowLocalizationIcons; }
            set { _ShowLocalizationIcons = value; }
        }
        private ShowLocalizationStates _ShowLocalizationIcons = ShowLocalizationStates.InheritFromProvider;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            
            if (!this.Page.IsPostBack)
            {
                if (this.ShowIconsInitially == ShowLocalizationStates.DontShow)
                    this.ShowIcons = false;
                else if (this.ShowIconsInitially == ShowLocalizationStates.Show)
                    this.ShowIcons = true;
                else if (this.ShowIconsInitially == ShowLocalizationStates.InheritFromProvider)
                    this.ShowIcons = wwDbResourceConfiguration.Current.ShowControlIcons &&
                                     wwDbResourceConfiguration.Current.ShowLocalizationControlOptions;
            }
            else
            {
                this.ShowIcons = this.chkShowIcons.Checked;
            }

        }


       /// <summary>
       /// Event handler that is called and can be hooked when the Edit Resources
       /// option is clicked. This interface brings up the Administration form.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected virtual void OnEditResources(object sender, EventArgs e)
        {
            // *** Now redirect and display the resource items
            string Url = this.ResolveUrl( wwDbResourceConfiguration.Current.LocalizationFormWebPath );

            string ResourceSet = wwDbResourceConfiguration.Current.StripVirtualPath( this.Context.Request.Path );

            Url += "?ResourceSet=" + HttpUtility.UrlEncode(ResourceSet,Encoding.Default);

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "t", "window.open('" + Url + "','_Localization','width=850,height=650,resizable=yes');", true);            
        }
        
        /// <summary>
        /// Event handler that is called when the Show Icons checkbox is
        /// checked or unchecked. The default behavior sets the current
        /// wwDbResourceConfiguration.ShowControlIcons setting which 
        /// is global.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnShowIcons(object sender, EventArgs e)
        {
            //if (this.ShowIcons)
            //    wwDbResourceConfiguration.Current.ShowControlIcons = true;
            //else
            //    wwDbResourceConfiguration.Current.ShowControlIcons = false;
        }


        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (this.ShowIcons && this.Visible)
                this.AddLocalizationIcons(this.Page, true);
        }
        
        protected override void Render(HtmlTextWriter writer)
        {
            if (HttpContext.Current != null && 
                !wwDbResourceConfiguration.Current.ShowLocalizationControlOptions)
                return;

            if (this.Width == Unit.Empty)
                this.Width = Unit.Pixel(250);

            base.Render(writer);
        }    

        /// <summary>
        /// Generates the Database resources for a given form
        /// </summary>
        /// <param name="ParentControl"></param>
        /// <param name="ResourcePrefix"></param>
        public void AddResourceToResourceFile(Control ParentControl, string ResourcePrefix,string ResourceSet)
        {
            if (ResourcePrefix == null)
                ResourcePrefix = "Resource1";
            
            if (ResourceSet == null)
                ResourceSet = this.Context.Request.ApplicationPath + this.Parent.TemplateControl.AppRelativeVirtualPath.Replace("~","");


            wwDbResourceDataManager Data = new wwDbResourceDataManager();

            List<LocalizableProperty> ResourceList = this.GetAllLocalizableControls(ParentControl);

            foreach (LocalizableProperty Resource in ResourceList)
            {
                string ResourceKey = Resource.ControlId + ResourcePrefix + "." + Resource.Property;

                if (!Data.ResourceExists(ResourceKey, "", ResourceSet))
                    Data.AddResource(ResourceKey, Resource.Value, "", ResourceSet);
            }
        }

        /// <summary>
        /// Goes through the form and returns a list of all control on a form
        /// that are marked as [Localizable]
        /// </summary>
        /// <param name="control">Base container to start the parsing from. Usually this will be the current form but could be a control.</param>
        /// <returns></returns>
        public List<LocalizableProperty>GetAllLocalizableControls(Control ContainerControl)
        {
            return this.GetAllLocalizableControls(ContainerControl, null);
        }

        /// <summary>
        /// Goes through the form and returns a list of all control on a form
        /// that are marked as [Localizable]
        /// 
        /// This internal method does all the work and drills into child containers
        /// recursively.
        /// </summary>
        /// <param name="control">The control at which to start parsing usually Page</param>
        /// <param name="ResourceList">An instance of the resource list. Pass null to create</param>
        /// <returns></returns>
        protected List<LocalizableProperty> GetAllLocalizableControls(Control control, List<LocalizableProperty> ResourceList)
        {
            if (control == null)
                control = this.Page;

            // *** On the first hit create the list - recursive calls pass in the list
            if (ResourceList == null)
               ResourceList = new List<LocalizableProperty>();

           // *** 'generated' controls don't have an ID and don't need to be localized
           if (control.ID != null)
           {
               // *** Read all public properties and search for Localizable Attribute
               PropertyInfo[] pi = control.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
               foreach (PropertyInfo property in pi)
               {
                   object[] Attributes = property.GetCustomAttributes(typeof(LocalizableAttribute), true);
                   if (Attributes.Length < 1)
                       continue;

                   LocalizableProperty lp = new LocalizableProperty();

                   lp.ControlId = control.ID;

                   if (lp.ControlId.StartsWith("__"))
                       lp.ControlId = lp.ControlId.Substring(2);

                   lp.Property = property.Name;
                   lp.Value = property.GetValue(control, null) as string;

                   ResourceList.Add(lp);
               }
           }

            // *** Now drill into the any contained controls
            foreach (Control ctl in control.Controls)
            {
                // *** Recurse into child controls
                if (ctl != null)
                    this.GetAllLocalizableControls(ctl,ResourceList);
            }

            return ResourceList;
        }


        /// <summary>
        /// This method is responsible for showing localization icons next to every control
        /// that has localizable properties.
        /// 
        /// The icons are resource based and also display the control's ID. Note icons are
        /// placed only next to any controls that are marked as [Localizable]. Some contained
        /// controls like GridVIew/DataGrid Columns are not marked as [Localizable] yet
        /// the ASP.NET designer creates implicit resources for them anyway - these controls
        /// will not show icons.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="TopLevel"></param>
        public void AddLocalizationIcons(Control control,bool TopLevel)
        {
            if (control == null)
                control = this.Page;

            string IconUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), GlobalizationResources.INFO_ICON_LOCALIZE);

            if (TopLevel)
            {
                this.AddIconScriptFunctions();

                // *** Embed the IconUrl
                this.Page.ClientScript.RegisterStartupScript(this.GetType(),control.ID + "_iu",
                        "var _IconUrl = '" + IconUrl + "';\r\n",true);
            }
           
            // *** Don't localize ourselves
           if (control is wwDbResourceControl)
               return;


           // *** 'generated' controls don't have an ID and don't need to be localized
           if (control.ID != null)
           {
               // *** Read all public properties and search for Localizable Attribute
               PropertyInfo[] pi = control.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
               foreach (PropertyInfo property in pi)
               {
                   // *** Check for localizable Attribute on the property
                   object[] Attributes = property.GetCustomAttributes(typeof(LocalizableAttribute), true);
                   if (Attributes.Length < 1)
                       continue;
    
                   LocalizableProperty lp = new LocalizableProperty();
                   lp.ControlId = control.ID;

                   if (lp.ControlId.StartsWith("__"))
                       lp.ControlId = lp.ControlId.Substring(2);

                   lp.Property = property.Name;
                   lp.Value = property.GetValue(control, null) as string;

                   string ResourceSet = control.TemplateControl.AppRelativeVirtualPath.Replace("~/","");

                   //string Html = "<img src='"  + IconUrl +
                   //           "' onclick=\"OnLocalization('" + control.ID + "','" + ResourceSet + "','"+ lp.Property + "');\" style='margin-left:3px;border:none;' title='" + control.ID + "' >";

                   string Html = "<img src={0} onclick=\"OnLocalization('" + control.ID + "','" + ResourceSet + "','" + lp.Property + "');\" style='margin-left:3px;border:none;' title='" + control.ID + "' >";
                   Html = string.Format(Html.Replace("'", @"\'"), "' + _IconUrl + '");

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), control.ClientID + "_ahac",
                    string.Format("AddHtmlAfterControl('{0}','{1}');\r\n", control.ClientID,Html), true);
                    
                   break;
               }
           }

           // *** Now loop through all child controls
           foreach (Control ctl in control.Controls)
           {
               // *** Recurse into child controls
               if (ctl != null)
                   this.AddLocalizationIcons(ctl, false);
           }

        }
        

        /// <summary>
        /// Internal method to add the page level script routines
        /// that are used to inject the icons next to controls. These routines
        /// inject HTML into the DOM rather than adding controls in order
        /// to avoid problems with Controls.Add() and ASP.NET script expressions.
        /// </summary>
        private void AddIconScriptFunctions()
        {
            string ResourceSet = wwDbResourceConfiguration.Current.StripVirtualPath( this.Context.Request.Path );

            string Url = this.ResolveUrl(wwDbResourceConfiguration.Current.LocalizationFormWebPath) + 
                        "?CtlId=' + CtlId + '.' + Property  +" +
                        "'&ResourceSet=' + ResourceSet";
                        

            string Script = 
@"function OnLocalization(CtlId,ResourceSet,Property) 
{    
    if (CtlId == null || CtlId == """")
       return;
	
	var win =  window.open('" + Url + @",
	            ""_Localization"",
	            ""width=865,height=650,resizable=1,scrollbars=1"",""_Localization"");		    
    if (win.focus)
       win.focus();
}
function AddHtmlAfterControl(ControlId,HtmlMarkup)
{
    var Ctl = document.getElementById(ControlId);
    if (Ctl == null)
     return;
     
    var Insert = document.createElement('span');
    Insert.innerHTML = HtmlMarkup;

    var Sibling = Ctl.nextSibling;
    if (Sibling != null)
     Ctl.parentNode.insertBefore(Insert,Sibling);
    else
     Ctl.parentNode.appendChild(Insert);
}";

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"IconScript",Script,true );
        }	

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            
            // *** Make sure we use block mode instead of stock inline-block
            this.Style.Add(HtmlTextWriterStyle.Display, "block");

            this.Style.Add(HtmlTextWriterStyle.Margin, "10px");
            this.Controls.Add( new LiteralControl(string.Format("<b>{0}</b><hr/>",Resources.Resources.LocalizationOptions)) );
            
            Image img = new Image();

            if (this.Page != null)
                img.ImageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), GlobalizationResources.INFO_ICON_EDITRESOURCES);

            img.Style[HtmlTextWriterStyle.MarginRight] = "10px";
            this.Controls.Add(img);

            LinkButton but = this.btnEditResources;
            
            but.ID = "btnEditResources";
            but.Text = Resources.Resources.EditPageResources;
            //but.Attributes.Add("target", "LocalizationForm");
            but.Click += new EventHandler(OnEditResources);
            this.Controls.Add(but);
            
            this.Controls.Add( new LiteralControl("<br/>"));

            CheckBox cb = this.chkShowIcons;
            cb.ID = "chkShowIcons";
            cb.Text = Resources.Resources.ShowLocalizationIcons;
            cb.AutoPostBack = true;
            cb.Checked = this.ShowIcons;
            cb.CheckedChanged += new EventHandler(this.OnShowIcons);
            
            this.Controls.Add(cb);
        }

    }

    /// <summary>
    /// simple object that holds the value structure of each
    /// saved resource item on a form
    /// </summary>
    [Serializable]
    public class LocalizableProperty
    {
        public string ControlId = "";
        public string Property = "";
        public string Value = "";
    }


    /// <summary>
    /// Control designer used so we get a grey button display instead of the 
    /// default label display for the control.
    /// </summary>
    internal class wwDbResourceControlDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            StringWriter sb = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sb);
            
            wwDbResourceControl Ctl = new wwDbResourceControl();
            Ctl.RenderControl(writer);

            return sb.ToString();
        }
    }

    public enum ShowLocalizationStates
    {
        Show,
        DontShow,
        InheritFromProvider
    }
    
}
