using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RT2020.ModelEx
{
    /// <summary>
    /// 應該係配合 Current User Id 同 Form Id (Page Id) 嚟記住 user 習慣
    /// 暫時冇用
    /// </summary>
    public class StaffPreferenceEx
    {
        public static bool HasPreference(Guid staffId, Guid pageId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sp = ctx.StaffPreference.Where(x => x.StaffId == staffId && x.PageId == pageId).AsNoTracking().FirstOrDefault();
                if (sp != null)
                {
                    if (sp.MetadataXml != string.Empty) result = true;
                }
            }

            return result;
        }

        public static bool Save(Guid staffId, Guid pageId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sp = ctx.StaffPreference.Where(x => x.StaffId == staffId && x.PageId == pageId).FirstOrDefault();
                if (sp == null)
                {
                    sp = new EF6.StaffPreference();
                    sp.PreferenceId = Guid.NewGuid();
                    sp.StaffId = staffId;
                    sp.PageId = pageId;

                    ctx.StaffPreference.Add(sp);
                }
                ctx.SaveChanges();
            }

            return result;
        }

        public static List<KeyValuePair<string, string>> GetPreference(Guid preferenceId)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();


            return result;
        }

        public static bool SetMetadata(Guid preferenceId, string group,  string key, string value)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sp = ctx.StaffPreference.Find(preferenceId);
                if (sp != null)
                {
                    try
                    {
                        if (sp.MetadataXml == string.Empty)
                        {
                            XDocument newXml = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                new XComment("RT2020 User Preference"),
                                new XElement(group));
                            sp.MetadataXml = newXml.ToString();
                            ctx.StaffPreference.Add(sp);
                        }
                        XDocument xmlData = XDocument.Parse(sp.MetadataXml);

                        var target = xmlData.Descendants(group).FirstOrDefault();
                        if (target == null)
                        {
                            target = new XElement(group);
                            target.SetAttributeValue(key, value);
                            xmlData.Element(group).Add(target);
                        }

                        sp.MetadataXml = xmlData.ToString();

                        ctx.SaveChanges();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return result;
        }

        public static bool SetMetadata(Guid preferenceId, string group,  List<KeyValuePair<string, string>> items)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sp = ctx.StaffPreference.Find(preferenceId);
                if (sp != null)
                {
                    try
                    {
                        if (sp.MetadataXml == string.Empty)
                        {
                            XDocument newXml = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                new XComment("RT2020 User Proference"),
                                new XElement(group));
                            sp.MetadataXml = newXml.ToString();
                            ctx.StaffPreference.Add(sp);
                        }
                        XDocument xmlData = XDocument.Parse(sp.MetadataXml);

                        var target = xmlData.Descendants(group).FirstOrDefault();
                        if (target == null)
                        {
                            target = new XElement(group);
                            xmlData.Element(group).Add(target);
                        }
                        foreach (var item in items)
                        {
                            target.SetAttributeValue(item.Key, item.Value);
                        }

                        sp.MetadataXml = xmlData.ToString();

                        ctx.SaveChanges();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return result;
        }
    }
}