import { HomePageComponent } from "../components/HomePageComponent";
import { NavigationData, NavigationEntry } from "../interfaces/Navigation";
import { Page } from "../interfaces/Page";
import { AppVersionManager } from "./AppVersionManager";

export class HomePageController {
    private version: AppVersionManager;
    homepage: any;
    constructor() {
        this.version = AppVersionManager.getInstance();
    }

    init() {
        this.renderUI();
    }

    private renderUI() {
        // console.log("HomePageController", this.version.homePage);
        if (this.version.homePage) {
            const page = this.version.homePage as Page;
                        
            const pageContainer = document.querySelector(".tbap-page-container");
            if (pageContainer) {
                pageContainer.remove();
            }

            const homePage = new HomePageComponent(page);
            homePage.render();

            this.initialiseNavigator(page);
        }
    }

    initialiseNavigator (page: Page){
        const initialNav: NavigationEntry = {
            pageId: page.PageId,
            targetId: "",
            tileId: "",
            level: 0,
        };

        const history: NavigationData = {
            history: [initialNav],
        }

        localStorage.setItem("navigation", JSON.stringify(history));
    }
}