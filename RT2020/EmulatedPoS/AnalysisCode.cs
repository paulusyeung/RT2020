#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.DAL;

#endregion

namespace RT2020.EmulatedPoS
{
    public partial class AnalysisCode : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisCode"/> class.
        /// </summary>
        public AnalysisCode()
        {
            InitializeComponent();

            FillAnalysisList();

            cboAnalysisCode01.Text = "";
            cboAnalysisCode02.Text = "";
            cboAnalysisCode03.Text = "";
            cboAnalysisCode04.Text = "";
            cboAnalysisCode05.Text = "";
            cboAnalysisCode06.Text = "";
            cboAnalysisCode07.Text = "";
            cboAnalysisCode08.Text = "";
            cboAnalysisCode09.Text = "";
            cboAnalysisCode10.Text = "";
        }

        #region Properties
        private string analysisCode01;
        /// <summary>
        /// Gets or sets the analysis code01.
        /// </summary>
        /// <value>The analysis code01.</value>
        public string AnalysisCode01
        {
            get { return analysisCode01; }
            set { analysisCode01 = value; }
        }

        private string analysisCode02;
        /// <summary>
        /// Gets or sets the analysis code02.
        /// </summary>
        /// <value>The analysis code02.</value>
        public string AnalysisCode02
        {
            get { return analysisCode02; }
            set { analysisCode02 = value; }
        }

        private string analysisCode03;
        /// <summary>
        /// Gets or sets the analysis code03.
        /// </summary>
        /// <value>The analysis code03.</value>
        public string AnalysisCode03
        {
            get { return analysisCode03; }
            set { analysisCode03 = value; }
        }

        private string analysisCode04;
        /// <summary>
        /// Gets or sets the analysis code04.
        /// </summary>
        /// <value>The analysis code04.</value>
        public string AnalysisCode04
        {
            get { return analysisCode04; }
            set { analysisCode04 = value; }
        }

        private string analysisCode05;
        /// <summary>
        /// Gets or sets the analysis code05.
        /// </summary>
        /// <value>The analysis code05.</value>
        public string AnalysisCode05
        {
            get { return analysisCode05; }
            set { analysisCode05 = value; }
        }

        private string analysisCode06;
        /// <summary>
        /// Gets or sets the analysis code06.
        /// </summary>
        /// <value>The analysis code06.</value>
        public string AnalysisCode06
        {
            get { return analysisCode06; }
            set { analysisCode06 = value; }
        }

        private string analysisCode07;
        /// <summary>
        /// Gets or sets the analysis code07.
        /// </summary>
        /// <value>The analysis code07.</value>
        public string AnalysisCode07
        {
            get { return analysisCode07; }
            set { analysisCode07 = value; }
        }

        private string analysisCode08;
        /// <summary>
        /// Gets or sets the analysis code08.
        /// </summary>
        /// <value>The analysis code08.</value>
        public string AnalysisCode08
        {
            get { return analysisCode08; }
            set { analysisCode08 = value; }
        }

        private string analysisCode09;
        /// <summary>
        /// Gets or sets the analysis code09.
        /// </summary>
        /// <value>The analysis code09.</value>
        public string AnalysisCode09
        {
            get { return analysisCode09; }
            set { analysisCode09 = value; }
        }

        private string analysisCode10;
        /// <summary>
        /// Gets or sets the analysis code10.
        /// </summary>
        /// <value>The analysis code10.</value>
        public string AnalysisCode10
        {
            get { return analysisCode10; }
            set { analysisCode10 = value; }
        }
        #endregion

        /// <summary>
        /// Fills the analysis list.
        /// </summary>
        private void FillAnalysisList()
        {
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode01, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("01"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode02, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("02"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode03, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("03"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode04, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("04"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode05, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("05"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode06, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("06"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode07, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("07"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode08, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("08"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode09, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("09"), null);
            RT2020.DAL.PosAnalysisCode.LoadCombo(ref cboAnalysisCode10, new string[] { "AnalysisCode", "CodeName" }, "{0} {1}", false, false, string.Empty, string.Empty, GetAnalysisSqlCondition("10"), null);
        }

        /// <summary>
        /// Gets the analysis SQL condition.
        /// </summary>
        /// <param name="analysisParentCode">The analysis parent code.</param>
        /// <returns></returns>
        private string GetAnalysisSqlCondition(string analysisParentCode)
        {
            string sqlWhere = "ParentCode = (select AnalysisCodeId from PosAnalysisCode where AnalysisCode = '" + analysisParentCode + "')";
            return sqlWhere;
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.analysisCode01 = cboAnalysisCode01.Text;
            this.analysisCode02 = cboAnalysisCode02.Text;
            this.analysisCode03 = cboAnalysisCode03.Text;
            this.analysisCode04 = cboAnalysisCode04.Text;
            this.analysisCode05 = cboAnalysisCode05.Text;
            this.analysisCode06 = cboAnalysisCode06.Text;
            this.analysisCode07 = cboAnalysisCode07.Text;
            this.analysisCode08 = cboAnalysisCode08.Text;
            this.analysisCode09 = cboAnalysisCode09.Text;
            this.analysisCode10 = cboAnalysisCode10.Text;

            if (this.AnalysisCode01 == "")
            {
                MessageBox.Show("Bill must be checked!", "Posting result", MessageBoxButtons.OK);
            }
            else
            {
                this.Visible = false;
            }
        }

        /// <summary>
        /// Sets the analysis code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="index">The index.</param>
        public void SetAnalysisCode(string code, string index)
        {
            switch (index)
            {
                case "01":
                    cboAnalysisCode01.Text = code;
                    break;
                case "02":
                    cboAnalysisCode02.Text = code;
                    break;
                case "03":
                    cboAnalysisCode03.Text = code;
                    break;
                case "04":
                    cboAnalysisCode04.Text = code;
                    break;
                case "05":
                    cboAnalysisCode05.Text = code;
                    break;
                case "06":
                    cboAnalysisCode06.Text = code;
                    break;
                case "07":
                    cboAnalysisCode07.Text = code;
                    break;
                case "08":
                    cboAnalysisCode08.Text = code;
                    break;
                case "09":
                    cboAnalysisCode09.Text = code;
                    break;
                case "10":
                    cboAnalysisCode10.Text = code;
                    break;
            }
        }
    }
}