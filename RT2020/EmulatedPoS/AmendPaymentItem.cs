#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;


using System.Linq;
using System.Data.Entity;

using RT2020.Common.ModelEx;

#endregion

namespace RT2020.EmulatedPoS
{
    /// <summary>
    /// AmendPaymentItem
    /// </summary>
    public partial class AmendPaymentItem : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmendPaymentItem"/> class.
        /// </summary>
        public AmendPaymentItem()
        {
            InitializeComponent();

            FillTypeList();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Fill Combo List
        /// <summary>
        /// Fills the type list.
        /// </summary>
        private void FillTypeList()
        {
            RT2020.Controls.Utility.LoadPosTenderTypeToCombo(ref cboTypeCode);
        }
        #endregion

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTypeCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTypeCode.SelectedValue.ToString() != "RT2020.DAL.Common+ComboItem")
            {
                cboCurrencyCode.Items.Clear();

                string sqlWhere = "TypeCode='" + cboTypeCode.Text + "'";
                using (var ctx = new EF6.RT2020Entities())
                {
                    var posTypeCollection = ctx.PosTenderType.Where(x => x.TypeCode == cboTypeCode.Text).AsNoTracking().ToList(); ;
                    foreach (var posType in posTypeCollection)
                    {
                        cboCurrencyCode.Items.Add(posType.CurrencyCode);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the values.
        /// </summary>
        /// <param name="typeCode">The type code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="card">The card.</param>
        /// <param name="authorize">The authorize.</param>
        public void SetValues(string typeCode,string currencyCode,string amount,string card,string authorize)
        {
            if (typeCode == "")
            {
                cboTypeCode.SelectedIndex = 0;
            }
            else
            {
                cboTypeCode.Text = typeCode;
            }
            if (currencyCode == "")
            {
                cboCurrencyCode.SelectedIndex = 0;
            }
            else
            {
                cboCurrencyCode.Text = currencyCode;
            }
            txtAmount.Text = amount;
            txtCardChq.Text = card;
            txtAuthorize.Text = authorize;
        }

        /// <summary>
        /// Sets the values.
        /// </summary>
        /// <param name="typeCode">The type code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="card">The card.</param>
        /// <param name="authorize">The authorize.</param>
        public void SetValues(string typeCode, string currencyCode, string amount, string exchangeRate, string card, string authorize)
        {
            if (typeCode == "")
            {
                cboTypeCode.SelectedIndex = 0;
            }
            else
            {
                cboTypeCode.Text = typeCode;
            }
            if (currencyCode == "")
            {
                cboCurrencyCode.SelectedIndex = 0;
            }
            else
            {
                cboCurrencyCode.Text = currencyCode;
            }
            txtAmount.Text = amount;
            txtXchgRate.Text = exchangeRate;
            txtCardChq.Text = card;
            txtAuthorize.Text = authorize;
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Returns the values.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <param name="typeCode">The type code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="amtHkd">The amt HKD.</param>
        /// <param name="card">The card.</param>
        /// <param name="authorize">The authorize.</param>
        public void ReturnValues(ref Guid typeId,ref string typeCode, ref string currencyCode, ref string amount, ref string exchangeRate, ref string amtHkd, ref string card, ref string authorize)
        {
            //string sqlWhere = "TypeCode = '" + cboTypeCode.Text + "' AND CurrencyCode = '" + cboCurrencyCode.Text + "'";
            //RT2020.DAL.PosTenderType posTender = RT2020.DAL.PosTenderType.LoadWhere(sqlWhere);
            typeId = PosTenderTypeEx.GetId(typeCode, currencyCode);
            typeCode = cboTypeCode.Text;
            currencyCode = cboCurrencyCode.Text;
            amount = txtAmount.Text;
            exchangeRate = txtXchgRate.Text;
            amtHkd = txtAmountHkd.Text;
            card = txtCardChq.Text;
            authorize = txtAuthorize.Text;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboCurrencyCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboCurrencyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sqlWhere = "TypeCode = '" + cboTypeCode.Text + "' AND CurrencyCode = '" + cboCurrencyCode.Text + "'";
            //RT2020.DAL.PosTenderType posType = RT2020.DAL.PosTenderType.LoadWhere(sqlWhere);
            txtXchgRate.Text = PosTenderTypeEx.GetExchageRte(cboTypeCode.Text, cboCurrencyCode.Text).ToString("n4");
        }

        /// <summary>
        /// Handles the TextChanged event of the txtAmount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            txtAmountHkd.Text = txtAmount.Text;
        }
    }
}