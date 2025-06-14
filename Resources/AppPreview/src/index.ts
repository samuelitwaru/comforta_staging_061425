import { ToolboxPreview } from "./app";
import { AppVersionManager } from "./controls/AppVersionManager";
import { AppVersion } from "./interfaces/AppVersion";

class PreviewApp {
  constructor(
    appVersion: AppVersion
  ) {
    const version = AppVersionManager.getInstance();
    version.init(appVersion);
    this.init();
  }

  private init() {
    new ToolboxPreview();
  }
}

(window as any).PreviewApp = PreviewApp;