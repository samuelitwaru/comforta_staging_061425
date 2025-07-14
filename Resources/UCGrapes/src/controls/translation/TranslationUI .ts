// TranslationUI.ts
import { Column, CtaAttributes, InfoType, Tile } from "../../types";
import { ctaIcons } from "../../utils/cta-icons";
import { ThemeManager } from "../themes/ThemeManager";
import Quill from "quill";

export class TranslationUI {
  private editableElements: Map<string, any> = new Map();
  private currentQuillEditor: any = null;
  private currentEditingElement: HTMLElement | null = null;
  private themeManager: ThemeManager;

  constructor(themeManager: ThemeManager) {
    this.themeManager = themeManager;
  }

  private generateEditableId(): string {
    return `editable-${Date.now()}-${Math.random().toString(36).substr(2, 9)}`;
  }

  public makeEditable(
    content: string,
    dataPath: string,
    isHtml: boolean = false,
    fullContent?: string
  ): string {
    const editableId = this.generateEditableId();
    this.editableElements.set(editableId, {
      dataPath,
      isHtml,
      fullContent: fullContent || content,
    });

    const editableClass = isHtml
      ? "editable-content html-content"
      : "editable-content text-content";

    const titleAttr = isHtml ? "" : `title="${this.escapeHtml(fullContent || content)}"`;

    return `<span class="${editableClass}" 
              data-editable-id="${editableId}" 
              data-original-content="${this.escapeHtml(content)}"
              data-full-content="${this.escapeHtml(fullContent || content)}"
              contenteditable="false"
              style="width: 100%; display: inline-block; font-size: 15px;"
              ${titleAttr}>
          ${isHtml ? content : this.escapeHtml(content)}
        </span>`;
  }

  private escapeHtml(text: string): string {
    const div = document.createElement("div");
    div.textContent = text.trim();
    return div.innerHTML;
  }

  public createTileRowSection(section: any, sectionIndex: number): string {
    const tiles = section.Tiles || [];
    let tilesHtml = "";

    tiles.forEach((tile: any, tileIndex: number) => {
      const hasBackgroundImage = tile.BGImageUrl && tile.BGImageUrl.trim() !== "";
      const backgroundColor = this.themeManager.getThemeColor(tile.BGColor);

      const backgroundStyle = hasBackgroundImage
        ? `background-image: url('${tile.BGImageUrl}'); background-size: cover; background-position: center;`
        : `background-color: ${backgroundColor};`;

      const tileContent = tile.Text || tile.Name || "";
      const editableTileContent = this.makeEditable(
        tileContent,
        `InfoContent.${sectionIndex}.Tiles.${tileIndex}.${tile.Text ? "Text" : "Name"}`
      );

      tilesHtml += `
        <div
          class="translated-tile"
         style="
          ${backgroundStyle}
          color: ${tile.Color || "#333"};
          align-items: center;
          justify-content: ${tile.Align || "left"};
          text-align: ${tile.Align || "left"};
          ">
          ${editableTileContent}
        </div>
      `;
    });

    return `<div class="translated-tile-row">${tilesHtml}</div>`;
  }

