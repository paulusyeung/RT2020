---
title: Database
icon: user-ninja
order: 2
---

原本嘅數據庫係用 MS Access MDB，依家有兩種選擇：

- 照舊用 MS Access MDB
  
  好處係之前嘅 Visual Basic 寫嘅 program 可以照用，慢慢升級。如果你冇 MS Access，可以試下用呢隻傢伙：[MDB Admin](https://sourceforge.net/projects/mdbadmin/)，Open Source，仲識得 ```Dump a entire MSAccess database into a SQL file. 可選：MSAccess, MSSQL, Oracle, MySQL, PostgreSQL or SQLite```。
  
- PostgreSQL
  
  開源，基本上係免費嘅，功能就 more than enough，又唔會爆 2GB Size Limit，唔好嘅係要寫 data migration 俾啲舊客。寫 migration 就難免要用到 ```Bulk Copy``` 技術，網上好多，喺呢度放兩個作參考：
  
  - [Bulk insert / copy iEnumerable into table with npgsql - Stack Overflow](https://stackoverflow.com/questions/65687071/bulk-insert-copy-ienumerable-into-table-with-npgsql)
    
  - [PostgreSQLCopyHelper: Simple Wrapper around Npgsql for using PostgreSQL COPY functions.](https://github.com/PostgreSQLCopyHelper/PostgreSQLCopyHelper)
    
  
  Management Console 可以用 [DBeaver](https://dbeaver.io/download/)，免費嘅。另外，[DbGate](https://dbgate.org/) 都唔錯。
  

我要一步到位，一開始就用 PostgreSQL。