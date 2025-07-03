import { i18n } from "../../i18n/i18n";
import { Column, InfoType, Tile } from "../../types";
import { ActionListPopUp } from "../../ui/views/ActionListPopUp";
import {
  DefaultAttributes,
  infoRowDefaultAttributes,
  minTileHeight,
  rowDefaultAttributes,
  tileDefaultAttributes,
  tileWrapperDefaultAttributes,
} from "../../utils/default-attributes";
import { infoSectionSpacer, newTileColumn, newTileRow, resizeButton, tileFromAttributes } from "../../utils/gjs-components";
import { getNextSiblingComponent, randomIdGenerator } from "../../utils/helpers";
import { InfoSectionManager } from "../InfoSectionManager";
import { CtaManager } from "../themes/CtaManager";
import { ThemeManager } from "../themes/ThemeManager";
import { EditorEvents } from "./EditorEvents";
import { InfoContentMapper } from "./InfoContentMapper";
import { NewPageButton } from "./NewPageButton";
import { TileMapper } from "./TileMapper";
import { TileUpdate } from "./TileUpdate";

export class TileManager {
  // private event: MouseEvent;
  editor: any;
  pageId: any;
  frameId: any;
  pageData: any;
  page: any;
  tileUpdate: TileUpdate;
  themeManager: ThemeManager;

  constructor(
    // e: MouseEvent,
    editor: any,
    pageId: any,
    frameId: any,
    pageData: any
  ) {
    // this.event = e;
    this.editor = editor;
    this.pageId = pageId;
    this.frameId = frameId;
    this.pageData = pageData;
    this.tileUpdate = new TileUpdate(pageId);
    // (globalThis as any).pageData = pageData;
    (globalThis as any).tileMapper = new TileMapper(this.pageId);
    this.page = (globalThis as any).pageData;
    this.themeManager = new ThemeManager();
    this.init();
  }

  private init() {
    // this.addTileBottom();
    // this.addTileRight();
    // this.deleteTile();
    // this.removeTileIcon();
    // this.removeTileTitle();
    // this.removeCTa();
  }

  // addTileBottom() {
  //   const addBottomButton = (this.event.target as Element).closest(
  //     ".action-button.add-button-bottom"
  //   );
  //   if (addBottomButton) {
  //     const templateWrapper = addBottomButton.closest(".template-wrapper");
  //     if (!templateWrapper) return;

  //     let currentRow = templateWrapper.parentElement;
  //     let currentColumn = currentRow?.parentElement;

  //     if (!currentRow || !currentColumn) return;

  //     const index = Array.from(currentColumn.children).indexOf(currentRow);

  //     const columnComponent = this.editor.Components.getWrapper().find(
  //       "#" + currentColumn.id
  //     )[0];
  //     if (!columnComponent) return;

  //     const newRowComponent = this.editor.Components.addComponent(
  //       this.getTileRow()
  //     );
  //     columnComponent.append(newRowComponent, { at: index + 1 });
  //     const tileId = newRowComponent.find(".template-wrapper")[0]?.getId();

  //     if (this.page?.PageType === "Information") {
  //     } else {
  //       (globalThis as any).tileMapper.addFreshRow(
  //         newRowComponent.getId() as string,
  //         tileId as string,
  //         index + 1
  //       );
  //     }
  //   }
  // }

  addGridTile(rowComponent:any, index:number) {
    const newCol = newTileColumn()
    rowComponent.append(`
        ${newCol.html}
      `, {at:index + 1})
    this.addNewTileToGrid(rowComponent.getId(), newCol.colId, newCol.tileId)
    this.tileUpdate.updateGridTiles(rowComponent)
  }

  deleteGridTile(tileComponent:any) {
    if (tileComponent) {
      const rowComponent = tileComponent.closest('.container-row');
      const columnComponent = tileComponent.closest(".tile-column");
      const tileId = tileComponent.getId()
      tileComponent.remove();
      
      
      if (columnComponent && columnComponent.find('.template-wrapper').length === 0) {
        columnComponent.remove()
      }
      
      if (rowComponent && rowComponent.find('.tile-column').length === 0) {
        rowComponent.remove()
      }

      this.removeTileFromGrid(rowComponent.getId(), columnComponent.getId(), tileId)
      
      this.tileUpdate.updateGridTiles(rowComponent);
      const columnComponents = rowComponent.find('.tile-column')
      const tiles = rowComponent.find('.template-wrapper')
      if (columnComponents.length === 1 && tiles.length > 1) {
        this.splitGridTiles(rowComponent)
      }

      if (this.page?.PageType === "Information") {
        this.updateInfoTileRow(
          rowComponent.getId(),
          "delete",
          tileComponent.getId()
        );
        const infoSectionManager = new InfoSectionManager();
        infoSectionManager.removeConsecutivePlusButtons();
        infoSectionManager.restoreEmptyStateIfNoSections();
      } else {
        (globalThis as any).tileMapper.removeTile(
          tileComponent.getId() as string,
          columnComponent.getId() as string
        );
      }

      this.removeEditor(tileComponent.getId() as string);
    }
  }

