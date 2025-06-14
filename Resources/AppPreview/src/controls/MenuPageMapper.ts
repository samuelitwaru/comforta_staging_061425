import { TileComponent } from "../components/TileComponent";
import { Page } from "../interfaces/Page";
import { PageMenuStructure } from "../interfaces/PageMenuStructure";
import { Row } from "../interfaces/Row";
import { Tile } from "../interfaces/Tile";

export class MenuPageMapper {
    pageData: PageMenuStructure;
    pageId: string;

    constructor(page: Page) {
        this.pageId = page.PageId;
        this.pageData = page.PageMenuStructure;
    }

    private renderRow(row: Row, isFirstRow: boolean): HTMLElement {
        const hasSingleTile = row.Tiles.length === 1;
        const isHighPriorityRow = isFirstRow && hasSingleTile;
        
        // Create a row container
        const rowElement = document.createElement('div');
        rowElement.className = 'tbap-row';
        rowElement.id = row.Id;
        
        const rowTileLength = row.Tiles.length;
        row.Tiles.forEach((tile, index) => {
            const isHighPriority = isHighPriorityRow && index === 0;
            const tileComponent = new TileComponent(tile, isHighPriority, this.pageId, rowTileLength);
            rowElement.appendChild(tileComponent.getElement());
        });
        
        return rowElement;
    }

    renderContent(container: HTMLElement): void {
        if (!this.pageData?.Rows?.length) {
            const emptyContent = document.createElement('div');
            emptyContent.className = 'tbap-empty';
            emptyContent.innerText = 'No content available';
            container.appendChild(emptyContent);
            return;
        }

        const columnElement = document.createElement('div');
        columnElement.className = 'tbap-column';
        
        this.pageData.Rows.forEach((row, index) => {
            const isFirstRow = index === 0;
            const rowElement = this.renderRow(row, isFirstRow);
            columnElement.appendChild(rowElement);
        });
        
        container.appendChild(columnElement);
    }
}