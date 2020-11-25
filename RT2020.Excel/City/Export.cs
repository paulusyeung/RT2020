using ClosedXML.Excel;
using ClosedXML.Report;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT2020.Excel.City
{
    public class Export
    {
        public static Stream CityList()
        {
            var result = new MemoryStream();

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.City
                    .OrderBy(x => x.Province.Country.CountryName)
                    .ThenBy(x => x.Province.ProvinceName)
                    .ThenBy(x => x.CityName)
                    .AsNoTracking()
                    .ToList();

                using (var template = new XLTemplate(@".\Templates\template.xlsx"))
                {
                    template.AddVariable("City", list);
                    template.Generate();
                    template.SaveAs(result);
                }
            }

            return result;
        }

        public static Stream CityList(Guid provinceId)
        {
            var result = new MemoryStream();

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.City
                    .Where(x => x.ProvinceId == provinceId)
                    .OrderBy(x => x.Province.ProvinceName)
                    .ThenBy(x => x.CityName)
                    .AsNoTracking()
                    .ToList();

                using (var template = new XLTemplate(@".\Templates\template.xlsx"))
                {
                    template.AddVariable("City", list);
                    template.Generate();
                    template.SaveAs(result);
                }
            }

            return result;
        }
    }
}
