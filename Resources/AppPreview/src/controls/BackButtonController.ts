import { Page } from "../interfaces/Page";
import { AppVersionManager } from "./AppVersionManager";
import { HomePageController } from "./HomePageController";
import { MenuPageController } from "./MenuPageController";

export class BackButtonController {
    private version: AppVersionManager;
    pageId: any;

    constructor(pageId: any) {
        this.version = AppVersionManager.getInstance();
        this.pageId = pageId;
    }

    public back() {
        if (this.pageId) {
            const page = this.version.pages?.find(page => page.PageId === this.pageId);
            if (page) {
                if (page.PageName === "Home") {
                    new HomePageController().init();
                } else {
                    new MenuPageController(page.PageId).init();
                }
            }
        }
    }
}