import { ToolBoxService } from "../services/ToolBoxService";
import { TranslateSection } from "../ui/components/tools-section/translate/TranslateSection";
import { TranslationodeUIManager } from "./TranslationModeUIManager";

export class LanguageTranslate {
  private languages: string[];
  constructor() {
    this.languages = ["en", "nl"];
  }
  async translate() {
    const activeVersion = (globalThis as any).activeVersion;
    const activeVersionId = activeVersion.AppVersionId as string;
    const AppVersionLanguage = activeVersion.AppVersionLanguage as string;
    const activePageId = (globalThis as any).currentPageId as string;
    // Exclude the current app version language
    const filteredLanguages = this.languages.filter((lang) => lang !== AppVersionLanguage);

    try {
      const toolboxService = new ToolBoxService();
      const translate = await toolboxService.TranslateAppVersionLanguages(
        activeVersionId,
        activePageId,
        AppVersionLanguage,
        filteredLanguages
      );

      if (translate.result === "success") {
        const language = "nl";
        await toolboxService.TranslateSinglePage(activePageId, language).then((res: any) => {
          console.log("res", res.SDT_InfoContent);
          this.setUpSideBar(res.SDT_InfoContent);
        });
      }
    } catch (error) {
      console.error("Translation failed:", error);
    }
  }

  private setUpSideBar(data: any) {
    const sidebar = document.querySelector("#tb-sidebar") as HTMLDivElement;
    const pagesContent = document.querySelector("#tools-section") as HTMLDivElement;
    const pageTitle = document.querySelector("#page-info-title") as HTMLDivElement;
    const mappingSection = document.querySelector("#mapping-section") as HTMLDivElement;
    const pageInfoSection = document.querySelector("#page-info-section") as HTMLDivElement;

    if (sidebar) {
      this.enableTranslationMode();
      pagesContent.style.display = "none";
      pageTitle.style.display = "none";
      mappingSection.style.display = "none";
      pageInfoSection.style.display = "none";

      const translateSection = new TranslateSection(data);
      translateSection.render(sidebar);
    }
  }

  private enableTranslationMode() {
    const activeEditor = (globalThis as any).activeEditor;
    if (activeEditor) {
      (globalThis as any).isTranslationMode = true;
      const translationModeUi = new TranslationodeUIManager();
      translationModeUi.enableTranslationMode();
    }
  }
}
