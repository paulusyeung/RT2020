import { sidebar } from "vuepress-theme-hope";

export const enSidebar = sidebar({
  "/": [
    "",
    {
      text: "Tutorial",
      icon: "video",
      prefix: "tutorial/",
      link: "tutorial/",
      children: "structure",
    },
    {
      text: "Docs",
      icon: "circle-info",
      prefix: "docs/",
      link: "docs/",
      children: "structure",
      // children: [
      //   {
      //     text: 'Developer Guide',
      //     link: 'developer/',
      //     collapsible: true,
      //     children: [
      //       {
      //         text: 'Prefix',
      //         link: 'developer/',
      //         children: [
                
      //         ],
      //       },
      //       {
      //         text: 'Chapter A',
      //         link: 'developer/baz',
      //         children: [
                
      //         ],
      //       },
      //     ],
      //   },
      //   {
      //     text: 'User Guide',
      //     link: 'user/',
      //     collapsible: true,
      //     children: [
      //       {
      //         text: 'Prefix',
      //         link: 'user/',
      //         children: [
                
      //         ],
      //       },
      //       {
      //         text: 'Chapter A',
      //         link: 'user/ray',
      //         children: [
                
      //         ],
      //       },
      //     ],
      //   },
      //   // string - page file path
      //   '/developer/baz.md',
      // ],
    },
    //"slides",
  ],
});
