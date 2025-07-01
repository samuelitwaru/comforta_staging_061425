import { TranslationMapper } from "../../../../controls/translation/TranslationMapper";

export class TranslateFrame {
  frame!: HTMLDivElement;
  data: any;
  constructor(data: any) {
    this.data = data;
    this.init();
  }

  private init() {
    this.frame = document.createElement("div");
    this.frame.classList.add("translate-page-frame");
    this.frame.id = "translate-page-frame";

    const header = this.header();
    const homeAppbar = this.homePageAppBar();
    const otherAppbar = this.otherPageAppBar();
    const body = this.body();

    const frameContainer = body.querySelector(".translate-container") as HTMLElement | null;

    this.frame.append(header);
    this.frame.append(homeAppbar);
    // this.frame.append(otherAppbar);

    if (frameContainer instanceof HTMLElement) {
      this.frame.append(frameContainer);
    } else {
      console.warn("frameContainer is null or not an HTMLElement", frameContainer);
    }
  }

  private header(): HTMLDivElement {
    const headerDiv = document.createElement("div");
    headerDiv.className = "header";

    const clockSpan = document.createElement("span");
    clockSpan.id = "clock";
    clockSpan.textContent = this.getCurrentTime();

    const iconsSpan = document.createElement("span");
    iconsSpan.className = "icons";
    iconsSpan.innerHTML =
      '<i class="fas fa-signal"></i><i class="fas fa-wifi"></i><i class="fas fa-battery"></i>';

    headerDiv.appendChild(clockSpan);
    headerDiv.appendChild(iconsSpan);

    return headerDiv;
  }

  private homePageAppBar(): HTMLDivElement {
    const appBarDiv = document.createElement("div");
    appBarDiv.style.padding = "8px";
    appBarDiv.className = "home-app-bar";

    // Logo section
    const logoDiv = document.createElement("div");
    logoDiv.className = "logo-added";

    const logoImg = document.createElement("img");
    logoImg.src = "/Resources/ComfortaLogo1.png";
    logoImg.style.height = "35px";

    logoDiv.appendChild(logoImg);

    // Profile section
    const profileDiv = document.createElement("div");
    profileDiv.className = "profile-section";
    profileDiv.style.display = "flex";

    // Create SVG element
    const svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");
    svg.setAttribute("width", "16");
    svg.setAttribute("height", "18");
    svg.setAttribute("viewBox", "0 0 19.422 21.363");

    const path = document.createElementNS("http://www.w3.org/2000/svg", "path");
    path.setAttribute("id", "Path_1327");
    path.setAttribute("data-name", "Path 1327");
    path.setAttribute(
      "d",
      "M15.711,5a6.8,6.8,0,0,0-3.793,12.442A9.739,9.739,0,0,0,6,26.364H7.942a7.769,7.769,0,1,1,15.537,0h1.942A9.739,9.739,0,0,0,19.5,17.442,6.8,6.8,0,0,0,15.711,5Zm0,1.942A4.855,4.855,0,1,1,10.855,11.8,4.841,4.841,0,0,1,15.711,6.942Z"
    );
    path.setAttribute("transform", "translate(-6 -5)");
    path.setAttribute("fill", "#fff");

    svg.appendChild(path);
    profileDiv.appendChild(svg);

    // Assemble the app bar
    appBarDiv.appendChild(logoDiv);
    appBarDiv.appendChild(profileDiv);

    return appBarDiv;
  }

  private otherPageAppBar(pageTitle: string = "Enter page title"): HTMLDivElement {
    const appBarDiv = document.createElement("div");
    appBarDiv.className = "app-bar";

    appBarDiv.innerHTML = `
      <svg class="content-back-button" xmlns="http://www.w3.org/2000/svg" data-name="Group 14" width="47" height="47" viewBox="0 0 47 47">
        <g id="Ellipse_6" data-name="Ellipse 6" fill="none" stroke="#262626" stroke-width="1">
          <circle cx="23.5" cy="23.5" r="23.5" stroke="none"></circle>
          <circle cx="23.5" cy="23.5" r="23" fill="none"></circle>
        </g>
        <path id="Icon_ionic-ios-arrow-round-up" data-name="Icon ionic-ios-arrow-round-up" d="M13.242,7.334a.919.919,0,0,1-1.294.007L7.667,3.073V19.336a.914.914,0,0,1-1.828,0V3.073L1.557,7.348A.925.925,0,0,1,.263,7.341.91.91,0,0,1,.27,6.054L6.106.26h0A1.026,1.026,0,0,1,6.394.07.872.872,0,0,1,6.746,0a.916.916,0,0,1,.64.26l5.836,5.794A.9.9,0,0,1,13.242,7.334Z" transform="translate(13 30.501) rotate(-90)" fill="#262626"></path>
      </svg>
      <div class="appbar-title-container">
        <h1 class="title" title="${pageTitle}" data-placeholder="Enter page title">${pageTitle}</h1>
        <div class="icon-container">
          <svg id="edit_page_title" width="14px" height="14px" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd" clip-rule="evenodd" d="M18.4324 4C18.2266 4 18.0227 4.04055 17.8325 4.11933C17.6423 4.19811 17.4695 4.31358 17.3239 4.45914L5.25659 16.5265L4.42524 19.5748L7.47353 18.7434L19.5409 6.67608C19.6864 6.53051 19.8019 6.3577 19.8807 6.16751C19.9595 5.97732 20 5.77348 20 5.56761C20 5.36175 19.9595 5.1579 19.8807 4.96771C19.8019 4.77752 19.6864 4.60471 19.5409 4.45914C19.3953 4.31358 19.2225 4.19811 19.0323 4.11933C18.8421 4.04055 18.6383 4 18.4324 4ZM17.0671 2.27157C17.5 2.09228 17.9639 2 18.4324 2C18.9009 2 19.3648 2.09228 19.7977 2.27157C20.2305 2.45086 20.6238 2.71365 20.9551 3.04493C21.2864 3.37621 21.5492 3.7695 21.7285 4.20235C21.9077 4.63519 22 5.09911 22 5.56761C22 6.03611 21.9077 6.50003 21.7285 6.93288C21.5492 7.36572 21.2864 7.75901 20.9551 8.09029L8.69996 20.3454C8.57691 20.4685 8.42387 20.5573 8.25597 20.6031L3.26314 21.9648C2.91693 22.0592 2.54667 21.9609 2.29292 21.7071C2.03917 21.4534 1.94084 21.0831 2.03526 20.7369L3.39694 15.7441C3.44273 15.5762 3.53154 15.4231 3.6546 15.3001L15.9097 3.04493C16.241 2.71365 16.6343 2.45086 17.0671 2.27157Z" fill="#5068a8"></path>
          </svg>
        </div>
      </div>
    `;

    return appBarDiv;
  }

  private body(): HTMLDivElement {
    const frameContainer = document.createElement("div");
    const translationMapper = new TranslationMapper(this.data);
    const convertedHtml = translationMapper.convertToHTML();

    frameContainer.innerHTML = convertedHtml;
    return frameContainer;
  }

  private getCurrentTime(): string {
    const now = new Date();
    return now.toLocaleTimeString("en-US", {
      hour: "numeric",
      minute: "2-digit",
      hour12: true,
    });
  }

  render(parent: HTMLDivElement) {
    parent.append(this.frame);
  }
}
