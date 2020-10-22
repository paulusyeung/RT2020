#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace RT2020.Web.Reports.Controls.CustomPanel
{
    public partial class CustomPanel : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomPanel"/> class.
        /// </summary>
        public CustomPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.UserControl.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #region Panels

        /// <summary>
        /// Fills the panel list.
        /// </summary>
        private void FillPanelList(object dataItem)
        {
            switch (this.PanelType)
            {
                case PanelEnums.PanelViews.CardView:
                    this.CardViewPane(dataItem);
                    break;
                case PanelEnums.PanelViews.Thumbnail:
                    this.ThumbnailsViewPane(dataItem);
                    break;
            }
        }

        /// <summary>
        /// view the Card view pane.
        /// </summary>
        private void CardViewPane(object dataItem)
        {
            CardView oPanel = new CardView();

            string tag = this.GetDataItem(dataItem, "Tag");

            oPanel.Name = "panel_" + tag;
            oPanel.Tag = tag;
            oPanel.Text = this.GetDataItem(dataItem, "Caption");
            oPanel.Description = this.GetDataItem(dataItem, "Description");

            string lastAccessedOn = this.GetDataItem(dataItem, "LastAccessedOn");
            if (lastAccessedOn.Trim().Length > 0)
            {
                DateTime acceessedOn = Convert.ToDateTime(lastAccessedOn);

                lastAccessedOn = acceessedOn.ToString("dd/MM/yyyy HH:mm");
            }

            oPanel.LastPrintedOn = lastAccessedOn;
            oPanel.Image = new IconResourceHandle(this.GetDataItem(dataItem, "Image_CardView"));
            //oPanel.Cursor = Cursors.Hand;
            oPanel.Click += new EventHandler(oPanel_Click);

            flowLayoutPanel.Controls.Add(oPanel);
        }

        /// <summary>
        /// views the thumbnails view pane.
        /// </summary>
        private void ThumbnailsViewPane(object dataItem)
        {
            ThumbnailsView oPanel = new ThumbnailsView();

            string tag = this.GetDataItem(dataItem, "Tag");

            oPanel.Name = "panel_" + tag;
            oPanel.Tag = tag;
            oPanel.Text = this.GetDataItem(dataItem, "Caption");
            //oPanel.LastPrintedOn = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            oPanel.Image = new IconResourceHandle(this.GetDataItem(dataItem, "Image_Thumb"));
            //oPanel.Cursor = Cursors.Hand;
            oPanel.Click += new EventHandler(oPanel_Click);

            flowLayoutPanel.Controls.Add(oPanel);
        }

        /// <summary>
        /// Handles the DoubleClick event of the oPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void oPanel_Click(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                Panel panel = sender as Panel;
                this.Tag = panel.Tag;
            }

            this.OnClick(e);
        }

        private PanelEnums.PanelViews panelType = PanelEnums.PanelViews.CardView;

        /// <summary>
        /// Gets or sets the type of the panel.
        /// </summary>
        /// <value>The type of the panel.</value>
        public PanelEnums.PanelViews PanelType
        {
            get
            {
                return panelType;
            }
            set
            {
                this.flowLayoutPanel.Controls.Clear();

                panelType = value;

                this.OnDataBinding(new EventArgs());
            }
        }

        #endregion

        #region Data Source Handler

        /// <summary>
        /// Data Source
        /// </summary>
        private object dataSource;

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Browsable(false)]
        public object DataSource
        {
            set
            {
                this.dataSource = value;
                this.OnDataBinding(new EventArgs());
            }
            get { return this.dataSource; }
        }

        /// <summary>
        /// Handle the data source
        /// </summary>
        /// <param name="source">data source</param>
        /// <returns>IEnumerable</returns>
        private IEnumerable GetResolvedDataSource(object source)
        {
            if (source is IEnumerable)
                return (IEnumerable)source;
            else if (source is IList)
                return (IEnumerable)source;
            else if (source is DataSet)
                return (IEnumerable)(((DataSet)source).Tables[0].DefaultView);
            else if (source is DataTable)
                return (IEnumerable)(((DataTable)source).DefaultView);
            else
                return null;
        }

        /// <summary>
        /// get data item from IEnumerable by using DataTextField
        /// </summary>
        /// <param name="item">date item in IEnumerable</param>
        /// <returns>string</returns>
        private string GetDataItem(object item, string dataTextField)
        {
            if (item is IDataRecord)
                return ((IDataRecord)item)[dataTextField].ToString();
            else if (item is DataRowView)
                return ((DataRowView)item)[dataTextField].ToString();
            else
                return item.ToString();
        }

        /// <summary>
        /// Raises the <see cref="E:DataBinding"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void OnDataBinding(EventArgs e)
        {
            if (this.dataSource != null)
            {
                // first load
                if (this.flowLayoutPanel.Controls.Count == 0)
                {
                    IEnumerable source = this.GetResolvedDataSource(this.dataSource);
                    IEnumerator item = source.GetEnumerator();
                    while (item.MoveNext())
                    {
                        FillPanelList(item.Current);
                    }
                }
            }
        }

        #endregion
    }
}