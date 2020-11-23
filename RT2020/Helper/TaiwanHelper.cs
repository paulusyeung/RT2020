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
    public class TaiwanHelper
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
                        var country = ctx.Country.Where(x => x.CountryCode == "TW").FirstOrDefault();

                        if (country == null)
                        {
                            country = new EF6.Country();
                            country.CountryId = Guid.NewGuid();
                            ctx.Country.Add(country);
                        }

                        country.CountryCode = Taiwan.Id;
                        country.CountryName = Taiwan.Name;
                        country.CountryName_Chs = Taiwan.NameAlt1;
                        country.CountryName_Cht = Taiwan.NameAlt2;

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

        public static CountryStateCityItem Taiwan
        {
            get
            {
                return new CountryStateCityItem { Parent = "", Id = "TW", Name = "Taiwan", NameAlt1 = "台湾", NameAlt2 = "台灣" };
            }
        }

        // refer: http://gn.moi.gov.tw/geonames/DataFile/%E8%87%BA%E7%81%A3%E5%9C%B0%E5%8D%80%E9%84%89%E9%8E%AE%E5%B8%82%E5%8D%80%E7%B4%9A%E4%BB%A5%E4%B8%8A%E8%A1%8C%E6%94%BF%E5%8D%80%E5%9F%9F%E5%90%8D%E7%A8%B1%E4%B8%AD%E8%8B%B1%E5%B0%8D%E7%85%A7%E8%A1%A8.pdf
        private static List<CountryStateCityItem> Region
        {
            get
            {
                var result = new List<CountryStateCityItem>();

                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R01", Name = "Changhua County", NameAlt1 = "彰化县", NameAlt2 = "彰化縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R02", Name = "Chiayi City", NameAlt1 = "嘉义市", NameAlt2 = "嘉義市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R03", Name = "Chiayi County", NameAlt1 = "嘉义县", NameAlt2 = "嘉義縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R04", Name = "Hsinchu City", NameAlt1 = "新竹市", NameAlt2 = "新竹市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R05", Name = "Hsinchu County", NameAlt1 = "新竹县", NameAlt2 = "新竹縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R06", Name = "Hualien County", NameAlt1 = "花莲县", NameAlt2 = "花蓮縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R07", Name = "Kaohsiung City", NameAlt1 = "高雄市", NameAlt2 = "高雄市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R08", Name = "Keelung City", NameAlt1 = "基隆市", NameAlt2 = "基隆市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R09", Name = "Kinmen County", NameAlt1 = "金门县", NameAlt2 = "金門縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R10", Name = "Lienchiang County", NameAlt1 = "连江县", NameAlt2 = "連江縣" });

                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R11", Name = "Miaoli County", NameAlt1 = "苗栗县", NameAlt2 = "苗栗縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R12", Name = "Nantou County", NameAlt1 = "南投县", NameAlt2 = "南投縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R13", Name = "New Taipei City", NameAlt1 = "新北市", NameAlt2 = "新北市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R14", Name = "Penghu County", NameAlt1 = "澎湖县", NameAlt2 = "澎湖縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R15", Name = "Pingtung County", NameAlt1 = "屏东县", NameAlt2 = "屏東縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R16", Name = "Taichung City", NameAlt1 = "台中市", NameAlt2 = "臺中市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R17", Name = "Tainan City", NameAlt1 = "台南市", NameAlt2 = "臺南市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R18", Name = "Taipei City", NameAlt1 = "台北市", NameAlt2 = "臺北市" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R19", Name = "Taitung County", NameAlt1 = "台东县", NameAlt2 = "臺東縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R20", Name = "Taoyuan City", NameAlt1 = "桃园市", NameAlt2 = "桃園市" });

                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R21", Name = "Yilan County", NameAlt1 = "宜兰县", NameAlt2 = "宜蘭縣" });
                result.Add(new CountryStateCityItem { Parent = "TW", Id = "R22", Name = "Yunlin County", NameAlt1 = "云林县", NameAlt2 = "雲林縣" });
                return result;
            }
        }

        /// <summary>
        /// refer: http://gn.moi.gov.tw/geonames/DataFile/%E8%87%BA%E7%81%A3%E5%9C%B0%E5%8D%80%E9%84%89%E9%8E%AE%E5%B8%82%E5%8D%80%E7%B4%9A%E4%BB%A5%E4%B8%8A%E8%A1%8C%E6%94%BF%E5%8D%80%E5%9F%9F%E5%90%8D%E7%A8%B1%E4%B8%AD%E8%8B%B1%E5%B0%8D%E7%85%A7%E8%A1%A8.pdf
        /// </summary>
        private static List<CountryStateCityItem> District
        {
            get
            {
                var result = new List<CountryStateCityItem>();

                #region R01 x 13 彰化縣
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D01", Name = "Central", NameAlt1 = "丰滨乡", NameAlt2 = "豐濱鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D02", Name = "Central", NameAlt1 = "凤林镇", NameAlt2 = "鳳林鎮" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D03", Name = "Central", NameAlt1 = "富里乡", NameAlt2 = "富里鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D04", Name = "Central", NameAlt1 = "光复乡", NameAlt2 = "光復鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D05", Name = "Central", NameAlt1 = "花莲市", NameAlt2 = "花蓮市" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D06", Name = "Central", NameAlt1 = "吉安乡", NameAlt2 = "吉安鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D07", Name = "Central", NameAlt1 = "瑞穗乡", NameAlt2 = "瑞穗鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D08", Name = "Central", NameAlt1 = "寿丰乡", NameAlt2 = "壽豐鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D09", Name = "Central", NameAlt1 = "万荣乡", NameAlt2 = "萬榮鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D10", Name = "Central", NameAlt1 = "新城乡", NameAlt2 = "新城鄉" });

                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D11", Name = "Central", NameAlt1 = "秀林乡", NameAlt2 = "秀林鄉" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D12", Name = "Central", NameAlt1 = "玉里镇", NameAlt2 = "玉里鎮" });
                result.Add(new CountryStateCityItem { Parent = "R01", Id = "D13", Name = "Central", NameAlt1 = "卓溪乡", NameAlt2 = "卓溪鄉" });
                #endregion

                #region R02 x 2 嘉義市
                result.Add(new CountryStateCityItem { Parent = "R02", Id = "D01", Name = "East District", NameAlt1 = "东区", NameAlt2 = "東區" });
                result.Add(new CountryStateCityItem { Parent = "R02", Id = "D02", Name = "West District", NameAlt1 = "西区", NameAlt2 = "西區" });
                #endregion

                #region R03 x 18 嘉義縣
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D01", Name = "Alishan Township", NameAlt1 = "阿里山乡", NameAlt2 = "阿里山鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D02", Name = "Budai Township", NameAlt1 = "布袋镇", NameAlt2 = "布袋鎮" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D03", Name = "Dalin Township", NameAlt1 = "大林镇", NameAlt2 = "大林鎮" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D04", Name = "Dapu Township", NameAlt1 = "大埔乡", NameAlt2 = "大埔鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D05", Name = "Dongshi Township", NameAlt1 = "东石乡", NameAlt2 = "東石鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D06", Name = "Fanlu Township", NameAlt1 = "番路乡", NameAlt2 = "番路鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D07", Name = "Liujiao Township", NameAlt1 = "六脚乡", NameAlt2 = "六腳鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D08", Name = "Lucao Township", NameAlt1 = "鹿草乡", NameAlt2 = "鹿草鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D09", Name = "Meishan Township", NameAlt1 = "梅山乡", NameAlt2 = "梅山鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D10", Name = "Minxiong Township", NameAlt1 = "民雄乡", NameAlt2 = "民雄鄉" });

                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D11", Name = "Puzi City", NameAlt1 = "朴子市", NameAlt2 = "朴子市" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D12", Name = "Shuishang Township", NameAlt1 = "水上乡", NameAlt2 = "水上鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D13", Name = "Taibao City", NameAlt1 = "太保市", NameAlt2 = "太保市" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D14", Name = "Xikou Township", NameAlt1 = "溪口乡", NameAlt2 = "溪口鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D15", Name = "Xingang Township", NameAlt1 = "新港乡", NameAlt2 = "新港鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D16", Name = "Yizhu Township", NameAlt1 = "义竹乡", NameAlt2 = "義竹鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D17", Name = "Zhongpu Township", NameAlt1 = "中埔乡", NameAlt2 = "中埔鄉" });
                result.Add(new CountryStateCityItem { Parent = "R03", Id = "D18", Name = "Zhuqi Township", NameAlt1 = "竹崎乡", NameAlt2 = "竹崎鄉" });
                #endregion

                #region R04 x 3 新竹市
                result.Add(new CountryStateCityItem { Parent = "R04", Id = "D01", Name = "East District", NameAlt1 = "东区", NameAlt2 = "東區" });
                result.Add(new CountryStateCityItem { Parent = "R04", Id = "D02", Name = "North District", NameAlt1 = "北区", NameAlt2 = "北區" });
                result.Add(new CountryStateCityItem { Parent = "R04", Id = "D03", Name = "Xiangshan District", NameAlt1 = "香山区", NameAlt2 = "香山區" });
                #endregion

                #region R05 x 13 新竹縣
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D01", Name = "Baoshan Township", NameAlt1 = "宝山乡", NameAlt2 = "寶山鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D02", Name = "Beipu Township", NameAlt1 = "北埔乡", NameAlt2 = "北埔鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D03", Name = "Emei Township", NameAlt1 = "峨眉乡", NameAlt2 = "峨眉鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D04", Name = "Guanxi Township", NameAlt1 = "关西镇", NameAlt2 = "關西鎮" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D05", Name = "Hengshan Township", NameAlt1 = "横山乡", NameAlt2 = "橫山鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D06", Name = "Hukou Township", NameAlt1 = "湖口乡", NameAlt2 = "湖口鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D07", Name = "Jianshi Township", NameAlt1 = "尖石乡", NameAlt2 = "尖石鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D08", Name = "Qionglin Township", NameAlt1 = "芎林乡", NameAlt2 = "芎林鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D09", Name = "Wufeng Township", NameAlt1 = "五峰乡", NameAlt2 = "五峰鄉" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D10", Name = "Xinfeng Township", NameAlt1 = "新丰乡", NameAlt2 = "新豐鄉" });

                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D11", Name = "Xinpu Township", NameAlt1 = "新埔镇", NameAlt2 = "新埔鎮" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D13", Name = "Zhubei City", NameAlt1 = "竹北市", NameAlt2 = "竹北市" });
                result.Add(new CountryStateCityItem { Parent = "R05", Id = "D14", Name = "Zhudong Township", NameAlt1 = "竹东镇", NameAlt2 = "竹東鎮" });
                #endregion

                #region R06 x 13 花蓮縣
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D01", Name = "Fengbin Township", NameAlt1 = "丰滨乡", NameAlt2 = "豐濱鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D02", Name = "Fenglin Township", NameAlt1 = "凤林镇", NameAlt2 = "鳳林鎮" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D03", Name = "Fuli Township", NameAlt1 = "富里乡", NameAlt2 = "富里鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D04", Name = "Guangfu Township", NameAlt1 = "光复乡", NameAlt2 = "光復鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D05", Name = "Hualien City", NameAlt1 = "花莲市", NameAlt2 = "花蓮市" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D06", Name = "Ji’an Township", NameAlt1 = "吉安乡", NameAlt2 = "吉安鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D07", Name = "Ruisui Township", NameAlt1 = "瑞穗乡", NameAlt2 = "瑞穗鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D08", Name = "Shoufeng Township", NameAlt1 = "寿丰乡", NameAlt2 = "壽豐鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D09", Name = "Wanrong Township", NameAlt1 = "万荣乡", NameAlt2 = "萬榮鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D10", Name = "Xincheng Township", NameAlt1 = "新城乡", NameAlt2 = "新城鄉" });

                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D11", Name = "Xiulin Township", NameAlt1 = "秀林乡", NameAlt2 = "秀林鄉" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D12", Name = "Yuli Township", NameAlt1 = "玉里镇", NameAlt2 = "玉里鎮" });
                result.Add(new CountryStateCityItem { Parent = "R06", Id = "D13", Name = "Zhuoxi Township", NameAlt1 = "卓溪乡", NameAlt2 = "卓溪鄉" });
                #endregion

                #region R07 x 11 高雄市
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D01", Name = "Gushan District", NameAlt1 = "鼓山区", NameAlt2 = "鼓山區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D02", Name = "Lingya District", NameAlt1 = "苓雅区", NameAlt2 = "苓雅區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D03", Name = "Nanzi District", NameAlt1 = "楠梓区", NameAlt2 = "楠梓區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D04", Name = "Qianjin District", NameAlt1 = "前金区", NameAlt2 = "前金區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D05", Name = "Qianzhen District", NameAlt1 = "前镇区", NameAlt2 = "前鎮區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D06", Name = "Qijin District", NameAlt1 = "旗津区", NameAlt2 = "旗津區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D07", Name = "Sanmin District", NameAlt1 = "三民区", NameAlt2 = "三民區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D08", Name = "Xiaogang District", NameAlt1 = "小港区", NameAlt2 = "小港區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D09", Name = "Xinxing District", NameAlt1 = "新兴区", NameAlt2 = "新興區" });
                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D10", Name = "Yancheng District", NameAlt1 = "盐埕区", NameAlt2 = "鹽埕區" });

                result.Add(new CountryStateCityItem { Parent = "R07", Id = "D11", Name = "Zuoying District", NameAlt1 = "左营区", NameAlt2 = "左營區" });
                #endregion

                #region R08 x 7 基隆市
                result.Add(new CountryStateCityItem { Parent = "R08", Id = "D01", Name = "Anle District", NameAlt1 = "安乐区", NameAlt2 = "安樂區" });
                result.Add(new CountryStateCityItem { Parent = "R08", Id = "D02", Name = "Nuannuan District", NameAlt1 = "暖暖区", NameAlt2 = "暖暖區" });
                result.Add(new CountryStateCityItem { Parent = "R08", Id = "D03", Name = "Qidu District", NameAlt1 = "七堵区", NameAlt2 = "七堵區" });
                result.Add(new CountryStateCityItem { Parent = "R08", Id = "D04", Name = "Ren’ai District", NameAlt1 = "仁爱区", NameAlt2 = "仁愛區" });
                result.Add(new CountryStateCityItem { Parent = "R08", Id = "D05", Name = "Xinyi District", NameAlt1 = "信义区", NameAlt2 = "信義區" });
                result.Add(new CountryStateCityItem { Parent = "R08", Id = "D06", Name = "Zhongshan District", NameAlt1 = "中山区", NameAlt2 = "中山區" });
                result.Add(new CountryStateCityItem { Parent = "R08", Id = "D07", Name = "Zhongzheng District", NameAlt1 = "中正区", NameAlt2 = "中正區" });
                #endregion

                #region R09 x 6 金門縣
                result.Add(new CountryStateCityItem { Parent = "R09", Id = "D01", Name = "Jincheng Township", NameAlt1 = "金城镇", NameAlt2 = "金城鎮" });
                result.Add(new CountryStateCityItem { Parent = "R09", Id = "D02", Name = "Jinhu Township", NameAlt1 = "金湖镇", NameAlt2 = "金湖鎮" });
                result.Add(new CountryStateCityItem { Parent = "R09", Id = "D03", Name = "Jinning Township", NameAlt1 = "金宁乡", NameAlt2 = "金寧鄉" });
                result.Add(new CountryStateCityItem { Parent = "R09", Id = "D04", Name = "Jinsha Township", NameAlt1 = "金沙镇", NameAlt2 = "金沙鎮" });
                result.Add(new CountryStateCityItem { Parent = "R09", Id = "D05", Name = "Lieyu Township", NameAlt1 = "烈屿乡", NameAlt2 = "烈嶼鄉" });
                result.Add(new CountryStateCityItem { Parent = "R09", Id = "D06", Name = "Wuqiu Township", NameAlt1 = "乌坵乡", NameAlt2 = "烏坵鄉" });
                #endregion

                #region R10 x 4 連江縣
                result.Add(new CountryStateCityItem { Parent = "R10", Id = "D01", Name = "Beigan Township", NameAlt1 = "北竿乡", NameAlt2 = "北竿鄉" });
                result.Add(new CountryStateCityItem { Parent = "R10", Id = "D02", Name = "Dongyin Township", NameAlt1 = "东引乡", NameAlt2 = "東引鄉" });
                result.Add(new CountryStateCityItem { Parent = "R10", Id = "D03", Name = "Juguang Township", NameAlt1 = "莒光乡", NameAlt2 = "莒光鄉" });
                result.Add(new CountryStateCityItem { Parent = "R10", Id = "D04", Name = "Nangan Township", NameAlt1 = "南竿乡", NameAlt2 = "南竿鄉" });
                #endregion

                #region R11 x 18 苗栗縣
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D01", Name = "Dahu Township", NameAlt1 = "大湖乡", NameAlt2 = "大湖鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D02", Name = "Gongguan Township", NameAlt1 = "公馆乡", NameAlt2 = "公館鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D03", Name = "Houlong Township", NameAlt1 = "後龙镇", NameAlt2 = "後龍鎮" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D04", Name = "Miaoli City", NameAlt1 = "苗栗市", NameAlt2 = "苗栗市" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D05", Name = "Nanzhuang Township", NameAlt1 = "南庄乡", NameAlt2 = "南庄鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D06", Name = "Sanwan Township", NameAlt1 = "三湾乡", NameAlt2 = "三灣鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D07", Name = "Sanyi Township", NameAlt1 = "三义乡", NameAlt2 = "三義鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D08", Name = "Shitan Township", NameAlt1 = "狮潭乡", NameAlt2 = "獅潭鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D09", Name = "Tai’an Township", NameAlt1 = "泰安乡", NameAlt2 = "泰安鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D10", Name = "Tongluo Township", NameAlt1 = "铜锣乡", NameAlt2 = "銅鑼鄉" });

                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D11", Name = "Tongxiao Township", NameAlt1 = "通霄镇", NameAlt2 = "通霄鎮" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D12", Name = "Toufen Township", NameAlt1 = "头份镇", NameAlt2 = "頭份鎮" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D13", Name = "Touwu Township", NameAlt1 = "头屋乡", NameAlt2 = "頭屋鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D14", Name = "Xihu Township", NameAlt1 = "西湖乡", NameAlt2 = "西湖鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D15", Name = "Yuanli Township", NameAlt1 = "苑里镇", NameAlt2 = "苑裡鎮" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D16", Name = "Zaoqiao Township", NameAlt1 = "造桥乡", NameAlt2 = "造橋鄉" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D17", Name = "Zhunan Township", NameAlt1 = "竹南镇", NameAlt2 = "竹南鎮" });
                result.Add(new CountryStateCityItem { Parent = "R11", Id = "D18", Name = "Zhuolan Township", NameAlt1 = "卓兰镇", NameAlt2 = "卓蘭鎮" });
                #endregion

                #region R12 x 13 南投縣
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D01", Name = "Caotun Township", NameAlt1 = "草屯镇", NameAlt2 = "草屯鎮" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D02", Name = "Guoxing Township", NameAlt1 = "国姓乡", NameAlt2 = "國姓鄉" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D03", Name = "Jiji Township", NameAlt1 = "集集镇", NameAlt2 = "集集鎮" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D04", Name = "Lugu Township", NameAlt1 = "鹿谷乡", NameAlt2 = "鹿谷鄉" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D05", Name = "Mingjian Township", NameAlt1 = "名间乡", NameAlt2 = "名間鄉" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D06", Name = "Nantou City", NameAlt1 = "南投市", NameAlt2 = "南投市" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D07", Name = "Puli Township", NameAlt1 = "埔里镇", NameAlt2 = "埔里鎮" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D08", Name = "Ren’ai Township", NameAlt1 = "仁爱乡", NameAlt2 = "仁愛鄉" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D09", Name = "Shuili Township", NameAlt1 = "水里乡", NameAlt2 = "水里鄉" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D10", Name = "Xinyi Township", NameAlt1 = "信义乡", NameAlt2 = "信義鄉" });

                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D11", Name = "Yuchi Township", NameAlt1 = "鱼池乡", NameAlt2 = "魚池鄉" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D12", Name = "Zhongliao Township", NameAlt1 = "中寮乡", NameAlt2 = "中寮鄉" });
                result.Add(new CountryStateCityItem { Parent = "R12", Id = "D13", Name = "Zhushan Township", NameAlt1 = "竹山镇", NameAlt2 = "竹山鎮" });
                #endregion

                #region R13 x 29 新北市
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D01", Name = "Bali District", NameAlt1 = "八里区", NameAlt2 = "八里區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D02", Name = "Banqiao District", NameAlt1 = "板桥区", NameAlt2 = "板橋區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D03", Name = "Gongliao District", NameAlt1 = "贡寮区", NameAlt2 = "貢寮區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D04", Name = "Jinshan District", NameAlt1 = "金山区", NameAlt2 = "金山區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D05", Name = "Linkou District", NameAlt1 = "林口区", NameAlt2 = "林口區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D06", Name = "Luzhou District", NameAlt1 = "芦洲区", NameAlt2 = "蘆洲區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D07", Name = "Pinglin District", NameAlt1 = "坪林区", NameAlt2 = "坪林區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D08", Name = "Pingxi District", NameAlt1 = "帄溪区", NameAlt2 = "帄溪區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D09", Name = "Ruifang District", NameAlt1 = "瑞芳区", NameAlt2 = "瑞芳區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D10", Name = "Sanchong District", NameAlt1 = "三重区", NameAlt2 = "三重區" });

                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D11", Name = "Sanxia District", NameAlt1 = "三峡区", NameAlt2 = "三峽區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D12", Name = "Sanzhi District", NameAlt1 = "三芝区", NameAlt2 = "三芝區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D13", Name = "Shenkeng District", NameAlt1 = "深坑区", NameAlt2 = "深坑區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D14", Name = "Shiding District", NameAlt1 = "石碇区", NameAlt2 = "石碇區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D15", Name = "Shimen District", NameAlt1 = "石门区", NameAlt2 = "石門區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D16", Name = "Shuangxi District", NameAlt1 = "双溪区", NameAlt2 = "雙溪區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D17", Name = "Shulin District", NameAlt1 = "树林区", NameAlt2 = "樹林區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D18", Name = "Taishan District", NameAlt1 = "泰山区", NameAlt2 = "泰山區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D19", Name = "Tamsu District", NameAlt1 = "淡水区", NameAlt2 = "淡水區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D20", Name = "Tucheng District", NameAlt1 = "土城区", NameAlt2 = "土城區" });

                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D21", Name = "Wanli District", NameAlt1 = "万里区", NameAlt2 = "萬里區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D22", Name = "Wugu District", NameAlt1 = "五股区", NameAlt2 = "五股區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D23", Name = "Wulai District", NameAlt1 = "乌来区", NameAlt2 = "烏來區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D24", Name = "Xindian District", NameAlt1 = "新店区", NameAlt2 = "新店區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D25", Name = "Xinzhuang District", NameAlt1 = "新庄区", NameAlt2 = "新莊區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D26", Name = "Xizhi District", NameAlt1 = "污止区", NameAlt2 = "污止區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D27", Name = "Yingge District", NameAlt1 = "莺歌区", NameAlt2 = "鶯歌區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D28", Name = "Yonghe District", NameAlt1 = "永和区", NameAlt2 = "永和區" });
                result.Add(new CountryStateCityItem { Parent = "R13", Id = "D29", Name = "Zhonghe District", NameAlt1 = "中和区", NameAlt2 = "中和區" });
                #endregion

                #region R14 x 6 澎湖縣
                result.Add(new CountryStateCityItem { Parent = "R14", Id = "D01", Name = "Baisha Township", NameAlt1 = "白沙乡", NameAlt2 = "白沙鄉" });
                result.Add(new CountryStateCityItem { Parent = "R14", Id = "D02", Name = "Huxi Township", NameAlt1 = "湖西乡", NameAlt2 = "湖西鄉" });
                result.Add(new CountryStateCityItem { Parent = "R14", Id = "D03", Name = "Magong City", NameAlt1 = "马公市", NameAlt2 = "馬公市" });
                result.Add(new CountryStateCityItem { Parent = "R14", Id = "D04", Name = "Qimei Township", NameAlt1 = "七美乡", NameAlt2 = "七美鄉" });
                result.Add(new CountryStateCityItem { Parent = "R14", Id = "D05", Name = "Wang’an Township", NameAlt1 = "望安乡", NameAlt2 = "望安鄉" });
                result.Add(new CountryStateCityItem { Parent = "R14", Id = "D06", Name = "Xiyu Township", NameAlt1 = "西屿乡", NameAlt2 = "西嶼鄉" });
                #endregion

                #region R15 x 33 屏東縣
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D01", Name = "Changzhi Township", NameAlt1 = "长治乡", NameAlt2 = "長治鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D02", Name = "ChaozhouTownship", NameAlt1 = "潮州镇", NameAlt2 = "潮州鎮" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D03", Name = "Checheng Township", NameAlt1 = "车城乡", NameAlt2 = "車城鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D04", Name = "Chunri Township", NameAlt1 = "春日乡", NameAlt2 = "春日鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D05", Name = "Donggang Township", NameAlt1 = "东港镇", NameAlt2 = "東港鎮" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D06", Name = "Fangliao Township", NameAlt1 = "枋寮乡", NameAlt2 = "枋寮鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D07", Name = "Fangshan Township", NameAlt1 = "枋山乡", NameAlt2 = "枋山鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D08", Name = "Gaoshu Township", NameAlt1 = "高树乡", NameAlt2 = "高樹鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D09", Name = "Hengchun Township", NameAlt1 = "恒春镇", NameAlt2 = "恆春鎮" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D10", Name = "Jiadong Township", NameAlt1 = "佳冬乡", NameAlt2 = "佳冬鄉" });

                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D11", Name = "Jiuru Township", NameAlt1 = "九如乡", NameAlt2 = "九如鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D12", Name = "Kanding Township", NameAlt1 = "崁顶乡", NameAlt2 = "崁頂鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D13", Name = "Laiyi Township", NameAlt1 = "来义乡", NameAlt2 = "來義鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D14", Name = "Ligang Township", NameAlt1 = "里港乡", NameAlt2 = "里港鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D15", Name = "Linbian Township", NameAlt1 = "林边乡", NameAlt2 = "林邊鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D16", Name = "Linluo Township", NameAlt1 = "麟洛乡", NameAlt2 = "麟洛鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D17", Name = "Liuqiu Township", NameAlt1 = "琉球乡", NameAlt2 = "琉球鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D18", Name = "Majia Township", NameAlt1 = "玛家乡", NameAlt2 = "瑪家鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D19", Name = "Manzhou Township", NameAlt1 = "满州乡", NameAlt2 = "滿州鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D20", Name = "Mudan Township", NameAlt1 = "牡丹乡", NameAlt2 = "牡丹鄉" });

                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D21", Name = "Nanzhou Township", NameAlt1 = "南州乡", NameAlt2 = "南州鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D22", Name = "Neipu Township", NameAlt1 = "内埔乡", NameAlt2 = "內埔鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D23", Name = "Pingtung City", NameAlt1 = "屏东市", NameAlt2 = "屏東市" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D24", Name = "Sandimen Township", NameAlt1 = "三地门乡", NameAlt2 = "三地門鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D25", Name = "Shizi Township", NameAlt1 = "狮子乡", NameAlt2 = "獅子鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D26", Name = "Taiwu Township", NameAlt1 = "泰武乡", NameAlt2 = "泰武鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D27", Name = "Wandan Township", NameAlt1 = "万丹乡", NameAlt2 = "萬丹鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D28", Name = "Wanluan Township", NameAlt1 = "万峦乡", NameAlt2 = "萬巒鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D29", Name = "Wutai Township", NameAlt1 = "雾台乡", NameAlt2 = "霧臺鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D30", Name = "Xinpi Township", NameAlt1 = "新埤乡", NameAlt2 = "新埤鄉" });

                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D31", Name = "Xinyuan Township", NameAlt1 = "新园乡", NameAlt2 = "新園鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D32", Name = "Yanpu Township", NameAlt1 = "盐埔乡", NameAlt2 = "鹽埔鄉" });
                result.Add(new CountryStateCityItem { Parent = "R15", Id = "D33", Name = "Zhutian Township", NameAlt1 = "竹田乡", NameAlt2 = "竹田鄉" });
                #endregion

                #region R16 x 29 臺中市
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D01", Name = "Beitun District", NameAlt1 = "北屯区", NameAlt2 = "北屯區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D02", Name = "Central District", NameAlt1 = "中区", NameAlt2 = "中區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D03", Name = "Da’an District", NameAlt1 = "大安区", NameAlt2 = "大安區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D04", Name = "Dadu District", NameAlt1 = "大肚区", NameAlt2 = "大肚區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D05", Name = "Dajia District", NameAlt1 = "大甲区", NameAlt2 = "大甲區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D06", Name = "Dali District", NameAlt1 = "大里区", NameAlt2 = "大里區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D07", Name = "Daya District", NameAlt1 = "大雅区", NameAlt2 = "大雅區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D08", Name = "Dongshi District", NameAlt1 = "东势区", NameAlt2 = "東勢區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D09", Name = "East District", NameAlt1 = "东区", NameAlt2 = "東區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D10", Name = "Fengyuan District", NameAlt1 = "丰原区", NameAlt2 = "豐原區" });

                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D11", Name = "Heping District", NameAlt1 = "和平区", NameAlt2 = "和平區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D12", Name = "Houli District", NameAlt1 = "后里区", NameAlt2 = "后里區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D13", Name = "Longjing District", NameAlt1 = "龙井区", NameAlt2 = "龍井區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D14", Name = "Nantun District", NameAlt1 = "南屯区", NameAlt2 = "南屯區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D15", Name = "North District", NameAlt1 = "北区", NameAlt2 = "北區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D16", Name = "Qingshui District", NameAlt1 = "清水区", NameAlt2 = "清水區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D17", Name = "Shalu District", NameAlt1 = "沙鹿区", NameAlt2 = "沙鹿區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D18", Name = "Shengang District", NameAlt1 = "神冈区", NameAlt2 = "神岡區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D19", Name = "Shigang District", NameAlt1 = "石冈区", NameAlt2 = "石岡區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D20", Name = "South District", NameAlt1 = "南区", NameAlt2 = "南區" });

                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D21", Name = "Taiping District", NameAlt1 = "太帄区", NameAlt2 = "太帄區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D22", Name = "Tanzi District", NameAlt1 = "潭子区", NameAlt2 = "潭子區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D23", Name = "Waipu District", NameAlt1 = "外埔区", NameAlt2 = "外埔區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D24", Name = "West District", NameAlt1 = "西区", NameAlt2 = "西區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D25", Name = "Wufeng District", NameAlt1 = "雾峰区", NameAlt2 = "霧峰區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D26", Name = "Wuqi District", NameAlt1 = "梧栖区", NameAlt2 = "梧棲區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D27", Name = "Wuri District", NameAlt1 = "乌日区", NameAlt2 = "烏日區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D28", Name = "Xinshe District", NameAlt1 = "新社区", NameAlt2 = "新社區" });
                result.Add(new CountryStateCityItem { Parent = "R16", Id = "D29", Name = "Xitun District", NameAlt1 = "西屯区", NameAlt2 = "西屯區" });
                #endregion

                #region R17 x 37 臺南市
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D01", Name = "Anding District", NameAlt1 = "安定区", NameAlt2 = "安定區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D02", Name = "Annan District", NameAlt1 = "安南区", NameAlt2 = "安南區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D03", Name = "Anping District", NameAlt1 = "安帄区", NameAlt2 = "安帄區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D04", Name = "Baihe District", NameAlt1 = "白河区", NameAlt2 = "白河區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D05", Name = "Beimen District", NameAlt1 = "北门区", NameAlt2 = "北門區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D06", Name = "Danei District", NameAlt1 = "大内区", NameAlt2 = "大內區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D07", Name = "Dongshan District", NameAlt1 = "东山区", NameAlt2 = "東山區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D08", Name = "East District", NameAlt1 = "东区", NameAlt2 = "東區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D09", Name = "Guanmiao District", NameAlt1 = "关庙区", NameAlt2 = "關廟區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D10", Name = "Guantian District", NameAlt1 = "官田区", NameAlt2 = "官田區" });

                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D11", Name = "Guiren District", NameAlt1 = "归仁区", NameAlt2 = "歸仁區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D12", Name = "Houbi Distric", NameAlt1 = "後壁区", NameAlt2 = "後壁區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D13", Name = "Jiali District", NameAlt1 = "佳里区", NameAlt2 = "佳里區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D14", Name = "Jiangjun District", NameAlt1 = "将军区", NameAlt2 = "將軍區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D15", Name = "Liujia District", NameAlt1 = "六甲区", NameAlt2 = "六甲區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D16", Name = "Liuying District", NameAlt1 = "柳营区", NameAlt2 = "柳營區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D17", Name = "Longqi District", NameAlt1 = "龙崎区", NameAlt2 = "龍崎區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D18", Name = "Madou District", NameAlt1 = "麻豆区", NameAlt2 = "麻豆區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D19", Name = "Nanhua District", NameAlt1 = "南化区", NameAlt2 = "南化區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D20", Name = "Nanxi District", NameAlt1 = "楠西区", NameAlt2 = "楠西區" });

                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D21", Name = "North District", NameAlt1 = "北区", NameAlt2 = "北區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D22", Name = "Qigu District", NameAlt1 = "七股区", NameAlt2 = "七股區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D23", Name = "Rende District", NameAlt1 = "仁德区", NameAlt2 = "仁德區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D24", Name = "Shanhua District", NameAlt1 = "善化区", NameAlt2 = "善化區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D25", Name = "Shanshang District", NameAlt1 = "山上区", NameAlt2 = "山上區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D26", Name = "South District", NameAlt1 = "南区", NameAlt2 = "南區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D27", Name = "West Central District", NameAlt1 = "中西区", NameAlt2 = "中西區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D28", Name = "Xiaying District", NameAlt1 = "下营区", NameAlt2 = "下營區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D29", Name = "Xigang District", NameAlt1 = "西港区", NameAlt2 = "西港區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D30", Name = "Xinhua District", NameAlt1 = "新化区", NameAlt2 = "新化區" });

                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D31", Name = "Xinshi District", NameAlt1 = "新市区", NameAlt2 = "新市區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D32", Name = "Xinying District", NameAlt1 = "新营区", NameAlt2 = "新營區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D33", Name = "Xuejia District", NameAlt1 = "学甲区", NameAlt2 = "學甲區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D34", Name = "Yanshui District", NameAlt1 = "盐水区", NameAlt2 = "鹽水區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D35", Name = "Yongkang District", NameAlt1 = "永康区", NameAlt2 = "永康區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D36", Name = "Yujing District", NameAlt1 = "玉井区", NameAlt2 = "玉井區" });
                result.Add(new CountryStateCityItem { Parent = "R17", Id = "D37", Name = "Zuozhen District", NameAlt1 = "左镇区", NameAlt2 = "左鎮區" });
                #endregion

                #region R18 x 12 臺北市
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D01", Name = "Beitou District", NameAlt1 = "北投区", NameAlt2 = "北投區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D02", Name = "Da’an District", NameAlt1 = "大安区", NameAlt2 = "大安區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D03", Name = "Datong District", NameAlt1 = "大同区", NameAlt2 = "大同區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D04", Name = "Nangang District", NameAlt1 = "南港区", NameAlt2 = "南港區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D05", Name = "Neihu District", NameAlt1 = "内湖区", NameAlt2 = "內湖區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D06", Name = "Shilin District", NameAlt1 = "士林区", NameAlt2 = "士林區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D07", Name = "Songshan District", NameAlt1 = "松山区", NameAlt2 = "松山區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D08", Name = "Wanhua District", NameAlt1 = "万华区", NameAlt2 = "萬華區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D09", Name = "Wenshan District", NameAlt1 = "文山区", NameAlt2 = "文山區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D10", Name = "Xinyi District", NameAlt1 = "信义区", NameAlt2 = "信義區" });

                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D11", Name = "Zhongshan District", NameAlt1 = "中山区", NameAlt2 = "中山區" });
                result.Add(new CountryStateCityItem { Parent = "R18", Id = "D12", Name = "Zhongzheng District", NameAlt1 = "中正区", NameAlt2 = "中正區" });
                #endregion

                #region R19 x 16 臺東縣
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D01", Name = "Beinan Township", NameAlt1 = "卑南乡", NameAlt2 = "卑南鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D02", Name = "Changbin Township", NameAlt1 = "长滨乡", NameAlt2 = "長濱鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D03", Name = "Chenggong Township", NameAlt1 = "成功镇", NameAlt2 = "成功鎮" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D04", Name = "Chishang Township", NameAlt1 = "池上乡", NameAlt2 = "池上鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D05", Name = "Daren Township", NameAlt1 = "达仁乡", NameAlt2 = "達仁鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D06", Name = "Dawu Township", NameAlt1 = "大武乡", NameAlt2 = "大武鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D07", Name = "Donghe Township", NameAlt1 = "东河乡", NameAlt2 = "東河鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D08", Name = "Guanshan Township", NameAlt1 = "关山镇", NameAlt2 = "關山鎮" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D09", Name = "Haiduan Township", NameAlt1 = "海端乡", NameAlt2 = "海端鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D10", Name = "Jinfeng Township", NameAlt1 = "金峰乡", NameAlt2 = "金峰鄉" });

                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D11", Name = "Lanyu Township", NameAlt1 = "兰屿乡", NameAlt2 = "蘭嶼鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D12", Name = "Lüdao Township", NameAlt1 = "绿岛乡", NameAlt2 = "綠島鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D13", Name = "Luye Township", NameAlt1 = "鹿野乡", NameAlt2 = "鹿野鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D14", Name = "Taimali Township", NameAlt1 = "太麻里乡", NameAlt2 = "太麻里鄉" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D15", Name = "Taitung City", NameAlt1 = "台东市", NameAlt2 = "臺東市" });
                result.Add(new CountryStateCityItem { Parent = "R19", Id = "D16", Name = "Yanping Township", NameAlt1 = "延帄乡", NameAlt2 = "延帄鄉" });
                #endregion

                #region R20 x 13 桃園市
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D01", Name = "Bade District", NameAlt1 = "八德区", NameAlt2 = "八德區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D02", Name = "Daxi District", NameAlt1 = "大溪区", NameAlt2 = "大溪區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D03", Name = "Dayuan District", NameAlt1 = "大园区", NameAlt2 = "大園區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D04", Name = "Fuxing District", NameAlt1 = "复兴区", NameAlt2 = "復興區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D05", Name = "Guanyin District", NameAlt1 = "观音区", NameAlt2 = "觀音區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D06", Name = "Guishan District", NameAlt1 = "龟山区", NameAlt2 = "龜山區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D07", Name = "Longtan District", NameAlt1 = "龙潭区", NameAlt2 = "龍潭區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D08", Name = "Luzhu District", NameAlt1 = "芦竹区", NameAlt2 = "蘆竹區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D09", Name = "Pingzhen District", NameAlt1 = "帄镇区", NameAlt2 = "帄鎮區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D10", Name = "Taoyuan District", NameAlt1 = "桃园区", NameAlt2 = "桃園區" });

                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D11", Name = "Xinwu District", NameAlt1 = "新屋区", NameAlt2 = "新屋區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D12", Name = "Yangmei District", NameAlt1 = "杨梅区", NameAlt2 = "楊梅區" });
                result.Add(new CountryStateCityItem { Parent = "R20", Id = "D13", Name = "Zhongli District", NameAlt1 = "中坜区", NameAlt2 = "中壢區" });
                #endregion

                #region R21 x 12 宜蘭縣
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D01", Name = "Datong Township", NameAlt1 = "大同乡", NameAlt2 = "大同鄉" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D02", Name = "Dongshan Township", NameAlt1 = "冬山乡", NameAlt2 = "冬山鄉" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D03", Name = "Jiaoxi Township", NameAlt1 = "礁溪乡", NameAlt2 = "礁溪鄉" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D04", Name = "Luodong Township", NameAlt1 = "罗东镇", NameAlt2 = "羅東鎮" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D05", Name = "Nan’ao Township", NameAlt1 = "南澳乡", NameAlt2 = "南澳鄉" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D06", Name = "Sanxing Township", NameAlt1 = "三星乡", NameAlt2 = "三星鄉" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D07", Name = "Su’ao Township", NameAlt1 = "苏澳镇", NameAlt2 = "蘇澳鎮" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D08", Name = "Toucheng Township", NameAlt1 = "头城镇", NameAlt2 = "頭城鎮" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D09", Name = "Wujie Township", NameAlt1 = "五结乡", NameAlt2 = "五結鄉" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D10", Name = "Yilan City", NameAlt1 = "宜兰市", NameAlt2 = "宜蘭市" });

                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D11", Name = "Yuanshan Township", NameAlt1 = "员山乡", NameAlt2 = "員山鄉" });
                result.Add(new CountryStateCityItem { Parent = "R21", Id = "D12", Name = "Zhuangwei Township", NameAlt1 = "壮围乡", NameAlt2 = "壯圍鄉" });
                #endregion

                #region R22 x 20 雲林縣
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D01", Name = "Baozhong Township", NameAlt1 = "褒忠乡", NameAlt2 = "褒忠鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D02", Name = "Beigang Township", NameAlt1 = "北港镇", NameAlt2 = "北港鎮" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D03", Name = "Citong Township", NameAlt1 = "莿桐乡", NameAlt2 = "莿桐鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D04", Name = "Dapi Township", NameAlt1 = "大埤乡", NameAlt2 = "大埤鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D05", Name = "Dongshi Township", NameAlt1 = "东势乡", NameAlt2 = "東勢鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D06", Name = "Douliu City", NameAlt1 = "斗六市", NameAlt2 = "斗六市" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D07", Name = "Dounan Township", NameAlt1 = "斗南镇", NameAlt2 = "斗南鎮" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D08", Name = "Erlun Township", NameAlt1 = "二仑乡", NameAlt2 = "二崙鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D09", Name = "Gukeng Township", NameAlt1 = "古坑乡", NameAlt2 = "古坑鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D10", Name = "Huwei Township", NameAlt1 = "虎尾镇", NameAlt2 = "虎尾鎮" });

                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D11", Name = "Kouhu Township", NameAlt1 = "口湖乡", NameAlt2 = "口湖鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D12", Name = "Linnei Township", NameAlt1 = "林内乡", NameAlt2 = "林內鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D13", Name = "Lunbei Township", NameAlt1 = "仑背乡", NameAlt2 = "崙背鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D14", Name = "Mailiao Township ", NameAlt1 = "麦寮乡", NameAlt2 = "麥寮鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D15", Name = "Shuilin Township", NameAlt1 = "水林乡", NameAlt2 = "水林鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D16", Name = "Sihu Township", NameAlt1 = "四湖乡", NameAlt2 = "四湖鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D17", Name = "Taixi Township", NameAlt1 = "台西乡", NameAlt2 = "臺西鄉" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D18", Name = "Tuku Township", NameAlt1 = "土库镇", NameAlt2 = "土庫鎮" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D19", Name = "Xiluo Township", NameAlt1 = "西螺镇", NameAlt2 = "西螺鎮" });
                result.Add(new CountryStateCityItem { Parent = "R22", Id = "D20", Name = "Yuanchang Township", NameAlt1 = "元长乡", NameAlt2 = "元長鄉" });
                #endregion

                return result;
            }
        }
    }
}