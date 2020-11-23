using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
    /// <summary>
    /// dbo.Country = Hong Kong SAR
    /// dbo.Province = Region: Hong Kong Island/ Kowloon/ Net Territories (港島/ 九龍/ 新界)
    /// dbo.City = District: 18 區 (refer: https://en.wikipedia.org/wiki/Hong_Kong)
    /// 順豐分區圖：https://www.sf-express.com/hk/tc/dynamic_function/range/
    /// </summary>
    public class HongKongHelper
    {
        /// <summary>
        /// 寫啲 default values 入：
        /// dbo.Province = Region; dbo.City = District
        /// </summary>
        /// <returns></returns>
        public static bool WriteDefaultValues()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        #region dbo.Country
                        var country = ctx.Country.Where(x => x.CountryCode == "HK").FirstOrDefault();

                        if (country == null)
                        {
                            country = new EF6.Country();
                            country.CountryId = Guid.NewGuid();
                            ctx.Country.Add(country);
                        }

                        country.CountryCode = HongKong.Id;
                        country.CountryName = HongKong.Name;
                        country.CountryName_Chs = HongKong.NameAlt1;
                        country.CountryName_Cht = HongKong.NameAlt2;

                        ctx.SaveChanges();
                        #endregion

                        #region dbo.Province
                        foreach( var item in Region)
                        {
                            var code = String.Format("{0}.{1}", country.CountryCode, item.Id);
                            var province = ctx.Province.Where(x => x.ProvinceCode == code).FirstOrDefault();
                            if (province == null)
                            {
                                province = new EF6.Province()
                                {
                                    ProvinceId = Guid.NewGuid(),
                                    ProvinceCode = String.Format("{0}.{1}", country.CountryCode, item.Id)
                                };
                                ctx.Province.Add(province);
                            }
                            province.ProvinceName = item.Name;
                            province.ProvinceName_Chs = item.NameAlt1;
                            province.ProvinceName_Cht = item.NameAlt2;
                            province.CountryId = country.CountryId;
                        }
                        ctx.SaveChanges();
                        #endregion

                        #region cbo.City
                        foreach (var item in District)
                        {
                            var parent = String.Format("{0}.{1}", country.CountryCode, item.Parent);
                            var province = ctx.Province.Where(x => x.ProvinceCode == parent).FirstOrDefault();
                            if (province != null)
                            {
                                var code = String.Format("{0}.{1}", province.ProvinceCode, item.Id);
                                var city = ctx.City.Where(x => x.CityCode == code).FirstOrDefault();
                                if (city == null)
                                {
                                    city = new EF6.City()
                                    {
                                        CityId = Guid.NewGuid(),
                                        CityCode = String.Format("{0}.{1}", province.ProvinceCode, item.Id),
                                    };
                                    ctx.City.Add(city);
                                }
                                city.CityName = item.Name;
                                city.CityName_Chs = item.NameAlt1;
                                city.CityName_Cht = item.NameAlt2;
                                city.ProvinceId = province.ProvinceId;
                            }
                        }
                        ctx.SaveChanges();
                        #endregion

                        scope.Commit();
                        result = true;
                    }
                    catch
                    {
                        scope.Rollback();
                    }
                }
            }

            return result;
        }

        public static CountryStateCityItem HongKong
        {
            get
            {
                return new CountryStateCityItem { Parent = "", Id = "HK", Name = "Hong Kong SAR", NameAlt1 = "中国香港特别行政区", NameAlt2 = "中國香港特別行政區" };
            }
        }

        private static List<CountryStateCityItem> Region
        {
            get
            {
                var result = new List<CountryStateCityItem>();

                result.Add(new CountryStateCityItem { Parent = "HK", Id = "R1", Name = "Hong Kong Island", NameAlt1 = "香港岛", NameAlt2 = "香港島" });
                result.Add(new CountryStateCityItem { Parent = "HK", Id = "R2", Name = "Kowloon", NameAlt1 = "九龙", NameAlt2 = "九龍" });
                result.Add(new CountryStateCityItem { Parent = "HK", Id = "R3", Name = "New Territeries", NameAlt1 = "新界", NameAlt2 = "新界" });

                return result;
            }
        }

        /// <summary>
        /// refer: https://en.wikipedia.org/wiki/Districts_of_Hong_Kong
        /// 順豐分區圖：https://www.sf-express.com/hk/tc/dynamic_function/range/
        /// </summary>
        private static List<CountryStateCityItem> District
        {
            get
            {
                var result = new List<CountryStateCityItem>();
                result.Add(new CountryStateCityItem { Parent = "R1", Id = "D11", Name = "Central and Western", NameAlt1 = "中西区", NameAlt2 = "中西區" });
                result.Add(new CountryStateCityItem { Parent = "R1", Id = "D12", Name = "Eastern", NameAlt1 = "东区", NameAlt2 = "東區" });
                result.Add(new CountryStateCityItem { Parent = "R1", Id = "D13", Name = "Southern", NameAlt1 = "南区", NameAlt2 = "南區" });
                result.Add(new CountryStateCityItem { Parent = "R1", Id = "D14", Name = "Wan Chai", NameAlt1 = "湾仔区", NameAlt2 = "灣仔區" });

                result.Add(new CountryStateCityItem { Parent = "R2", Id = "D21", Name = "Sham Shui Po", NameAlt1 = "深水埗区", NameAlt2 = "深水埗區" });
                result.Add(new CountryStateCityItem { Parent = "R2", Id = "D22", Name = "Kowloon City", NameAlt1 = "九龙城区", NameAlt2 = "九龍城區" });
                result.Add(new CountryStateCityItem { Parent = "R2", Id = "D23", Name = "Kwun Tong", NameAlt1 = "观塘区", NameAlt2 = "觀塘區" });
                result.Add(new CountryStateCityItem { Parent = "R2", Id = "D24", Name = "Wong Tai Sin", NameAlt1 = "黄大仙区", NameAlt2 = "黃大仙區" });
                result.Add(new CountryStateCityItem { Parent = "R2", Id = "D25", Name = "Yau Tsim Mong", NameAlt1 = "油尖旺区", NameAlt2 = "油尖旺區" });

                //result.Add(new Track { Parent = "R3", Id = "D31", Name = "Islands", NameAlt1 = "", NameAlt2 = "離島區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D32", Name = "Kwai Tsing", NameAlt1 = "葵青区", NameAlt2 = "葵青區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D33", Name = "North", NameAlt1 = "北区", NameAlt2 = "北區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D34", Name = "Sai Kung", NameAlt1 = "西贡区", NameAlt2 = "西貢區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D35", Name = "Sha Tin", NameAlt1 = "沙田区", NameAlt2 = "沙田區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D36", Name = "Tai Po", NameAlt1 = "大埔区", NameAlt2 = "大埔區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D37", Name = "Tsuen Wan", NameAlt1 = "荃湾区", NameAlt2 = "荃灣區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D38", Name = "Tuen Mun", NameAlt1 = "屯门区", NameAlt2 = "屯門區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "D39", Name = "Yuen Long", NameAlt1 = "元朗区", NameAlt2 = "元朗區" });

                // 順豐將離島區分為以下 4 區
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "E1", Name = "Cheung Chau", NameAlt1 = "长洲区", NameAlt2 = "長洲區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "E2", Name = "Peng Chau", NameAlt1 = "坪洲区", NameAlt2 = "坪洲區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "E3", Name = "Lantau Island", NameAlt1 = "大屿山区", NameAlt2 = "大嶼山區" });
                result.Add(new CountryStateCityItem { Parent = "R3", Id = "E4", Name = "Lamma Island", NameAlt1 = "南丫岛区", NameAlt2 = "南丫島區" });

                return result;
            }
        }
    }

    public class CountryStateCityItem
    {
        public string Parent { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameAlt1 { get; set; }
        public string NameAlt2 { get; set; }
    }
}