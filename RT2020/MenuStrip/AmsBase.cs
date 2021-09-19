using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Xml;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

using System.Collections.Generic;
using RT2020.Common.Helper;

namespace RT2020.MenuStrip
{
    public class AmsBase
    {
        public static MenuItem FillAms(String navPaneName)
        {
            MenuItem result = new MenuItem();
            XmlDocument oXmlDoc = new XmlDocument();

            nxStudio.BaseClass.WordDict oDict = new nxStudio.BaseClass.WordDict(ConfigHelper.CurrentWordDict, ConfigHelper.CurrentLanguageId);

            string source = String.Empty;

            #region 2012.04.21 paulus: Load external Menu.xml
            if (ConfigHelper.UseNetSqlAzMan)
            {   // 使用 NetSqlAzMan 時祇需要一個 Menu.xml
                source = System.Web.HttpContext.Current.Server.MapPath("~/Resources/Menu/NavMenu.xml");
            }
            else
            {   // 舊式辦法
                #region 根據用戶級別選用不同的 Menu.xml
                //if (RT2020.Controls.Utility.Staff.IsAccessAllowed(EnumHelper.UserGroup.Senior))
                //{
                //    source = System.Web.HttpContext.Current.Server.MapPath("~/Resources/Menu/NavMenu.xml");
                //}
                //else
                //{
                //    source = System.Web.HttpContext.Current.Server.MapPath("~/Resources/Menu/NavMenu4Factory.xml");
                //}
                #endregion
                source = System.Web.HttpContext.Current.Server.MapPath("~/Resources/Menu/NavMenu.xml");
            }

            try
            {
                oXmlDoc.Load(source);
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion

            XmlNodeList oNodeList = oXmlDoc.DocumentElement.ChildNodes;
            foreach (XmlNode oNode in oNodeList)
            {
                XmlNode oCurNode = oNode;

                if (oCurNode.HasChildNodes && oCurNode.Name.ToLower() == navPaneName.ToLower())
                {
                    result.Text = oDict.GetWord(oCurNode.Attributes["Caption"].Value);
                    FillMenuItem(oNode, result, navPaneName);
                }
            }

            return result;
        }

        // 2007.10.23 paulus: I use FillTree_ to skips the first node
        private static void FillMenuItem(XmlNode node, MenuItem parentnode, String navPaneName)
        {
            // Add all the children of the current node to the treeview
            foreach (XmlNode tmpchildnode in node.ChildNodes)
            {
                FillMenu(tmpchildnode, parentnode, navPaneName);
            }
        }

        private static void FillMenu(XmlNode node, MenuItem parentnode, String navPaneName)
        {
            MenuItem tmpNodes = AddNodeToMenu(node, parentnode, navPaneName);

            // Add all the children of the current node to the treeview
            foreach (XmlNode tmpchildnode in node.ChildNodes)
            {
                FillMenu(tmpchildnode, tmpNodes, navPaneName);
            }
        }

        private static MenuItem AddNodeToMenu(XmlNode node, MenuItem parentnode, String navPaneName)
        {
            MenuItem newchildnode = CreateMenuItemFromXmlNode(node, navPaneName);
            // if nothing to add, return the parent item
            if (newchildnode == null) return parentnode;
            // add the newly created tree node to its parent
            if (parentnode != null) parentnode.MenuItems.Add(newchildnode);
            return newchildnode;
        }

        private static Gizmox.WebGUI.Forms.MenuItem CreateMenuItemFromXmlNode(XmlNode node, String navPaneName)
        {
            nxStudio.BaseClass.WordDict oDict = new nxStudio.BaseClass.WordDict(ConfigHelper.CurrentWordDict, ConfigHelper.CurrentLanguageId);

            MenuItem tmptreenode = null;

            bool buildNode = true;

            #region 2012.04.21 paulus: 如果有採用 NetSqlAzMan，就要用 IsAccessAuthorized check 下這位 user 是否有 permission
            if (ConfigHelper.UseNetSqlAzMan)
            {
                String tagName = String.Empty;
                if (node.Attributes["Tag"] != null)
                    tagName = node.Attributes["Tag"].Value;
                else
                    tagName = node.Attributes["Caption"].Value;
                //buildNode = xPort5.Controls.Utility.NetSqlAzMan.IsAccessAuthorized(navPaneName, tagName);
            }
            #endregion

            if (buildNode)
            {   // 以下這段 code 沒有因為要用 NetSqlAzMan 而改動過
                if ((node.HasChildNodes) && (node.FirstChild.Value != null))
                {
                    tmptreenode = new MenuItem(node.Name);
                    MenuItem tmptreenode2 = new MenuItem(node.FirstChild.Value);
                    tmptreenode.MenuItems.Add(tmptreenode2);
                }
                else if (node.NodeType != XmlNodeType.CDATA)
                {
                    tmptreenode = new MenuItem();
                    if (node.HasChildNodes)
                    {
                        MenuItem oNode = new MenuItem();

                        oNode.Text = oDict.GetWord(node.Attributes["Caption"].Value);

                        tmptreenode = oNode;
                    }
                    else
                    {
                        MenuItem oNode = new MenuItem();
                        var caption = node.Attributes["Caption"].Value;

                        if (caption == "-")
                        {
                            oNode.Text = "-";   // 分隔線
                        }
                        else
                        {
                            if (node.Attributes["Tag"].Value.Contains("."))
                            {
                                oNode.Text = oDict.GetWord(node.Attributes["Tag"].Value.Replace('.', '_'));
                            }
                            else
                            {
                                #region 如果係哩幾個 keywords 要特別處理
                                List<string> keyWords = new List<string>();
                                keyWords.Add("STKCODE");
                                keyWords.Add("APPENDIX1");
                                keyWords.Add("APPENDIX2");
                                keyWords.Add("APPENDIX3");
                                keyWords.Add("CLASS1");
                                keyWords.Add("CLASS2");
                                keyWords.Add("CLASS3");
                                keyWords.Add("CLASS4");
                                keyWords.Add("CLASS5");
                                keyWords.Add("CLASS6");
                                #endregion

                                if (keyWords.Exists(key => key == node.Attributes["Caption"].Value))
                                {
                                    oNode.Text = SystemInfoHelper.Settings.GetSystemLabelByKey(node.Attributes["Caption"].Value);
                                }
                                else
                                {
                                    oNode.Text = oDict.GetWord(node.Attributes["Caption"].Value);
                                }
                            }
                            oNode.Tag = node.Attributes["Tag"].Value;
                            oNode.Icon = new IconResourceHandle(node.Attributes["ImageUrl"].Value);
                        }

                        tmptreenode = oNode;
                    }
                }
            }

            return tmptreenode;
        }
    }
}