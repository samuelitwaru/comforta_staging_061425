import { Page } from "../interfaces/Page";
import { Tile } from "../interfaces/Tile";
import { TileAction } from "../interfaces/TileAction";
import { AppVersionManager } from "./AppVersionManager";
import { MapPageController } from "./MapPageController";
import { MenuPageController } from "./MenuPageController";
import { WebLinkController } from "./WebLinkController";

export class TileController {
    private version: AppVersionManager;
    tile: Tile;
    constructor(tile: Tile) {
        this.version = AppVersionManager.getInstance();
        this.tile = tile;
        console.log('tile', tile);
    }

    public navigate() {
        if (this.tile.Action.ObjectId) {
            if (this.tile.Action.ObjectType === "WebLink") {
                const webLinkController = new WebLinkController(this.tile, this.tile.Action.ObjectId);
                webLinkController.init();
            } else if (this.tile.Action.ObjectType === "Map") {
                const mapController = new MapPageController(this.tile, this.tile.Action.ObjectId);
                mapController.init();
            } else {
                const menuPageController = new MenuPageController(this.tile.Action.ObjectId);
                menuPageController.init();
            }
        }
    }
}