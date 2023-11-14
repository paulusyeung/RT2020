---
title: Documentation
icon: user-ninja
order: 9
---


用 [VuePress 2 代](https://v2.vuepress.vuejs.org/) 配 [VuePress Theme Hope 2 代](https://vuepress-theme-hope.github.io/v2/) 嚟寫，分為：

* 開發手冊 (Developer Guide)

* 用戶手冊 (User Guide)

So far 我碰到嘅麻煩係 ```Hope``` 自帶嘅 [plugins](https://github.com/vuepress-theme-hope) 支持好少 [languages](https://vuepress-theme-hope.github.io/v2/config/i18n.html#supported-languages)，連 zh-HK 唔冇，要搵 zh-TW 代替先可以喺選擇語言嘅 drop down list 中出倒 ```繁體中文``` 幾隻字，如果真係要埋 HK 嘅 ```日月年 dd-mm-yyyy``` 之類嘅 locale，咁就要寫 customization，據佢講就要首先改好咗啲 code 然後提交你嘅 PR 俾佢哋幫你 merge，都係 Open Source projects 嘅正常手續，不過我就暫時唔想搞。

另外，```Hope``` 安裝有自己嘅要求：

```
pnpm create vuepress-theme-hope [dir]
```

個 [dir] 要係```吉```嘅，而我成個 xOpti 想用 VS 2022 開一個 solution 裝哂所有 projects，打算叫 xOpti.Manual 開一個 Standalone Vue project 嚟搞，有咗隻 xOpti.Manual 之後就唔會係```空```嘅，所以要喺另外一個 directory create 隻 VuePress-Theme-Hope，然後 copy 去 xOpti.Manual 之內，有啲轉接，不過，搞得成就 OK 啦。