  splitGridTiles(rowComponent:any) {
    const tiles = rowComponent.find('.template-wrapper')
    if (tiles.length > 1) {
      const tilesToSplit = tiles.slice(1)
      tilesToSplit.forEach((tile:any) => {
        const tileAttributes = this.getTileAttrs(rowComponent.getId(), tile.parent().getId(), tile.getId())
        const columnComponent = tile.closest('.tile-column')
        tile.remove()
        this.removeTileFromGrid(rowComponent.getId(), columnComponent.getId(), tile.getId())
        this.addTileOnNewRow(tile, tileAttributes, rowComponent)
      })
    }
  }


  // addTileRight() {
  //   const addRightutton = (this.event.target as Element).closest(
  //     ".action-button.add-button-right"
  //   );
  //   if (addRightutton) {
  //     const currentTile = addRightutton.closest(".template-wrapper");
  //     const currentTileComponent = this.editor.Components.getWrapper().find(
  //       "#" + currentTile?.id
  //     )[0];
  //     if (!currentTileComponent) return;

  //     const containerRowComponent = currentTileComponent.parent();
  //     const tiles = containerRowComponent.components().filter((comp: any) => {
  //       const type = comp.get("type");
  //       return type === "tile-wrapper";
  //     });

  //     if (tiles.length >= 3) return;

  //     const newTileComponent = this.editor.Components.addComponent(
  //       this.getTile()
  //     );

  //     const index = currentTileComponent.index();
  //     containerRowComponent.append(newTileComponent, { at: index + 1 });

  //     if (this.page?.PageType === "Information") {
  //       this.updateInfoTileRow(
  //         containerRowComponent.getId(),
  //         "add",
  //         newTileComponent.getId(),
  //         index
  //       );
  //     } else {
  //       (globalThis as any).tileMapper.addTile(
  //         currentTile?.parentElement?.id as string,
  //         newTileComponent.getId() as string
  //       );
  //     }

  //     this.tileUpdate.updateTile(containerRowComponent);

  //     if (newTileComponent) {
  //       const tileComponent = newTileComponent.find(".template-block")[0];
  //       if (tileComponent) {
  //         setTimeout(() => {
  //           this.editor.select(tileComponent);
  //         }, 0);
  //       }
  //     }
  //   }
  // }

  // deleteTile() {
  //   const deleteButton = (this.event.target as Element).closest(
  //     ".action-button.delete-button"
  //   );
  //   if (deleteButton) {
  //     const templateWrapper = deleteButton.closest(".template-wrapper");
  //     if (templateWrapper) {
  //       const tileComponent = this.editor.Components.getWrapper().find(
  //         "#" + templateWrapper?.id
  //       )[0];
  //       const parentComponent = tileComponent.parent();
  //       tileComponent.remove();

  //       this.tileUpdate.updateTile(parentComponent);

  //       if (this.page?.PageType === "Information") {
  //         this.updateInfoTileRow(
  //           parentComponent.getId(),
  //           "delete",
  //           tileComponent.getId()
  //         );
  //         const infoSectionManager = new InfoSectionManager();
  //         infoSectionManager.removeConsecutivePlusButtons();
  //         infoSectionManager.restoreEmptyStateIfNoSections();
  //       } else {
  //         (globalThis as any).tileMapper.removeTile(
  //           tileComponent.getId() as string,
  //           parentComponent.getId() as string
  //         );
  //       }

  //       this.removeEditor(tileComponent.getId() as string);
  //     }
  //   }
  // }

