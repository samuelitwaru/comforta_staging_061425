import { HeaderComponent } from "../components/HeaderComponent";
import { CalendarPageMapper } from "../controls/CalendarPageMapper";
import { ContentPageMapper } from "../controls/ContentPageMapper";
import { HomePageMapper } from "../controls/HomePageMapper";
import { InfoPageMapper } from "../controls/InfoPageMapper";
import { MenuPageMapper } from "../controls/MenuPageMapper";
import MyActivityPageMapper from "../controls/MyActivityPageMapper";
import { WebLinkPageMapper } from "../controls/WebLinkPageMapper";
import { Page } from "../interfaces/Page";
import { MenuAppBarComponent } from "./PageAppBarComponent";

export class MenuPageComponent {
    pageElement: HTMLElement;
    page: Page;

    constructor(page: Page) {
        this.page = page;
        this.pageElement = document.createElement("div");
        this.init();
    }

    private init() {
        this.pageElement.classList.add("tbap-page-container");
        const header = new HeaderComponent();
        const menuAppBar = new MenuAppBarComponent(this.page);

        header.render(this.pageElement);
        menuAppBar.render(this.pageElement);

        let pageMapper;
        if (this.page.PageType === "Calendar") {
            pageMapper = new CalendarPageMapper();
        } else if (this.page.PageType === "MyActivity") {
            pageMapper = new MyActivityPageMapper();
        } else if (
            this.page.PageType === "Menu" ||
            this.page.PageType === "MyCare" ||
            this.page.PageType === "MyLiving" ||
            this.page.PageType === "MyService"
        ) {
            pageMapper = new MenuPageMapper(this.page);
        } else if (
            this.page.PageType === "Content" ||
            this.page.PageType === "Location" ||
            this.page.PageType === "Reception"
        ) {
            pageMapper = new ContentPageMapper(this.page);
        } else if (this.page.PageType === "Information") {
            pageMapper = new InfoPageMapper(this.page);
        }

        pageMapper?.renderContent(this.pageElement);
    }

    render() {
        const frame = document.getElementById("frame") as HTMLElement;
        frame.appendChild(this.pageElement);
    }
}