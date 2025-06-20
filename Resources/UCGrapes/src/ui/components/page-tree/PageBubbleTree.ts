import { AppConfig } from "../../../AppConfig";
import { ThemeManager } from "../../../controls/themes/ThemeManager";
import { TreeComponent } from "../TreeComponent";
import { PageTreeRenderer } from "./PageTreeRenderer";
import { PageTreeRendererInfoPage } from "./PageTreeRendererInfoPage";
import { EditorManager } from "../../../controls/editor/EditorManager";

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
  zoom: any;
  pageTreeRenderer: PageTreeRenderer;
  PageTreeRendererInfoPage: PageTreeRendererInfoPage;
  primaryNodeId: string | null = null; // Fixed type to string
  appVersionManager: any;
  navigationHistory: { id: string; name: string }[] = [];
  parentNodeId: string | null = null;

  constructor(primaryNodeId?: string) {
    this.pageTreeRenderer = new PageTreeRenderer();
    this.PageTreeRendererInfoPage = new PageTreeRendererInfoPage();
    const config = AppConfig.getInstance();
    this.d3 = config.UC.d3;
    this.themeManager = new ThemeManager();
    const appVersionManager = this.themeManager.appVersionManager;
    this.appVersionManager = appVersionManager;
    this.pages = appVersionManager.getPages();
    this.processedPages = this.processPageData(this.pages);
    console.log('processedPages', this.processedPages)
    const homePage = this.processedPages.find((page) => page.title === "Home");

    // if (homePage) {
    //   this.primaryNodeId = homePage.id;
    //   // Initialize navigation history with home page
    //   // this.navigationHistory = [{ id: homePage.id, name: homePage.title }];
    //   // Use the same logic as onNodeClick for initialization
    //   this.updateNodeDisplay(homePage);
    // }

    // If primaryNodeId is provided, use it; otherwise, use "Home"
    let initialNode = null;
    if (primaryNodeId) {
      this.primaryNodeId = primaryNodeId;
      initialNode = this.processedPages.find(
        (page) => page.id === primaryNodeId
      );
    } else {
      const homePage = this.processedPages.find(
        (page) => page.title === "Home"
      );
      if (homePage) {
        this.primaryNodeId = homePage.id;
        initialNode = homePage;
      }
    }

    if (initialNode) {
      // Optionally initialize navigation history
      this.navigationHistory = [
        { id: initialNode.id, name: initialNode.title },
      ];
      this.updateNodeDisplay(initialNode);
    }

    // this.init();
  }

  // init() {
  //   this.refreshPages();

  //   this.graphContainer = this.build();
  //   this.buildTree();
  // }

  refreshPages() {
    this.pages = this.appVersionManager.getPages();
    this.processedPages = this.processPageData(this.pages);
  }

  intializePreviewTree() {
    this.treeContainer = this.build2();
    this.buildPreviewTree();
  }

  show() {
    this.refreshPages();

    this.graphContainer = this.build();
    this.buildTree();

    const editorSections = document.getElementsByClassName(
      "editor-main-section"
    );
    const toolSection = document.getElementById(
      "tools-section"
    ) as HTMLDivElement;

    const treeSection = document.getElementById(
      "tree-container"
    ) as HTMLDivElement;

    const sidebarSection = document.getElementById(
      "tb-sidebar"
    ) as HTMLDivElement;

    //set display to none for editor section
    if (editorSections.length > 0) {
      // toggle display
      const div = editorSections[0] as HTMLDivElement;
      if (div.style.display === "none") {
        div.style.display = "block";
        this.graphContainer.style.display = "none";
        toolSection.style.display = "block";
        treeSection.style.display = "none";
        sidebarSection.style.display = "block";
      } else {
        toolSection.style.display = "none";
        sidebarSection.style.display = "none";
        div.style.display = "none";
        this.graphContainer.style.display = "block";
        this.graphContainer.style.width = "100%";
        this.graphContainer.style.height = "100%";
        // const tree = new TreeComponent(this.appVersionManager);
      }
    }
  }

  build() {
    const mainContainer = document.getElementById(
      "main-content"
    ) as HTMLDivElement;

    if (!mainContainer) {
      console.error("Main content container not found");
      return document.createElement("div");
    }

    this.graphContainer = document.getElementById(
      "graph-container-1"
    ) as HTMLDivElement;

    if (!this.graphContainer) {
      this.graphContainer = document.createElement("div");
      this.graphContainer.id = "graph-container-1";
    }

    // Clear any existing content
    this.graphContainer.innerHTML = ""; // Clear existing content
    this.graphContainer.innerHTML = "<svg></svg>";

    mainContainer.appendChild(this.graphContainer);
    this.graphContainer.setAttribute("style", "display:block;width:100%;");
    console.log("this.graphContainer", this.graphContainer);

    return this.graphContainer;
  }

  build2() {
    console.log("Build2");
    const TreeSection = document.getElementById(
      "section-tree"
    ) as HTMLDivElement;

    if (!TreeSection) {
      console.error("Main content container not found");
      return document.createElement("div");
    }

    this.treeContainer = document.getElementById(
      "tree-container"
    ) as HTMLDivElement;

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
      let ret: PageNode = {
        id: page.PageId,
        title: page.PageName,
        structure: "",
        thumbnail: page.PageThumbnailUrl,
        children: [],
        x: 0,
        y: 0,
      };

      if (
        page.PageType === "Menu" ||
        page.PageType === "MyCare" ||
        page.PageType === "MyLiving" ||
        page.PageType === "MyService"
      ) {
        ret.structure = this.pageTreeRenderer.createMenuHTML(page);
        page.PageMenuStructure.Rows.forEach((row: any) => {
          row.Tiles.forEach((tile: any) => {
            if (
              tile.Action.ObjectType == "DynamicForm" ||
              tile.Action.ObjectType == "WebLink"
            ) {
              const title =
                tile.Action.ObjectType == "DynamicForm"
                  ? "Dynamic Form"
                  : "Web Link";

              linkPages.push({
                id: tile.Action.ObjectId,
                title: title,
                structure: this.pageTreeRenderer.createLinkHTML(
                  title,
                  tile.Action.ObjectUrl
                ),
                thumbnail: page.PageThumbnailUrl,
                children: [],
                x: 0,
                y: 0,
              });
              ret.children.push(tile.Action.ObjectId);
            } else if (tile.Action.ObjectId) {
              if (
                this.pages.some(
                  // Changed from filter to some for boolean check
                  (page: any) => page.PageId === tile.Action.ObjectId
                )
              ) {
                this.primaryNodeId = page.PageId;
                ret.children.push(tile.Action.ObjectId);
              }
            }
          });
        });
      } else if (page.PageType === "Information") {
        if (page.PageInfoStructure.InfoContent) {
          ret.structure = this.PageTreeRendererInfoPage.createMenuHTML(page);
          page.PageInfoStructure.InfoContent.forEach((row: any) => {
            if (row.InfoType === "TileRow") {
              row.Tiles.forEach((tile: any) => {
                if (
                  tile.Action.ObjectType == "DynamicForm" ||
                  tile.Action.ObjectType == "WebLink"
                ) {
                  const title =
                    tile.Action.ObjectType == "DynamicForm"
                      ? "Dynamic Form"
                      : "Web Link";
                  linkPages.push({
                    id: tile.Action.ObjectId,
                    title: title,
                    structure: "",
                    thumbnail: page.PageThumbnailUrl,
                    children: [],
                    x: 0,
                    y: 0,
                  });
                  ret.children.push(tile.Action.ObjectId);
                } else if (tile.Action.ObjectId) {
                  if (
                    this.pages.some(
                      (page: any) => page.PageId === tile.Action.ObjectId
                    )
                  ) {
                    ret.children.push(tile.Action.ObjectId);
                  }
                }
              });
            }
          });
        }
      } else if (
        page.PageType == "Content" ||
        page.PageType == "Location" ||
        page.PageType == "Reception"
      ) {
        ret.structure = this.pageTreeRenderer.createContentHTML(page);
      } else if (page.PageType == "Calendar") {
        ret.structure = this.pageTreeRenderer.createAgendaHTML(page);
      } else if (page.PageType == "MyActivity") {
        ret.structure = this.pageTreeRenderer.createMyActivityHTML(page);
      } else if (page.PageType == "Map") {
        ret.structure = this.pageTreeRenderer.createMapHTML(page);
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
    console.log('processedPages', processedPages)
    return processedPages.flatMap((p) =>
      p.children
        .filter((childId: string) =>
          processedPages.some((page: any) => page.id === childId)
        )
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

    console.log("svg", this.svg);

    console.log("container", this.container);
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
      .attr("stroke", "#fff")
      .attr("stroke-opacity", 0.6)
      .selectAll("line")
      .data(this.normalLinks)
      .join("line")
      .attr("stroke-width", 2.0)
      .style("cursor", "pointer") // Make it look clickable
      .on("click", (event: any, d: any) => {
        // const editorManager = new EditorManager();
        // editorManager.currentPage(d.source.id);
        // alert(
        //   `Parent (source): ${d.source.id}\nChild (target): ${d.target.id}`
        // );
      });
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
      .attr("fill", "#fff");

    // Arrows at midpoint
    this.arrows = this.container
      .append("g")
      .selectAll("path")
      .data(this.normalLinks)
      .join("path")
      .attr("fill", "#fff")
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
      .attr("stroke", "#fff")
      .attr("stroke-width", 2)
      .attr("marker-end", "url(#arrow)");
  }

  createCircularNodes() {
    let tooltip = document.getElementById(
      "bubble-tree-tooltip"
    ) as HTMLDivElement;
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
      .filter(
        (d: any) =>
          d.totalChildCount > d.childCount && d.id !== this.primaryNodeId
      )
      .append("rect")
      .attr("width", nodeWidth)
      .attr("height", nodeHeight)
      .attr("x", -nodeWidth / 2 + 5) // Offset to top-right
      .attr("y", -nodeHeight / 2 - 5)
      .attr("rx", 10)
      .attr("ry", 10)
      .attr("fill", "#fff")
      .attr("stroke", "#d3d3d3")
      .attr("stroke-width", 1.5)
      .attr("opacity", 1)
      .attr("stroke", "#222f54")
      .lower(); // Ensure it's behind the main rect

    // Node rectangle
    this.node
      .append("rect")
      .attr("width", nodeWidth)
      .attr("height", nodeHeight)
      .attr("x", -nodeWidth / 2) // Center the rectangle horizontally
      .attr("y", -nodeHeight / 2) // Center the rectangle vertically
      .attr("stroke", (d: any) =>
        d.id === this.primaryNodeId ? "#FF5722" : "#222f54"
      )
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
      .attr("fill", "#ffffff");

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
        const tooltip = document.getElementById(
          "bubble-tree-tooltip"
        ) as HTMLDivElement;
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
      console.error("Invalid node clicked:", d);
      return;
    }

    // Check if node is already in history
    const existingIndex = this.navigationHistory.findIndex(
      (item) => item.id === d.id
    );

    if (existingIndex !== -1) {
      // If clicking a node that's in history, truncate history to that point
      this.navigationHistory = this.navigationHistory.slice(
        0,
        existingIndex + 1
      );
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
    let nodeIds = new Set<string>();
    nodeIds.add(node.id);

    // Add all ancestor nodes
    ancestorIds.forEach((id) => nodeIds.add(id));

    // Add children of the current node
    (node.children || []).forEach((id: string) => nodeIds.add(id));

    // Add shared nodes (children of both current node and any ancestor)
    ancestorIds.forEach((ancestorId) => {
      const ancestor = this.processedPages.find(
        (p: any) => p.id === ancestorId
      );
      if (ancestor) {
        const shared = (ancestor.children || []).filter((id: string) =>
          (node.children || []).includes(id)
        );
        shared.forEach((id: string) => nodeIds.add(id));
      }
    });

    // Build processedPages for these nodes
    const processedPages = this.processedPages.filter((p: any) =>
      nodeIds.has(p.id)
    );

    this.nodes = this.createNodes(processedPages);
    this.links = this.createLinks(processedPages);
    this.buildTree();
    // this.createBreadcrumbs();
  }

  navigateToNode(nodeId: string, historyIndex?: number) {
    const node = this.processedPages.find((page: any) => page.id === nodeId);
    if (!node) {
      console.error("Node not found:", nodeId);
      return;
    }

    // Update primary node
    this.primaryNodeId = nodeId;

    // Update navigation history if index provided
    if (historyIndex !== undefined) {
      // Truncate history if clicking on a breadcrumb
      this.navigationHistory = this.navigationHistory.slice(
        0,
        historyIndex + 1
      );
    }

    // Use the common update function
    this.updateNodeDisplay(node);
  }
}
