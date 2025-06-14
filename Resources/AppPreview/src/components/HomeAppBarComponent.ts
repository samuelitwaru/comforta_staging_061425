import { AppVersionManager } from "../controls/AppVersionManager";

export class HomeAppBarComponent {
    appBar: HTMLElement;
    constructor() {
        this.appBar = document.createElement('div');
        this.init();
    }

    private init() {
        this.appBar.classList.add('tbap-home-app-bar');

        const logoSection = document.createElement('div');
        logoSection.classList.add('logo-section');

        const logo = document.createElement('img');

        const organisationLogo = AppVersionManager.getInstance().OrganisationLogo;

        if (organisationLogo) {
            logo.src = organisationLogo;
        } else {
            logo.src = '/Resources/ComfortaLogo1.png'; // fallback
        }


        logo.style.height = '35px';

        logoSection.appendChild(logo);

        const profileSection = document.createElement('div');
        profileSection.classList.add('profile-section');
        profileSection.style.display = 'flex';

        const userSvg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
        userSvg.setAttribute('viewBox', '0 0 19.422 21.363');
        userSvg.setAttribute('width', '16');
        userSvg.setAttribute('height', '18');
        userSvg.setAttribute('fill', 'none');
        userSvg.innerHTML = `
            <path id="Path_1327" data-name="Path 1327" d="M15.711,5a6.8,6.8,0,0,0-3.793,12.442A9.739,9.739,0,0,0,6,26.364H7.942a7.769,7.769,0,1,1,15.537,0h1.942A9.739,9.739,0,0,0,19.5,17.442,6.8,6.8,0,0,0,15.711,5Zm0,1.942A4.855,4.855,0,1,1,10.855,11.8,4.841,4.841,0,0,1,15.711,6.942Z" transform="translate(-6 -5)" fill="#fff"></path>
        `;

        profileSection.appendChild(userSvg);

        this.appBar.appendChild(logoSection);
        this.appBar.appendChild(profileSection);
    }

    render(container: HTMLElement) {
        container.appendChild(this.appBar);
    }
}