  private updateInfoTileRow(
    tileRowId: any,
    method: "add" | "delete" = "add",
    tileId: string,
    index?: number
  ) {
    const infoContentMapper = new InfoContentMapper(this.pageId);
    const tileSection: InfoType | null =
      infoContentMapper.getInfoContent(tileRowId);
    if (tileSection) {
      if (method === "add" && index !== undefined) {
        tileSection.Tiles?.splice(index + 1, 0, {
          Id: tileId,
          Name: "Title",
          Text: "Title",
          Color: "#333333",
          Align: "left",
          Action: {
            ObjectType: "",
            ObjectId: "",
            ObjectUrl: "",
            FormId: 0
          },
        });        
      } else if (method === "delete") {
        const tile = tileSection.Tiles?.find((tile: any) => tile.Id === tileId);
        if (tile) {
          const index = tileSection.Tiles?.indexOf(tile);
          if (index !== undefined && index >= 0) {
            tileSection.Tiles?.splice(index, 1);
          }
        }
      }

      const infoSectionManager = new InfoSectionManager();
      infoSectionManager.updateInfoMapper(tileRowId, tileSection);
    }
  }

  removeTileIcon(event:MouseEvent) {
    const tileIcon = (event.target as Element).closest(".tile-close-icon");
    if (tileIcon) {
      const templateWrapper = tileIcon.closest(".template-wrapper");
      if (templateWrapper) {
        const tileComponent = this.editor.Components.getWrapper().find(
          "#" + templateWrapper?.id
        )[0];
        
        if (this.checkTileHasIconOrTitle(tileComponent)) {
          if (this.page?.PageType === "Information") {
            const infoSectionManager = new InfoSectionManager();
            const rowComponent = tileComponent.closest('.container-row')
            const colComponent = tileComponent.closest('.tile-column')

            infoSectionManager.updateGridTileAttribute(
              rowComponent.getId(),
              colComponent.getId(),
              tileComponent.getId(),
              "Icon",""
            )

            // infoSectionManager.updateInfoTileAttributes(
            //   tileComponent.parent().getId(),
            //   tileComponent.getId(),
            //   "Icon",
            //   ""
            // );
          } else {
            (globalThis as any).tileMapper.updateTile(
              tileComponent.getId(),
              "Icon",
              ""
            );
          }
          const iconSection = tileComponent.find(".tile-icon-section")[0];
          if (iconSection) {
            iconSection.addStyle({ display: "none" });
          }
        } else {
          console.warn("Tile has no icon or title");
        }
      }
    }
  }

  removeTileTitle(event:MouseEvent) {
    const tileTitle = (event.target as Element).closest(
      ".tile-close-title"
    );
    if (tileTitle) {
      const templateWrapper = tileTitle.closest(".template-wrapper");
      if (templateWrapper) {
        const tileComponent = this.editor.Components.getWrapper().find(
          "#" + templateWrapper?.id
        )[0];

        if (this.checkTileHasIconOrTitle(tileComponent)) {
          if (this.page?.PageType === "Information") {
            const infoSectionManager = new InfoSectionManager();
            const rowComponent = tileComponent.closest('.container-row')
            const colComponent = tileComponent.closest('.tile-column')
            infoSectionManager.updateGridTileAttribute(
              rowComponent.getId(),
              colComponent.getId(),
              tileComponent.getId(),
              "Icon",""
            )
            // infoSectionManager.updateInfoTileAttributes(
            //   tileComponent.parent().getId(),
            //   tileComponent.getId(),
            //   "Text",
            //   ""
            // );
          } else {
            (globalThis as any).tileMapper.updateTile(
              tileComponent.getId(),
              "Text",
              ""
            );
          }
          const tileSection = tileComponent.find(".tile-title-section")[0];
          if (tileSection) {
            tileSection.addStyle({ display: "none" });
          }
        } else {
          console.warn("Tile has no icon or title");
        }
      }
    }
  }

  checkTileHasIconOrTitle(component: any): boolean {
    // const parentComponent = component.parent();
    const parentComponent = component.closest('.container-row')
    const columnComponenet = component.closest('.tile-column')

    if (!parentComponent) return false;
    let tileAttributes;
    if (this.pageData.PageType === "Information") {
      const tileInfoSectionAttributes: InfoType = (
        globalThis as any
      ).infoContentMapper.getInfoContent(parentComponent.getId());
      console.log('tileInfoSectionAttributes', tileInfoSectionAttributes)
      const column = tileInfoSectionAttributes?.Columns?.find((col:any) => col.ColId = columnComponenet.getId())
      console.log('column', column)
      
      tileAttributes = column?.Tiles?.find(
        (tile: any) => tile.Id === component.getId()
      );
      console.log('tileAttributes', tileAttributes)
    } else {
      tileAttributes = (globalThis as any).tileMapper.getTile(
        parentComponent.getId(),
        component.getId()
      );
    }
    console.log('tileAttributes', tileAttributes)
    if (tileAttributes) {
      if (tileAttributes.Icon && tileAttributes.Text) {
        return true;
      }
    }
    return false;
  }

