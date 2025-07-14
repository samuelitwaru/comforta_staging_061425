import { TranslateFrame } from "./TranslateFrame";
import { TranslationodeUIManager } from "../../../../controls/translation/TranslationModeUIManager";
import { i18n } from "../../../../i18n/i18n";
import { TranslationStructure } from "../../../../types";

interface Language {
  code: string;
  label: string;
  flag: string;
}

export class TranslateSection {
  private static readonly SECTION_IDS = {
    TRANSLATE_SECTION: "translate-page-section",
    MENU_SECTION: "menu-page-section",
    TREE_SECTION: "tree-view-section",
    CONTENT_SECTION: "content-page-section",
    TRANSLATE_BUTTON: "translateBtn",
    LANGUAGE_SELECTION: "tb-custom-language-selection",
  } as const;

  private static readonly CSS_CLASSES = {
    TRANSLATE_SECTION: "translate-page-section",
    THEME_SELECTION: "tb-custom-theme-selection",
    SELECT_BUTTON: "theme-select-button",
    SELECTED_LANGUAGE: "selected-theme-language",
    OPTIONS_LIST: "theme-options-list",
    THEME_OPTION: "theme-option",
    THEME: "theme",
    CLOSE_BUTTON: "translate-close-button",
    LANGUAGE_FLAG: "language-flag",
    LANGUAGE_LABEL: "language-label",
  } as const;

