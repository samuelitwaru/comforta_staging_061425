import { AppConfig } from "../../../AppConfig";
import { ThemeManager } from "../../../controls/themes/ThemeManager";
import { PageTreeRendererInfoPage } from "./PageTreeRendererInfoPage";

interface PageNode {
  id: string;
  title: string;
  structure: string;
  thumbnail: string;
  children: string[]; // recursive type for nested structure
  x: Number;
  y: Number;
}

export class PageBubbleTree {
  sampleData: any;
  link: any;
  node: any;
  simulation: any;
  simulationActive: boolean | undefined;
  d3: any;
  pages: any;
  themeManager: ThemeManager;
  processedPages!: { id: string; title: string; children: string[] }[]; // Fixed type to match actual usage
  nodes!: any[];
  links!: { source: string; target: string }[]; // Fixed type to match actual usage
  svg: any;
  width: number = 1000;
  height: number = 1000;
  selfLinks: { source: string; target: string }[] = []; // Fixed type to match actual usage
  normalLinks: { source: string; target: string }[] = []; // Fixed type to match actual usage
  container: any;
  selfArcs: any;
  arrows: any;
  graphContainer!: HTMLDivElement;
  treeContainer!: HTMLDivElement;
  sectionTreeMinimize!: HTMLDivElement;
  treeFeatures!: HTMLDivElement;

  zoom: any;

  PageTreeRendererInfoPage: PageTreeRendererInfoPage;
  primaryNodeId: string | null = null; // Fixed type to string
  appVersionManager: any;
  navigationHistory: { id: string; name: string }[] = [];
  parentNodeId: string | null = null;
  mainContainer!: HTMLDivElement;
  sectionAllPages!: HTMLDivElement;

  constructor(primaryNodeId?: string) {
    this.PageTreeRendererInfoPage = new PageTreeRendererInfoPage();
    const config = AppConfig.getInstance();
    this.d3 = config.UC.d3;
    this.themeManager = new ThemeManager();
    const appVersionManager = this.themeManager.appVersionManager;
    this.appVersionManager = appVersionManager;
    this.pages = appVersionManager.getPages();
    this.processedPages = this.processPageData(this.pages);
    const homePage = this.processedPages.find((page) => page.title === "Home");

    if (homePage) {
      //get page trail
      const pageTrail = (globalThis as any).activePages;
      // console.log("pageTrail)", pageTrail);

      //get pageids from the trail
      const pageIdsOnly = Array.isArray(pageTrail)
        ? pageTrail.filter((item: any) => item && item.pageId).map((item: any) => item.pageId)
        : [];
      // console.log("pageIdsOnly", pageIdsOnly);

      this.primaryNodeId = homePage.id;
      this.navigationHistory = [{ id: homePage.id, name: homePage.title }];

      // If a different primaryNodeId is provided, trace path from Home to that node
      if (primaryNodeId && primaryNodeId !== homePage.id) {
        // Try to find a path that matches the pageIdsOnly sequence
        let path: string[] | null = null;
        if (
          pageIdsOnly.length > 1 &&
          pageIdsOnly[0] === homePage.id &&
          pageIdsOnly[pageIdsOnly.length - 1] === primaryNodeId
        ) {
          // If the pageIdsOnly path starts with homePage and ends with primaryNodeId, use it
          path = pageIdsOnly;
        } else {
          // Otherwise, use the DFS path
          path = this.findPathFromHome(homePage.id, primaryNodeId);
          // alert("no path");
        }

        if (path && path.length > 1) {
          // Build navigation history from Home to the target node
          this.navigationHistory = path.map((id) => {
            const page = this.processedPages.find((p) => p.id === id);
            return { id, name: page ? page.title : id };
          });
          this.primaryNodeId = primaryNodeId;
          const targetNode = this.processedPages.find((p) => p.id === primaryNodeId);
          if (targetNode) {
            this.updateNodeDisplay(targetNode);
            return;
          }
        }
      }
      // Default: just show Home
      this.updateNodeDisplay(homePage);
    }
  }

  // Helper to find path from Home to target node (DFS)
  findPathFromHome(startId: string, targetId: string): string[] | null {
    const visited = new Set<string>();
    const path: string[] = [];

    const dfs = (currentId: string): boolean => {
      visited.add(currentId);
      path.push(currentId);
      if (currentId === targetId) return true;
      const current = this.processedPages.find((p) => p.id === currentId);
      if (current && current.children) {
        for (const childId of current.children) {
          if (!visited.has(childId)) {
            if (dfs(childId)) return true;
          }
        }
      }
      path.pop();
      return false;
    };

    return dfs(startId) ? path : null;
  }

