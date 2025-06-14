import { ThemeManager } from "../controls/ThemeManager";
import { TileController } from "../controls/TileController";
import { NavigationData } from "../interfaces/Navigation";
import { Tile } from "../interfaces/Tile";


export class TileComponent {
    tile: Tile;
    pageId: string;
    tileContainer: HTMLElement;
    isHighPriority: boolean;
    themeManager: any;
    rowTileLength: number;

    constructor(tile: Tile, isHighPriority: boolean = false, pageId: string, rowTileLength: number) {
        this.tile = tile;
        this.pageId = pageId;
        this.isHighPriority = isHighPriority;
        this.rowTileLength = rowTileLength;
        this.themeManager = new ThemeManager();
        this.tileContainer = document.createElement("div");
        this.init();
    }

    private init() {
        // Apply appropriate CSS class based on priority
        this.tileContainer.classList.add("tbap-tile");
        if (this.isHighPriority) {
            // this.tileContainer.classList.add("high-priority-tile");
            const sizeFactor = this.tile.Size || 80;
            // console.log(`size ${sizeFactor}`)
            this.tileContainer.style.height = `${sizeFactor}px`  
        }

        // Set alignment
        const align = this.tile.Align === "left" ? "start" : "center";
        this.tileContainer.style.justifyContent = align;
        this.tileContainer.style.alignItems = align;

        // Set background
        if (this.tile.BGImageUrl) {
            this.tileContainer.style.backgroundImage = `url(${this.tile.BGImageUrl})`;
            this.tileContainer.style.backgroundColor = `rgba(0,0,0, ${this.tile.Opacity / 100})`;
            this.tileContainer.style.backgroundBlendMode = "overlay";
            this.tileContainer.style.backgroundPosition = "center";
            this.tileContainer.style.backgroundSize = "cover"
        } else if (this.tile.BGColor) {
            this.tileContainer.style.backgroundColor = this.themeManager.getThemeColor(this.tile.BGColor);
        }

        // Create and add icon
        const icon = document.createElement("div");
        icon.classList.add("tile-icon");
        icon.style.color = this.tile.Color;
        if (this.tile.Icon) {
            icon.innerHTML = this.themeManager.getThemeIcon(this.tile.Icon);

            const path = icon.querySelector("path");
            if (path) {
                path.setAttribute("fill", this.tile.Color);
            }
        }

        // Create and add title
        const title = document.createElement("div");
        title.classList.add("tile-title");
        title.style.color = this.tile.Color;
        title.style.textAlign = this.tile.Align;
        if (this.tile.Text) {
            title.innerHTML = this.wrapTileTitle(this.tile.Text);
        }
        if (this.isHighPriority) {
            title.style.textTransform = "uppercase"
        }

        // Add the elements to the container
        this.tileContainer.appendChild(icon);
        this.tileContainer.appendChild(title);

        // Add click event handler
        this.tileContainer.addEventListener("click", (e) => {
            e.preventDefault();
            if (this.tile.Action.ObjectId) {
                const tileController = new TileController(this.tile);
                this.updateNavigationChain();
                tileController.navigate();
            }
        });
    }

    private wrapTileTitle(title: any) {        
        if (this.rowTileLength === 3) {
            const words = title.split(" ");
            if (words.length > 1) {
                return words[0] + "<br>" + words[1];
            }
            return title.replace("<br>", "");
        }
        return title;
    }

    updateNavigationChain(): void {
        try {
            const navData: NavigationData = JSON.parse(localStorage.getItem("navigation") || '{"history":[]}');
    
            if (!this.tile || !this.tile.Id || !this.tile.Action || !this.tile.Action.ObjectId) {
                console.error("Tile or required properties are missing");
                return;
            }
            const level = navData.history.length;
    
            navData.history.push({
                pageId: this.pageId,
                tileId: this.tile.Id,
                targetId: this.tile.Action.ObjectId,
                level: level,
            });
    
            localStorage.setItem("navigation", JSON.stringify(navData));
        } catch (error) {
            console.error("Error updating navigation chain:", error);
        }
    }
    
    getElement(): HTMLElement {
        return this.tileContainer;
    } 
} 