#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_MarketingInfo : UserControl
    {
        public MemberWizard_MarketingInfo()
        {
            InitializeComponent();
        }

        #region Properties
        private Guid memberId = System.Guid.Empty;
        public Guid MemberId
        {
            get
            {
                return memberId;
            }
            set
            {
                memberId = value;
            }
        }
        #endregion
    }
}