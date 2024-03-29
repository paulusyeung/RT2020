#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.IO;
using System.IO.Packaging;
using System.Collections;
using System.Xml;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Member.Reports
{
    public partial class RptVipThanksLetterForm : Form, IGatewayComponent
    {
        public RptVipThanksLetterForm()
        {
            InitializeComponent();
        }

        #region FillComboBox
        private void FillComboBox()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Member.OrderBy(x => x.MemberNumber).AsNoTracking().ToList();
                if (list.Count > 0)
                {
                    foreach (var oMember in list)
                    {
                        string item = oMember.MemberNumber + " - " + oMember.FullName;
                        cmbFrom.Items.Add(item);
                        cmbTo.Items.Add(item);
                    }
                    cmbFrom.SelectedIndex = 0;

                    cmbTo.SelectedIndex = list.Count - 1;
                }
            }
        }
        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string from = cmbFrom.Text.Remove(cmbFrom.Text.IndexOf("-")).Trim();
            string to = cmbTo.Text.Remove(cmbTo.Text.IndexOf("-")).Trim() + "z";
            string sql = @"SELECT * FROM dbo.vwVIP_MemberList WHERE VipNumber BETWEEN '" + from + "' AND '" + to + "' ORDER BY VipNumber";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        #region Export

        private void MailMergeData(DataRow row, XmlDocument tdoc, XmlNamespaceManager nsManager)
        {
            int iTotalFields = 0;

            XmlNodeList nodeList = tdoc.SelectNodes("//w:fldSimple", nsManager);
            foreach (XmlNode node in nodeList)
            {
                XmlNode newNode = tdoc.CreateNode(XmlNodeType.Element, "w", "r", nsManager.LookupNamespace("w"));
                XmlNode newChildNode = tdoc.CreateNode(XmlNodeType.Element, "w", "t", nsManager.LookupNamespace("w"));

                String fieldText = node.Attributes[0].Value;

                // only getting the mailmerge fields
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    // The text comes in the format of 'MERGEFIELD  MyFieldName  \\* MERGEFORMAT'
                    // This has to be edited to get only the fieldname "myfieldname"
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);

                    // Gives the fieldnames as the user had entered in .dot file
                    fieldName = fieldName.Trim();

                    // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ****//
                    switch (fieldName)
                    {
                        case "FIELD_SYSTEM_DATE":
                            newChildNode.InnerText = DateTime.Now.ToString("dd/MM/yyyy");
                            break;
                        case "FIELD_CARD_NAME":
                            newChildNode.InnerText = row["CARD_NAME"].ToString();
                            break;
                        case "FIELD_VIP_NUMBER":
                            newChildNode.InnerText = row["VipNumber"].ToString();
                            break;
                        case "FIELD_COMM_DATE":
                            newChildNode.InnerText = row["Date Commence"].ToString();
                            break;
                        case "\"FIELD_NNAME FIELD_FNAME\"":
                            newChildNode.InnerText = row["NickName"].ToString() + " " + row["FirstName"].ToString();
                            break;
                        case "FIELD_TEL":
                            newChildNode.InnerText = row["Phone_H"].ToString();
                            break;
                        case "FIELD_OTHER":
                            newChildNode.InnerText = row["Phone_Other"].ToString();
                            break;
                        case "FIELD_LETTER_WORD":
                            newChildNode.InnerText = txtLetterWording.Text.Trim();
                            break;
                        case "FIELD_PUR_VALUE":
                            newChildNode.InnerText = txtPurchaseValue.Text.Trim();
                            break;
                        case "FIELD_COMPANY_NAME":
                            newChildNode.InnerText = " ";
                            break;
                    }
                }
                newNode.AppendChild(newChildNode);

                node.ParentNode.ReplaceChild(newNode, node);

                iTotalFields++;
            }
        }

        private XmlDocument LoadTempateDoc()
        {
            // DOC Schemas
            const string wordmlNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            const string documentRelationshipType = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";

            //File name
            string dotName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Templates\\VIPThanksLetter.dotx");

            //  Manage namespaces to perform Xml XPath queries.
            NameTable nt = new NameTable();
            XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
            nsManager.AddNamespace("w", wordmlNamespace);

            // Open 
            Package wdPackage = Package.Open(dotName, FileMode.Open, FileAccess.ReadWrite);
            PackagePart documentPart = null;
            Uri documentUri = null;

            //  Get the main document part (document.xml).
            foreach (System.IO.Packaging.PackageRelationship relationship in wdPackage.GetRelationshipsByType(documentRelationshipType))
            {
                documentUri = PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative), relationship.TargetUri);
                documentPart = wdPackage.GetPart(documentUri);
                //  There is only one document.
                break;
            }

            // parse the document.xml
            XmlDocument xdot = new XmlDocument(nt);
            xdot.Load(documentPart.GetStream());

            wdPackage.Close();

            return xdot;
        }

        private string ExportToWord()
        {
            // DOC Schemas
            const string wordmlNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            const string documentRelationshipType = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
            const string wordDOCXContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml";

            //File name
            string dotName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Templates\\VIPThanksLetter.dotx");
            string mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "MemberReport");
            string docName = string.Empty;

            if (!Directory.Exists(mstrDirectory))
            {
                Directory.CreateDirectory(mstrDirectory);
            }

            docName = Path.Combine(mstrDirectory, "VIP_Thanks_Letter.dotx");

            // Copy the template file to output directory
            if (File.Exists(docName))
            {
                RT2020.Controls.FileHelper.RemoveReadOnlyAttribute(docName);
                File.Delete(docName);
            }
            File.Copy(dotName, docName);
            RT2020.Controls.FileHelper.RemoveReadOnlyAttribute(docName);

            //  Manage namespaces to perform Xml XPath queries.
            NameTable nt = new NameTable();
            XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
            nsManager.AddNamespace("w", wordmlNamespace);

            // Open 
            Package wdPackage = Package.Open(docName, FileMode.Open, FileAccess.ReadWrite);
            PackagePart documentPart = null;
            Uri documentUri = null;

            //  Get the main document part (document.xml).
            foreach (System.IO.Packaging.PackageRelationship relationship in wdPackage.GetRelationshipsByType(documentRelationshipType))
            {
                documentUri = PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative), relationship.TargetUri);
                documentPart = wdPackage.GetPart(documentUri);
                //  There is only one document.
                break;
            }

            // new documnet
            XmlDocument newDoc = new XmlDocument(nt);

            // Merge Data
            DataTable oTable = BindData();
            foreach (DataRow row in oTable.Rows)
            {
                XmlDocument tempDoc = new XmlDocument(nt);
                if (!tempDoc.HasChildNodes)
                {
                    tempDoc = LoadTempateDoc();
                    MailMergeData(row, tempDoc, nsManager);

                    if (!newDoc.HasChildNodes)
                    {
                        newDoc = tempDoc;
                    }
                    else
                    {
                        newDoc.LastChild.LastChild.InnerXml += tempDoc.LastChild.LastChild.InnerXml;
                    }
                }
            }

            //  Delete the document part and its relationship part.
            wdPackage.DeletePart(documentPart.Uri);

            //  Create new document and relationship parts using the correct content types.
            documentPart = wdPackage.CreatePart(documentUri, wordDOCXContentType);

            // Save and Create docx file
            newDoc.Save(documentPart.GetStream(FileMode.Create, FileAccess.Write));
            wdPackage.Close();

            string newFileName = Path.Combine(mstrDirectory, Path.GetFileNameWithoutExtension(docName) + ".docx");
            //  If the new file exists, delete it. You might
            //  want to make this code less destructive.
            if (File.Exists(newFileName))
            {
                File.Delete(newFileName);
            }
            File.Move(docName, newFileName);

            return newFileName;
        }

        #endregion

        #region IGatewayComponent Members

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            string fileName = ExportToWord();

            if (fileName.Length > 0)
            {
                Stream stream = File.Open(fileName, FileMode.Open);
                byte[] streamByte = SystemInfoHelper.Settings.ReadFully(stream, stream.Length);
                stream.Close();

                HttpResponse objResponse = this.Context.HttpContext.Response;
                objResponse.Clear();
                objResponse.ClearHeaders();
                objResponse.ContentType = "application/docx";
                objResponse.AddHeader("content-disposition", "attachment; filename=VIP Thanks Letter.docx");
                objResponse.BinaryWrite(streamByte);
                objResponse.Flush();
                objResponse.End();
            }
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RptVipThanksLetterForm_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }
    }
}