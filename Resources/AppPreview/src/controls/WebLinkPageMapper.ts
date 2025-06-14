import { Tile } from "../interfaces/Tile";

export class WebLinkPageMapper {
    tile: Tile;

    constructor(tile: Tile) {
        this.tile = tile;
    }

    renderContent(container: HTMLElement): void {
        if (!this.tile?.Action?.ObjectUrl) {
            const emptyContent = document.createElement("div");
            emptyContent.className = "tbap-empty";
            emptyContent.innerText = "No content available";
            container.appendChild(emptyContent);
            return;
        }

        const columnElement = document.createElement("div");
        columnElement.className = "tbap-weblink-column";

        // Preloader setup
        const preloader = document.createElement("div");
        preloader.id = "weblink-preloader";
        preloader.style.position = "absolute";
        preloader.style.top = "0";
        preloader.style.left = "0";
        preloader.style.width = "100%";
        preloader.style.height = "100%";
        preloader.style.display = "flex";
        preloader.style.justifyContent = "center";
        preloader.style.alignItems = "center";
        preloader.style.zIndex = "1000";

        const spinner = document.createElement("img");
        spinner.src = "/Resources/UCGrapes1/src/images/spinner.gif";
        spinner.alt = "Loading content...";
        spinner.style.width = "32px";
        spinner.style.height = "32px";

        preloader.appendChild(spinner);
        columnElement.appendChild(preloader);

        // Content element setup
        const contentEl = document.createElement("object") as HTMLObjectElement;
        contentEl.data = this.tile.Action.ObjectUrl;
        contentEl.type = "text/html";
        contentEl.width = "100%";
        contentEl.height = "900px";
        contentEl.style.visibility = "hidden";

        contentEl.innerHTML = `
            <p>Unable to display content. 
                <a href="${this.tile.Action.ObjectUrl}" target="_blank">Open in new tab</a>
            </p>
        `;

        columnElement.appendChild(contentEl);
        container.appendChild(columnElement);

        contentEl.addEventListener("load", () => {
            preloader.style.display = "none";
            contentEl.style.visibility = "visible";
        });

        // Fallback timeout (preloader disappears after 5 seconds)
        setTimeout(() => {
            preloader.style.display = "none";
            contentEl.style.visibility = "visible";
        }, 5000);
    }
}
