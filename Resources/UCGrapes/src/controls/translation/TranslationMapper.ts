import { ThemeManager } from "../themes/ThemeManager";

export class TranslationMapper {
  data: any;
  themeManager: ThemeManager;
  constructor(data: any) {
    this.data = data;
    this.themeManager = new ThemeManager();
  }

  private createTileRowSection(section: any): string {
    const tiles = section.Tiles || [];
    let tilesHtml = "";

    tiles.forEach((tile: any) => {
      const hasBackgroundImage = tile.BGImageUrl && tile.BGImageUrl.trim() !== "";
      const backgroundColor = this.themeManager.getThemeColor(tile.BGColor);

      const backgroundStyle = hasBackgroundImage
        ? `background-image: url('${tile.BGImageUrl}'); background-size: cover; background-position: center;`
        : `background-color: ${backgroundColor};`;

      tilesHtml += `
        <div
          class="translated-tile"
         style="
          ${backgroundStyle}
          color: ${tile.Color || "#333"};
          align-items: center;
          justify-content: ${tile.Align || "left"};
          ">
          ${tile.Text || tile.Name || ""}
        </div>
      `;
    });

    return `<div class="translated-tile-row">${tilesHtml}</div>`;
  }

  private createDescSection(section: any): string {
    const description = section.InfoValue || "";
    return `
      <div class="translated-description">
        ${description}
      </div>
    `;
  }

  private createImageSlideSection(section: any): string {
    const images = section.Images || [];

    if (images.length === 0) return "";

    if (images.length === 1) {
      // Single image
      return `
        <div class="translated-images">
          <img src="${images[0].InfoImageValue}" 
               alt="Content Image" >
        </div>
      `;
    }

    // Multiple images - show only first image with counter
    return `
      <div class="translated-images" style="position: relative;">
          <img src="${images[0].InfoImageValue}" 
               alt="Content Image" >
          <div style="
            position: absolute;
            top: 10px;
            left: 10px;
            background: rgba(0,0,0,0.7);
            color: white;
            padding: 4px 8px;
            border-radius: 4px;
            font-size: 12px;
            font-weight: bold;
          ">1/${images.length}</div>
        </div>
    `;
  }

  private createCtaSection(section: any): string {
    // This method can be used for future CTA sections
    return `
      <div class="translated-cta">
        ${section.InfoValue || ""}
      </div>
    `;
  }

  public convertToHTML(): string {
    const infoContent = this.data.InfoContent || [];
    let htmlContent = "";

    infoContent.forEach((section: any) => {
      switch (section.InfoType) {
        case "TileRow":
          htmlContent += this.createTileRowSection(section);
          break;
        case "Description":
          htmlContent += this.createDescSection(section);
          break;
        case "Images":
          htmlContent += this.createImageSlideSection(section);
          break;
        case "Cta":
          htmlContent += this.createCtaSection(section);
          break;
        default:
          console.log("Unknown section type:", section.InfoType);
      }
    });

    // Wrap everything in a container div with JavaScript for slider functionality
    return `
      <div class="translate-container"
      style="font-family: ${this.themeManager.getFontFamily()}"
      ">
        ${htmlContent}
      </div>
    `;
  }
}