  refreshPages() {
    // console.log("Refreshing pages...");

    this.pages = this.appVersionManager.getPages();
    this.processedPages = this.processPageData(this.pages);
    // console.log("Processed Pages:", this.processedPages);
  }

  intializePreviewTree() {
    this.refreshPages();
    this.treeContainer = this.build2();
    this.buildPreviewTree();
  }

  hide() {
    const editorSections = document.getElementsByClassName("editor-main-section");
    const toolSection = document.getElementById("tools-section") as HTMLDivElement;
    const treeSection = document.getElementById("tree-view-section") as HTMLDivElement;
    const menuPageSection = document.getElementById("menu-page-section") as HTMLDivElement;
    const contentPageSection = document.getElementById("content-page-section") as HTMLDivElement;

    if (editorSections.length > 0) {
      // toggle display
      const div = editorSections[0] as HTMLDivElement;
      div.style.display = "block";
      this.graphContainer.style.display = "none";
      menuPageSection.style.display = "none";
      contentPageSection.style.display = "none";
      toolSection.style.display = "block";
      treeSection.style.display = "block";
      this.mainContainer.style.background = "#6a747f";
      this.treeFeatures.style.visibility = "hidden";
    }
  }
  show() {
    this.refreshPages();

    this.graphContainer = this.build();
    this.buildTree();

    const editorSections = document.getElementsByClassName("editor-main-section");
    const toolSection = document.getElementById("tools-section") as HTMLDivElement;
    const treeSection = document.getElementById("tree-view-section") as HTMLDivElement;

    // Hide editor sections and tool/tree sections, show graphContainer
    if (editorSections.length > 0) {
      const div = editorSections[0] as HTMLDivElement;
      div.style.display = "none";
      this.graphContainer.style.display = "block";
      this.graphContainer.style.width = "100%";
      this.graphContainer.style.height = "100%";
      toolSection.style.display = "none";
      treeSection.style.display = "none";
      this.treeFeatures.style.visibility = "visible";
    }
  }

