import { PageBubbleTree } from "../page-tree/PageBubbleTree";
import { EditorUIManager } from "../../../controls/editor/EditorUiManager";
export class TreeViewSection {
  container: HTMLElement;
  sectionTree!: HTMLElement;

  constructor() {
    this.container = document.createElement("div") as HTMLElement;
    this.init();
  }

  init() {
    this.container.id = "tree-view-section";
    this.container.className = "sidebar-section tree-view-section";

    this.sectionTree = document.createElement("div");
    this.sectionTree.id = "section-tree";
    this.sectionTree.className = "section-tree";

    // Create tree container
    const treeContainer = document.createElement("div");
    treeContainer.className = "tree-container";
    treeContainer.id = "tree-container";

    // Add container to DOM FIRST - this is crucial!

    // treeContainer.innerHTML = "<svg></svg>";

    this.sectionTree.appendChild(treeContainer);
    this.container.appendChild(this.sectionTree);

    // Add maximize SVG icon
    const svgWrapper = document.createElement("div");
    svgWrapper.className = "section-tree-maximize";
    svgWrapper.innerHTML = `
    <svg version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
      viewBox="0 0 489.3 489.3" style="enable-background:new 0 0 489.3 489.3;" xml:space="preserve">
      <g>
        <g>
          <path d="M476.95,0H12.35c-6.8,0-12.2,5.5-12.2,12.2V235c0,6.8,5.5,12.2,12.2,12.2s12.3-5.5,12.3-12.2V24.5h440.2v440.2h-211.9
            c-6.8,0-12.3,5.5-12.3,12.3s5.5,12.3,12.3,12.3h224c6.8,0,12.3-5.5,12.3-12.3V12.3C489.25,5.5,483.75,0,476.95,0z"/>
          <path d="M0.05,476.9c0,6.8,5.5,12.3,12.2,12.3h170.4c6.8,0,12.3-5.5,12.3-12.3V306.6c0-6.8-5.5-12.3-12.3-12.3H12.35
            c-6.8,0-12.2,5.5-12.2,12.3v170.3H0.05z M24.55,318.8h145.9v145.9H24.55V318.8z"/>
          <path d="M222.95,266.3c2.4,2.4,5.5,3.6,8.7,3.6s6.3-1.2,8.7-3.6l138.6-138.7v79.9c0,6.8,5.5,12.3,12.3,12.3s12.3-5.5,12.3-12.3
            V98.1c0-6.8-5.5-12.3-12.3-12.3h-109.5c-6.8,0-12.3,5.5-12.3,12.3s5.5,12.3,12.3,12.3h79.9L222.95,249
            C218.15,253.8,218.15,261.5,222.95,266.3z"/>
        </g>
      </g>
    </svg>
  `;

    svgWrapper.addEventListener("click", (e) => {
      e.preventDefault();
      const pageBubbleTree = new PageBubbleTree(
        (globalThis as any).currentPageId
      );
      pageBubbleTree.show();
    });

    this.sectionTree.appendChild(svgWrapper);
  }

  render(container: HTMLElement) {
    container.appendChild(this.container);

    const pageBubbleTree = new PageBubbleTree(
      (globalThis as any).currentPageId
    );
    pageBubbleTree.intializePreviewTree();
  }

  //refresh container to render the tree view
  refresh() {
    // Remove all children from the container
    while (this.container.firstChild) {
      this.container.removeChild(this.container.firstChild);
    }

    this.container.id = "tree-view-section";
    this.container.className = "sidebar-section tree-view-section";
    // Re-initialize the section
    this.init();

    const pageBubbleTree = new PageBubbleTree(
      (globalThis as any).currentPageId
    );
    pageBubbleTree.intializePreviewTree();
  }
}
