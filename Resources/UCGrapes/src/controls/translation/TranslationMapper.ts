// TranslationMapper.ts
import { ToolBoxService } from "../../services/ToolBoxService";
import { InfoType } from "../../types";
import { ThemeManager } from "../themes/ThemeManager";
import { TranslationUI } from "./TranslationUI ";

export class TranslationMapper {
  data: any;
  pageId: string;
  language: string;
  themeManager: ThemeManager;
  private translationUI: TranslationUI;

  constructor(data: any, pageId: string, language: string) {
    this.data = data;
    this.pageId = pageId;
    this.language = language;
    this.themeManager = new ThemeManager();
    this.translationUI = new TranslationUI(this.themeManager);
  }

  private updateDataPath(path: string, value: string): void {
    const pathParts = path.split(".");
    let current = this.data;

    for (let i = 0; i < pathParts.length - 1; i++) {
      const part = pathParts[i];
      if (current[part] === undefined) {
        current[part] = {};
      }
      current = current[part];
    }

    const finalKey = pathParts[pathParts.length - 1];
    current[finalKey] = value;

    this.saveUpdatedData(this.data);
  }

  private async saveUpdatedData(data: any): Promise<void> {
    const autoSaveSection = document.querySelector(
      ".auto-saving-section-content-text"
    ) as HTMLElement;
    const autoSavedSection = document.querySelector(
      ".auto-saved-section-content-text"
    ) as HTMLElement;
    autoSaveSection.style.display = "none";
    autoSavedSection.style.display = "none";

    const toolboxService = new ToolBoxService();
    try {

      const startTime = Date.now();
      const minDelay = 500; // Minimum 500ms delay

      // Run save operation and minimum delay in parallel
      const [saveResult] = await Promise.all([
        await toolboxService.updateTranslatedVersion(this.pageId, this.language, data),
        new Promise((resolve) => setTimeout(resolve, minDelay)),
      ]);

      autoSaveSection.style.display = "none";
      autoSavedSection.style.display = "flex";
    } catch (error) {
      throw error;
    } finally {
      setTimeout(() => {
        autoSavedSection.style.display = "none";
      }, 1000);
    }
  }

  public convertToHTML(): string {
    const infoContent = this.data.InfoContent || [];
    let htmlContent = "";
    let i = 0;

    while (i < infoContent.length) {
      const section = infoContent[i];

      if (section.InfoType === "Cta" && section.CtaAttributes?.CtaButtonType === "Round") {
        const roundCtaSections = [section];
        let j = i + 1;

        while (
          j < infoContent.length &&
          infoContent[j].InfoType === "Cta" &&
          infoContent[j].CtaAttributes?.CtaButtonType === "Round"
        ) {
          roundCtaSections.push(infoContent[j]);
          j++;
        }

        if (roundCtaSections.length > 1) {
          htmlContent += this.translationUI.createMergedRoundCtaSection(roundCtaSections, i);
          i = j;
        } else {
          htmlContent += this.translationUI.createCtaSection(section, i);
          i++;
        }
      } else {
        switch (section.InfoType) {
          case "TileRow":
            htmlContent += this.translationUI.createTileRowSection(section, i);
            break;
          case "TileGrid": // Add this case for TileGrid
            htmlContent += this.translationUI.createTileGridSection(section);
            break;
          case "Description":
            htmlContent += this.translationUI.createDescSection(section, i);
            break;
          case "Images":
            htmlContent += this.translationUI.createImageSlideSection(section);
            break;
          case "Cta":
            htmlContent += this.translationUI.createCtaSection(section, i);
            break;
          default:
            htmlContent += "";
        }
        i++;
      }
    }

    this.translationUI.setupEditableElements((dataPath, newValue) => {
      this.updateDataPath(dataPath, newValue);
      this.onContentChanged?.(dataPath, newValue);
    });

    return `
    <div class="translate-column"
    style="font-family: ${this.themeManager.getFontFamily()}"
    ">
      ${htmlContent}
    </div>
  `;
  }

  public getUpdatedData(): any {
    return this.data;
  }

  public onContentChanged?: (dataPath: string, newValue: string) => void;
}
