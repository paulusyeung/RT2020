---
title: 簡介
icon: user-ninja
order: 1
---


當初係叫 SynergyV，用 Visual Basic 5 寫嘅 Windows App，今次嘅目標係將佢升級為 Web App，從此叫 xOpti，用發 IDE 用 Visual Studio 2022，.NET 7，C#，希望最終全 Linux，唔使靠 IIS，不過目前由於未搵倒合適嘅 Linux Reporting Tools，依然要靠 Windows Server + IIS Web Server，即係要俾 licenses。

Hardware 終極目標係用一部 Mini PC 跑 [Proxmox](https://www.proxmox.com/en/) 然後喺 Proxmox 之上搞幾隻 VMs 執行哂所有要用嘅 functions：

```text
+--------+ +--------+ +--------+ +--------+ +--------+
| Proxy  | |  RDP   | |  Web   | |  SQL   | |  File  |
| Server | | Server | | Server | | Server | | Server |
+--------+-+--------+-+--------+-+--------+-+--------+
|               Proxmox Virtual Server               |
+----------------------------------------------------+
```

- Proxy Server
  
  其實係用 [nginx](https://nginx.com/) 搞嘅 Reverse Proxy Server，通常嚟講入屋嘅 internet 淨係得一個 IP，當使用單一 domain name 嘅時候，透過 Reverse Proxy Server 可以將唔同嘅 sub-domain 指去唔同嘅內聯網 IP。
  
- RDP Server
  
  我用 [Guacamole](https://guacamole.apache.org/) 直接由外聯網 access 啲內聯網嘅 workstations 或 servers，例如利用一隻 VM 安裝一隻 Windows 11 (Ubuntu Desktop 也可)，日後要做 support 嘅時候就可以用 browser 經 Guacamole login 呢隻 Windows 11 做嘢，一切會方便好多。
  
- Web Server
  
  比較多用途，例如可以 host：xOpti.WebApp、xOpti.Api、xOpti.Restful、xOpti.Graphql、xOpti.Bot、xOpti.Reports、xOpti.Hangfire、xOpti.Migrate 等等 utilities/ applications。
  
- SQL Server [🔗](glossary/data-backup)
  
  我會用 [PostgreSQL](https://www.postgresql.org/) 目前係 v16，用 [DBeaver](https://dbeaver.io/) Com88munity Edition 做日常管理。
  
- File Server
  
  用 [NextCloud](https://nextcloud.com/) community edition，主要係放啲 image files，進一步就係利用佢同 [OnlyOffice](https://www.onlyoffice.com/) 嘅 integration，加上 frontend 有現成嘅 [Vue OnlyOffice Component](https://api.onlyoffice.com/editors/vue)，直接整合成 document management server，處理辦公室文件自動化。

## Options

- WiFi Hotspot<br />幫隻 Proxmox 加 hostspot，有咗佢，可以淨係准許經指定嘅 WiFi 使用 xOpti，咁樣做嘅好處除咗係可以增強保安之外，當如果你冇自己嘅 domain，又或者你唔識點樣 edit 啲 DNS records，就可以發揮作用。

  - [Hostapd](https://wiki.gentoo.org/wiki/Hostapd)

  - [RaspAP](https://docs.raspap.com/)

- Backup Server<br />要利用 Proxmox 嘅 [Proxmox Backup Server](https://www.proxmox.com/en/proxmox-backup-server) 整，安全起見，一定要係 external，或者係 cloud 備份服務都得，遲啲再諗。

- Secure Network<br />如果你部 Proxmox Server 有兩個 Network 口，可以加隻 [pfsense](https://www.pfsense.org/) 做 router，將所有 server 藏哂喺另一個 subnet，physical 分開 xOpti LAN 同其他 LANs，xOpti LAN 可以 access 其他 LANs，而其他 LANs 就唔可以 access xOpti LAN，做起嚟簡單易明，更加安全。