  build() {
    this.mainContainer = document.getElementById("main-content") as HTMLDivElement;

    if (!this.mainContainer) {
      // console.error("Main content container not found");
      return document.createElement("div");
    }

    //add style to mainContainer
    this.mainContainer.style.background = "#E9EBF0";

    this.graphContainer = document.getElementById("graph-container-1") as HTMLDivElement;

    if (!this.graphContainer) {
      this.graphContainer = document.createElement("div");
      this.graphContainer.id = "graph-container-1";
    }

    // Clear any existing content
    this.graphContainer.innerHTML = ""; // Clear existing content
    this.graphContainer.innerHTML = "<svg></svg>";
    this.mainContainer.appendChild(this.graphContainer);

    this.treeFeatures = document.getElementById("tree-features") as HTMLDivElement;
    if (!this.treeFeatures) {
      // Create tree features container if it doesn't exist
      this.treeFeatures = document.createElement("div");
      this.treeFeatures.id = "tree-features";
      this.treeFeatures.className = "tree-features";
    }

    this.sectionTreeMinimize = document.getElementById("section-tree-minimize") as HTMLDivElement;
    if (!this.sectionTreeMinimize) {
      this.sectionTreeMinimize = document.createElement("div");
      this.sectionTreeMinimize.id = "section-tree-minimize";
      this.sectionTreeMinimize.className = "section-tree-items";
      this.sectionTreeMinimize.title = "Minimize Tree";
      this.sectionTreeMinimize.innerHTML = `
    <svg xmlns="http://www.w3.org/2000/svg" width="19.483" height="19.482" viewBox="0 0 19.483 19.482">
      <path id="Group_2527-converted" data-name="Group 2527-converted" d="M18.914.334a.862.862,0,0,0-.2.066c-.047.023-1.393,1.35-2.993,2.949l-2.91,2.9V4.108c0-1.449-.012-2.19-.037-2.28a.819.819,0,0,0-.529-.486.745.745,0,0,0-.854.385l-.072.134v6.4l.074.139a.769.769,0,0,0,.419.362,23.639,23.639,0,0,0,3.3.045L18.26,8.8l.139-.075a.758.758,0,0,0,.377-.9.914.914,0,0,0-.489-.483c-.084-.024-.864-.036-2.274-.036H13.867L16.773,4.4c1.6-1.6,2.933-2.962,2.966-3.026a.765.765,0,0,0,.062-.321.55.55,0,0,0-.1-.368.757.757,0,0,0-.787-.352m-17,11a.7.7,0,0,0-.533.439.682.682,0,0,0,.16.809.756.756,0,0,0,.29.193c.091.025.814.037,2.28.037H6.254L3.348,15.72C1.75,17.32.415,18.682.382,18.746a.765.765,0,0,0-.062.321.718.718,0,0,0,.366.634.55.55,0,0,0,.368.1.765.765,0,0,0,.321-.062c.064-.033,1.426-1.368,3.026-2.966l2.91-2.906v2.146c0,1.466.012,2.189.037,2.28a.888.888,0,0,0,.482.483.756.756,0,0,0,.9-.377L8.8,18.26l.009-3.152a23.639,23.639,0,0,0-.045-3.3.769.769,0,0,0-.362-.419l-.139-.074-3.118-.005c-1.716,0-3.172.006-3.237.019" transform="translate(-0.32 -0.321)" fill="#7c8791" fill-rule="evenodd"/>
    </svg>
  `;
      this.sectionTreeMinimize.addEventListener("click", (e) => {
        e.preventDefault();
        this.hide();
      });
    }

    this.sectionAllPages = document.getElementById("section-all-pages") as HTMLDivElement;
    if (!this.sectionAllPages) {
      this.sectionAllPages = document.createElement("div");
      this.sectionAllPages.id = "section-all-pages";
      this.sectionAllPages.className = "section-tree-items";
      this.sectionAllPages.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" width="19.48" height="19.48" viewBox="0 0 19.48 19.48">
          <path id="overview" d="M1.34.049A1.865,1.865,0,0,0,.2.928C0,1.318,0,1.265,0,4.256,0,7.208,0,7.143.185,7.532A2.195,2.195,0,0,0,.9,8.274c.432.229.27.219,3.353.219H7.03l.232-.073A1.81,1.81,0,0,0,8.42,7.259c.072-.228.072-.231.072-3,0-3.084.01-2.922-.219-3.354a2.141,2.141,0,0,0-.75-.716C7.145,0,7.139,0,4.221,0,2.094,0,1.5.014,1.34.049m11.012,0a1.6,1.6,0,0,0-.807.444,1.7,1.7,0,0,0-.493.791,17.676,17.676,0,0,0-.06,2.972c0,2.773,0,2.776.072,3A1.81,1.81,0,0,0,12.222,8.42l.232.073h2.776a17.635,17.635,0,0,0,2.97-.06,1.637,1.637,0,0,0,.722-.421,1.745,1.745,0,0,0,.472-.692l.073-.192.01-2.784c.01-3.079.014-3.019-.2-3.416A2.092,2.092,0,0,0,18.55.2c-.38-.2-.366-.2-3.321-.2-2.1,0-2.721.011-2.878.045M6.913,1.572l.068.062V4.243c0,2.534,0,2.611-.062,2.672a.424.424,0,0,1-.2.083c-.078.011-1.247.016-2.6.011L1.658,7l-.074-.074L1.51,6.851,1.5,4.294c-.007-1.789,0-2.582.026-2.642a.266.266,0,0,1,.106-.12c.049-.023.88-.032,2.641-.028,2.478.006,2.573.008,2.639.068M17.84,1.531a.27.27,0,0,1,.116.122c.025.059.033.857.026,2.641l-.008,2.557-.074.074L17.826,7l-2.459.01c-1.353,0-2.522,0-2.6-.011a.424.424,0,0,1-.2-.083c-.061-.061-.062-.138-.062-2.672a12.422,12.422,0,0,1,.056-2.658.424.424,0,0,1,.106-.068c.027-.01,1.184-.019,2.572-.02,1.811,0,2.546.007,2.6.034M1.2,11.083a2.093,2.093,0,0,0-.381.181,2.185,2.185,0,0,0-.636.693C0,12.342,0,12.28,0,15.23c0,2.991,0,2.938.2,3.328a2.106,2.106,0,0,0,.725.724c.4.211.337.207,3.415.2l2.784-.01L7.32,19.4a1.745,1.745,0,0,0,.691-.472,1.638,1.638,0,0,0,.421-.722,17.642,17.642,0,0,0,.06-2.971V12.455l-.073-.232a1.827,1.827,0,0,0-1.242-1.178c-.095-.022-1.133-.034-2.955-.034H1.413l-.212.072m11.093-.037a1.844,1.844,0,0,0-1.229,1.177l-.073.232v2.776a17.642,17.642,0,0,0,.06,2.971,1.638,1.638,0,0,0,.421.722,1.745,1.745,0,0,0,.691.472l.192.073,2.784.01c3.078.01,3.018.014,3.415-.2a2.1,2.1,0,0,0,.725-.725c.211-.4.207-.337.2-3.416l-.01-2.784-.072-.19a1.607,1.607,0,0,0-.381-.6,1.831,1.831,0,0,0-.757-.491,16.118,16.118,0,0,0-3.022-.061c-1.582,0-2.869.016-2.94.033M6.917,12.569c.063.063.064.108.064,2.676v2.612l-.085.068c-.085.066-.1.067-2.629.067-1.821,0-2.566-.01-2.624-.037a.27.27,0,0,1-.116-.122c-.025-.059-.033-.857-.026-2.639.008-2.459.011-2.556.07-2.622l.062-.068H4.242c2.566,0,2.611,0,2.675.065m10.995,0c.059.066.062.163.07,2.622.007,1.782,0,2.58-.026,2.639a.27.27,0,0,1-.116.122c-.058.027-.8.037-2.624.037-2.524,0-2.544,0-2.629-.067l-.085-.068V15.245c0-2.568,0-2.613.065-2.676s.108-.065,2.674-.065H17.85l.062.068" transform="translate(0 -0.003)" fill="#7c8791" fill-rule="evenodd"/>
        </svg>
        `;
      this.sectionAllPages.addEventListener("click", (e) => {
        e.preventDefault();
        // Exclude MyActivity, Calendar, Map, Maps from those that are not connected to
        const excludedTypes = ["MyActivity", "My Activity", "Calendar", "Map", "Maps"];

        // Find all connected page IDs
        const connectedIds = new Set<string>();
        this.processedPages.forEach((page: any) => {
          (page.children || []).forEach((childId: string) => connectedIds.add(childId));
        });

        // Always include pages that are connected to, or are not of excluded types
        const filteredPages = this.processedPages.filter((page: any) => {
          if (connectedIds.has(page.id)) return true;
          return !excludedTypes.includes(page.title) && !excludedTypes.includes(page.PageType);
        });

        this.nodes = this.createNodes(filteredPages);
        this.links = this.createLinks(filteredPages);
        this.buildTree();
      });
    }

    this.treeFeatures.appendChild(this.sectionTreeMinimize);
    this.treeFeatures.appendChild(this.sectionAllPages);

    this.mainContainer.appendChild(this.treeFeatures);
    this.graphContainer.setAttribute("style", "display:block;width:100%;");

    return this.graphContainer;
  }

  build2() {
    // console.log("Build2");
    const TreeSection = document.getElementById("section-tree") as HTMLDivElement;

    if (!TreeSection) {
      // console.error("Main content container not found");
      return document.createElement("div");
    }

    this.treeContainer = document.getElementById("tree-container") as HTMLDivElement;

    if (!this.treeContainer) {
      this.treeContainer = document.createElement("div");
      this.treeContainer.id = "tree-container";
    }

    // Clear any existing content
    this.treeContainer.innerHTML = ""; // Clear existing content
    this.treeContainer.innerHTML = "<svg></svg>";

    TreeSection.appendChild(this.treeContainer);
    // this.treeContainer.setAttribute("style", "display:block;width:100%;");

    return this.treeContainer;
  }

  processPageData(pages: any[]) {
    const linkPages: PageNode[] = [];
    pages = pages.map((page: any) => {
      const ret: PageNode = {
        id: page.PageId,
        title: page.PageName,
        structure: "",
        thumbnail: page.PageThumbnailUrl,
        children: [],
        x: 0,
        y: 0,
      };

      if (page.PageType === "Information") {
        if (page.PageInfoStructure.InfoContent) {
          ret.structure = this.PageTreeRendererInfoPage.createInfoHTML(page);
          page.PageInfoStructure.InfoContent.forEach((row: any) => {
            if (row.InfoType === "TileGrid" && row.Columns) {
              row.Columns.forEach((column: any) => {
                // console.log("column", column);
                column.Tiles.forEach((tile: any) => {
                  if (tile.Action.ObjectId) {
                    ret.children.push(tile.Action.ObjectId);
                  } else if (row.InfoType === "Cta") {
                    // console.log("row.CtaAttributes", row.CtaAttributes);

                    if (
                      row.CtaAttributes.CtaType === "Form" ||
                      row.CtaAttributes.CtaType === "WebLink"
                    ) {
                      const title =
                        row.CtaAttributes.CtaType === "Form" ? "Dynamic Form" : "Web Link";

                      linkPages.push({
                        id: row.CtaAttributes.Action.ObjectId,
                        title: title,
                        structure: "",
                        thumbnail: page.PageThumbnailUrl,
                        children: [],
                        x: 0,
                        y: 0,
                      });
                      ret.children.push(row.CtaAttributes.Action?.ObjectId);
                    }
                  }
                });
              });
            }
            if (row.InfoType === "TileRow") {
              row.Tiles.forEach((tile: any) => {
                // if (
                //   tile.Action.ObjectType == "DynamicForm" ||
                //   tile.Action.ObjectType == "WebLink"
                // ) {
                //   const title =
                //     tile.Action.ObjectType == "DynamicForm"
                //       ? "Dynamic Form"
                //       : "Web Link";
                //   linkPages.push({
                //     id: tile.Action.ObjectId,
                //     title: title,
                //     structure: "",
                //     thumbnail: page.PageThumbnailUrl,
                //     children: [],
                //     x: 0,
                //     y: 0,
                //   });
                //   ret.children.push(tile.Action.ObjectId);
                // } else if (
                //   tile.Action.ObjectId &&
                //   tile.Action.ObjectType !== ""
                // ) {
                //   if (
                //     this.pages.some(
                //       (page: any) => page.PageId === tile.Action.ObjectId
                //     )
                //   ) {
                //     ret.children.push(tile.Action.ObjectId);
                //   }
                // }

                if (tile.Action.ObjectId) {
                  ret.children.push(tile.Action.ObjectId);
                }
              });
            } else if (row.InfoType === "Cta") {
              // console.log("row.CtaAttributes", row.CtaAttributes);

              if (row.CtaAttributes.CtaType === "Form" || row.CtaAttributes.CtaType === "WebLink") {
                const title = row.CtaAttributes.CtaType === "Form" ? "Dynamic Form" : "Web Link";

                linkPages.push({
                  id: row.CtaAttributes.Action.ObjectId,
                  title: title,
                  structure: "",
                  thumbnail: page.PageThumbnailUrl,
                  children: [],
                  x: 0,
                  y: 0,
                });
                ret.children.push(row.CtaAttributes.Action?.ObjectId);
              }
            }
          });
        }
      } else if (page.PageType === "Calendar") {
        ret.structure = this.PageTreeRendererInfoPage.createAgendaHTML(page);
      } else if (page.PageType === "MyActivity") {
        ret.structure = this.PageTreeRendererInfoPage.createMyActivityHTML(page);
      } else if (page.PageType === "Map") {
        ret.structure = this.PageTreeRendererInfoPage.createMapHTML(page);
      }
      return ret;
    });

    return pages.concat(linkPages);
  }

  createNodes(processedPages: any[] = this.processedPages) {
    return processedPages.map((p) => {
      const validChildren = p.children.filter((childId: string) =>
        processedPages.some((page: any) => page.id === childId)
      );
      const totalChildCount = p.children.filter((childId: string) =>
        this.processedPages.some((page: any) => page.id === childId)
      ).length;
      return {
        id: p.id,
        name: p.title,
        children: p.children,
        structure: p.structure,
        thumbnail: p.thumbnail,
        childCount: validChildren.length,
        totalChildCount,
      };
    });
  }

  createLinks(processedPages: any[] = this.processedPages) {
    // console.log("processedPages", processedPages);
    return processedPages.flatMap((p) =>
      p.children
        .filter((childId: string) => processedPages.some((page: any) => page.id === childId))
        .map((childId: string) => ({
          source: p.id,
          target: childId,
        }))
    );
  }

  buildPreviewTree() {
    this.width = window.innerWidth;
    this.height = window.innerHeight;

    // Clear existing SVG content first to avoid duplications
    this.svg = this.d3
      .select("#tree-container")
      .select("svg")
      .html("") // Clear existing content
      .attr("viewBox", [0, 0, this.width, this.height])
      .attr("preserveAspectRatio", "xMidYMid meet");

    this.container = this.svg.append("g");
    this.splitLinks();
    this.forceSimulation();
    this.createNormalLinks();
    this.createLinkArrows();
    this.createSelfArcs();
    this.createCircularNodes();
    this.onTick();
    this.panAndZoom();

  }

  buildTree() {
    this.width = window.innerWidth;
    this.height = window.innerHeight;

    // Clear existing SVG content first to avoid duplications
    this.svg = this.d3
      .select("#graph-container-1")
      .select("svg")
      .html("") // Clear existing content
      .attr("viewBox", [0, 0, this.width, this.height])
      .attr("preserveAspectRatio", "xMidYMid meet");

    this.container = this.svg.append("g");
    this.splitLinks();
    this.forceSimulation();
    this.createNormalLinks();
    this.createLinkArrows();
    this.createSelfArcs();
    this.createCircularNodes();
    this.onTick();
    this.panAndZoom();
  }

  splitLinks() {
    this.selfLinks = this.links.filter((d) => d.source === d.target);
    this.normalLinks = this.links.filter((d) => d.source !== d.target);
  }

  forceSimulation() {
    this.simulation = this.d3
      .forceSimulation(this.nodes)
      .force(
        "link",
        this.d3
          .forceLink(this.normalLinks)
          .id((d: any) => d.id)
          .distance(300)
      )
      .force("charge", this.d3.forceManyBody().strength(-4000))
      .force("center", this.d3.forceCenter(this.width / 2, this.height / 2.2));
  }

  createNormalLinks() {
    // Normal links (lines)
    this.link = this.container
      .append("g")
      .attr("stroke", "#222F54")
      .attr("stroke-opacity", 0.6)
      .selectAll("line")
      .data(this.normalLinks)
      .join("line")
      .attr("stroke-width", 1.0)
      .style("cursor", "pointer"); // Make it look clickable
    // .on("click", (event: any, d: any) => {
    //   // const editorManager = new EditorManager();
    //   // editorManager.currentPage(d.source.id);
    //   // alert(
    //   //   `Parent (source): ${d.source.id}\nChild (target): ${d.target.id}`
    //   // );
    // });
  }

  createLinkArrows() {
    // Arrow marker definition
    this.svg
      .append("defs")
      .append("marker")
      .attr("id", "arrow")
      .attr("viewBox", "0 -5 10 10")
      .attr("refX", 5)
      .attr("refY", 0)
      .attr("markerWidth", 10)
      .attr("markerHeight", 10)
      .attr("orient", "auto")
      .append("path")
      .attr("d", "M0,-5L10,0L0,5")
      .attr("fill", "#222F54");

    // Arrows at midpoint
    this.arrows = this.container
      .append("g")
      .selectAll("path")
      .data(this.normalLinks)
      .join("path")
      .attr("fill", "#222F54")
      .attr("marker-end", "url(#arrow)");
  }

  createSelfArcs() {
    // Self-loop arcs
    this.selfArcs = this.container
      .append("g")
      .selectAll("path")
      .data(this.selfLinks)
      .join("path")
      .attr("fill", "none")
      .attr("stroke", "#222F54")
      .attr("stroke-width", 2)
      .attr("marker-end", "url(#arrow)");
  }

  createCircularNodes() {
    let tooltip = document.getElementById("bubble-tree-tooltip") as HTMLDivElement;
    if (!tooltip) {
      tooltip = document.createElement("div");
      tooltip.id = "bubble-tree-tooltip";
      tooltip.style.position = "absolute";
      tooltip.style.pointerEvents = "none";
      tooltip.style.background = "#222f54";
      tooltip.style.color = "#fff";
      tooltip.style.padding = "6px 12px";
      tooltip.style.borderRadius = "6px";
      tooltip.style.fontSize = "14px";
      tooltip.style.boxShadow = "0 2px 8px rgba(0,0,0,0.15)";
      tooltip.style.display = "none";
      tooltip.style.zIndex = "1000";
      document.body.appendChild(tooltip);
    }

    // Nodes
    this.node = this.container
      .append("g")
      .attr("stroke-width", 1.5)
      .selectAll("g")
      .data(this.nodes)
      .join("g")
      .call(this.drag())
      .on("click", (event: any, d: any) => {
        tooltip.style.display = "none";
        this.onNodeClick(event, d);
      })
      .on("mouseover", (event: any, d: any) => {
        tooltip.innerText = d.name;
        tooltip.style.display = "block";
      })
      .on("mousemove", (event: any) => {
        tooltip.style.left = event.clientX + 15 + "px";
        tooltip.style.top = event.clientY + 10 + "px";
      })
      .on("mouseout", () => {
        tooltip.style.display = "none";
      })
      .on("contextmenu", (event: any, d: any) => {
        event.preventDefault();
        alert(`Right-clicked node: ${d.name} (ID: ${d.id})`);
      });

    // Nodes
    // this.node = this.container
    //   .append("g")
    //   .attr("stroke-width", 1.5)
    //   .selectAll("g")
    //   .data(this.nodes)
    //   .join("g")
    //   .call(this.drag())
    //   .on("click", (event: any, d: any) => this.onNodeClick(event, d));

    // Store node dimensions for centered connections
    const nodeWidth = 100;
    const nodeHeight = 175;

    this.node
      .filter((d: any) => d.totalChildCount > d.childCount && d.id !== this.primaryNodeId)
      .append("rect")
      .attr("width", nodeWidth)
      .attr("height", nodeHeight)
      .attr("x", -nodeWidth / 2 + 5) // Offset to top-right
      .attr("y", -nodeHeight / 2 - 5)
      .attr("rx", 10)
      .attr("ry", 10)
      .attr("fill", "#EFEEEC")
      // .attr("stroke", "#d3d3d3")
      .attr("stroke-width", 1.5)
      .attr("opacity", 1)
      .attr("stroke", "#8F8F8F")
      .lower(); // Ensure it's behind the main rect

    // Node rectangle
    this.node
      .append("rect")
      .attr("width", nodeWidth)
      .attr("height", nodeHeight)
      .attr("x", -nodeWidth / 2) // Center the rectangle horizontally
      .attr("y", -nodeHeight / 2) // Center the rectangle vertically
      .attr("stroke", (d: any) => (d.id === this.primaryNodeId ? "#222F54" : "#8F8F8F73"))
      .attr("fill", "#efeeec")
      .attr("rx", 10)
      .attr("ry", 10);

    this.node
      .filter((d: any) => d.childCount > 0 && d.id !== this.primaryNodeId)
      .append("text")
      .text((d: any) => d.childCount)
      .attr("x", nodeWidth / 2 - 8)
      .attr("y", -nodeHeight / 2 + 12)
      .attr("text-anchor", "middle")
      .attr("font-size", "12px")
      .attr("font-weight", "bold")
      .attr("fill", "#EFEEEC");

    this.node
      .append("foreignObject")
      .attr("height", nodeHeight - 10)
      .attr("width", nodeWidth)
      .attr("y", -nodeHeight / 2)
      .attr("x", -nodeWidth / 2)
      .attr("fill", "#efeeec")
      .html(
        (d: any) => `
         ${d.structure}
        `
      );
  }

  onTick() {
    this.simulation.on("tick", () => {
      // Transform nodes first so we can use their calculated positions
      this.node.attr("transform", (d: any) => {
        d.x = Math.max(100, Math.min(this.width - 100, d.x));
        d.y = Math.max(100, Math.min(this.height - 100, d.y));
        return `translate(${d.x},${d.y})`;
      });

      // Normal links - connecting to center of node rectangles
      this.link
        .attr("x1", (d: any) => d.source.x)
        .attr("y1", (d: any) => d.source.y)
        .attr("x2", (d: any) => d.target.x)
        .attr("y2", (d: any) => d.target.y);

      // Midpoint arrows
      this.arrows.attr("d", (d: any) => {
        const x1 = d.source.x,
          y1 = d.source.y;
        const x2 = d.target.x,
          y2 = d.target.y;
        const mx = (x1 + x2) / 2;
        const my = (y1 + y2) / 2;
        const angle = Math.atan2(y2 - y1, x2 - x1);
        const len = 10;

        const tx = mx - len * Math.cos(angle);
        const ty = my - len * Math.sin(angle);
        const ex = mx + len * Math.cos(angle);
        const ey = my + len * Math.sin(angle);

        return `M${tx},${ty}L${ex},${ey}`;
      });

      // Self-loop arcs
      this.selfArcs.attr("d", (d: any) => {
        const x = d.source.x;
        const y = d.source.y;
        const r = 60; // radius of loop
        return `
                M ${x} ${y}
                m 0 -${r}
                a ${r} ${r} 0 1 1 1 0.01
                `;
      });
    });
  }

  panAndZoom() {
    // Zoom and pan functionality can be enabled here if needed
    // this.zoom = this.d3
    //   .zoom()
    //   .scaleExtent([0.5, 2])
    //   .on("zoom", (event: any) => {
    //     this.container.attr("transform", event.transform);
    //   });
    // this.svg.call(this.zoom);
  }

  drag() {
    return this.d3
      .drag()
      .on("start", (event: any, d: any) => this.dragstarted(event, d))
      .on("drag", (event: any, d: any) => {
        const tooltip = document.getElementById("bubble-tree-tooltip") as HTMLDivElement;
        if (tooltip) tooltip.style.display = "none";
        this.dragged(event, d);
      })
      .on("end", (event: any, d: any) => this.dragended(event, d));
  }

  dragstarted(event: any, d: any) {
    if (!event.active) this.simulation.alphaTarget(0.3).restart();
    d.fx = d.x;
    d.fy = d.y;
  }

  dragged(event: any, d: any) {
    d.fx = event.x;
    d.fy = event.y;
  }

  dragended(event: any, d: any) {
    if (!event.active) this.simulation.alphaTarget(0);
    d.fx = null;
    d.fy = null;
  }

  onNodeClick(event: any, d: any) {
    if (!d || !d.id) {
      // console.error("Invalid node clicked:", d);
      return;
    }

    // Check if node is already in history
    const existingIndex = this.navigationHistory.findIndex((item) => item.id === d.id);

    if (existingIndex !== -1) {
      // If clicking a node that's in history, truncate history to that point
      this.navigationHistory = this.navigationHistory.slice(0, existingIndex + 1);
    } else {
      // Add new node to navigation history
      this.navigationHistory.push({ id: d.id, name: d.name });
    }

    // Track parent node before updating primaryNodeId
    this.parentNodeId = this.primaryNodeId;

    // Set as primary node
    this.primaryNodeId = d.id;

    // Process nodes and links
    this.updateNodeDisplay(d);
  }

  updateNodeDisplay(node: any) {
    if (!node) return;

    // Collect all ancestor node IDs from navigationHistory (excluding the current node)
    const ancestorIds = this.navigationHistory
      .slice(0, -1) // all except the last (current node)
      .map((item) => item.id);

    // Collect node IDs to display
    const nodeIds = new Set<string>();
    nodeIds.add(node.id);

    // Add all ancestor nodes
    ancestorIds.forEach((id) => nodeIds.add(id));

    // Add children of the current node
    (node.children || []).forEach((id: string) => nodeIds.add(id));

    // Add shared nodes (children of both current node and any ancestor)
    ancestorIds.forEach((ancestorId) => {
      const ancestor = this.processedPages.find((p: any) => p.id === ancestorId);
      if (ancestor) {
        const shared = (ancestor.children || []).filter((id: string) =>
          (node.children || []).includes(id)
        );
        shared.forEach((id: string) => nodeIds.add(id));
      }
    });

    // Build processedPages for these nodes
    const processedPages = this.processedPages.filter((p: any) => nodeIds.has(p.id));

    this.nodes = this.createNodes(processedPages);
    this.links = this.createLinks(processedPages);
    this.buildTree();
    // this.createBreadcrumbs();
  }

  navigateToNode(nodeId: string, historyIndex?: number) {
    const node = this.processedPages.find((page: any) => page.id === nodeId);
    if (!node) {
      // console.error("Node not found:", nodeId);
      return;
    }

    // Update primary node
    this.primaryNodeId = nodeId;

    // Update navigation history if index provided
    if (historyIndex !== undefined) {
      // Truncate history if clicking on a breadcrumb
      this.navigationHistory = this.navigationHistory.slice(0, historyIndex + 1);
    }

    // Use the common update function
    this.updateNodeDisplay(node);
  }
}
