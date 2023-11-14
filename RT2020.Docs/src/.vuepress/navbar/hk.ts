import { navbar } from "vuepress-theme-hope";

export const hkNavbar = navbar([
  "/hk/",
  { text: "教學短片", icon: "video", link: "/hk/tutorial/" },
  {
    text: "文檔",
    icon: "circle-info",
    prefix: "/hk/docs/",
    children: [
      {
        text: "開發手冊",
        icon: "user-ninja",
        prefix: "developer/",
        children: [
          "intro", 
          "database",
          "tools-packages",
          "reporting",
          "api",
          "vue-pure-admin",
          "inventory-sales-forecasting",
          "digital-marketing",
          "documentation",
          { text: "...", icon: "ellipsis", link: "" }
        ],
      },
      {
        text: "用戶手冊",
        icon: "user",
        prefix: "user/",
        children: ["intro", { text: "...", icon: "ellipsis", link: "" }],
      },
    ],
  },
  {
    text: "報錯",
    icon: "bug",
    link: "https://github.com/paulusyeung/xOpti/issues",
  },
  {
    text: "討論",
    icon: "comments",
    link: "https://github.com/paulusyeung/xOpti/discussions",
  },
]);
