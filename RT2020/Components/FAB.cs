#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Common.Helper;

#endregion Using

namespace RT2020.Components
{
    /// <summary>
    /// A button control
    /// </summary>
    [Skin(typeof(FABSkin))]
    [Serializable()]
    public class FAB : Button
    {
        public FAB()
        {
            this.CustomStyle = "FABSkin";

            this.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.Cursor = Cursors.Hand;
            this.FlatAppearance.BorderColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.Image = new IconResourceHandle(ThemeHelper.GetIconThemed(".48.mdi-plus.circle.png"));
            this.ImageSize = new Size(32, 32);
            this.Size = new Size(48, 48);
            this.TextImageRelation = TextImageRelation.ImageAboveText;
            this.TabStop = false;
        }
    }

}
