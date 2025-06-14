// import { TileComponent } from "../components/TileComponent";
// import { Content } from "../interfaces/Content";
// import { Page } from "../interfaces/Page";
// import { PageContentStructure } from "../interfaces/PageContentStructure";
// import { Row } from "../interfaces/Row";
// import { Tile } from "../interfaces/Tile";

// export class ContentPageMapper {
//     pageData: PageContentStructure;
//     pageId: string;

//     constructor(page: Page) {
//         this.pageId = page.PageId;
//         this.pageData = page.PageContentStructure;
//     }

//     private renderImage(content: Content) {
//         const imageContainer = document.createElement('div');
//         imageContainer.classList.add('image-container');

//         const image = document.createElement('img');
//         image.src = content?.ContentValue;
//         imageContainer.appendChild(image);

//         return imageContainer;
//     }

//     private renderDescription(content: Content) {
//         const description = document.createElement('div');
//         description.classList.add('description-container');
//         description.innerText = content?.ContentValue;

//         return description;
//     }
//     renderContent(container: HTMLElement): void {
//         if (!this.pageData?.Content?.length) {
//             const emptyContent = document.createElement('div');
//             emptyContent.className = 'tbap-empty';
//             emptyContent.innerText = 'No content available';
//             container.appendChild(emptyContent);
//             return;
//         }

//         const columnElement = document.createElement('div');
//         columnElement.className = 'tbap-column';
        
//         this.pageData.Content.forEach((content: Content) => {
//             let contentEl: HTMLElement | null = null;
//             if (content.ContentType === "Image") {
//                 contentEl = this.renderImage(content);
//             } else  if(content.ContentType === "Description") {
//                 contentEl = this.renderDescription(content);
//             }

//             if (contentEl) {
//                 columnElement.appendChild(contentEl);
//             }            
//         });
        
//         container.appendChild(columnElement);
//     }
// }