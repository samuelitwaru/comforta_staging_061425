import { AppConfig } from "../../AppConfig";
import { ToolBoxService } from "../../services/ToolBoxService";
import { FrameList } from "../../ui/components/editor-content/FrameList";
import { LeftNavigatorButton } from "../../ui/components/editor-content/LeftNavigatorButton";
import { RightNavigatorButton } from "../../ui/components/editor-content/RightNavigatorButton";
import { ThemeManager } from "../themes/ThemeManager";
import { HistoryManager } from "../toolbox/HistoryManager";
import { ToolboxManager } from "../toolbox/ToolboxManager";
import { AppVersionManager } from "../versions/AppVersionManager";
import { EditorEvents } from "./EditorEvents";
import { EditorUIManager } from "./EditorUiManager";
import { JSONToGrapesJSInformation } from "./JSONToGrapesJSInformation";
import { JSONToGrapesJSMenu } from "./JSONToGrapesJSMenu";
import { TileMapper } from "./TileMapper";

declare const grapesjs: any;

export class EditorManager {
  private config: AppConfig;
  organisationLogo: string | any;
  toolboxService: ToolBoxService;
  selectedComponent: any;
  editors: { pageId: string; frameId: string; editor: any }[] = [];
  editorEvents: EditorEvents;
  jsonToGrapes: JSONToGrapesJSMenu;
  homepage: any;
  themeManager: any;
  appVersion: any;

  constructor() {
    this.config = AppConfig.getInstance();
    this.organisationLogo = this.config.organisationLogo;
    this.appVersion = new AppVersionManager();
    this.themeManager = new ThemeManager();
    this.toolboxService = new ToolBoxService();
    this.editorEvents = new EditorEvents();
    this.jsonToGrapes = new JSONToGrapesJSMenu(this);
  }

  async init(newVersion?: any) {
    const version = newVersion || await this.appVersion.getUpdatedActiveVersion();
    (globalThis as any).activeVersion = version;
    this.homepage = version?.Pages.find((page: any) => page.PageName === "Home");
    const mainContainer = document.getElementById('main-content') as HTMLDivElement
    mainContainer.innerHTML = ""
    this.setUpEditorFrame();
    this.setUpEditor();
    this.editorEvents.activateEditor(`gjs-0`)
  }

  setUpEditorFrame() {
    const frameList = new FrameList(`gjs-0`, this.homepage);
    
    const thumbsContainer = document.createElement("div");
    thumbsContainer.style.justifyContent = "center";
    thumbsContainer.style.display = "flex";
    thumbsContainer.style.flexDirection = "row";
    thumbsContainer.style.alignItems = "center";
    thumbsContainer.style.gap = "0.4rem"
    thumbsContainer.className = "editor-thumbs-list";
    thumbsContainer.id = "editor-thumbs-list";

    const editorFrameArea = document.getElementById(
      "main-content"
    ) as HTMLElement;

    const mainEditorSection = document.createElement("div");
    mainEditorSection.className = "editor-main-section";
    mainEditorSection.style.display = "flex";
    mainEditorSection.style.justifyContent = "center";
    mainEditorSection.style.alignItems = "center";
    mainEditorSection.style.flexDirection = "column";
    mainEditorSection.style.width = "100%";
    frameList.render(mainEditorSection);
    mainEditorSection.appendChild(thumbsContainer);

    editorFrameArea.appendChild(mainEditorSection);    

    this.setClientWidth(frameList.container);
  }

  setClientWidth(container: HTMLElement) {
    const frame = container.querySelector(".mobile-frame") as HTMLElement;
    if (frame) {
      (globalThis as any).deviceWidth = frame.clientWidth;
      (globalThis as any).deviceHeight = frame.clientHeight;
    }
  }

  async setUpEditor() {
    const editor = this.initializeGrapesEditor(`gjs-0`);
    (window as any).app.editors[`gjs-0`] = editor;
    this.finalizeEditorSetup(editor);
    await this.loadHomePage(editor);
    this.activateHomeEditor(`gjs-0`, editor);

    const theme = this.themeManager.getThemeById((globalThis as any).activeVersion.ThemeId);
    this.themeManager.setTheme(theme);
  }

  async loadHomePage(editor: any) {
    let converter;
    if (this.homepage.PageType == "Information") {
      converter = new JSONToGrapesJSInformation(this.homepage);
    } else {
      converter = new JSONToGrapesJSMenu(this.homepage);
    }

    const htmlOutput = converter.generateHTML();

    editor.setComponents(htmlOutput);
    this.editorEvents.init(editor, this.homepage, `gjs-0`, true);
    localStorage.setItem(
      `data-${this.homepage?.PageId}`,
      JSON.stringify(this.homepage)
    );

    new ToolboxManager().unDoReDo();
  }

  initializeGrapesEditor(editorId: string) {
    return grapesjs.init({
      container: `#${editorId}`,
      fromElement: true,
      height: "100%",
      width: "auto",
      canvas: {
        styles: [
          "/Resources/UCGrapes/public/css/toolbox.css",
          "/DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css?202521714271081",
          "https://fonts.googleapis.com/css2?family=Inter:opsz@14..32&family=Roboto:ital,wght@0,100..900;1,100..900&display=swap",
        ],
      },
      baseCss: " ",
      dragMode: "normal",
      panels: { defaults: [] },
      sidebarManager: false,
      storageManager: false,
      modal: false,
      commands: false,
      hoverable: false,
      highlightable: false,
      selectable: false,
      richTextEditor: {},
    });
  }

  finalizeEditorSetup(editor: any) {
    const wrapper = editor.getWrapper();

    wrapper.set({
      selectable: false,
      droppable: false,
      draggable: false,
      hoverable: false,
    });

    const canvas = editor.Canvas.getElement();
    if (canvas) {
      canvas.style.setProperty("height", "calc(100% - 110px)", "important");
    }

    const canvasBody = editor.Canvas.getBody();
    if (canvasBody) {
      canvasBody.style.setProperty("background-color", "#EFEEEC", "important");
    }
  }

  activateHomeEditor(frameId: string, editor: any) {
    const homeFrame = document.getElementById(`${frameId}-frame`) as HTMLElement;
    homeFrame.classList.add("active-editor");
  }  

  loadPageHistory(pageData: any) {
    const historyManager = new HistoryManager(pageData?.PageId);
    historyManager.addState(pageData);
  }
}
