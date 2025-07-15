import { TranslationMapper } from "../../../../controls/translation/TranslationMapper";
import { ToolBoxService } from "../../../../services/ToolBoxService";
import { TranslationStructure } from "../../../../types";

export class TranslateFrame {
  frame!: HTMLDivElement;
  data: TranslationStructure;
  pageId: string;
  language: string;
  constructor(data: TranslationStructure, pageId: string, language: string) {
    this.data = data;
    this.pageId = pageId;
    this.language = language;
    this.init();
  }

  private init() {
    this.frame = document.createElement("div");
    this.frame.classList.add("translate-page-frame");
    this.frame.id = "translate-page-frame";

    const pageTitle = this.data.PageName;

    const container = document.createElement("div");
    container.classList.add("translate-container");

    const header = this.header();
    const homeAppbar = this.homePageAppBar();
    const otherAppbar = this.otherPageAppBar(pageTitle);
    const body = this.body();

    const frameContainer = body.querySelector(".translate-column") as HTMLElement | null;

    container.append(header);
    // container.append(homeAppbar);
    container.append(otherAppbar);

    if (frameContainer instanceof HTMLElement) {
      container.append(frameContainer);
    } else {
      console.warn("frameContainer is null or not an HTMLElement", frameContainer);
    }

    this.frame.append(container);
    this.pageTitleEvents();
  }

  private header(): HTMLDivElement {
    const headerDiv = document.createElement("div");
    headerDiv.className = "header";

    const clockSpan = document.createElement("span");
    clockSpan.id = "clock";
    clockSpan.textContent = this.getCurrentTime();

    const iconsSpan = document.createElement("span");
    iconsSpan.className = "icons";
    iconsSpan.innerHTML =
      '<i class="fas fa-signal"></i><i class="fas fa-wifi"></i><i class="fas fa-battery"></i>';

    headerDiv.appendChild(clockSpan);
    headerDiv.appendChild(iconsSpan);

    return headerDiv;
  }

  private homePageAppBar(): HTMLDivElement {
    const appBarDiv = document.createElement("div");
    appBarDiv.style.padding = "8px";
    appBarDiv.className = "home-app-bar";

    // Logo section
    const logoDiv = document.createElement("div");
    logoDiv.className = "logo-added";

    const logoImg = document.createElement("img");
    logoImg.src = "/Resources/ComfortaLogo1.png";
    logoImg.style.height = "35px";

    logoDiv.appendChild(logoImg);

    // Profile section
    const profileDiv = document.createElement("div");
    profileDiv.className = "profile-section";
    profileDiv.style.display = "flex";

    // Create SVG element
    const svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");
    svg.setAttribute("width", "16");
    svg.setAttribute("height", "18");
    svg.setAttribute("viewBox", "0 0 19.422 21.363");

    const path = document.createElementNS("http://www.w3.org/2000/svg", "path");
    path.setAttribute("id", "Path_1327");
    path.setAttribute("data-name", "Path 1327");
    path.setAttribute(
      "d",
      "M15.711,5a6.8,6.8,0,0,0-3.793,12.442A9.739,9.739,0,0,0,6,26.364H7.942a7.769,7.769,0,1,1,15.537,0h1.942A9.739,9.739,0,0,0,19.5,17.442,6.8,6.8,0,0,0,15.711,5Zm0,1.942A4.855,4.855,0,1,1,10.855,11.8,4.841,4.841,0,0,1,15.711,6.942Z"
    );
    path.setAttribute("transform", "translate(-6 -5)");
    path.setAttribute("fill", "#fff");

    svg.appendChild(path);
    profileDiv.appendChild(svg);

    // Assemble the app bar
    appBarDiv.appendChild(logoDiv);
    appBarDiv.appendChild(profileDiv);

    return appBarDiv;
  }

  private otherPageAppBar(pageTitle: string = "Page Title"): HTMLDivElement {
    const appBarDiv = document.createElement("div");
    appBarDiv.className = "translate-app-bar";

    appBarDiv.innerHTML = `
      <h1 class="title ${this.isHomePage() ? "" : "editable-content"}" original-content="${pageTitle}" contenteditable="false" title="${pageTitle}" data-placeholder="Enter page title">${pageTitle}</h1>
    `;

    return appBarDiv;
  }

  private body(): HTMLDivElement {
    const frameContainer = document.createElement("div");
    const translationMapper = new TranslationMapper(this.data, this.pageId, this.language);
    const convertedHtml = translationMapper.convertToHTML();

    frameContainer.innerHTML = convertedHtml;
    return frameContainer;
  }

  private getCurrentTime(): string {
    const now = new Date();
    return now.toLocaleTimeString("en-US", {
      hour: "numeric",
      minute: "2-digit",
      hour12: true,
    });
  }

  private pageTitleEvents(): void {
    const pageTitle = this.getPageTitleElement();
    if (!pageTitle || this.isHomePage()) return;

    const editingState = this.createEditingState();
    const handlers = this.createEventHandlers(pageTitle, editingState);

    this.attachEventListeners(pageTitle, handlers);
  }

  private getPageTitleElement(): HTMLHeadingElement | null {
    return this.frame.querySelector(".title") as HTMLHeadingElement;
  }

  private isHomePage(): boolean {
    return this.data.PageName === "Home";
  }

  private createEditingState() {
    return {
      isEditing: false,
      outsideClickHandler: null as ((e: MouseEvent) => void) | null,
      originalContent: "",
    };
  }

