using System;
using System.Web;
using System.Web.UI.Design;
using System.Configuration;
using System.Web.Configuration;
using System.ComponentModel;
using System.Web.Compilation;
using System.Collections.Generic;

namespace Westwind.Globalization
{
    /// <summary>
    /// The configuration class that is used to configure the Resource Provider.
    /// This class contains various configuration settings that the provider requires
    /// to operate both at design time and runtime.
    /// 
    /// The application uses the static Current property to access the actual
    /// configuration settings object. By default it reads the configuration settings
    /// from web.config (at runtime). You can override this behavior by creating your
    /// own configuration object and assigning it to the wwDbResourceConfiguration.Current property.
    /// </summary>
    public class wwDbResourceConfiguration
    {
        /// <summary>
        /// A global instance of the current configuration. By default this instance reads its
        /// configuration values from web.config at runtime, but it can be overridden to
        /// assign specific values or completely replace this object. 
        /// 
        /// NOTE: Any assignment made to this property should be made at Application_Start
        /// or other 'application initialization' event so that these settings are applied
        /// BEFORE the resource provider is used for the first time.
        /// </summary>
        public static wwDbResourceConfiguration Current = null;

        /// <summary>
        /// Static constructor for the Current property - guarantees this
        /// code fires exactly once giving us a singleton instance
        /// of the configuration object.
        /// </summary>
        static wwDbResourceConfiguration()
        {
            Current = new wwDbResourceConfiguration(true);
        }

        /// <summary>
        /// Database connection string to the resource data.
        /// 
        /// The string can either be a full connection string or an entry in the 
        /// ConnectionStrings section of web.config.
        /// <seealso>Class wwDbResource
        /// Compiling Your Applications with the Provider</seealso>
        /// </summary>
        public string ConnectionString
        {
            get 
            {
                // *** If no = in the string assume it's a ConnectionStrings entry instead
                if (!_ConnectionString.Contains("="))
                {
                    try
                    {
                        return ConfigurationManager.ConnectionStrings[_ConnectionString].ConnectionString;
                    }
                    catch { }
                }
                return _ConnectionString; 
            }
            set { _ConnectionString = value; }
        }
        private string _ConnectionString = "";

        /// <summary>
        /// Database table name used in the database
        /// </summary>
        public string ResourceTableName
        {
            get { return _ResourceTableName; }
            set { _ResourceTableName = value; }
        }
        private string _ResourceTableName = "Localizations";

        /// <summary>
        /// The virtual path for the Web application. This value is used at design time.
        /// </summary>
        public string DesignTimeVirtualPath
        {
            get { return _DesignTimeVirtualPath; }
            set { _DesignTimeVirtualPath = value; }
        }
        private string _DesignTimeVirtualPath = "";

        /// <summary>
        /// Determines whether the wwDbResourceControl shows its localization options on the
        /// page. 
        /// </summary>
        public bool ShowLocalizationControlOptions
        {
            get { return _ShowLocalizationOptions; }
            set { _ShowLocalizationOptions = value; }
        }
        private bool _ShowLocalizationOptions = false;

        /// <summary>
        /// Determines whether page controls show icons when a 
        /// wwDbResourceControl is active. Note requires that ShowLocalizationControlOptions
        /// is true as well.
        /// </summary>
        public bool ShowControlIcons
        {
            get { return _ShowControlIcons; }
            set { _ShowControlIcons = value; }
        }
        private bool _ShowControlIcons = false;



        /// <summary>
        /// Determines the location of the Localization form in a Web relative path.
        /// This form is popped up when clicking on Edit Resources in the 
        /// wwDbResourceControl
        /// </summary>        
        public string LocalizationFormWebPath
        {
            get { return _LocalizationFormWebPath; }
            set { _LocalizationFormWebPath = value; }
        }
        private string _LocalizationFormWebPath = "~/LocalizationAdmin/Default.aspx";

        /// <summary>
        /// Determines whether any resources that are not found are automatically
        /// added to the resource file.
        /// 
        /// Note only applies to the Invariant culture.
        /// </summary>
        public bool AddMissingResources
        {
            get { return _AddMissingResources; }
            set { _AddMissingResources = value; }
        }
        private bool _AddMissingResources = true;

        /// <summary>
        /// Determines whether generated Resource names use the same syntax
        /// as VS.Net uses. Defaults to false, which uses simple control
        /// name syntax (no ResourceX value) if possible. The dfeault value
        /// is shown without a number and numbers are only used on duplication.
        /// </summary>
        public bool UseVsNetResourceNaming
        {
            get { return _UseVsNetResourceNaming; }
            set { _UseVsNetResourceNaming = value; }
        }
        private bool _UseVsNetResourceNaming = false;


