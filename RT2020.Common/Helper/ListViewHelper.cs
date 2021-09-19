using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using Newtonsoft.Json;
using System.Dynamic;
using System.Xml.Linq;

namespace RT2020.Common.Helper
{
    public static class ListViewHelper
    {
        public static int CountCheckedItems(ref ListView lvwList)
        {
            int result = 0;

            foreach (ListViewItem item in lvwList.Items)
            {
                result += item.Checked ? 1 : 0;
            }

            return result;
        }

        public static void SavePreference(ListView lvwList)
        {
            // 把每個 ColumnHeader 的資料保存在 MetadataXml 中
            var user = ModelEx.UserProfileEx.GetByUserSid(ConfigHelper.CurrentUserId);
            if (user != null)
            {
                /**
                var sql = String.Format("UserId = '{0}' AND PreferenceObjectId = '{1}'", user.UserId.ToString(), ((Guid)lvwList.Tag).ToString());

                UserPreference userPref = UserPreference.LoadWhere(sql);
                
                if (userPref == null)
                {
                    userPref = new UserPreference();
                    userPref.UserId = user.UserId;
                    userPref.PreferenceObjectId = (Guid)lvwList.Tag;
                }

                userPref.MetadataXml = new Dictionary<string, UserPreference.MetadataAttributes>();     // 首先清空舊的 Metadata.

                foreach (ColumnHeader col in lvwList.Columns)
                {
                    UserPreference.MetadataAttributes attrs = new UserPreference.MetadataAttributes();

                    attrs.Add(new UserPreference.MetadataAttribute("Name", col.Name));
                    //attrs.Add(new UserPreference.MetadataAttribute("Position", col.Position.ToString()));
                    attrs.Add(new UserPreference.MetadataAttribute("SortOrder", col.SortOrder.ToString()));
                    attrs.Add(new UserPreference.MetadataAttribute("SortPosition", col.SortPosition.ToString()));
                    attrs.Add(new UserPreference.MetadataAttribute("Text", col.Text));                  // 為咗方便睇 SQL 紀錄，Text 會 save 不過不需要 load
                    attrs.Add(new UserPreference.MetadataAttribute("Visible", col.Visible.ToString()));
                    attrs.Add(new UserPreference.MetadataAttribute("Width", col.Width.ToString()));
                    if (col.Image != null)
                        attrs.Add(new UserPreference.MetadataAttribute("ImageFile", col.Image.File));
                    else
                        attrs.Add(new UserPreference.MetadataAttribute("ImageFile", String.Empty));

                    userPref.SetMetadata(col.Index.ToString(), attrs);                                  // 採用 ColumnHeader.Index 作為 key
                }

                userPref.Save();
                */
                ModelEx.UserPreferenceEx.Save(user.UserId, ref lvwList);
            }
        }

        public static void DeletePreference(ListView lvwList)
        {
            var userId = ModelEx.UserProfileEx.GetUserIdBySid(ConfigHelper.CurrentUserId);
            if (userId != Guid.Empty)
            {
                ModelEx.UserPreferenceEx.Delete(userId, (Guid)lvwList.Tag);
            }
        }

        public static void LoadPreference(ref ListView lvwList)
        {
            var user = ModelEx.UserProfileEx.GetByUserSid(ConfigHelper.CurrentUserId);
            if (user != null)
            {
                /**
                var userId = ModelEx.UserProfileEx.GetUserIdBySid(ConfigHelper.CurrentUserId);
                if (userId != Guid.Empty)
                {
                    // 2012.04.18 paulus:
                    // 首先用 SuperUser 個 Id 試下，搵唔到才用自己個 Id，於是 SuperUser 可以設定 ListView 的 Layout 給所有用戶
                    var sql = String.Format("UserId = '{0}' AND PreferenceObjectId = '{1}'", RT2020.Controls.UserProfile.GetSuperUserId().ToString(), ((Guid)lvwList.Tag).ToString());
                    UserPreference userPref = UserPreference.LoadWhere(sql);
                    if (userPref == null)
                    {
                        sql = String.Format("UserId = '{0}' AND PreferenceObjectId = '{1}'", userId.ToString(), ((Guid)lvwList.Tag).ToString());
                        userPref = UserPreference.LoadWhere(sql);
                    }

                    #region 搵到就根據 UserPreference 的資料更改 ColumnHeader
                    if (userPref != null)
                    {
                        Dictionary<string, RT2020.DAL.UserPreference.MetadataAttributes> metadata = userPref.MetadataXml;
                        foreach (KeyValuePair<string, RT2020.DAL.UserPreference.MetadataAttributes> col in metadata)
                        {
                            int colIndex = int.Parse(col.Key);      // col.Key 等於 ColumnHeader.Index

                            foreach (RT2020.DAL.UserPreference.MetadataAttribute item in col.Value)
                            {
                                int position = 0, sortPosition = 0, width = 0;
                                bool visible = false;

                                switch (item.Key)
                                {
                                    case "Name":
                                        lvwList.Columns[colIndex].Name = item.Value;
                                        break;
                                    case "Position":
                                        int.TryParse(item.Value, out position);
                                        //lvwList.Columns[colIndex]..Position = position;
                                        break;
                                    case "SortOrder":
                                        if (item.Value == Gizmox.WebGUI.Forms.SortOrder.Ascending.ToString("g"))
                                            lvwList.Columns[colIndex].SortOrder = Gizmox.WebGUI.Forms.SortOrder.Ascending;
                                        else if (item.Value == Gizmox.WebGUI.Forms.SortOrder.Descending.ToString("g"))
                                            lvwList.Columns[colIndex].SortOrder = Gizmox.WebGUI.Forms.SortOrder.Descending;
                                        else if (item.Value == Gizmox.WebGUI.Forms.SortOrder.None.ToString("g"))
                                            lvwList.Columns[colIndex].SortOrder = Gizmox.WebGUI.Forms.SortOrder.None;
                                        break;
                                    case "SortPosition":
                                        int.TryParse(item.Value, out sortPosition);
                                        lvwList.Columns[colIndex].SortPosition = sortPosition;
                                        break;
                                    case "Visible":
                                        bool.TryParse(item.Value, out visible);
                                        lvwList.Columns[colIndex].Visible = visible;
                                        break;
                                    case "Width":
                                        int.TryParse(item.Value, out width);
                                        lvwList.Columns[colIndex].Width = width;
                                        break;
                                }
                            }
                        }
                    }
                    #endregion
                }
                */
                ModelEx.UserPreferenceEx.Load(user.UserId, ref lvwList);
            }
        }
    }

    /// <summary>
    /// Custom ListView Sorter: Sorting Integer Columns
    /// 參考：https://stackoverflow.com/a/1214333
    /// </summary>
    public class Sorter : System.Collections.IComparer
    {
        public int Column = 0;
        public Gizmox.WebGUI.Forms.SortOrder Order = SortOrder.Ascending;

        public int Compare(object x, object y) // IComparer Member
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);

            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;

            if (l1.ListView.Columns[Column].Tag == null)
            {
                l1.ListView.Columns[Column].Tag = "Text";
            }

            if (l1.ListView.Columns[Column].Tag.ToString() == "Numeric")
            {
                float fl1 = float.Parse(l1.SubItems[Column].Text);
                float fl2 = float.Parse(l2.SubItems[Column].Text);

                if (Order == SortOrder.Ascending)
                {
                    return fl1.CompareTo(fl2);
                }
                else
                {
                    return fl2.CompareTo(fl1);
                }
            }
            else
            {
                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (Order == SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }
    }
}