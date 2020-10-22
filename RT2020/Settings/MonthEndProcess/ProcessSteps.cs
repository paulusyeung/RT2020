using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using RT2020.Controls;

namespace RT2020.Settings.MonthEndProcess
{
    public class ProcessSteps
    {
        public event ProgressUpdateEventHandler UpdatedProgress;

        public bool ResetServiceItemCDQty = false;
        public DateTime StartOn = DateTime.Now;
        public string PostedErrorMsg = string.Empty;

        public void Process()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Start Processing...", 1, 100));

            Assembly assem = Assembly.GetExecutingAssembly();
            string className = "RT2020.Settings.MonthEndProcess.Step";

            for (int i = 1; i <= 10; i++)
            {
                UpdatedProgress(this, new ProgressUpdateEventArgs("Step" + i.ToString().PadLeft(2, '0') + " Start Processing ...", 1, 100));

                if (i == 10)
                {
                    Step10 objStep10 = new Step10();
                    objStep10.ResetSerivceItemsCDQty = this.ResetServiceItemCDQty;
                    objStep10.StartOn = this.StartOn;
                    objStep10.PostedErrorMsg = this.PostedErrorMsg;
                    objStep10.UpdatedProgress += new ProgressUpdateEventHandler(objStep_UpdatedProgress);
                    objStep10.DoAction();
                }
                else
                {
                    Type packetType = assem.GetType(className + i.ToString().PadLeft(2, '0'));
                    if (packetType != null)
                    {
                        Object obj = Activator.CreateInstance(packetType);

                        IStep objStep = obj as IStep;
                        if (objStep != null)
                        {
                            objStep.UpdatedProgress += new ProgressUpdateEventHandler(objStep_UpdatedProgress);
                            objStep.DoAction();
                        }
                    }
                }
            }

            UpdatedProgress(this, new ProgressUpdateEventArgs("End Processing...", 99, 100));
        }

        /// <summary>
        /// Handles the UpdatedProgress event of the objStep control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RT2020.SettingsMonthEndCommon.ProgressUpdateEventArgs"/> instance containing the event data.</param>
        void objStep_UpdatedProgress(object sender, ProgressUpdateEventArgs e)
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs(e.Message, e.Position, e.Total));
        }
    }
}
