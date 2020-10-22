using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RT2020.Settings.MonthEndProcess
{
    public interface IStep
    {
        event Controls.ProgressUpdateEventHandler UpdatedProgress;
        void DoAction();
    }
}
