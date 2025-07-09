import { EditorEvents } from "../editor/EditorEvents";

export class TranslationodeUIManager {
  private static readonly MOBILE_FRAME_SELECTOR = ".mobile-frame iframe";
  private static readonly READONLY_MODE_SELECTOR = ".readonly-mode";
  private static readonly TRANSLATE_SECTION_ID = "translate-page-section";

  public disableTranslationMode(): void {
    const iframes = this.getMobileFrameIframes();
    if (!iframes.length) return;

    this.processIframes(iframes, this.showReadOnlyElements.bind(this));
  }

  public enableTranslationMode(): void {
    const iframes = this.getMobileFrameIframes();
    if (!iframes.length) return;

    this.processIframes(iframes, this.hideReadOnlyElements.bind(this));
  }

  public toggleSidebar(): void {
    const isTranslationMode = this.getTranslationModeState();
    const translateSection = this.getTranslateSectionElement();

    if (isTranslationMode && translateSection) {
      this.showTranslateSection(translateSection);
    } else {
      this.hideTranslateSection(translateSection);
    }
  }

  private getMobileFrameIframes(): NodeListOf<HTMLIFrameElement> {
    return document.querySelectorAll(
      TranslationodeUIManager.MOBILE_FRAME_SELECTOR
    ) as NodeListOf<HTMLIFrameElement>;
  }

  private processIframes(
    iframes: NodeListOf<HTMLIFrameElement>,
    elementProcessor: (elements: NodeListOf<HTMLElement>) => void
  ): void {
    iframes.forEach((iframe) => {
      try {
        const iframeDoc = this.getIframeDocument(iframe);
        if (iframeDoc) {
          const readOnlyTags = this.getReadOnlyElements(iframeDoc);
          if (readOnlyTags) {
            elementProcessor(readOnlyTags);
          }
        }
      } catch (error) {
        this.handleIframeError(error);
      }
    });
  }

  private getReadOnlyElements(document: Document): NodeListOf<HTMLElement> {
    return document.querySelectorAll(
      TranslationodeUIManager.READONLY_MODE_SELECTOR
    ) as NodeListOf<HTMLElement>;
  }

  private showReadOnlyElements(elements: NodeListOf<HTMLElement>): void {
    elements.forEach((element: HTMLElement) => {
      element.style.removeProperty("visibility");
    });
  }

  private hideReadOnlyElements(elements: NodeListOf<HTMLElement>): void {
    elements.forEach((element: HTMLElement) => {
      element.style.visibility = "hidden";
    });
  }

  private handleIframeError(error: unknown): void {
    if (this.shouldRethrowError()) {
      throw error;
    }
  }

  private shouldRethrowError(): boolean {
    // This mimics the original logic where enableTranslationMode throws errors
    // while disableTranslationMode catches them
    return true;
  }

  private getIframeDocument(iframe: HTMLIFrameElement): Document | null {
    try {
      return iframe.contentDocument || iframe.contentWindow?.document || null;
    // eslint-disable-next-line no-unused-vars
    } catch (error) {
      return null;
    }
  }

  private getTranslationModeState(): boolean {
    return (globalThis as any).isTranslationMode;
  }

  private getTranslateSectionElement(): HTMLDivElement | null {
    return document.getElementById(TranslationodeUIManager.TRANSLATE_SECTION_ID) as HTMLDivElement;
  }

  private showTranslateSection(translateSection: HTMLDivElement): void {
    translateSection.style.display = "block";
    this.getEditorEvents().hidePageInfo();
  }

  private hideTranslateSection(translateSection: HTMLDivElement | null): void {
    if (translateSection) {
      translateSection.style.display = "none";
      this.resetSidebarWidth();
    }
    this.showPageInfo();
  }

  private resetSidebarWidth(): void {
    const sidebar = document.querySelector("#tb-sidebar") as HTMLDivElement;
    if (sidebar) sidebar.style.width = sidebar.clientWidth - 70 + "px";
    sidebar.style.transition = "width 0.3s ease";
  }

  private showPageInfo(): void {
    const pageTitle = document.getElementById("page-info-title") as HTMLDivElement;
    const pageInfo = document.getElementById("page-info-section") as HTMLDivElement;
    if (pageTitle) {
      pageTitle.style.display = "block";
    }
    if (pageInfo) {
      pageInfo.style.display = "block";
    }
  }

  private getEditorEvents(): EditorEvents {
    return new EditorEvents();
  }
}
