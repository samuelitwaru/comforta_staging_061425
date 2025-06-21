import { TileProperties } from "../../../../controls/editor/TileProperties";
import { InfoSectionManager } from "../../../../controls/InfoSectionManager";
import { ThemeManager } from "../../../../controls/themes/ThemeManager";
import { InfoType, ThemeIcon } from "../../../../types";
import { DefaultAttributes } from "../../../../utils/default-attributes";
import { capitalizeWords } from "../../../../utils/helpers";

export class IconList {
  private themeManager: ThemeManager;
  private icons: HTMLElement[] = [];
  iconsCategory: string = "Technical Services & Support";

  constructor(themeManager: ThemeManager, iconsCategory: string, searchQuery: string = "") {
    this.themeManager = themeManager;
    this.iconsCategory = iconsCategory || "Technical Services & Support";
    this.init(searchQuery);
  }

  init(searchQuery:string) {
    this.icons = [];
    let themeIcons: ThemeIcon[] = this.themeManager.getActiveThemeIcons();
    // Filter icons by category and theme
    if (searchQuery) {
      themeIcons = this.searchIcons(searchQuery, themeIcons);
    }else {
      themeIcons = themeIcons.filter(
        (icon) => icon.IconCategory === this.iconsCategory 
      );
    }
    themeIcons.forEach((themeIcon) => {
        const icon = document.createElement("div");
        icon.classList.add("icon");
        icon.title = capitalizeWords(themeIcon.IconName.replace(/-/g,' ').replace(/_/g,' '));
        icon.innerHTML = `${themeIcon.IconSVG}`;

        icon.addEventListener("click", (e) => {
          e.preventDefault();

          const selectedComponent = (globalThis as any).selectedComponent;
          if (!selectedComponent) return;

          const iconComponent = selectedComponent.find(".tile-icon")[0];
          if (!iconComponent) return;
          const currentTileColor = selectedComponent.getStyle()?.["color"];
          const whiteSVG = themeIcon.IconSVG.replace(
            /fill="#[^"]*"/g,
            `fill="${currentTileColor || "white"}"`
          );
          const iconSVGWithAttributes = whiteSVG.replace(
            "<svg",
            `<svg ${DefaultAttributes}`
          );

          iconComponent.components(iconSVGWithAttributes);
          iconComponent.addAttributes({
            title: themeIcon.IconName,
          });

          const iconCompParent = iconComponent.parent();
          iconCompParent.addStyle({
            display: "block",
          });

          const tileWrapper = selectedComponent.parent();
          const rowComponent = tileWrapper.parent();
          let tileAttributes;

          const pageData = (globalThis as any).pageData;
          if (pageData.PageType === "Information") {
            const infoSectionManager = new InfoSectionManager();
            infoSectionManager.updateInfoTileAttributes(
              rowComponent.getId(),
              tileWrapper.getId(),
              "Icon",
              themeIcon.IconName
            );

            const tileInfoSectionAttributes: InfoType = (
              globalThis as any
            ).infoContentMapper.getInfoContent(rowComponent.getId());

            tileAttributes = tileInfoSectionAttributes?.Tiles?.find(
              (tile: any) => tile.Id === tileWrapper.getId()
            );
          } else {
            (globalThis as any).tileMapper.updateTile(
              selectedComponent.parent().getId(),
              "Icon",
              themeIcon.IconName
            );
            tileAttributes = (globalThis as any).tileMapper.getTile(
              rowComponent.getId(),
              tileWrapper.getId()
            );
          }

          const tileProperties = new TileProperties(
            selectedComponent,
            tileAttributes
          );
          tileProperties.setTileAttributes();
        });

        this.icons.push(icon);
      });

    
  }

  searchIcons(query:string, iconList: any[]) {
      if (!query || !iconList || !Array.isArray(iconList)) return [];
  
      const normalizedQuery = query.trim().toLowerCase();
      return iconList
        .map((icon:any) => {
          const name = icon.IconName?.toLowerCase() || "";
          const tags = icon.IconTags?.split(",").map((tag:any) => tag.toLowerCase()) || [];
  
          let score = 0;
  
          // Exact match boost
          if (name === normalizedQuery) score += 100;
          if (tags.includes(normalizedQuery)) score += 80;
  
          // Partial match
          if (name.includes(normalizedQuery)) score += 50;
          for (const tag of tags) {
            if (tag.includes(normalizedQuery)) score += 30;
          }
  
          // Word-level match
          const queryWords = normalizedQuery.split(/\s+/);
          for (const word of queryWords) {
            if (name.includes(word)) score += 20;
            for (const tag of tags) {
              if (tag.includes(word)) score += 10;
            }
          }
  
          return { ...icon, _score: score };
        })
        .filter(icon => icon._score > 0)
        .sort((a, b) => b._score - a._score)
        .map(({ _score, ...icon }) => icon); // remove internal score
  }

  render(container: HTMLElement) {
    this.icons.forEach((icon) => container.appendChild(icon));
  }
}
