import { CtaAttributes } from "./CtaAttributes";
import { Image } from "./Image";
import { Tile } from "./Tile";

export interface InfoType {
  InfoId: string;
  InfoType: string;
  InfoValue?: string;
  CtaAttributes?: CtaAttributes;
  Tiles?:Tile[];
  Images?: Image[];
}
