import { InfoSectionManager } from "../../../../controls/InfoSectionManager";
import { i18n } from "../../../../i18n/i18n";
import { capitalizeWords } from "../../../../utils/helpers";

export class TitleInputSection {
  input: HTMLInputElement;
  private debounceTimer: number | null = null;
  private readonly debounceDelay: number = 500; 

  constructor() {
    this.input = document.createElement("input");
    this.init();
  }

  init() {
    this.input.type = "text";
    this.input.placeholder = i18n.t("sidebar.input_place_holder");
    this.input.classList.add("tb-form-control");
    this.input.id = "tile-title";

    this.input.addEventListener("input", (e) => {
      e.preventDefault();

      // Clear existing timer
      if (this.debounceTimer) {
        clearTimeout(this.debounceTimer);
      }

      // Set new timer
      this.debounceTimer = window.setTimeout(() => {
        this.handleInputChange();
      }, this.debounceDelay);
    });
  }

  private handleInputChange() {
    let titleValue = capitalizeWords(this.input.value);
    const selectedComponent = (globalThis as any).selectedComponent;

    const isFirstTile =
      selectedComponent.getClasses().includes("first-tile") &&
      selectedComponent.getClasses().includes("high-priority-template");

    if (!selectedComponent) return;
    const componentRow = selectedComponent.closest(".container-row");
    const rowTilesLength = componentRow.components().length;

    const tileTitle = selectedComponent.find(".tile-title")[0];
    if (tileTitle) {
      const truncatedTitle =
        rowTilesLength === 3
          ? this.truncate(11)
          : rowTilesLength === 2
            ? this.truncate(14)
            : this.truncate(25);
      tileTitle.components(truncatedTitle);
      tileTitle.addAttributes({ title: titleValue });
    }

    // if tile is first and high priority, set text to upper case
    if (isFirstTile) titleValue = titleValue.toUpperCase();
    const pageData = this.getPageData();
    if (pageData.PageType === "Information") {
      const infoSectionManager = new InfoSectionManager();
      const rowComp = selectedComponent.closest(".container-row");
      const colComp = selectedComponent.closest(".tile-column");
      const tile = selectedComponent.closest(".template-wrapper");

      infoSectionManager.updateGridTileAttribute(
        rowComp.getId(),
        colComp.getId(),
        tile.getId(),
        "Text",
        titleValue.trim()
      );
    }

    const parentComponent = tileTitle.parent();
    if (parentComponent) {
      if (parentComponent.getStyle()["display"] === "none") {
        parentComponent.addStyle({ display: "block" });
      }
    }
  }

  truncate(length: number) {
    if (this.input.value.length > length) {
      return this.input.value.substring(0, length) + "..";
    }
    return this.input.value;
  }

  private getPageData(): any {
    return (globalThis as any).pageData;
  }

  render(container: HTMLElement) {
    container.appendChild(this.input);
  }

  // Clean up method to clear timer if component is destroyed
  destroy() {
    if (this.debounceTimer) {
      clearTimeout(this.debounceTimer);
      this.debounceTimer = null;
    }
  }
}
