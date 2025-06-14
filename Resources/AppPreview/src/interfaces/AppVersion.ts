import { Page } from "./Page";

export interface AppVersion {
    AppVersionId: string;
    AppVersionName: string;
    IsActive: boolean;
    Pages: Page[];
    SDT_Theme: any;
    OrganisationLogo :string;
}