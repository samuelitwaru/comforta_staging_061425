import { i18n } from "../../i18n/i18n";

export class EditActions {
  private readonly undoButton: HTMLButtonElement;
  private readonly redoButton: HTMLButtonElement;
  private readonly translateButton: HTMLButtonElement;
  private readonly container: HTMLDivElement;

  constructor() {
    this.container = this.createElement("div");
    this.undoButton = this.createElement("button");
    this.redoButton = this.createElement("button");
    this.translateButton = this.createElement("button");
    this.initializeComponent();
  }

  private createElement<T extends keyof HTMLElementTagNameMap>(
    tagName: T
  ): HTMLElementTagNameMap[T] {
    return document.createElement(tagName);
  }

  private initializeComponent(): void {
    this.setupContainer();
    this.setupUndoButton();
    this.setupRedoButton();
    // this.setupTranslateButton();
    this.appendButtonsToContainer();
  }

  private setupContainer(): void {
    this.container.classList.add("edit-actions");
  }

  private setupUndoButton(): void {
    this.undoButton.id = "undo";
    this.undoButton.disabled = true;
    this.undoButton.className = "btn-transparent";
    this.undoButton.title = `${i18n.t("undo")} (ctrl+z)`;
    this.undoButton.innerHTML = "<span class='fa fa-undo'></span>";
  }

  private setupRedoButton(): void {
    this.redoButton.id = "redo";
    this.redoButton.disabled = true;
    this.redoButton.className = "btn-transparent";
    this.redoButton.title = `${i18n.t("undo")} (ctrl+shift+z)`;
    this.redoButton.innerHTML = "<span class='fa fa-redo'></span>";
  }

  private appendButtonsToContainer(): void {
    this.container.appendChild(this.undoButton);
    this.container.appendChild(this.redoButton);
  }

  public render(container: HTMLElement): void {
    container.appendChild(this.container);
  }
}
