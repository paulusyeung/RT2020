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
 * based in part on code provided in:
 * ----------------------------------
 * .NET Internationalization
 *      Addison Wesley Books
 *      by Guy Smith Ferrier
 * 
 **************************************************************  
*/

using System;
using System.Collections.Generic;
using System.Resources;
using System.Globalization;
using System.Collections;
using System.Reflection;

namespace Westwind.Globalization
{
    /// <summary>
    /// This class provides a databased implementation of a ResourceManager.
    /// 
    /// A ResourceManager holds each of the ResourceSets for a given group
    /// of resources. In ResX files a group is a file group wiht the same name
    /// (ie. Resources.resx, Resources.en.resx, Resources.de.resx). In this
    /// database driven provider the group is determined by the ResourceSet
    /// and the LocaleId as stored in the database. This class is instantiated
    /// and gets passed both of these values for identity.
    /// 
    /// An application can have many ResourceManagers - one for each localized
    /// page and one for each global resource with each hold multiple resourcesets
    /// for each of the locale's that are part of that resourceSet.
    /// 
    /// This class implements only the GetInternalResourceSet method to
    /// provide the ResourceSet from a database. It also implements all the
    /// base class constructors and captures only the BaseName which 
    /// is the name of the ResourceSet (ie. a global or local resource group)
    /// 
    /// Dependencies:
    /// wwDbResourceDataManager for data access
    /// wwDbResourceConfiguration which holds and reads config settings
    /// 
    /// wwDbResourceSet
    /// wwDbResourceReader
    /// </summary>
    public class wwDbResourceManager : ResourceManager
    {
        
        // *** Duplicate the Resource Manager Constructors below
        // *** Key feature of these overrides is to set up the BaseName
        // *** which is the name of the resource set (either a local
        // *** or global resource. Each ResourceManager controls one set
        // *** of resources (global or local) and manages the ResourceSet
        // *** for each of cultures that are part of that ResourceSet

        /// <summary> 
        /// Constructs a DbResourceManager object
        /// </summary>
        /// <param name="baseName">The qualified base name which the resources represent</param>
        public wwDbResourceManager(string baseName)
		{
			Initialize(baseName, null);
		}

        /// <summary>
        /// Constructs a DbResourceManager object. Match base constructors.
        /// </summary>
        /// <param name="resourceType">The Type for which resources should be read/written</param>
		public wwDbResourceManager(Type resourceType)
		{
			this.Initialize(resourceType.Name, resourceType.Assembly);
		}
        public wwDbResourceManager(string baseName, Assembly assembly)
        {
            this.Initialize( baseName,null);
        }
        public wwDbResourceManager(string baseName, Assembly assembly, Type usingResourceSet)
        {
            this.Initialize(baseName, null);
        }

        /// <summary>
        /// Core Configuration method that sets up the ResourceManager. For this 
        /// implementation we only need the baseName which is the ResourceSet id
        /// (ie. the local or global resource set name) and the assembly name is
        /// simply ignored.
        /// 
        /// This method essentially sets up the ResourceManager and holds all
        /// of the culture specific resource sets for a single ResourceSet. With
        /// ResX files each set is a file - in the database a ResourceSet is a group
        /// with the same ResourceSet Id.
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="assembly"></param>
        protected void Initialize(string baseName, Assembly assembly)
        {
            this.BaseNameField = baseName;

            // *** ResourceSets contains a set of resources for each locale
            this.ResourceSets = new Hashtable();
        }


        /// <summary>
        /// This is the only method that needs to be overridden as long as we
        /// provide implementations for the ResourceSet/ResourceReader/ResourceWriter
        /// </summary>
        /// <param name="Culture"></param>
        /// <param name="createIfNotExists"></param>
        /// <param name="tryParents"></param>
        /// <returns></returns>
        protected override ResourceSet InternalGetResourceSet(CultureInfo Culture, bool createIfNotExists, bool tryParents)
        {             
            // *** retrieved cached instance
            if (this.ResourceSets.Contains(Culture.Name))
                return this.ResourceSets[Culture.Name] as ResourceSet;

            // *** Otherwise create a new instance, load it and return it
            wwDbResourceSet rs = new wwDbResourceSet(this.BaseNameField, Culture);
            this.ResourceSets.Add(Culture.Name, rs);

            return rs;
        }

        public override void ReleaseAllResources()
        {
            base.ReleaseAllResources();
            this.ResourceSets.Clear();
        }

#if false   // GetObject implementations to retrieve values - not required but useful to see operation
        /// <summary>
        /// Core worker method on the manager that returns resource. This
        /// override returns the resource for the currently active UICulture
        /// for this manager/resource set.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override object GetObject(string name)
        {
            object Value = base.GetObject(name);
            return Value;
        }

        /// <summary>
        /// Core worker method that returnsa  resource value for a
        /// given culture from the this resourcemanager/resourceset.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object GetObject(string name, CultureInfo culture)
        {
            object Value = base.GetObject(name, culture);
            return Value;
        }
#endif
    } 

