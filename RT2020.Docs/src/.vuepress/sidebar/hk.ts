import { sidebar } from "vuepress-theme-hope";

export const hkSidebar = sidebar({
  "/hk/": [
    "",
    {
      text: "教學短片",
      icon: "video",
      prefix: "tutorial/",
      link: "tutorial/",
      children: "structure",
    },
    {
      text: "文檔",
      icon: "circle-info",
      prefix: "docs/",
      link: "docs/",
      children: "structure",
      // children: [
      //   {
      //     text: '開發手冊',
      //     link: 'developer/',
      //     collapsible: true,
      //     children: [
      //       {
      //         text: 'Intro',
      //         link: 'developer/intro',
      //       },
      //       {
      //         text: 'Database',
      //         link: 'developer/database',
      //       },
      //       {
      //         text: 'Tools & Packages',
      //         link: 'developer/tools-packages',
      //       },
      //       {
      //         text: 'Reporting',
      //         link: 'developer/reporting',
      //       },
      //       {
      //         text: 'API',
      //         link: 'developer/api',
      //       },
      //       {
      //         text: 'Vue-Pure-Admin',
      //         link: 'developer/vue-pure-admin',
      //       },
      //       {
      //         text: 'Inventory & Sales Forecasting',
      //         link: 'developer/inventory-sales-forecasting',
      //       },
      //       {
      //         text: 'Digital Marketing',
      //         link: 'developer/digital-marketing',
      //       },
      //       {
      //         text: 'Documentation',
      //         link: 'developer/documentation',
      //       },
      //     ],
      //   },
      //   {
      //     text: '用戶手冊',
      //     link: 'user/',
      //     collapsible: true,
      //     children: [
      //       {
      //         text: 'Intro',
      //         link: 'user/intro',
      //         // children: [
                
      //         // ],
      //       },
      //     ],
      //   },
      // ],
    },
    //"slides",
  ],
});