  // In TranslationUI.ts
  public createTileGridSection(section: any, sectionIndex: number): string {
    const columns = section.Columns || [];
    let columnsHtml = "";

    columns?.forEach((column: Column, columnIndex: number) => {
      const tiles = column.Tiles || [];
      let tilesHtml = "";

      const columnHeightStyle =
        tiles.length === 1 ? `min-height: 100%;` : `min-height: ${80 * tiles.length}px`;

      tiles.forEach((tile: Tile, tileIndex: number) => {
        const hasBackgroundImage = tile.BGImageUrl && tile.BGImageUrl.trim() !== "";
        const backgroundColor = this.themeManager.getThemeColor(tile.BGColor || "");

        const backgroundStyle = hasBackgroundImage
          ? `background-color: rgba(0,0,0, ${tile?.Opacity ? tile.Opacity / 100 : 0});
               background-image: url('${tile.BGImageUrl}');
               background-size: cover;
               background-position: center;
               background-blend-mode: overlay;`
          : `background-color: ${backgroundColor};`;

        const tileContent = tile.Text || tile.Name || "";
        const editableTileContent = this.makeEditable(
          tileContent,
          `InfoContent.${sectionIndex}.Columns.${columnIndex}.Tiles.${tileIndex}.${tile.Text ? "Text" : "Name"}`
        );

        tilesHtml += `
        <div
          class="translated-tile"
         style="
          ${backgroundStyle}
          color: ${tile.Color || "#333"};
          align-items: ${tile.Align === "left" ? "start" : tile.Align}; 
          justify-content: ${tile.Align === "left" ? "start" : tile.Align};
          justify-content: ${tile.Align || "left"};
          text-align: ${tile.Align || "left"};
          min-height: ${tile?.Height ? tile.Height : 80}px;
          ">
          <div class="tile-icon-section" ${tile.Icon ? 'style="display: block;"' : ""}>
            <span title="${tile.Icon}" class="tile-icon" style="width: 30px; display: block;">
              ${this.getTileIcon(tile)}
            </span>
          </div>
          ${editableTileContent}
        </div>
      `;
      });

      columnsHtml += `
            <div class="tile-column" 
                 style="
                     flex: 1;
                     display: flex;
                     flex-direction: column;
                     gap: 8px;
                     ${columnHeightStyle}
                 ">
                ${tilesHtml}
            </div>
        `;
    });

    return `
        <div class="tile-grid-section">
            ${columnsHtml}
        </div>
    `;
  }

  private getTileIcon(tile: Tile) {
    const iconData = this.themeManager.getThemeIcon(tile.Icon || "");
    let cleanedSVG = "";

    if (iconData && typeof iconData === "object" && iconData.IconSVG) {
      cleanedSVG = iconData.IconSVG.replace('fill="#7c8791"', `fill="${tile.Color}"`);
    }
    return cleanedSVG;
  }

  public createDescSection(section: any, sectionIndex: number): string {
    const description = section.InfoValue || "";
    const editableDescription = this.makeEditable(
      description,
      `InfoContent.${sectionIndex}.InfoValue`,
      true
    );

    return `
      <div class="translated-description">
        ${editableDescription}
      </div>
    `;
  }

  public createImageSlideSection(section: any): string {
    const images = section.Images || [];

    if (images.length === 0) return "";

    if (images.length === 1) {
      return `
        <div class="translated-images">
          <img src="${images[0].InfoImageValue}" 
               alt="Content Image" >
        </div>
      `;
    }

    return `
      <div class="translated-images" style="position: relative;">
          <img src="${images[0].InfoImageValue}" 
               alt="Content Image" >
          <div style="
            position: absolute;
            top: 10px;
            left: 10px;
            background: rgba(0,0,0,0.7);
            color: white;
            padding: 4px 8px;
            border-radius: 4px;
            font-size: 12px;
            font-weight: bold;
          ">1/${images.length}</div>
        </div>
    `;
  }

  public createCtaSection(section: InfoType, sectionIndex: number): string {
    let button;
    switch (section.CtaAttributes?.CtaButtonType) {
      case "Image":
        button = this.ctaImageButton(section.CtaAttributes, sectionIndex);
        break;
      case "Icon":
        button = this.ctaIconButton(section.CtaAttributes, sectionIndex);
        break;
      case "FullWidth":
        button = this.ctaPlainButton(section.CtaAttributes, sectionIndex);
        break;
      case "Round":
        button = this.ctaRoundButton(section.CtaAttributes, sectionIndex);
        break;
      default:
        button = "";
    }
    return `
      <div class="translated-cta">
        ${button}
      </div>
    `;
  }

