using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Resources.Tools;
using System.Globalization;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Resources;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Compilation;

namespace Westwind.Globalization
{
    /// <summary>
    /// This class can be used to export resources from the database to ASP.NET
    /// compatible resources (Resx). This class takes all the resources in 
    /// the database and creates RESX files that match these resources.
    /// 
    /// Please note that it will overrwrite any existing resource files
    /// if they already exist, so please use this class with care if
    /// you have existing ResX resources.
    /// 
    /// Note this class is primarily ASP.NET specific in that it looks at
    /// ASP.NET specific directory structures for ResX imports and strongly
    /// typed resource creation.
    /// </summary>
    public class wwDbResXConverter
    {
        
        public wwDbResXConverter(string WebPhysicalPath)
        {
            this.WebPhysicalPath = WebPhysicalPath;
        }

        /// <summary>
        /// The physical path of the Web application. This path serves as 
        /// the root path to write resources to.
        /// 
        /// Example: c:\projects\MyWebApp
        /// </summary>
        public string WebPhysicalPath
        {
            get { return _WebPhysicalPath; }
            set 
            {
                if (!value.EndsWith("\\"))
                    value += "\\";

                _WebPhysicalPath = value; 
            }
        }
        private string _WebPhysicalPath = "";



        /// <summary>
        /// Error message if an operation fails
        /// </summary>
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        private string _ErrorMessage = "";


        /// <summary>
        /// Genereates Local Web Resource ResX files from the wwDbResourceDataManager
        /// </summary>
        /// <returns></returns>
        public bool GenerateLocalResourceResXFiles()
        {
            return this.GenerateResXFiles(true);
        }
        /// <summary>
        /// Genereates Local Web Resource ResX files from the wwDbResourceDataManager
        /// </summary>
        /// <returns></returns>
        public bool GenerateGlobalResourceResXFiles()
        {
            return this.GenerateResXFiles(false);
        }

        /// <summary>
        /// Generates both local and global Web resources from the wwDbResourceDataManager
        /// </summary>
        /// <returns></returns>
        public bool GenerateAllResourceResXFiles()
        {
            if (!this.GenerateResXFiles(true))
                return false;

            return this.GenerateResXFiles(false);
        }

        /// <summary>
        /// Work method that goes through the database resources and dumps them
        /// into resource files. Note - will overwrite existing files.
        /// </summary>
        /// <returns></returns>
        protected bool GenerateResXFiles(bool LocalResources)
        {
            wwDbResourceDataManager Data = new wwDbResourceDataManager();
            
            // *** Retrieve all resources for a ResourceSet for all cultures
            // *** The data is ordered by ResourceSet, LocaleId and resource ID as each
            // *** ResourceSet or Locale changes a new file is written
            DataTable dtResources = Data.GetAllResourcesForResourceSet(LocalResources);
            
            if (dtResources == null)
                return false;

            string LastSet = "";
            string LastLocale = "@!";
            
            XmlWriter xWriter = null;
            XmlWriterSettings XmlSettings = new XmlWriterSettings();

            // *** Make sure we use fragment syntax so there's no validation
            // *** otherwise loading the original string will fail
            XmlSettings.ConformanceLevel = ConformanceLevel.Fragment;

            // *** Pretty format
            XmlSettings.Indent = true;

            foreach(DataRow dr in dtResources.Rows)
            {
                // *** Read into vars for easier usage below
                string ResourceId = dr["ResourceId"] as string;                
                string Value = dr["Value"] as string;

                string Type = dr["Type"] as string;
                string TextFile = dr["TextFile"] as string;
                byte[] BinFile = dr["BinFile"] as byte[];
                string FileName = dr["FileName"] as string;

                string ResourceSet = dr["ResourceSet"] as string;
                ResourceSet = ResourceSet.ToLower();

                string LocaleId = dr["LocaleId"] as string;
                LocaleId = LocaleId.ToLower();
                                 
                // *** Create a new output file if the resource set or locale changes
                if (ResourceSet != LastSet || LocaleId != LastLocale )
                {
                    if (xWriter != null)
                    {
                        xWriter.WriteRaw("</root>");
                        xWriter.Close();
                    }

                    string Loc = ".resx";
                    if (LocaleId != "")
                        Loc = "." + LocaleId + ".resx";

                    xWriter = XmlWriter.Create( this.FormatResourceSetPath(ResourceSet,LocalResources) + Loc,XmlSettings);
                    xWriter.WriteRaw(ResXDocumentTemplate);

                    LastSet = ResourceSet;
                    LastLocale = LocaleId;
                }
                
//<data name="LinkButton1Resource1.Text" xml:space="preserve">
//    <value>LinkButton</value>
//</data>
                if (Type == "")  // plain string value
                {
                    xWriter.WriteStartElement("data");
                    xWriter.WriteAttributeString("name", ResourceId);
                    xWriter.WriteAttributeString("space", "xml", "preserve");
                    xWriter.WriteElementString("value", Value);
                    xWriter.WriteEndElement(); // data
                }
                // *** File Resources get written to disk
                else if (Type == "FileResource")  
                {
                    string ResourceFilePath = this.FormatResourceSetPath(ResourceSet,LocalResources);
                    string ResourcePath = new FileInfo(ResourceFilePath).DirectoryName;

                    if (Value.IndexOf("System.String") > -1)
                    {
                        string[] Tokens = Value.Split(';');
                        Encoding Encode = Encoding.Default;
                        try
                        {
                            if (Tokens.Length == 3)
                                Encode = Encoding.GetEncoding(Tokens[2]);

                            // *** Write out the file to disk
                            File.WriteAllText(ResourcePath + "\\" + FileName, TextFile, Encode);
                        }
                        catch
                        {
                        }
                    }
                    else 
                    {
                        File.WriteAllBytes(ResourcePath + "\\" + FileName,BinFile);
                    }

  //<data name="Scratch" type="System.Resources.ResXFileRef, System.Windows.Forms">
  //  <value>Scratch.txt;System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;Windows-1252</value>
  //</data>
                    xWriter.WriteStartElement("data");
                    xWriter.WriteAttributeString("name", ResourceId);
                    xWriter.WriteAttributeString("type", "System.Resources.ResXFileRef, System.Windows.Forms");
                    
                    // *** values are already formatted in the database
                    xWriter.WriteElementString("value", Value);
                    xWriter.WriteEndElement(); // data
                }                            

            } // foreach dr

            if (xWriter != null)
            {
                xWriter.WriteRaw("</root>");
                xWriter.Close();
            }

            return true;
        }
    