        /// <summary>
        /// Path and Name space of an optionally generated strongly typed resource
        /// which is created when exporting to ResX resources.
        /// 
        /// Leave this value blank if you don't want a strongly typed resource class
        /// generated for you.
        /// 
        /// Otherwise format is: (File Path,Namespace)
        /// ~/App_Code/Resources.cs,AppResources
        /// </summary>
        public string StronglyTypedGlobalResource
        {
            get { return _StronglyTypedGlobalResource; }
            set { _StronglyTypedGlobalResource = value; }
        }
        private string _StronglyTypedGlobalResource = "~/App_Code/Resources.cs,AppResources";

        
        
        /// <summary>
        /// Base constructor that doesn't do anything to the default values.
        /// </summary>
        public wwDbResourceConfiguration()
        {
        }

        /// <summary>
        /// Default constructor used to read the configuration section to retrieve its values
        /// on startup.
        /// </summary>
        /// <param name="ReadConfigurationSection"></param>
        public wwDbResourceConfiguration(bool ReadConfigurationSection)
        {
            if (ReadConfigurationSection)
                this.ReadConfigurationSection();
        }


        /// <summary>
        /// Reads the wwDbResourceProvider Configuration Section and assigns the values 
        /// to the properties of this class
        /// </summary>
        /// <returns></returns>
        public bool ReadConfigurationSection()
        {
            object TSection = WebConfigurationManager.GetWebApplicationSection("wwDbResourceProvider");
            if (TSection == null)
                return false;

            wwDbResourceProviderSection Section = TSection as wwDbResourceProviderSection;
            this.ReadSectionValues(Section);

            return true;
        }

        /// <summary>
        /// Handle design time access to the configuration settings - used for the 
        /// wwDbDesignTimeResourceProvider - when loaded we re-read the settings
        /// </summary>
        /// <param name="serviceHost"></param>
        public bool ReadDesignTimeConfiguration(IServiceProvider serviceProvider )
        {
            IWebApplication webApp = serviceProvider.GetService(typeof(IWebApplication)) as IWebApplication;

            // *** Can't get an application instance - can only exit
            if (webApp == null)
                return false;

            object TSection = webApp.OpenWebConfiguration(true).GetSection("wwDbResourceProvider");
            if (TSection == null)
                return false;

            wwDbResourceProviderSection Section = TSection as wwDbResourceProviderSection;
            ReadSectionValues(Section);

            // *** If the connection string doesn't contain = then it's
            // *** a ConnectionString key from .config. This is handled in
            // *** in the propertyGet of the resource configration, but it uses
            // *** ConfigurationManager which is not available at design time
            // ***  So we have to duplicate the code here using the WebConfiguration.
            if (!this.ConnectionString.Contains("="))
            {
                try
                {
                    string Conn = webApp.OpenWebConfiguration(true).ConnectionStrings.ConnectionStrings[this.ConnectionString].ConnectionString;
                    this.ConnectionString = Conn;
                }
                catch { }                
            }
                
            return true;
        }

        /// <summary>
        /// Reads the actual section values
        /// </summary>
        /// <param name="Section"></param>
        private void ReadSectionValues(wwDbResourceProviderSection Section)
        {
            this.ConnectionString = Section.ConnectionString;
            this.ResourceTableName = Section.ResourceTableName;
            this.DesignTimeVirtualPath = Section.DesignTimeVirtualPath;
            this.LocalizationFormWebPath = Section.LocalizationFormWebPath;
            this.ShowLocalizationControlOptions = Section.ShowLocalizationControlOptions;
            this.ShowControlIcons = Section.ShowControlIcons;
            this.AddMissingResources = Section.AddMissingResources;
            this.StronglyTypedGlobalResource = Section.StronglyTypedGlobalResource;
        }


        /// <summary>
        /// Used to strip of the virtual path of Local ResourceSet paths.
        /// </summary>
        /// <param name="FullVirtualPath"></param>
        /// <returns></returns>
        public string StripVirtualPath(string FullVirtualPath)
        {            
            string StripVirtual = wwDbResourceConfiguration.Current.DesignTimeVirtualPath;
            if (HttpContext.Current != null)
                StripVirtual = HttpContext.Current.Request.ApplicationPath;

            if (!StripVirtual.EndsWith("/"))
                StripVirtual = StripVirtual.ToLower() + "/";

            // *** Root Webs are a special case
            if (StripVirtual == "/" && FullVirtualPath.StartsWith("/"))
                return FullVirtualPath.TrimStart('/');  // leave just the relative path

            // *** Stript out the virtual path leaving us just with page
            return FullVirtualPath.ToLower().Replace(StripVirtual, "");
        }

#region Allow for provider unloading
        /// <summary>
        /// Keep track of loaded providers so we can unload them
        /// </summary>
        internal static List<IwwResourceProvider> LoadedProviders = new List<IwwResourceProvider>();

