using RT2020.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using VWG.Community.Util;

namespace RT2020.Bot.Helper
{
    public class SuperUserHelper
    {
        public static void GenMemberPhoneNumbers(Guid id)
        {
            using (var ctx = new RT2020Entities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                #region Generate random phone numbers for each Member
                var mbrAddresses = ctx.MemberAddress.Where(x => x.PhoneTag1Value != "" || x.PhoneTag2Value != "").ToList();
                var counts = mbrAddresses.Count();
                if (counts > 0)
                {
                    var ccodes = new CountryCodes();
                    var codelist = ccodes.GetList();

                    //using (var scope = ctx.Database.BeginTransaction())
                    //{
                    try
                    {
                        //List<String> uniqueCountries = new List<string>();
                        int i = 0;
                        foreach (var item in mbrAddresses)
                        {
                            #region 用 random gen phone number 取代原有嘅 phone number
                            /** 假設條件（address 先決）：
                             * 0. 冇地址，當 others
                             * 1. 非 ASCII 地址就係中國
                             * 2. 由 Address 找到所屬 Country，分為：中國﹑香港﹑其他
                             * 3. 如果 match 唔倒，當係 香港
                             */
                            String currentCountry = "", number1 = "", number2 = "", number3 = "", number4 = "", number5 = "";

                            currentCountry = (String.IsNullOrEmpty(item.Address)) ?
                                "" :
                                IsChinese(item.Address) ? "china" : StripCountry(item.Address);   // 非 ASCII 地址就係中國
                            if (currentCountry != String.Empty)
                            {
                                #region 有地址
                                currentCountry = currentCountry.ToLower().Replace(".", "");

                                var isoCountry = ccodes.FindByDisplayName(currentCountry);     // 由 Address 找到所屬 Country
                                var found = isoCountry != null ? true : false;
                                if (!found)     // match 唔倒，當係 香港
                                {
                                    currentCountry = "hong kong";
                                    isoCountry = ccodes.FindByISO3166_Alpha3("HKG");    //! 應該加埋：FindByISO3166_Alpha2，可惜 :(
                                }
                                else
                                {
                                    currentCountry = isoCountry.CLDR_displayname.ToLower();
                                }

                                var dboCountry = ctx.Country.Where(x => x.CountryCode == isoCountry.FIPS).FirstOrDefault();

                                #region get random Phone Numbers into: number1 number2
                                switch (isoCountry.FIPS)
                                {
                                    case "CN":
                                        number1 = (item.PhoneTag1Value.Trim() != String.Empty) ? GetRandomPhoneNumber_CN() : "";
                                        number2 = (item.PhoneTag2Value.Trim() != String.Empty) ? GetRandomPhoneNumber_CN() : "";
                                        number3 = (item.PhoneTag3Value.Trim() != String.Empty) ? GetRandomPhoneNumber_CN() : "";
                                        number4 = (item.PhoneTag4Value.Trim() != String.Empty) ? GetRandomPhoneNumber_CN() : "";
                                        number5 = (item.PhoneTag5Value.Trim() != String.Empty) ? GetRandomPhoneNumber_CN() : "";
                                        break;
                                    case "HK":
                                        number1 = (item.PhoneTag1Value.Trim() != String.Empty) ? GetRandomPhoneNumber_HK() : "";
                                        number2 = (item.PhoneTag2Value.Trim() != String.Empty) ? GetRandomPhoneNumber_HK() : "";
                                        number3 = (item.PhoneTag3Value.Trim() != String.Empty) ? GetRandomPhoneNumber_HK() : "";
                                        number4 = (item.PhoneTag4Value.Trim() != String.Empty) ? GetRandomPhoneNumber_HK() : "";
                                        number5 = (item.PhoneTag5Value.Trim() != String.Empty) ? GetRandomPhoneNumber_HK() : "";
                                        break;
                                    default:
                                        number1 = (item.PhoneTag1Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                        number2 = (item.PhoneTag2Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                        number3 = (item.PhoneTag3Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                        number4 = (item.PhoneTag4Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                        number5 = (item.PhoneTag5Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                        break;
                                }
                                #endregion

                                if (dboCountry != null) item.CountryId = dboCountry.CountryId;
                                item.PhoneTag1Value = number1;
                                item.PhoneTag2Value = number2;
                                item.PhoneTag3Value = number3;
                                item.PhoneTag4Value = number4;
                                item.PhoneTag5Value = number5;

                                /** Code used in debugging
                                var inList = uniqueCountries.Where(x => x == currentCountry).FirstOrDefault();
                                if (inList == null) uniqueCountries.Add(currentCountry);
                                */
                                #endregion
                            }
                            else
                            {
                                #region 冇地址
                                number1 = (item.PhoneTag1Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                number2 = (item.PhoneTag2Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                number3 = (item.PhoneTag3Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                number4 = (item.PhoneTag4Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";
                                number5 = (item.PhoneTag5Value.Trim() != String.Empty) ? GetRandomPhoneNumber_Others() : "";

                                item.PhoneTag1Value = number1;
                                item.PhoneTag2Value = number2;
                                item.PhoneTag3Value = number3;
                                item.PhoneTag4Value = number4;
                                item.PhoneTag5Value = number5;
                                #endregion
                            }

                            //ctx.BulkSaveChanges(options => options.BatchSize = 100);
                            #endregion

                            i++;
                            #region SaveChanges each batch: say 100
                            if ((i % 100) == 0)
                            {
                                ctx.BulkSaveChanges();

                                // uncomment for debugging
                                //if (i >= 50) break;
                            }
                            #endregion
                        }

                        if (ctx.ChangeTracker.HasChanges())
                        {
                            ctx.BulkSaveChanges();
                        }
                        //scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        //scope.Rollback();
                        throw ex;
                    }
                    //}
                }
                #endregion
            }
        }

        #region private methods for GenMemberPhoneNumbers

        static Random rand = new Random();

        /// <summary>
        /// 假如唔係 ASCII 就當係中文
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static bool IsChinese(String source)
        {
            // Encoding.ASCII.GetBytes 會將 non-ascii 轉變為 ?
            var stripped = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(source));
            // 如果有 ? 就當係中文
            return (stripped.Contains("?"));
        }

        /// <summary>
        /// 抽出最後嗰行當係 Country
        /// 中文地址係 country 行先，所以要先用 IsChinese 過濾咗啲中文地址
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static String StripCountry(String source)
        {
            var result = "";
            var rows = source.Split(new string[] { "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
            var lastRow = rows.Length == 0 ? "" : rows.Length > 1 ? rows[rows.Length - 1] : rows[0];

            if (lastRow != String.Empty)
            {
                var words = lastRow.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var lastWord = words.Length == 0 ? "" : words.Length > 1 ? words[words.Length - 1] : words[0];

                // 唔要 numeric，唔要前後 spaces
                result = Regex.Replace(lastWord, "[0-9]", "").Trim();
            }

            return result;
        }

        /// <summary>
        /// 其他國家：Gen 10 位數字，唔要符號
        /// </summary>
        /// <returns></returns>
        private static String GetRandomPhoneNumber_Others()
        {
            StringBuilder telNo = new StringBuilder(10);
            int number;
            for (int i = 0; i < 3; i++)
            {
                number = rand.Next(0, 8); // digit between 0 (incl) and 8 (excl)
                telNo = telNo.Append(number.ToString());
            }
            //telNo = telNo.Append("-");
            number = rand.Next(0, 743); // number between 0 (incl) and 743 (excl)
            telNo = telNo.Append(String.Format("{0:D3}", number));
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        /// <summary>
        /// 中國：Gen 10 位數字，唔要符號
        /// </summary>
        /// <returns></returns>
        private static String GetRandomPhoneNumber_CN()
        {
            StringBuilder telNo = new StringBuilder(10);
            int number = 86;
            //telNo = telNo.Append(number.ToString());
            //telNo = telNo.Append("-");
            for (int i = 0; i < 3; i++)
            {
                number = rand.Next(0, 8); // digit between 0 (incl) and 8 (excl)
                telNo = telNo.Append(number.ToString());
            }
            //telNo = telNo.Append("-");
            number = rand.Next(0, 1000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D3}", number));
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        /// <summary>
        /// 香港：Gen 8 位數字，唔要符號
        /// </summary>
        /// <returns></returns>
        private static String GetRandomPhoneNumber_HK()
        {
            StringBuilder telNo = new StringBuilder(8);
            int number = 852;

            //telNo = telNo.Append(number.ToString());
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            //telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        #endregion
    }
}