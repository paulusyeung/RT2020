using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using Westwind.Globlization.Data;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Drawing;

namespace Westwind.Globalization
{

    /// <summary>
    /// This class provides the Data Access to the database
    /// for the wwDbResourceManager, Provider and design time
    /// services. This class acts as a Business layer
    /// and uses the wwSqlDataAccess DAL for its data access.
    /// 
    /// Dependencies:
    /// wwDbResourceConfiguration   (holds and reads all config data from .Current)
    /// wwSqlDataAccess             (provides a data access (DAL))
    /// </summary>
    public class wwDbResourceDataManager
    {
        //public static string ConnectionString = "";
        //public static string ResourceTableName = "Localizations";

        protected SqlTransaction Transaction = null;

        /// <summary>
        /// Error message that can be checked after a method complets
        /// and returns a failure result.
        /// </summary>
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        private string _ErrorMessage = "";

        /// <summary>
        /// Default constructor. Instantiates with the default connection string
        /// which is loaded from the configuration section.
        /// </summary>
        public wwDbResourceDataManager()
        {
        }
          
        /// <summary>
        /// Returns a specific set of resources for a given culture and 'resource set' which
        /// in this case is just the virtual directory and culture.
        /// </summary>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public IDictionary GetResourceSet(string CultureName, string ResourceSet)
        {
            if (CultureName == null)
                CultureName = "";

            string ResourceFilter = "";
            ResourceFilter = " ResourceSet=@ResourceSet";

            Dictionary<string, object> hashTable = new Dictionary<string, object>();
            //Hashtable hashTable = new Hashtable();

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            SqlDataReader reader = null;

            if (string.IsNullOrEmpty(CultureName))
                reader = Data.ExecuteReader("select ResourceId,Value,Type,BinFile,TextFile,FileName from " + wwDbResourceConfiguration.Current.ResourceTableName + " where " + ResourceFilter + " and (LocaleId is null OR LocaleId = '') order by ResourceId",
                                                      new SqlParameter("@ResourceSet", ResourceSet));
            else
                reader = Data.ExecuteReader("select ResourceId,Value,Type,BinFile,TextFile,FileName from " + wwDbResourceConfiguration.Current.ResourceTableName + " where " + ResourceFilter + " and LocaleId=@LocaleId order by ResourceId",
                                                      new SqlParameter("@ResourceSet", ResourceSet),
                                                      new SqlParameter("@LocaleId", CultureName));

            if (reader == null) 
                return hashTable as IDictionary;

            try
            {
                while (reader.Read())
                {
                    // *** Read the value into this
                    object ResourceValue = null;
                    ResourceValue = reader["Value"] as string;

                    string ResourceType = reader["Type"] as string;

                    if (!string.IsNullOrEmpty(ResourceType) )
                    {
                        // *** FileResource is a special type that is raw file data stored
                        // *** in the BinFile or TextFile data. Value contains
                        // *** filename and type data which is used to create: String, Bitmap or Byte[]
                        if (ResourceType == "FileResource")
                            ResourceValue = LoadFileResource(reader);
                        else
                        {
                            LosFormatter Formatter = new LosFormatter();
                            ResourceValue = Formatter.Deserialize(ResourceValue as string);
                        }
                    }
                    else
                    { 
                        if (ResourceValue == null)
                            ResourceValue = "";
                    }
                    
                    hashTable.Add(reader["ResourceId"].ToString(), ResourceValue);
                }
            }
            catch {}
            finally
            {
                // close reader and connection
                reader.Close();
                Data.CloseConnection();
            }            

            return hashTable as IDictionary;
        }

