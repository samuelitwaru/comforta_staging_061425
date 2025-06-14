import { HeaderComponent } from "../components/HeaderComponent";
import { WebLinkPageMapper } from "../controls/WebLinkPageMapper";
import { Page } from "../interfaces/Page";
import { Tile } from "../interfaces/Tile";
import { MenuAppBarComponent } from "./PageAppBarComponent";

export class WebLinkPageComponent {
    pageElement: HTMLElement;
    page: Page;
    tile: Tile;

    constructor(tile: Tile, page: Page) {
        this.page = page;
        this.tile = tile;
        console.log('tile', tile)
        console.log('page', page)
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
        pageMapper = new WebLinkPageMapper(this.tile);

        pageMapper?.renderContent(this.pageElement);
    }

    render() {
        const frame = document.getElementById("frame") as HTMLElement;
        frame.appendChild(this.pageElement);
    }
}