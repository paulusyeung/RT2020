---
title: Database
icon: user-ninja
order: 2
---

原本嘅數據庫係用 MS Access MDB，依家有兩種選擇：

1. 照舊用 MS Access MDB
  
  好處係之前嘅 Visual Basic 寫嘅 program 可以照用，慢慢升級。如果你冇 MS Access，可以試下用呢隻傢伙：[MDB Admin](https://sourceforge.net/projects/mdbadmin/)，Open Source，仲識得 ```Dump a entire MSAccess database into a SQL file. 可選：MSAccess, MSSQL, Oracle, MySQL, PostgreSQL or SQLite```。
  
2. 直接改用 [PostgreSQL](https://www.postgresql.org/)
  
  開源，基本上係免費嘅，功能就足夠有餘，又唔會好似 MDB 咁有 2GB Size Limit，壞處係 server 比較高難度，而且又要寫 data migration 俾啲舊客。如果要寫 migration 就難免要用到 ```Bulk Copy``` 技術，網上好多，喺呢度介紹兩個作參考：
  
  - [Npgsql](https://www.npgsql.org/index.html)：開源嘅 ADO.NET Data Provider for PostgreSQL
  
  - [PostgreSQLCopyHelper](https://github.com/PostgreSQLCopyHelper/PostgreSQLCopyHelper)：Simple Wrapper around Npgsql for using PostgreSQL COPY functions.

  - [Bulk insert / copy iEnumerable into table with npgsql - Stack Overflow](https://stackoverflow.com/questions/65687071/bulk-insert-copy-ienumerable-into-table-with-npgsql)

  - [DBeaver](https://dbeaver.io/download/)：Database management console，免費嘅。另外，[DbGate](https://dbgate.org/) 都唔錯。
  