  private createEventHandlers(pageTitle: HTMLHeadingElement, editingState: any) {
    const startEditing = () => {
      editingState.isEditing = true;
      editingState.originalContent =
        pageTitle.getAttribute("original-content") || pageTitle.textContent || "";

      this.setEditingMode(pageTitle, true);
      this.setupOutsideClickHandler(pageTitle, editingState, finishEditing);
    };

    const finishEditing = () => {
      if (!editingState.isEditing) return;

      editingState.isEditing = false;
      this.setEditingMode(pageTitle, false);

      const updatedTitle = this.getUpdatedTitle(pageTitle);
      this.savePageTitle(updatedTitle.toLocaleUpperCase());
      this.cleanupOutsideClickHandler(editingState);

      pageTitle.setAttribute("original-content", updatedTitle);
      pageTitle.setAttribute("title", updatedTitle.toLocaleUpperCase());
    };

    const cancelEditing = () => {
      if (!editingState.isEditing) return;

      pageTitle.textContent = editingState.originalContent;
      finishEditing();
    };

    return { startEditing, finishEditing, cancelEditing };
  }

  private setEditingMode(pageTitle: HTMLHeadingElement, isEditing: boolean): void {
    if (isEditing) {
      pageTitle.classList.add("editing");
      pageTitle.setAttribute("contenteditable", "true");
      pageTitle.focus();
    } else {
      pageTitle.classList.remove("editing");
      pageTitle.setAttribute("contenteditable", "false");
    }
  }

  private setupOutsideClickHandler(
    pageTitle: HTMLHeadingElement,
    editingState: any,
    finishEditing: () => void
  ): void {
    editingState.outsideClickHandler = (e: MouseEvent) => {
      if (editingState.isEditing && !pageTitle.contains(e.target as Node)) {
        finishEditing();
      }
    };

    // Delay to prevent immediate triggering
    setTimeout(() => {
      if (editingState.outsideClickHandler) {
        document.addEventListener("click", editingState.outsideClickHandler);
      }
    }, 100);
  }

  private cleanupOutsideClickHandler(editingState: any): void {
    if (editingState.outsideClickHandler) {
      document.removeEventListener("click", editingState.outsideClickHandler);
      editingState.outsideClickHandler = null;
    }
  }

  private getUpdatedTitle(pageTitle: HTMLHeadingElement): string {
    return pageTitle.textContent?.trim() || "";
  }

  private attachEventListeners(pageTitle: HTMLHeadingElement, handlers: any): void {
    const { startEditing, finishEditing, cancelEditing } = handlers;

    // Click to start editing
    pageTitle.addEventListener("click", (e: MouseEvent) => {
      e.stopPropagation();
      startEditing();
    });

    // Keyboard shortcuts
    pageTitle.addEventListener("keydown", (e: KeyboardEvent) => {
      switch (e.key) {
        case "Enter":
          e.preventDefault();
          finishEditing();
          break;
        case "Escape":
          e.preventDefault();
          cancelEditing();
          break;
      }
    });

    // Blur event as backup
    pageTitle.addEventListener("blur", () => {
      this.handleBlurEvent(finishEditing);
    });
  }

  private handleBlurEvent(finishEditing: () => void): void {
    setTimeout(() => {
      if (
        document.activeElement?.tagName !== "H1" ||
        !document.activeElement?.classList.contains("title")
      ) {
        finishEditing();
      }
    }, 100);
  }

  private savePageTitle(pageTitle: string): void {
    this.data.PageName = pageTitle;
    this.saveUpdatedData(this.data).catch((error) => {
      throw error;
    });
  }

  private async saveUpdatedData(data: TranslationStructure): Promise<void> {
    const autoSaveUI = this.getAutoSaveElements();
    if (!autoSaveUI) return;

    this.showAutoSaveStatus(autoSaveUI, "saving");

    try {
      const toolboxService = new ToolBoxService();
      const minDelay = 500;

      await Promise.all([
        toolboxService.updateTranslatedVersion(this.pageId, this.language, data),
        this.delay(minDelay),
      ]);

      this.showAutoSaveStatus(autoSaveUI, "saved");
    } catch (error) {
      this.showAutoSaveStatus(autoSaveUI, "error");
      throw error;
    } finally {
      setTimeout(() => {
        this.hideAutoSaveStatus(autoSaveUI);
      }, 1000);
    }
  }

  private getAutoSaveElements(): { saving: HTMLElement; saved: HTMLElement } | null {
    const saving = document.querySelector(".auto-saving-section-content-text") as HTMLElement;
    const saved = document.querySelector(".auto-saved-section-content-text") as HTMLElement;

    return saving && saved ? { saving, saved } : null;
  }

  private showAutoSaveStatus(
    autoSaveUI: { saving: HTMLElement; saved: HTMLElement },
    status: "saving" | "saved" | "error"
  ): void {
    // Hide all status elements first
    autoSaveUI.saving.style.display = "none";
    autoSaveUI.saved.style.display = "none";

    switch (status) {
      case "saving":
        autoSaveUI.saving.style.display = "flex";
        break;
      case "saved":
        autoSaveUI.saved.style.display = "flex";
        break;
      case "error":
        // You might want to show an error status element here
        console.error("Auto-save failed");
        break;
    }
  }

  private hideAutoSaveStatus(autoSaveUI: { saving: HTMLElement; saved: HTMLElement }): void {
    autoSaveUI.saving.style.display = "none";
    autoSaveUI.saved.style.display = "none";
  }

  private delay(ms: number): Promise<void> {
    return new Promise((resolve) => setTimeout(resolve, ms));
  }

  render(parent: HTMLDivElement) {
    parent.append(this.frame);
  }
}
