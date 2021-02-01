using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
    public class MenuHelper
    {
        public class MenuTag
        {
            private string resourceId;
            private bool isPopup;

            public MenuTag()
            {

            }

            public MenuTag(string resourceId, bool isPopup)
            {
                this.resourceId = resourceId;
                this.isPopup = isPopup;
            }

            public string ResourceId
            {
                get { return resourceId; }
                set { resourceId = value; }
            }
            public bool IsPopup
            {
                get { return isPopup; }
                set { isPopup = value; }
            }
        }
    }
}