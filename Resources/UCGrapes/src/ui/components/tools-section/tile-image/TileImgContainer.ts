import { InfoSectionManager } from "../../../../controls/InfoSectionManager";
import { ThemeManager } from "../../../../controls/themes/ThemeManager";
import { InfoType, Tile } from "../../../../types";

export class TileImgContainer {
  container: HTMLElement;
  positionX: number = 50;
  positionY: number = 50;
  zoomLevel: number = 1;
  infoSectionManager: InfoSectionManager;

  constructor() {
    this.container = document.createElement("div");
    this.infoSectionManager = new InfoSectionManager();
    this.init();
  }

  init() {
    this.container.classList.add("tile-img-container");
    this.container.id = "tile-img-container";

    this.container.innerHTML = `
    <svg xmlns="http://www.w3.org/2000/svg" width="14.5" height="16" viewBox="0 0 14.5 16">
      <g id="Icon_feather-trash-2" data-name="Icon feather-trash-2" transform="translate(0.5 0.5)">
        <path id="Path_68" data-name="Path 68" d="M4.5,9H18" transform="translate(-4.5 -6)" fill="none" stroke="#4c5357" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
        <path id="Path_69" data-name="Path 69" d="M18.572,6V16.5A1.542,1.542,0,0,1,16.99,18H9.082A1.542,1.542,0,0,1,7.5,16.5V6M9.872,6V4.5A1.542,1.542,0,0,1,11.454,3h3.163A1.542,1.542,0,0,1,16.2,4.5V6" transform="translate(-6.285 -3)" fill="none" stroke="#4c5357" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
        <path id="Path_70" data-name="Path 70" d="M15,16.5v3.643" transform="translate(-9.75 -9.199)" fill="none" stroke="#4c5357" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
        <path id="Path_71" data-name="Path 71" d="M21,16.5v3.643" transform="translate(-12.75 -9.199)" fill="none" stroke="#4c5357" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
      </g>
    </svg>
    `;

    this.container.addEventListener("click", (e) => {
      e.preventDefault();

      const selectedComponent = (globalThis as any).selectedComponent;
      if (!selectedComponent) return;

      const tileWrapper = selectedComponent.parent();

      const rowComponent = tileWrapper.closest(".container-row");
      const colComponent = tileWrapper.closest(".tile-column");

      const rowId = rowComponent.getId();
      const tileId = tileWrapper.getId();
      const colId = colComponent.getId();

      const tileAttributes = this.getInfoTileAttributes(rowId, tileId);

      const themeManager = new ThemeManager();
      const themeColor = themeManager.getThemeColor(tileAttributes?.BGColor);

      // Update selected component styles
      const currentStyles = selectedComponent.getStyle();
      delete currentStyles["background-image"];
      currentStyles["background-color"] = themeColor;
      selectedComponent.setStyle(currentStyles);

      // Update actual element styles
      const el = selectedComponent.getEl();
      el.style.backgroundImage = "";
      el.style.backgroundColor = themeColor;

      const updates = {
        BGImageUrl: "",
        Opacity: "0",
        BGPosition: "",
        Top: "",
        Left: "",
        OriginalImageUrl: "",
        BGSize: "",
      };

      for (const [key, value] of Object.entries(updates)) {
        this.infoSectionManager.updateGridTileAttribute(rowId, colId, tileId, key, value);
      }

      // Hide UI elements
      this.container.style.display = "none";

      const slider = document.querySelector("#slider-wrapper") as HTMLElement;
      if (slider) {
        slider.style.display = "none";
      }
    });
  }

  private getInfoTileAttributes(rowComponentId: any, tileWrapperId: any): any {
    if (!rowComponentId || !tileWrapperId) return;
    const tileInfoSectionAttributes: InfoType | null =
      this.infoSectionManager.getInfoContent(rowComponentId);
    return this.findTileById(tileInfoSectionAttributes, tileWrapperId);
  }

  private findTileById(tileInfoSectionAttributes: any, tileWrapperId: string): Tile | null {
    for (const column of tileInfoSectionAttributes?.Columns || []) {
      const foundTile: Tile = column.Tiles?.find((tile: any) => tile.Id === tileWrapperId);
      if (foundTile) return foundTile;
    }
    return null;
  }

  render(container: HTMLElement) {
    container.appendChild(this.container);
  }
}
