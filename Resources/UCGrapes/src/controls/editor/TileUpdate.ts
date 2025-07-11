import { minTileHeight } from "../../utils/default-attributes";
import { addRightButton, resizeButton } from "../../utils/gjs-components";
import { InfoSectionManager } from "../InfoSectionManager";

export class TileUpdate {
  rowComponent: any;
  pageId: any;

  constructor(pageId?: string) {
    this.pageId = pageId || null;
  }

  // updateTile(rowComponent: any, isDragging: boolean = false) {
  //   this.rowComponent = rowComponent;
  //   const tiles = rowComponent.find(".template-wrapper");
  //   const length = tiles.length;
  //   const tileUpdates: { tileId: string; align: string }[] = [];

  //   tiles.forEach((tile: any) => {
  //     const tileAttributes = this.getTileAttributes(rowComponent, tile);
  //     const rightButton = tile.find(".add-button-right")[0];
  //     if (rightButton) {
  //       rightButton.addStyle({
  //         display: length >= 3 ? "none" : "flex",
  //       });
  //     }
  //     const alignValue = length === 3 ? "center" : tileAttributes?.Align;
  //     const cssAlignValue = alignValue === "left" ? "start" : alignValue;

  //     // if tiles are 2 or 3, remove resize button else add the resize button
  //     if (length > 1) {
  //       tile.addStyle({ height: `${minTileHeight}px` });
  //       (globalThis as any).tileMapper.updateTile(
  //         tile.getId(),
  //         "Size",
  //         minTileHeight
  //       );
  //       tile.find(".tile-resize-button").forEach((comp: any) => comp.remove());
  //     } else {
  //       tile.append(resizeButton("Resize"));
  //     }

  //     const tileAlignment = {
  //       "justify-content": cssAlignValue,
  //       "align-items": cssAlignValue,
  //     };

  //     const titleAlignment = {
  //       "text-align": alignValue,
  //     };

  //     this.updateTileHeight(tile, length);
  //     this.updateAlignment(tile, tileAlignment, titleAlignment);
  //     this.updateTileTitleLength(tile, length);

  //     if (!isDragging) {
  //       // Collect tile updates instead of updating individually
  //       let align = alignValue;
  //       if (alignValue === "start") {
  //         align = "left";
  //       }
  //       tileUpdates.push({ tileId: tile.getId(), align });
  //     }
  //   });

  //   // Update all tiles in the row at once
  //   if (!isDragging && tileUpdates.length > 0) {
  //     this.updateRowAttributes(rowComponent.getId(), tileUpdates);
  //   }

  //   this.removeEmptyRows();
  // }

  updateGridTiles(rowComponent:any) {
    // remove all add tile and resize components
    rowComponent.find('.add-button-right').forEach((comp:any) => comp.remove())
    rowComponent.find('.tile-resize-button').forEach((comp:any) => comp.remove())

    const columnComponents = rowComponent.find(".tile-column")
    const tileCounts = columnComponents.map((comp:any) => comp.components().filter((comp:any)=>comp.get('type') === "tile-wrapper" || comp.getClasses().includes("template-wrapper")).length)

    const maxTileCount = Math.max(...tileCounts) 
    rowComponent.addStyle('height', `${maxTileCount*minTileHeight}px`)
    const columnCount = columnComponents.length

    if (maxTileCount == 1) {
      // set all tile heights to min height
      rowComponent.find('.template-wrapper').forEach((comp:any) => {
        comp.addStyle({height: `${minTileHeight}px`})
      })
    }

    columnComponents.forEach((comp:any) => {
      const maxWidths = ['100%','50%','32%']
      const colHeights = [178,264]
      comp.addStyle({'width': maxWidths[columnCount-1]})
      const tiles = comp.components().filter((comp:any)=>(comp.get('type') === "tile-wrapper")||comp.getClasses().includes("template-wrapper"))
      const colWidth = comp.view.el.getBoundingClientRect().width
      tiles.forEach((tile:any) => {
        // tile.addStyle({'width': `${colWidth}px`})
        if (maxTileCount === 1 && columnCount < 3) {
          tile.append(addRightButton("Add Tile Right"));
        }
      })

      if (tiles.length === 0) {
        comp.remove()
      }
      else if (tiles.length === 1) {
        comp.addStyle({'display': 'block', 'height':'100%'})
        if (columnCount < 3) {
          // add resize handle
          tiles[0].append(resizeButton("Resize"));
          if (maxTileCount > 1) {
            tiles[0].addStyle({height: `100%`})
          }
        }
      }
      
      else if (tiles.length > 1) {
        comp.addStyle({'display': 'flex'})
        comp.addStyle({height: `${colHeights[tiles.length-2]}px`})
        tiles.forEach((tile:any) => {
          // remove resize component
          tile.find(".tile-resize-button").forEach((comp: any) => comp.remove());
          // set tile height as minHeight
          tile.addStyle('height', `${minTileHeight}px`)
        })
      }
      
    })
  }

