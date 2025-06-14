import { HomePageComponent } from "../components/HomePageComponent";
import { MenuPageComponent } from "../components/MenuPageComponent";
import { Page } from "../interfaces/Page";
import { AppVersionManager } from "./AppVersionManager";

export class MenuPageController {
    private version: AppVersionManager;
    homepage: any;
    pageId: any;

    constructor(pageId: any) {
        this.version = AppVersionManager.getInstance();
        this.pageId = pageId;
    }

    init() {
        this.renderUI();
    }

    private renderUI() {
        if (this.pageId) {
            const page = this.version.pages?.find(page => page.PageId === this.pageId) as Page;
            const pageContainer = document.querySelector(".tbap-page-container");
            if (pageContainer) {
                pageContainer.remove();
            }
            const menuPage = new MenuPageComponent(page);
            menuPage.render();
        }
    }
}