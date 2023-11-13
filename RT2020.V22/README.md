### RT2020.V22 重大 migration bug fix

  - Web.config + log4net.config

    唔可以用 `linked files`，用咗會 run 唔倒。

  - Temporary ASP.NET Files

    Debug run 會一開始就死，報錯話搵唔倒啲 reference library files，要手動抄哂 bin 啲檔案入去先 run 倒。

  - Resources

    仲要手動抄哂啲 Resouces 下面啲檔案入去先 run 倒。

### RT2020.V22 觀察

Compile 完全冇問題，可以正常 debug，啲 WebGUI forms 都 run 得好正常。

### Localization
要取消自制嘅 nxstudio.dll，原本想用 [i18n](https://github.com/turquoiseowl/i18n)，唔用 Microsoft 嘅 Resources Files，不過我搞佢唔掂，離離去去都淨係出到 en (default locale)，其實作者都喺其中 1 條 [issues](https://github.com/turquoiseowl/i18n/issues/378#issuecomment-430245684) 中有提及，我大意冇睇到，而且，英文都得，其他文就照計都應該可以㗎？點知就係唔掂。

改用 [Westwind](https://github.com/RickStrahl/Westwind.Globalization) + Resources Files + SQL，唔算係用 Resources File，因為我用咗 SQL 嚟裝啲 data，唔使一粒鐘就用得，仲可以附帶 online editor 添。

Reporting 由 Microsoft Reporting/ DevExpress XtraReport 改用開源 [FastReport](https://www.fast-report.com/en/)

OLAP 由 DevExpress XtraPivotGrid 改用開源 [WebPivotTable](https://webpivottable.com/) + [ClosedXML.Report](https://closedxml.github.io/ClosedXML.Report/docs/en/)