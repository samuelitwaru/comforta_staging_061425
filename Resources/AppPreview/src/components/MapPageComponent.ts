import { HeaderComponent } from "../components/HeaderComponent";
import { MapPageMapper } from "../controls/MapPageMapper";
import { WebLinkPageMapper } from "../controls/WebLinkPageMapper";
import { Page } from "../interfaces/Page";
import { Tile } from "../interfaces/Tile";
import { MenuAppBarComponent } from "./PageAppBarComponent";

export class MapPageComponent {
    pageElement: HTMLElement;
    page: Page;
    tile: Tile;

    constructor(tile: Tile, page: Page) {
        this.page = page;
        this.tile = tile;
        this.pageElement = document.createElement("div");
        this.init();
    }

    private init() {
        this.pageElement.classList.add("tbap-page-container");
        const header = new HeaderComponent();
        const menuAppBar = new MenuAppBarComponent(this.page, this.tile.Name);

        header.render(this.pageElement);
        menuAppBar.render(this.pageElement);

        let pageMapper;
        pageMapper = new MapPageMapper(this.tile);

        pageMapper?.renderContent(this.pageElement);
    }

    render() {
        const frame = document.getElementById("frame") as HTMLElement;
        frame.appendChild(this.pageElement);
    }
}