    /// <summary>
    /// wwDbResourceSet is the ResourceSet implementation for the database driven
    /// Resource manager. A ResourceSet is a IEnumerable list of all resources
    /// in set for a given specific culture. Each culture has a separate resource
    /// set. The ResourceManager caches the ResourceSets and figures out how to
    /// return the resources from this ResourceSet using the IEnumerable interface.
    /// 
    /// The ResourceSet doesn't do any work - it serves merely as a coordinator. The
    /// actual reading of resources is managed by the ResourceReader which eventually
    /// calls into the database to retrieve the resources for the ResourceSet.
    /// </summary>
    public class wwDbResourceSet : ResourceSet
    {
        string _BaseName = null;
        CultureInfo _Culture = null;

        /// <summary>
        /// Core constructore. Gets passed a baseName (which is the ResourceSet Id - 
        /// either a local or global resource group) and a culture. 
        /// 
        /// This constructor basically creates a new ResourceReader and uses that
        /// reader's IEnumerable interface to provide access to the underlying
        /// resource data.
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="culture"></param>
        public wwDbResourceSet(string baseName, CultureInfo culture)
            : base( new wwDbResourceReader(baseName, culture) )
        {
            this._BaseName = baseName;
            this._Culture = culture;
        }

        /// <summary>
        /// Marker method that provides the type used for the ResourceReader.
        /// Not used.
        /// </summary>
        /// <returns></returns>
        public override Type GetDefaultReader()
        {
            return typeof(wwDbResourceReader);
        }

        /// <summary>
        /// Marker method that provides the type used for a ResourceWriter.
        /// Not used.
        /// </summary>
        /// <returns></returns>
        public override Type GetDefaultWriter()
        {
            return typeof(wwDbResourceWriter);
        }

#if false  // Factory methods for ResourceReader and ResourceWriter objects - not used
        /// <summary>
        /// Custom implementations that allow calling code to get an instance of 
        /// ResourceReader.
        /// </summary>
        /// <returns>An IResourceReader to read the resources</returns>
        public IResourceReader CreateDefaultReader()
        {
            return new wwDbResourceReader(this._BaseName,this._Culture);
        }

        /// <summary>
        /// CreateDefaultWriter creates an IResourceWriter to write the resources
        /// </summary>
        /// <returns>An IResourceWriter to write the resources</returns>
        public IResourceWriter CreateDefaultWriter()
        {
            return new wwDbResourceWriter(this._BaseName,this._Culture);
        }
#endif
    }

    /// <summary>
    /// wwDbResourceReader is an IResourceReader for reading resources from a database.
    /// The ResourceReader is the actual Resource component that accesses the underlying datasource
    /// to retrieve the resource data. 
    /// 
    /// This databased manager uses the wwDbResourceDataManager to query the database and retrieve
    /// a list of resources for a given baseName (ResourceSet) and Culture and returns that result
    /// as an IEnumerable list (via a HashTable). This process - other than the data access - results
    /// in the same structures as resources read from ResX files.
    /// </summary>
    public class wwDbResourceReader : IResourceReader
    {
        /// <summary>
        /// Name of the ResourceSet
        /// </summary>
        private string baseNameField;

        /// <summary>
        /// The culture that applies to to this reader
        /// </summary>
        private CultureInfo cultureInfo;

        /// <summary>
        /// Cached instance of items. The ResourceManager will often be called repeatedly
        /// for the same data so this caching avoids multiple repetitive calls to the
        /// database.
        /// </summary>
        IDictionary Items = null;

        /// <summary>
        /// Core constructor for wwDbResourceReader. This ctor is passed the name of the
        /// ResourceSet and a culture that is to be loaded.
        /// </summary>
        /// <param name="baseNameField">The base name of the resource reader</param>
        /// <param name="cultureInfo">The CultureInfo identifying the culture of the resources to be read</param>
        public wwDbResourceReader(string baseNameField, CultureInfo cultureInfo)
        {
            this.baseNameField = baseNameField;
            this.cultureInfo = cultureInfo; 
        }

        /// <summary>
        /// This is the worker method responsible for actually retrieving resources from the resource
        /// store. This method goes out queries the database by asking for a specific ResourceSet and 
        /// Culture and it returns a Hashtable (as IEnumerable) to use as a ResourceSet.
        /// 
        /// The ResourceSet manages access to resources via IEnumerable access which is ultimately used
        /// to return resources to the front end.
        /// 
        /// Resources are read once and cached into an internal Items field. A ResourceReader instance
        /// is specific to a ResourceSet and Culture combination so there should never be a need to
        /// reload this data, except when explicitly clearing the reader/resourceset (in which case
        /// Items can be set to null via ClearResources()).
        /// </summary>
        /// <returns>An IDictionaryEnumerator of the resources for this reader</returns>
        public IDictionaryEnumerator GetEnumerator()
        {
            if (this.Items != null)
                return this.Items.GetEnumerator();

            // *** DEPENDENCY HERE
            // *** Here's the only place we really access the database and return
            // *** a specific ResourceSet for a given ResourceSet Id and Culture
            wwDbResourceDataManager Manager = new wwDbResourceDataManager();
            this.Items = Manager.GetResourceSet(this.cultureInfo.Name, this.baseNameField);             
            return this.Items.GetEnumerator();
        }


