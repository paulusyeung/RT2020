---
title: Tools & Packages
icon: user-ninja
order: 3
---

- [EntityFrameworkCore.Jet](https://github.com/bubibubi/EntityFrameworkCore.Jet)
  
  用嚟讀 AccDb database (亦可以用 System.Data.OleDb : [Read Microsoft Access Database in C#](https://www.c-sharpcorner.com/article/read-microsoft-access-database-in-C-Sharp/))，不過由於佢官方版本淨係去到 3.1.1，為咗要配合 [Scaffold-DbContext](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx) 所以我要首先 create 隻 project as Core 3.x，run 完 Scaffold-DbContext，gen 哂啲檔案，然後先再將個 project 升級去 Core 6.x，而且改為 [Unofficial EF Core 6 support](https://github.com/bubibubi/EntityFrameworkCore.Jet/issues/111)，有啲忙忙碌碌嘅感覺。
  
  過程間為咗減少打錯 command line syntax 我借用呢隻傢伙：[ScaffoldDbContextHelper](https://github.com/karenpayneoregon/ScaffoldDbContextHelper) ([介紹文章](https://social.technet.microsoft.com/wiki/contents/articles/53258.windows-forms-entity-framework-core-reverse-engineering-databases.aspx?fbclid=IwAR3AJK-vxEfKLnA-9-jinLHw9MKWAggM-zqW5vobhH1za_703bGyy2sBNEU))。
  
  如果後期要改動個 database 設計，就要重做一次，非常唔化算，結論係，盡量唔好用 AccDb，又或者淨係用嚟做 migration。
  
- [Scaffold-DbContext](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx)
  
  用嚟 gen 啲 models
  
- [dotnet-aspnet-codegenerator](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator)
  
  用嚟 gen 啲 controllers，有兩篇 articles 值得參考：
  
  - [Building REST APIs with .NET 5, ASP.NET Core, and PostgreSQL | End Point Dev](https://www.endpointdev.com/blog/2021/07/dotnet-5-web-api/#table-of-contents)
    
  - [如何使用 .NET CLI 快速產生 ASP․NET Core 的 Controllers 與 Views 程式碼](https://blog.miniasp.com/post/2020/09/09/Create-Controller-and-Views-with-dotnet-aspnet-codegenerator)
    
- [Access To PostgreSQL](https://www.bullzip.com/products/a2p/info.php)
  
  用嚟將 AccDb (mdb) convert 做 PostgreSQL，我順手試埋佢哋隻 [Access To MySQL](https://www.bullzip.com/products/a2m/info.php)，兩隻都 OK。要留意嘅係佢會搞 Tables 同 Queries (Views) 不過就唔處理 ForeignKeys，唔理 ForeignKeys 對我嚟講係最好不過，因為隻 AccDb 有啲 table relationships 我覺得有問題！
  
- [DbSchema](https://dbschema.com/)
  
  用嚟 design 個 database，佢有個 Community Edition 係免費嘅。
  
- [Hot Chocolate](https://chillicream.com/docs/hotchocolate)
  
  用嚟搞 GraphQL API
  
- [Hangfire](https://www.hangfire.io/)
  
  Background jobs