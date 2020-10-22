/***************************************************************************************************************
 * 
 * wwDbSimpleResourceProvider
 * 
 * by Rick Strahl
 * (c) West Wind Technologies, 2006
 * 
 * 
 * this file contains a simplified ASP.NET Resource Provider that doesn't create a custom Resource Manager.
 * This implementation is much simpler than the full resource provider, but it's also not as integrated as
 * the full implementation. You can use this provider safely to serve resources, but for resource
 * editing and Visual Studio integration preferrably use the full provider.
 * 
 * This class shows how the Provider model works a little more clearly because this class is
 * self contained with the exception of the data access code and you can use this as a starting
 * point to build a custom provider.
 * 
 * This class uses wwDbResourceDataManager to retrieve and write resources in exactly two
 * places of the code. If you prefer you can replace these two locations with your own custom
 * Resource implementation. They are marked with:
 * 
 * // *** DEPENDENCY HERE
 * 
 * However, I would still recommend going with the full resource manager based implementation
 * because it works in any .NET application, not just ASP.NET. But a full resource manager
 * based implementation is much more complicated to create.
**************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Compilation;
using System.Collections;
using System.Resources;
using System.Globalization;
using System.Collections.Specialized;
using Westwind.Globlization.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Westwind.Globalization
{
    
/// <summary>
/// Provider factory that instantiates the individual provider. The provider
/// passes a 'classname' which is the ResourceSet id or how a resource is identified.
/// For global resources it's the name of hte resource file, for local resources
/// it's the full Web relative virtual path
/// </summary>
[DesignTimeResourceProviderFactoryAttribute(typeof(wwDbDesignTimeResourceProviderFactory))]
    public class wwDbSimpleResourceProviderFactory : ResourceProviderFactory
{
    /// <summary>
    /// ASP.NET sets up provides the global resource name which is the 
    /// resource ResX file (without any extensions). This will become
    /// our ResourceSet id. ie. Resource.resx becomes "Resources"
    /// </summary>
    /// <param name="classname"></param>
    /// <returns></returns>
    public override IResourceProvider CreateGlobalResourceProvider(string classname)
    {
        return new wwDbSimpleResourceProvider(null, classname);
    }

    /// <summary>
    /// ASP.NET passes the full page virtual path (/MyApp/subdir/test.aspx) wich is
    /// the effective ResourceSet id. We'll store only an application relative path
    /// (subdir/test.aspx) by stripping off the base path.
    /// </summary>
    /// <param name="virtualPath"></param>
    /// <returns></returns>
    public override IResourceProvider CreateLocalResourceProvider(string virtualPath)
    {
        // *** DEPENDENCY HERE: use Configuration class to strip off Virtual path leaving
        //                      just a page/control relative path for ResourceSet Ids

        // *** ASP.NET passes full virtual path: Strip out the virtual path 
        // *** leaving us just with app relative page/control path
        string ResourceSetName = wwDbResourceConfiguration.Current.StripVirtualPath(virtualPath);

        return new wwDbSimpleResourceProvider(null,ResourceSetName.ToLower());
    }
}

/// <summary>
/// Implementation of a very simple database Resource Provider. This implementation
/// is self contained and doesn't use a custom ResourceManager. Instead it
/// talks directly to the data resoure business layer (wwDbResourceDataManager).
/// 
/// Dependencies:
/// wwDbResourceDataManager
/// wwDbResourceConfiguration
/// 
/// You can replace those depencies (marked below in code) with your own data access
/// management. The two dependcies manage all data access as well as configuration 
/// management via web.config configuration section. It's easy to remove these
/// and instead use custom data access code of your choice.
/// 
/// </summary>
public class wwDbSimpleResourceProvider : IResourceProvider, IImplicitResourceProvider, IwwResourceProvider
{   
    /// <summary>
    /// Keep track of the 'className' passed by ASP.NET
    /// which is the ResourceSetId in the database.
    /// </summary>
    private string _ResourceSetName;        

    /// <summary>
    /// Cache for each culture of this ResourceSet. Once
    /// loaded we just cache the resources.
    /// </summary>
    private IDictionary _resourceCache;


    private wwDbSimpleResourceProvider()
    { }

    public wwDbSimpleResourceProvider(string virtualPath, string className)
    {
        _ResourceSetName = className;
        wwDbResourceConfiguration.LoadedProviders.Add(this);
    }

    /// <summary>
    /// Manages caching of the Resource Sets. Once loaded the values are loaded from the 
    /// cache only.
    /// </summary>
    /// <param name="cultureName"></param>
    /// <returns></returns>
    private IDictionary GetResourceCache(string cultureName)
    {
        if (cultureName == null)
            cultureName = "";

        if (this._resourceCache == null)
            this._resourceCache = new ListDictionary();

        IDictionary Resources = this._resourceCache[cultureName] as IDictionary;
        if (Resources == null)
        {
            // *** DEPENDENCY HERE (#1): Using wwDbResourceDataManager to retrieve resources

            // *** Use datamanager to retrieve the resource keys from the database
            wwDbResourceDataManager Data = new wwDbResourceDataManager();
            Resources = Data.GetResourceSet(cultureName as string, this._ResourceSetName);
            this._resourceCache[cultureName] = Resources;
        }

        return Resources;
    }   

    /// <summary>
    /// Clears out the resource cache which forces all resources to be reloaded from
    /// the database.
    /// 
    /// This is never actually called as far as I can tell
    /// </summary>
    public void ClearResourceCache()
    {
        this._resourceCache.Clear();
    }

    /// <summary>
    /// The main worker method that retrieves a resource key for a given culture
    /// from a ResourceSet.
    /// </summary>
    /// <param name="resourceKey"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    object IResourceProvider.GetObject(string ResourceKey, CultureInfo Culture)
    {
        string CultureName = null;
        if (Culture != null)
            CultureName = Culture.Name;
        else
            CultureName = CultureInfo.CurrentUICulture.Name;

        return this.GetObjectInternal(ResourceKey, CultureName);
    }

    /// <summary>
    /// Internal lookup method that handles retrieving a resource
    /// by its resource id and culture. Realistically this method
    /// is always called with the culture being null or empty
    /// but the routine handles resource fallback in case the
    /// code is manually called.
    /// </summary>
    /// <param name="ResourceKey"></param>
    /// <param name="CultureName"></param>
    /// <returns></returns>
    object GetObjectInternal(string ResourceKey, string CultureName)
    {
        IDictionary Resources = this.GetResourceCache(CultureName);
        
        object value = null;           
        if (Resources == null)
            value = null;
        else
            value = Resources[ResourceKey];
                        
        // *** If we're at a specific culture (en-Us) and there's no value fall back
        // *** to the generic culture (en)
        if (value == null && CultureName.Length > 3)
        {
            // *** try again with the 2 letter locale
            return GetObjectInternal(ResourceKey,CultureName.Substring(0,2) );
        }

        // *** If the value is still null get the invariant value
        if (value == null)
        {
            Resources = this.GetResourceCache("");
            if (Resources == null)
              value = null;
            else
              value = Resources[ResourceKey];
        }

        // *** If the value is still null and we're at the invariant culture
        // *** let's add a marker that the value is missing
        // *** this also allows the pre-compiler to work and never return null
        if (value == null && string.IsNullOrEmpty(CultureName))
        {
            // *** No entry there
            value = "";

            // *** DEPENDENCY HERE (#2): using wwDbResourceConfiguration and wwDbResourceDataManager to optionally
            //                           add missing resource keys

            // *** Add a key in the repository at least for the Invariant culture
            // *** Something's referencing but nothing's there
            if (wwDbResourceConfiguration.Current.AddMissingResources)
                new wwDbResourceDataManager().AddResource(ResourceKey, value.ToString(), "", this._ResourceSetName);                

        }

        return value;
    }

    /// <summary>
    /// The Resource Reader is used parse over the resource collection
    /// that the ResourceSet contains. It's basically an IEnumarable interface
    /// implementation and it's what's used to retrieve the actual keys
    /// </summary>
    public IResourceReader ResourceReader  // IResourceProvider.ResourceReader
    {
        get
        {
            if (this._ResourceReader != null)
                return this._ResourceReader as IResourceReader;

            this._ResourceReader = new wwDbSimpleResourceReader(GetResourceCache(null));
            return this._ResourceReader as IResourceReader;
        }
    }
    private wwDbSimpleResourceReader _ResourceReader = null;

    
#region IImplicitResourceProvider Members

    /// <summary>
    /// Called when an ASP.NET Page is compiled asking for a collection
    /// of keys that match a given control name (keyPrefix). This
    /// routine for example returns control.Text,control.ToolTip from the
    /// Resource collection if they exist when a request for "control"
    /// is made as the key prefix.
    /// </summary>
    /// <param name="keyPrefix"></param>
    /// <returns></returns>
    public ICollection GetImplicitResourceKeys(string keyPrefix)
    {
        List<ImplicitResourceKey> keys = new List<ImplicitResourceKey>();

        IDictionaryEnumerator Enumerator = this.ResourceReader.GetEnumerator();
        if (Enumerator == null)
            return keys; // Cannot return null!

        foreach (DictionaryEntry dictentry in this.ResourceReader)
        {
            string key = (string)dictentry.Key;

            if (key.StartsWith(keyPrefix + ".", StringComparison.InvariantCultureIgnoreCase) == true)
            {
                string keyproperty = String.Empty;
                if (key.Length > (keyPrefix.Length + 1))
                {
                    int pos = key.IndexOf('.');
                    if ((pos > 0) && (pos == keyPrefix.Length))
                    {
                        keyproperty = key.Substring(pos + 1);
                        if (String.IsNullOrEmpty(keyproperty) == false)
                        {
                            //Debug.WriteLine("Adding Implicit Key: " + keyPrefix + " - " + keyproperty);
                            ImplicitResourceKey implicitkey = new ImplicitResourceKey(String.Empty, keyPrefix, keyproperty);
                            keys.Add(implicitkey);
                        }
                    }
                }
            }
        }
        return keys;
    }    


    /// <summary>
    /// Returns an Implicit key value from the ResourceSet. 
    /// Note this method is called only if a ResourceKey was found in the
    /// ResourceSet at load time. If a resource cannot be located this
    /// method is never called to retrieve it. IOW, GetImplicitResourceKeys
    /// determines which keys are actually retrievable.
    /// 
    /// This method simply parses the Implicit key and then retrieves
    /// the value using standard GetObject logic for the ResourceID.
    /// </summary>
    /// <param name="implicitKey"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object GetObject(ImplicitResourceKey implicitKey, CultureInfo culture)
    {
        string ResourceKey = ConstructFullKey(implicitKey);

        string CultureName = null;
        if (culture != null)
            CultureName = culture.Name;
        else
            CultureName = CultureInfo.CurrentUICulture.Name;

        return this.GetObjectInternal(ResourceKey, CultureName);
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
        {
            text = entry.Filter + ":" + text;
        }
        return text;
    }
    #endregion
}


/// <summary>
/// Required simple IResourceReader implementation. A ResourceReader
/// is little more than an Enumeration interface that allows 
/// parsing through the Resources in a Resource Set which
/// is passed in the constructor.
/// </summary>
public class wwDbSimpleResourceReader : IResourceReader
{
    private IDictionary _resources;

    public wwDbSimpleResourceReader(IDictionary resources)
    {
        _resources = resources;
    }
    IDictionaryEnumerator IResourceReader.GetEnumerator()
    {
        return _resources.GetEnumerator();
    }
    void IResourceReader.Close()
    {
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _resources.GetEnumerator();
    }
    void IDisposable.Dispose()
    {
    }
}



}