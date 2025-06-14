import { HomePageMapper } from "../controls/HomePageMapper";
import { InfoPageMapper } from "../controls/InfoPageMapper";
import { Page } from "../interfaces/Page";
import { HeaderComponent } from "./HeaderComponent";
import { HomeAppBarComponent } from "./HomeAppBarComponent";

export class HomePageComponent {
    homeElement: HTMLElement;
    page: Page;

    constructor(homePage: Page) {
        this.page = homePage;
        this.homeElement = document.createElement("div");
        this.init();
    }

    private init() {
        this.homeElement.classList.add("tbap-page-container");

        const header = new HeaderComponent();
        const homeAppBar = new HomeAppBarComponent();

        header.render(this.homeElement);
        homeAppBar.render(this.homeElement);

        const homePageMapper = new InfoPageMapper(this.page);
        homePageMapper.renderContent(this.homeElement);
    }

    render() {
        const frame = document.getElementById("frame") as HTMLElement;
        frame.appendChild(this.homeElement);
    }
}