import { InfoSectionManager } from "../../../controls/InfoSectionManager";
import { i18n } from "../../../i18n/i18n";
import { DebugResults, defaultUrlEntry, UrlEntry } from "../../../types";

export class DebugFix {
  private debugContainer: HTMLDivElement;
  private static readonly containerId = "debug-fix-section";
  debugSectionResult: UrlEntry;

  constructor(debugSectionResult: UrlEntry) {
    this.debugSectionResult = { ...defaultUrlEntry, ...debugSectionResult };
    this.debugContainer = document.createElement("div");
    this.debugContainer.className = "debug-fix-section";
    this.debugContainer.id = DebugFix.containerId + this.debugSectionResult.AffectedInfoId;
    this.init();
  }

  private init() {
    this.debugContainer.style.fontFamily = "sans-serif";

    const errorText = document.createElement("p");
    errorText.textContent = i18n.t("navbar.debug.debug_error_message");
    errorText.style.color = "#BC0A0A";
    errorText.style.marginTop = "16px";

    const input = document.createElement("input");
    input.type = "text";
    input.value = this.debugSectionResult.Url;
    input.style.marginTop = "0";
    input.className = "tb-form-control cta-action-input";

    this.debugContainer.innerHTML = "";
    this.debugContainer.appendChild(errorText);
    this.debugContainer.appendChild(input);

    const handleInput = this.debounce((value: string) => {
      if (this.debugSectionResult.AffectedType === "Cta") {
        this.fixCtaUrl(value);
      } else if (this.debugSectionResult.AffectedType === "Tile") {
        this.fixTileUrl(value);
      }
    }, 800); // Adjust delay as needed

    input.addEventListener("input", () => {
      handleInput(input.value);
    });
  }

  private fixCtaUrl(url: string) {
    const infoSectionManager = new InfoSectionManager();
    const infoId = this.debugSectionResult.AffectedInfoId;
    const attribute =
      this.debugSectionResult.UrlType === "ImgUrl" ? "CtaButtonImgUrl" : "CtaAction";
    infoSectionManager.updateInfoCtaAttributes(infoId, attribute, url);
    this.updateDebugSectionResult(this.debugSectionResult.UrlType);
  }

  private fixTileUrl(url: string) {
    const tileId = this.debugSectionResult.AffectedTileId;
    if (!tileId)  return;
    const infoSectionManager = new InfoSectionManager();
    const infoId = this.debugSectionResult.AffectedInfoId;
    const attribute =
      this.debugSectionResult.UrlType === "ImgUrl" ? "BGImageUrl" : "Action.ObjectUrl";
    infoSectionManager.updateInfoTileAttributes(infoId, tileId, attribute, url);
    this.updateDebugSectionResult(this.debugSectionResult.UrlType);
  }

  private updateDebugSectionResult(type: string) {
    const affectedInfoId = this.debugSectionResult.AffectedInfoId;
    const debugResults: DebugResults = (globalThis as any).debugResults;
    const pageId = (globalThis as any).currentPageId;
    const page = debugResults.Pages.find((p) => p.PageId === pageId);

    if (!page) {
      throw new Error(`Page with ID ${pageId} not found`);
    }

    const urlEntry = page.UrlList.find((url) => (url.AffectedInfoId === affectedInfoId && url.UrlType === type));

    if (!urlEntry) {
      throw new Error(`URL entry with AffectedInfoId ${affectedInfoId} not found`);
    }

    // Update the property
    urlEntry["IsFixed"] = true;
    console.log('debugResults', debugResults)
  }

  private debounce<T extends (...args: any[]) => void>(func: T, delay: number): T {
    let timeout: ReturnType<typeof setTimeout>;
    return function (this: any, ...args: any[]) {
      clearTimeout(timeout);
      timeout = setTimeout(() => func.apply(this, args), delay);
    } as T;
  }

  render(container: HTMLElement) {
    container.appendChild(this.debugContainer);
  }
}