  public createMergedRoundCtaSection(sections: InfoType[], startIndex: number): string {
    let buttonsHtml = "";

    sections.forEach((section, relativeIndex) => {
      if (section.CtaAttributes) {
        const sectionIndex = startIndex + relativeIndex;
        const backgroundColor = this.themeManager.getThemeCtaColor(
          section.CtaAttributes?.CtaBGColor ?? ""
        );

        const label = section.CtaAttributes.CtaLabel || "";
        const truncatedLabel = label.length > 18 ? label.slice(0, 18) + "..." : label;
        const editableLabel = this.makeEditable(
          truncatedLabel,
          `InfoContent.${sectionIndex}.CtaAttributes.CtaLabel`,
          false,
          label
        );

        buttonsHtml += `
          <div class="translated-cta-round-button">
            <div class="translated-cta-round-button__button" style="background-color: ${backgroundColor};">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 41 32.8">
                <path id="Path_1218" data-name="Path 1218" d="M6.1,4A4.068,4.068,0,0,0,2.789,5.7a1.5,1.5,0,0,0,.444,2.126l18,11.219a2.387,2.387,0,0,0,2.531,0L41.691,7.732a1.5,1.5,0,0,0,.384-2.2A4.063,4.063,0,0,0,38.9,4Zm35.907,8.376a.963.963,0,0,0-.508.152L23.765,23.711a2.392,2.392,0,0,1-2.531,0L3.5,12.656a.98.98,0,0,0-1.5.833V32.7a4.1,4.1,0,0,0,4.1,4.1H38.9A4.1,4.1,0,0,0,43,32.7V13.357A.981.981,0,0,0,42.007,12.376Z" transform="translate(-2 -4)" fill="#ffffff"></path>
            </svg>
            </div>
            <div class="translated-cta-round-button__label">
              ${editableLabel}
            </div>
          </div>
        `;
      }
    });

    return `
      <div class="translated-cta translated-cta-merged-round">
        ${buttonsHtml}
      </div>
    `;
  }

  private ctaImageButton(ctaAttributes: CtaAttributes, sectionIndex: number) {
    const backgroundColor = this.themeManager.getThemeCtaColor(ctaAttributes?.CtaBGColor ?? "");
    const editableLabel = this.makeEditable(
      ctaAttributes.CtaLabel || "",
      `InfoContent.${sectionIndex}.CtaAttributes.CtaLabel`
    );

    return `
      <div class="translated-cta-img-button">
        <div class="translated-cta-img-button__button" style="background-color: ${backgroundColor};">
          <img class="translated-cta-img-button__img" src="${ctaAttributes.CtaButtonImgUrl}">
          <div class="translated-cta-img-button__label" style="color: ${ctaAttributes.CtaColor}">${editableLabel}</div>
          <i class="fa fa-angle-right translated-cta-img-button__icon" style="color: ${ctaAttributes.CtaColor}"></i>
        </div>
      </div>
    `;
  }

  private ctaIconButton(ctaAttributes: CtaAttributes, sectionIndex: number) {
    const backgroundColor = this.themeManager.getThemeCtaColor(ctaAttributes?.CtaBGColor ?? "");
    const editableLabel = this.makeEditable(
      ctaAttributes.CtaLabel || "",
      `InfoContent.${sectionIndex}.CtaAttributes.CtaLabel`
    );

    return `
      <div class="translated-cta-icon-button">
        <div class="translated-cta-icon-button__button" style="background-color: ${backgroundColor};">
        <span class="translated-cta-iconSvg-button__iconSvg">
          ${this.getIcon(ctaAttributes)}
          </span><div class="translated-cta-icon-button__label" style="color: ${ctaAttributes.CtaColor}">${editableLabel}</div>
          <i class="fa fa-angle-right translated-cta-icon-button__icon" style="color: ${ctaAttributes.CtaColor}"></i>
        </div>
      </div>
    `;
  }

  private ctaRoundButton(ctaAttributes: CtaAttributes, sectionIndex: number) {
    const backgroundColor = this.themeManager.getThemeCtaColor(ctaAttributes?.CtaBGColor ?? "");
    const editableLabel = this.makeEditable(
      ctaAttributes.CtaLabel || "",
      `InfoContent.${sectionIndex}.CtaAttributes.CtaLabel`
    );

    return `
    <div class="translated-cta-round-button">
      <div class="translated-cta-round-button__button" style="background-color: ${backgroundColor};">
      <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 41 32.8">
          <path id="Path_1218" data-name="Path 1218" d="M6.1,4A4.068,4.068,0,0,0,2.789,5.7a1.5,1.5,0,0,0,.444,2.126l18,11.219a2.387,2.387,0,0,0,2.531,0L41.691,7.732a1.5,1.5,0,0,0,.384-2.2A4.063,4.063,0,0,0,38.9,4Zm35.907,8.376a.963.963,0,0,0-.508.152L23.765,23.711a2.392,2.392,0,0,1-2.531,0L3.5,12.656a.98.98,0,0,0-1.5.833V32.7a4.1,4.1,0,0,0,4.1,4.1H38.9A4.1,4.1,0,0,0,43,32.7V13.357A.981.981,0,0,0,42.007,12.376Z" transform="translate(-2 -4)" fill="#ffffff"></path>
      </svg>
      </div><div class="translated-cta-round-button__label">${editableLabel}</div>
    </div>
      `;
  }

