using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Xml;
using id = System.String;

namespace RT2020.Common.ModelEx
{
    public class MetadataXml
    {
        private Dictionary<id, MetadataAttributes> metadataXml = new Dictionary<id, MetadataAttributes>();

        public MetadataXml()
        {

        }

        #region XML Manipulation

        #region Metadata Attributes

        public class MetadataAttribute
        {
            private string _key = string.Empty;
            private string _value = string.Empty;

            public MetadataAttribute(string key, string value)
            {
                _key = key;
                _value = value;
            }

            public string Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    _key = value;
                }
            }

            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
        }

        public class MetadataAttributes : BindingList<MetadataAttribute>
        {
        }

        #endregion

        protected string RootNode = "Metadata";

        /// <summary>
        /// Process the SqlXml Data from Database to prepare MetadataXml.
        /// </summary>
        private void PrepareMetadataXml(SqlXml dataXml, out Dictionary<id, MetadataAttributes> metadataXml)
        {
            metadataXml = new Dictionary<id, MetadataAttributes>();

            if (!dataXml.IsNull)
            {
                XmlDocument metadata = new XmlDocument();
                metadata.LoadXml(dataXml.Value);

                XmlNodeList dataList = metadata.SelectNodes("//data");
                if (dataList.Count > 0)
                {
                    MetadataAttributes attributes = new MetadataAttributes();

                    foreach (XmlNode node in dataList)
                    {
                        string key = node.ChildNodes[0].InnerText;
                        string value = node.ChildNodes[1].InnerText;

                        attributes.Add(new MetadataAttribute(key, value));
                    }

                    if (attributes.Count > 0)
                    {
                        metadataXml.Add("data", attributes);
                    }
                }
                else
                {
                    MetadataAttributes attributes = new MetadataAttributes();
                    XmlNodeList targetNode = metadata.SelectNodes("//" + RootNode);
                    foreach (XmlNode node in targetNode)
                    {
                        if (node.HasChildNodes)
                        {
                            ProcessingNodes(node, ref metadataXml, attributes);
                        }
                        else
                        {
                            XmlAttributeCollection attrList = node.Attributes;
                            foreach (XmlAttribute attr in attrList)
                            {
                                attributes.Add(new MetadataAttribute(attr.Name, attr.Value));
                            }

                            if (attributes.Count > 0)
                            {
                                metadataXml.Add("data", attributes);
                            }
                        }
                    }
                }
            }
        }

        private void ProcessingNodes(XmlNode node, ref Dictionary<id, MetadataAttributes> metadataXml, MetadataAttributes attributes)
        {
            foreach (XmlNode child in node)
            {
                attributes = new MetadataAttributes();
                string metadataKey = string.Empty;
                XmlAttributeCollection attrList = child.Attributes;
                foreach (XmlAttribute attr in attrList)
                {
                    if (attr.Name == "id")
                    {
                        metadataKey = attr.Value;
                    }
                    else
                    {
                        attributes.Add(new MetadataAttribute(attr.Name, attr.Value));
                    }
                }

                if (metadataKey != string.Empty)
                {
                    metadataXml.Add(metadataKey, attributes);
                }
            }
        }

        /// <summary>
        /// Generate xml string.
        /// </summary>
        /// <returns>.</returns>
        public string GenerateXml(Dictionary<string, MetadataAttributes> metadataXml)
        {
            string sqlXml = string.Empty;
            XmlDocument metadata = new XmlDocument();
            XmlNode node = metadata.AppendChild(metadata.CreateElement(RootNode));

            foreach (KeyValuePair<id, MetadataAttributes> kvp in metadataXml)
            {
                XmlElement element = metadata.CreateElement("record");
                element.SetAttribute("id", kvp.Key);

                foreach (MetadataAttribute attr in kvp.Value)
                {
                    element.SetAttribute(attr.Key, attr.Value);
                }

                node.AppendChild(element);
            }

            sqlXml = metadata.OuterXml;
            return sqlXml;
        }

        public MetadataAttributes GetMetadataList(string id)
        {
            if (this.metadataXml.ContainsKey(id))
            {
                return this.metadataXml[id];
            }
            else
            {
                return new MetadataAttributes();
            }
        }

        /// <summary>
        /// GetMetadata by Key.
        /// </summary>
        /// <returns>The string value of the Key.</returns>
        public string GetMetadata(string key)
        {
            if (this.GetMetadataList("data").Count > 0)
            {
                MetadataAttributes attributes = this.GetMetadataList("data");
                string value = string.Empty;
                foreach (MetadataAttribute attr in attributes)
                {
                    if (attr.Key == key)
                    {
                        value = attr.Value;
                        break;
                    }
                }
                return value;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Set Metadata with id = key
        /// </summary>
        public void SetMetadata(string key, MetadataAttributes data)
        {
            if (this.metadataXml == null)
            {
                this.metadataXml = new Dictionary<string, MetadataAttributes>();
            }

            if (this.metadataXml.ContainsKey(key))
            {
                this.metadataXml[key] = data;
            }
            else
            {
                this.metadataXml.Add(key, data);
            }
        }

        /// <summary>
        /// Set Metadata with id = key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void SetMetadata(string key, MetadataAttribute data)
        {
            MetadataAttributes attributes = this.GetMetadataList(key);

            if (!attributes.Contains(data))
            {
                attributes.Add(data);
            }

            this.SetMetadata(key, attributes);
        }

        /// <summary>
        /// Set Metadata with default id;
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void SetMetadata(string key, string data)
        {
            this.SetMetadata("data", new MetadataAttribute(key, data));
        }

        #endregion
    }
}