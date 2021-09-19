#region Using

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Server;
using System.Xml.Serialization;

using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion Using

namespace RT2020.Controls
{
    public class Utility
    {
        #region Misc Utility

        /// <summary>
        /// Return uploaded file name
        /// </summary>
        /// <param name="objFileDialog"></param>
        /// <returns></returns>
        public static string UploadFile(OpenFileDialog objFileDialog, string uploadedPath)
        {
            string FileName = string.Empty;
            string FullName = string.Empty;

            if (!Directory.Exists(uploadedPath))
            {
                Directory.CreateDirectory(uploadedPath);
            }

            if (objFileDialog != null)
            {
                for (int i = 0; i < objFileDialog.Files.Count; i++)
                {
                    HttpPostedFileHandle file = objFileDialog.Files[i] as HttpPostedFileHandle;
                    if (file.ContentLength > 0)
                    {
                        FileName = Path.GetFileName(file.PostedFileName);
                        FullName = Path.Combine(uploadedPath, FileName);
                        file.SaveAs(FullName);
                    }
                }
            }
            return FileName;
        }

        // Verify the single/double quote and remove it

        public static string VerifyQuotes(string valueToBeVerified)
        {
            if (valueToBeVerified.Contains("'"))
            {
                valueToBeVerified = valueToBeVerified.Replace("'", "");
            }

            if (valueToBeVerified.Contains("\""))
            {
                valueToBeVerified = valueToBeVerified.Replace("\"", "");
            }

            return valueToBeVerified;
        }

        /// <summary>
        /// Gets the workplace id list by current zone.
        /// </summary>
        /// <returns></returns>
        public static string GetWorkplaceIdListByCurrentZone()
        {
            return GetWorkplaceIdListByZone(ConfigHelper.CurrentZoneId);
        }

        /// <summary>
        /// Gets the workplace id list by zone.
        /// </summary>
        /// <param name="zoneId">The zone id.</param>
        /// <returns></returns>
        public static string GetWorkplaceIdListByZone(Guid zoneId)
        {
            int iCount = 0;
            string result = "'{0}'", temp = Guid.Empty.ToString();
            temp = string.Format(result, temp);

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Workplace.Where(x => x.ZoneId == zoneId).OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();

                foreach (var wp in list)
                {
                    if (iCount > 0)
                    {
                        temp += ", ";
                        temp += string.Format(result, wp.WorkplaceId.ToString());
                    }
                    else
                    {
                        temp = string.Format(result, wp.WorkplaceId.ToString());
                    }

                    iCount++;
                }
            }

            return temp;
        }

        /// <summary>
        /// Gets the on hand qty by current zone.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByCurrentZone(Guid productId)
        {
            return GetOnHandQtyByZone(productId, ConfigHelper.CurrentZoneId);
        }

