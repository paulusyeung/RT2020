### RT2020

##### 前世今生
RT2000 > RT2008 > RT2020

**RT2000**，又叫 Retail 2000，係 Synergy 用 VisualBasic + Access MDB 開發嘅，後期升級為 VisualBasic + MS SQL。至於佢嘅第 0 號（少年 RT2000）係用 [DataFlex](https://en.wikipedia.org/wiki/DataFlex) 開發嘅，我唔記得當時有冇俾過個 product 名佢？ 既然 DataFlex 係咩都冇人知，大家當佢一出就叫 RT2000 啦，唔使理少年 RT2000！

**RT2008** 係全面升級為 Visual WebGUI Framework + C# + MS SQL，即係 Web App + Windows App。

**RT2020** 就再變身為 Open Source，目標係：developed on C#，run on Linux。目前已經可以 run on Linux，不過就要首先解決 reporting 同 OLAP 先算全面 run on Linux。

![RT2020 Logo](/RT2020/Resources/images/logo.png)

##### Development Environment
1. .Net Framework 4.5.2
2. Visual Studio 2015
3. C#
4. Visual WebGUI 10.0.5b
5. DevExpress 15.2（ 用咗佢嘅 Reporting﹑PivotGrid，如果要再開發就要自己買 license，我希望最終可以取代佢 ）

##### 3rd Party Libraries (一次過寫唔哂，慢慢補充)
1. nxStudio Custom Controls
2. log4net
3. ClosedXML
4. FileHelpers
5. 