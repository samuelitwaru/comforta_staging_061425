import { AppVersion } from "../interfaces/AppVersion";
import { Page } from "../interfaces/Page";
import { PageContentStructure } from "../interfaces/PageContentStructure";
import { PageMenuStructure } from "../interfaces/PageMenuStructure";
import { SDT_Theme } from "../interfaces/SDT_Theme";

export class AppVersionManager {
    private static instance: AppVersionManager | null = null;
    private _appVersion: AppVersion | null = null;
    private _isInitialized: boolean = false;

    private constructor() {}

    public static getInstance(): AppVersionManager {
        if (!AppVersionManager.instance) {
            AppVersionManager.instance = new AppVersionManager();
        }
        return AppVersionManager.instance;
    }

    public init(
        appVersion: AppVersion | null,
      ): void {
        if (this._isInitialized) {
          console.warn("AppConfig already initialized - ignoring new data");
          return;
        }
        this._appVersion = appVersion
        this._isInitialized = true;
        this.initialiseTheme();
      }

      
    private initialiseTheme(): void {
        document.body.style.fontFamily = this.theme?.ThemeFontFamily || "Roboto";
    }
    get pages(): Page[] | null {
        return this._appVersion?.Pages || null;
    } 

    get OrganisationLogo(): string | null {
        return this._appVersion?.OrganisationLogo || null;
    } 
    get theme(): SDT_Theme | null {
        return this._appVersion?.SDT_Theme || null;
    } 

    get homePage(): Page | null {
        return this.pages?.find(page => page.PageName === 'Home') || null;
    }

    getPage(pageId: string): Page | null {
        return this.pages?.find(page => page.PageId === pageId) || null;
    }

    pageContentStructure(pageId: string): PageContentStructure | undefined {
        return this.pages?.find(page => page.PageId === pageId)?.PageContentStructure;
    }

    pageMenuStructure(pageId: string): PageMenuStructure| undefined {
        return this.pages?.find(page => page.PageId === pageId)?.PageMenuStructure;
    }

    tileParentPage(tileId: string): Page | null {
        for (const page of this.pages || []) {
            if (page.PageMenuStructure?.Rows) {
                let found = false;
                for (const row of page.PageMenuStructure.Rows) {
                    if (row.Tiles) {
                        for (const tile of row.Tiles) {
                            if (tile.Id === tileId) {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (found) {
                        break;
                    }
                }
                if (found) {
                    return page;
                }
            }
        }
        return null;
    }
}