#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Helper;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_Marketing : UserControl
    {
        #region Properties
        private Guid _MemberId = System.Guid.Empty;
        public Guid MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        #endregion

        public MemberWizard_Marketing()
        {
            InitializeComponent();

            SetCaptions();
        }

        #region SetCaptions & SetAttributes
        private void SetCaptions()
        {
            lblMostBoughtBrands.Text = WestwindHelper.GetWordWithColon("member.marketing.MFBB", "Model");
            lblMostReadMagazine.Text = WestwindHelper.GetWordWithColon("member.marketing.MFRM", "Model");
            lblMostUsedCreditCards.Text = WestwindHelper.GetWordWithColon("member.marketing.MFUCC", "Model");
            lblMostVisitedMalls.Text = WestwindHelper.GetWordWithColon("member.marketing.MFVM", "Model");
        }

        private void SetAttributes()
        {

        }
        #endregion
    }
}