        /// <summary>
        /// Translates the resource set path to a system path based
        /// on the base virutal and output paths.
        /// </summary>
        /// <param name="ResourceSet"></param>
        /// <returns></returns>
        public string FormatResourceSetPath(string ResourceSet, bool LocalResources)
        {
               ResourceSet = ResourceSet.ToLower();
             
               // *** Make sure our slashes are right
               ResourceSet = ResourceSet.Replace("/","\\");

               if (LocalResources)
               {
                   // *** Inject App_LocalResource
                   ResourceSet = ResourceSet.Insert(ResourceSet.LastIndexOf('\\')+1, "App_LocalResources\\");
                   ResourceSet = this.WebPhysicalPath + ResourceSet;
               }
               else
               {
                   ResourceSet = this.WebPhysicalPath + "App_GlobalResources\\" + ResourceSet;
               }

               FileInfo fi = new FileInfo(ResourceSet);
               if (!fi.Directory.Exists)
                   fi.Directory.Create();
            
               return ResourceSet;
           }


        /// <summary>
        /// Imports ResX Web Resources of a Web application by parsing through
        /// the App_GlobalResources and App_LocalResources directories of 
        /// a Web site.
        /// 
        /// Note: Requires that WebPhysicalPath is set to point at the 
        /// Web root directory.
        /// </summary>
        /// <returns></returns>
        public bool ImportWebResources()
        {
            return this.ImportWebResources(null);
        }


        /// <summary>
        /// Internal worker method that parses through the directories
        /// </summary>
        /// <param name="WebPath">Physical path of the directory to pars</param>
        /// <returns></returns>
        protected bool ImportWebResources(string WebPath)
        {
            if (WebPath == null)
                WebPath = this.WebPhysicalPath;

            WebPath = WebPath.ToLower();
            if (!WebPath.EndsWith("\\"))
                WebPath += "\\";

            string[] Directories = Directory.GetDirectories(WebPath);

            foreach (string Dir in Directories)
            {
                string dir = Dir.ToLower();
                dir = Path.GetFileNameWithoutExtension(dir);

                if (dir == "app_localresources")
                {
                    // *** We need to create a Web relative path (ie. admin/default.aspx)
                    string RelPath = WebPath.Replace(this.WebPhysicalPath.ToLower(), "");
                    RelPath = RelPath.Replace("\\","/");

                    ImportDirectoryResources(WebPath + dir + "\\",RelPath) ;
                }
                else if (dir == "app_globalresources")
                    ImportDirectoryResources(WebPath + dir + "\\","");
                
                else if (  !("bin|app_code|app_themes|app_data|".Contains(dir + "|" )) )
                    // *** Recurse through child directories
                    ImportWebResources(WebPath + dir + "\\"); 
            }

            return true;
        }

