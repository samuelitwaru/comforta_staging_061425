import { CtaAttributes, DebugResults, defaultUrlEntry, UrlEntry } from "../../types";
import { ActionInput } from "../../ui/components/tools-section/content-section/ActionInput";
import { DebugFix } from "../../ui/components/tools-section/DebugFix";
import { TextColor } from "../../ui/components/tools-section/title-section/TextColor";
import { ThemeManager } from "../themes/ThemeManager";

export class CtaButtonProperties {
  ctaAttributes: CtaAttributes;
  selectedComponent: any;
  themeManager: any;
  pageData: any;

  constructor(selectedComponent: any, ctaAttributes: any) {
    this.selectedComponent = selectedComponent;
    this.ctaAttributes = ctaAttributes;
    this.themeManager = new ThemeManager();
    this.pageData = (globalThis as any).pageData;
  }

  public setctaAttributes() {
    this.waitForButtonLayoutContainer(() => {
      this.checkButtonLayouts();
      this.ctaColorAttributes();
      this.ctaActionDisplay();
      this.ctaLabelColor();
      this.setCtaDebugStatus();
    });
  }

  private waitForButtonLayoutContainer(callback: () => void) {
    const interval = setInterval(() => {
      const buttonLayoutContainer = document?.querySelector(".cta-button-layout-container");
      const contentSection = document?.querySelector("#content-page-section");
      if (buttonLayoutContainer && contentSection) {
        clearInterval(interval);
        callback();
      }
    }, 100);
  }

  private checkButtonLayouts() {
    if (this.ctaAttributes) {
      const buttons = document.querySelectorAll(".cta-button-layout") as NodeListOf<HTMLElement>;
      buttons.forEach((button) => {
        if (
          this.ctaAttributes.CtaButtonType === "FullWidth" &&
          button.id === "plain-button-layout"
        ) {
          button.style.border = "2px solid #5068a8";
        } else if (
          this.ctaAttributes.CtaButtonType === "Icon" &&
          button.id === "icon-button-layout"
        ) {
          button.style.border = "2px solid #5068a8";
        } else if (
          this.ctaAttributes.CtaButtonType === "Image" &&
          button.id === "image-button-layout"
        ) {
          button.style.border = "2px solid #5068a8";
        } else if (
          this.ctaAttributes.CtaButtonType === "Round" &&
          button.id === "round-button-layout"
        ) {
          button.style.border = "2px solid #5068a8";
          button.style.borderRadius = "50%";
        } else {
          button.style.border = "";
        }
      });
    }
  }

  private ctaColorAttributes() {
    const contentSection = document.querySelector("#content-page-section");
    const colorItems = contentSection?.querySelectorAll(".color-item > input");
    const ctaColorAttribute = this.themeManager.getThemeCtaColor(this.ctaAttributes?.CtaBGColor);

    colorItems?.forEach((input: any) => {
      if (input.value === ctaColorAttribute) {
        input.checked = true;
      }
    });
  }

  private ctaActionDisplay() {
    const contentSection = document.querySelector("#content-page-section");
    const labelValue = this.ctaAttributes?.CtaLabel;
    const labelInput = new ActionInput(labelValue, this.ctaAttributes, "label", "cta");
    labelInput.render(contentSection as HTMLElement);

    console.log('this.ctaAttributes?.CtaAction', this.ctaAttributes?.CtaAction)
    const actionValue = this.ctaAttributes?.CtaAction;
    const actionInput = new ActionInput(actionValue, this.ctaAttributes, "action", "cta");
    actionInput.render(contentSection as HTMLElement);
  }

  private ctaLabelColor() {
    const contentSection = document.querySelector("#content-page-section");
    const labelColor = new TextColor("cta");
    labelColor.render(contentSection as HTMLElement);

    const color = this.ctaAttributes?.CtaColor;

    const ctaColorSection = contentSection?.querySelector("#text-color-palette");
    const ctaColorsOptions = ctaColorSection?.querySelectorAll("input");
    ctaColorsOptions?.forEach((option) => {
      if (option.value === color) {
        option.checked = true;
      } else {
        option.checked = false;
      }
    });
  }

  private setCtaDebugStatus() {
    // search for a tag with id menu-page-section and attach a paragraph tag
    const ctaPageSection = document.getElementById("content-page-section") as HTMLDivElement;
    if (ctaPageSection) {
      this.clearAllDebugSection(ctaPageSection);
      const infoSectionComponentId = this.selectedComponent.getId();
      if (infoSectionComponentId) {
        const debugResults: UrlEntry[] | undefined =
          this.infoSectionDebugItem(infoSectionComponentId);
        if (debugResults && debugResults.length > 0) {
          debugResults.forEach((result: UrlEntry) => {
            result = { ...defaultUrlEntry, ...result };
            const statusCode = Number(result.StatusCode);
            if ((!result.IsFixed && statusCode < 200) || (!result.IsFixed && statusCode > 300)) {
              const debugSection = new DebugFix(result);
              debugSection.render(ctaPageSection);
            }
          });
        }
      }
    }
  }

  private clearAllDebugSection(ctaPageSection: HTMLDivElement) {
    const existingInfoSections = ctaPageSection.querySelectorAll(".debug-fix-section");
    if (existingInfoSections) {
      existingInfoSections.forEach((section) => {
        section.remove();
      });
    }
  }

  private infoSectionDebugItem(affectedInfoId: string): UrlEntry[] | undefined {
    const debugResults: DebugResults = (globalThis as any).debugResults;
    const pageId = (globalThis as any).currentPageId;
    if (debugResults) {
      const page = debugResults.Pages.find((p) => p.PageId === pageId);
      if (page) {
        return page.UrlList.filter((url) => url.AffectedInfoId === affectedInfoId);
      }
    }
    return undefined;
  }
}
