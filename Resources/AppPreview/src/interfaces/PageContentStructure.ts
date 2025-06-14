import { Content } from "./Content";
import { Cta } from "./Cta";
import { CtaAttributes } from "./CtaAttributes";

export interface PageContentStructure {
    Content: Content[];
    Cta: CtaAttributes[];
}