  // removeCTa() {
  //   const ctaBadgeBtn = (this.event.target as Element).closest(
  //     ".cta-badge"
  //   ) as HTMLElement;
  //   if (ctaBadgeBtn) {
  //     new CtaManager().removeCta(ctaBadgeBtn);
  //   }
  // }

  removeEditor(tileId: string): void {
    const framelist = document.querySelectorAll(".mobile-frame");
    framelist.forEach((frame: any) => {
      const frameHasTile = frame.querySelector(`#${tileId}`);
      if (frameHasTile) {
        console.log(frameHasTile);
      }
      if (frame.id.includes(this.frameId)) {
        let nextElement = frame.nextElementSibling;
        while (nextElement) {
          const elementToRemove = nextElement;
          nextElement = nextElement.nextElementSibling;
          if (elementToRemove) {
            const thumbsList = document.querySelector(
              ".editor-thumbs-list"
            ) as HTMLElement;
            const thumbToRemove = thumbsList.querySelector(
              `div[id="${elementToRemove.id}"]`
            );
            if (thumbToRemove) {
              thumbToRemove.parentElement?.parentElement?.parentElement?.remove();
            }

            elementToRemove.remove();
            new EditorEvents().activateNavigators();
          }
        }
      }
    });
  }

  private getTileRow() {
    const isSingleTile = true;
    const tile = this.getTile(isSingleTile);
    return `<div class="container-row" ${rowDefaultAttributes} id="${randomIdGenerator(
      8
    )}">${tile}</div>`;
  }

  private getTile(isSingleTile: boolean = false) {
    return `
      <div ${tileWrapperDefaultAttributes} ${isSingleTile ? `style="height:${minTileHeight}px"` : ``
      } class="template-wrapper" id="${randomIdGenerator(8)}">
        <div ${tileDefaultAttributes} class="template-block" style="background-color: transparent; color: #333333; justify-content: left">
            <div ${DefaultAttributes} id="igtdq" data-gjs-type="default" class="tile-icon-section">
              <span ${DefaultAttributes} id="is1dw" data-gjs-type="text" class="tile-close-icon top-right selected-tile-title">×</span>
              <span ${DefaultAttributes} id="ic26t" data-gjs-type="text" class="tile-icon"></span>
            </div>
            <div ${DefaultAttributes} id="igtdq" data-gjs-type="default" class="tile-title-section">
              <span ${DefaultAttributes} id="is1dw" data-gjs-type="text" class="tile-close-title top-right selected-tile-title">×</span>
              <span ${DefaultAttributes} style="display: block" id="ic26t" data-gjs-type="text" is-hidden="false" title="${i18n.t('tile.title')}" class="tile-title">${i18n.t('tile.title')}</span>
            </div>
        </div>
        <button ${DefaultAttributes} id="i9sxl" data-gjs-type="default" title="Delete tile" class="action-button delete-button">&minus;</button>
        <button ${DefaultAttributes} id="ifvvi" data-gjs-type="default" title="Add tile right" class="action-button add-button-right">
          <svg ${DefaultAttributes} fill="#fff" width="15" height="15" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path ${DefaultAttributes} d="M19,11H13V5a1,1,0,0,0-2,0v6H5a1,1,0,0,0,0,2h6v6a1,1,0,0,0,2,0V13h6a1,1,0,0,0,0-2Z"/>
          </svg>
        </button>
        ${isSingleTile
        ? `
            ${resizeButton("Resize")}
          `
        : ``
      }
        ${this.page?.PageType === "Information"
        ? ``
        : `
          <button ${DefaultAttributes} id="i4ubt" data-gjs-type="default" title="Add template bottom" class="action-button add-button-bottom">
          <svg ${DefaultAttributes} fill="#fff" width="15" height="15" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path ${DefaultAttributes} d="M19,11H13V5a1,1,0,0,0-2,0v6H5a1,1,0,0,0,0,2h6v6a1,1,0,0,0,2,0V13h6a1,1,0,0,0,0-2Z"/>
          </svg>
          </button>
        `
      }
        <svg ${DefaultAttributes} class="tile-open-menu" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 27 27">
          <g ${DefaultAttributes} id="Group_2383" data-name="Group 2383" transform="translate(-921 -417.999)">
            <g ${DefaultAttributes} id="Group_2382" data-name="Group 2382" transform="translate(921 418)">
              <circle ${DefaultAttributes} id="Ellipse_534" data-name="Ellipse 534" cx="13.5" cy="13.5" r="13.5" transform="translate(0 -0.001)" fill="#6a747f"/>
            </g>
            <path ${DefaultAttributes} id="Path_2320" data-name="Path 2320" d="M1.7,0a1.7,1.7,0,1,0,1.7,1.7A1.7,1.7,0,0,0,1.7,0ZM7.346,0a1.7,1.7,0,1,0,1.7,1.7A1.7,1.7,0,0,0,7.346,0ZM13,0a1.7,1.7,0,1,0,1.7,1.7A1.7,1.7,0,0,0,13,0Z" transform="translate(927 430)" fill="#fff"/>
          </g>
        </svg>
      </div>
    `;
  }

