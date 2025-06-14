import { TileAction } from "./TileAction";

export interface Tile {
    Id: string;
    Name: string;
    Text: string;
    Color: string;
    Align: string;
    Icon: string;
    BGColor: string;
    BGImageUrl: string;
    Opacity: number;
    Action: TileAction;
    Size: number;
}