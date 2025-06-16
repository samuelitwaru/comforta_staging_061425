import { version } from "d3";
import { AppConfig } from "../../AppConfig";
import { ToolBoxService } from "../../services/ToolBoxService";
import { TileMapper } from "../editor/TileMapper";
import { AppVersionController } from "./AppVersionController";

export class AppVersionManager {
  private config: AppConfig;
  toolboxService: any;
  themes: any[] = [];
  appVersion: any;

  constructor() {
    this.config = AppConfig.getInstance();
    this.initializeActiveVersion();
  }

  private async initializeActiveVersion() {
    try {
      // Initialize from window.app.currentVersion if available
      if ((window as any).app?.currentVersion) {
        (globalThis as any).activeVersion = (window as any).app.currentVersion;
        this.appVersion = (globalThis as any).activeVersion;
        return;
      }

      // Fallback to fetching from service
      const toolboxService = new ToolBoxService();
      const appVersion = await toolboxService.getVersion();
      (globalThis as any).activeVersion = appVersion.AppVersion;
      this.appVersion = (globalThis as any).activeVersion;
    } catch (error) {
      console.error('Failed to initialize active version:', error);
      (globalThis as any).activeVersion = null;
      this.appVersion = null;
    }
  }

  public async getCurrentVersion() {
    const versionController = new AppVersionController();
    const toolboxService = new ToolBoxService();
    const versions = await versionController.getVersions();
    const location = await toolboxService.getLocationData();
    const currentPublishedAppId = location.BC_Trn_Location.PublishedActiveAppVersionId;
    return versions.find((version: any) => version.AppVersionId == currentPublishedAppId);
  }

  public getActiveVersion() {
    // Return the already initialized version
    return (globalThis as any).activeVersion;
  }

  public async refreshActiveVersion() {
    // Only refresh when explicitly needed
    const toolboxService = new ToolBoxService();
    const appVersion = await toolboxService.getVersion();
    (globalThis as any).activeVersion = appVersion.AppVersion;
    this.appVersion = (globalThis as any).activeVersion;
    return (globalThis as any).activeVersion;
  }

  public async refreshVersion() {
    await this.refreshActiveVersion();
  }

  public getPages() {
    return (globalThis as any).activeVersion?.Pages || null;
  }

  public async preDefinedPages() {
    const res = this.getPages() || [];
    const pages = res.filter(
      (page: any) =>
        page.PageType == "Maps" ||
        page.PageType == "Map" ||
        page.PageType == "MyActivity" ||
        (page.PageType == "Calendar" && page.PageName !== "Home")
    );
    return pages;
  }

  async getActiveVersionId() {
    const activeVersion = (globalThis as any).activeVersion;
    return activeVersion?.AppVersionId;
  }

  async updatePageTitle(pageTitle: string) {
    const pageId = (globalThis as any).currentPageId;
    const selectedTileMapper = (globalThis as any).tileMapper;
    const selectedComponent = (globalThis as any).selectedComponent;

    if (!pageId) return;

    const toolboxService = new ToolBoxService();

    const pageData = {
      AppVersionId: await this.getActiveVersionId(),
      PageId: pageId,
      PageName: pageTitle,
    };
    const res = await toolboxService.updatePageTitle(pageData);
    if (res) {
      const data = localStorage.getItem(`data-${pageId}`);
      if (data) {
        const page = JSON.parse(data);
        page.PageName = pageTitle;
        localStorage.setItem(`data-${pageId}`, JSON.stringify(page)); 
        await this.refreshVersion();       
      }
    }

    await this.refreshVersion();
  }
}