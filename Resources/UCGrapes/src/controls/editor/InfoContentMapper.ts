import { InfoType } from "../../types";
import { randomIdGenerator } from "../../utils/helpers";
import { HistoryManager } from "../toolbox/HistoryManager";
import { ToolboxManager } from "../toolbox/ToolboxManager";

export class InfoContentMapper {
  pageId: any;
  historyManager: HistoryManager;
  constructor(pageId: any) {
    this.pageId = pageId;
    this.historyManager = new HistoryManager(this.pageId);
  }

  private saveData(data: any): void {
    const storageKey = `data-${this.pageId}`;
    localStorage.setItem(storageKey, JSON.stringify(data));
    this.historyManager.addState(data);
    // call auto save to DB:
    const toolboxManager = new ToolboxManager();
    toolboxManager.savePages();
  }

  public contentRow(content: InfoType): any {
    const data: any = JSON.parse(
      localStorage.getItem(`data-${this.pageId}`) || "{}"
    );
    const row = {
      InfoId: content.InfoId,
      InfoType: content.InfoType || "",
      InfoValue: content.InfoValue || "",
      InfoNextSectionId: content.InfoPositionId || "",
      CtaAttributes: content?.CtaAttributes,
      Tiles: content?.Tiles,
      Images: content?.Images,
    };

    return row;
  }