  // getTileAttributes(rowComponent: any, tileWrapper: any) {
  //   const pageData = (globalThis as any).pageData;
  //   let tileAttributes;
  //   if (pageData.PageType === "Information") {
  //     const infoContentMapper = new InfoContentMapper(this.pageId);
  //     const tileInfoSectionAttributes: InfoType | null = infoContentMapper.getInfoContent(rowComponent.getId());

  //     if (!tileInfoSectionAttributes) return;

  //     tileAttributes = tileInfoSectionAttributes?.Tiles?.find(
  //       (tile: any) => tile.Id === tileWrapper.getId()
  //     );
  //   } else {
  //     tileAttributes = (globalThis as any).tileMapper.getTile(
  //       rowComponent.getId(),
  //       tileWrapper.getId()
  //     );
  //   }
  //   return tileAttributes;
  // }

  // private updateTileHeight(tile: any, length: number) {
  //   const templateBlock = tile.find(".template-block")[0];
  //   if (length === 1) {
  //     if (templateBlock.getClasses().includes("first-tile")) {
  //       templateBlock.addClass("high-priority-template");
  //     }
  //   } else {
  //     templateBlock.removeClass("high-priority-template");
  //   }
  // }

  // private updateAlignment(tile: any, tileAlignment: any, titleAlignment: any) {
  //   const templateBlock = tile.find(".template-block")[0];
  //   const tileTitle = tile.find(".tile-title-section")[0];
  //   templateBlock.addStyle(tileAlignment);
  //   tileTitle.addStyle(titleAlignment);
  // }

  // private updateTileTitleLength(tile: any, length: number) {
  //   const tileTitle = tile.find(".tile-title")[0];
  //   if (tileTitle) {
  //     const textLength = length === 3 ? 11 : length === 2 ? 15 : 20;
  //     const title = this.truncateText(
  //       textLength,
  //       tileTitle.getAttributes()?.["title"] || tileTitle.getEl().innerText
  //     );

  //     if (length === 3) {
  //       tileTitle.components(this.wrapTileTitle(title));
  //     } else {
  //       tileTitle.components(title);
  //     }
  //   }
  // }

  private truncateText(titleLength: number, tileTitle: string) {
    const screenWidth: number = window.innerWidth;
    if (
      tileTitle.length > (screenWidth <= 280 ? titleLength : titleLength + 4)
    ) {
      return (
        tileTitle
          .substring(0, screenWidth <= 280 ? titleLength : titleLength + 4)
          .trim() + ".."
      );
    }
    return tileTitle;
  }

  private wrapTileTitle(title: any) {
    const words = title.split(" ");
    if (words.length > 1) {
      return words[0] + "<br>" + words[1];
    }
    return title.replace("<br>", "");
  }

  // Removed the old updateTileAttributes method since we're now using updateRowAttributes

  updateRowAttributes(rowId: string, tileUpdates: { tileId: string; align: string }[]) {
    const pageData = (globalThis as any).pageData;

    if (pageData.PageType === "Information") {
      const infoSectionManager = new InfoSectionManager();
      const tileInfoSectionAttributes = infoSectionManager.getInfoContent(rowId);
      
      if (tileInfoSectionAttributes) {
        // Update all tiles in the row
        tileUpdates.forEach(({ tileId, align }) => {
          const tile = tileInfoSectionAttributes.Tiles?.find(
            (tile) => tile.Id === tileId
          );
          if (tile) {
            tile.Align = align; 
          }
        });

        // Save the entire row with all updated tiles
        infoSectionManager.updateInfoMapper(rowId, tileInfoSectionAttributes);
      }
    }
  }

