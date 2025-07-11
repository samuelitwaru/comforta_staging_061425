import { PageBubbleTree } from "../page-tree/PageBubbleTree";
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

    const hr = document.createElement("hr");
    this.sectionTree = document.createElement("div");
    this.sectionTree.id = "section-tree";
    this.sectionTree.className = "section-tree";

    // Create tree container
    const treeContainer = document.createElement("div");
    treeContainer.className = "tree-container";
    treeContainer.id = "tree-container";

    // Add container to DOM FIRST - this is crucial!

    // treeContainer.innerHTML = "<svg></svg>";

    this.container.appendChild(hr);
    this.sectionTree.appendChild(treeContainer);
    this.container.appendChild(this.sectionTree);

    // Add maximize SVG icon
    const svgWrapper = document.createElement("div");
    svgWrapper.className = "section-tree-maximize";
    svgWrapper.innerHTML = `
      
    <svg xmlns="http://www.w3.org/2000/svg" width="17.333" height="17.333" viewBox="0 0 17.333 17.333">
      <path id="Group_2526-converted" data-name="Group 2526-converted" d="M.7.372a.607.607,0,0,0-.34.346A10.144,10.144,0,0,0,.3,3.155C.3,4.807.312,5.5.337,5.6a.748.748,0,0,0,.427.452.655.655,0,0,0,.666-.155c.216-.2.21-.161.211-1.822V2.581L3.809,4.742c2.3,2.294,2.228,2.231,2.5,2.231a.7.7,0,0,0,.665-.663c0-.273.065-.2-2.231-2.5L2.581,1.642H4.07c1.661,0,1.617,0,1.822-.211A.655.655,0,0,0,5.711.382L5.588.317,3.22.309.853.3.7.372M12.394.329a.655.655,0,0,0-.324,1.125c.2.19.171.187,1.8.187h1.482L13.195,3.809c-2.294,2.3-2.231,2.228-2.231,2.5a.7.7,0,0,0,.663.665c.273,0,.2.065,2.5-2.231L16.3,2.581V4.04c0,.937.012,1.5.032,1.573a.788.788,0,0,0,.37.411.717.717,0,0,0,.537,0,.75.75,0,0,0,.368-.435c.023-.09.033-.851.033-2.433V.853L17.564.7a.6.6,0,0,0-.345-.34A10.011,10.011,0,0,0,14.792.305c-1.262,0-2.34.012-2.4.024m-6.3,10.679a1.229,1.229,0,0,1-.133.044c-.008,0-.983.969-2.167,2.153L1.642,15.356V13.868c0-1.678.006-1.623-.229-1.836a.6.6,0,0,0-.51-.165.675.675,0,0,0-.57.494c-.019.067-.03.96-.03,2.416v2.308l.071.148a.6.6,0,0,0,.345.34,10.144,10.144,0,0,0,2.437.061c1.583,0,2.343-.009,2.433-.032a.75.75,0,0,0,.435-.368.717.717,0,0,0,0-.537.788.788,0,0,0-.411-.37c-.073-.02-.636-.032-1.573-.032H2.581l2.162-2.167c2.3-2.3,2.231-2.228,2.231-2.5a.758.758,0,0,0-.172-.434.7.7,0,0,0-.707-.185m5.339,0a.671.671,0,0,0-.435.835,20.84,20.84,0,0,0,2.2,2.289l2.162,2.167H13.9c-.937,0-1.5.012-1.573.032a.735.735,0,0,0-.235.141.654.654,0,0,0-.2.705.748.748,0,0,0,.452.427c.1.025.788.035,2.44.034a10.144,10.144,0,0,0,2.437-.061.6.6,0,0,0,.345-.34l.071-.148v-2.3c0-1.665-.01-2.34-.035-2.441a.755.755,0,0,0-.431-.45.65.65,0,0,0-.7.2.735.735,0,0,0-.141.235c-.02.073-.032.637-.032,1.573v1.46l-2.137-2.134c-1.175-1.174-2.181-2.156-2.235-2.183A.7.7,0,0,0,11.434,11" transform="translate(-0.302 -0.301)" fill="#3c3c3c" fill-rule="evenodd"/>
    </svg>
  `;

    svgWrapper.addEventListener("click", (e) => {
      e.preventDefault();
      const pageBubbleTree = new PageBubbleTree((globalThis as any).currentPageId);
      pageBubbleTree.show();
    });

    this.sectionTree.appendChild(svgWrapper);
  }

  render(container: HTMLElement) {
    container.appendChild(this.container);
    this.updateTreeViewSectionTop();

    const pageBubbleTree = new PageBubbleTree((globalThis as any).currentPageId);
    pageBubbleTree.intializePreviewTree();

    // Also update on window resize/scroll
    window.addEventListener('resize', () => this.updateTreeViewSectionTop());
    window.addEventListener('scroll', () => this.updateTreeViewSectionTop());
  }

  updateTreeViewSectionTop() {
    const activeEditor = document.querySelector('.active-editor');
    const treeViewSection = document.querySelector('.tree-view-section');
    if (activeEditor && treeViewSection) {
      const rect = activeEditor.getBoundingClientRect();
      // Calculate the bottom position relative to the viewport, then add scroll offset
      const topPx = rect.height;
      (treeViewSection as HTMLElement).style.top = `${topPx+30}px`;
    }
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

    const pageBubbleTree = new PageBubbleTree((globalThis as any).currentPageId);
    pageBubbleTree.intializePreviewTree();
  }
}
