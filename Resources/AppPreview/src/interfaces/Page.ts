import { PageContentStructure } from "./PageContentStructure";
import { PageInfoContentStructure } from "./PageInfoContentStructure";
import { PageMenuStructure } from "./PageMenuStructure";

export interface Page {
    PageId: string;
    PageName: string;
    PageType: string;
    PageStructure: string;
    PageMenuStructure: PageMenuStructure;
    PageContentStructure: PageContentStructure;
    PageInfoStructure: PageInfoContentStructure
}