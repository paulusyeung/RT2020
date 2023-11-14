---
title: Intro
icon: user-ninja
order: 1
---


當初係叫 SynergyV，用 Visual Basic 5 寫嘅 Windows App，從此叫 xOpti，用 Visual Studio 2022 C# 重寫為 Web App，希望可以用哂 .Net Core ，將來全 Linux 唔使靠 IIS，全免 Windows server licenses。終極目標係用 [Proxmox](https://www.proxmox.com/en/) 搞幾隻 VMs 執行哂所有要用嘅 functions：

```textile
+--------+ +--------+ +--------+ +--------+ +--------+
| Proxy  | |  RDP   | |  Web   | |  SQL   | |  File  |
| Server | | Server | | Server | | Server | | Server |
+--------+-+--------+-+--------+-+--------+-+--------+
|               Proxmox Virtual Server               |
+----------------------------------------------------+
```

- Proxy Server
  
  其實係用 [nginx](https://nginx.com/) 搞嘅 Reverse Proxy Server，當使用單一 domain name 嘅時候，可以將唔同嘅 sub-domain 指去唔同嘅 IP。
  
- RDP Server
  
  我用 [Guacamole](https://guacamole.apache.org/) 直接由外聯網 access 啲內聯網嘅 workstations 或 servers。
  
- Web Server
  
  比較多用途，例如：xOpti.WebApp﹑xOpti.Api﹑xOpti.Restful﹑xOpti.Graphql﹑xOpti.Bot﹑xOpti.Reports﹑xOpti.Hangfire 等等 utilities/ applications。
  
- SQL Server
  
  我會用 [PostgreSQL](https://www.postgresql.org/) v15。
  
- File Server
  
  用 [NextCloud](https://nextcloud.com/) community edition，主要係放啲 image files，進一步就係利用佢同 [OnlyOffice](https://www.onlyoffice.com/) 嘅 integration，加上 frontend 有現成嘅 [Vue OnlyOffice Component](https://api.onlyoffice.com/editors/vue)，直接整合成 document management service，處理辦公室文件自動化。