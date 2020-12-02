using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using Gizmox.WebGUI.Common.Resources;

namespace RT2020.Controls
{
    /// <summary>
    /// Page Preference
    /// </summary>
    public class PagePreference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSettings"/> class.
        /// </summary>
        public PagePreference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagePreference"/> class.
        /// </summary>
        /// <param name="pageId">The page id.</param>
        public PagePreference(Guid pageId)
        {
            this.pageId = pageId;
            this.sql = string.Format(this.sql, this.PageId.ToString());
        }

        #region Variables

        private string preferredLayout = string.Empty;
        private string staffForSearch = string.Empty;
        private string preferredView = string.Empty;
        private Guid pageId = Guid.Empty;

        private string sql = "StaffId = '" + Common.Config.CurrentUserId.ToString() + "' AND PageId = '{0}'";

        #endregion

        #region Propeties

        /// <summary>
        /// Gets or sets the preferred layout.
        /// </summary>
        /// <value>The preferred layout.</value>
        public string PreferredLayout
        {
            get
            {
                return this.preferredLayout;
            }
            set
            {
                this.preferredLayout = value;
            }
        }

        /// <summary>
        /// Gets or sets the staff for search.
        /// </summary>
        /// <value>The staff for search.</value>
        public string StaffForSearch
        {
            get
            {
                return this.staffForSearch;
            }
            set
            {
                this.staffForSearch = value;
            }
        }

        /// <summary>
        /// Gets or sets the preferred view.
        /// </summary>
        /// <value>The preferred view.</value>
        public string PreferredView
        {
            get
            {
                return this.preferredView;
            }
            set
            {
                this.preferredView = value;
            }
        }

        /// <summary>
        /// Gets or sets the page id.
        /// </summary>
        /// <value>The page id.</value>
        public Guid PageId
        {
            get
            {
                return this.pageId;
            }
            set
            {
                this.pageId = value;
            }
        }

        #endregion
    }
}
