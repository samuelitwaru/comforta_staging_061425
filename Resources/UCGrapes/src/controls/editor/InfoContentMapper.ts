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
    const row = {
      InfoId: content.InfoId,
      InfoType: content.InfoType || "",
      InfoValue: content.InfoValue || "",
      InfoNextSectionId: content.InfoPositionId || "",
      CtaAttributes: content?.CtaAttributes,
      Tiles: content?.Tiles,
      Images: content?.Images,
      Columns: content?.Columns
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
    const draggedTile = draggedTileParent?.Columns?.find(
      (col: any) => col.ColId === draggedTileId
    );
    if (draggedTileParent && draggedTile) {
      // remove the dragged tile from its current parent
      draggedTileParent.Columns = draggedTileParent.Columns.filter(
        (col: any) => col.ColId !== draggedTileId
      );

      // check if dragged tile parent is left with one column containing more than one tile
      if (draggedTileParent.Columns.length === 1 && draggedTileParent.Columns[0].Tiles?.length > 1) {
        // If it has only one column with more than one tile, we create a new info section for each tile except the first one
        const tiles = draggedTileParent.Columns[0].Tiles;
        tiles.slice(1).forEach((tile: any, index: number) => {
          const newSectionId = randomIdGenerator(15);
          const content: InfoType = {
            InfoId: newSectionId,
            InfoType: "TileGrid",
            InfoValue: "",
            Columns: [{
              Tiles: [tile],
              ColId: randomIdGenerator(8)
            }],
          };

          const draggedTileParentIndex = data.PageInfoStructure.InfoContent.findIndex(
            (section: any) => section.InfoId === draggedTileParentId
          );

          if (draggedTileParentIndex === -1) {
            data.PageInfoStructure.InfoContent.push(content);
          } else {
            data.PageInfoStructure.InfoContent.splice(draggedTileParentIndex + 1 + index, 0, content);
          }
        });
        // Remove the copied tiles from the parent column, keep only the first tile
        draggedTileParent.Columns[0].Tiles = [tiles[0]];
      }

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
        InfoType: "TileGrid",
        InfoValue: "",
        Columns: [{
          ...draggedTile,
          ColId: randomIdGenerator(8)
        }],
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

      const cleanData = this.checkAndRemoveEmptyTileSections(data);

      // refresh updated page structure
      new ToolboxManager().applyNewState(cleanData, this.pageId);

      this.saveData(cleanData);
    }
  }

  public handleDragAndDropToExistingTileArea(draggedTileId: string, draggedFromParentId: string, draggedToParentId: string, tileDestinationIndex: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];

    // Find the parent section of the dragged tile
    const draggedTileParent = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === draggedFromParentId
    );
    // remove the dragged tile from its current parent and save it
    const draggedTile = draggedTileParent?.Columns?.find(
      (col: any) => col.ColId === draggedTileId
    );
    if (draggedTileParent && draggedTile) {
      // remove the dragged tile from its current parent
      draggedTileParent.Columns = draggedTileParent.Columns.filter(
        (col: any) => col.ColId !== draggedTileId
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
      targetSection.Columns ??= [];
      // Insert the dragged tile at the specified index
      targetSection.Columns.splice(tileDestinationIndex, 0, {
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

    const cleanData = this.checkAndRemoveEmptyTileSections(data);
    // refresh updated page structure
    new ToolboxManager().applyNewState(cleanData, this.pageId);

    this.saveData(cleanData);
  }

  public handleDragAndDropWithinExistingTileColumn(draggedTileId: string, draggedFromParentId: string, draggedToParentId: string, tileSectionId: string, tileDestinationIndex: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];

    // Find the parent section of the dragged tile
    const parentTileSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === tileSectionId
    );
    const parentColumnSection = parentTileSection?.Columns?.find(
      (col: any) => col.ColId === draggedFromParentId
    );
    // remove the dragged tile from its current parent and save it
    const draggedTile = parentColumnSection?.Tiles?.find(
      (tile: any) => tile.Id === draggedTileId
    );
    if (parentTileSection && parentColumnSection && draggedTile) {
      // remove the dragged tile from its current parent
      parentColumnSection.Tiles = parentColumnSection.Tiles.filter(
        (tile: any) => tile.Id !== draggedTileId
      );

      // update page structure with parentTileSection state
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === tileSectionId) {
            return parentTileSection;
          }
          return section;
        }
      );
    }

    // Find the target section where the tile should be moved
    const targetSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === tileSectionId
    );

    if (targetSection && draggedTile) {
      // If the target section exists, add the dragged tile to its Tiles array
      targetSection.Columns ??= [];
      // Insert the dragged tile at the specified index
      targetSection.Columns = targetSection.Columns.map((col: any) => {
        if (col.ColId === draggedToParentId) {
          col.Tiles ??= [];
          // Insert the dragged tile at the specified index
          col.Tiles.splice(tileDestinationIndex, 0, {
            ...draggedTile,
            // Id: randomIdGenerator(8), // Generate a new ID for the moved tile
          });
        }
        return col;
      });

      // Update the target section with the modified columns
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === tileSectionId) {
            return targetSection;
          }
          return section;
        }
      );
    }

    const cleanData = this.checkAndRemoveEmptyTileSections(data);
    // refresh updated page structure
    new ToolboxManager().applyNewState(cleanData, this.pageId);

    this.saveData(cleanData);
  }

  public handleDragAndDropTileToExistingTileColumn(draggedTileId: string, draggedFromParentId: string, draggedToColumnId: string, destinationTileSectionId: string, tileDestinationIndex: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];

    // Find the parent section of the dragged tile
    const parentTileSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === draggedFromParentId
    );
    // remove the dragged tile from its current parent and save it
    const draggedTile = parentTileSection?.Columns?.find(
      (col: any) => col.ColId === draggedTileId
    );
    if (parentTileSection && draggedTile) {
      // remove the dragged tile from its current parent
      parentTileSection.Columns = parentTileSection.Columns.filter(
        (col: any) => col.ColId !== draggedTileId
      );

      // update page structure with parentTileSection state
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === draggedFromParentId) {
            return parentTileSection;
          }
          return section;
        }
      );
    }

    // Find the target section where the tile should be moved
    const targetSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === destinationTileSectionId
    );

    if (targetSection && draggedTile) {
      // If the target section exists, add the dragged tile to its Tiles array
      targetSection.Columns ??= [];
      // Insert the dragged tile at the specified index
      targetSection.Columns = targetSection.Columns.map((col: any) => {
        if (col.ColId === draggedToColumnId) {
          col.Tiles ??= [];
          // Insert the dragged tile at the specified index
          // extract dragged tile from the draggedTile object
          const draggedTileContent = draggedTile.Tiles ? draggedTile.Tiles[0] : draggedTile;
          // Insert the dragged tile at the specified index
          col.Tiles.splice(tileDestinationIndex, 0, {
            ...draggedTileContent,
            // Id: randomIdGenerator(8), // Generate a new ID for the moved tile
          });
        }
        return col;
      });

      // Update the target section with the modified columns
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === destinationTileSectionId) {
            return targetSection;
          }
          return section;
        }
      );
    }

    const cleanData = this.checkAndRemoveEmptyTileSections(data);
    // refresh updated page structure
    new ToolboxManager().applyNewState(cleanData, this.pageId);

    this.saveData(cleanData);
  }

  public handleDragAndDropTileWrapperToNewTileColumn(draggedTileId: string, draggedFromColumnId: string, draggedFromTileSectionId: string, beforeSectionId?: string): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];
    // Find the parent section of the dragged tile

    const draggedTileParentSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === draggedFromTileSectionId
    );
    // remove the dragged tile from its current parent and save it
    const draggedTileParentColumn = draggedTileParentSection?.Columns?.find(
      (col: any) => col.ColId === draggedFromColumnId
    );
    const draggedTile = draggedTileParentColumn?.Tiles?.find(
      (tile: any) => tile.Id === draggedTileId
    );
    if (draggedTileParentColumn && draggedTile) {
      // remove the dragged tile from its current parent
      draggedTileParentColumn.Tiles = draggedTileParentColumn.Tiles.filter(
        (tile: any) => tile.Id !== draggedTileId
      );

      // remove the parent column if it has no tiles left
      if (draggedTileParentColumn.Tiles.length === 0) {
        draggedTileParentSection.Columns = draggedTileParentSection.Columns.filter(
          (col: any) => col.ColId !== draggedFromColumnId
        );
      }

      // update page structure with draggedTileParent state
      data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.map(
        (section: any) => {
          if (section.InfoId === draggedFromTileSectionId) {
            return draggedTileParentSection;
          }
          return section;
        }
      );

      // create a new section for the dragged tile
      const content: InfoType = {
        InfoId: randomIdGenerator(15),
        InfoType: "TileGrid",
        InfoValue: "",
        Columns: [{
          Tiles: [{
            ...draggedTile,
          }],
          ColId: randomIdGenerator(8)
        }],
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

      const cleanData = this.checkAndRemoveEmptyTileSections(data);

      // refresh updated page structure
      new ToolboxManager().applyNewState(cleanData, this.pageId);

      this.saveData(cleanData);
    }
  }

  public handleDragAndDropTileToExistingTileSectionWithNoGrid(
    draggedTileId: string,
    draggedFromParentId: string,
    draggedToParentId: string,
    sourceTileSectionId: string,
    destinationTileSectionId: string,
    tileDestinationIndex: string
  ): any {
    const storageKey = `data-${this.pageId}`;
    const data: any = JSON.parse(localStorage.getItem(storageKey) || "{}");

    if (!data.PageInfoStructure) return;

    data.PageInfoStructure.InfoContent ??= [];

    // Find the parent section of the dragged tile
    const parentTileSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === sourceTileSectionId
    );
    const parentColumnSection = parentTileSection?.Columns?.find(
      (col: any) => col.ColId === draggedFromParentId
    );
    // remove the dragged tile from its current parent and save it
    const draggedTile = parentColumnSection?.Tiles?.find(
      (tile: any) => tile.Id === draggedTileId
    );
    if (parentTileSection && parentColumnSection && draggedTile) {
      // remove the dragged tile from its current parent
      parentColumnSection.Tiles = parentColumnSection.Tiles.filter(
        (tile: any) => tile.Id !== draggedTileId
      );

      // update page structure with parentTileSection state
      data.PageInfoStructure.InfoContent =
        data.PageInfoStructure.InfoContent.map((section: any) => {
          if (section.InfoId === sourceTileSectionId) {
            return parentTileSection;
          }
          return section;
        });
    }

    // Find the target section where the tile should be moved
    const targetSection = data.PageInfoStructure.InfoContent.find(
      (section: any) => section.InfoId === destinationTileSectionId
    );

    if (targetSection && draggedTile) {
      // If the target section exists, add the dragged tile to it with a new column
      //Create a new column for the dragged tile
      const newColumn = {
        ColId: randomIdGenerator(8),
        Tiles: [{
          ...draggedTile,
        }],
      };
      targetSection.Columns ??= [];
      // insert the new column at the specified index
      if (tileDestinationIndex < targetSection.Columns.length) {
        targetSection.Columns.splice(tileDestinationIndex, 0, newColumn);
      }
      else {
        targetSection.Columns.push(newColumn);
      }

      // Update the target section with the modified columns
      data.PageInfoStructure.InfoContent =
        data.PageInfoStructure.InfoContent.map((section: any) => {
          if (section.InfoId === destinationTileSectionId) {
            return targetSection;
          }
          return section;
        });
    }

    const cleanData = this.checkAndRemoveEmptyTileSections(data);
    // refresh updated page structure
    new ToolboxManager().applyNewState(cleanData, this.pageId);

    this.saveData(cleanData);
  }

  checkAndRemoveEmptyTileSections(data: any): any {
    if (!data?.PageInfoStructure?.InfoContent) return data;
    data.PageInfoStructure.InfoContent = data.PageInfoStructure.InfoContent.filter(
      (section: any) => {
        // Remove sections with empty InfoId or InfoType
        if (!section.InfoId || !section.InfoType) {
          return false;
        }
        // Only remove sections with InfoType 'TileGrid' if their columns are empty
        if (section.InfoType === 'TileGrid') {
          if (section.Columns && section.Columns.length > 0) {
            return section.Columns.some((col: any) => col.Tiles && col.Tiles.length > 0);
          }
          return false; // Remove empty TileGrid sections
        }
        // Keep all other InfoTypes
        return true;
      }
    );
    return data;
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
    this.clearGJSSelected();

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

  private clearGJSSelected() {
    const grapesJsEditor = (globalThis as any).activeEditor;
    if (grapesJsEditor) {
      const selectedComponent = grapesJsEditor.getSelected();
      if (selectedComponent) {
        grapesJsEditor.select(null);
        (globalThis as any).selectedComponent = null;
      }
    }
  }
}