  private ctaPlainButton(ctaAttributes: CtaAttributes, sectionIndex: number) {
    const backgroundColor = this.themeManager.getThemeCtaColor(ctaAttributes?.CtaBGColor ?? "");
    const editableLabel = this.makeEditable(
      ctaAttributes.CtaLabel || "",
      `InfoContent.${sectionIndex}.CtaAttributes.CtaLabel`
    );

    return `
      <div class="translated-cta-plain-button">
        <div class="translated-cta-plain-button__button" style="background-color: ${backgroundColor};">
          <div class="translated-cta-plain-button__label" style="color: ${ctaAttributes.CtaColor}">${editableLabel}</div>
        </div>
      </div>
    `;
  }

  private getIcon(ctaAttributes: CtaAttributes): string {
    if (ctaAttributes.CtaButtonIcon) {
      const svg = ctaIcons.find((icon) => icon.name === ctaAttributes.CtaButtonIcon)?.svg;
      const tempElement = document.createElement("div") as HTMLElement;
      tempElement.innerHTML = svg || ``;
      const newSvgElement = tempElement.querySelector("svg");

      if (newSvgElement) {
        newSvgElement.setAttribute("height", "32");
        newSvgElement.setAttribute("width", "32");

        const pathElements = newSvgElement.querySelectorAll("path");
        pathElements.forEach((path) => {
          path.setAttribute("fill", ctaAttributes?.CtaColor || "#fff");
        });

        return tempElement.innerHTML;
      }
    } else {
      let icon: string = "";
      switch (ctaAttributes.CtaType) {
        case "Phone":
          return `
                    <svg id="ixdtl" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32" height="32"
                        viewBox="0 0 49.417 49.418">
                        <path id="call" data-gjs-type="svg-in"
                            d="M29.782,3a2.149,2.149,0,1,0,0,4.3A19.3,19.3,0,0,1,49.119,26.634a2.149,2.149,0,1,0,4.3,0A23.667,23.667,0,0,0,29.782,3ZM12.032,7.305a2.548,2.548,0,0,0-.818.067,8.342,8.342,0,0,0-3.9,2.342C2.775,14.254.366,21.907,17.437,38.98S42.16,53.643,46.7,49.1a8.348,8.348,0,0,0,2.346-3.907,2.524,2.524,0,0,0-1.179-2.786c-2.424-1.418-7.654-4.484-10.08-5.9a2.523,2.523,0,0,0-2.568.012l-4.012,2.392a2.517,2.517,0,0,1-2.845-.168,65.811,65.811,0,0,1-5.711-4.981,65.07,65.07,0,0,1-4.981-5.711A2.512,2.512,0,0,1,17.5,25.2L19.9,21.191a2.533,2.533,0,0,0,.008-2.577L14.012,8.556A2.543,2.543,0,0,0,12.032,7.305Zm17.751,4.289a2.149,2.149,0,1,0,0,4.3A10.709,10.709,0,0,1,40.525,26.634a2.149,2.149,0,1,0,4.3,0A15.072,15.072,0,0,0,29.782,11.594Zm0,8.594a2.149,2.149,0,1,0,0,4.3,2.114,2.114,0,0,1,2.149,2.148,2.149,2.149,0,1,0,4.3,0A6.479,6.479,0,0,0,29.782,20.188Z"
                            transform="translate(-4 -3)" fill="#fff"></path>
                    </svg>
                    `;
          break;
        case "Email":
          return `
                    <svg id="inavf" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32"
                        height="28" viewBox="0 0 41 32.8">
                        <path id="Path_1218" data-gjs-type="svg-in" data-name="Path 1218"
                            d="M6.1,4A4.068,4.068,0,0,0,2.789,5.7a1.5,1.5,0,0,0,.444,2.126l18,11.219a2.387,2.387,0,0,0,2.531,0L41.691,7.732a1.5,1.5,0,0,0,.384-2.2A4.063,4.063,0,0,0,38.9,4Zm35.907,8.376a.963.963,0,0,0-.508.152L23.765,23.711a2.392,2.392,0,0,1-2.531,0L3.5,12.656a.98.98,0,0,0-1.5.833V32.7a4.1,4.1,0,0,0,4.1,4.1H38.9A4.1,4.1,0,0,0,43,32.7V13.357A.981.981,0,0,0,42.007,12.376Z"
                            transform="translate(-2 -4)" fill="#fff"></path>
                    </svg>
                    `;
          break;
        case "WebLink":
          return `
                    <svg id="i8bct" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 16 16">
                        <path id="Path_1213" data-gjs-type="svg-in" data-name="Path 1213" d="M15.833,4a4.163,4.163,0,0,0-2.958,1.229l-.979.979a4.168,4.168,0,0,0-1.229,2.958,4.1,4.1,0,0,0,.292,1.521L12.042,9.6a2.857,2.857,0,0,1,.792-2.458l.979-.979a2.853,2.853,0,0,1,2.021-.833,2.805,2.805,0,0,1-2,.833,2.85,2.85,0,0,1,0,4.021l-.979.979A2.853,2.853,0,0,1,14.833,12a2.439,2.439,0,0,1-.437-.042l-1.083,1.083a4.1,4.1,0,0,0,1.521.292A4.163,4.163,0,0,0,17.792,12.1l.979-.979A4.168,4.168,0,0,0,20,8.167,4.2,4.2,0,0,0,15.833,4ZM14.188,8.854,8.854,14.188l.958.958,5.333-5.333ZM9.167,10.667A4.163,4.163,0,0,0,6.208,11.9l-.979.979A4.168,4.168,0,0,0,4,15.833,4.2,4.2,0,0,0,8.167,20a4.163,4.163,0,0,0,2.958-1.229l.979-.979a4.168,4.168,0,0,0,1.229-2.958,4.1,4.1,0,0,0-.292-1.521L11.958,14.4a2.857,2.857,0,0,1-.792,2.458l-.979.979a2.853,2.853,0,0,1-2.021.833,2.805,2.805,0,0,1-2-.833,2.85,2.85,0,0,1,0-4.021l.979-.979A2.853,2.853,0,0,1,9.167,12a2.44,2.44,0,0,1,.438.042l1.083-1.083A4.1,4.1,0,0,0,9.167,10.667Z" transform="translate(-4 -4)" fill="#fff">
                        </path>
                    </svg>
                    `;
          break;
        case "Form":
          return `
                    <svg id="igqdh" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="26" height="30"
                        viewBox="0 0 13 16">
                        <path id="Path_1209" data-gjs-type="svg-in" data-name="Path 1209"
                            d="M9.828,4A1.823,1.823,0,0,0,8,5.8V18.2A1.823,1.823,0,0,0,9.828,20h9.344A1.823,1.823,0,0,0,21,18.2V9.8a.6.6,0,0,0-.179-.424l-.006-.006L15.54,4.176A.614.614,0,0,0,15.109,4Zm0,1.2H14.5V8.6a1.823,1.823,0,0,0,1.828,1.8h3.453v7.8a.6.6,0,0,1-.609.6H9.828a.6.6,0,0,1-.609-.6V5.8A.6.6,0,0,1,9.828,5.2Zm5.891.848L18.92,9.2H16.328a.6.6,0,0,1-.609-.6Z"
                            transform="translate(-8 -4)" fill="#fff"></path>
                    </svg>
                    `;
          break;
        default:
          break;
      }
      return icon;
    }
    return "";
  }

