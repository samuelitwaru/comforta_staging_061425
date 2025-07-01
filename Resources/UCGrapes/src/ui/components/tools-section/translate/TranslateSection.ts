import { drop } from "lodash";
import { IconListCategories } from "../icon-list/IconListCategories";
import { ThemeSection } from "../ThemeSection";
import { TileImgSection } from "../TileImgSection";
import { TitleSection } from "../TitleSection";
import { TranslateFrame } from "./TranslateFrame";

export class TranslateSection {
  container: HTMLDivElement;
  languageList: { code: string; label: string; flag: string }[];
  private selectedLanguageSpan!: HTMLSpanElement;
  private languageDropDown!: HTMLDivElement;
  private selectButton!: HTMLButtonElement;
  private data: any

  constructor(data: any) {
    this.data = data;
    this.languageList = [
      {
        code: "en",
        label: "English",
        flag: `<svg xmlns="http://www.w3.org/2000/svg" id="Group_2517" data-name="Group 2517" width="18" height="18" viewBox="0 0 18 18"><path id="Path_2463" data-name="Path 2463" d="M13.366,4.656A8.994,8.994,0,0,0,8.757,7.542l4.609,2.818Z" transform="translate(-6.616 -4.361)" fill="#3f51b5"/><path id="Path_2464" data-name="Path 2464" d="M8.6,33.269a9,9,0,0,0,4.678,2.961V30.41Z" transform="translate(-6.533 -18.526)" fill="#3f51b5"/><path id="Path_2465" data-name="Path 2465" d="M4.656,29c.006.023.012.046.018.07L4.787,29Z" transform="translate(-4.361 -17.75)" fill="#fff"/><path id="Path_2466" data-name="Path 2466" d="M33.759,7.722A9,9,0,0,0,29,4.656v5.975Z" transform="translate(-17.75 -4.361)" fill="#3f51b5"/><path id="Path_2467" data-name="Path 2467" d="M29,35.9a8.994,8.994,0,0,0,4.82-3.147L29,29.8Z" transform="translate(-17.75 -18.192)" fill="#3f51b5"/><path id="Path_2468" data-name="Path 2468" d="M4.7,18.621c-.016.056-.029.114-.044.171h.323Z" transform="translate(-4.361 -12.042)" fill="#fff"/><path id="Path_2469" data-name="Path 2469" d="M41.876,19.978q-.064-.425-.167-.836l-1.368.836Z" transform="translate(-23.988 -12.328)" fill="#fff"/><path id="Path_2470" data-name="Path 2470" d="M4.755,19H4.432a9,9,0,0,0-.183.9H6.227Z" transform="translate(-4.137 -12.25)" fill="#fff"/><path id="Path_2471" data-name="Path 2471" d="M41.974,27.733c.057-.241.1-.486.14-.733h-1.34Z" transform="translate(-24.226 -16.65)" fill="#fff"/><path id="Path_2472" data-name="Path 2472" d="M6.036,27H4.249a8.877,8.877,0,0,0,.183.9h.132Z" transform="translate(-4.137 -16.65)" fill="#fff"/><path id="Path_2473" data-name="Path 2473" d="M19.9,10.686V4.249a8.876,8.876,0,0,0-.9.183v5.7Z" transform="translate(-12.25 -4.137)" fill="#fff"/><path id="Path_2474" data-name="Path 2474" d="M27,28.582v6.826a8.877,8.877,0,0,0,.9-.183V29.132Z" transform="translate(-16.65 -17.52)" fill="#fff"/><path id="Path_2475" data-name="Path 2475" d="M19,29.738v5.82a9,9,0,0,0,.9.183V29.188Z" transform="translate(-12.25 -17.853)" fill="#fff"/><path id="Path_2476" data-name="Path 2476" d="M27.083,10.749l.128.078.689-.421V4.432a9,9,0,0,0-.9-.183v6.637Z" transform="translate(-16.65 -4.137)" fill="#fff"/><path id="Path_2477" data-name="Path 2477" d="M6.5,15.538h4.225l1.334-.815v-.285l-.9-.55L6.554,11.069a9.042,9.042,0,0,0-1.016,1.466l3.4,2.1H6.481L5,13.717q-.139.369-.247.751l.279.171Z" transform="translate(-4.414 -7.888)" fill="#fff"/><path id="Path_2478" data-name="Path 2478" d="M27.469,14.8l1.57.959h4.223l1.368-.836a8.9,8.9,0,0,0-.6-1.679l-2.593,1.616H28.978l4.415-2.745c-.149-.222-.309-.436-.477-.644l-4.759,2.908Z" transform="translate(-16.908 -8.108)" fill="#fff"/><path id="Path_2479" data-name="Path 2479" d="M9.239,16.429l-3.4-2.1A8.935,8.935,0,0,0,5.3,15.508l1.481.921Z" transform="translate(-4.716 -9.679)" fill="#e53935"/><path id="Path_2480" data-name="Path 2480" d="M33.277,15.646l2.593-1.615a8.956,8.956,0,0,0-.633-1.129l-4.416,2.745Z" transform="translate(-18.752 -8.896)" fill="#e53935"/><path id="Path_2481" data-name="Path 2481" d="M27,27v.712l.9.55,4.82,2.946a9,9,0,0,0,.916-1.417L30.587,27.9h2.455l1.107.69a8.83,8.83,0,0,0,.249-.857L33.2,27Z" transform="translate(-16.65 -16.65)" fill="#fff"/><path id="Path_2482" data-name="Path 2482" d="M28.781,19.732l-1.57-.959-.128-.078L27,18.83v.9Z" transform="translate(-16.65 -12.082)" fill="#fff"/><path id="Path_2483" data-name="Path 2483" d="M12.032,27.985V27H6.281l-1.472.9-.114.07a8.927,8.927,0,0,0,.645,1.7L8.13,27.9h2.455L6,30.795c.143.205.292.407.451.6l4.678-2.859Z" transform="translate(-4.382 -16.65)" fill="#fff"/><path id="Path_2484" data-name="Path 2484" d="M18.035,20h1.334v-.815Z" transform="translate(-11.719 -12.353)" fill="#fff"/><path id="Path_2485" data-name="Path 2485" d="M34.971,29l3.049,1.89a8.944,8.944,0,0,0,.513-1.2L37.426,29Z" transform="translate(-21.034 -17.75)" fill="#e53935"/><path id="Path_2486" data-name="Path 2486" d="M8.918,29l-2.79,1.773a8.97,8.97,0,0,0,.664,1.121L11.374,29Z" transform="translate(-5.17 -17.75)" fill="#e53935"/><path id="Path_2487" data-name="Path 2487" d="M28.781,21H27v2.7h7.538a8.188,8.188,0,0,0,0-2.7H28.781Z" transform="translate(-16.65 -13.35)" fill="#e53935"/><path id="Path_2488" data-name="Path 2488" d="M11.65,23.7V21H4.112a8.189,8.189,0,0,0,0,2.7H11.65Z" transform="translate(-4 -13.35)" fill="#e53935"/><path id="Path_2489" data-name="Path 2489" d="M23.7,21.888V4.112a8.189,8.189,0,0,0-2.7,0V21.888a8.189,8.189,0,0,0,2.7,0Z" transform="translate(-13.35 -4)" fill="#e53935"/></svg>`,
      },
      {
        code: "nl",
        label: "Nederlands",
        flag: `<svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 18 18"><g id="Group_2534" data-name="Group 2534" transform="translate(-4 -4)"><path id="Path_2500" data-name="Path 2500" d="M22.128,31H5.284a8.988,8.988,0,0,0,16.844,0Z" transform="translate(-0.706 -14.85)" fill="#3f51b5"/><path id="Path_2501" data-name="Path 2501" d="M13.706,4A9,9,0,0,0,5.284,9.85H22.128A8.994,8.994,0,0,0,13.706,4Z" transform="translate(-0.706)" fill="#ff3d00"/><path id="Path_2502" data-name="Path 2502" d="M22,20.15A8.966,8.966,0,0,0,21.422,17H4.578a8.875,8.875,0,0,0,0,6.3H21.422A8.956,8.956,0,0,0,22,20.15Z" transform="translate(0 -7.15)" fill="#eceff1"/></g></svg>`,
      },
    ];
    this.container = document.createElement("div");
    this.init();
  }

