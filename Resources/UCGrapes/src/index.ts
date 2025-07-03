import ToolboxApp from "./app";
import { AppConfig } from "./AppConfig";
import { Form, Media, ProductService, Theme } from "./types";

export class App {
  private toolboxApp: ToolboxApp;
  currentVersion: string | null;
  currentThemeId: string | null;
  editors: { [key: string]: any } = {};
  suppliers: any[];
  forms: Form[];

  constructor(
    UC: any,
    themes: Theme[],
    suppliers: any[],
    services: ProductService[],
    forms: Form[],
    media: Media[],
    currentThemeId: string | null,
    currentVersion: string | null,
    organisationLogo: string | null,
    currentLanguage: string,
    addServiceButtonEvent: any,
    addTemplatesButtonEvent: any
  ) {
    this.currentVersion = currentVersion;
    (globalThis as any).activeVersion = currentVersion
    this.currentThemeId = currentThemeId;
    this.suppliers = suppliers;
    this.forms = forms;
    const config = AppConfig.getInstance();
    config.init(
      UC,
      themes,
      suppliers,
      services,
      forms,
      media,
      currentThemeId,
      currentVersion,
      organisationLogo,
      currentLanguage,
      addServiceButtonEvent,
      addTemplatesButtonEvent
    );

    (window as any).app = this;
    this.toolboxApp = new ToolboxApp();
  }

  static createWithVersion(
    versionId: string | null,
    themeId: string | null
  ): App {
    const config = AppConfig.getInstance();

    if (!config.themes || !config.services) {
      throw new Error(
        "AppConfig must be initialized before calling createWithVersion."
      );
    }

    config.setInitialization(false);

    const tbBody = document.getElementById("tb-body");
    if (tbBody) {
      tbBody.outerHTML = App.getFreshTBBodyHTML();
    }

    return new App(
      config.UC,
      config.themes,
      config.suppliers,
      config.services,
      config.forms,
      config.media,
      themeId || config.currentThemeId,
      versionId,
      config.organisationLogo,
      config.currentLanguage,
      config.addServiceButtonEvent,
      config.addTemplatesButtonEvent
    );
  }

  private static getFreshTBBodyHTML(): string {
    return `
    <div id="tb-body">
      <div class="tb-navbar" id="tb-navbar">
        <div class="navbar-buttons" id="navbar-buttons-left"></div>
        <div class="navbar-buttons" id="navbar-buttons"></div>
      </div>
      <div class="tb-container">
        <div class="main-content" id="main-content"></div>
        <div class="sidebar sidebar-right" id="tb-sidebar">
          <div id="page-info-title"></div>
          <div id="page-info-section"></div>
          <div id="tools-section"></div>
          <div id="mapping-section" style="display: none;">
            <div class="mapping-header">
              <h3><span id="sidebar_mapping_title"></span></h3>
            </div>
            <div class="sidebar-section">
              <div id="tree-container" class="tb-list-container"></div>
            </div>
          </div>
        </div>
        <div class="tb-alerts-container" id="tb-alerts-container"></div>
      </div>
    </div>
  `;
  }
}

// Expose the App class globally
(window as any).App = App;
