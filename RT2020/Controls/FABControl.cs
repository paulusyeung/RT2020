using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.Controls
{
    public class FABControl
    {
        PictureBox fab = new PictureBox()
        {
            Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right))),
            Cursor = Cursors.Hand,
            Image = new IconResourceHandle(ThemeHelper.GetIconThemed(".48.mdi-plus.circle.png")),
            Location = new System.Drawing.Point(411, 252),
            Name = "cmdAddNew",
            Size = new System.Drawing.Size(48, 48),
            //TabIndex = 2,
            TabStop = false,
            //SetToolTip(cmdAddNew, "Add New"),
        };
    }
}