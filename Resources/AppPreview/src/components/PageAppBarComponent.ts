import { BackButtonController } from "../controls/BackButtonController";
import { NavigationData } from "../interfaces/Navigation";
import { Page } from "../interfaces/Page";

export class MenuAppBarComponent {
    appBar: HTMLElement;
    page: Page;
    pageTitle?: string;

    constructor(page: Page, pageTitle?: string) {
        this.page = page;
        this.pageTitle = pageTitle;
        this.appBar = document.createElement('div');
        this.init();
    }

    private init() {
        this.appBar.classList.add('tbap-app-bar');

        const backButtonSvg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
        backButtonSvg.setAttribute('viewBox', '0 0 47 47');
        backButtonSvg.setAttribute('width', '47');
        backButtonSvg.setAttribute('height', '47');
        backButtonSvg.classList.add('content-back-button');
        
        backButtonSvg.innerHTML = `
            <g id="Ellipse_6" data-name="Ellipse 6" fill="none" stroke="#262626" stroke-width="1">
                <circle cx="23.5" cy="23.5" r="23.5" stroke="none"></circle>
                <circle cx="23.5" cy="23.5" r="23" fill="none"></circle>
            </g>
            <path id="Icon_ionic-ios-arrow-round-up" data-name="Icon ionic-ios-arrow-round-up" d="M13.242,7.334a.919.919,0,0,1-1.294.007L7.667,3.073V19.336a.914.914,0,0,1-1.828,0V3.073L1.557,7.348A.925.925,0,0,1,.263,7.341.91.91,0,0,1,.27,6.054L6.106.26h0A1.026,1.026,0,0,1,6.394.07.872.872,0,0,1,6.746,0a.916.916,0,0,1,.64.26l5.836,5.794A.9.9,0,0,1,13.242,7.334Z" transform="translate(13 30.501) rotate(-90)" fill="#262626"></path>
        `;

        backButtonSvg.addEventListener('click', (e) => {
            e.preventDefault();
            this.onBackButtonClicked();
        })
        console.log('backButtonSvg', this.pageTitle)
        const h1 = document.createElement('h1');
        h1.classList.add('title');
        h1.innerText = this.truncateText(this.pageTitle || this.page.PageName);

        this.appBar.appendChild(backButtonSvg);
        this.appBar.appendChild(h1);
    }

    render(container: HTMLElement) {
        container.appendChild(this.appBar);
    }

    onBackButtonClicked () {
        const parentPageId = this.getParentId();
        if (parentPageId) {
            const backButtonController = new BackButtonController(parentPageId);
            backButtonController.back();
        }        
    }

    getParentId(): any {
        try {
            let navData: NavigationData = JSON.parse(localStorage.getItem("navigation") || '{"history":[]}');
    
            if (navData.history.length <= 0) return; 
        
            const parentId = navData.history.find(data => data.targetId === this.page.PageId)?.pageId;

            navData.history.pop();
    
            localStorage.setItem("navigation", JSON.stringify(navData));
    
            if (parentId) {
                return parentId.trim().replace(/^["']|["']$/g, '')
            }
        } catch (error) {
            console.error("Error navigating back:", error);
        }
        return null;
    }

    private truncateText(text: string, maxLength: number = 20): string {
        return text.length > maxLength ? text.substring(0, maxLength) + '...' : text;
    }
}