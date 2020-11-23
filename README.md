### RT2020

##### 前世今生
RT2000 > RT2008 > RT2020

**RT2000**，又叫 Retail 2000，係 Synergy 用 VisualBasic + Access MDB 開發嘅，後期升級為 VisualBasic + MS SQL。至於佢嘅第 0 號（少年 RT2000）係用 [DataFlex](https://en.wikipedia.org/wiki/DataFlex) 開發嘅，我唔記得當時有冇俾過個 product 名佢？ 既然 DataFlex 係咩都冇人知，大家當佢一出就叫 RT2000 啦，唔使理少年 RT2000！

**RT2008** 係全面升級為 Visual WebGUI Framework + C# + MS SQL，即係 Web App + Windows App。

**RT2020** 就再變身為 Open Source，目標係：developed on C#，run on Linux。目前已經可以 run on Linux，不過就要首先解決 reporting 同 OLAP 先算全面 run on Linux。

![RT2020 Logo](https://github.com/paulusyeung/RT2020/blob/master/RT2020/Resources/Images/logo.png?raw=true)

#### Development Environment
1. .Net Framework 4.5.2
2. Visual Studio 2015
3. C#
4. Visual WebGUI 10.0.5b
5. DevExpress 15.2（ 用咗佢嘅 Reporting﹑PivotGrid，如果要再開發就要自己買 license，我希望最終可以取代佢 ）

#### 3rd Party Libraries (一次過寫唔哂，慢慢補充)
1. nxStudio Custom Controls
2. log4net
3. ClosedXML
4. FileHelpers


#### Locale Info

Refer: [CultureInfo.Name Property](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.name?view=netframework-4.8)
> The culture name in the format languagecode2-country/regioncode2, if the current CultureInfo is culture-dependent; or an empty string, if it's an invariant culture. languagecode2 is a lowercase two-letter code derived from ISO 639-1. country/regioncode2 is derived from ISO 3166 and usually consists of two uppercase letters, or a BCP-47 language tag.

languagecode2-country = [ISO 639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes)

regioncode2 = [BCP-47 language tag](https://tools.ietf.org/html/bcp47) region = [ISO 3166-1 Alpha2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)

##### 喺 RT2020：

1. Default （我喺 Westwind 用 invariant 代替）= en (English)
2. Alt-1 = zh-CN 簡體：中文（中国）NativeName
3. Alt-2 = zh-HK 繁體：中文（香港特別行政區）NativeName

##### Notes

1. RT2020 Settings > System > Translation 內 General.logon 有幾多種 locale，Theme Language Switcher 就可以有幾多種選擇。

2. RT2020 大部分 records 都支持 3 種文字 (D+2：default + alt1 + alt2)，default 係英文，你可以隨意選用 alt1/ alt2（D+0 or D+1 or D+2），development 係用 alt1 = 繁體中文（香港），alt2 = 簡體中文
```
dbo.Staff.Name
dbo.Staff.NameAlt1
dbo.Staff.NameAlt2
```

3. Translation 係用 [Westwind.Globalization](https://github.com/RickStrahl/Westwind.Globalization)




