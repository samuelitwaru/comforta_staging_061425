import { ThemeManager } from "../controls/themes/ThemeManager";
import { i18n } from "../i18n/i18n";
import { Tile } from "../types";
import { DefaultAttributes, infoRowDefaultAttributes, minTileHeight, tileDefaultAttributes, tileWrapperDefaultAttributes } from "./default-attributes";
import { randomIdGenerator, truncateString } from "./helpers";

export function resizeButton (title:string) {
    return `
        <button ${DefaultAttributes} title="${title}" class="tile-resize-button">
        </button>
    `
}

export function addRightButton (title:string) {
    return `
        <button ${DefaultAttributes} data-gjs-type="default" title="${title}" class="action-button add-button-right">
          <svg ${DefaultAttributes} fill="#fff" width="15" height="15" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path ${DefaultAttributes} d="M19,11H13V5a1,1,0,0,0-2,0v6H5a1,1,0,0,0,0,2h6v6a1,1,0,0,0,2,0V13h6a1,1,0,0,0,0-2Z"/>
          </svg>
        </button>
    `
}

export function tileFromAttributes (tile: Tile, themeManager:ThemeManager): string {
  const id = tile.Id
  const text = tile.Text
  const textColor = tile.Color
  const align = tile.Align
  const icon = themeManager.getThemeIcon(tile.Icon as string)
  let iconSVG = ""
  if (icon) {
    iconSVG = icon.IconSVG.replace(/fill="[^"]*"/g, `fill="${textColor}"`)
  }
  const bgImage = tile.BGImageUrl
  const bgColor = bgImage ? '' : themeManager.getThemeColor(tile.BGColor as string)
  const opacity = tile.Opacity;

  return `
    <div ${tileWrapperDefaultAttributes} class="template-wrapper" id="${ id }" style="text-align:${align}">
        <div ${tileDefaultAttributes} class="template-block" style="background-color: ${bgColor}; background-image: url(${bgImage}); color: ${textColor}; justify-content: ${align}; align-items: ${align}">
            <div ${DefaultAttributes} class="tile-icon-section"  style="display: ${icon?'block':'none'}; " >
                <span ${DefaultAttributes} data-gjs-type="text" class="tile-close-icon top-right selected-tile-title">×</span>
                <span ${DefaultAttributes} data-gjs-type="text" title="${icon?.IconName}" class="tile-icon">
                  ${iconSVG}
                </span>
            </div>
            <div ${DefaultAttributes} class="tile-title-section">
                <span ${DefaultAttributes} id="is1dw" data-gjs-type="text" class="tile-close-title top-right selected-tile-title">×</span>
                <span ${DefaultAttributes} style="display: block" id="ic26t" data-gjs-type="text" is-hidden="false" title="${text}" class="tile-title">${text}</span>
            </div>
        </div>
        <button ${DefaultAttributes} id="ifvvi" data-gjs-type="default" title="Add tile right" class="action-button add-button-right">+</button>
        <button ${DefaultAttributes} id="i9sxl" data-gjs-type="default" title="Delete tile" class="action-button delete-button">&minus;</button>
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

export  function newTile(tileId?:String){
  return `
      <div ${tileWrapperDefaultAttributes} class="template-wrapper" id="${ tileId || randomIdGenerator(8)}">
          <div ${tileDefaultAttributes} class="template-block" style="background-color: transparent; color: #333333; justify-content: left">
              <div ${DefaultAttributes} id="igtdq" data-gjs-type="default" class="tile-icon-section">
                  <span ${DefaultAttributes} id="is1dw" data-gjs-type="text" class="tile-close-icon top-right selected-tile-title">×</span>
                  <span ${DefaultAttributes} id="ic26t" data-gjs-type="text" class="tile-icon">deade</span>
              </div>
              <div ${DefaultAttributes} id="igtdq" data-gjs-type="default" class="tile-title-section">
                  <span ${DefaultAttributes} id="is1dw" data-gjs-type="text" class="tile-close-title top-right selected-tile-title">×</span>
                  <span ${DefaultAttributes} style="display: block" id="ic26t" data-gjs-type="text" is-hidden="false" title="${i18n.t('tile.title')}" class="tile-title">${i18n.t('tile.title')}</span>
              </div>
          </div>
          <button ${DefaultAttributes} id="ifvvi" data-gjs-type="default" title="Add tile right" class="action-button add-button-right">+</button>
          <button ${DefaultAttributes} id="i9sxl" data-gjs-type="default" title="Delete tile" class="action-button delete-button">&minus;</button>
          ${resizeButton("Resize")}
          <svg ${DefaultAttributes} class="tile-open-menu" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 27 27">
              <g ${DefaultAttributes} id="Group_2383" data-name="Group 2383" transform="translate(-921 -417.999)">
                  <g ${DefaultAttributes} id="Group_2382" data-name="Group 2382" transform="translate(921 418)">
                      <circle ${DefaultAttributes} id="Ellipse_534" data-name="Ellipse 534" cx="13.5" cy="13.5" r="13.5" transform="translate(0 -0.001)" fill="#6a747f"/>
                  </g>
                  <path ${DefaultAttributes} id="Path_2320" data-name="Path 2320" d="M1.7,0a1.7,1.7,0,1,0,1.7,1.7A1.7,1.7,0,0,0,1.7,0ZM7.346,0a1.7,1.7,0,1,0,1.7,1.7A1.7,1.7,0,0,0,7.346,0ZM13,0a1.7,1.7,0,1,0,1.7,1.7A1.7,1.7,0,0,0,13,0Z" transform="translate(927 430)" fill="#fff"/>
              </g>
          </svg>
      </div>
    `
}

export function newTileRow(tileHTML?:string) {
    const col = newTileColumn(tileHTML)
    const rowId =  randomIdGenerator(8)
    const html = `
      <div class="container-row" ${infoRowDefaultAttributes} id="${rowId}">
        ${col.html}
      </div>
    `;
    return {
      html: html,
      rowId: rowId,
      colId: col.colId,
      tileId: col.tileId
    } 
}

export function newTileColumn(tileHTML?:string) {
    const colId = randomIdGenerator(8)
    const tileId = randomIdGenerator(8)
    if (!tileHTML) {
        tileHTML = newTile(tileId)
    }

    const html =  `
        <div ${DefaultAttributes} id="${colId}" class="tile-column" data-gjs-type="tile-column">
            ${tileHTML}
        </div>
    `;
    return {
        html: html,
        colId: colId,
        tileId: tileId
    }
}

export function infoSectionSpacer() {
    return `
    <div ${DefaultAttributes} data-type="add-button" data-custom="add-button" class="info-section-spacing-container">
        <div ${DefaultAttributes} class="add-new-info-section">
          <hr ${DefaultAttributes} class="add-new-info-hr" />
          <svg ${DefaultAttributes} xmlns="http://www.w3.org/2000/svg" id="Component_67_2" data-name="Component 67 – 2" width="30" height="30" viewBox="0 0 30 30">
            <g ${DefaultAttributes} id="Group_2309" data-name="Group 2309">
              <g ${DefaultAttributes} id="Group_2307" data-name="Group 2307">
                <g ${DefaultAttributes} id="Ellipse_6" data-name="Ellipse 6" fill="#fdfdfd" stroke="#5068a8" stroke-width="1">
                  <circle ${DefaultAttributes} cx="15" cy="15" r="15" stroke="none" />
                  <circle ${DefaultAttributes} cx="15" cy="15" r="14.5" fill="none" />
                </g>
              </g>
            </g>
            <path ${DefaultAttributes} id="Icon_ionic-ios-add" data-name="Icon ionic-ios-add"
              d="M21.895,15H16.717V9.823a.858.858,0,1,0-1.717,0V15H9.823a.858.858,0,0,0,0,1.717H15v5.177a.858.858,0,1,0,1.717,0V16.717h5.177a.858.858,0,1,0,0-1.717Z"
              transform="translate(-0.692 -1.025)" fill="#5068a8" />
          </svg>
        </div>
    </div>
    `
}