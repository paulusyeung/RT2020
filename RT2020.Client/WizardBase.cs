using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using RT2020.DAL;
using System.Text.RegularExpressions;

namespace RT2020.Client
{
    #region Enums
    public enum State
    {
        Loading,
        Loaded,
        Closing
    }

    public enum Modified
    {
        Clean,
        Dirty
    }

    public enum HandleEvents
    {
        Default,
        Busy,
        Noise
    }

    public enum Mode
    {
        New,
        Edit,
        Read
    }
    #endregion

    public partial class WizardBase : Form
    {
        private Mode _EditMode = Mode.New;
        private State _FormState;
        private Modified _FormChanged;
        private HandleEvents _FormEventHandling;
        private EventHandler toolStripHandler;

        public WizardBase()
        {
            InitializeComponent();
        }

        #region Properties
        [Browsable(true)]
        [Description("The load state of the form")]
        public State FormState
        {
            get
            {
                return _FormState;
            }
            set
            {
                _FormState = value;
            }
        }

        [Browsable(true)]
        [Description("If control contents have been modified")]
        public Modified FormChanged
        {
            get
            {
                return _FormChanged;
            }
            set
            {
                _FormChanged = value;
            }
        }

        [Browsable(true)]
        [Description("whether to ignore or process events")]
        public HandleEvents FormEventHandling
        {
            get
            {
                return _FormEventHandling;
            }
            set
            {
                _FormEventHandling = value;
            }
        }
        [Browsable(true)]
        [Description("The edit mode of the form")]
        public Mode EditMode
        {
            get
            {
                return _EditMode;
            }
            set
            {
                _EditMode = value;
            }
        }
        #endregion

        #region Form Events
        protected virtual void WizardBase_Load(object sender, EventArgs e)
        {
            this.wspPane.BackColor = Common.Theme.Workspace.BackColor();
            this.Text += string.Format(" [{0}]", this.EditMode.ToString());
            FormState = State.Loading;
        }

        protected void WizardBase_Activated(object sender, EventArgs e)
        {
            if (FormState == State.Loading)
            {
                FormState = State.Loaded;
            }
        }

        private void WizardBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormChanged == Modified.Dirty)
            {
                DialogResult result = MessageBox.Show("Save changes before close?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    toolStripHandler = new EventHandler(cmdSaveClose_Click);
                    this.Invoke(toolStripHandler, new object[] { sender, new EventArgs() });
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        public void SetFormToBeDirty()
        {
            if (FormState == State.Loaded)
            {
                FormChanged = Modified.Dirty;
            }
        }

        #region ToolStrip Events
        protected virtual void cmdSave_Click(object sender, EventArgs e)
        {
        }

        protected virtual void cmdSaveNew_Click(object sender, EventArgs e)
        {
        }

        protected virtual void cmdSaveClose_Click(object sender, EventArgs e)
        {
        }

        protected virtual void ansAddNew_Click(object sender, EventArgs e)
        {
        }

        protected virtual void cmdDelete_Click(object sender, EventArgs e)
        {
        }

        protected virtual void ansRefresh_Click(object sender, EventArgs e)
        {
        }

        protected virtual void cmdApproval_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
