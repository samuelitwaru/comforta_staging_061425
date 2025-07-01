import { i18n } from "../../i18n/i18n";
import { LanguageTranslate } from "../../controls/LanguageTranslate";
import { TranslationodeUIManager } from "../../controls/TranslationModeUIManager";
export class EditActions {
  private undoButton: HTMLButtonElement;
  private redoButton: HTMLButtonElement;
  private translateButton: HTMLButtonElement;
  private container: HTMLDivElement;

  constructor() {
    this.container = document.createElement("div");
    this.translateButton = document.createElement("button");
    this.undoButton = document.createElement("button");
    this.redoButton = document.createElement("button");
    this.init();
  }

  private init(): void {
    this.container.classList.add("edit-actions");

    this.undoButton.id = "undo";
    this.undoButton.disabled = true;
    this.undoButton.className = "btn-transparent";
    this.undoButton.title = `${i18n.t("undo")} (ctrl+z)`;
    this.undoButton.innerHTML = "<span class='fa fa-undo'></span>";

    this.redoButton.id = "redo";
    this.redoButton.disabled = true;
    this.redoButton.className = "btn-transparent";
    this.redoButton.title = `${i18n.t("undo")} (ctrl+shift+z)`;
    this.redoButton.innerHTML = "<span class='fa fa-redo'></span>";

    const translateSvg = `
    <svg xmlns="http://www.w3.org/2000/svg" width="21" height="21" viewBox="0 0 21 21">
      <path id="Translation" d="M5.33.066a.725.725,0,0,0-.055,1.3c.148.078.193.083.826.083.728,0,.818-.019,1-.2A.71.71,0,0,0,7.146.259C6.944.029,6.834,0,6.112,0A1.94,1.94,0,0,0,5.33.066M.46,2.986a.7.7,0,0,0-.37.354.671.671,0,0,0-.023.612.887.887,0,0,0,.471.419c.06.012,2.021.021,4.357.021H9.141l-.6.895-.6.894-.916.912-.916.912-.992-.994C4.574,6.464,4.069,5.987,4,5.948a.786.786,0,0,0-.868.15.816.816,0,0,0-.15.762A15.436,15.436,0,0,0,4.049,8L5.084,9.033,3.555,10.564c-1.614,1.618-1.606,1.609-1.605,1.923a.82.82,0,0,0,.449.642.835.835,0,0,0,.6-.02,20.971,20.971,0,0,0,1.63-1.558L6.112,10.06l1.523,1.521c.838.837,1.568,1.539,1.623,1.559a.886.886,0,0,0,.574-.029.729.729,0,0,0,.339-1c-.025-.048-.717-.761-1.538-1.584l-1.493-1.5L8.168,8,9.2,6.961l.848-1.283.849-1.284h.872c.842,0,.876,0,1.027-.083a.686.686,0,0,0,.378-.6.68.68,0,0,0-.3-.645l-.153-.106L6.631,2.949c-4.961-.008-6.1,0-6.171.037m14.669,6.83c-.277.11-.2-.028-2.836,5.242-2.3,4.6-2.514,5.042-2.511,5.2a.7.7,0,0,0,.192.51.707.707,0,0,0,1.074-.021c.065-.074.5-.9.992-1.883l.874-1.75h4.961l.912,1.822c.965,1.927.97,1.935,1.264,2.034A.736.736,0,0,0,21,20.174c-.012-.093-.886-1.879-2.5-5.107-1.9-3.8-2.511-4.994-2.606-5.087a.782.782,0,0,0-.763-.164m1.981,5.778c0,.015-.772.027-1.717.027s-1.719-.008-1.719-.018.387-.791.86-1.736l.859-1.718.857,1.71c.472.94.859,1.721.86,1.735" transform="translate(-0.004 -0.002)" fill="#5067a8" fill-rule="evenodd"/>
    </svg>`;

    this.translateButton.id = "translateBtn";
    // this.translateButton.disabled = true;
    this.translateButton.className = "btn-transparent";
    this.translateButton.title = `${i18n.t("translate")}`;
    this.translateButton.innerHTML = translateSvg;
    this.translateButton.addEventListener("click", (e) => {
      e.preventDefault();
      let isTranslationMode = (globalThis as any).isTranslationMode;
      isTranslationMode = !isTranslationMode;

      if (!isTranslationMode) {
        (globalThis as any).isTranslationMode = false;
        const translationModeUi = new TranslationodeUIManager();
        translationModeUi.disableTranslationMode();
        return;
      }
      new LanguageTranslate().translate();
    });

    this.container.appendChild(this.undoButton);
    this.container.appendChild(this.redoButton);
    this.container.appendChild(this.translateButton);
  }

  render(container: HTMLElement) {
    container.appendChild(this.container);
  }
}