  private static readonly LANGUAGES: Language[] = [
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

  private readonly container: HTMLDivElement;
  private readonly languageList: Language[];
  private readonly data: TranslationStructure;
  private readonly versionLanguage: string;

  private selectedLanguageSpan!: HTMLSpanElement;
  private languageDropDown!: HTMLDivElement;
  private selectButton!: HTMLButtonElement;

  private selectedLanguageCode!: string;

  constructor(data: TranslationStructure, versionLanguage: string) {
    this.data = data;
    this.versionLanguage = versionLanguage;
    this.languageList = [...TranslateSection.LANGUAGES];
    this.container = this.createElement("div");
    this.initializeComponent();
  }

  private createElement<T extends keyof HTMLElementTagNameMap>(
    tagName: T
  ): HTMLElementTagNameMap[T] {
    return document.createElement(tagName);
  }

  private initializeComponent(): void {
    this.hideSidebarSections();
    this.setupContainer();
    this.setupHeaderSection();
    this.setDefaultLanguage();
    this.setupTranslateFrame();
  }

  private setupContainer(): void {
    this.container.id = TranslateSection.SECTION_IDS.TRANSLATE_SECTION;
    this.container.classList.add(TranslateSection.CSS_CLASSES.TRANSLATE_SECTION);
    this.container.style.marginTop = "10px";
    this.container.style.position = "relative";
  }

  private setupHeaderSection(): void {
    const headerSection = this.createHeaderSection();
    const languageDropdown = this.createLanguageDropdown();

    const translateButton = this.createElement("button");
    translateButton.id = "translateBtn";
    translateButton.className = "btn-transparent";
    translateButton.title = `${i18n.t("translate")}`;
    translateButton.innerHTML = this.getTranslateSvg();
    const closeButton = this.createCloseButton();

    // headerSection.appendChild(translateButton);
    headerSection.appendChild(languageDropdown);
    // headerSection.appendChild(closeButton);
    this.container.appendChild(closeButton);
  }

  private createHeaderSection(): HTMLDivElement {
    const headerSection = this.createElement("div");
    this.applyHeaderStyles(headerSection);
    return headerSection;
  }

  private applyHeaderStyles(element: HTMLDivElement): void {
    Object.assign(element.style, {
      display: "flex",
      justifyContent: "space-between",
      alignItems: "center",
      borderBottom: "1px #9f9d9d solid",
      paddingBottom: "12px",
      marginBottom: "40px",
    });
  }

  private setupTranslateFrame(): void {
    const pageId = (globalThis as any).currentPageId;
    // language code
    const frame = new TranslateFrame(this.data, pageId, this.selectedLanguageCode);
    frame.render(this.container);
  }

  private setDefaultLanguage(): void {
    const availableLanguages = this.getAvailableLanguages();
    const defaultLanguage = availableLanguages[0];

    if (defaultLanguage) {
      this.setSelectedLanguage(defaultLanguage);
    }
  }

  private getAvailableLanguages(): Language[] {
    return this.languageList.filter((lang) => lang.code !== this.versionLanguage);
  }

  private createCloseButton(): HTMLSpanElement {
    const closeButton = this.createElement("span");
    closeButton.className = TranslateSection.CSS_CLASSES.CLOSE_BUTTON;
    closeButton.style.cursor = "pointer";
    closeButton.style.position = "absolute";
    closeButton.style.right = "0";
    closeButton.innerHTML = this.getCloseButtonSvg();
    closeButton.setAttribute("aria-label", "Close translate section");

    closeButton.addEventListener("click", this.handleCloseButtonClick.bind(this));

    return closeButton;
  }

  private getCloseButtonSvg(): string {
    return `
    <svg xmlns="http://www.w3.org/2000/svg" id="Group_456" data-name="Group 456" width="12" height="12" viewBox="0 0 8.059 8.059">
      <path id="Линия_201" data-name="Линия 201" d="M7.013,7.559a.544.544,0,0,1-.386-.16L-.34.431A.546.546,0,1,1,.432-.34L7.4,6.627a.546.546,0,0,1-.386.931Z" transform="translate(0.5 0.5)" fill="#bdbdbd"/>
      <path id="Линия_202" data-name="Линия 202" d="M.046,7.559A.544.544,0,0,1-.34,7.4a.546.546,0,0,1,0-.772L6.628-.34A.546.546,0,0,1,7.4.431L.432,7.4A.544.544,0,0,1,.046,7.559Z" transform="translate(0.5 0.5)" fill="#bdbdbd"/>
    </svg>
    `;
  }

  private handleCloseButtonClick(): void {
    this.disableTranslationMode();
    this.resetTranslateButtonIcon();
  }

  private disableTranslationMode(): void {
    (globalThis as any).isTranslationMode = false;
    const translationModeUI = new TranslationodeUIManager();
    translationModeUI.disableTranslationMode();
    translationModeUI.toggleSidebar();
  }

  private resetTranslateButtonIcon(): void {
    const translateButton = document.getElementById(
      TranslateSection.SECTION_IDS.TRANSLATE_BUTTON
    ) as HTMLButtonElement;
    const svg = translateButton?.querySelector("svg");
    const path = svg?.querySelector("path");

    if (path) {
      path.setAttribute("fill", "#7c8791");
    }
  }

  private createLanguageDropdown(): HTMLDivElement {
    const dropdownContainer = this.createElement("div");

    this.selectButton = this.createElement("button");
    this.selectedLanguageSpan = this.createElement("span");
    this.languageDropDown = this.createDropdownList();

    this.setupDropdownContainer(dropdownContainer);
    this.setupSelectButton();
    this.setupSelectedLanguageSpan();
    this.setupDropdownEventListeners(dropdownContainer);

    this.selectButton.appendChild(this.selectedLanguageSpan);
    dropdownContainer.appendChild(this.selectButton);
    dropdownContainer.appendChild(this.languageDropDown);

    return dropdownContainer;
  }

  public getLanguageSelectionElement(): HTMLDivElement {
    return this.createLanguageDropdown();
  }

  private setupDropdownContainer(container: HTMLDivElement): void {
    container.className = TranslateSection.CSS_CLASSES.THEME_SELECTION;
    container.id = TranslateSection.SECTION_IDS.LANGUAGE_SELECTION;
  }

  private setupSelectButton(): void {
    this.selectButton.className = TranslateSection.CSS_CLASSES.SELECT_BUTTON;

    const translateButton = this.createElement("button");
    translateButton.id = "translateBtn";
    translateButton.className = "btn-transparent";
    translateButton.title = `${i18n.t("translate")}`;
    translateButton.innerHTML = this.getTranslateSvg();
    this.selectButton.appendChild(translateButton);

    this.selectButton.addEventListener("click", this.handleSelectButtonClick.bind(this));
  }

  private setupSelectedLanguageSpan(): void {
    this.selectedLanguageSpan.className = TranslateSection.CSS_CLASSES.SELECTED_LANGUAGE;

    Object.assign(this.selectedLanguageSpan.style, {
      display: "flex",
      alignItems: "center",
      gap: "0.3rem",
    });
  }

  private setupDropdownEventListeners(container: HTMLDivElement): void {
    document.addEventListener("click", (e) => {
      if (!container.contains(e.target as Node)) {
        this.hideDropdown();
      }
    });
  }

  private handleSelectButtonClick(e: Event): void {
    e.preventDefault();
    this.toggleDropdown();
  }

  private createDropdownList(): HTMLDivElement {
    const dropdown = this.createElement("div");
    dropdown.classList.add(TranslateSection.CSS_CLASSES.OPTIONS_LIST);
    dropdown.style.display = "none";

    const availableLanguages = this.getAvailableLanguages();
    availableLanguages.forEach((language) => {
      const option = this.createLanguageOption(language);
      dropdown.appendChild(option);
    });

    return dropdown;
  }

  private createLanguageOption(language: Language): HTMLDivElement {
    const option = this.createElement("div");
    option.classList.add(
      TranslateSection.CSS_CLASSES.THEME_OPTION,
      TranslateSection.CSS_CLASSES.THEME
    );

    this.applyOptionStyles(option);
    this.setOptionAttributes(option, language.code);

    const flagSpan = this.createLanguageFlag(language.flag);
    const labelSpan = this.createLanguageLabel(language.label);

    option.appendChild(flagSpan);
    option.appendChild(labelSpan);

    option.addEventListener("click", () => this.handleLanguageSelection(language));

    return option;
  }

  private applyOptionStyles(option: HTMLDivElement): void {
    Object.assign(option.style, {
      padding: "6px",
      justifyContent: "flex-start",
      gap: "0.4rem",
    });
  }

  private setOptionAttributes(option: HTMLDivElement, languageCode: string) {
    option.setAttribute("role", "option");
    option.setAttribute("data-value", languageCode);

    return languageCode;
  }

  private createLanguageFlag(flagSvg: string): HTMLSpanElement {
    const flagSpan = this.createElement("span");
    flagSpan.className = TranslateSection.CSS_CLASSES.LANGUAGE_FLAG;

    Object.assign(flagSpan.style, {
      display: "inline-block",
      height: "24px",
    });

    flagSpan.innerHTML = flagSvg;
    return flagSpan;
  }

  private createLanguageLabel(labelText: string): HTMLSpanElement {
    const labelSpan = this.createElement("span");
    labelSpan.className = TranslateSection.CSS_CLASSES.LANGUAGE_LABEL;

    Object.assign(labelSpan.style, {
      display: "inline-block",
      height: "24px",
    });

    labelSpan.textContent = labelText;
    return labelSpan;
  }

  private handleLanguageSelection(language: Language): void {
    this.setSelectedLanguage(language);
    this.hideDropdown();
  }

  private toggleDropdown(): void {
    const isOpen = this.selectButton.classList.contains("open");

    if (isOpen) {
      this.hideDropdown();
    } else {
      this.showDropdown();
    }
  }

  private showDropdown(): void {
    this.selectButton.classList.add("open");
    this.languageDropDown.style.display = "block";
  }

  private hideDropdown(): void {
    this.selectButton.classList.remove("open");
    this.languageDropDown.style.display = "none";
  }

  private setSelectedLanguage(language: Language): void {
    this.selectedLanguageSpan.innerHTML = "";

    const flagSpan = this.createLanguageFlag(language.flag);

    this.selectedLanguageSpan.appendChild(flagSpan);

    this.selectedLanguageCode = language.code;
  }

  private hideSidebarSections(): void {
    const sectionsToHide = [
      TranslateSection.SECTION_IDS.MENU_SECTION,
      TranslateSection.SECTION_IDS.CONTENT_SECTION,
      TranslateSection.SECTION_IDS.TRANSLATE_SECTION,
      TranslateSection.SECTION_IDS.TREE_SECTION,
    ];

    sectionsToHide.forEach((sectionId) => {
      const section = document.getElementById(sectionId);
      if (section) {
        section.style.display = "none";
      }
    });
  }

  private getTranslateSvg(): string {
    return `
    <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 21 21">
      <path id="Translation" d="M5.33.066a.725.725,0,0,0-.055,1.3c.148.078.193.083.826.083.728,0,.818-.019,1-.2A.71.71,0,0,0,7.146.259C6.944.029,6.834,0,6.112,0A1.94,1.94,0,0,0,5.33.066M.46,2.986a.7.7,0,0,0-.37.354.671.671,0,0,0-.023.612.887.887,0,0,0,.471.419c.06.012,2.021.021,4.357.021H9.141l-.6.895-.6.894-.916.912-.916.912-.992-.994C4.574,6.464,4.069,5.987,4,5.948a.786.786,0,0,0-.868.15.816.816,0,0,0-.15.762A15.436,15.436,0,0,0,4.049,8L5.084,9.033,3.555,10.564c-1.614,1.618-1.606,1.609-1.605,1.923a.82.82,0,0,0,.449.642.835.835,0,0,0,.6-.02a20.971,20.971,0,0,0,1.63-1.558L6.112,10.06l1.523,1.521c.838.837,1.568,1.539,1.623,1.559a.886.886,0,0,0,.574-.029.729.729,0,0,0,.339-1c-.025-.048-.717-.761-1.538-1.584l-1.493-1.5L8.168,8,9.2,6.961l.848-1.283.849-1.284h.872c.842,0,.876,0,1.027-.083a.686.686,0,0,0,.378-.6.68.68,0,0,0-.3-.645l-.153-.106L6.631,2.949c-4.961-.008-6.1,0-6.171.037m14.669,6.83c-.277.11-.2-.028-2.836,5.242-2.3,4.6-2.514,5.042-2.511,5.2a.7.7,0,0,0,.192.51.707.707,0,0,0,1.074-.021c.065-.074.5-.9.992-1.883l.874-1.75h4.961l.912,1.822c.965,1.927.97,1.935,1.264,2.034A.736.736,0,0,0,21,20.174c-.012-.093-.886-1.879-2.5-5.107-1.9-3.8-2.511-4.994-2.606-5.087a.782.782,0,0,0-.763-.164m1.981,5.778c0,.015-.772.027-1.717.027s-1.719-.008-1.719-.018.387-.791.86-1.736l.859-1.718.857,1.71c.472.94.859,1.721.86,1.735" transform="translate(-0.004 -0.002)" fill="#7c8791" fill-rule="evenodd"/>
    </svg>`;
  }

  public render(container: HTMLDivElement): void {
    this.removeExistingTranslateSection();
    container.appendChild(this.container);
  }

  private removeExistingTranslateSection(): void {
    const existingSection = document.getElementById(TranslateSection.SECTION_IDS.TRANSLATE_SECTION);
    if (existingSection) {
      existingSection.remove();
    }
  }
}
