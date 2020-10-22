/*
 **************************************************************
 * wwDbReourceManager Class
 **************************************************************
 *  Author: Rick Strahl 
 *          (c) West Wind Technologies
 *          http://www.west-wind.com/
 * 
 * Created: 10/10/2006
 * 
 * credits:
 **************************************************************  
*/

using System;
using System.Collections.Generic;
using System.Collections;
using System.Resources;
using System.Web.Compilation;
using System.Globalization;


namespace Westwind.Globalization
{

    public interface IwwResourceProvider
    {
        /// <summary>
        /// Interface method used to force providers to register themselves
        /// with wwDbResourceConfiguration.
        /// </summary>
        void ClearResourceCache();
    }


    /// <summary>
    /// Provider Factory class that needs to be set in web.config in order for ASP.NET to instantiate
    /// this class for all resource related tasks.
    /// </summary>
    [DesignTimeResourceProviderFactoryAttribute(typeof(wwDbDesignTimeResourceProviderFactory))]
    public class wwDbResourceProviderFactory : ResourceProviderFactory
    {
        /// <summary>
        /// Core Factory method that returns an instance of our wwDbResourceProvider 
        /// database Resource provider for Global Resources. This method gets
        /// passed simple a ResourceSet which is equivalent to a Resource file in
        /// Resx and here maps to the ResourceSet id in the database.
        /// </summary>
        /// <param name="classname"></param>
        /// <returns></returns>
        public override IResourceProvider CreateGlobalResourceProvider(string classname)
        {
            return new wwDbResourceProvider(null, classname);
        }

        /// <summary>
        /// Creates a local resource provider for a given Page or Template Resource.
        /// 
        /// We'll create local resources by application relative names. This routine
        /// gets passed a full virtual path to the page or template control and we'll
        /// strip off the virtual and use only the virtual relative path. 
        /// 
        /// So: /myapp/test.aspx becomes test.aspx and
        ///     /myapp/subdir/test.aspx becomes subdir/test.aspx
        /// 
        /// for our ResourceSet naming of local resources. The provider is 
        /// created with this ResourceSet name.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public override IResourceProvider CreateLocalResourceProvider(string virtualPath)
        {
            // *** Strip out the virtual path leaving us just with page
            string ResourceSetName = wwDbResourceConfiguration.Current.StripVirtualPath(virtualPath);

            // *** Create Provider with the ResourceSetname
            return new wwDbResourceProvider(ResourceSetName.ToLower(), ResourceSetName.ToLower());
        }
    }

    /// <summary>
    /// The wwDbResourceProvider class is an ASP.NET Resource Provider implementation
    /// that retrieves its resources from a database. It works in conjunction with a
    /// wwDbResourceManager object and so uses standard .NET Resource mechanisms to 
    /// retrieve its data. The provider should be fairly efficient and other than
    /// initial load time standard .NET resource caching is used to hold resource sets
    /// in memory.
    /// 
    /// The Resource Provider class provides the base interface for accessing resources.
    /// This provider interface handles loading resources, caching them (using standard
    /// Resource Manager functionality) and allowing access to resources via GetObject.
    /// 
    /// This provider supports global and local resources, explicit expressions
    /// as well as implicit expressions (IImplicitResourceProvider).
    /// 
    /// There's also a design time implementation to provide Generate LocalResources
    /// support from ASP.NET Web Form designer.
    /// </summary>
    public class wwDbResourceProvider : IResourceProvider, IImplicitResourceProvider , IwwResourceProvider
    {
        /// <summary>
        /// not actually used
        /// </summary>
        //string _virtualPath;

        /// <summary>
        /// 
        /// </summary>
        string _className;

        private wwDbResourceProvider()
        { }

        /// <summary>
        /// Default constructor - only captures the parameter values
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="classname"></param>
        public wwDbResourceProvider(string virtualPath, string classname)
        { 
            //  _virtualPath = virtualPath;
            _className = classname;
            wwDbResourceConfiguration.LoadedProviders.Add(this);
        }

        /// <summary>
        /// IResourceProvider interface - required to provide an instance to an
        /// ResourceManager object.
        /// 
        /// Note that the resource manager is not tied to a specific culture by
        /// default. The Provider uses the UiCulture without explicitly passing
        /// culture info.
        /// </summary>
        public wwDbResourceManager ResourceManager
        {
            get
            {
                if (this._ResourceManager == null)
                {
                    wwDbResourceManager manager = new wwDbResourceManager(this._className);
                    manager.IgnoreCase = true;
                    this._ResourceManager = manager;                    
                }
                return _ResourceManager;
            }
        }
        private wwDbResourceManager _ResourceManager = null;


