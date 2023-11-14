import { navbar } from "vuepress-theme-hope";

export const enNavbar = navbar([
  "/",
  { text: "Tutorial", icon: "video", link: "/tutorial/" },
  {
    text: "Docs",
    icon: "circle-info",
    prefix: "/docs/",
    children: [
      {
        text: "Developer Guide",
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
        text: "User Guide",
        icon: "user",
        prefix: "user/",
        children: ["ray", { text: "...", icon: "more", link: "" }],
      },
    ],
  },
  {
    text: "Issues",
    icon: "bug",
    link: "https://github.com/paulusyeung/xOpti/issues",
  },
  {
    text: "Discussions",
    icon: "comments",
    link: "https://github.com/paulusyeung/xOpti/discussions",
  },
]);