        /// <summary>
        /// This static method clears all resources from the loaded Resource Providers 
        /// and forces them to be reloaded the next time they are requested.
        /// 
        /// Use this method after you've edited resources in the database and you want 
        /// to refresh the UI to show the newly changed values.
        /// 
        /// This method works by internally tracking all the loaded ResourceProvider 
        /// instances and calling the IwwResourceProvider.ClearResourceCache() method 
        /// on each of the provider instances. This method is called by the Resource 
        /// Administration form when you explicitly click the Reload Resources button.
        /// <seealso>Class wwDbResourceConfiguration</seealso>
        /// </summary>
        public static void ClearResourceCache()
        {
            foreach (IwwResourceProvider provider in LoadedProviders)
            {
                provider.ClearResourceCache();
            }                
        }
#endregion

    }

    /// <summary>
    /// This is the resource provider section that mimics the settings stored in wwDbResourceConfiguration object.
    /// </summary>
    public class wwDbResourceProviderSection : ConfigurationSection
    {
        [ConfigurationProperty("connectionString",DefaultValue=""),
        Description("The connection string used to connect to the db Resource provider")]       
        public string ConnectionString
        {
            get { return this["connectionString"] as string; }
            set { this["connectionString"]  = value; }
        }
        

        [ConfigurationProperty("resourceTableName",DefaultValue="Localizations"),
        Description("The name of the table used in the Connection String database for localizations.")]
        public string ResourceTableName
        {
            get { return this["resourceTableName"] as string; }
            set { this["resourceTableName"] = value; }
        }
        
        [ConfigurationProperty("designTimeVirtualPath",DefaultValue=""),
        Description("The virtual path to the application. This value is used at design time and should be in the format of: /MyVirtual")]
        public string DesignTimeVirtualPath
        {
            get { return this["designTimeVirtualPath"] as string; }
            set { this["designTimeVirtualPath"] = value; }
        }

        

        [Description("Determines whether the wwDbResourceControl shows its localization options on the page."),
         ConfigurationProperty("showLocalizationControlOptions",DefaultValue="false")]         
        public bool ShowLocalizationControlOptions
        {
            get { return (bool) this["showLocalizationControlOptions"]; }
            set { this["showLocalizationControlOptions"] = value; }
        }

        [Description("Determines whether the wwDbResourceControl shows icons next to each control of a page to jump to the localization page."),
         ConfigurationProperty("showControlIcons", DefaultValue = "false")]
        public bool ShowControlIcons
        {
            get { return (bool)this["showControlIcons"]; }
            set { this["showControlIcons"] = value; }
        }


        [Description("The web path to the administration localization form used to display and edit resources."),
         ConfigurationProperty("localizationFormWebPath",DefaultValue="~/admin/localizeform.aspx")]         
        public string LocalizationFormWebPath
        {
            get { return this["localizationFormWebPath"] as string; }
            set { this["localizationFormWebPath"] = value; }
        }

        [Description("Determines whether any missing resources are automatically added to the Invariant culture. Defaults to true"),
         ConfigurationProperty("addMissingResources", DefaultValue = true)]         
        public bool AddMissingResources
        {
            get { return (bool)this["addMissingResources"]; }
            set { this["addMissingResources"] = value; }
        }

        [Description("If set to true uses Visual Studio naming for generate resource names that have a ResourceX prefix. The default doesn't generate the Resource text and omits the number if possible"),
         ConfigurationProperty("useVsNetResourceNaming", DefaultValue = false)]
        public bool UseVsNetResourceNaming
        {
            get { return (bool)this["useVsNetResourceNaming"]; }
            set { this["useVsNetResourceNaming"] = value; }
        }

        [Description("Determines whether a strongly typed resource is created when database resources are exported to a ResX file"),
         ConfigurationProperty("stronglyTypedGlobalResource", DefaultValue = "~/App_Code/Resources.cs,AppResources")]
        public string StronglyTypedGlobalResource
        {
            get { return (string)this["stronglyTypedGlobalResource"]; }
            set { this["stronglyTypedGlobalResource"] = value; }
        }       

        public wwDbResourceProviderSection(string ConnectionString, string ResourceTableName, string DesignTimeVirtualPath)
        {
            this.ConnectionString = ConnectionString;
            this.DesignTimeVirtualPath = DesignTimeVirtualPath;
            this.ResourceTableName = ResourceTableName;
        }

        public wwDbResourceProviderSection()
        { 
           
        }

    }
}