        /// <summary>
        /// Returns an IEnumerator of the resources for this reader. Simply returns 
        /// the IDictionary enumerator from the overload.
        /// </summary>
        /// <returns>An IEnumerator of the resources for this reader</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        /// <summary>
        /// Closes the resource reader after releasing any resources associated with it
        /// </summary>
        public void Close()
        {
            this.Dispose();
        }
        
        /// <summary>
        /// Releases all resources used by the object. Ultimately this is called
        /// by ResourceManager.ReleaseAllResources which calls on the ResourceSet
        /// and then down into the reader to close its resources. 
        /// 
        /// This code cleans up the internally created dictionary which in turn
        /// comes from a Hashtable.
        /// </summary>
        public void Dispose()
        {
            // *** Clear the Resource Items
            this.Items = null;
        }

    }

    // *** wwDbResourceWriter is not used, but fully implemented here
    // *** This interface is too limited to be really useful for a sophisticated
    // *** Resource Provider so the admin interfaces talk directly to the database
    // *** instead.
    //
    // *** The ResourceWriter would be more useful if it were directly tied to a
    // *** ResourceManager, but this is not the case.
    // *** Provided mainly for completeness here.


    /// <summary>
    /// DbResourceWriter is an IResourceWriter for writing resources to a database
    /// </summary>
    public class wwDbResourceWriter : IResourceWriter
    {
        private string baseName;
        private CultureInfo cultureInfo;

        /// <summary>
        /// List of resources we want to add
        /// </summary>
        private IDictionary resourceList = new Hashtable();

        /// <summary>
        /// Constructs a DbResourceWriter object
        /// </summary>
        /// <param name="baseNameField">The base name of the resource writer</param>
        /// <param name="cultureInfo">The CultureInfo identifying the culture of the resources to be written</param>
        public wwDbResourceWriter(string baseName, CultureInfo cultureInfo)
        {
            this.baseName = baseName;
            this.cultureInfo = cultureInfo;

            string CultureName = "";
            if (cultureInfo != null && !cultureInfo.IsNeutralCulture)
                CultureName = cultureInfo.Name;
        }

        /// <summary>
        /// Override that reads existing resources into the list
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="baseName"></param>
        /// <param name="cultureInfo"></param>
        public wwDbResourceWriter(IResourceReader reader, string baseName, CultureInfo cultureInfo)
        {
            this.baseName = baseName;
            this.cultureInfo = cultureInfo;

            this.resourceList = reader as IDictionary;
        }

        /// <summary>
        /// Closes the resource writer after releasing any resources associated with it
        /// </summary>
        public void Close()
        {
            Dispose(true);
        }
        /// <summary>
        /// Releases all resources used by the object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Releases all resources used by the object
        /// </summary>
        /// <param name="disposing">True if the object is being disposed</param>
        private void Dispose(bool disposing)
        {
            if (disposing && resourceList != null)
                Generate();
        }
        /// <summary>
        /// Adds a resource to the list of resources to be written to an output file or output stream
        /// </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="value">The value of the resource</param>
        public void AddResource(string name, object value)
        {
            if (name == null)
                throw new ArgumentNullException(name);
            if (resourceList == null)
                throw new InvalidOperationException("No Resources");
            
            resourceList[name] = value;            
        }
        /// <summary>
        /// Adds a resource to the list of resources to be written to an output file or output stream
        /// </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="value">The value of the resource</param>
        public void AddResource(string name, string value)
        {
            AddResource(name, (Object)value);
        }
        /// <summary>
        /// Adds a resource to the list of resources to be written to an output file or output stream
        /// </summary>
        /// <param name="name">The name of the resource</param>
        /// <param name="value">The value of the resource</param>
        public void AddResource(string name, byte[] value)
        {
            AddResource(name, (Object)value);
        }
        
        /// <summary>
        /// Writes all the resources added by the AddResource method to the output file or stream
        /// </summary>
        public void Generate()
        {
            this.Generate(false);
        }

        /// <summary>
        /// Writes all resources out to the resource store. Optional flag that
        /// allows deleting all resources for a given culture and basename first
        /// so that you get 'clean set' of resource with no orphaned values.
        /// </summary>
        /// <param name="DeleteAllRowsFirst"></param>
        public void Generate(bool DeleteAllRowsFirst)
        {
            // *** DEPENDENCY HERE
            wwDbResourceDataManager Data = new wwDbResourceDataManager();
            Data.GenerateResources(resourceList, this.cultureInfo.Name, this.baseName, DeleteAllRowsFirst);
        }
    }

}
