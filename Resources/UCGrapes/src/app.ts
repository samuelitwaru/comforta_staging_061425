import { AppConfig } from "./AppConfig";
import { EditorManager } from "./controls/editor/EditorManager";
import { Localisation } from "./controls/Localisation";
import { ToolboxManager } from "./controls/toolbox/ToolboxManager";
import { i18n, i18nModule } from "./i18n/i18n";

class ToolboxApp {
  private toolboxManager: ToolboxManager;
  private editor: EditorManager;
  private config: AppConfig;
  translations: any;

  constructor() {
    this.config = AppConfig.getInstance();
    this.toolboxManager = new ToolboxManager();
    this.editor = new EditorManager();
    if (!this.config.isInitialized) {
      console.error("ToolboxApp created before AppConfig was initialized!");
    }

    this.initialiseLocalisation();
    this.initialise();
  }

  initialise(): void {
    this.toolboxManager.setUpNavBar();
    this.toolboxManager.setUpSideBar();
    this.removeModalListener();
    this.editor.init();
  }

  initialiseLocalisation() {
    if (this.config.currentLanguage == "Dutch") {
      i18n.locale = "nl";
    } else {
      i18n.locale = "en";
    }

    const activeVersion = (globalThis as any).activeVersion;
    const versionLanguage = activeVersion.AppVersionLanguage;
    i18nModule.locale = versionLanguage;
  }

  removeModalListener(): void {
    document.addEventListener("click", (event: MouseEvent) => {
      const target = event.target as HTMLElement;
      const modalContent = target.closest(".tb-modal-content, .modal-dialog");

      if (modalContent) {
        event.stopPropagation();
        return;
      }

      // Check if click is on modal backdrop
      if (
        target.classList.contains("tb-modal") ||
        target.classList.contains("popup-modal-link") ||
        target.classList.contains("popup-modal")
      ) {
        target.style.display = "none";
      }
    });
  }
}

export default ToolboxApp;