        /// <summary>
        /// Gets the on hand qty by zone.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <param name="zoneId">The zone id.</param>
        /// <returns></returns>
        public static decimal GetOnHandQtyByZone(Guid productId, Guid zoneId)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var wpList = ctx.Workplace.Where(x => x.ZoneId == zoneId).AsNoTracking().ToList();
                foreach (var wp in wpList)
                {
                    result += ProductHelper.GetOnHandQtyByWorkplaceId(productId, wp.WorkplaceId);
                }
            }

            return result;
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void WriteLog(string message)
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");

            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }

            fileName = Path.Combine(fileName, "MEND_" + DateTime.Now.ToString("yyyyMMdd") + ".log");

            WriteLog(message, fileName);
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="pathWithFileName">the path with file Name.</param>
        public static void WriteLog(string message, string pathWithFileName)
        {
            StreamWriter writer = null;

            writer = new StreamWriter(pathWithFileName, true, Encoding.Unicode, 4096);

            writer.WriteLine(message);

            writer.Close();
            //sw.Flush();
        }

        #endregion Misc Utility

        public static nxStudio.BaseClass.WordDict Dictionary
        {
            get
            {
                string fileName = Path.Combine(VWGContext.Current.Config.GetDirectory("UserData"), "WordDict.xml");
                nxStudio.BaseClass.WordDict wordDict = null;

                if (VWGContext.Current.Session["WordDict"] != null && ConfigHelper.CurrentLanguageCode == System.Web.HttpContext.Current.Request.UserLanguages[0])
                {
                    wordDict = (nxStudio.BaseClass.WordDict)VWGContext.Current.Session["WordDict"];
                }
                else
                {
                    wordDict = new nxStudio.BaseClass.WordDict(fileName, ConfigHelper.CurrentLanguageId);
                    VWGContext.Current.Session["WordDict"] = wordDict;
                }

                return wordDict;
            }
        }

        public static void BindingViewCombo(ref ComboBox cboView)
        {
            string label = RT2020.Controls.Utility.Dictionary.GetWord("Last_days");
            cboView.Items.Add(string.Format(label, "7"));
            cboView.Items.Add(string.Format(label, "14"));
            cboView.Items.Add(string.Format(label, "30"));
            cboView.Items.Add(string.Format(label, "60"));
            cboView.Items.Add(string.Format(label, "90"));
            cboView.Items.Add(RT2020.Controls.Utility.Dictionary.GetWord("All"));
        }

        public static void LoadPosTenderTypeToCombo(ref ComboBox cbo)
        {
            string sql = "SELECT DISTINCT TypeCode FROM PosTenderType WHERE Retired = 0";
            PosTenderTypeEx.LoadCombo(ref cbo, "TypeCode", false, false, "", sql);
            /**
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            Common.ComboList comboList = new Common.ComboList();

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    Common.ComboItem cboItem = new Common.ComboItem(reader.GetString(0), Guid.Empty);

                    comboList.Add(cboItem);
                }
            }

            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.SelectedIndex = 0;
            */
        }

        public static bool StringBetween(String source, String min, String max)
        {
            bool result = false;

            if (
                (String.CompareOrdinal(source, min) == 0) || (String.CompareOrdinal(source, max) == 0) ||
                ((String.CompareOrdinal(source, min) > 0) && (String.CompareOrdinal(source, max) < 0))
                )
            {
                result = true;
            }
            return result;
        }

        public class Default
        {
            public static Color TopPanelBackgroundColor
            {
                get
                {
                    Color color = Color.FromName("#ACC0E9");    // default color
                    if (HttpContext.Current.Request.Cookies["RT2020_TopPanelBackgroundColor"] != null)
                    {
                        color = HttpContext.Current.Request.Cookies["RT2020_TopPanelBackgroundColor"].Value == String.Empty ?
                            Color.FromName("#ACC0E9") :
                            Color.FromName(HttpContext.Current.Request.Cookies["RT2020_TopPanelBackgroundColor"].Value);
                    }
                    return color;
                }
                set
                {
                    System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2020_TopPanelBackgroundColor");

                    if (value != null)
                    {
                        // create the cookie
                        DateTime now = DateTime.Now;

                        oCookie.Value = value.ToString();
                        oCookie.Expires = now.AddYears(1);

                        System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                    }
                    else
                    {
                        // destory the cookie
                        DateTime now = DateTime.Now;

                        oCookie.Value = value.ToString();
                        oCookie.Expires = now.AddDays(-1);

                        System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                    }
                }
            }

            public static String CurrentTheme
            {
                get
                {
                    String theme = "";
                    if (HttpContext.Current.Request.Cookies["RT2020_CurrentTheme"] != null)
                    {
                        theme = HttpContext.Current.Request.Cookies["RT2020_CurrentTheme"].Value;
                    }
                    return theme == String.Empty ? "Vista" : theme;
                }
                set
                {
                    System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2020_CurrentTheme");

                    if (value != null)
                    {
                        // create the cookie
                        DateTime now = DateTime.Now;

                        oCookie.Value = value.ToString() == String.Empty ? "Vista" : value.ToString();
                        oCookie.Expires = now.AddYears(1);

                        System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                    }
                    else
                    {
                        // destory the cookie
                        DateTime now = DateTime.Now;

                        oCookie.Value = value.ToString();
                        oCookie.Expires = now.AddDays(-1);

                        System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                    }
                }
            }
        }
    }

    #region Inventory

    public class InvtUtility
    {
        /// <summary>
        /// Posting Status
        /// </summary>
        public enum PostingStatus
        {
            /// <summary>
            /// Ready to post
            /// </summary>
            Ready,
            /// <summary>
            /// be verified, can be posted
            /// </summary>
            Postable,
            /// <summary>
            /// not verify, cannot be posted
            /// </summary>
            Error
        }

        public enum InvtOlapViewerType
        {
            CAP_Summary,
            QoH_ATS,
            QoH_ATS_WithCutOffDate,
            StockReorder,
            StockIOHistory,
            OCInventory,
            DiscrepancyAudit,
            StockTransfer
        }

        public static void ShowCriteria(ref TextBox txtTxNumberFrom, ref TextBox txtTxNumberTo, string targetSQLViewName, EnumHelper.TxType txType, DateTime from, DateTime to)
        {
            string sql = @" SELECT MIN(TxNumber) AS TxNumber FROM " + targetSQLViewName + " WHERE TxType = '" + txType.ToString() + "' AND TxDate >= '" + from.ToString("yyyy-MM-dd") + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    if (!(reader[0] is DBNull))
                    {
                        txtTxNumberFrom.Text = reader.GetString(0);
                    }
                }
            }

            sql = @" SELECT MAX(TxNumber) AS TxNumber FROM " + targetSQLViewName + " WHERE TxType = '" + txType.ToString() + "' AND TxDate <= '" + to.ToString("yyyy-MM-dd") + "'";
            cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    if (!(reader[0] is DBNull))
                    {
                        txtTxNumberTo.Text = reader.GetString(0);
                    }
                }
            }
        }

        public static InvtTxSearcher ShowTxSearcher(string targetSQLViewName, EnumHelper.TxType txType)
        {
            RT2020.Controls.InvtTxSearcher searchForm = new RT2020.Controls.InvtTxSearcher();
            searchForm.SqlQuery = string.Format("SELECT HeaderId, TxNumber, TxType, TxDate FROM {0}", targetSQLViewName);
            searchForm.TxType = txType;

            return searchForm;
        }
    }

    #endregion Inventory

    #region Users'

    public class UserUtility
    {
        public static string PermissionLevel()
        {
            string result = "1"; // Guest

            var user = StaffEx.GetByStaffId(ConfigHelper.CurrentUserId);
            if (user != null)
            {
                result = StaffGroupEx.GetGradeCodeById(user.GroupId.Value);
            }

            return result;
        }

        /// <summary>
        /// the Allowed permission.
        /// According to PermissionLevel:
        /// 1, 2, 3 - Can Read
        /// 4, 5, 6 - Can Write
        /// 7, 8    - Can Modify
        /// 9       - All
        /// </summary>
        /// <returns></returns>
        private static EnumHelper.Permission AllowedPermission()
        {
            bool canRead = true, canWrite = false, canDelete = false, canPost = false;
            EnumHelper.Permission allowedPermission = EnumHelper.Permission.Read;

            //string query = "StaffId = '" + ConfigHelper.CurrentUserId.ToString() + "' AND GradeCode = '" + PermissionLevel() + "'";
            var oSecurity = StaffSecurityEx.GetByStaffId(ConfigHelper.CurrentUserId, PermissionLevel());
            if (oSecurity != null)
            {
                canRead = oSecurity.CanRead.Value;
                canWrite = oSecurity.CanWrite.Value;
                canDelete = oSecurity.CanDelete.Value;
                canPost = oSecurity.CanPost.Value;
            }
            else
            {
                var oStaff = StaffEx.GetByStaffId(ConfigHelper.CurrentUserId);
                if (oStaff != null)
                {
                    var oGroup = StaffGroupEx.GetById(oStaff.GroupId.Value);
                    if (oGroup != null)
                    {
                        canRead = oGroup.CanRead.Value;
                        canWrite = oGroup.CanWrite.Value;
                        canDelete = oGroup.CanDelete.Value;
                        canPost = oGroup.CanPost.Value;
                    }
                }
            }

            if (canRead)
            {
                allowedPermission = EnumHelper.Permission.Read;
            }

            if (canWrite)
            {
                allowedPermission = allowedPermission | EnumHelper.Permission.Write;
            }

            if (canDelete)
            {
                allowedPermission = allowedPermission | EnumHelper.Permission.Delete;
            }

            if (canPost)
            {
                allowedPermission = allowedPermission | EnumHelper.Permission.Posting;
            }

            return allowedPermission;
        }

        /// <summary>
        /// Determines whether [is access allowed] [the specified challenge].
        /// </summary>
        /// <param name="challenge">The challenge.</param>
        /// <returns>
        /// 	<c>true</c> if [is access allowed] [the specified challenge]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAccessAllowed(EnumHelper.Permission challenge)
        {
            return (((Int64)AllowedPermission() & (Int64)challenge) == (Int64)(challenge));
        }

        public static bool DeleteRec(Guid userId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var user = ctx.Staff.Find(userId);
                if (user != null)
                {
                    // cannot delete primary user (primary user means CreatedBy = Guid.Empty)
                    if (user.CreatedBy != Guid.Empty)
                    {
                        switch ((int)user.Status)
                        {
                            case (int)EnumHelper.Status.Active:
                                user.Status = Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d"));
                                user.Retired = true;
                                user.RetiredOn = DateTime.Now;
                                user.RetiredBy = ConfigHelper.CurrentUserId;

                                ctx.SaveChanges();
                                result = true;
                                break;

                            case (int)EnumHelper.Status.Draft:
                                result = StaffAddressEx.Delete(userId);
                                break;
                        }
                    }
                }
            }
            return result;
        }

        public static String SecurityLevel()
        {
            String result = String.Empty;
            var staff = StaffEx.GetByStaffId(ConfigHelper.CurrentUserId);

            if (staff != null)
            {
                result = StaffGroupEx.GetGradeCodeById(staff.GroupId.Value);
            }

            return result;
        }
    }

    #endregion Users'

    #region Barcode

    public class BarcodeUtility
    {
        /// <summary>
        /// Generate Barcode (EAN-8[GTIN-8]/UPC-12[GTIN-12]/EAN-13[GTIN-13]/ITF-14[GTIN-14]/SSCC) Check Digit
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetCheckCode(string value)
        {
            char ch;
            int init = 0;

            for (int index = value.Length - 1; index >= 0; index -= 2)
            {
                ch = value[index];
                init += int.Parse(ch.ToString());
            }

            init *= 3;
            for (int index = value.Length - 2; index >= 0; index -= 2)
            {
                ch = value[index];
                init += int.Parse(ch.ToString());
            }

            init = 10 - (init % 10);
            if (init == 10)
            {
                init = 0;
            }

            return init.ToString();
        }
    }

    #endregion Barcode

    #region Import Excel files

    public class XlsImport
    {
        #region Fill Sheet List

        private void FillDropdownList(ref ComboBox cboSheetName, string fileName)
        {
            cboSheetName.Items.Clear();
            string[] sheetNames = GetExcelSheetNames(fileName);
            if (sheetNames.Length > 0)
            {
                cboSheetName.Items.AddRange(sheetNames);
                for (int i = cboSheetName.Items.Count - 1; i >= 0; i--)
                {
                    // remove the item called "Database"
                    if (cboSheetName.Items[i].ToString().ToLower() == "database")
                    {
                        cboSheetName.Items.RemoveAt(i);
                    }
                }
            }
        }

        public static string[] GetExcelSheetNames(string excelFile)
        {
            try
            {
                if (excelFile.Length > 0)
                {
                    OleDbConnection oConn = ConfigHelper.GetOleDbConnection(excelFile);
                    DataTable dt = new DataTable();
                    oConn.Open();
                    dt = oConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (dt == null)
                    {
                        return null;
                    }

                    string[] excelSheets = new string[dt.Rows.Count];

                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                        i++;
                    }

                    if (oConn.State == ConnectionState.Open)
                    {
                        oConn.Close();
                    }

                    return excelSheets;
                }
                else
                {
                    return null;
                }
            }
            catch //(Exception ex)
            {
                return null;
            }
        }

        private string GetSheetNames(string excelFile)
        {
            string result = String.Empty;

            if (excelFile.Length > 0)
            {
                using (OleDbConnection oConn = ConfigHelper.GetOleDbConnection(excelFile))
                {
                    oConn.Open();
                    DataTable schemaTable = oConn.GetOleDbSchemaTable(
                        OleDbSchemaGuid.Tables,
                        new object[] { null, null, null, "TABLE" });
                    result = schemaTable.Rows[0]["TABLE_NAME"].ToString();
                }
            }

            return result;
        }

        #endregion Fill Sheet List

        #region Data Binding

        public static DataTable BindData(string fileName, string sheetName)
        {
            if (fileName.Length > 0 && sheetName.Length > 0)
            {
                OleDbConnection oConn = ConfigHelper.GetOleDbConnection(fileName);
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", oConn);

                da.Fill(dt);

                if (oConn.State == ConnectionState.Open)
                {
                    oConn.Close();
                }

                return dt;
            }
            else
            {
                return new DataTable();
            }
        }

        #endregion Data Binding
    }

    #endregion Import Excel files

    public class FileHelper
    {
        //2013.06.26 paulus
        public static void RemoveReadOnlyAttribute(String filepath)
        {
            FileAttributes attributes = File.GetAttributes(filepath);
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes(filepath, attributes ^ FileAttributes.ReadOnly);
        }
    }

    public class Staff
    {
        public static bool DeleteRec(Guid userId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var staff = ctx.Staff.Find(userId);
                if (staff != null)
                {
                    // cannot delete primary user (primary user means CreatedBy = Guid.Empty)
                    if (staff.CreatedBy != Guid.Empty)
                    {
                        switch ((int)staff.Status)
                        {
                            case (int)EnumHelper.Status.Active:
                                staff.Status = Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d"));
                                staff.Retired = true;
                                staff.RetiredOn = DateTime.Now;
                                staff.RetiredBy = ConfigHelper.CurrentUserId;

                                ctx.SaveChanges();
                                result = true;
                                break;

                            case (int)EnumHelper.Status.Draft:
                                result = StaffAddressEx.Delete(userId);
                                break;
                        }

                        // 2012.04.04 paulus: 把 login 的資料一並刪除
                        UserProfile.DelRec(staff.StaffId);
                    }

                    // log activity
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, staff.ToString());
                }
            }
            return result;
        }

        public static bool IsSuperUser(Guid userId)
        {
            bool result = false;

            var staff = StaffEx.GetByStaffId(userId);
            if (staff != null)
            {
                if (staff.CreatedBy == Guid.Empty)
                {
                    result = true;
                }
            }

            return result;
        }

        public static Guid GetSuperStaffId()
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                String sql = String.Format("CreatedBy = '{0}'", Guid.Empty.ToString());
                var staff = ctx.Staff.Where(x => x.CreatedBy == Guid.Empty).AsNoTracking().FirstOrDefault();
                if (staff != null)
                {
                    result = staff.StaffId;
                }
            }
            return result;
        }
    }

    public class UserProfile
    {
        public static bool SaveRec(Guid userSid, int userType, String loginName, String loginPassword, String alias)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var user = ctx.UserProfile.Where(x => x.UserSid == userSid).FirstOrDefault();
                    if (user == null)
                    {
                        user = new EF6.UserProfile();
                        user.UserId = Guid.NewGuid();
                        user.UserSid = userSid;
                        ctx.UserProfile.Add(user);
                    }
                    user.UserType = userType;
                    user.LoginName = loginName;
                    user.LoginPassword = loginPassword;
                    user.Alias = alias;

                    ctx.SaveChanges();
                    result = true;
                }
                catch { }
            }

            return result;
        }

        public static bool DelRec(Guid userSid)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var user = ctx.UserProfile.Where(x => x.UserSid == userSid).FirstOrDefault();

                    if (user != null)
                    {
                        ctx.UserProfile.Remove(user);
                        ctx.SaveChanges();
                        result = true;
                    }
                }
                catch { }
            }

            return result;
        }

        public static Guid GetSuperUserId()
        {
            return UserProfileEx.GetUserIdBySid(Staff.GetSuperStaffId());
        }
    }

    public class Data
    {
        /// <summary>
        /// Appends the different Order Type with Icons to a ContextMenu
        /// </summary>
        /// <param name="ddlMenu"></param>
        public static void AppendMenuItem_OrderType(ref ContextMenu ddlMenu)
        {
            ddlMenu.MenuItems.Add(new MenuItem("Upload File", string.Empty, "UploadFile"));
            ddlMenu.MenuItems.Add(new MenuItem("Direct Print", string.Empty, "DirectPrint"));
            ddlMenu.MenuItems.Add(new MenuItem("PS File", string.Empty, "PsFile"));
            ddlMenu.MenuItems.Add(new MenuItem("Others", string.Empty, "Others"));

            ddlMenu.MenuItems[0].Icon = new IconResourceHandle("JobOrder.UploadFile_16.png");
            ddlMenu.MenuItems[1].Icon = new IconResourceHandle("JobOrder.DirectPrint_16.png");
            ddlMenu.MenuItems[2].Icon = new IconResourceHandle("JobOrder.PsFile_16.png");
            ddlMenu.MenuItems[3].Icon = new IconResourceHandle("JobOrder.Others_16.png");
        }

        public static void AppendMenuItem_AppViews(ref ContextMenu ddlViews)
        {
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("icon_view"), string.Empty, "Icon"));
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("tile_view"), string.Empty, "Tile"));
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("list_view"), string.Empty, "List"));
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("details_view"), string.Empty, "Details"));

            ddlViews.MenuItems[0].Icon = new IconResourceHandle("16x16.appView_icons.png");
            ddlViews.MenuItems[1].Icon = new IconResourceHandle("16x16.appView_tile.png");
            ddlViews.MenuItems[2].Icon = new IconResourceHandle("16x16.appView_columns.png");
            ddlViews.MenuItems[3].Icon = new IconResourceHandle("16x16.appView_list.png");
        }

        public static void AppendMenuItem_AppPref(ref ContextMenu ddlViews)
        {
            ddlViews.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("toolbar.preference.save", "Tools"), string.Empty, "Save"));
            ddlViews.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("toolbar.preference.reset", "Tools"), string.Empty, "Reset"));

            ddlViews.MenuItems[0].Icon = new IconResourceHandle("16x16.application_add.png");
            ddlViews.MenuItems[1].Icon = new IconResourceHandle("16x16.application_delete.png");
        }

        public static void AppendMenuItem_AppImageList(ref ContextMenu ddlViews)
        {
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("small_image"), string.Empty, "Small"));
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("medium_image"), string.Empty, "Medium"));
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("large_image"), string.Empty, "Large"));
            ddlViews.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("details_image"), string.Empty, "Details"));

            ddlViews.MenuItems[0].Icon = new IconResourceHandle("16x16.imagelist_small_on_16.png");
            ddlViews.MenuItems[1].Icon = new IconResourceHandle("16x16.imagelist_medium_on_16.png");
            ddlViews.MenuItems[2].Icon = new IconResourceHandle("16x16.imagelist_large_on_16.png");
            ddlViews.MenuItems[3].Icon = new IconResourceHandle("16x16.imagelist_detail_on_16.png");
        }

        public static void LoadCombo_CreditLimmit(ref ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("0");
            comboBox.Items.Add("30");
            comboBox.Items.Add("60");
            comboBox.Items.Add("90");
            comboBox.SelectedIndex = 0;
        }

        public static void LoadCombo_Language(ref ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("English");
            comboBox.Items.Add("Simpified Chinese");
            comboBox.Items.Add("Traditional Chinese");
            comboBox.SelectedIndex = 0;
        }

        public static void LoadCombo_XchgBase(ref ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Foreign --> Local");
            comboBox.Items.Add("Local --> Foreign");
            comboBox.SelectedIndex = 0;
        }
    }

    public class Member
    {
        public static String GetNextVipNumber(bool PadTo13Digits)
        {
            String result = String.Empty;

            string sql = "SELECT MAX(VipNumber) + 1 FROM MemberVipData WHERE LEN(VipNumber) > 6 AND SUBSTRING(VipNumber, 1, 1) > CHAR(48) AND SUBSTRING(VipNumber, 1, 1) < CHAR(57)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings[""]);
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0).ToString();
                    if (PadTo13Digits)
                    {
                        result = result.PadLeft(13, '0');
                    }
                }
            }

            return result;
        }
    }

    public class Workplace
    {
        public static void LoadComboBox_Shops(ref ComboBox target)
        {
            String shop = "3";
            if (WorkplaceNatureEx.IsNatureCodeInUse("3"))
            {
                string[] textField = { "WorkplaceCode", "WorkplaceName" };
                string pattern = "{0} - {1}";
                string[] orderBy = { "WorkplaceCode" };

                WorkplaceEx.LoadCombo(ref target, textField, pattern, true, true, String.Empty, String.Empty, orderBy);
            }
        }
    }
}
