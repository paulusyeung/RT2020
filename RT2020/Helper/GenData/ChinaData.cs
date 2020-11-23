using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Helper.GenData
{
    /// <summary>
    /// dbo.Country = Hong Kong SAR
    /// dbo.Province = Region: Hong Kong Island/ Kowloon/ Net Territories (港島/ 九龍/ 新界)
    /// dbo.City = District: 18 區 (refer: https://en.wikipedia.org/wiki/Hong_Kong)
    /// 順豐分區圖：https://www.sf-express.com/hk/tc/dynamic_function/range/
    /// </summary>
    public class ChinaData
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

                        country.CountryCode = China.Id;
                        country.CountryName = China.Name;
                        country.CountryName_Chs = China.NameAlt1;
                        country.CountryName_Cht = China.NameAlt2;

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

        public static CountryStateCityItem China
        {
            get
            {
                return new CountryStateCityItem { Parent = "", Id = "CN", Name = "China", NameAlt1 = "中华人民共和国", NameAlt2 = "中華人民共和國" };
            }
        }

        // refer: http://www.cuhk.edu.hk/soc/socionexus/resources/chisoc/basics/f-struct_2c.htm & http://big5.www.gov.cn/gate/big5/www.gov.cn/test/2005-06/15/content_18253.htm
        private static List<CountryStateCityItem> Region
        {
            get
            {
                var result = new List<CountryStateCityItem>();

                #region 直轄市
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "M1", Name = "Beijing Municipality", NameAlt1 = "北京市", NameAlt2 = "北京市" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "M2", Name = "Chongqing Municipality", NameAlt1 = "重庆市", NameAlt2 = "重慶市" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "M3", Name = "Shanghai Municipality", NameAlt1 = "上海市", NameAlt2 = "上海市" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "M4", Name = "Tianjin Municipality", NameAlt1 = "天津市", NameAlt2 = "天津市" });
                #endregion

                #region 自治區
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "A1", Name = "Guangxi", NameAlt1 = "广西", NameAlt2 = "廣西" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "A2", Name = "Inner Mongolia", NameAlt1 = "内蒙古", NameAlt2 = "內蒙古" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "A3", Name = "Ningxia Hui", NameAlt1 = "宁夏", NameAlt2 = "寧夏" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "A4", Name = "Tibet", NameAlt1 = "西藏", NameAlt2 = "西藏" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "A5", Name = "Xinjiang", NameAlt1 = "新疆", NameAlt2 = "新疆" });
                #endregion

                #region 省
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P01", Name = "Anhui", NameAlt1 = "安徽", NameAlt2 = "安徽" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P02", Name = "Fujian", NameAlt1 = "福建", NameAlt2 = "福建" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P03", Name = "Gansu", NameAlt1 = "甘肃", NameAlt2 = "甘肅" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P04", Name = "Guangdong", NameAlt1 = "广东", NameAlt2 = "廣東" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P05", Name = "Guizhou", NameAlt1 = "贵州", NameAlt2 = "貴州" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P06", Name = "Hainan", NameAlt1 = "海南", NameAlt2 = "海南" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P07", Name = "Hebei", NameAlt1 = "河北", NameAlt2 = "河北" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P08", Name = "Heilongjiang", NameAlt1 = "黑龙江", NameAlt2 = "黑龍江" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P09", Name = "Henan", NameAlt1 = "河南", NameAlt2 = "河南" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P10", Name = "Hubei", NameAlt1 = "湖北", NameAlt2 = "湖北" });

                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P11", Name = "Hunan", NameAlt1 = "湖南", NameAlt2 = "湖南" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P12", Name = "Jiangsu", NameAlt1 = "江苏", NameAlt2 = "江蘇" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P13", Name = "Jiangxi", NameAlt1 = "江西", NameAlt2 = "江西" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P14", Name = "Jilin", NameAlt1 = "吉林", NameAlt2 = "吉林" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P15", Name = "Liaoning", NameAlt1 = "辽宁", NameAlt2 = "遼寧" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P16", Name = "Qinghai", NameAlt1 = "青海", NameAlt2 = "青海" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P17", Name = "Shandong", NameAlt1 = "山东", NameAlt2 = "山東" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P18", Name = "Shaanxi", NameAlt1 = "陕西", NameAlt2 = "陝西" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P19", Name = "Shanxi", NameAlt1 = "山西", NameAlt2 = "山西" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P20", Name = "Sichuan", NameAlt1 = "四川", NameAlt2 = "四川" });

                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P21", Name = "Yunnan", NameAlt1 = "云南", NameAlt2 = "雲南" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P22", Name = "Zhejiang", NameAlt1 = "浙江", NameAlt2 = "浙江" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "P23", Name = "Taiwan", NameAlt1 = "台湾", NameAlt2 = "台灣" });
                #endregion

                #region 特別行政區
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "S1", Name = "Hong Kong", NameAlt1 = "香港", NameAlt2 = "香港" });
                result.Add(new CountryStateCityItem { Parent = "CN", Id = "S1", Name = "Macao", NameAlt1 = "澳门", NameAlt2 = "澳門" });
                #endregion

                return result;
            }
        }

        /// <summary>
        /// refer: https://help.aliyun.com/document_detail/67899.html
        /// </summary>
        private static List<CountryStateCityItem> District
        {
            get
            {
                var result = new List<CountryStateCityItem>();

                #region M1 直轄市 x 4
                result.Add(new CountryStateCityItem { Parent = "M1", Id = "D01", Name = "Beijing", NameAlt1 = "北京市", NameAlt2 = "北京市" });
                result.Add(new CountryStateCityItem { Parent = "M2", Id = "D02", Name = "Chongqing", NameAlt1 = "重庆市", NameAlt2 = "重慶市" });
                result.Add(new CountryStateCityItem { Parent = "M3", Id = "D03", Name = "Shanghai", NameAlt1 = "上海市", NameAlt2 = "上海市" });
                result.Add(new CountryStateCityItem { Parent = "M4", Id = "D04", Name = "Tianjin", NameAlt1 = "天津市", NameAlt2 = "天津市" });
                #endregion

                #region A1 广西 x 20
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D01", Name = "Baise", NameAlt1 = "百色市", NameAlt2 = "百色市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D02", Name = "Beihai", NameAlt1 = "北海市", NameAlt2 = "北海市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D03", Name = "Beiliu", NameAlt1 = "北流市", NameAlt2 = "北流市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D04", Name = "Cenxi", NameAlt1 = "岑溪市", NameAlt2 = "岑溪市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D05", Name = "Chongzuo", NameAlt1 = "崇左市", NameAlt2 = "崇左市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D06", Name = "Dongxing", NameAlt1 = "东兴市", NameAlt2 = "東興市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D07", Name = "Fangchenggang", NameAlt1 = "防城港市", NameAlt2 = "防城港市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D08", Name = "Guigang", NameAlt1 = "贵港市", NameAlt2 = "貴港市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D09", Name = "Guilin", NameAlt1 = "桂林市", NameAlt2 = "桂林市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D10", Name = "Hechi", NameAlt1 = "河池市", NameAlt2 = "河池市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D11", Name = "Heshan", NameAlt1 = "合山市", NameAlt2 = "合山市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D12", Name = "Hezhou", NameAlt1 = "贺州市", NameAlt2 = "賀州市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D13", Name = "Laibin", NameAlt1 = "来宾市", NameAlt2 = "來賓市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D14", Name = "Liuzhou", NameAlt1 = "柳州市", NameAlt2 = "柳州市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D15", Name = "Nanning", NameAlt1 = "南宁市", NameAlt2 = "南寧市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D16", Name = "Pingxiang", NameAlt1 = "憑祥市", NameAlt2 = "憑祥市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D17", Name = "Qinzhou", NameAlt1 = "钦州市", NameAlt2 = "欽州市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D18", Name = "Wuzhou", NameAlt1 = "梧州市", NameAlt2 = "梧州市" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D19", Name = "Yizhou", NameAlt1 = "宜州区", NameAlt2 = "宜州區" });
                result.Add(new CountryStateCityItem { Parent = "A1", Id = "D20", Name = "Yulin", NameAlt1 = "玉林市", NameAlt2 = "玉林市" });
                #endregion

                #region A2 x 23 內蒙古
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D01", Name = "Alxa League", NameAlt1 = "阿拉善盟", NameAlt2 = "阿拉善盟" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D02", Name = "Arxan", NameAlt1 = "阿尔山市", NameAlt2 = "阿爾山市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D03", Name = "Baotou", NameAlt1 = "包头市", NameAlt2 = "包頭市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D04", Name = "Bayannur", NameAlt1 = "巴彦淖尔市", NameAlt2 = "巴彥淖爾市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D05", Name = "Chifeng", NameAlt1 = "赤峰市", NameAlt2 = "赤峰市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D06", Name = "Erenhot", NameAlt1 = "二连浩特市", NameAlt2 = "二連浩特市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D07", Name = "Ergun City", NameAlt1 = "额尔古纳市", NameAlt2 = "額爾古納市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D08", Name = "Fengzhen", NameAlt1 = "丰镇市", NameAlt2 = "豐鎮市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D09", Name = "Genhe", NameAlt1 = "根河市", NameAlt2 = "根河市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D10", Name = "Hinggan League", NameAlt1 = "兴安盟", NameAlt2 = "興安盟" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D11", Name = "Hohhot", NameAlt1 = "呼和浩特市", NameAlt2 = "呼和浩特市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D12", Name = "Holingol", NameAlt1 = "霍林郭勒市", NameAlt2 = "霍林郭勒市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D13", Name = "Hulunbuir", NameAlt1 = "呼伦贝尔市", NameAlt2 = "呼倫貝爾市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D14", Name = "Manzhouli", NameAlt1 = "满洲里市", NameAlt2 = "滿洲裡市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D15", Name = "Ordos City", NameAlt1 = "鄂尔多斯市", NameAlt2 = "鄂爾多斯市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D16", Name = "Tongliao", NameAlt1 = "通辽市", NameAlt2 = "通遼市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D17", Name = "Ulanhot", NameAlt1 = "乌兰浩特市", NameAlt2 = "烏蘭浩特市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D18", Name = "Ulanqab", NameAlt1 = "乌兰察布市", NameAlt2 = "烏蘭察布市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D19", Name = "Wuhai", NameAlt1 = "乌海市", NameAlt2 = "烏海市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D20", Name = "Xilingol League", NameAlt1 = "锡林郭勒盟", NameAlt2 = "錫林郭勒盟" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D21", Name = "Xilinhot", NameAlt1 = "锡林浩特市", NameAlt2 = "錫林浩特市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D22", Name = "Yakeshi", NameAlt1 = "牙克石市", NameAlt2 = "牙克石市" });
                result.Add(new CountryStateCityItem { Parent = "A2", Id = "D23", Name = "Zalantun", NameAlt1 = "紥蘭屯市", NameAlt2 = "紥蘭屯市" });
                #endregion

                #region A3 x 7 寧夏
                result.Add(new CountryStateCityItem { Parent = "A3", Id = "D01", Name = "Guyuan", NameAlt1 = "固原市", NameAlt2 = "固原市" });
                result.Add(new CountryStateCityItem { Parent = "A3", Id = "D02", Name = "Lingwu", NameAlt1 = "灵武市", NameAlt2 = "靈武市" });
                result.Add(new CountryStateCityItem { Parent = "A3", Id = "D03", Name = "Qingtongxia", NameAlt1 = "青铜峡市", NameAlt2 = "青銅峽市" });
                result.Add(new CountryStateCityItem { Parent = "A3", Id = "D04", Name = "Shizuishan", NameAlt1 = "石嘴山市", NameAlt2 = "石嘴山市" });
                result.Add(new CountryStateCityItem { Parent = "A3", Id = "D05", Name = "Wuzhong", NameAlt1 = "吴忠市", NameAlt2 = "吳忠市" });
                result.Add(new CountryStateCityItem { Parent = "A3", Id = "D06", Name = "Yinchuan", NameAlt1 = "银川市", NameAlt2 = "銀川市" });
                result.Add(new CountryStateCityItem { Parent = "A3", Id = "D07", Name = "Zhongwei", NameAlt1 = "中卫市", NameAlt2 = "中衛市" });
                #endregion

                #region A4 x 7 西藏
                result.Add(new CountryStateCityItem { Parent = "A4", Id = "D01", Name = "Chamdo", NameAlt1 = "昌都市", NameAlt2 = "昌都市" });
                result.Add(new CountryStateCityItem { Parent = "A4", Id = "D02", Name = "Lhasa", NameAlt1 = "拉萨市", NameAlt2 = "拉薩市" });
                result.Add(new CountryStateCityItem { Parent = "A4", Id = "D03", Name = "Nagqu", NameAlt1 = "那曲市", NameAlt2 = "那曲市" });
                result.Add(new CountryStateCityItem { Parent = "A4", Id = "D04", Name = "Ngari Prefecture", NameAlt1 = "阿里地区", NameAlt2 = "阿里地區" });
                result.Add(new CountryStateCityItem { Parent = "A4", Id = "D05", Name = "Nyingchi", NameAlt1 = "林芝市", NameAlt2 = "林芝市" });
                result.Add(new CountryStateCityItem { Parent = "A4", Id = "D06", Name = "Shannan", NameAlt1 = "山南市", NameAlt2 = "山南市" });
                result.Add(new CountryStateCityItem { Parent = "A4", Id = "D07", Name = "Shigatse", NameAlt1 = "日喀则市", NameAlt2 = "日喀則市" });
                #endregion

                #region A5 x 30 新疆
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D01", Name = "Aksu City", NameAlt1 = "阿克苏市", NameAlt2 = "阿克蘇市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D02", Name = "Aksu Prefecture", NameAlt1 = "阿克苏地区", NameAlt2 = "阿克蘇地區" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D03", Name = "Alar", NameAlt1 = "阿拉尔市", NameAlt2 = "阿拉爾市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D04", Name = "Altay", NameAlt1 = "阿勒泰市", NameAlt2 = "阿勒泰市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D05", Name = "Altay Prefecture", NameAlt1 = "阿勒泰地区", NameAlt2 = "阿勒泰地區" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D06", Name = "Artux", NameAlt1 = "阿图什市", NameAlt2 = "阿圖什市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D07", Name = "Bayingolin Mongol Autonomous Prefecture", NameAlt1 = "巴音郭楞蒙古自治州", NameAlt2 = "阿拉善盟" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D08", Name = "Bole", NameAlt1 = "博乐市", NameAlt2 = "博樂市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D09", Name = "Bortala Mongol Autonomous Prefecture", NameAlt1 = "博爾塔拉蒙古自治州", NameAlt2 = "阿拉善盟" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D10", Name = "Changji", NameAlt1 = "昌吉市", NameAlt2 = "昌吉市" });

                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D11", Name = "Changji Hui Autonomous Prefecture", NameAlt1 = "昌吉回族自治州", NameAlt2 = "昌吉回族自治州" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D12", Name = "Fukang", NameAlt1 = "阜康市", NameAlt2 = "阜康市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D13", Name = "Ghulja", NameAlt1 = "伊宁市", NameAlt2 = "伊寧市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D14", Name = "Hami", NameAlt1 = "哈密市", NameAlt2 = "哈密市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D15", Name = "Hotan", NameAlt1 = "和田市", NameAlt2 = "和田市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D16", Name = "Ili", NameAlt1 = "伊犁哈萨克自治州", NameAlt2 = "伊犁哈薩克自治州" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D17", Name = "Karamay", NameAlt1 = "克拉玛依市", NameAlt2 = "克拉瑪依市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D18", Name = "Kashgar", NameAlt1 = "喀什市", NameAlt2 = "喀什市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D19", Name = "Kashgar Prefecture", NameAlt1 = "喀什地区", NameAlt2 = "喀什地區" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D20", Name = "Kizilsu Kyrgyz Autonomous Prefecture", NameAlt1 = "克孜勒苏柯尔克孜自治州", NameAlt2 = "克孜勒蘇柯爾克孜自治州" });

                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D21", Name = "Korla", NameAlt1 = "库尔勒市", NameAlt2 = "庫爾勒市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D22", Name = "Kuytun", NameAlt1 = "奎屯市", NameAlt2 = "奎屯市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D23", Name = "Shihezi", NameAlt1 = "石河子市", NameAlt2 = "石河子市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D24", Name = "Tacheng", NameAlt1 = "塔城市", NameAlt2 = "塔城市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D25", Name = "Tacheng Prefecture", NameAlt1 = "塔城地区", NameAlt2 = "塔城地區" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D26", Name = "Tumxuk", NameAlt1 = "图木舒克市", NameAlt2 = "圖木舒克市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D27", Name = "Turpan", NameAlt1 = "吐鲁番市", NameAlt2 = "吐魯番市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D28", Name = "Urumchi", NameAlt1 = "乌鲁木齐市", NameAlt2 = "烏魯木齊市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D29", Name = "Wujiaqu", NameAlt1 = "阿拉善盟", NameAlt2 = "五家渠市" });
                result.Add(new CountryStateCityItem { Parent = "A5", Id = "D30", Name = "Wusu", NameAlt1 = "乌苏市", NameAlt2 = "烏蘇市" });
                #endregion

                #region P01 x 22 安徽
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D01", Name = "Anqing", NameAlt1 = "安庆市", NameAlt2 = "安慶市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D02", Name = "Bengbu", NameAlt1 = "蚌埠市", NameAlt2 = "蚌埠市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D03", Name = "Bozhou", NameAlt1 = "亳州市", NameAlt2 = "亳州市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D04", Name = "Chaohu", NameAlt1 = "巢湖市", NameAlt2 = "巢湖市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D05", Name = "Chizhou", NameAlt1 = "池州市", NameAlt2 = "池州市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D06", Name = "Chuzhou", NameAlt1 = "滁州市", NameAlt2 = "滁州市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D07", Name = "Fuyang", NameAlt1 = "阜阳市", NameAlt2 = "阜陽市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D08", Name = "Hefei", NameAlt1 = "合肥市", NameAlt2 = "合肥市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D09", Name = "Huaibei", NameAlt1 = "淮北市", NameAlt2 = "淮北市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D10", Name = "Huainan", NameAlt1 = "淮南市", NameAlt2 = "淮南市" });

                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D11", Name = "Huangshan City", NameAlt1 = "黄山市", NameAlt2 = "黃山市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D12", Name = "Jieshou", NameAlt1 = "界首市", NameAlt2 = "界首市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D13", Name = "Lu'an", NameAlt1 = "六安市", NameAlt2 = "六安市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D14", Name = "Ma'anshan", NameAlt1 = "马鞍山市", NameAlt2 = "馬鞍山市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D15", Name = "Mingguang", NameAlt1 = "明光市", NameAlt2 = "明光市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D16", Name = "Ningguo", NameAlt1 = "宁国市", NameAlt2 = "寧國市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D17", Name = "Suzhou", NameAlt1 = "宿州市", NameAlt2 = "宿州市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D18", Name = "Tianchang", NameAlt1 = "天长市", NameAlt2 = "天長市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D19", Name = "Tongcheng", NameAlt1 = "桐城市", NameAlt2 = "桐城市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D20", Name = "Tongling", NameAlt1 = "铜陵市", NameAlt2 = "銅陵市" });

                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D11", Name = "Wuhu", NameAlt1 = "芜湖市", NameAlt2 = "蕪湖市" });
                result.Add(new CountryStateCityItem { Parent = "P01", Id = "D22", Name = "Xuancheng", NameAlt1 = "宣城市", NameAlt2 = "宣城市" });
                #endregion

                #region P02 x 23 福建
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D01", Name = "Changle District", NameAlt1 = "长乐区", NameAlt2 = "長樂區" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D02", Name = "Fu'an", NameAlt1 = "福安市", NameAlt2 = "福安市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D03", Name = "Fuding", NameAlt1 = "福鼎市", NameAlt2 = "福鼎市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D04", Name = "Fuqing", NameAlt1 = "福清市", NameAlt2 = "福清市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D05", Name = "Fuzhou", NameAlt1 = "福州市", NameAlt2 = "福州市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D06", Name = "Jian'ou", NameAlt1 = "建瓯市", NameAlt2 = "建甌市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D07", Name = "Jianyang District", NameAlt1 = "建阳区", NameAlt2 = "建陽區" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D08", Name = "Jinjiang", NameAlt1 = "晋江市", NameAlt2 = "晉江市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D09", Name = "Longhai City", NameAlt1 = "龙海市", NameAlt2 = "龍海市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D10", Name = "Longyan", NameAlt1 = "龙岩市", NameAlt2 = "龍岩市" });

                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D11", Name = "Nan'an", NameAlt1 = "南安市", NameAlt2 = "南安市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D12", Name = "Nanping", NameAlt1 = "南平市", NameAlt2 = "南平市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D13", Name = "Ningde", NameAlt1 = "宁德市", NameAlt2 = "寧德市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D14", Name = "Putian", NameAlt1 = "莆田市", NameAlt2 = "莆田市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D15", Name = "Quanzhou", NameAlt1 = "泉州市", NameAlt2 = "泉州市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D16", Name = "Sanming", NameAlt1 = "三明市", NameAlt2 = "三明市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D17", Name = "Shaowu", NameAlt1 = "邵武市", NameAlt2 = "邵武市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D18", Name = "Shishi", NameAlt1 = "石狮市", NameAlt2 = "石獅市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D19", Name = "Wuyishan", NameAlt1 = "武夷山市", NameAlt2 = "武夷山市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D20", Name = "Xiamen", NameAlt1 = "厦门市", NameAlt2 = "廈門市" });

                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D21", Name = "Yong'an", NameAlt1 = "永安市", NameAlt2 = "永安市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D22", Name = "Zhangping", NameAlt1 = "漳平市", NameAlt2 = "漳平市" });
                result.Add(new CountryStateCityItem { Parent = "P02", Id = "D23", Name = "Zhangzhou", NameAlt1 = "漳州市", NameAlt2 = "漳州市" });
                #endregion

                #region P03 x 17 甘肅
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D01", Name = "Baiyin", NameAlt1 = "白银市", NameAlt2 = "白銀市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D02", Name = "Dingxi", NameAlt1 = "定西市", NameAlt2 = "定西市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D03", Name = "Gannan Tibetan Autonomous Prefecture", NameAlt1 = "甘南藏族自治州", NameAlt2 = "甘南藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D04", Name = "Hezuo", NameAlt1 = "合作市", NameAlt2 = "合作市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D05", Name = "Jiayuguan City", NameAlt1 = "嘉峪关市", NameAlt2 = "嘉峪關市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D06", Name = "Jinchang", NameAlt1 = "金昌市", NameAlt2 = "金昌市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D07", Name = "Jiuquan", NameAlt1 = "酒泉市", NameAlt2 = "酒泉市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D08", Name = "Lanzhou", NameAlt1 = "兰州市", NameAlt2 = "蘭州市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D09", Name = "Linxia City", NameAlt1 = "临夏市", NameAlt2 = "臨夏市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D10", Name = "Linxia Hui Autonomous Prefecture", NameAlt1 = "临夏回族自治州", NameAlt2 = "臨夏回族自治州" });

                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D11", Name = "Longnan", NameAlt1 = "陇南市", NameAlt2 = "隴南市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D12", Name = "Pingliang", NameAlt1 = "平凉市", NameAlt2 = "平涼市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D13", Name = "Qingyang", NameAlt1 = "庆阳市", NameAlt2 = "慶陽市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D14", Name = "Tianshui", NameAlt1 = "天水市", NameAlt2 = "天水市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D15", Name = "Wuwei", NameAlt1 = "武威市", NameAlt2 = "武威市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D16", Name = "Yumen City", NameAlt1 = "玉门市", NameAlt2 = "玉門市" });
                result.Add(new CountryStateCityItem { Parent = "P03", Id = "D17", Name = "Zhangye", NameAlt1 = "张掖市", NameAlt2 = "張掖市" });
                #endregion

                #region P04 x 43 廣東
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D01", Name = "Chaozhou", NameAlt1 = "潮州市", NameAlt2 = "潮州市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D02", Name = "Conghua", NameAlt1 = "从化市", NameAlt2 = "從化市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D03", Name = "Dongguan", NameAlt1 = "东莞市", NameAlt2 = "東莞市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D04", Name = "Enping", NameAlt1 = "恩平市", NameAlt2 = "恩平市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D05", Name = "Foshan", NameAlt1 = "佛山市", NameAlt2 = "佛山市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D06", Name = "Gaozhou", NameAlt1 = "高州市", NameAlt2 = "高州市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D07", Name = "Guangzhou", NameAlt1 = "广州市", NameAlt2 = "廣州市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D08", Name = "Heshan", NameAlt1 = "鹤山市", NameAlt2 = "鶴山市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D09", Name = "Heyuan", NameAlt1 = "河源市", NameAlt2 = "河源市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D10", Name = "Huazhou", NameAlt1 = "化州市", NameAlt2 = "化州市" });

                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D11", Name = "Huizhou", NameAlt1 = "惠州市", NameAlt2 = "惠州市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D12", Name = "Jiangmen", NameAlt1 = "江门市", NameAlt2 = "江門市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D13", Name = "Jieyang", NameAlt1 = "揭阳市", NameAlt2 = "揭陽市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D14", Name = "Kaiping", NameAlt1 = "开平市", NameAlt2 = "開平市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D15", Name = "Lechang", NameAlt1 = "乐昌市", NameAlt2 = "樂昌市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D16", Name = "Leizhou", NameAlt1 = "雷州市", NameAlt2 = "雷州市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D17", Name = "Lianjiang", NameAlt1 = "廉江市", NameAlt2 = "廉江市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D18", Name = "Lianzhou", NameAlt1 = "连州市", NameAlt2 = "連州市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D19", Name = "Lufeng", NameAlt1 = "陆丰市", NameAlt2 = "陸豐市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D20", Name = "Luoding", NameAlt1 = "罗定市", NameAlt2 = "羅定市" });

                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D21", Name = "Maoming", NameAlt1 = "茂名市", NameAlt2 = "茂名市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D22", Name = "Meizhou", NameAlt1 = "梅州市", NameAlt2 = "梅州市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D23", Name = "Nanxiong", NameAlt1 = "南雄市", NameAlt2 = "南雄市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D24", Name = "Puning", NameAlt1 = "普宁市", NameAlt2 = "普寧市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D25", Name = "Qingyuan", NameAlt1 = "清远市", NameAlt2 = "清遠市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D26", Name = "Shantou", NameAlt1 = "汕头市", NameAlt2 = "汕頭市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D27", Name = "Shanwei", NameAlt1 = "汕尾市", NameAlt2 = "汕尾市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D28", Name = "Shaoguan", NameAlt1 = "韶关市", NameAlt2 = "韶關市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D29", Name = "Shenzhen", NameAlt1 = "深圳市", NameAlt2 = "深圳市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D30", Name = "Sihui", NameAlt1 = "四会市", NameAlt2 = "四會市" });

                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D31", Name = "Taishan", NameAlt1 = "台山市", NameAlt2 = "台山市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D32", Name = "Wuchuan", NameAlt1 = "吴川市", NameAlt2 = "吳川市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D33", Name = "Xingning", NameAlt1 = "兴宁市", NameAlt2 = "興寧市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D34", Name = "Xinyi", NameAlt1 = "信宜市", NameAlt2 = "信宜市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D35", Name = "Yangchun", NameAlt1 = "阳春市", NameAlt2 = "陽春市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D36", Name = "Yangjiang", NameAlt1 = "阳江市", NameAlt2 = "陽江市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D37", Name = "Yingde", NameAlt1 = "英德市", NameAlt2 = "英德市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D38", Name = "Yunfu", NameAlt1 = "云浮市", NameAlt2 = "雲浮市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D39", Name = "Zengcheng", NameAlt1 = "增城市", NameAlt2 = "增城市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D40", Name = "Zhanjiang", NameAlt1 = "湛江市", NameAlt2 = "湛江市" });

                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D41", Name = "Zhaoqing", NameAlt1 = "肇庆市", NameAlt2 = "肇慶市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D42", Name = "Zhongshan", NameAlt1 = "中山市", NameAlt2 = "中山市" });
                result.Add(new CountryStateCityItem { Parent = "P04", Id = "D43", Name = "Zhuhai", NameAlt1 = "珠海市", NameAlt2 = "珠海市" });
                #endregion

                #region P05 x 16  貴州
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D01", Name = "Anshun", NameAlt1 = "安顺市", NameAlt2 = "安順市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D02", Name = "Bijie", NameAlt1 = "毕节市", NameAlt2 = "畢節市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D03", Name = "Chishui City", NameAlt1 = "赤水市", NameAlt2 = "赤水市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D04", Name = "Duyun", NameAlt1 = "都匀市", NameAlt2 = "都勻市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D05", Name = "Fuquan", NameAlt1 = "福泉市", NameAlt2 = "福泉市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D06", Name = "Guiyang", NameAlt1 = "贵阳市", NameAlt2 = "貴陽市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D07", Name = "Kaili City", NameAlt1 = "凯里市", NameAlt2 = "凱裡市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D08", Name = "Liupanshui", NameAlt1 = "六盘水市", NameAlt2 = "六盤水市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D09", Name = "Qiandongnan Miao and Dong Autonomous Prefecture", NameAlt1 = "黔东南苗族侗族自治州", NameAlt2 = "黔東南苗族侗族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D10", Name = "Qiannan Buyei and Miao Autonomous Prefecture", NameAlt1 = "黔南布依族苗族自治州", NameAlt2 = "黔南布依族苗族自治州" });

                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D11", Name = "ianxinan Buyei and Miao Autonomous Prefecture", NameAlt1 = "黔西南布依族苗族自治州", NameAlt2 = "黔西南布依族苗族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D12", Name = "Qingzhen", NameAlt1 = "清镇市", NameAlt2 = "清鎮市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D13", Name = "Renhuai", NameAlt1 = "仁怀市", NameAlt2 = "仁懷市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D14", Name = "Tongren", NameAlt1 = "铜仁市", NameAlt2 = "銅仁市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D15", Name = "Xingyi", NameAlt1 = "兴义市", NameAlt2 = "興義市" });
                result.Add(new CountryStateCityItem { Parent = "P05", Id = "D16", Name = "Zunyi", NameAlt1 = "遵义市", NameAlt2 = "遵義市" });
                #endregion

                #region P06 x 8 海南
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D01", Name = "Danzhou", NameAlt1 = "儋州市", NameAlt2 = "儋州市" });
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D02", Name = "Dongfang", NameAlt1 = "东方市", NameAlt2 = "東方市" });
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D03", Name = "Haikou", NameAlt1 = "海口市", NameAlt2 = "海口市" });
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D04", Name = "Qionghai", NameAlt1 = "琼海市", NameAlt2 = "瓊海市" });
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D05", Name = "Sanya", NameAlt1 = "三亚市", NameAlt2 = "三亞市" });
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D06", Name = "Wanning", NameAlt1 = "万宁市", NameAlt2 = "萬寧市" });
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D07", Name = "Wenchang", NameAlt1 = "文昌市", NameAlt2 = "文昌市" });
                result.Add(new CountryStateCityItem { Parent = "P06", Id = "D08", Name = "Wuzhishan City", NameAlt1 = "五指山市", NameAlt2 = "五指山市" });
                #endregion

                #region P07 x 31 河北
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D01", Name = "Anguo", NameAlt1 = "安国市", NameAlt2 = "安國市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D02", Name = "Baoding", NameAlt1 = "保定市", NameAlt2 = "保定市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D03", Name = "Bazhou", NameAlt1 = "霸州市", NameAlt2 = "霸州市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D04", Name = "Botou", NameAlt1 = "泊头市", NameAlt2 = "泊頭市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D05", Name = "Cangzhou", NameAlt1 = "沧州市", NameAlt2 = "滄州市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D06", Name = "Chengde", NameAlt1 = "承德市", NameAlt2 = "承德市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D07", Name = "Dingzhou", NameAlt1 = "定州市", NameAlt2 = "定州市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D08", Name = "Gaobeidian", NameAlt1 = "高碑店市", NameAlt2 = "高碑店市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D09", Name = "Handan", NameAlt1 = "邯郸市", NameAlt2 = "邯鄲市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D10", Name = "Hejian", NameAlt1 = "河间市", NameAlt2 = "河間市" });

                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D11", Name = "Hengshui", NameAlt1 = "衡水市", NameAlt2 = "衡水市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D12", Name = "Huanghua", NameAlt1 = "黄骅市", NameAlt2 = "黃驊市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D13", Name = "Jinzhou", NameAlt1 = "晋州市", NameAlt2 = "晉州市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D14", Name = "Jizhou", NameAlt1 = "冀州区", NameAlt2 = "冀州區" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D15", Name = "Langfang", NameAlt1 = "廊坊市", NameAlt2 = "廊坊市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D16", Name = "Nangong", NameAlt1 = "南宫市", NameAlt2 = "南宮市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D17", Name = "Qian'an", NameAlt1 = "迁安市", NameAlt2 = "遷安市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D18", Name = "Qinhuangdao", NameAlt1 = "秦皇岛市", NameAlt2 = "秦皇島市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D19", Name = "Renqiu", NameAlt1 = "任丘市", NameAlt2 = "任丘市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D20", Name = "Sanhe", NameAlt1 = "三河市", NameAlt2 = "三河市" });

                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D21", Name = "Shahe", NameAlt1 = "沙河市", NameAlt2 = "沙河市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D22", Name = "Shenzhou", NameAlt1 = "深州市", NameAlt2 = "深州市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D23", Name = "Shijiazhuang", NameAlt1 = "石家庄市", NameAlt2 = "石家莊市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D24", Name = "Tangshan", NameAlt1 = "唐山市", NameAlt2 = "唐山市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D25", Name = "Wu'an", NameAlt1 = "武安市", NameAlt2 = "武安市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D26", Name = "Xingtai", NameAlt1 = "邢台市", NameAlt2 = "邢台市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D27", Name = "Xinji", NameAlt1 = "辛集市", NameAlt2 = "辛集市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D28", Name = "Xinle", NameAlt1 = "新乐市", NameAlt2 = "新樂市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D29", Name = "Zhangjiakou", NameAlt1 = "张家口市", NameAlt2 = "張家口市" });
                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D30", Name = "Zhuozhou", NameAlt1 = "涿州市", NameAlt2 = "涿州市" });

                result.Add(new CountryStateCityItem { Parent = "P07", Id = "D31", Name = "Zunhua", NameAlt1 = "遵化市", NameAlt2 = "遵化市" });
                #endregion

                #region P08 x 30 黑龍江
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D01", Name = "Anda", NameAlt1 = "安达市", NameAlt2 = "安達市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D02", Name = "Bei'an", NameAlt1 = "北安市", NameAlt2 = "北安市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D03", Name = "Daqing", NameAlt1 = "大庆市", NameAlt2 = "大慶市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D04", Name = "Daxing'anling Prefecture", NameAlt1 = "大兴安岭地区", NameAlt2 = "大興安嶺地區" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D05", Name = "Fujin City", NameAlt1 = "富锦市", NameAlt2 = "富錦市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D06", Name = "Hailin", NameAlt1 = "海林市", NameAlt2 = "海林市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D07", Name = "Hailun", NameAlt1 = "海伦市", NameAlt2 = "海倫市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D08", Name = "Harbin", NameAlt1 = "哈尔滨市", NameAlt2 = "哈爾濱市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D09", Name = "Hegang", NameAlt1 = "鹤岗市", NameAlt2 = "鶴崗市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D10", Name = "Heihe", NameAlt1 = "黑河市", NameAlt2 = "黑河市" });

                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D11", Name = "Hulin", NameAlt1 = "虎林市", NameAlt2 = "虎林市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D12", Name = "Jiamusi", NameAlt1 = "佳木斯市", NameAlt2 = "佳木斯市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D13", Name = "Jixi", NameAlt1 = "鸡西市", NameAlt2 = "雞西市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D14", Name = "Mishan", NameAlt1 = "密山市", NameAlt2 = "密山市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D15", Name = "Mudanjiang", NameAlt1 = "牡丹江市", NameAlt2 = "牡丹江市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D16", Name = "Muling", NameAlt1 = "穆棱市", NameAlt2 = "穆棱市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D17", Name = "Nehe", NameAlt1 = "讷河市", NameAlt2 = "訥河市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D18", Name = "Ning'an", NameAlt1 = "宁安市", NameAlt2 = "寧安市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D19", Name = "Qiqihar", NameAlt1 = "齐齐哈尔市", NameAlt2 = "齊齊哈爾市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D20", Name = "Qitaihe", NameAlt1 = "七台河市", NameAlt2 = "七台河市" });

                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D21", Name = "Shangzhi", NameAlt1 = "尚志市", NameAlt2 = "尚志市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D22", Name = "Shuangyashan", NameAlt1 = "双鸭山市", NameAlt2 = "雙鴨山市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D23", Name = "Suifenhe", NameAlt1 = "绥芬河市", NameAlt2 = "綏芬河市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D24", Name = "Suihua", NameAlt1 = "绥化市", NameAlt2 = "綏化市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D25", Name = "Tieli", NameAlt1 = "铁力市", NameAlt2 = "鐵力市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D26", Name = "Tongjiang", NameAlt1 = "同江市", NameAlt2 = "同江市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D27", Name = "Wuchang", NameAlt1 = "五常市", NameAlt2 = "五常市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D28", Name = "Wudalianchi", NameAlt1 = "五大连池市", NameAlt2 = "五大連池市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D29", Name = "Yichun", NameAlt1 = "伊春市", NameAlt2 = "伊春市" });
                result.Add(new CountryStateCityItem { Parent = "P08", Id = "D30", Name = "Zhaodong", NameAlt1 = "肇东市", NameAlt2 = "肇東市" });
                #endregion

                #region P09 x 38 河南
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D01", Name = "Anyang", NameAlt1 = "安阳市", NameAlt2 = "安陽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D02", Name = "Changge", NameAlt1 = "长葛市", NameAlt2 = "長葛市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D03", Name = "Dengfeng", NameAlt1 = "登封市", NameAlt2 = "登封市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D04", Name = "Dengzhou", NameAlt1 = "邓州市", NameAlt2 = "鄧州市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D05", Name = "Gongyi", NameAlt1 = "巩义市", NameAlt2 = "鞏義市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D06", Name = "Hebi", NameAlt1 = "鹤壁市", NameAlt2 = "鶴壁市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D07", Name = "Huixian", NameAlt1 = "辉县市", NameAlt2 = "輝縣市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D08", Name = "Jiaozuo", NameAlt1 = "焦作市", NameAlt2 = "焦作市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D09", Name = "Jiyuan", NameAlt1 = "济源市", NameAlt2 = "濟源市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D10", Name = "Kaifeng", NameAlt1 = "开封市", NameAlt2 = "開封市" });

                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D11", Name = "Lingbao City", NameAlt1 = "灵宝市", NameAlt2 = "靈寶市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D12", Name = "Linzhou", NameAlt1 = "林州市", NameAlt2 = "林州市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D13", Name = "Luohe", NameAlt1 = "漯河市", NameAlt2 = "漯河市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D14", Name = "Luoyang", NameAlt1 = "洛阳市", NameAlt2 = "洛陽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D15", Name = "Mengzhou", NameAlt1 = "孟州市", NameAlt2 = "孟州市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D16", Name = "Nanyang", NameAlt1 = "南阳市", NameAlt2 = "南陽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D17", Name = "Pingdingshan", NameAlt1 = "平顶山市", NameAlt2 = "平頂山市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D18", Name = "Puyang", NameAlt1 = "濮阳市", NameAlt2 = "濮陽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D19", Name = "Qinyang", NameAlt1 = "沁阳市", NameAlt2 = "沁陽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D20", Name = "Ruzhou", NameAlt1 = "汝州市", NameAlt2 = "汝州市" });

                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D21", Name = "Sanmenxia", NameAlt1 = "三门峡市", NameAlt2 = "三門峽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D22", Name = "Shangqiu", NameAlt1 = "商丘市", NameAlt2 = "商丘市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D23", Name = "Weihui", NameAlt1 = "卫辉市", NameAlt2 = "衛輝市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D24", Name = "Wugang", NameAlt1 = "舞钢市", NameAlt2 = "舞鋼市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D25", Name = "Xiangcheng City", NameAlt1 = "项城市", NameAlt2 = "項城市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D26", Name = "Xingyang", NameAlt1 = "荥阳市", NameAlt2 = "滎陽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D27", Name = "Xinmi", NameAlt1 = "新密市", NameAlt2 = "新密市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D28", Name = "Xinxiang", NameAlt1 = "新乡市", NameAlt2 = "新鄉市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D29", Name = "Xinyang", NameAlt1 = "信阳市", NameAlt2 = "信陽市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D30", Name = "Xinzheng", NameAlt1 = "新郑市", NameAlt2 = "新鄭市" });

                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D31", Name = "Xuchang", NameAlt1 = "许昌市", NameAlt2 = "許昌市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D32", Name = "Yanshi", NameAlt1 = "偃师市", NameAlt2 = "偃師市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D33", Name = "Yima", NameAlt1 = "义马市", NameAlt2 = "義馬市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D34", Name = "Yongcheng", NameAlt1 = "永城市", NameAlt2 = "永城市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D35", Name = "Yuzhou", NameAlt1 = "禹州市", NameAlt2 = "禹州市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D36", Name = "Zhengzhou", NameAlt1 = "郑州市", NameAlt2 = "鄭州市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D37", Name = "Zhoukou", NameAlt1 = "周口市", NameAlt2 = "周口市" });
                result.Add(new CountryStateCityItem { Parent = "P09", Id = "D38", Name = "Zhumadian", NameAlt1 = "驻马店市", NameAlt2 = "駐馬店市" });
                #endregion

                #region P10 x 36 湖北
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D01", Name = "Anlu", NameAlt1 = "安陆市", NameAlt2 = "安陸市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D02", Name = "Chibi", NameAlt1 = "赤壁市", NameAlt2 = "赤壁市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D03", Name = "Dangyang", NameAlt1 = "当阳市", NameAlt2 = "當陽市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D04", Name = "Danjiangkou", NameAlt1 = "丹江口市", NameAlt2 = "丹江口市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D05", Name = "Daye", NameAlt1 = "大冶市", NameAlt2 = "大冶市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D06", Name = "Enshi City", NameAlt1 = "恩施市", NameAlt2 = "恩施市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D07", Name = "Ezhou", NameAlt1 = "鄂州市", NameAlt2 = "鄂州市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D08", Name = "Guangshui", NameAlt1 = "广水市", NameAlt2 = "廣水市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D09", Name = "Hanchuan", NameAlt1 = "汉川市", NameAlt2 = "漢川市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D10", Name = "Honghu", NameAlt1 = "洪湖市", NameAlt2 = "洪湖市" });

                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D11", Name = "Huanggang", NameAlt1 = "黄冈市", NameAlt2 = "黃岡市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D12", Name = "Huangshi", NameAlt1 = "黄石市", NameAlt2 = "黃石市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D13", Name = "Jingzhou", NameAlt1 = "荆州市", NameAlt2 = "荊州市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D14", Name = "Jingmen", NameAlt1 = "荆门市", NameAlt2 = "荊門市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D15", Name = "Laohekou", NameAlt1 = "老河口市", NameAlt2 = "老河口市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D16", Name = "Lichuan", NameAlt1 = "利川市", NameAlt2 = "利川市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D17", Name = "Macheng", NameAlt1 = "麻城市", NameAlt2 = "麻城市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D18", Name = "Qianjiang", NameAlt1 = "潜江市", NameAlt2 = "潛江市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D19", Name = "Shennongjia", NameAlt1 = "神农架林区", NameAlt2 = "神農架林區" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D20", Name = "Shishou", NameAlt1 = "石首市", NameAlt2 = "石首市" });

                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D21", Name = "Shiyan", NameAlt1 = "十堰市", NameAlt2 = "十堰市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D22", Name = "Songzi", NameAlt1 = "松滋市", NameAlt2 = "松滋市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D23", Name = "Suizhou", NameAlt1 = "随州市", NameAlt2 = "隨州市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D24", Name = "Tianmen", NameAlt1 = "天门市", NameAlt2 = "天門市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D25", Name = "Wuhan", NameAlt1 = "武汉市", NameAlt2 = "武漢市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D26", Name = "Wuxue", NameAlt1 = "武穴市", NameAlt2 = "武穴市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D27", Name = "Xiangyang", NameAlt1 = "襄阳市", NameAlt2 = "襄陽市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D28", Name = "Xianning", NameAlt1 = "咸宁市", NameAlt2 = "鹹寧市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D29", Name = "Xiantao", NameAlt1 = "仙桃市", NameAlt2 = "仙桃市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D30", Name = "Xiaogan", NameAlt1 = "孝感市", NameAlt2 = "孝感市" });

                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D31", Name = "Yichang", NameAlt1 = "宜昌市", NameAlt2 = "宜昌市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D32", Name = "Yidu", NameAlt1 = "宜都市", NameAlt2 = "宜都市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D33", Name = "Yingcheng", NameAlt1 = "应城市", NameAlt2 = "應城市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D34", Name = "Zaoyang", NameAlt1 = "枣阳市", NameAlt2 = "棗陽市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D35", Name = "Zhijiang", NameAlt1 = "枝江市", NameAlt2 = "枝江市" });
                result.Add(new CountryStateCityItem { Parent = "P10", Id = "D36", Name = "Zhongxiang", NameAlt1 = "锺祥市", NameAlt2 = "鍾祥市" });
                #endregion

                #region P11 x 30 湖南
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D01", Name = "Changde", NameAlt1 = "常德市", NameAlt2 = "常德市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D02", Name = "Changning", NameAlt1 = "常宁市", NameAlt2 = "常寧市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D03", Name = "Changsha", NameAlt1 = "长沙市", NameAlt2 = "長沙市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D04", Name = "Chenzhou", NameAlt1 = "郴州市", NameAlt2 = "郴州市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D05", Name = "Hengyang", NameAlt1 = "衡阳市", NameAlt2 = "衡陽市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D06", Name = "Hongjiang", NameAlt1 = "洪江市", NameAlt2 = "洪江市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D07", Name = "Huaihua", NameAlt1 = "怀化市", NameAlt2 = "懷化市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D08", Name = "Jinshi City", NameAlt1 = "津市市", NameAlt2 = "津市市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D09", Name = "Jishou", NameAlt1 = "吉首市", NameAlt2 = "吉首市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D10", Name = "Leiyang", NameAlt1 = "耒阳市", NameAlt2 = "耒陽市" });

                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D11", Name = "Lengshuijiang", NameAlt1 = "冷水江市", NameAlt2 = "冷水江市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D12", Name = "Lianyuan", NameAlt1 = "涟源市", NameAlt2 = "漣源市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D13", Name = "Liling", NameAlt1 = "醴陵市", NameAlt2 = "醴陵市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D14", Name = "Linxiang", NameAlt1 = "临湘市", NameAlt2 = "臨湘市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D15", Name = "Liuyang", NameAlt1 = "浏阳市", NameAlt2 = "瀏陽市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D16", Name = "Loudi", NameAlt1 = "娄底市", NameAlt2 = "婁底市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D17", Name = "Miluo City", NameAlt1 = "汨罗市", NameAlt2 = "汨羅市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D18", Name = "Shaoshan", NameAlt1 = "韶山市", NameAlt2 = "韶山市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D19", Name = "Shaoyang", NameAlt1 = "邵阳市", NameAlt2 = "邵陽市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D20", Name = "Wugang", NameAlt1 = "武冈市", NameAlt2 = "武岡市" });

                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D21", Name = "Xiangtan", NameAlt1 = "湘潭市", NameAlt2 = "安陸市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D22", Name = "Xiangxi Tujia and Miao Autonomous Prefecture", NameAlt1 = "湘西土家族苗族自治州", NameAlt2 = "湘西土家族苗族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D23", Name = "Xiangxiang", NameAlt1 = "湘乡市", NameAlt2 = "湘鄉市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D24", Name = "Yiyang", NameAlt1 = "益阳市", NameAlt2 = "益陽市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D25", Name = "Yongzhou", NameAlt1 = "永州市", NameAlt2 = "永州市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D26", Name = "Yuanjiang", NameAlt1 = "沅江市", NameAlt2 = "沅江市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D27", Name = "Yueyang", NameAlt1 = "岳阳市", NameAlt2 = "岳陽市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D28", Name = "Zhangjiajie", NameAlt1 = "张家界市", NameAlt2 = "張家界市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D29", Name = "Zhuzhou", NameAlt1 = "株洲市", NameAlt2 = "株洲市" });
                result.Add(new CountryStateCityItem { Parent = "P11", Id = "D30", Name = "Zixing", NameAlt1 = "资兴市", NameAlt2 = "資興市" });
                #endregion

                #region P12 x 34 江蘇
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D01", Name = "Changshu", NameAlt1 = "常熟市", NameAlt2 = "常熟市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D02", Name = "Changzhou", NameAlt1 = "常州市", NameAlt2 = "常州市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D03", Name = "Danyang", NameAlt1 = "丹阳市", NameAlt2 = "丹陽市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D04", Name = "Dongtai", NameAlt1 = "东台市", NameAlt2 = "東台市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D05", Name = "Gaoyou", NameAlt1 = "高邮市", NameAlt2 = "高郵市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D06", Name = "Haimen", NameAlt1 = "海门市", NameAlt2 = "海門市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D07", Name = "Huai'an", NameAlt1 = "淮安市", NameAlt2 = "淮安市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D08", Name = "Jiangyin", NameAlt1 = "江阴市", NameAlt2 = "江陰市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D09", Name = "Jingjiang", NameAlt1 = "靖江市", NameAlt2 = "靖江市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D10", Name = "Jurong", NameAlt1 = "句容市", NameAlt2 = "句容市" });

                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D11", Name = "Kunshan", NameAlt1 = "昆山市", NameAlt2 = "昆山市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D12", Name = "Lianyungang", NameAlt1 = "连云港市", NameAlt2 = "連雲港市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D13", Name = "Liyang", NameAlt1 = "溧阳市", NameAlt2 = "溧陽市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D14", Name = "Nanjing", NameAlt1 = "南京市", NameAlt2 = "南京市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D15", Name = "Nantong", NameAlt1 = "南通市", NameAlt2 = "南通市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D16", Name = "Pizhou", NameAlt1 = "邳州市", NameAlt2 = "邳州市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D17", Name = "Qidong", NameAlt1 = "启东市", NameAlt2 = "啟東市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D18", Name = "Rugao", NameAlt1 = "如皋市", NameAlt2 = "如皋市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D19", Name = "Suqian", NameAlt1 = "宿迁市", NameAlt2 = "宿遷市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D20", Name = "Suzhou", NameAlt1 = "苏州市", NameAlt2 = "蘇州市" });

                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D21", Name = "Taicang", NameAlt1 = "太仓市", NameAlt2 = "太倉市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D22", Name = "Taixing", NameAlt1 = "泰兴市", NameAlt2 = "泰興市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D23", Name = "Taizhou", NameAlt1 = "泰州市", NameAlt2 = "泰州市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D24", Name = "Wuxi", NameAlt1 = "无锡市", NameAlt2 = "無錫市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D25", Name = "Xinghua", NameAlt1 = "兴化市", NameAlt2 = "興化市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D26", Name = "Xinyi", NameAlt1 = "新沂市", NameAlt2 = "新沂市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D27", Name = "Xuzhou", NameAlt1 = "徐州市", NameAlt2 = "徐州市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D28", Name = "Yancheng", NameAlt1 = "盐城市", NameAlt2 = "鹽城市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D29", Name = "Yangzhong", NameAlt1 = "扬中市", NameAlt2 = "揚中市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D30", Name = "Yangzhou", NameAlt1 = "扬州市", NameAlt2 = "揚州市" });

                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D31", Name = "Yixing", NameAlt1 = "宜兴市", NameAlt2 = "宜興市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D32", Name = "Yizheng", NameAlt1 = "仪征市", NameAlt2 = "儀征市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D33", Name = "Zhangjiagang", NameAlt1 = "张家港市", NameAlt2 = "張家港市" });
                result.Add(new CountryStateCityItem { Parent = "P12", Id = "D34", Name = "Zhenjiang", NameAlt1 = "镇江市", NameAlt2 = "鎮江市" });
                #endregion

                #region P13 x 21 江西
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D01", Name = "Dexing", NameAlt1 = "德兴市", NameAlt2 = "德興市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D02", Name = "Fengcheng", NameAlt1 = "丰城市", NameAlt2 = "豐城市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D03", Name = "Fuzhou", NameAlt1 = "抚州市", NameAlt2 = "撫州市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D04", Name = "Ganzhou", NameAlt1 = "赣州市", NameAlt2 = "贛州市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D05", Name = "Gao'an", NameAlt1 = "高安市", NameAlt2 = "高安市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D06", Name = "ChanGuixigshu", NameAlt1 = "贵溪市", NameAlt2 = "貴溪市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D07", Name = "Ji'an", NameAlt1 = "吉安市", NameAlt2 = "吉安市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D08", Name = "Jingdezhen", NameAlt1 = "景德镇市", NameAlt2 = "景德鎮市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D09", Name = "Jinggangshan City", NameAlt1 = "井冈山市", NameAlt2 = "井岡山市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D10", Name = "Jiujiang", NameAlt1 = "九江市", NameAlt2 = "九江市" });

                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D11", Name = "Leping", NameAlt1 = "乐平市", NameAlt2 = "樂平市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D12", Name = "Nanchang", NameAlt1 = "南昌市", NameAlt2 = "南昌市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D13", Name = "Nankang", NameAlt1 = "南康区", NameAlt2 = "南康區" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D14", Name = "Pingxiang", NameAlt1 = "萍乡市", NameAlt2 = "萍鄉市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D15", Name = "Ruichang", NameAlt1 = "瑞昌市", NameAlt2 = "瑞昌市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D16", Name = "Ruijin", NameAlt1 = "瑞金市", NameAlt2 = "瑞金市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D17", Name = "Shangrao", NameAlt1 = "上饶市", NameAlt2 = "上饒市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D18", Name = "Xinyu", NameAlt1 = "新余市", NameAlt2 = "新余市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D19", Name = "Yichun", NameAlt1 = "宜春市", NameAlt2 = "宜春市" });
                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D20", Name = "Yingtan", NameAlt1 = "鹰潭市", NameAlt2 = "鷹潭市" });

                result.Add(new CountryStateCityItem { Parent = "P13", Id = "D21", Name = "Zhangshu", NameAlt1 = "樟树市", NameAlt2 = "樟樹市" });
                #endregion

                #region P14 x 28 吉林
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D01", Name = "Baicheng", NameAlt1 = "白城市", NameAlt2 = "白城市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D02", Name = "Changchun", NameAlt1 = "长春市", NameAlt2 = "長春市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D03", Name = "Da'an", NameAlt1 = "大安市", NameAlt2 = "大安市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D04", Name = "Dehui", NameAlt1 = "德惠市", NameAlt2 = "德惠市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D05", Name = "Dunhua", NameAlt1 = "敦化市", NameAlt2 = "敦化市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D06", Name = "Gongzhuling", NameAlt1 = "公主岭市", NameAlt2 = "公主嶺市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D07", Name = "Hakusan", NameAlt1 = "白山市", NameAlt2 = "白山市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D08", Name = "Helong", NameAlt1 = "和龙市", NameAlt2 = "和龍市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D09", Name = "Huadian", NameAlt1 = "桦甸市", NameAlt2 = "樺甸市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D10", Name = "Hunchun", NameAlt1 = "珲春市", NameAlt2 = "琿春市" });

                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D11", Name = "Ji'an", NameAlt1 = "集安市", NameAlt2 = "集安市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D12", Name = "Jiaohe", NameAlt1 = "蛟河市", NameAlt2 = "蛟河市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D13", Name = "Jilin City", NameAlt1 = "吉林市", NameAlt2 = "吉林市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D14", Name = "Liaoyuan", NameAlt1 = "辽源市", NameAlt2 = "遼源市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D15", Name = "Linjiang", NameAlt1 = "临江市", NameAlt2 = "臨江市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D16", Name = "Longjing", NameAlt1 = "龙井市", NameAlt2 = "龍井市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D17", Name = "Meihekou", NameAlt1 = "梅河口市", NameAlt2 = "梅河口市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D18", Name = "Panshi", NameAlt1 = "磐石市", NameAlt2 = "磐石市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D19", Name = "Shuangliao", NameAlt1 = "双辽市", NameAlt2 = "雙遼市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D20", Name = "Shulan", NameAlt1 = "舒兰市", NameAlt2 = "舒蘭市" });

                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D21", Name = "Siping", NameAlt1 = "四平市", NameAlt2 = "四平市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D22", Name = "Songyuan", NameAlt1 = "松原市", NameAlt2 = "松原市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D23", Name = "Taonan", NameAlt1 = "洮南市", NameAlt2 = "洮南市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D24", Name = "Tonghua", NameAlt1 = "通化市", NameAlt2 = "通化市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D25", Name = "Tumen", NameAlt1 = "图们市", NameAlt2 = "圖們市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D26", Name = "Yanbian Korean Autonomous Prefecture", NameAlt1 = "延边朝鲜族自治州", NameAlt2 = "延邊朝鮮族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D27", Name = "Yanji", NameAlt1 = "延吉市", NameAlt2 = "延吉市" });
                result.Add(new CountryStateCityItem { Parent = "P14", Id = "D28", Name = "Yushu", NameAlt1 = "榆树市", NameAlt2 = "榆樹市" });
                #endregion

                #region P15 x 30 遼寧
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D01", Name = "Anshan", NameAlt1 = "鞍山市", NameAlt2 = "鞍山市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D02", Name = "Beipiao", NameAlt1 = "北票市", NameAlt2 = "北票市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D03", Name = "Beizhen", NameAlt1 = "北镇市", NameAlt2 = "北鎮市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D04", Name = "Benxi", NameAlt1 = "本溪市", NameAlt2 = "本溪市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D05", Name = "Chaoyang", NameAlt1 = "朝阳市", NameAlt2 = "朝陽市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D06", Name = "Dalian", NameAlt1 = "大连市", NameAlt2 = "大連市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D07", Name = "Dandong", NameAlt1 = "丹东市", NameAlt2 = "丹東市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D08", Name = "Dashiqiao", NameAlt1 = "大石桥市", NameAlt2 = "大石橋市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D09", Name = "Dengta", NameAlt1 = "灯塔市", NameAlt2 = "燈塔市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D10", Name = "Diaobingshan", NameAlt1 = "调兵山市", NameAlt2 = "調兵山市" });

                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D11", Name = "Donggang", NameAlt1 = "东港市", NameAlt2 = "東港市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D12", Name = "Fengcheng", NameAlt1 = "凤城市", NameAlt2 = "鳳城市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D13", Name = "Fushun", NameAlt1 = "抚顺市", NameAlt2 = "撫順市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D14", Name = "Fuxin", NameAlt1 = "阜新市", NameAlt2 = "阜新市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D15", Name = "Gaizhou", NameAlt1 = "盖州市", NameAlt2 = "蓋州市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D16", Name = "Haicheng", NameAlt1 = "海城市", NameAlt2 = "海城市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D17", Name = "Huludao", NameAlt1 = "葫芦岛市", NameAlt2 = "葫蘆島市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D18", Name = "Jinzhou", NameAlt1 = "锦州市", NameAlt2 = "錦州市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D19", Name = "Kaiyuan", NameAlt1 = "开原市", NameAlt2 = "開原市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D20", Name = "Liaoyang", NameAlt1 = "辽阳市", NameAlt2 = "遼陽市" });

                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D21", Name = "Linghai", NameAlt1 = "凌海市", NameAlt2 = "凌海市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D22", Name = "Lingyuan", NameAlt1 = "凌源市", NameAlt2 = "凌源市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D23", Name = "Panjin", NameAlt1 = "盘锦市", NameAlt2 = "盤錦市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D24", Name = "Shenyang", NameAlt1 = "沈阳市", NameAlt2 = "沈陽市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D25", Name = "Tieling", NameAlt1 = "铁岭市", NameAlt2 = "鐵嶺市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D26", Name = "Wafangdian", NameAlt1 = "瓦房店市", NameAlt2 = "瓦房店市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D27", Name = "Xingcheng", NameAlt1 = "兴城市", NameAlt2 = "興城市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D28", Name = "Xinmin", NameAlt1 = "新民市", NameAlt2 = "新民市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D29", Name = "Yingkou", NameAlt1 = "营口市", NameAlt2 = "營口市" });
                result.Add(new CountryStateCityItem { Parent = "P15", Id = "D30", Name = "Zhuanghe", NameAlt1 = "庄河市", NameAlt2 = "莊河市" });
                #endregion

                #region P16 x 10 青海
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D01", Name = "Delingha", NameAlt1 = "德令哈市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D02", Name = "Golmud", NameAlt1 = "格尔木市", NameAlt2 = "格爾木市" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D03", Name = "Golog Tibetan Autonomous Prefecture", NameAlt1 = "果洛藏族自治州", NameAlt2 = "果洛藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D04", Name = "Haibei Tibetan Autonomous Prefecture", NameAlt1 = "海北藏族自治州", NameAlt2 = "海北藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D05", Name = "Haidong", NameAlt1 = "海东市", NameAlt2 = "海東市" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D06", Name = "Hainan Tibetan Autonomous Prefecture", NameAlt1 = "海南藏族自治州", NameAlt2 = "海南藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D07", Name = "Haixi Mongol and Tibetan Autonomous Prefecture", NameAlt1 = "海西蒙古族藏族自治州", NameAlt2 = "海西蒙古族藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D08", Name = "Huangnan Tibetan Autonomous Prefecture", NameAlt1 = "黄南藏族自治州", NameAlt2 = "黃南藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D09", Name = "Xining", NameAlt1 = "西宁市", NameAlt2 = "西寧市" });
                result.Add(new CountryStateCityItem { Parent = "P16", Id = "D10", Name = "Yushu Tibetan Autonomous Prefecture", NameAlt1 = "玉树藏族自治州", NameAlt2 = "玉樹藏族自治州" });
                #endregion

                #region P17 x 44 山東
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D01", Name = "Anqiu", NameAlt1 = "安丘市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D02", Name = "Binzhou", NameAlt1 = "滨州市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D03", Name = "Changyi", NameAlt1 = "昌邑市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D04", Name = "Dezhou", NameAlt1 = "德州市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D05", Name = "Dongying", NameAlt1 = "东营市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D06", Name = "Feicheng", NameAlt1 = "肥城市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D07", Name = "Gaomi", NameAlt1 = "高密市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D08", Name = "Haiyang", NameAlt1 = "海阳市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D09", Name = "Heze", NameAlt1 = "菏泽市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D10", Name = "Jiaozhou City", NameAlt1 = "胶州市", NameAlt2 = "德令哈市" });

                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D11", Name = "Jimo", NameAlt1 = "即墨区", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D12", Name = "Jinan", NameAlt1 = "济南市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D13", Name = "Jining", NameAlt1 = "济宁市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D14", Name = "Laiwu", NameAlt1 = "莱芜市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D15", Name = "Laixi", NameAlt1 = "莱西市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D16", Name = "Laiyang", NameAlt1 = "莱阳市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D17", Name = "Laizhou", NameAlt1 = "莱州市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D18", Name = "Laoling", NameAlt1 = "乐陵市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D19", Name = "Liaocheng", NameAlt1 = "聊城市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D20", Name = "Linqing", NameAlt1 = "临清市", NameAlt2 = "德令哈市" });

                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D21", Name = "Linyi", NameAlt1 = "临沂市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D22", Name = "Longkou", NameAlt1 = "龙口市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D23", Name = "Penglai", NameAlt1 = "蓬莱市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D24", Name = "Pingdu", NameAlt1 = "平度市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D25", Name = "Qingdao", NameAlt1 = "青岛市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D26", Name = "Qingzhou", NameAlt1 = "青州市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D27", Name = "Qixia", NameAlt1 = "栖霞市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D28", Name = "Qufu", NameAlt1 = "曲阜市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D29", Name = "Rizhao", NameAlt1 = "日照市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D30", Name = "Rongcheng", NameAlt1 = "荣成市", NameAlt2 = "德令哈市" });

                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D31", Name = "Rushan", NameAlt1 = "乳山市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D32", Name = "Shouguang", NameAlt1 = "寿光市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D33", Name = "Tai'an", NameAlt1 = "泰安市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D34", Name = "Tengzhou", NameAlt1 = "滕州市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D35", Name = "Weifang", NameAlt1 = "潍坊市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D36", Name = "Weihai", NameAlt1 = "威海市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D37", Name = "Xintai", NameAlt1 = "新泰市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D38", Name = "Yantai", NameAlt1 = "烟台市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D39", Name = "Yucheng", NameAlt1 = "禹城市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D40", Name = "Zaozhuang", NameAlt1 = "枣庄市", NameAlt2 = "德令哈市" });

                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D41", Name = "Zhaoyuan", NameAlt1 = "招远市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D42", Name = "Zhucheng", NameAlt1 = "诸城市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D43", Name = "Zibo", NameAlt1 = "淄博市", NameAlt2 = "德令哈市" });
                result.Add(new CountryStateCityItem { Parent = "P17", Id = "D44", Name = "Zoucheng", NameAlt1 = "邹城市", NameAlt2 = "德令哈市" });
                #endregion

                #region P18 x 13 陝西
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D01", Name = "Ankang", NameAlt1 = "安康市", NameAlt2 = "安康市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D02", Name = "Baoji", NameAlt1 = "宝鸡市", NameAlt2 = "寶雞市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D03", Name = "Hancheng", NameAlt1 = "韩城市", NameAlt2 = "韓城市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D04", Name = "Hanzhong", NameAlt1 = "汉中市", NameAlt2 = "漢中市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D05", Name = "Huayin", NameAlt1 = "华阴市", NameAlt2 = "華陰市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D06", Name = "Shangluo", NameAlt1 = "商洛市", NameAlt2 = "商洛市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D07", Name = "Tongchuan", NameAlt1 = "铜川市", NameAlt2 = "銅川市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D08", Name = "Weinan", NameAlt1 = "渭南市", NameAlt2 = "渭南市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D09", Name = "Xi'an", NameAlt1 = "西安市", NameAlt2 = "西安市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D10", Name = "Xianyang", NameAlt1 = "咸阳市", NameAlt2 = "鹹陽市" });

                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D11", Name = "Xingping", NameAlt1 = "兴平市", NameAlt2 = "興平市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D12", Name = "Yan'an", NameAlt1 = "延安市", NameAlt2 = "延安市" });
                result.Add(new CountryStateCityItem { Parent = "P18", Id = "D13", Name = "Yulin", NameAlt1 = "榆林市", NameAlt2 = "榆林市" });
                #endregion

                #region P19 x 21 山西
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D01", Name = "Changzhi", NameAlt1 = "长治市", NameAlt2 = "長治市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D02", Name = "Datong", NameAlt1 = "大同市", NameAlt2 = "大同市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D03", Name = "Fenyang", NameAlt1 = "汾阳市", NameAlt2 = "汾陽市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D04", Name = "Gaoping", NameAlt1 = "高平市", NameAlt2 = "高平市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D05", Name = "Gujiao", NameAlt1 = "古交市", NameAlt2 = "古交市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D06", Name = "Hejin", NameAlt1 = "河津市", NameAlt2 = "河津市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D07", Name = "Houma", NameAlt1 = "侯马市", NameAlt2 = "侯馬市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D08", Name = "Huozhou", NameAlt1 = "霍州市", NameAlt2 = "霍州市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D09", Name = "Jiexiu", NameAlt1 = "介休市", NameAlt2 = "介休市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D10", Name = "Jincheng", NameAlt1 = "晋城市", NameAlt2 = "晉城市" });

                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D11", Name = "Jinzhong", NameAlt1 = "晋中市", NameAlt2 = "晉中市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D12", Name = "Linfen", NameAlt1 = "临汾市", NameAlt2 = "臨汾市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D13", Name = "Lüliang", NameAlt1 = "吕梁市", NameAlt2 = "呂梁市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D14", Name = "Shuozhou", NameAlt1 = "朔州市", NameAlt2 = "朔州市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D15", Name = "Taiyuan", NameAlt1 = "太原市", NameAlt2 = "太原市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D16", Name = "Xiaoyi", NameAlt1 = "孝义市", NameAlt2 = "孝義市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D17", Name = "Xinzhou", NameAlt1 = "忻州市", NameAlt2 = "忻州市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D18", Name = "Yangquan", NameAlt1 = "阳泉市", NameAlt2 = "陽泉市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D19", Name = "Yongji", NameAlt1 = "永济市", NameAlt2 = "永濟市" });
                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D20", Name = "Yuanping", NameAlt1 = "原平市", NameAlt2 = "原平市" });

                result.Add(new CountryStateCityItem { Parent = "P19", Id = "D21", Name = "Yuncheng", NameAlt1 = "运城市", NameAlt2 = "運城市" });
                #endregion

                #region P20 x 35 四川
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D01", Name = "Bazhong", NameAlt1 = "巴中市", NameAlt2 = "巴中市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D02", Name = "Chengdu", NameAlt1 = "成都市", NameAlt2 = "成都市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D03", Name = "Chongzhou", NameAlt1 = "崇州市", NameAlt2 = "崇州市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D04", Name = "Dazhou", NameAlt1 = "达州市", NameAlt2 = "達州市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D05", Name = "Deyang", NameAlt1 = "德阳市", NameAlt2 = "德陽市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D06", Name = "Dujiangyan City", NameAlt1 = "都江堰市", NameAlt2 = "都江堰市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D07", Name = "Emeishan City", NameAlt1 = "峨眉山市", NameAlt2 = "峨眉山市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D08", Name = "Garzê Tibetan Autonomous Prefecture", NameAlt1 = "甘孜藏族自治州", NameAlt2 = "甘孜藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D09", Name = "Guang'an", NameAlt1 = "广安市", NameAlt2 = "廣安市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D10", Name = "Guanghan", NameAlt1 = "广汉市", NameAlt2 = "廣漢市" });

                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D11", Name = "Guangyuan", NameAlt1 = "广元市", NameAlt2 = "廣元市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D12", Name = "Huaying", NameAlt1 = "华蓥市", NameAlt2 = "華鎣市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D13", Name = "Jiangyou", NameAlt1 = "江油市", NameAlt2 = "江油市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D14", Name = "Jianyang", NameAlt1 = "简阳市", NameAlt2 = "簡陽市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D15", Name = "Langzhong", NameAlt1 = "阆中市", NameAlt2 = "閬中市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D16", Name = "Leshan", NameAlt1 = "乐山市", NameAlt2 = "樂山市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D17", Name = "Liangshan Yi Autonomous Prefecture", NameAlt1 = "凉山彝族自治州", NameAlt2 = "涼山彝族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D18", Name = "Luzhou", NameAlt1 = "泸州市", NameAlt2 = "瀘州市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D19", Name = "Meishan", NameAlt1 = "眉山市", NameAlt2 = "眉山市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D20", Name = "Mianyang", NameAlt1 = "绵阳市", NameAlt2 = "綿陽市" });

                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D21", Name = "Mianzhu", NameAlt1 = "绵竹市", NameAlt2 = "綿竹市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D22", Name = "Nanchong", NameAlt1 = "南充市", NameAlt2 = "南充市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D23", Name = "Neijiang", NameAlt1 = "长治市", NameAlt2 = "內江市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D24", Name = "Ngawa Tibetan and Qiang Autonomous Prefecture", NameAlt1 = "阿坝藏族羌族自治州", NameAlt2 = "阿壩藏族羌族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D25", Name = "Panzhihua", NameAlt1 = "攀枝花市", NameAlt2 = "攀枝花市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D26", Name = "Pengzhou", NameAlt1 = "彭州市", NameAlt2 = "彭州市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D27", Name = "Qionglai City", NameAlt1 = "邛崃市", NameAlt2 = "邛崍市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D28", Name = "Shifang", NameAlt1 = "什邡市", NameAlt2 = "什邡市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D29", Name = "Suining", NameAlt1 = "遂宁市", NameAlt2 = "遂寧市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D30", Name = "Wanyuan", NameAlt1 = "万源市", NameAlt2 = "萬源市" });

                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D31", Name = "Xichang", NameAlt1 = "西昌市", NameAlt2 = "西昌市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D32", Name = "Ya'an", NameAlt1 = "雅安市", NameAlt2 = "雅安市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D33", Name = "Yibin", NameAlt1 = "雅安市", NameAlt2 = "宜賓市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D34", Name = "Zigong", NameAlt1 = "自贡市", NameAlt2 = "自貢市" });
                result.Add(new CountryStateCityItem { Parent = "P20", Id = "D35", Name = "Ziyang", NameAlt1 = "资阳市", NameAlt2 = "資陽市" });
                #endregion

                #region P21 x 24 雲南
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D01", Name = "Anning", NameAlt1 = "安宁市", NameAlt2 = "安寧市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D02", Name = "Baoshan", NameAlt1 = "保山市", NameAlt2 = "保山市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D03", Name = "Chuxiong City", NameAlt1 = "楚雄市", NameAlt2 = "楚雄市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D04", Name = "Chuxiong Yi Autonomous Prefecture", NameAlt1 = "楚雄彝族自治州", NameAlt2 = "楚雄彝族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D05", Name = "Dali", NameAlt1 = "大理市", NameAlt2 = "大理市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D06", Name = "Dehong Dai and Jingpo Autonomous Prefecture", NameAlt1 = "德宏傣族景颇族自治州", NameAlt2 = "德宏傣族景頗族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D07", Name = "Diqing Tibetan Autonomous Prefecture", NameAlt1 = "迪庆藏族自治州", NameAlt2 = "迪慶藏族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D08", Name = "Gejiu", NameAlt1 = "个旧市", NameAlt2 = "個舊市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D09", Name = "Honghe Hani and Yi Autonomous Prefecture", NameAlt1 = "红河哈尼族彝族自治州", NameAlt2 = "紅河哈尼族彝族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D10", Name = "Jinghong", NameAlt1 = "景洪市", NameAlt2 = "景洪市" });

                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D11", Name = "Kaiyuan", NameAlt1 = "开远市", NameAlt2 = "開遠市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D12", Name = "Kunming", NameAlt1 = "昆明市", NameAlt2 = "昆明市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D13", Name = "Lijiang", NameAlt1 = "丽江市", NameAlt2 = "麗江市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D14", Name = "Lincang", NameAlt1 = "临沧市", NameAlt2 = "臨滄市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D15", Name = "Mangshi", NameAlt1 = "芒市", NameAlt2 = "芒市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D16", Name = "Nujiang Lisu Autonomous Prefecture", NameAlt1 = "怒江傈僳族自治州", NameAlt2 = "怒江傈僳族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D17", Name = "Pu'er City", NameAlt1 = "普洱市", NameAlt2 = "普洱市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D18", Name = "Qujing", NameAlt1 = "曲靖市", NameAlt2 = "曲靖市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D19", Name = "Ruili", NameAlt1 = "瑞丽市", NameAlt2 = "瑞麗市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D20", Name = "Wenshan Zhuang and Miao Autonomous Prefecture", NameAlt1 = "文山壮族苗族自治州", NameAlt2 = "文山壯族苗族自治州" });

                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D21", Name = "Xishuangbanna Dai Autonomous Prefecture", NameAlt1 = "西双版纳傣族自治州", NameAlt2 = "西雙版納傣族自治州" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D22", Name = "Xuanwei", NameAlt1 = "宣威市", NameAlt2 = "宣威市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D23", Name = "Yuxi", NameAlt1 = "玉溪市", NameAlt2 = "玉溪市" });
                result.Add(new CountryStateCityItem { Parent = "P21", Id = "D24", Name = "Zhaotong", NameAlt1 = "昭通市", NameAlt2 = "昭通市" });
                #endregion

                #region P22 x 29 浙江
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D01", Name = "Cixi", NameAlt1 = "慈溪市", NameAlt2 = "慈溪市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D02", Name = "Dongyang", NameAlt1 = "东阳市", NameAlt2 = "東陽市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D03", Name = "Haining", NameAlt1 = "海宁市", NameAlt2 = "安寧市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D04", Name = "Hangzhou", NameAlt1 = "杭州市", NameAlt2 = "杭州市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D05", Name = "Huzhou", NameAlt1 = "湖州市", NameAlt2 = "湖州市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D06", Name = "Jiande", NameAlt1 = "建德市", NameAlt2 = "建德市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D07", Name = "Jiangshan", NameAlt1 = "江山市", NameAlt2 = "江山市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D08", Name = "Jiaxing", NameAlt1 = "嘉兴市", NameAlt2 = "嘉興市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D09", Name = "Jinhua", NameAlt1 = "金华市", NameAlt2 = "金華市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D10", Name = "Lanxi", NameAlt1 = "兰溪市", NameAlt2 = "蘭溪市" });

                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D11", Name = "Linhai", NameAlt1 = "临海市", NameAlt2 = "臨海市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D12", Name = "Lishui", NameAlt1 = "丽水市", NameAlt2 = "麗水市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D13", Name = "Longquan", NameAlt1 = "龙泉市", NameAlt2 = "龍泉市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D14", Name = "Ningbo", NameAlt1 = "宁波市", NameAlt2 = "寧波市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D15", Name = "Pinghu", NameAlt1 = "平湖市", NameAlt2 = "平湖市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D16", Name = "Quzhou", NameAlt1 = "衢州市", NameAlt2 = "衢州市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D17", Name = "Rui'an", NameAlt1 = "瑞安市", NameAlt2 = "瑞安市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D18", Name = "Shaoxing", NameAlt1 = "绍兴市", NameAlt2 = "紹興市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D19", Name = "Shengzhou", NameAlt1 = "嵊州市", NameAlt2 = "嵊州市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D20", Name = "Taizhou", NameAlt1 = "台州市", NameAlt2 = "台州市" });

                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D21", Name = "Tongxiang", NameAlt1 = "桐乡市", NameAlt2 = "桐鄉市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D22", Name = "Wenling", NameAlt1 = "温岭市", NameAlt2 = "溫嶺市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D23", Name = "Wenzhou", NameAlt1 = "温州市", NameAlt2 = "溫州市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D24", Name = "Yiwu", NameAlt1 = "义乌市", NameAlt2 = "義烏市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D25", Name = "Yongkang", NameAlt1 = "永康市", NameAlt2 = "永康市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D26", Name = "Yueqing", NameAlt1 = "乐清市", NameAlt2 = "樂清市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D27", Name = "Yuyao", NameAlt1 = "余姚市", NameAlt2 = "余姚市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D28", Name = "Zhoushan", NameAlt1 = "舟山市", NameAlt2 = "舟山市" });
                result.Add(new CountryStateCityItem { Parent = "P22", Id = "D29", Name = "Zhuji", NameAlt1 = "诸暨市", NameAlt2 = "諸暨市" });
                #endregion

                #region P23 x  台灣
                //result.Add(new CountryStateCityItem { Parent = "P23", Id = "D01", Name = "Cixi", NameAlt1 = "慈溪市", NameAlt2 = "慈溪市" });
                #endregion

                return result;
            }
        }
    }
}