  public setupEditableElements(
    onContentChanged: (dataPath: string, newValue: string) => void
  ): void {
    setTimeout(() => {
      const editableElements = document.querySelectorAll(".editable-content");

      editableElements.forEach((element) => {
        const htmlElement = element as HTMLElement;

        htmlElement.addEventListener("click", (e) => {
          e.stopPropagation();
          this.startEditing(htmlElement);
        });

        if (!htmlElement.classList.contains("html-content")) {
          htmlElement.addEventListener("blur", () => {
            this.saveEdit(htmlElement, onContentChanged);
          });

          htmlElement.addEventListener("keydown", (e) => {
            if (e.key === "Enter") {
              e.preventDefault();
              htmlElement.blur();
            }
          });
        }
      });

      document.addEventListener("click", (e) => {
        if (this.currentQuillEditor && this.currentEditingElement) {
          const quillContainer = this.currentEditingElement.querySelector(".ql-container");
          const quillToolbar = this.currentEditingElement.querySelector(".ql-toolbar");

          if (quillContainer && quillToolbar) {
            const target = e.target as HTMLElement;
            if (!quillContainer.contains(target) && !quillToolbar.contains(target)) {
              this.saveEdit(this.currentEditingElement, onContentChanged);
            }
          }
        }
      });
    }, 100);
  }

