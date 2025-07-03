import { AppConfig } from "../AppConfig";
import { baseURL, ToolBoxService } from "../services/ToolBoxService";
import { ActionListDropDown } from "../ui/components/tools-section/action-list/ActionListDropDown";
import { PageAttacher } from "../ui/components/tools-section/action-list/PageAttacher";
import { PageCreationService } from "../ui/components/tools-section/action-list/PageCreationService";
import { ChildEditor } from "./editor/ChildEditor";
import { AppVersionManager } from "./versions/AppVersionManager";
import { i18n } from "../i18n/i18n";
import { MenuItem } from "../types";
import { InfoSectionManager } from "./InfoSectionManager";

export class ActionListManager {
  private toolboxService: ToolBoxService;
  private appVersionManager: AppVersionManager;
  private pageAttacher: PageAttacher;
  actionList: ActionListDropDown;
  private selectedComponent: any;
  pageCreationService: PageCreationService;

  constructor() {
    this.toolboxService = new ToolBoxService();
    this.appVersionManager = new AppVersionManager();
    this.pageAttacher = new PageAttacher();
    this.actionList = new ActionListDropDown();
    this.pageCreationService = new PageCreationService();
    this.selectedComponent = (globalThis as any).selectedComponent;
  }

  async getMenuCategories(): Promise<MenuItem[][] | null> {
    const categoryData = await this.actionList.getCategoryData();
    const activePage = (globalThis as any).pageData;

    const secondCategory: MenuItem[] = [];

    secondCategory.push({
      id: "list-page",
      name: "Page",
      label: i18n.t("tile.existing_pages"),
      expandable: true,
      action: () => this.getSubMenuItems(categoryData, ""),
    });

    secondCategory.push({
      id: "cta-list",
      name: "CallToActions",
      label: i18n.t("tile.call_to_action"),
      expandable: true,
      action: () => this.getSubMenuItems(categoryData, "CallToActions"),
    });

    secondCategory.push({
      id: "list-form",
      name: "DynamicForm",
      label: i18n.t("tile.forms"),
      expandable: true,
      action: () => this.getSubMenuItems(categoryData, "Content"),
    });
    secondCategory.push({
      id: "list-module",
      name: "Modules",
      label: i18n.t("tile.modules"),
      expandable: true,
      action: () => this.getSubMenuItems(categoryData, "Modules"),
    });
    // }

    return [
      [
        {
          id: "add-info-page",
          label: i18n.t("tile.information_page"),
          name: "",
          action: async () => {
            this.createNewInfoPage("Untitled");
          },
        },
      ],
      secondCategory,
      [
        {
          id: "copy-tile-info",
          label: i18n.t("tile.copy_tile"),
          name: "Copy Tile",
          action: () => this.copySelectedTileSection(),
        },
      ],
    ];
  }

  async getSubMenuItems(categoryData: any, type: string): Promise<MenuItem[]> {
    const category = categoryData.find((cat: any) => cat.name === type);
    const itemsList = category?.options || [];
    return itemsList.map((item: any) => {
      return {
        id: item.PageId,
        label: item.PageName,
        url: item.PageUrl,
        action: () => this.handleSubMenuItemSelection(item, item.PageType),
      };
    });
  }

  async createNewPage(title: string): Promise<void> {
    const appVersion = await this.appVersionManager.getActiveVersion();
    const res = await this.toolboxService.createMenuPage(
      appVersion.AppVersionId,
      title
    );

    if (!res.error.message) {
      const page = {
        PageId: res.MenuPage.PageId,
        PageName: res.MenuPage.PageName,
        TileName: res.MenuPage.PageName,
        PageType: res.MenuPage.PageType,
      };
      this.pageAttacher.attachToTile(page, "Menu", "Menu");
    } else {
      console.error("error", res.error.message);
    }
  }

  async createNewInfoPage(title: string): Promise<void> {
    const appVersion = await this.appVersionManager.getActiveVersion();
    const res = await this.toolboxService.createInfoPage(
      appVersion.AppVersionId,
      title
    );

    console.log('res', res)
    if (!res.error.message) {
      const page = {
        PageId: res.MenuPage.PageId,
        PageName: res.MenuPage.PageName,
        TileName: res.MenuPage.PageName,
        PageType: res.MenuPage.PageType,
      };
      this.pageAttacher.attachToTile(page, "Information", "Information", true);
    } else {
      console.error("error", res.error.message);
    }
  }

  private handleSubMenuItemSelection(item: any, type: string): void {
    console.log('handleSubMenuItemSelection', item)
    console.log('handleSubMenuItemSelection', (globalThis as any).pageData)

    this.pageAttacher.removeOtherEditors();

    console.log('handleSubMenuItemSelection:removeOtherEditors', (globalThis as any).pageData)

    if (type === "DynamicForm") {
      this.handleDynamicForms(item);
    } else if (type === "Modules") {
      this.pageAttacher.attachToTile(item, item.PageType, item.PageName);
    } else if (type === "CtaEmail") {
      this.pageCreationService.handleEmail();
    } else if (type === "CtaPhone") {
      this.pageCreationService.handlePhone();
    } else if (type === "CtaWebLink") {
      console.log('at Actionlistmanager')
      this.pageCreationService.handleWebLinks();
    } else {
      this.pageAttacher.attachToTile(item, type, item.PageName);
    }
  }

