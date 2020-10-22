using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

using RT2020.DAL;

namespace RT2020.Client.Common
{

	class SignOnPrincipal
	{
		//private static ResourceManager m_ResMg = new ResourceManager("HKe._resx.Messages", System.Reflection.Assembly.GetExecutingAssembly());

		private SignOnPrincipal()
		{
		}

		public static void SignOnIdentity(string userName, string password)
		{
			if (IsIdentity(userName, password))
			{
				// Create generic identity.
				GenericIdentity MyIdentity = new GenericIdentity(userName);

				// Create generic principal.
				//String[] MyStringArray = { "Zone", warehouseId.ToString("N") };
				string[] MyStringArray = new string[0];
				GenericPrincipal MyPrincipal =
					new GenericPrincipal(MyIdentity, MyStringArray);

				// Attach the principal to the current thread.
				// This is not required unless repeated validation must occur,
				// other code in your application must validate, or the 
				// PrincipalPermisson object is used. 
				Thread.CurrentPrincipal = MyPrincipal;
			}
			else
			{
				//MessageBox.Show(string.Format(m_ResMg.GetString("login_error_msg"), userName, ZoneName(warehouseId)), "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				MessageBox.Show("User Name does not match the password, Please check!", "Logon failed", MessageBoxButtons.RetryCancel);
			}
		}

		private static bool IsIdentity(string userName, string password)
		{
			bool result = false;

			string sql = "StaffNumber = '" + userName + "' AND Password = '" + password + "'";
            DAL.Staff oUser = DAL.Staff.LoadWhere(sql);
            if (oUser != null)
            {
                RT2020.DAL.Common.Config.CurrentUserId = oUser.StaffId;
                result = true;
            }

            return result;    // result;
		}
	}
}