  addTileOnNewRow(tile:any, tileAttributes:any, previousRowComponent:any){
    const index = previousRowComponent.index() + 1
    const parent = previousRowComponent.parent()
    parent.append(infoSectionSpacer(),  { at: index })
    const colId = randomIdGenerator(8)
    const rowId = randomIdGenerator(8)
    const columns = [{ColId: colId, Tiles:[tileAttributes]}]
    const rowHTML = `
          <div class="container-row" ${infoRowDefaultAttributes} id="${rowId}">
            ${columns.map((col:any)=> `
              <div class="tile-column" id="${col.ColId}">
                ${col.Tiles.map((tile:any)=> `
                    ${tileFromAttributes(tileAttributes, this.themeManager)}
                  ` ).join("")}
              </div>
              ` ).join("")}
          </div>
        `

    parent.append(`${rowHTML}`, { at: index + 1})
    
    const rowComponent = this.editor.Components.getWrapper().find(`#${rowId}`)[0];
    this.tileUpdate.updateGridTiles(rowComponent)
    const nextRowComp = getNextSiblingComponent(rowComponent, 'container-row')
    this.addTileToNewGrid(tileAttributes, rowId, colId, nextRowComp)
    this.tileUpdate.updateGridTiles(previousRowComponent)
  }

  addNewTileToGrid(rowId:string, colId:string, tileId:string) {
    const infoContentMapper = new InfoContentMapper(this.pageId);
    const tileSection: InfoType | null =
      infoContentMapper.getInfoContent(rowId);
    if (!tileSection) return

    let col = tileSection?.Columns?.find((col:Column) => col.ColId == colId)
    if (!col) {
      col = {ColId: colId, Tiles: []}
      tileSection?.Columns?.push(col)
    }

    const tile:Tile = {
      Id: tileId,
      Name: "Title",
      Text: "Title",
      Color: "#333333",
      Align: "left",
      Action: {
        ObjectType: "",
        ObjectId: "",
        ObjectUrl: "",
      },
    }
    col?.Tiles?.push(tile)
    

    const infoSectionManager = new InfoSectionManager();
      infoSectionManager.updateInfoMapper(rowId, tileSection);
  }

  addTileToNewGrid(tileAttributes:Object, rowId:string, colId:string, nextRowComp:any) {
    const infoContentMapper = new InfoContentMapper(this.pageId);
    const newInfoRow = {
      InfoId: rowId,
      InfoType: "TileGrid",
      InfoPositionId: nextRowComp?.getId(),
      InfoValue: "",
      Columns: [
          {

              ColId: colId,
              Tiles: [
                  tileAttributes as Tile
              ]
          },
        ]
    }
    infoContentMapper.addInfoType(newInfoRow)
  }

  removeTileFromGrid(rowId:string, colId:string, tileId:string) {
    const infoContentMapper = new InfoContentMapper(this.pageId);
    const tileSection: InfoType | null =
      infoContentMapper.getInfoContent(rowId);
    if (!tileSection) return
    const col = tileSection?.Columns?.find((col:Column) => col.ColId == colId)
    if (!col) return
    col.Tiles = col?.Tiles?.filter((tile:Tile) => tile.Id != tileId)

    if (!col.Tiles?.length) {
      tileSection.Columns = tileSection.Columns?.filter((item:any) => col.ColId != item.ColId)
    }

    if(tileSection.Columns && tileSection.Columns?.length == 0) {
      infoContentMapper.removeInfoContent(rowId)
    }

    const infoSectionManager = new InfoSectionManager();
      infoSectionManager.updateInfoMapper(rowId, tileSection);
  }


  getTileAttrs(rowId:string, colId:string, tileId:string) {
    const infoContentMapper = new InfoContentMapper(this.pageId);
    const tileSection: InfoType | null =
      infoContentMapper.getInfoContent(rowId);
    if (tileSection) {
      const col = tileSection.Columns?.find((col:any) => col.ColId == colId)
      const tile = col?.Tiles?.find((tile:any) => tile.Id == tileId)
      return tile
    }
  }
}