  init() {
    this.toggleSideBar();
    this.container.id = "translate-page-section";
    this.container.classList.add("translate-page-section");

    const dropDown = this.setUpLanguageDropdown();

    // Add X button
    const xButton = this.createXButton();

    const headerSection = document.createElement("div");
    headerSection.style.display = "flex";
    headerSection.style.justifyContent = "space-between";
    headerSection.style.alignItems = "center";
    headerSection.style.borderBottom = "1px #9f9d9d solid";
    headerSection.style.paddingBottom = "12px";
    headerSection.style.marginBottom = "40px";

    headerSection.appendChild(dropDown);
    headerSection.appendChild(xButton);

    this.container.appendChild(headerSection);
    const frame = new TranslateFrame(this.data);
    frame.render(this.container);

    // Set default selected language
    this.setSelectedLanguage(this.languageList[0]);
  }

  private createXButton(): HTMLSpanElement {
    const xButton = document.createElement("span");
    xButton.className = "translate-close-button";
    xButton.innerHTML = `
    <svg xmlns="http://www.w3.org/2000/svg" id="Group_456" data-name="Group 456" width="12" height="12" viewBox="0 0 8.059 8.059">
      <path id="Линия_201" data-name="Линия 201" d="M7.013,7.559a.544.544,0,0,1-.386-.16L-.34.431A.546.546,0,1,1,.432-.34L7.4,6.627a.546.546,0,0,1-.386.931Z" transform="translate(0.5 0.5)" fill="#bdbdbd"/>
      <path id="Линия_202" data-name="Линия 202" d="M.046,7.559A.544.544,0,0,1-.34,7.4a.546.546,0,0,1,0-.772L6.628-.34A.546.546,0,0,1,7.4.431L.432,7.4A.544.544,0,0,1,.046,7.559Z" transform="translate(0.5 0.5)" fill="#bdbdbd"/>
    </svg>
    `;
    xButton.setAttribute("aria-label", "Close translate section");

    xButton.addEventListener("click", () => {
      console.log("X button clicked - closing translate section");
      // You can add additional close functionality here
      // this.container.remove();
    });

    return xButton;
  }