        public void ClearResourceCache()
        {
            // *** Just force the resource manager to be completely reloaded
            this.ResourceManager.ReleaseAllResources();
        }

        /// <summary>
        /// The main method to retrieve a specific resource key. The provider
        /// internally handles resource fallback based on the ResourceSet implementation.
        /// </summary>
        /// <param name="ResourceKey"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object IResourceProvider.GetObject(string ResourceKey, CultureInfo culture)
        {
            
            object value = this.ResourceManager.GetObject(ResourceKey, culture);

            // *** If the value is still null and we're at the invariant culture
            // *** let's add a marker that the value is missing
            // *** this also allows the pre-compiler to work and never return null
            if (value == null && (culture == null || culture == CultureInfo.InvariantCulture) )
            {
                // *** No entry there
                value =  "";

                if (wwDbResourceConfiguration.Current.AddMissingResources)
                {
                    // *** Add invariant resource
                    wwDbResourceDataManager Data = new wwDbResourceDataManager();
                    if (!Data.ResourceExists(ResourceKey,"",this._className))
                        Data.UpdateOrAdd(ResourceKey,"*** Missing","",this._className);
                }                
            }

            return value;
        }


        /// <summary>
        /// Required instance of the ResourceReader for this provider. Part of
        /// the IResourceProvider interface. The reader is responsible for feeding
        /// the Resource data from a ResourceSet. The interface basically walks
        /// an enumerable interface by ResourceId.
        /// </summary>
        public IResourceReader ResourceReader
        {
            get
            {
                if (this._ResourceReader == null)
                    this._ResourceReader = new wwDbResourceReader(this._className, CultureInfo.InvariantCulture);

                return this._ResourceReader;
            }
        }
        private wwDbResourceReader _ResourceReader = null;
       

        #region IImplicitResourceProvider Members and helpers


        /// <summary>
        /// Implicit ResourceKey GetMethod that is called off meta:Resource key values.
        /// Note that if a value is missing at compile time this method is never called
        /// at runtime as the key isn't added to the Implicit key dictionary
        /// </summary>
        /// <param name="implicitKey"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object IImplicitResourceProvider.GetObject(ImplicitResourceKey implicitKey, CultureInfo culture)
        {
            return this.ResourceManager.GetObject(ConstructFullKey(implicitKey), culture);
        }

        /// <summary>
        /// Routine that generates a full resource key string from
        /// an Implicit Resource Key value
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        private static string ConstructFullKey(ImplicitResourceKey entry)
        {
            string text = entry.KeyPrefix + "." + entry.Property;
            if (entry.Filter.Length > 0)
                text = entry.Filter + ":" + text;

            return text;
        }

        
        /// <summary>
        /// Retrieves all keys for from the resource store that match the given key prefix.
        /// The value here is generally a property name (or resourceId) and this routine
        /// retrieves all matching property values.
        /// 
        /// So, lnkSubmit as the prefix finds lnkSubmit.Text, lnkSubmit.ToolTip and
        /// returns both of those keys.
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <returns></returns>
        ICollection IImplicitResourceProvider.GetImplicitResourceKeys(string keyPrefix)
        {
            List<ImplicitResourceKey> keys = new List<ImplicitResourceKey>(); 

            foreach (DictionaryEntry dictentry in this.ResourceReader)
            { 
                string key = (string)dictentry.Key;

                if (key.StartsWith(keyPrefix + ".", StringComparison.InvariantCultureIgnoreCase) == true)
                {
                    string keyproperty = String.Empty;
                    if (key.Length > (keyPrefix.Length + 1)) 
                    { 
                        int pos = key.IndexOf('.');
                        if ((pos > 0) && (pos  == keyPrefix.Length))
                        {
                            keyproperty = key.Substring(pos + 1);
                            if (String.IsNullOrEmpty(keyproperty) == false)
                            {
                                ImplicitResourceKey implicitkey = new ImplicitResourceKey(String.Empty, keyPrefix, keyproperty);
                                keys.Add(implicitkey);
                            }
                        }
                    }
                } 
            }
            return keys;
        }  
        #endregion

    }

}
