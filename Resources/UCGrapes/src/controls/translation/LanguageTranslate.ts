import { ToolBoxService } from "../../services/ToolBoxService";
import { TranslateSection } from "../../ui/components/tools-section/translate/TranslateSection";
import { TranslationodeUIManager } from "./TranslationModeUIManager";

interface ActiveVersion {
  AppVersionId: string;
  AppVersionLanguage: string;
}

export class LanguageTranslate {
  private static readonly SUPPORTED_LANGUAGES = ["en", "nl"];
  private static readonly TARGET_LANGUAGE = "nl";

  private static readonly SIDEBAR_SELECTORS = {
    SIDEBAR: "#tb-sidebar",
    TOOLS_SECTION: "#tools-section",
    PAGE_TITLE: "#page-info-title",
    MAPPING_SECTION: "#mapping-section",
    PAGE_INFO_SECTION: "#page-info-section",
  } as const;

  private readonly languages: string[];
  private readonly toolboxService: ToolBoxService;

  constructor() {
    this.languages = [...LanguageTranslate.SUPPORTED_LANGUAGES];
    this.toolboxService = new ToolBoxService();
  }

  public async translate(): Promise<void> {
    try {
      const translationContext = this.getTranslationContext();
      const filteredLanguages = this.getFilteredLanguages(translationContext.versionLanguage);

      const translateResult = await this.translateAppVersionLanguages(
        translationContext,
        filteredLanguages
      );

      if (this.isTranslationSuccessful(translateResult)) {
        await this.handleSuccessfulTranslation(translationContext);
      }
    } catch (error) {
      this.handleTranslationError(error);
    }
  }

  public async translatePage(pageId: string): Promise<void> {
    const translationContext = this.getTranslationContext();
    const translatedPageData = await this.translateSinglePage(
      pageId,
      LanguageTranslate.TARGET_LANGUAGE
    );
    this.setUpSideBar(translatedPageData.SDT_InfoContent, translationContext.versionLanguage);
  }

  private getTranslationContext(): TranslationContext {
    const activeVersion = this.getActiveVersion();
    const activePageId = this.getCurrentPageId();

    return {
      versionId: activeVersion.AppVersionId,
      versionLanguage: activeVersion.AppVersionLanguage,
      pageId: activePageId,
    };
  }

  private getActiveVersion(): ActiveVersion {
    return (globalThis as any).activeVersion as ActiveVersion;
  }

  private getCurrentPageId(): string {
    return (globalThis as any).currentPageId as string;
  }

  private getFilteredLanguages(currentLanguage: string): string[] {
    return this.languages.filter((lang) => lang !== currentLanguage);
  }

  private async translateAppVersionLanguages(
    context: TranslationContext,
    filteredLanguages: string[]
  ): Promise<any> {
    return await this.toolboxService.TranslateAppVersionLanguages(
      context.versionId,
      context.pageId,
      context.versionLanguage,
      filteredLanguages
    );
  }

  private isTranslationSuccessful(result: any): boolean {
    return result.result === "success";
  }

  private async handleSuccessfulTranslation(context: TranslationContext): Promise<void> {
    const translatedPageData = await this.translateSinglePage(
      context.pageId,
      LanguageTranslate.TARGET_LANGUAGE
    );

    this.setUpSideBar(translatedPageData.SDT_InfoContent, context.versionLanguage);
  }

  private async translateSinglePage(pageId: string, language: string): Promise<any> {
    return await this.toolboxService.TranslateSinglePage(pageId, language);
  }

  private handleTranslationError(error: unknown): void {
    throw new Error("Translation failed: " + error);
  }

  private setUpSideBar(data: any, versionLanguage: string): void {
    const sidebarElements = this.getSidebarElements();

    if (!sidebarElements.sidebar) return;

    const sidebar = sidebarElements.sidebar;
    this.increaseSidebarWidth(sidebar);

    this.enableTranslationMode();
    this.hideSidebarSections(sidebarElements);
    this.renderTranslateSection(sidebarElements.sidebar, data, versionLanguage);
    this.toggleTranslationUI();
  }

  private increaseSidebarWidth(sidebar: HTMLDivElement): void {
    const isTranslationMode = (globalThis as any).isTranslationMode;
    if (isTranslationMode) return;
    
    sidebar.style.width = sidebar.clientWidth + 70 + "px";
    sidebar.style.transition = "width 0.3s ease";
  }

  private getSidebarElements(): SidebarElements {
    return {
      sidebar: document.querySelector(
        LanguageTranslate.SIDEBAR_SELECTORS.SIDEBAR
      ) as HTMLDivElement,
      toolsSection: document.querySelector(
        LanguageTranslate.SIDEBAR_SELECTORS.TOOLS_SECTION
      ) as HTMLDivElement,
      pageTitle: document.querySelector(
        LanguageTranslate.SIDEBAR_SELECTORS.PAGE_TITLE
      ) as HTMLDivElement,
      mappingSection: document.querySelector(
        LanguageTranslate.SIDEBAR_SELECTORS.MAPPING_SECTION
      ) as HTMLDivElement,
      pageInfoSection: document.querySelector(
        LanguageTranslate.SIDEBAR_SELECTORS.PAGE_INFO_SECTION
      ) as HTMLDivElement,
    };
  }

  private hideSidebarSections(elements: SidebarElements): void {
    const sectionsToHide = [
      elements.toolsSection,
      elements.pageTitle,
      elements.mappingSection,
      elements.pageInfoSection,
    ];

    sectionsToHide.forEach((section) => {
      if (section) {
        section.style.display = "none";
      }
    });
  }

  private renderTranslateSection(
    sidebar: HTMLDivElement,
    data: any,
    versionLanguage: string
  ): void {
    const translateSection = new TranslateSection(data, versionLanguage);
    translateSection.render(sidebar);
  }

  private toggleTranslationUI(): void {
    const translationModeUI = this.createTranslationModeUI();
    translationModeUI.toggleSidebar();
  }

  private enableTranslationMode(): void {
    const activeEditor = this.getActiveEditor();

    if (!activeEditor) return;

    this.setTranslationModeState(true);
    const translationModeUI = this.createTranslationModeUI();
    translationModeUI.enableTranslationMode();
  }

  private getActiveEditor(): any {
    return (globalThis as any).activeEditor;
  }

  private setTranslationModeState(isEnabled: boolean): void {
    (globalThis as any).isTranslationMode = isEnabled;
  }

  private createTranslationModeUI(): TranslationodeUIManager {
    return new TranslationodeUIManager();
  }
}

interface TranslationContext {
  versionId: string;
  versionLanguage: string;
  pageId: string;
}

interface SidebarElements {
  sidebar: HTMLDivElement | null;
  toolsSection: HTMLDivElement | null;
  pageTitle: HTMLDivElement | null;
  mappingSection: HTMLDivElement | null;
  pageInfoSection: HTMLDivElement | null;
}