  async handleDynamicForms(form: any) {
    const selectedComponent = (globalThis as any).selectedComponent;
    if (!selectedComponent) return;
    const tileTitle = selectedComponent.find(".tile-title")[0];
    if (tileTitle) tileTitle.components(form.PageName);
    tileTitle.addAttributes({ title: form.PageName });

    const tileId = selectedComponent.parent().getId();
    const rowId = selectedComponent.parent().parent().getId();

    const version = (globalThis as any).activeVersion;
    let childPage = version?.Pages.find((page: any) => {
      if (page.PageType == "DynamicForm")
        return (
          page.PageType == "DynamicForm" &&
          page.PageLinkStructure.WWPFormId == form.PageId
        );
    });
    const parsedUrl = new URL(form.PageUrl);
    // Get the query parameters
    const params = parsedUrl.searchParams;
    // Extract values
    const WWPFormReferenceName = params.get('WWPFormReferenceName');
    //const WWPFormInstanceId = params.get('WWPFormInstanceId');
    //const WWPDynamicFormMode = params.get('WWPDynamicFormMode');
    // Output
    console.log('ActionListManager');
    console.log('WWPFormReferenceName:', WWPFormReferenceName);
    //console.log('WWPFormInstanceId:', WWPFormInstanceId);
    //console.log('WWPDynamicFormMode:', WWPDynamicFormMode);
    if (!childPage) {
      const appVersion = await this.appVersionManager.getActiveVersion();
      childPage = await this.toolboxService.createLinkPage(
        appVersion.AppVersionId,
        form.PageName,
        "",
        form.PageId,
        WWPFormReferenceName
      );
      childPage = childPage.MenuPage;
    }

    const formUrl = `${baseURL}/utoolboxdynamicform.aspx?WWPFormId=${form.PageId}&WWPDynamicFormMode=DSP&DefaultFormType=&WWPFormType=0&WWPFormReferenceName=${WWPFormReferenceName}`;
    const updates = [
      ["Text", form.PageName],
      ["Name", form.PageName],
      ["Action.ObjectType", "DynamicForm"],
      ["Action.ObjectId", childPage.PageId],
      ["Action.ObjectUrl", formUrl],
      ["Action.FormId", form.PageId],
    ];

    for (const [property, value] of updates) {
      const infoSectionManager = new InfoSectionManager();
      infoSectionManager.updateInfoTileAttributes(
        rowId,
        tileId,
        property,
        value
      );
    }
    const tileAttributes = (globalThis as any).tileMapper.getTile(
      rowId,
      tileId
    );

    new ChildEditor(childPage?.PageId, childPage).init(tileAttributes);
  }



  filterMenuItems(items: HTMLElement[], searchTerm: string): HTMLElement[] {
    return items.filter((item) => {
      const itemText = item.textContent?.toLowerCase() || "";
      return itemText.includes(searchTerm.toLowerCase());
    });
  }

  /**
   * Copies the selected tile and prepares it for pasting.
   * This method should be called when the user selects a tile and clicks the copy button.
   */
  private copySelectedTileSection(): void {
    const selectedComponent = (globalThis as any).selectedComponent;
    const activePage = (globalThis as any).pageData;
    let copiedStructure = {};
    // console.log('copySelectedTile activePage', activePage);
    if (!selectedComponent) {
      console.error("No tile selected to copy.");
      return;
    }

    // 1. Get the tile's unique ID
    const tileParentId = selectedComponent.parent().parent().getId?.();
    const tileId = selectedComponent.parent().getId?.();

    if (!tileId) {
      console.error("Selected tile does not have an ID.");
      return;
    }

    // 2. Retrieve the tile structure from localStorage
    const data: any = JSON.parse(
      localStorage.getItem(`data-${activePage.PageId}`) || "{}"
    );
    // console.log('local storage key', `data-${activePage.PageId}`);
    // console.log('copySelectedTile data', data);
    if (data?.PageInfoStructure?.InfoContent) {
      data.PageInfoStructure.InfoContent.forEach((infoContent: any) => {
        if (infoContent?.InfoType === "TileRow" && infoContent?.InfoId === tileParentId) {
          // get the structure of the selected tile
          infoContent?.Tiles.forEach((tile: any) => {
            if (tile.Id === tileId) {
              // console.log('copySelectedTile infoContent', infoContent);
              copiedStructure = tile;
            }
          });
        } else if (infoContent?.InfoType === "Tile" && infoContent?.InfoId === tileId) {
          // If the tile itself is directly in the PageInfoStructure
          copiedStructure = infoContent;
          // console.log('copySelectedTile infoContent tile', infoContent);
          // No need to continue if we found the tile directly

          return;

        }
      });
    }

    if (!copiedStructure) {
      console.error("No structure found in localStorage for tile ID:", tileId);
      return;
    }

    // Option B: Store in a dedicated localStorage key
    localStorage.setItem('copiedInfoSection', JSON.stringify(copiedStructure));

    // console.log("Tile copied:", tileId, copiedStructure);
  }
}

