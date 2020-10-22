using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Controls
{
    public interface IWizard
    {
        void AddItemByList(List<RT2020.Controls.ProductSearcher.DetailData> resultList);
        List<RT2020.Controls.ProductSearcher.DetailData> SetDetailData(string STKCODE);
    }
}
