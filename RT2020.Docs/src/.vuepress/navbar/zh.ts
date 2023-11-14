import { navbar } from "vuepress-theme-hope";

export const zhNavbar = navbar([
  "/zh/",
  { text: "教程", icon: "video", link: "/zh/demo/" },
  {
    text: "指南",
    icon: "circle-info",
    prefix: "/zh/guide/",
    children: [
      {
        text: "Bar",
        icon: "creative",
        prefix: "bar/",
        children: ["baz", { text: "...", icon: "more", link: "" }],
      },
      {
        text: "Foo",
        icon: "config",
        prefix: "foo/",
        children: ["ray", { text: "...", icon: "more", link: "" }],
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
