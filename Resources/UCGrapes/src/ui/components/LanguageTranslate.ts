import { ToolBoxService } from "../../services/ToolBoxService";

export class LanguageTranslate {
  private languages: string[];
  constructor() {
    this.languages = ["en", "nl"];
  }
  translate() {
    const activeVersion = (globalThis as any).activeVersion;
    const activeVersionId = activeVersion.AppVersionId as string;
    const AppVersionLanguage = activeVersion.AppVersionLanguage as string;
    const activePageId = (globalThis as any).currentPageId as string;
    // Exclude the current app version language
    const filteredLanguages = this.languages.filter((lang) => lang !== AppVersionLanguage);

    try {
      const toolboxService = new ToolBoxService();
      toolboxService.TranslateAppVersionLanguages(
        activeVersionId,
        activePageId,
        AppVersionLanguage,
        filteredLanguages
      );
    } catch (error) {
      console.error("Translation failed:", error);
    }
  }
}