        /// <summary>
        /// Imports all resources from a given directory. This method works for any resources.
        /// 
        /// When using LocalResources, make sure to provide an app relative path as the second
        /// parameter if the resources live in non root folder. So if you have resources in off
        /// an Admin folder use "admin/" as the parameter. Otherwise for web root resources or
        /// global or assembly level assemblies pass string.Empty or null.   
        /// </summary>
        /// <param name="path">Physical Path for the Resources</param>
        /// <param name="WebRelativePath">Optional - relative path prefix for Web App_LocalResources (ie. admin/)</param>
        /// <returns></returns>
        public bool ImportDirectoryResources(string path, string WebRelativePath)
        {
            if (string.IsNullOrEmpty(WebRelativePath))
                WebRelativePath = "";

            string[] Files = Directory.GetFiles(path, "*.resx");
         
            foreach (string CurFile in Files)
            {
                string file = CurFile.ToLower();
                string[] tokens = file.Replace(".resx","").Split('.');

                // *** ResName: admin/default.aspx or default.aspx or resources (global or assembly resources)
                string LocaleId = "";
                string ResName = WebRelativePath + Path.GetFileNameWithoutExtension(tokens[0]);

                if (tokens.Length > 1)
                {
                    string Extension = tokens[1];
                    if ("aspx|ascx|master|sitemap|".Contains(Extension + "|") )
                        ResName += "." + Extension;
                    else
                        LocaleId = Extension;
                }
                if (tokens.Length > 2)
                {
                    LocaleId = tokens[2];
                }

                this.ImportResourceFile(file, ResName, LocaleId);
            }

            return true;
        }

        /// <summary>
        /// Imports an individual ResX Resource file into the database
        /// </summary>
        /// <param name="FileName">Full path to the the ResX file</param>
        /// <param name="ResourceSetName">Name of the file or for local resources the app relative path plus filename (admin/default.aspx or default.aspx)</param>
        /// <param name="LocaleId">Locale Id of the file to import. Use "" for Invariant</param>
        /// <returns></returns>
        public bool ImportResourceFile(string FileName,string ResourceSetName,string LocaleId)
        {
            string FilePath = Path.GetDirectoryName(FileName) + "\\";
            
            wwDbResourceDataManager Data = new wwDbResourceDataManager();
            
            XmlDocument Dom = new XmlDocument();

            try
            {
                Dom.Load(FileName);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return false;
            }

            XmlNodeList nodes = Dom.DocumentElement.SelectNodes("data");

            foreach (XmlNode Node in nodes)
            {
                string Value = Node.ChildNodes[0].InnerText;
                string Name = Node.Attributes["name"].Value;
                string Type = null;
                if (Node.Attributes["type"] != null)
                    Type = Node.Attributes["type"].Value;

                if (string.IsNullOrEmpty(Type))
                    Data.UpdateOrAdd(Name, Value, LocaleId, ResourceSetName);
                else
                {
                    // *** File based resources are formatted: filename;full type name
                    string[] tokens = Value.Split(';');
                    if (tokens.Length > 0)
                    {
                        string ResFileName = FilePath + tokens[0];
                        if (File.Exists(ResFileName) )
                            // *** DataManager knows about file resources and can figure type info
                            Data.UpdateOrAdd(Name, ResFileName, LocaleId, ResourceSetName, true);
                    }
                }
            }

            return true;
        }
      


        public const string ResXDocumentTemplate =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
  <xsd:schema id=""root"" xmlns="""" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">
    <xsd:import namespace=""http://www.w3.org/XML/1998/namespace"" />
    <xsd:element name=""root"" msdata:IsDataSet=""true"">
      <xsd:complexType>
        <xsd:choice maxOccurs=""unbounded"">
          <xsd:element name=""metadata"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" use=""required"" type=""xsd:string"" />
              <xsd:attribute name=""type"" type=""xsd:string"" />
              <xsd:attribute name=""mimetype"" type=""xsd:string"" />
              <xsd:attribute ref=""xml:space"" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name=""assembly"">
            <xsd:complexType>
              <xsd:attribute name=""alias"" type=""xsd:string"" />
              <xsd:attribute name=""name"" type=""xsd:string"" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name=""data"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
                <xsd:element name=""comment"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""2"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" msdata:Ordinal=""1"" />
              <xsd:attribute name=""type"" type=""xsd:string"" msdata:Ordinal=""3"" />
              <xsd:attribute name=""mimetype"" type=""xsd:string"" msdata:Ordinal=""4"" />
              <xsd:attribute ref=""xml:space"" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name=""resheader"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name=""resmimetype"">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name=""version"">
    <value>2.0</value>
  </resheader>
  <resheader name=""reader"">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name=""writer"">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
";

    }

    public enum wwResourceExportLanguages 
    {
        CSharp, VB
    }
}