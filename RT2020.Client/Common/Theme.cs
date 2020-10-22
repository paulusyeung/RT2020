using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RT2020.Client.Common.Theme
{
    class Breadcrumb
    {
        /// <summary>
        /// #6489D4 to #466094
        /// </summary>
        /// <returns></returns>
        public static Color BackColor()
        {
            return Color.FromArgb(255, Convert.ToInt32("64", 16), Convert.ToInt32("89", 16), Convert.ToInt32("D4", 16));
        }

        /// <summary>
        /// Transparent
        /// </summary>
        /// <returns></returns>
        public static Color BorderColor()
        {
            return Color.FromName("Transparent");
        }
    }

    class Workspace
    {
        /// <summary>
        /// #ACC0E9
        /// </summary>
        /// <returns></returns>
        public static Color BackColor()
        {
            return Color.FromArgb(255, Convert.ToInt32("AC", 16), Convert.ToInt32("C0", 16), Convert.ToInt32("E9", 16));
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
