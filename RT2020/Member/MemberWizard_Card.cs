#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_Card : UserControl
    {
        #region Properties
        private Guid _MemberId = System.Guid.Empty;
        public Guid MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        #endregion

        public MemberWizard_Card()
        {
            InitializeComponent();

            SetCaptions();
        }

        private void SetCaptions()
        {
            lblFormerPPNumber.Text = WestwindHelper.GetWordWithColon("memberVipData.formerPP", "Model");
            lblCommencementDate.Text = WestwindHelper.GetWordWithColon("memberVipData.dateOfCommencement", "Model");
            lblMigrationDate.Text = WestwindHelper.GetWordWithColon("memberVipData.dateOfMigration", "Model");
            lblCardIssuedOn.Text = WestwindHelper.GetWordWithColon("memberVipData.cardIssuedOn", "Model");
            lblCardExpiredOn.Text = WestwindHelper.GetWordWithColon("memberVipData.cardExpiredOn", "Model");
            lblCardName.Text = WestwindHelper.GetWordWithColon("memberVipData.cardHolderName", "Model");
            lblCardReceived.Text = WestwindHelper.GetWordWithColon("memberVipData.cardReceived", "Model");
            lblCardActived.Text = WestwindHelper.GetWordWithColon("memberVipData.cardActivated", "Model");
        }
    }
}