  private startEditing(element: HTMLElement): void {
    if (element.contentEditable === "true") return;

    if (this.currentEditingElement === element && this.currentQuillEditor) {
      this.currentQuillEditor.focus();
      return;
    }

    if (
      this.currentQuillEditor &&
      this.currentEditingElement &&
      this.currentEditingElement !== element
    ) {
      this.saveEdit(this.currentEditingElement, () => {});
    }

    const isHtml = element.classList.contains("html-content");

    if (isHtml) {
      this.startQuillEditing(element);
    } else {
      this.startTextEditing(element);
    }
  }

  private startQuillEditing(element: HTMLElement): void {
    if (this.currentEditingElement === element && this.currentQuillEditor) {
      return;
    }

    const fullContent = element.getAttribute("data-full-content") || element.innerHTML;
    const quillId = `quill-editor-${this.generateEditableId()}`;

    element.innerHTML = `
    <div id="${quillId}" class="quill-editor-container"></div>
    <div class="character-counter">0/1000</div>
    `;

    const quillContainer = element.querySelector(`#${quillId}`) as HTMLElement;
    const characterCounter = element.querySelector(".character-counter") as HTMLElement;

    element.classList.add("editing");

    const Delta = Quill.import("delta");
    this.currentQuillEditor = new Quill(quillContainer, {
      theme: "snow",
      modules: {
        toolbar: [
          ["bold", "italic", "underline"],
          [{ list: "ordered" }, { list: "bullet" }],
          ["clean"],
        ],
        clipboard: {
          matchVisual: false, // Add this to prevent adding extra paragraphs
          matchers: [
            [
              Node.ELEMENT_NODE,
              (node: Node, delta: any) => {
                return delta.compose(
                  new Delta().retain(delta.length(), {
                    background: false,
                    color: false,
                    font: false,
                    code: false,
                    size: false,
                    strike: false,
                    script: false,
                    blockquote: false,
                    header: false,
                    indent: false,
                    align: false,
                    direction: false,
                    formula: false,
                    image: false,
                    video: false,
                  })
                );
              },
            ],
          ],
        },
      },
      formats: ["bold", "italic", "underline", "list"],
      placeholder: "Enter description here...",
    });

    const cleanContent = this.decodeAndCleanHtml(fullContent);

    const cleanedContent = cleanContent.replace(/<p><br><\/p>/g, "");

    // Only paste content if it's not empty
    if (cleanedContent.trim()) {
      this.currentQuillEditor.clipboard.dangerouslyPasteHTML(0, cleanedContent);
    }

    this.currentEditingElement = element;
    this.updateCharacterCounter(characterCounter);

    this.currentQuillEditor.on("text-change", () => {
      this.updateCharacterCounter(characterCounter);

      if (this.currentQuillEditor.getLength() > 1000) {
        this.currentQuillEditor.deleteText(1000, this.currentQuillEditor.getLength());
      }
    });

    const editor = this.currentQuillEditor.root;
    editor.style.userSelect = "auto";
    editor.style.webkitUserSelect = "text";
    editor.style.mozUserSelect = "text";
    editor.style.msUserSelect = "text";
    editor.style.cursor = "text";

    setTimeout(() => {
      this.currentQuillEditor.focus();
      // Set selection to the end of the content if there is any
      const length = this.currentQuillEditor.getLength();
      this.currentQuillEditor.setSelection(length, 0);
    }, 100);
  }

  private updateCharacterCounter(counterElement: HTMLElement): void {
    if (!this.currentQuillEditor) return;

    const length = Math.max(0, this.currentQuillEditor.getLength() - 1);
    counterElement.textContent = `${length}/1000`;

    if (length >= 1000) {
      counterElement.style.color = "red";
    } else if (length >= 900) {
      counterElement.style.color = "orange";
    } else {
      counterElement.style.color = "";
    }
  }

