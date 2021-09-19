using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RT2020.Common.Helper
{
    public class BotHelper
    {
        /// <summary>
        /// Random 生成 Member Phone Numbers
        /// 射去 Bot Server，利用 Hangfire 做 Background Job
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool PostSuperUser_GenPhonenumbers(Guid userId)
        {
            String botServer = ConfigurationManager.AppSettings["BotServer"];

            var client = new RestClient(botServer);
            var request = new RestRequest(
                String.Format("SuperUser/GenMemberPhoneNumbers/{0}/", userId.ToString()),
                Method.POST
                );
            request.RequestFormat = DataFormat.Json;

            //! 2020.11.13 paulus: request.AddBody is deprecated
            request.AddJsonBody(new
            {
                UserId = userId.ToString(),
                AnotherParam = 19.99
            });
            var result = client.Execute(request);
            return (result.StatusCode == System.Net.HttpStatusCode.Accepted ? true : false);
        }
    }
}