import { AppVersionController } from "../../controls/versions/AppVersionController";
import { ToolBoxService } from "../../services/ToolBoxService";

export class LanguageTranslate {
  private VersionController: AppVersionController;
  private languages: string[];
  constructor() {
    this.VersionController = new AppVersionController();
    this.languages = ["en", "nl"];
  }
  async translate() {
    const activeVersion = await this.VersionController.getActiveVersion();
    const activeVersionId = activeVersion?.AppVersionId as string;
    const AppVersionLanguage = activeVersion?.AppVersionLanguage as string;
    const activePageId = (globalThis as any).currentPageId as string;
    // Exclude the current app version language
    const filteredLanguages = this.languages.filter((lang) => lang !== AppVersionLanguage);

    // console.log("activeVersionId:", activeVersionId);
    // console.log("AppVersionLanguage:", AppVersionLanguage);
    // console.log("activePageId:", activePageId);
    // console.log("filteredLanguages:", filteredLanguages);

    const toolboxService = new ToolBoxService();
    toolboxService.TranslateAppVersionLanguages(
      activeVersionId,
      activePageId,
      AppVersionLanguage,
      filteredLanguages
    );
  }
}