  private decodeAndCleanHtml(htmlString: string): string {
    const tempDiv = document.createElement("div");
    tempDiv.innerHTML = htmlString.trim();

    // Remove any empty paragraphs
    const emptyParagraphs = tempDiv.querySelectorAll("p:empty, p:has(br:only-child)");
    emptyParagraphs.forEach((p) => p.remove());

    let decodedContent = tempDiv.innerHTML;

    decodedContent = decodedContent
      .replace(/&lt;/g, "<")
      .replace(/&gt;/g, ">")
      .replace(/&amp;/g, "&")
      .replace(/&quot;/g, '"')
      .replace(/&#39;/g, "'")
      .replace(/<p><br><\/p>/g, "") // Remove empty paragraphs
      .replace(/<p>\s*<\/p>/g, ""); // Remove paragraphs with only whitespace

    return decodedContent.trim();
  }

  private startTextEditing(element: HTMLElement): void {
    const fullContent = element.getAttribute("data-full-content") || element.innerHTML;

    element.textContent = fullContent;
    element.contentEditable = "true";
    element.classList.add("editing");
    element.focus();

    const range = document.createRange();
    range.selectNodeContents(element);
    const selection = window.getSelection();
    selection?.removeAllRanges();
    selection?.addRange(range);
  }

  private saveEdit(
    element: HTMLElement,
    onContentChanged: (dataPath: string, newValue: string) => void
  ): void {
    const editableId = element.getAttribute("data-editable-id");
    const isHtml = element.classList.contains("html-content");

    if (isHtml && this.currentQuillEditor) {
      let newContent = this.currentQuillEditor.root.innerHTML;

      // Clean up the content before saving
      newContent = this.decodeAndCleanHtml(newContent);

      this.currentQuillEditor = null;
      this.currentEditingElement = null;

      // Only update if there's actual content
      if (newContent.trim() !== "<p><br></p>" && newContent.trim() !== "<p></p>") {
        element.innerHTML = newContent;
        element.classList.remove("editing");

        if (editableId) {
          const editableInfo = this.editableElements.get(editableId);
          if (editableInfo) {
            editableInfo.fullContent = newContent;
            element.setAttribute("data-original-content", this.escapeHtml(newContent));
            element.setAttribute("data-full-content", this.escapeHtml(newContent));

            onContentChanged(editableInfo.dataPath, newContent);
          }
        }
      } else {
        // If content is empty, restore the original content
        const editableInfo = editableId ? this.editableElements.get(editableId) : null;
        if (editableInfo) {
          element.innerHTML = editableInfo.fullContent ?? "";
          element.classList.remove("editing");
        }
      }
    } else if (!isHtml) {
      if (element.contentEditable === "false") return;

      element.contentEditable = "false";
      element.classList.remove("editing");

      const newTextContent = element.textContent || "";
      const originalContent = element.getAttribute("data-original-content") || "";

      if (editableId && newTextContent !== originalContent) {
        const editableInfo = this.editableElements.get(editableId);
        if (editableInfo) {
          editableInfo.fullContent = newTextContent;
          element.setAttribute("data-original-content", this.escapeHtml(newTextContent));
          element.setAttribute("data-full-content", this.escapeHtml(newTextContent));
          element.setAttribute("title", this.escapeHtml(newTextContent));

          this.applyTruncation(element, newTextContent, editableInfo);
          onContentChanged(editableInfo.dataPath, newTextContent);
        }
      } else {
        const editableInfo = editableId ? this.editableElements.get(editableId) : null;
        if (editableInfo) {
          this.applyTruncation(element, editableInfo.fullContent || "", editableInfo);
        }
      }
    }
  }

  private applyTruncation(element: HTMLElement, fullContent: string, editableInfo: any): void {
    const isCTALabel =
      element.closest(".translated-cta-round-button__label") ||
      element.closest(".translated-cta-img-button__label") ||
      element.closest(".translated-cta-icon-button__label") ||
      element.closest(".translated-cta-plain-button__label");

    if (isCTALabel && !editableInfo.isHtml && fullContent.length > 18) {
      element.textContent = fullContent.slice(0, 18) + "...";
    } else {
      if (editableInfo.isHtml) {
        element.innerHTML = fullContent;
      } else {
        element.textContent = fullContent;
      }
    }
  }
}
