using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT2020.Helper
{
    public static class DesktopHelper
    {
        /// <summary>
        /// Refreshes the main list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RefreshMainList<T>()
        {
            var desktop = VWGContext.Current.MainForm as RT2020.Desktop;

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
    }
}
