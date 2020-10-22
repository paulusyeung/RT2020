#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Controls
{
    public partial class PostingMessageForm : Form
    {
        public PostingMessageForm()
        {
            InitializeComponent();
        }

        public DataRow[] RowList { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ShowMessage();
        }

        private void ShowMessage()
        {
            if (RowList.Length > 0)
            {
                string txNumber = string.Empty;
                StringBuilder message = new StringBuilder();

                for (int i = 0; i < RowList.Length; i++)
                {
                    if (i == 0)
                    {
                        this.Text = Utility.Dictionary.GetWord("Posting Message") + " [" + RowList[i]["TxNumber"].ToString() + "]";

                        txNumber = RowList[i]["TxNumber"].ToString();
                        message.Append(Utility.Dictionary.GetWordWithColon("TxNumber")).Append(txNumber).AppendLine();
                        message.Append(Utility.Dictionary.GetWordWithColon("Post Date")).Append(RowList[i]["PostDate"].ToString()).AppendLine();
                        message.Append(Utility.Dictionary.GetWordWithColon("Error")).AppendLine();

                        lblHeaderId.Text = RowList[i]["HeaderId"].ToString();
                    }

                    if (txNumber == RowList[i]["TxNumber"].ToString())
                    {
                        message.Append("          ").Append((i + 1).ToString()).Append(". ").Append(RowList[i]["ErrorReason"].ToString()).AppendLine();
                    }

                    if (RowList[i]["STKCODE"].ToString().Length > 0)
                    {
                        message.Append("          " + Utility.Dictionary.GetWordWithColon("Product")).Append(RowList[i]["STKCODE"].ToString());
                        message.Append(" ").Append(RowList[i]["APPENDIX1"].ToString());
                        message.Append(" ").Append(RowList[i]["APPENDIX2"].ToString());
                        message.Append(" ").Append(RowList[i]["APPENDIX3"].ToString());
                        message.AppendLine();
                    }
                }

                if (message.Length > 0)
                {
                    txtMessage.Text = message.ToString();
                }
            }
        }
    }
}