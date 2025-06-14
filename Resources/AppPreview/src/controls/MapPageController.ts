import { HomePageComponent } from "../components/HomePageComponent";
import { MapPageComponent } from "../components/MapPageComponent";
import { MenuPageComponent } from "../components/MenuPageComponent";
import { WebLinkPageComponent } from "../components/WebLinkComponent";
import { Page } from "../interfaces/Page";
import { AppVersionManager } from "./AppVersionManager";

export class MapPageController {
    private version: AppVersionManager;
        pageId: any;
        tile: any;
    
        constructor(tile: any, pageId: any) {
            this.version = AppVersionManager.getInstance();
            this.tile = tile;
            this.pageId = pageId;
        }
    
        init() {
            this.renderUI();
        }
    
        private renderUI() {
            if (this.tile && this.pageId) {
                const page = this.version.pages?.find(page => page.PageId === this.pageId) as Page;
                const pageContainer = document.querySelector(".tbap-page-container");
                
                if (pageContainer) {
                    pageContainer.remove();
                }

                const mapPage = new MapPageComponent(this.tile, page);
                mapPage.render();
            }
        }
}