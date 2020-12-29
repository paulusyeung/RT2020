using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;

using Gizmox.WebGUI.Forms;
using Newtonsoft.Json;
using System.Dynamic;
using System.Xml.Linq;

namespace RT2020.ModelEx
{
    public class UserPreferenceEx
    {
        public static bool Delete(Guid userId, Guid objectId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.UserPreference.Where(x => x.UserId == userId && x.PreferenceObjectId == objectId).FirstOrDefault();
                if (item != null)
                {
                    ctx.UserPreference.Remove(item);
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }

        public static bool Save(Guid userId, ref ListView lvw)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    Guid objectId = (Guid)lvw.Tag;
                    var item = ctx.UserPreference.Where(x => x.UserId == userId && x.PreferenceObjectId == objectId).FirstOrDefault();
                    if (item == null)
                    {
                        item = new EF6.UserPreference();
                        item.PreferenceId = Guid.NewGuid();
                        item.UserId = userId;
                        item.PreferenceObjectId = objectId;

                        #region 開個吉嘅 XML 格式
                        XDocument newXml = new XDocument(
                            new XDeclaration("1.0", "utf-8", "yes"),
                            new XComment("VWG ListView Properties"),
                            new XElement("Columns"));
                        #endregion
                        item.MetadataXml = newXml.ToString();

                        ctx.UserPreference.Add(item);
                    }

                    XDocument xmlData = XDocument.Parse(item.MetadataXml);

                    #region 將每個 Column 嘅資料寫入 xmlData
                    foreach (ColumnHeader col in lvw.Columns)
                    {
                        bool insRec = false;
                        /** 例子：
                        * <!--VWG ListView Properties-->
                        * <Columns>
                        *   <Column Name="colWorkplaceCode" SortOrder="None" SortPosition="1000" Text="代碼" Visible="True" Width="80" ImageFile="" />
                        * </Columns>
                        */
                        var target = xmlData.Descendants("Columns").Elements("Column").Where(x => x.Attribute("Name").Value == col.Name).FirstOrDefault();
                        if (target == null)
                        {
                            target = new XElement("Column");
                            target.SetAttributeValue("Name", col.Name);
                            xmlData.Element("Columns").Add(target);
                        }

                        target.SetAttributeValue("Index", col.Index.ToString());
                        target.SetAttributeValue("DisplayIndex", col.DisplayIndex.ToString());
                        target.SetAttributeValue("SortOrder", col.SortOrder.ToString("g"));
                        target.SetAttributeValue("SortPosition", col.SortPosition.ToString());
                        target.SetAttributeValue("Text", col.Text);
                        target.SetAttributeValue("Visible", col.Visible.ToString());
                        target.SetAttributeValue("Width", col.Width.ToString());
                        target.SetAttributeValue("ImageFile", (col.Image == null) ? String.Empty : col.Image.File);
                    }
                    #endregion

                    item.MetadataXml = xmlData.ToString();

                    ctx.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        public static void Load(Guid userId, ref ListView lvw)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                if (userId != Guid.Empty)
                {
                    Guid objectId = (Guid)lvw.Tag;
                    // 2012.04.18 paulus:
                    // 首先用 SuperUser 個 Id 試下，搵唔到才用自己個 Id，於是 SuperUser 可以設定 ListView 的 Layout 給所有用戶
                    var id = RT2020.Controls.UserProfile.GetSuperUserId();
                    var userPref = ctx.UserPreference.Where(x => x.UserId == userId && x.PreferenceObjectId == id).FirstOrDefault();
                    if (userPref == null)
                    {
                        userPref = ctx.UserPreference.Where(x => x.UserId == userId && x.PreferenceObjectId == objectId).FirstOrDefault();
                    }

                    #region 搵到就根據 UserPreference 的資料更改 ColumnHeader
                    if (userPref != null)
                    {
                        XDocument xmlData = XDocument.Parse(userPref.MetadataXml);

                        foreach (ColumnHeader col in lvw.Columns)
                        {
                            int displayIndex = 0, sortPosition = 0, width = 0;
                            bool visible = false;

                            var colData = xmlData.Descendants("Columns").Elements("Column").Where(x => x.Attribute("Name").Value == col.Name).FirstOrDefault();
                            if (colData != null)
                            {
                                int.TryParse((string)colData.Attribute("DisplayIndex"), out displayIndex);
                                int.TryParse((string)colData.Attribute("SortPosition"), out sortPosition);
                                bool.TryParse((string)colData.Attribute("Visible"), out visible);
                                int.TryParse((string)colData.Attribute("Width"), out width);

                                col.DisplayIndex = displayIndex;
                                col.SortOrder = (string)colData.Attribute("SortOrder") == SortOrder.Ascending.ToString("g") ?
                                    SortOrder.Ascending : (string)colData.Attribute("SortOrder") == SortOrder.Descending.ToString("g") ?
                                    SortOrder.Descending :
                                    SortOrder.None;
                                col.SortPosition = sortPosition;
                                col.Visible = visible;
                                col.Width = width;
                            }
                        }
                    }
                    #endregion
                }
            }
        }
    }
}