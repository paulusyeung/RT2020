using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RT2020.Helper
{
    class SystemInfoHelper
    {
        /// <summary>
        /// System Settings
        /// </summary>
        public class Settings
        {
            /// <summary>
            /// Queuings the tx number.
            /// </summary>
            /// <param name="txType">Type of the transactions.</param>
            /// <returns></returns>
            public static string QueuingTxNumber(EnumHelper.TxType txType)
            {
                return QueuingTxNumber<EnumHelper.TxType>(txType);
            }

            /// <summary>
            /// Queuings the tx number.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="typeName">Name of the type. Enums: EnumHelper.TxType, EnumHelper.POType</param>
            /// <returns>TxNumber</returns>
            public static string QueuingTxNumber<T>(T typeName)
            {
                string query = " 1 = 1 ";
                string queuingType = string.Empty;

                switch (typeName.GetType().Name)
                {
                    case "TxType":
                        EnumHelper.TxType txType = (EnumHelper.TxType)Convert.ChangeType(typeName, typeof(EnumHelper.TxType));
                        query = "QueuingType = '" + txType.ToString() + "'";
                        queuingType = txType.ToString();
                        break;
                    case "POType":
                        EnumHelper.POType poType = (EnumHelper.POType)Convert.ChangeType(typeName, typeof(EnumHelper.POType));
                        query = "QueuingType = '" + poType.ToString() + "'";
                        queuingType = poType.ToString();
                        break;
                }

                long queuedTxNumber = 1;

                using (var ctx = new EF6.RT2020Entities())
                {
                    var oQueue = ctx.SystemQueue.SqlQuery(
                        String.Format(
                            "Select * from SystemQueue Where {0}",
                            String.IsNullOrEmpty(query) ? "1 = 1" : query
                        ))
                        .FirstOrDefault();
                    if (oQueue == null)
                    {
                        oQueue = new EF6.SystemQueue();
                        oQueue.QueueId = Guid.NewGuid();
                        oQueue.QueuingType = queuingType;
                        oQueue.LastNumber = "000000000000";
                        ctx.SystemQueue.Add(oQueue);
                    }

                    queuedTxNumber = Convert.ToInt64(oQueue.LastNumber) + 1;

                    oQueue.LastNumber = queuedTxNumber.ToString();
                    ctx.SaveChanges();
                }

                return queuedTxNumber.ToString().PadLeft(12, '0');
            }

            /// <summary>
            /// Gets the system label by key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <returns></returns>
            public static string GetSystemLabelByKey(string key)
            {
                string result = key;

                var oLabel = ModelEx.SystemLabelEx.GetByLanguageCode(ConfigHelper.CurrentLanguageCode);
                if (oLabel != null)
                {
                    PropertyInfo pi = oLabel.GetType().GetProperty(key.Trim().ToUpper());
                    if (pi != null)
                    {
                        result = pi.GetValue(oLabel, null).ToString();
                    }
                }

                return result;
            }

            /// <summary>
            /// Gets the qty decimal point.
            /// </summary>
            /// <returns></returns>
            public static int GetQtyDecimalPoint()
            {
                int result = 0;

                return result;
            }

            #region Refresh Main List View Panel

            /// <summary>
            /// Refreshes the main list.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public static void RefreshMainList<T>()
            {
                Desktop desktop = VWGContext.Current.MainForm as Desktop;

                Gizmox.WebGUI.Forms.Control[] ctrlList = desktop.Controls.Find("wspPane", true);
                if (ctrlList.Length > 0)
                {
                    for (int i = 0; i < ctrlList[0].Controls.Count; i++)
                    {
                        if (ctrlList[0].Controls[i].GetType().Equals(typeof(T)))
                        {
                            T list = (T)Convert.ChangeType(ctrlList[0].Controls[i], typeof(T));
                            var rtList = list as RT2020.Controls.IRTList;
                            rtList.BindRTList(true);
                        }
                    }
                }
            }
            #endregion

            /// <summary>
            /// Reads data from a stream until the end is reached. The
            /// data is returned as a byte array. An IOException is
            /// thrown if any of the underlying IO calls fail.
            /// </summary>
            /// <param name="stream">The stream to read data from</param>
            /// <param name="initialLength">The initial buffer length</param>
            public static byte[] ReadFully(Stream stream, long initialLength)
            {
                // If we've been passed an unhelpful initial length, just
                // use 32K.
                if (initialLength < 1)
                {
                    initialLength = 32768;
                }

                byte[] buffer = new byte[initialLength];
                int read = 0;

                int chunk;
                while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
                {
                    read += chunk;

                    // If we've reached the end of our buffer, check to see if there's
                    // any more information
                    if (read == buffer.Length)
                    {
                        int nextByte = stream.ReadByte();

                        // End of stream? If so, we're done
                        if (nextByte == -1)
                        {
                            return buffer;
                        }

                        // Nope. Resize the buffer, put in the byte we've just
                        // read, and continue
                        byte[] newBuffer = new byte[buffer.Length * 2];
                        Array.Copy(buffer, newBuffer, buffer.Length);
                        newBuffer[read] = (byte)nextByte;
                        buffer = newBuffer;
                        read++;
                    }
                }
                // Buffer is now too big. Shrink it.
                byte[] ret = new byte[read];
                Array.Copy(buffer, ret, read);
                return ret;
            }
        }

        /// <summary>
        /// Backgroud color for controls
        /// </summary>
        public class ControlBackColor
        {
            /// <summary>
            /// Gets the back color for disabled box.
            /// </summary>
            /// <value>the back color.</value>
            public static Color DisabledBox
            {
                get
                {
                    return Color.LightYellow;
                }
            }

            /// <summary>
            /// Gets the back color required box.
            /// </summary>
            /// <value>the back color.</value>
            public static Color RequiredBox
            {
                get
                {
                    return Color.PaleTurquoise;
                }
            }
        }
    }
}
