### Localization
要取消自制嘅 nxstudio.dll，原本想用 [i18n](https://github.com/turquoiseowl/i18n)，唔用 Microsoft 嘅 Resources Files，不過我搞佢唔掂，離離去去都淨係出到 en (default locale)，其實作者都喺其中 1 條 [issues](https://github.com/turquoiseowl/i18n/issues/378#issuecomment-430245684) 中有提及，我大意冇睇到，而且，英文都得，其他文就照計都應該可以㗎？點知就係唔掂。

改用 [Westwind](https://github.com/RickStrahl/Westwind.Globalization) + Resources Files + SQL，唔算係用 Resources File，因為我用咗 SQL 嚟裝啲 data，唔使一粒鐘就用得，仲可以附帶 online editor 添。

Reporting 由 Microsoft Reporting/ DevExpress XtraReport 改用開源 [FastReport](https://www.fast-report.com/en/)

OLAP 由 DevExpress XtraPivotGrid 改用開源 [WebPivotTable](https://webpivottable.com/) + [ClosedXML.Report](https://closedxml.github.io/ClosedXML.Report/docs/en/)