        /// <summary>
        /// Internal method used to parse the data in the database into a 'real' value.
        /// 
        /// Value field hold filename and type string
        /// TextFile,BinFile hold the actual file content
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private object LoadFileResource(SqlDataReader reader)
        {
            object Value = null;

            try
            {
                string TypeInfo = reader["Value"] as string;

                if (TypeInfo.IndexOf("System.String") > -1)
                {
                    Value = reader["TextFile"] as string;
                }
                else if (TypeInfo.IndexOf("System.Drawing.Bitmap") > -1)
                {
                    MemoryStream ms = new MemoryStream(reader["BinFile"] as byte[]);
                    Value = new Bitmap(ms);
                    ms.Close();
                }
                else
                {
                    Value = reader["BinFile"] as byte[];
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = reader["ResourceKey"].ToString() + ": " + ex.Message;
            }
            


            return Value;
        }

        /// <summary>
        /// Returns a data table of all the resources for all locales. The result is in a 
        /// table called TResources that contains all fields of the table. The table is
        /// ordered by LocaleId.
        /// 
        /// Fields:
        /// ResourceId,Value,LocaleId,ResourceSet,Type
        /// </summary>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public DataTable GetAllResourcesForResourceSet(bool LocalResources)
        {
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            
            string Sql = "";
            
            Sql = "select ResourceId,Value,LocaleId,ResourceSet,Type,TextFile,BinFile,FileName from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceSet "  +
                  (!LocalResources ? "not" : "") + " like @ResourceSet ORDER by ResourceSet,LocaleId";
            
            DataTable dt = Data.ExecuteTable("TResources",
                                             Sql,
                                             new SqlParameter("@ResourceSet","%.%") );

            if (dt == null)
            {
                this.ErrorMessage = Data.ErrorMessage;
                return null;
            }

            return dt;
        }
    

        /// <summary>
        /// Returns all available resource ids for a given resource set in all languages.
        /// 
        /// Returns a DataTable called TResoureIds. (ResourecId field)
        /// </summary>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public DataTable GetAllResourceIds(string ResourceSet)
        {
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            return Data.ExecuteTable("TResourceIds", "select ResourceId from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceSet=@ResourceSet group by ResourceId",
                                        new SqlParameter("@ResourceSet",ResourceSet) ) ;
        }

        /// <summary>
        /// Returns all available resource sets
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllResourceSets(ResourceListingTypes Type)
        {
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            DataTable dt = null;

            if (Type == ResourceListingTypes.AllResources)
                dt = Data.ExecuteTable("TResourcesets","select lower(ResourceSet) as ResourceSet from " + wwDbResourceConfiguration.Current.ResourceTableName + " group by ResourceSet");
            else if (Type == ResourceListingTypes.LocalResourcesOnly)
                dt = Data.ExecuteTable("TResourcesets", "select lower(ResourceSet) as ResourceSet from " + wwDbResourceConfiguration.Current.ResourceTableName + " where resourceset like @ResourceSet group by ResourceSet",
                                  new SqlParameter("@ResourceSet","%.%") );
            else if (Type == ResourceListingTypes.GlobalResourcesOnly)
                dt = Data.ExecuteTable("TResourcesets", "select lower(ResourceSet) as ResourceSet from " + wwDbResourceConfiguration.Current.ResourceTableName + " where resourceset not like @ResourceSet group by ResourceSet",
                                  new SqlParameter("@ResourceSet","%.%") );

            if (dt == null)
                this.ErrorMessage = Data.ErrorMessage;

            return dt;
        }

        /// <summary>
        /// Gets all the locales for a specific resource set.
        /// 
        /// Returns a table named TLocaleIds (LocaleId field)
        /// </summary>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public DataTable GetAllLocaleIds(string ResourceSet)
        {
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            return Data.ExecuteTable("TLocaleIds", "select LocaleId,'' as Language from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceSet=@ResourceSet group by LocaleId",
                                      new SqlParameter("@ResourceSet", ResourceSet));
        }

        /// <summary>
        /// Gets all the Resourecs and ResourceIds for a given resource set and Locale
        /// 
        /// returns a table "TResource" ResourceId, Value fields
        /// </summary>
        /// <param name="ResourceSet"></param>
        /// <param name="CultureName"></param>
        /// <returns></returns>
        public DataTable GetAllResourcesForCulture(string ResourceSet, string CultureName)
        {
            if (CultureName == null)
                CultureName = "";

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            return Data.ExecuteTable("TResources",
                                     "select ResourceId, Value from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceSet=@ResourceSet and LocaleId=@LocaleId",
                                        new SqlParameter("@ResourceSet", ResourceSet),
                                        new SqlParameter("@LocaleId",CultureName) );
        }

        
        /// <summary>
        /// Returns an individual Resource String from the database
        /// </summary>
        /// <param name="ResourceSet"></param>
        /// <param name="CultureName"></param>
        /// <returns></returns>
        public string GetResourceString(string ResourceId, string ResourceSet, string CultureName)
        {
            this.ErrorMessage = "";

            if (CultureName == null)
                CultureName = "";

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            object Result = Data.ExecuteScalar("select Value from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceId=@ResourceId and ResourceSet=@ResourceSet and LocaleId=@LocaleId",
                                new SqlParameter("@ResourceId", ResourceId),
                                new SqlParameter("@ResourceSet", ResourceSet),
                                new SqlParameter("@LocaleId",CultureName) );

            
            return Result as string;
        }

        /// <summary>
        /// Returns all the resource strings for all cultures.
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public Dictionary<string,string> GetResourceStrings(string ResourceId, string ResourceSet)
        {
            Dictionary<string, string> Resources = new Dictionary<string, string>();
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            SqlDataReader reader = Data.ExecuteReader("select Value,LocaleId from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceId=@ResourceId and ResourceSet=@ResourceSet ",
                                new SqlParameter("@ResourceId", ResourceId),
                                new SqlParameter("@ResourceSet", ResourceSet) );

            if (reader == null)
                return null;

            while (reader.Read())
            {
                Resources.Add(reader["LocaleId"] as string, reader["Value"] as string);
            }

            reader.Close();

            return Resources;
        }

        /// <summary>
        /// Returns an object from the Resources. Use this for any non-string
        /// types. While this method can be used with strings GetREsourceString
        /// is much more efficient.
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="ResourceSet"></param>
        /// <param name="CultureName"></param>
        /// <returns></returns>
        public object GetResourceObject(string ResourceId, string ResourceSet, string CultureName)
        {
            this.ErrorMessage = "";

            if (CultureName == null)
                CultureName = "";

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            SqlDataReader reader = Data.ExecuteReader("select Value,Type from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceId=@ResourceId and ResourceSet=@ResourceSet and LocaleId=@LocaleId",
                                new SqlParameter("@ResourceId", ResourceId),
                                new SqlParameter("@ResourceSet", ResourceSet),
                                new SqlParameter("@LocaleId", CultureName));
            if (reader == null)
                return null;

            reader.Read();

            string Type = reader["Type"] as string;
            if (string.IsNullOrEmpty(Type))
                return reader["Value"] as string;

            LosFormatter Formatter = new LosFormatter();

            object Result = Formatter.Deserialize(reader["Value"] as string);
            return Result;
        }

        /// <summary>
        /// Updates a resource if it exists, if it doesn't one is created
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="Value"></param>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <param name="Type"></param>
        public int UpdateOrAdd(string ResourceId, object Value, string CultureName, string ResourceSet)
        {
            return this.UpdateOrAdd(ResourceId, Value, CultureName, ResourceSet, false);
        }


        /// <summary>
        /// Updates a resource if it exists, if it doesn't one is created
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="Value"></param>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <param name="Type"></param>
        public int UpdateOrAdd(string ResourceId, object Value, string CultureName, string ResourceSet,bool ValueIsFileName)
        {
            int Result = 0;
            Result = this.UpdateResource(ResourceId, Value, CultureName, ResourceSet,ValueIsFileName);

            // *** We either failed or we updated
            if (Result != 0)
                return Result;

            // *** We have no records matched in the Update - Add instead
            Result = this.AddResource(ResourceId, Value, CultureName, ResourceSet,ValueIsFileName);

            if (Result == -1)
                return -1;

            return 1;
        }

        /// <summary>
        /// Adds a resource to the Localization Table
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="Value"></param>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <param name="Type"></param>
        /// <param name="Filename"></param>
        public int AddResource(string ResourceId, object Value, string CultureName, string ResourceSet)
        {
            return this.AddResource(ResourceId, Value, CultureName, ResourceSet, false);
        }

        /// <summary>
        /// Adds a resource to the Localization Table
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="Value"></param>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <param name="Type"></param>
        /// <param name="Filename"></param>
        /// <param name="ValueIsFileName">if true the Value property is a filename to import</param>
        public int AddResource(string ResourceId, object Value, string CultureName, string ResourceSet, bool ValueIsFileName)
        {
            string Type = "";

            if (CultureName == null)
                CultureName = "";

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            if (this.Transaction != null)
                Data.Transaction = this.Transaction;

            if (Value != null && !(Value is string))
            {
                Type = Value.GetType().AssemblyQualifiedName;
                try
                {
                    LosFormatter output = new LosFormatter();
                    StringWriter writer = new StringWriter();
                    output.Serialize(writer, Value);
                    Value = writer.ToString();
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                    return -1;
                }
            }
            else
                Type = "";

            byte[] BinFile = null ;
            string TextFile = null;
            string FileName = "";

            if (ValueIsFileName)
            {
                FileInfoFormat FileData = null;
                try
                {
                    FileData = this.GetFileInfo( Value as string);
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                    return -1;
                }

                Type = "FileResource";
                Value = FileData.ValueString;
                FileName = FileData.FileName;

                if (FileData.FileFormatType ==  FileFormatTypes.Text )
                    TextFile = FileData.TextContent;
                else
                    BinFile = FileData.BinContent;                
            }

            if (Value == null)
                Value = "";
            
            SqlParameter BinFileParm = new SqlParameter("@BinFile", SqlDbType.Image);
            if (BinFile == null)
                BinFileParm.Value = DBNull.Value;
            else
                BinFileParm.Value = BinFile;
            SqlParameter TextFileParm =  new SqlParameter("@TextFile",SqlDbType.NText);
            if (TextFile == null)
                TextFileParm.Value = DBNull.Value;
            else
                TextFileParm.Value = TextFile;

            string Sql = "insert into " + wwDbResourceConfiguration.Current.ResourceTableName + " (ResourceId,Value,LocaleId,Type,Resourceset,BinFile,TextFile,Filename) Values (@ResourceID,@Value,@LocaleId,@Type,@ResourceSet,@BinFile,@TextFile,@FileName)";
            if (Data.ExecuteNonQuery(Sql,
                                    new SqlParameter("@ResourceId", ResourceId),
                                    new SqlParameter("@Value", Value),
                                    new SqlParameter("@LocaleId", CultureName.ToLower()),
                                    new SqlParameter("@Type", Type),
                                    new SqlParameter("@ResourceSet", ResourceSet.ToLower()),
                                    BinFileParm,TextFileParm,
                                    new SqlParameter("@FileName",FileName) ) == -1)
            {
                this.ErrorMessage = Data.ErrorMessage;
                return -1;
            }

            return 1;
        }


        
        /// <summary>
        /// Updates an existing resource in the Localization table
        /// </summary>
        /// <param name="ResourceId">The Resource id to update</param>
        /// <param name="Value">The value to set it to</param>
        /// <param name="CultureName">The 2 (en) or 5 character (en-us)culture. Or "" for Invariant </param>
        /// <param name="ResourceSet">The name of the resourceset.</param>
        /// <param name="Type"></param>
        /// <
        public int UpdateResource(string ResourceId, object Value, string CultureName, string ResourceSet)
        {
            return this.UpdateResource(ResourceId, Value, CultureName, ResourceSet, false);
        }

        /// <summary>
        /// Updates an existing resource in the Localization table
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="Value"></param>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <param name="Type"></param>
        public int UpdateResource(string ResourceId, object Value, string CultureName, string ResourceSet, bool ValueIsFileName)
        {
            string Type = "";
            if (CultureName == null)
                CultureName = "";


            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            if (this.Transaction != null)
                Data.Transaction = this.Transaction;

            if (Value != null && !(Value is string) )
            {
                Type = Value.GetType().AssemblyQualifiedName;
                try
                {
                    LosFormatter output = new LosFormatter();
                    StringWriter writer = new StringWriter();
                    output.Serialize(writer, Value);
                    Value = writer.ToString();
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                    return -1;
                }
            }
            else
            {
                Type = "";

                if (Value == null)
                    Value = "";
            }

            byte[] BinFile = null;
            string TextFile = null;
            string FileName = "";

            if (ValueIsFileName)
            {
                FileInfoFormat FileData = null;
                try
                {
                    FileData = this.GetFileInfo(Value as string);
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                    return -1;
                }

                Type = "FileResource";
                Value = FileData.ValueString;
                FileName = FileData.FileName;

                if (FileData.FileFormatType == FileFormatTypes.Text)
                    TextFile = FileData.TextContent;
                else
                    BinFile = FileData.BinContent;
            }

            if (Value == null)
                Value = "";

            // *** Set up Binfile and TextFile parameters which are set only for
            // *** file values - otherwise they'll pass as Null values.
            SqlParameter BinFileParm = new SqlParameter("@BinFile", SqlDbType.Image);
            if (BinFile == null)
                BinFileParm.Value = DBNull.Value;
            else
                BinFileParm.Value = BinFile;
            SqlParameter TextFileParm = new SqlParameter("@TextFile", SqlDbType.NText);
            if (TextFile == null)
                TextFileParm.Value = DBNull.Value;
            else
                TextFileParm.Value = TextFile;

            int Result = 0;

            string Sql = "update " + wwDbResourceConfiguration.Current.ResourceTableName + " set Value=@Value, Type=@Type, BinFile=@BinFile,TextFile=@TextFile,FileName=@FileName where LocaleId=@LocaleId AND ResourceSet=@ResourceSet and ResourceId=@ResourceId";
            Result = Data.ExecuteNonQuery(Sql,
                                new SqlParameter("@ResourceId", ResourceId),
                                new SqlParameter("@Value", Value),
                                new SqlParameter("@Type", Type),
                                new SqlParameter("@LocaleId", CultureName.ToLower()),                                    
                                new SqlParameter("@ResourceSet", ResourceSet),
                                BinFileParm,TextFileParm,
                                new SqlParameter("@FileName",FileName) );
            if (Result == -1)
            {
                this.ErrorMessage = Data.ErrorMessage;
                return -1;
            }

            return Result;
        }

        /// <summary>
        /// Internal routine that looks at a file and based on its
        /// extension determines how that file needs to be stored in the
        /// database. Returns FileInfoFormat structure
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private FileInfoFormat GetFileInfo(string FileName)
        {
            FileInfoFormat Details = new FileInfoFormat();


            FileInfo fi = new FileInfo(FileName);
            if (!fi.Exists)
                throw new InvalidOperationException("Invalid Filename");

            string Extension = fi.Extension.ToLower().TrimStart('.');
            Details.FileName = fi.Name;

            if (Extension == "txt" || Extension == "css" || Extension == "js")
            {
                Details.FileFormatType = FileFormatTypes.Text;
                using (StreamReader sr = new StreamReader(FileName, Encoding.Default, true))
                {
                    Details.TextContent = sr.ReadToEnd();
                }
                Details.ValueString = Details.FileName + ";" + typeof(string).AssemblyQualifiedName + ";" + Encoding.Default.HeaderName;
            }
            else if (Extension == "gif" || Extension == "jpg" || Extension == "bmp" || Extension == "png")
            {
                Details.FileFormatType = FileFormatTypes.Image;
                Details.BinContent = File.ReadAllBytes(FileName);
                Details.ValueString = Details.FileName + ";" + typeof(Bitmap).AssemblyQualifiedName;
            }
            else
            {
                Details.BinContent = File.ReadAllBytes(FileName);
                Details.ValueString = Details.FileName + ";" + typeof(System.Byte[]).AssemblyQualifiedName;
            }

            return Details;
        }

        internal enum FileFormatTypes
        {
            Text,
            Image,
            Binary
        }

        /// <summary>
        /// Internal structure that contains format information about a file
        /// resource. Used internally to figure out how to write 
        /// a resource into the database
        /// </summary>
        internal class FileInfoFormat
        {
            public string FileName = "";
            public string Encoding = "";
            public byte[] BinContent = null;
            public string TextContent = "";
            public FileFormatTypes FileFormatType = FileFormatTypes.Binary;
            public string ValueString = "";
            public string Type = "File";
        }


        /// <summary>
        /// Deletes a specific resource ID based on ResourceId, ResourceSet and Culture.
        /// If an empty culture is passed the entire group is removed (ie. all locales).
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public bool DeleteResource(string ResourceId, string CultureName, string ResourceSet)
        {
            int Result = 0;

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            
            if (!string.IsNullOrEmpty(CultureName))
                // *** Delete the specific entry only
                Result = Data.ExecuteNonQuery("delete from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceId=@ResourceId and LocaleId=@LocaleId and ResourceSet=@ResourceSet",
                                       new SqlParameter("@ResourceId", ResourceId),
                                       new SqlParameter("@LocaleId", CultureName),
                                       new SqlParameter("@ResourceSet", ResourceSet));
            else
                // *** If we're deleting the invariant entry - delete ALL of the languages for this key
                Result = Data.ExecuteNonQuery("delete from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceId=@ResourceId and ResourceSet=@ResourceSet",
                                       new SqlParameter("@ResourceId", ResourceId),
                                       new SqlParameter("@ResourceSet", ResourceSet));
        
            if (Result == -1)
            {
                this.ErrorMessage = Data.ErrorMessage;
                return false;
            }
        

            return true;
        }

        /// <summary>
        /// Renames a given resource in a resource set. Note all languages will be renamed
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="NewResourceId"></param>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public bool RenameResource(string ResourceId, string NewResourceId, string ResourceSet)
        {
            wwSqlDataAccess Sql = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            int Result = Sql.ExecuteNonQuery("update " + wwDbResourceConfiguration.Current.ResourceTableName + " set ResourceId=@NewResourceId where ResourceId=@ResourceId AND ResourceSet=@ResourceSet",
                                new SqlParameter("@ResourceId", ResourceId),
                                new SqlParameter("@NewResourceId", NewResourceId),
                                new SqlParameter("@ResourceSet", ResourceSet));
            if (Result == -1)
            {
                this.ErrorMessage = Sql.ErrorMessage;
                return false;
            }
            if (Result == 0)
            {
                this.ErrorMessage = "Invalid ResourceId";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Renames all property keys for a given property prefix. So this routine updates
        /// lblName.Text, lblName.ToolTip to lblName2.Text, lblName2.ToolTip if the property
        /// is changed from lblName to lblName2.
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="NewProperty"></param>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public bool RenameResourceProperty(string Property, string NewProperty, string ResourceSet)
        {
            wwSqlDataAccess Sql = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            Property += ".";
            NewProperty += ".";

            string PropertyQuery = Property + "%";

            int Result = Sql.ExecuteNonQuery("update " + wwDbResourceConfiguration.Current.ResourceTableName + " set ResourceId=replace(resourceid,@Property,@NewProperty) where ResourceSet=@ResourceSet and ResourceId like @PropertyQuery",
                                new SqlParameter("@Property", Property),
                                new SqlParameter("@NewProperty", NewProperty),
                                new SqlParameter("@ResourceSet", ResourceSet),
                                new SqlParameter("@PropertyQuery", PropertyQuery));
            
            if (Result == -1)
            {
                this.ErrorMessage = Sql.ErrorMessage;
                return false;
            }            

            return true;
        }

        /// <summary>
        /// Deletes an entire resource set from the database. Careful with this function!
        /// </summary>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public bool DeleteResourceSet(string ResourceSet)
        {
            if (string.IsNullOrEmpty(ResourceSet))
                return false;

            int Result = -1;

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            
            Result = Data.ExecuteNonQuery("delete from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceSet=@ResourceSet",
                                         new SqlParameter("@ResourceSet",ResourceSet) );

            if (Result < 0)
            {
                this.ErrorMessage = Data.ErrorMessage;
                return false;
            }
            
            if (Result > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Renames a resource set. Useful if you need to move a local page resource set
        /// to a new page. ResourceSet naming for local resources is application relative page path:
        /// 
        /// test.aspx
        /// subdir/test.aspx
        /// 
        /// Global resources have a simple name
        /// </summary>
        /// <param name="OldResourceSet">Name of the existing resource set</param>
        /// <param name="NewResourceSet">Name to set the resourceset name to</param>
        /// <returns></returns>
        public bool RenameResourceSet(string OldResourceSet, string NewResourceSet)
        {
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            
            int Result = Data.ExecuteNonQuery("update " + wwDbResourceConfiguration.Current.ResourceTableName + " set ResourceSet=@NewResourceSet where ResourceSet=@OldResourceSet",
                                         new SqlParameter("@NewResourceSet",NewResourceSet),
                                         new SqlParameter("@OldResourceSet",OldResourceSet) );

            if (Result == -1)
            {
                this.ErrorMessage = Data.ErrorMessage;
                return false;
            }

            if (Result == 0)
            {
                this.ErrorMessage = "No matching Recordset found.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks to see if a resource exists in the resource store
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="Value"></param>
        /// <param name="CultureName"></param>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public bool ResourceExists(string ResourceId, string CultureName, string ResourceSet)
        {
           if (CultureName == null)
               CultureName = "";

            object Result = null;
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            
            Result = Data.ExecuteScalar("select ResourceId from " + wwDbResourceConfiguration.Current.ResourceTableName + " where ResourceId=@ResourceId and LocaleID=@LocaleId and ResourceSet=@ResourceSet group by ResourceId",
                   new SqlParameter("@ResourceId", ResourceId),
                   new SqlParameter("@LocaleId", CultureName),
                   new SqlParameter("@ResourceSet", ResourceSet));
        
           if (Result == null)
                return false;

            return true;
        }

        /// <summary>
        /// Persists resources to the database - first wipes out all resources, then writes them back in
        /// from the ResourceSet
        /// </summary>
        /// <param name="ResourceList"></param>
        /// <param name="CultureName"></param>
        /// <param name="BaseName"></param>
        public bool GenerateResources(IDictionary ResourceList, string CultureName, string BaseName,bool DeleteAllResourceFirst)
        {
            if (ResourceList == null)
                throw new InvalidOperationException("No Resources");

            if (CultureName == null)
                CultureName = "";

            
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            if (!Data.BeginTransaction())
                return false;

            // *** Set transaction to be shared by other methods
            this.Transaction = Data.Transaction;

            try
            {
                // *** First delete all resources for this resource set
                if (DeleteAllResourceFirst)
                {
                    int Result = Data.ExecuteNonQuery("delete " + wwDbResourceConfiguration.Current.ResourceTableName + " where LocaleId=@LocaleId and ResourceSet=@ResourceSet",
                                                            new SqlParameter("@LocaleId", CultureName),
                                                            new SqlParameter("@ResourceSet", BaseName));
                    if (Result == -1)
                    {
                        Data.RollbackTransaction();
                        return false;
                    }
                }

                // *** Now add them all back in one by one
                foreach (DictionaryEntry Entry in ResourceList)
                {
                    if (Entry.Value != null)
                    {
                        int Result = 0;
                        if (DeleteAllResourceFirst)
                            Result = this.AddResource(Entry.Key.ToString(), Entry.Value, CultureName, BaseName);
                        else
                            Result = this.UpdateOrAdd(Entry.Key.ToString(), Entry.Value, CultureName, BaseName);

                        if (Result == -1)
                        {
                            Data.RollbackTransaction();
                            return false;
                        }
                    }
                }
            }
            catch
            {
                Data.RollbackTransaction();
                return false;
            }
            
            Data.CommitTransaction();

            // Clear out the resources
            ResourceList = null;

            return true;
        }

        /// <summary>
        /// Checks to see if the LocalizationTable exists
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public bool IsLocalizationTable(string TableName)
        {
            if (TableName == null)
                TableName = wwDbResourceConfiguration.Current.ResourceTableName;

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            
            // *** Check for table existing already
            object Pk = Data.ExecuteScalar("select count(pk) from " + TableName );
            if (Pk is int)
                return true;
            
            return false;            
        }


        /// <summary>
        /// Create a backup of the localization database.
        /// 
        /// Note the table used is the one specified in the wwDbResourceConfiguration.Current.ResourceTableName
        /// </summary>
        /// <param name="BackupTableName">Table of the backup table. Null creates a _Backup table.</param>
        /// <returns></returns>
        public bool CreateBackupTable(string BackupTableName)
        {
            if (BackupTableName == null)
                BackupTableName = wwDbResourceConfiguration.Current.ResourceTableName + "_Backup";
            
            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);

            Data.ExecuteNonQuery("drop table " + BackupTableName);
            if (Data.ExecuteNonQuery("select * into " + BackupTableName + " from " + wwDbResourceConfiguration.Current.ResourceTableName) < 0)
            {
                this.ErrorMessage = Data.ErrorMessage;
                return false;
            }

            return true;            
        }


        /// <summary>
        /// Restores the localization table from a backup table by first wiping out 
        /// </summary>
        /// <param name="BackupTableName"></param>
        /// <returns></returns>
        public bool ResourceBackupTable(string BackupTableName)
        {
            if (BackupTableName == null)
                BackupTableName = wwDbResourceConfiguration.Current.ResourceTableName + "_Backup";

            using (wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString))
            {

                Data.BeginTransaction();

                if (Data.ExecuteNonQuery("delete from " + wwDbResourceConfiguration.Current.ResourceTableName) < 0)
                {
                    Data.RollbackTransaction();
                    this.ErrorMessage = Data.ErrorMessage;
                    return false;
                }

                string Sql =
    @"insert into {0}
  (ResourceId,Value,LocaleId,ResourceSet,Type,BinFile,TextFile,FileName) 
   select ResourceId,Value,LocaleId,ResourceSet,Type,BinFile,TextFile,FileName from {1}";

                string.Format(Sql, wwDbResourceConfiguration.Current.ResourceTableName, BackupTableName);
            
                if (Data.ExecuteNonQuery(Sql) < 0)
                {
                    Data.RollbackTransaction();
                    this.ErrorMessage = Data.ErrorMessage;
                    return false;
                }

                Data.CommitTransaction();
            }

            return true;
        }

        /// <summary>
        /// Creates the Localization table on the current connection string for
        /// the provider.
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public bool CreateLocalizationTable(string TableName)
        {
            if (TableName == null)
                TableName = wwDbResourceConfiguration.Current.ResourceTableName;

            string Sql = string.Format(TableCreationSql, TableName);

            // *** Check for table existing already
            if ( this.IsLocalizationTable(TableName) )
            {
                this.ErrorMessage = "Localization Table exists already";
                return false;
            }

            wwSqlDataAccess Data = new wwSqlDataAccess(wwDbResourceConfiguration.Current.ConnectionString);
            
            // *** Now execute the script one batch at a time
            if (!Data.RunSqlScript(Sql, false, false))
            {
                this.ErrorMessage = Data.ErrorMessage;
                return false;
            }
        
            return true;
        }
        
        public const string TableCreationSql =
@"SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING OFF
GO
CREATE TABLE [{0}] (
		[pk]              int NOT NULL IDENTITY(1, 1),
		[ResourceId]      nvarchar(512) NOT NULL,
		[Value]           ntext NOT NULL,
		[LocaleId]        varchar(10) NOT NULL,
		[ResourceSet]     nvarchar(512) NOT NULL,
		[Type]            nvarchar(255) NOT NULL,
		[BinFile]         image NULL,
		[TextFile]        ntext NULL,
		[Filename]        nvarchar(128) NOT NULL
)
ON [PRIMARY]
GO
ALTER TABLE [{0}]
	ADD
	CONSTRAINT [PK_{0}]
	PRIMARY KEY
	([pk])
	ON [PRIMARY]
GO
ALTER TABLE [{0}]
	ADD
	CONSTRAINT [DF_{0}_ControlId]
	DEFAULT ('') FOR [ResourceId]
GO
ALTER TABLE [{0}]
	ADD
	CONSTRAINT [DF_{0}_Filename]
	DEFAULT ('') FOR [Filename]
GO
ALTER TABLE [{0}]
	ADD
	CONSTRAINT [DF_{0}_LocaleId]
	DEFAULT ('') FOR [LocaleId]
GO
ALTER TABLE [{0}]
	ADD
	CONSTRAINT [DF_{0}_PageId]
	DEFAULT ('') FOR [ResourceSet]
GO
ALTER TABLE [{0}]
	ADD
	CONSTRAINT [DF_{0}_Text]
	DEFAULT ('') FOR [Value]
GO
ALTER TABLE [{0}]
	ADD
	CONSTRAINT [DF_{0}_Type]
	DEFAULT ('') FOR [Type]
GO";

    }

    /// <summary>
    /// Determines how hte GetAllResourceSets method returns its data
    /// </summary>
    public enum ResourceListingTypes
    {
        LocalResourcesOnly,
        GlobalResourcesOnly,
        AllResources
    }

}