  private setUpLanguageDropdown(): HTMLDivElement {
    const languageDropDownEl = document.createElement("div");
    this.selectButton = document.createElement("button");
    this.selectedLanguageSpan = document.createElement("span");
    this.languageDropDown = this.setDropDownList();

    languageDropDownEl.className = "tb-custom-theme-selection";
    languageDropDownEl.id = "tb-custom-language-selection";
    this.selectButton.className = "theme-select-button";
    this.selectedLanguageSpan.className = "selected-theme-language";
    this.selectedLanguageSpan.style.display = "flex";
    this.selectedLanguageSpan.style.alignItems = "center";
    this.selectedLanguageSpan.style.gap = "0.3rem";

    this.selectButton.appendChild(this.selectedLanguageSpan);

    // Add click event to toggle dropdown
    this.selectButton.addEventListener("click", (e) => {
      e.preventDefault();
      this.toggleDropdown();
    });

    // Close dropdown when clicking outside
    document.addEventListener("click", (e) => {
      if (!languageDropDownEl.contains(e.target as Node)) {
        this.hideDropdown();
      }
    });

    languageDropDownEl.appendChild(this.selectButton);
    languageDropDownEl.appendChild(this.languageDropDown);

    return languageDropDownEl;
  }

  private setDropDownList(): HTMLDivElement {
    const languageDropDown = document.createElement("div");
    languageDropDown.classList.add("theme-options-list");
    languageDropDown.style.display = "none"; // Initially hidden

    this.languageList.forEach((item: { code: string; label: string; flag: string }) => {
      const option = document.createElement("div");
      option.classList.add("theme-option", "theme");
      option.style.padding = "6px";
      option.style.justifyContent = "flex-start";
      option.style.gap = "0.4rem";
      option.setAttribute("role", "option");
      option.setAttribute("data-value", item.code);

      // Create flag and label elements
      const flagSpan = document.createElement("span");
      flagSpan.className = "language-flag";
      flagSpan.style.display = "inline-block";
      flagSpan.style.height = "24px";
      flagSpan.innerHTML = item.flag;

      const labelSpan = document.createElement("span");
      labelSpan.className = "language-label";
      labelSpan.style.display = "inline-block";
      labelSpan.style.height = "24px";
      labelSpan.textContent = item.label;

      option.appendChild(flagSpan);
      option.appendChild(labelSpan);

      // Add click event for language selection
      option.addEventListener("click", () => {
        this.setSelectedLanguage(item);
        this.hideDropdown();
      });

      languageDropDown.appendChild(option);
    });

    return languageDropDown;
  }

  private toggleDropdown() {
    const isOpen = this.selectButton.classList.contains("open");
    if (isOpen) {
      this.hideDropdown();
    } else {
      this.showDropdown();
    }
  }

  private showDropdown() {
    this.selectButton.classList.add("open");
    this.languageDropDown.style.display = "block";
  }

  private hideDropdown() {
    this.selectButton.classList.remove("open");
    this.languageDropDown.style.display = "none";
  }

  private setSelectedLanguage(language: { code: string; label: string; flag: string }) {
    // Clear existing content
    this.selectedLanguageSpan.innerHTML = "";

    // Create flag and label elements for selected language
    const flagSpan = document.createElement("span");
    flagSpan.className = "language-flag";
    flagSpan.innerHTML = language.flag;

    const labelSpan = document.createElement("span");
    labelSpan.className = "language-label";
    labelSpan.textContent = language.label;

    this.selectedLanguageSpan.appendChild(flagSpan);
    this.selectedLanguageSpan.appendChild(labelSpan);
  }

  private toggleSideBar() {
    const menuSection = document.getElementById("menu-page-section");
    const ctaSection = document.getElementById("content-page-section");
    const translationSection = document.getElementById("translate-page-section");
    if (menuSection) {
      menuSection.style.display = "none";
    }
    if (ctaSection) {
      ctaSection.style.display = "none";
    }
    if (translationSection) {
      translationSection.style.display = "none";
    }
  }

  render(container: HTMLDivElement) {
    const existingTranslateSection = document.getElementById("translate-page-section");
    if (existingTranslateSection) {
      existingTranslateSection.remove();
    }
    container.appendChild(this.container);
  }
}
