export class TranslationodeUIManager {
  public disableTranslationMode() {
    const iframes = document.querySelectorAll(
      ".mobile-frame iframe"
    ) as NodeListOf<HTMLIFrameElement>;
    if (!iframes.length) return;

    iframes.forEach((iframe) => {
      try {
        const iframeDoc = this.getIframeDocument(iframe);
        if (iframeDoc) {
          // Handle img tags
          const readOnlyTags = iframeDoc.querySelectorAll(
            ".readonly-mode"
          ) as NodeListOf<HTMLElement>;
          readOnlyTags?.forEach((tag: HTMLElement) => {
            tag.style.removeProperty("visibility");
          });
        }
      } catch (error) {
        console.error("Error processing iframe content:", error);
      }
    });
  }

  public enableTranslationMode() {
    const iframes = document.querySelectorAll(
      ".mobile-frame iframe"
    ) as NodeListOf<HTMLIFrameElement>;
    if (!iframes.length) return;

    iframes.forEach((iframe) => {
      try {
        const iframeDoc = this.getIframeDocument(iframe);
        if (iframeDoc) {
          // Handle img tags
          const readOnlyTags = iframeDoc.querySelectorAll(
            ".readonly-mode"
          ) as NodeListOf<HTMLElement>;
          readOnlyTags?.forEach((tag: HTMLElement) => {
            tag.style.visibility = "hidden";
          });
        }
      } catch (error) {
        console.error("Error processing iframe content:", error);
      }
    });
  }

  private getIframeDocument(iframe: HTMLIFrameElement): Document | null {
    try {
      return iframe.contentDocument || iframe.contentWindow?.document || null;
    } catch (error) {
      console.error("Error accessing iframe document:", error);
      return null;
    }
  }
}
