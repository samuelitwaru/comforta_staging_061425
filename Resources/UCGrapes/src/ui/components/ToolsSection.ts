import { TabPageContent } from "./TabPageContent";


export class ToolsSection {
  container: HTMLElement;
  pagesTabContent: TabPageContent | undefined;
  constructor() {
    this.container = document.getElementById("tools-section") as HTMLElement;
    this.init();
  }

  init() {
    this.pagesTabContent = new TabPageContent();

    this.pagesTabContent.render(this.container);

    (window as any).app.toolsSection = this
  }

  render(container: HTMLElement) {
    container.appendChild(this.container);
  }
}