  public addInfoType(content: InfoType): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];

    const newSection = this.contentRow(content);
    const nextSectionId = newSection.InfoNextSectionId;

    // Find the index of the section with id matching InfoNextSection
    const targetIndex = data.PageInfoStructure.InfoContent.findIndex(
      (section: any) => section.InfoId === nextSectionId
    );

    delete newSection.InfoNextSectionId;

    if (targetIndex !== -1) {
      // Insert at the target index
      delete newSection.InfoNextSectionId;
      data.PageInfoStructure.InfoContent.splice(targetIndex, 0, newSection);
    } else {
      // If no match found, fallback to push
      data.PageInfoStructure.InfoContent.push(newSection);
    }

    this.saveData(data);
  }

  public pasteSingleInfoType(content: any, nextSectionId?: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];
    // Find the index of the section with id matching InfoNextSection
    const targetIndex = data.PageInfoStructure.InfoContent.findIndex(
      (section: any) => section.InfoId === nextSectionId
    );

    if (targetIndex !== -1) {
      // Insert at the target index
      data.PageInfoStructure.InfoContent.splice(targetIndex, 0, content);
    } else {
      // If no match found, fallback to push
      data.PageInfoStructure.InfoContent.push(content);
    }
    // console.log('pasteInfoType data', data);
    // clear copied structure
    // localStorage.removeItem('copiedInfoSection');

    // refresh updated page structure
    new ToolboxManager().applyNewState(data, this.pageId);

    this.saveData(data);
  }

  public pasteAllInfoSectionTypes(sections: any[], nextSectionId?: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];
    const infoContent = data.PageInfoStructure.InfoContent;

    // Find the index of the section with id matching InfoNextSection
    let targetIndex = infoContent.findIndex(
      (section: any) => section.InfoId === nextSectionId
    );

    // If not found, fallback to push at the end
    if (targetIndex === -1) {
      targetIndex = infoContent.length;
    }

    // Insert each section at the correct index, incrementing for each
    sections.forEach((section, i) => {
      infoContent.splice(targetIndex + i, 0, section);
    });

    // Optionally clear copied sections from localStorage
    // localStorage.removeItem('copiedInfoSections');

    // refresh updated page structure
    new ToolboxManager().applyNewState(data, this.pageId);

    this.saveData(data);
  }

  public handleDragAndDropToNewTileArea(draggedTileId: string, draggedTileParentId: string, beforeSectionId?: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];
    // Find the parent section of the dragged tile
    const draggedTileParent = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === draggedTileParentId
    );
    // remove the dragged tile from its current parent and save it
    const draggedTile = draggedTileParent?.Tiles?.find(
      (tile: any) => tile.Id === draggedTileId
    );
    if (draggedTileParent && draggedTile) {
      // remove the dragged tile from its current parent
      draggedTileParent.Tiles = draggedTileParent.Tiles.filter(
        (tile: any) => tile.Id !== draggedTileId
      );

      // update page structure with draggedTileParent state
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === draggedTileParentId) {
            return draggedTileParent;
          }
          return section;
        }
      );

      // create a new section for the dragged tile
      const content: InfoType = {
        InfoId: randomIdGenerator(15),
        InfoType: "TileRow",
        InfoValue: "",
        Tiles: [{ ...draggedTile, Id: randomIdGenerator(8) }],
      };

      if (beforeSectionId) {

        // Find the index of the section with id matching beforeSectionId
        const beforeSectionIndex = data.PageInfoStructure.InfoContent.findIndex(
          (section: any) => section.InfoId === beforeSectionId
        );
        if (beforeSectionIndex === -1) data.PageInfoStructure.InfoContent.push(content);
        else data.PageInfoStructure.InfoContent.splice(beforeSectionIndex + 1, 0, content);

      } else {
        // If no match found, add to the top of the InfoContent array
        data.PageInfoStructure.InfoContent.splice(0, 0, content);
      }

      // refresh updated page structure
      new ToolboxManager().applyNewState(data, this.pageId);

      this.saveData(data);
    }
  }

  public handleDragAndDropToExistingTileArea(draggedTileId: string, draggedFromParentId: string, draggedToParentId: string, tileDestinationIndex: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    console.log('data :>> ', data);

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];
    // Find the parent section of the dragged tile
    const draggedTileParent = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === draggedFromParentId
    );
    // remove the dragged tile from its current parent and save it
    const draggedTile = draggedTileParent?.Tiles?.find(
      (tile: any) => tile.Id === draggedTileId
    );
    if (draggedTileParent && draggedTile) {
      // remove the dragged tile from its current parent
      draggedTileParent.Tiles = draggedTileParent.Tiles.filter(
        (tile: any) => tile.Id !== draggedTileId
      );

      // update page structure with draggedTileParent state
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === draggedFromParentId) {
            return draggedTileParent;
          }
          return section;
        }
      );
    }

    // Find the target section where the tile should be moved
    const targetSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === draggedToParentId
    );

    if (targetSection && draggedTile) {
      // If the target section exists, add the dragged tile to its Tiles array
      targetSection.Tiles ??= [];
      // Insert the dragged tile at the specified index
      targetSection.Tiles.splice(tileDestinationIndex, 0, {
        ...draggedTile,
        // Id: randomIdGenerator(8), // Generate a new ID for the moved tile
      });

      // Update the page structure with the modified target section
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === draggedToParentId) {
            return targetSection;
          }
          return section;
        }
      );
    }
    // refresh updated page structure
    new ToolboxManager().applyNewState(data, this.pageId);
    this.saveData(data);
  }

  public cutInfoSectionsFromPage(sectionIdsToRemove: any[], cutPageId: string): any {
    const storageKey = `data-${cutPageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure || !sectionIdsToRemove) return;

    data.PageInfoStructure.InfoContent ??= [];
    const infoContent = data.PageInfoStructure.InfoContent;

    // Filter out sections whose InfoId matches any in sectionIdsToRemove
    const filteredContent = infoContent.filter(
      (section: any) => !sectionIdsToRemove.includes(section.InfoId)
    );

    // Update the InfoContent array
    data.PageInfoStructure.InfoContent = filteredContent;

    // refresh updated page structure
    new ToolboxManager().applyNewState(data, cutPageId);

    this.saveData(data);
  }

  moveContentRow(contentId: any, newIndex: number): void {
    const data: any = JSON.parse(
      localStorage.getItem(`data-${this.pageId}`) || "{}"
    );
    if (!data?.PageInfoStructure?.InfoContent) return;

    const contentArray = data.PageInfoStructure.InfoContent;
    const contentRowIndex = contentArray.findIndex(
      (row: any) => row.InfoId === contentId
    );

    if (
      contentRowIndex === -1 ||
      newIndex < 0 ||
      newIndex >= contentArray.length
    )
      return;

    const [contentRow] = contentArray.splice(contentRowIndex, 1);

    contentArray.splice(newIndex, 0, contentRow);
    this.saveData(data);
  }

  updateInfoContent(infoId: any, newContent: InfoType): boolean {
    const data: any = JSON.parse(
      localStorage.getItem(`data-${this.pageId}`) || "{}"
    );
    if (!data?.PageInfoStructure?.InfoContent) return false;
    const contentArray = data.PageInfoStructure.InfoContent;
    const contentRowIndex = contentArray.findIndex(
      (row: InfoType) => row.InfoId === infoId
    );
    if (contentRowIndex === -1) return false;
    contentArray[contentRowIndex] = newContent;
    this.saveData(data);

    return true;
  }

  removeInfoContent(infoId: any): boolean {
    const data: any = JSON.parse(
      localStorage.getItem(`data-${this.pageId}`) || "{}"
    );
    if (!data?.PageInfoStructure?.InfoContent) return false;

    const contentArray = data.PageInfoStructure.InfoContent;
    const contentRowIndex = contentArray.findIndex(
      (row: InfoType) => row.InfoId === infoId
    );

    if (contentRowIndex === -1) return false;

    contentArray.splice(contentRowIndex, 1);
    this.saveData(data);

    // trigger a grapes js deselect event
    const grapesJsEditor = (globalThis as any).activeEditor;
    if (grapesJsEditor) {
      const selectedComponent = grapesJsEditor.getSelected();
      if (selectedComponent) {
        grapesJsEditor.select(null);
        (globalThis as any).selectedComponent = null;
      }
    }

    return true;
  }

  getInfoContent(infoId: any): InfoType | null {
    const data: any = JSON.parse(
      localStorage.getItem(`data-${this.pageId}`) || "{}"
    );
    if (!data?.PageInfoStructure?.InfoContent) return null;

    const contentArray = data.PageInfoStructure.InfoContent;
    const contentRowIndex = contentArray.findIndex(
      (row: InfoType) => row.InfoId === infoId
    );

    if (contentRowIndex === -1) return null;

    return contentArray[contentRowIndex];
  }
}