  // Utility: Set tile-wrapper draggable state based on count in tile-col-wrapper
  updateTilesDraggableProperty(editor: any): void {
    const wrapper = editor.getWrapper();
    // Set all tile-wrapper components to not draggable by default
    const allTileWrappers = wrapper.find('[data-gjs-type="tile-wrapper"]');
    console.log(allTileWrappers, "tile wrappers found");
    allTileWrappers.forEach((tile: any) => {
      tile.set('draggable', false);
      tile.addAttributes({'data-gjs-draggable': 'false'});
      tile.trigger('change:draggable');
    });

    // Loop through all tile-col-wrapper components
    const colWrappers = wrapper.find('[data-gjs-type="tile-col-wrapper"]');
    colWrappers.forEach((col: any) => {
      const tileChildren = col.components().filter((comp: any) => comp.get('type') === 'tile-wrapper');
      if (tileChildren.length > 1) {
        tileChildren.forEach((tile: any) => {
          tile.set('draggable', true);
          tile.addAttributes({'data-gjs-draggable': 'true'});
          tile.trigger('change:draggable');
        });
        col.set('draggable', false);
        col.trigger('change:draggable');
      } else {
        tileChildren.forEach((tile: any) => {
          tile.set('draggable', false);
          tile.addAttributes({'data-gjs-draggable': 'true'});
          tile.trigger('change:draggable');
        });
        col.set('draggable', true);
        col.trigger('change:draggable');
      }
    });

    // --- Business rules for info-tiles-section and columns ---
    const infoSections = wrapper.find('[data-gjs-type="info-tiles-section"]');
    infoSections.forEach((section: any) => {
      const colChildren = section.components().filter((comp: any) => comp.get('type') === 'tile-col-wrapper');
      // 1. If section has exactly 3 tile-col-wrapper children, set droppable to false
      if (colChildren.length === 3) {
        section.set('droppable', false);
        section.addAttributes({'data-gjs-droppable': 'false'});
        section.trigger('change:droppable');
      }
      // 2. If section has 2 columns, apply adjacent and 2-tile/3-tile rules
      if (colChildren.length === 2) {
        const [colA, colB] = colChildren;
        const colAChildren = colA.components().filter((comp: any) => comp.get('type') === 'tile-wrapper');
        const colBChildren = colB.components().filter((comp: any) => comp.get('type') === 'tile-wrapper');
        // 2a. If one col has >1 tile-wrapper and the other has <=1, set the other's droppable to false
        if (colAChildren.length > 1 && colBChildren.length <= 1) {
          colB.set('droppable', false);
          colB.addAttributes({'data-gjs-droppable': 'false'});
          colB.trigger('change:droppable');
        } else if (colBChildren.length > 1 && colAChildren.length <= 1) {
          colA.set('droppable', false);
          colA.addAttributes({'data-gjs-droppable': 'false'});
          colA.trigger('change:droppable');
        }
        // 2b. If either col has exactly 2 tile-wrapper children, set its droppable to both types
        if (colAChildren.length === 2) {
          colA.set('droppable', "[data-gjs-type='tile-col-wrapper'], [data-gjs-type='tile-wrapper']");
          colA.addAttributes({'data-gjs-droppable': "[data-gjs-type='tile-col-wrapper'], [data-gjs-type='tile-wrapper']"});
          colA.trigger('change:droppable');
        }
        if (colBChildren.length === 2) {
          colB.set('droppable', "[data-gjs-type='tile-col-wrapper'], [data-gjs-type='tile-wrapper']");
          colB.addAttributes({'data-gjs-droppable': "[data-gjs-type='tile-col-wrapper'], [data-gjs-type='tile-wrapper']"});
          colB.trigger('change:droppable');
        }
        // 2c. If either col has exactly 3 tile-wrapper children, allow only tile-wrapper drops for internal re-ordering otherwise change droppable to false.
        if (colAChildren.length === 3) {
          colA.set('droppable', false);
          colA.addAttributes({'data-gjs-droppable': "false"});
          colA.trigger('change:droppable');
        }
        if (colBChildren.length === 3) {
          colB.set('droppable', false);
          colB.addAttributes({'data-gjs-droppable': "false"});
          colB.trigger('change:droppable');
        }
      }
    });

    // 3. For each tile-col-wrapper, if it has exactly 3 tile-wrapper children, set its own and parent section's droppable to false
    colWrappers.forEach((col: any) => {
      const tileChildren = col.components().filter((comp: any) => comp.get('type') === 'tile-wrapper');
      const infoTilesSection = col.closest('[data-gjs-type="info-tiles-section"]');
      if (tileChildren.length === 3 && infoTilesSection) {
        col.set('droppable', false);
        col.addAttributes({'data-gjs-droppable': 'false'});
        col.trigger('change:droppable');
        infoTilesSection.set('droppable', false);
        infoTilesSection.addAttributes({'data-gjs-droppable': 'false'});
        infoTilesSection.trigger('change:droppable');
      }
    });
  }

  removeEmptyRows() {
    const container = this.rowComponent.parent();
    const rows = container.components();
    rows.forEach((row: any) => {
      if (row?.components()?.length === 0) {
        row?.remove();
      }
    });
  }
}