using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RT2020.Common.ModelEx
{
    public class MemberVipDataEx
    {
        /** XML format: group = Address, parent = Phone, key = element (Pager) + attribute (Id), value = element value
        <?xml version="1.0" encoding="utf-8"?>
        <Root>
            <Address>
                <Phone>
                    <Pager Id="a87340ce8d624bd39ec00cf9f04fd735">1234-56789</Pager>                </Phone>
            </Address>
        </Root>
        */
        private static string _BaseXml =
@"
<?xml version=""1.0"" encoding=""utf-8""?>  
<!-- dbo.MemberVipData.MetadataXml -->  
<Root>  
    <{0}>
        <{1}>
            <{2} Id=""{3}"">{4}</>  
        </{1}>
    </{0}>  
</Root>"
;
        /// <summary>
        /// 將個 MetadataXml 存檔
        /// </summary>
        /// <param name="source"></param>
        /// <param name="group"></param>
        /// <param name="parent"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SetAttribute(string source, string group, string parent, string child, string id, string value)
        {
            string result = source == string.Empty ?
                string.Format(_BaseXml, group, parent, child, id, value) :
                source;

            var xDoc = XDocument.Parse(result);
            var element = xDoc
                .Descendants(child)
                .Where(x => x.Attribute("Id") != null & x.Attribute("Id").Value == id)
                .FirstOrDefault();
            if (element != null)
            {
                element.Value = value;
            }
            else
            {
                element = new XElement(group,
                    new XElement(parent,
                        new XElement(child, new XAttribute("Id", id), value)));
                xDoc.Root.Add(element);
            }
            result = xDoc.ToString();

            return result;
        }

        /// <summary>
        /// 搵個 MetadataXml value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="group"></param>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetAttribute(string source, string group, string parent, string child, string id)
        {
            string result = "";

            try
            {
                var xDoc = XDocument.Parse(source);
                var element = xDoc
                    .Descendants(child)
                    .Where(x => x.Attribute("Id").Value == id)
                    .FirstOrDefault();
                if (element != null)
                {
                    result = element.Value;
                }
            }
            catch { }

            return result;
        }

        /// <summary>
        /// 用 Vip Number 搵 MetadataXml 嘅 element (key)，attribute Id (id) 的 element value
        /// </summary>
        /// <param name="vipNumber"></param>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetAttribute(string vipNumber, string key, string id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var vip = ctx.MemberVipData.Where(x => x.VipNumber == vipNumber).FirstOrDefault();
                    if (vip != null)
                    {
                        var xDoc = XDocument.Parse(vip.MetadataXml);
                        var element = xDoc
                            .Descendants(key)
                            .Where(x => x.Attribute("Id").Value == id)
                            .FirstOrDefault();
                        if (element != null)
                        {
                            result = element.Value;
                        }
                    }
                }
                catch { }
            }

            return result;
        }

        /// <summary>
        /// 用 Member Vip Number 搵 MetadataXml 嘅 element (key)，attribute Id (id) 的 element value
        /// </summary>
        /// <param name="memberVipId"></param>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetAttribute(Guid memberVipId, string key, string id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var vip = ctx.MemberVipData.Where(x => x.MemberVipId == memberVipId).FirstOrDefault();
                    if (vip != null)
                    {
                        var xDoc = XDocument.Parse(vip.MetadataXml);
                        var element = xDoc
                            .Descendants(key)
                            .Where(x => x.Attribute("Id").Value == id)
                            .FirstOrDefault();
                        if (element != null)
                        {
                            result = element.Value;
                        }
                    }
                }
                catch { }
            }

            return result;
        }
    }
}