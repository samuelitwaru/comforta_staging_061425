import { fontWeight } from "html2canvas/dist/types/css/property-descriptors/font-weight";

interface DynamicFormElements {
  submitButtons: NodeListOf<HTMLInputElement>;
  fileInputButtons: NodeListOf<HTMLSpanElement>;
  stepNumberBulletSelecteds: NodeListOf<HTMLDivElement>;
  tableStepBulletCheckeds: NodeListOf<HTMLDivElement>;
  nextButtons: NodeListOf<HTMLButtonElement>;
  prevButtons: NodeListOf<HTMLButtonElement>;
}

declare const window: any;

export class UrlPageEditor {
  private editor: any;

  constructor(editor: any) {
    this.editor = editor;
  }

  async initialise(linkUrl: string): Promise<void> {
    try {
      this.editor.DomComponents.clear();
      this.defineObjectComponent();
      this.setEditorComponents(linkUrl);
    } catch (error: any) {
      console.error("Error setting up object component:", error.message);
    }
  }

  private defineObjectComponent(): void {
    this.editor.DomComponents.addType("object", {
      isComponent: (el: any) => el.tagName === "OBJECT",
      model: {
        defaults: {
          tagName: "object",
          draggable: true,
          droppable: false,
          attributes: {
            width: "100%",
            height: "300vh",
          },
          styles: this.getComponentStyles(),
        },
      },
      view: {
        onRender: ({ el, model }: any) => {
          this.setupObjectElement(el, model);
        },
      },
    });
  }

  private getComponentStyles(): string {
    return `
      .form-frame-container {
        overflow-x: hidden;
        overflow-y: auto;
        position: relative;
        min-height: 300px;
      }

      /* Preloader styles */
      .preloader-wrapper {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        z-index: 1000;
      }

      .preloader {
        width: 32px;
        height: 32px;
        background-image: url('/Resources/UCGrapes/public/images/spinner.gif');
        background-size: contain;
        background-repeat: no-repeat;
      }

      /* Custom scrollbar styles */
      .form-frame-container::-webkit-scrollbar {
        width: 6px;
        height: 0;
      }

      .form-frame-container::-webkit-scrollbar-track {
        background: #f1f1f1;
        border-radius: 3px;
      }

      .form-frame-container::-webkit-scrollbar-thumb {
        background: #888;
        border-radius: 3px;
      }

      .form-frame-container::-webkit-scrollbar-thumb:hover {
        background: #555;
      }

      /* Firefox scrollbar styles */
      .form-frame-container {
        scrollbar-width: thin;
        scrollbar-color: #888 #f1f1f1;
      }
      
      .fallback-message {
        margin-bottom: 10px;
        color: #666;
      }
    `;
  }

  private setupObjectElement(el: HTMLElement, model: any): void {
    this.addFallbackContent(el, model);
    this.addEventListeners(el);
  }

  private addFallbackContent(el: HTMLElement, model: any): void {
    const fallbackMessage =
      model.get("attributes").fallbackMessage || "Content cannot be displayed";
    const fallbackContent = `
      <div class="fallback-content">
        <p class="fallback-message">${fallbackMessage}</p>
        <a href="${model.get("attributes").data}" 
           target="_blank" 
           class="fallback-link">
          Open in New Window
        </a>
      </div>
    `;
    el.insertAdjacentHTML("beforeend", fallbackContent);
  }

  private addEventListeners(el: HTMLElement): void {
    el.addEventListener("load", () => this.handleObjectLoad(el));
    el.addEventListener("error", () => this.handleObjectError(el));
  }

  private handleObjectLoad(el: HTMLElement): void {
    this.hidePreloader(el);
    this.hideFallback(el);

    const objectElement = el as HTMLObjectElement;
    const dynamicFormContent = objectElement.contentDocument;

    if (!dynamicFormContent) return;

    this.setGlobalReferences(dynamicFormContent);
    this.applyInitialStyles(dynamicFormContent);
    this.setupMutationObservers(dynamicFormContent);
  }

  private handleObjectError(el: HTMLElement): void {
    this.hidePreloader(el);
    this.showFallback(el);
  }

  private hidePreloader(el: HTMLElement): void {
    const container = el.closest(".form-frame-container");
    const preloaderWrapper = container?.querySelector(".preloader-wrapper") as HTMLElement;
    if (preloaderWrapper) {
      preloaderWrapper.style.display = "none";
    }
  }

  private hideFallback(el: HTMLElement): void {
    const fallback = el.querySelector(".fallback-content") as HTMLElement;
    if (fallback) {
      fallback.style.display = "none";
    }
  }

  private showFallback(el: HTMLElement): void {
    const fallback = el.querySelector(".fallback-content") as HTMLElement;
    if (fallback) {
      fallback.style.display = "flex";
      fallback.style.flexDirection = "column";
      fallback.style.justifyContent = "start";
    }
  }

  private setGlobalReferences(dynamicFormContent: Document): void {
    window.DynamicForm = dynamicFormContent;
  }

  private applyInitialStyles(dynamicFormContent: Document): void {
    const elements = this.getAllDynamicFormElements(dynamicFormContent);

    this.styleSubmitButtons(elements.submitButtons);
    this.styleFileInputButtons(elements.fileInputButtons);
    this.styleStepBullets(elements.stepNumberBulletSelecteds);
    this.styleStepBullets(elements.tableStepBulletCheckeds);
    this.styleWizardButtons(elements.nextButtons);
    this.styleWizardButtons(elements.prevButtons);

    // Set global references
    window.DynamicFormSubmitButtons = elements.submitButtons;
    window.DynamicFormFileInputButtons = elements.fileInputButtons;
    window.DynamicFormstepNumberBulletSelecteds = elements.stepNumberBulletSelecteds;
    window.DynamicFormtableStepBulletCheckeds = elements.tableStepBulletCheckeds;
    window.DynamicFormWizardNext = elements.nextButtons;
    window.DynamicFormWizardPrevious = elements.prevButtons;
  }

  private getAllDynamicFormElements(dynamicFormContent: Document): DynamicFormElements {
    return {
      submitButtons: dynamicFormContent.querySelectorAll<HTMLInputElement>(".MobileSubmitBtn"),
      fileInputButtons: dynamicFormContent.querySelectorAll<HTMLSpanElement>(".fileinput-button"),
      stepNumberBulletSelecteds: dynamicFormContent.querySelectorAll<HTMLDivElement>(
        ".TableStepBulletSelected"
      ),
      tableStepBulletCheckeds:
        dynamicFormContent.querySelectorAll<HTMLDivElement>(".TableStepBulletChecked"),
      nextButtons: dynamicFormContent.querySelectorAll<HTMLButtonElement>(".NxtWzdBtn"),
      prevButtons: dynamicFormContent.querySelectorAll<HTMLButtonElement>(".PrevWzdBtn"),
    };
  }

  private styleSubmitButtons(buttons: NodeListOf<HTMLInputElement>): void {
    buttons.forEach((button) => {
      button.style.backgroundColor = window.DynamicFormSubmitButtonColor || "";
      button.style.border = "0px";
    });
  }

  private styleFileInputButtons(buttons: NodeListOf<HTMLSpanElement>): void {
    buttons.forEach((span) => {
      span.style.backgroundColor = window.DynamicFormSubmitButtonColor || "";
      span.style.fontWeight = "normal";
      span.style.fontSize = "14px";
      span.style.fontStyle = "normal";
      span.style.border = "0px";
      span.style.borderRadius = "4px";
    });
  }

  private styleStepBullets(bullets: NodeListOf<HTMLDivElement>): void {
    bullets.forEach((bullet) => {
      bullet.style.backgroundColor = window.DynamicFormSubmitButtonColor || "";
    });
  }

  private styleWizardButtons(buttons: NodeListOf<HTMLButtonElement>): void {
    buttons.forEach((button) => {
      button.style.backgroundColor = window.DynamicFormSubmitButtonColor || "";
      button.style.border = "0px";
    });
  }

  private setupMutationObservers(dynamicFormContent: Document): void {
    const cellWizardActions =
      dynamicFormContent.querySelectorAll<HTMLDivElement>(".CellWizardActions");
    const wizardStepsCell = dynamicFormContent.querySelectorAll<HTMLDivElement>(".WizardStepsCell");

    cellWizardActions.forEach((cell) => {
      this.createMutationObserver(cell, () => this.handleWizardActionsMutation(dynamicFormContent));
    });

    wizardStepsCell.forEach((cell) => {
      this.createMutationObserver(cell, () => this.handleWizardStepsMutation(dynamicFormContent));
    });
  }

  private createMutationObserver(element: HTMLElement, callback: () => void): void {
    const observer = new MutationObserver((mutations) => {
      mutations.forEach((mutation) => {
        this.logMutationType(mutation);
      });
      callback();
    });

    const config = {
      attributes: true,
      childList: true,
      characterData: true,
      subtree: true,
    };

    observer.observe(element, config);
  }

  private logMutationType(mutation: MutationRecord): void {
    const prefix = (mutation.target instanceof Element && mutation.target.closest(".CellWizardActions")) ? "Actions" : "Steps";

    switch (mutation.type) {
      case "attributes":
        console.log(`${prefix} Attribute changed:`, mutation.attributeName);
        break;
      case "childList":
        console.log(`${prefix} Child elements changed`);
        break;
      case "characterData":
        console.log(`${prefix} Text content changed`);
        break;
    }
  }

  private handleWizardActionsMutation(dynamicFormContent: Document): void {
    const elements = {
      nextButtons: dynamicFormContent.querySelectorAll<HTMLButtonElement>(".NxtWzdBtn"),
      prevButtons: dynamicFormContent.querySelectorAll<HTMLButtonElement>(".PrevWzdBtn"),
    };

    this.styleWizardButtons(elements.nextButtons);
    this.styleWizardButtons(elements.prevButtons);

    // Update global references
    window.DynamicFormWizardNext = elements.nextButtons;
    window.DynamicFormWizardPrevious = elements.prevButtons;
  }

  private handleWizardStepsMutation(dynamicFormContent: Document): void {
    const elements = {
      stepNumberBulletSelecteds: dynamicFormContent.querySelectorAll<HTMLDivElement>(
        ".TableStepBulletSelected"
      ),
      tableStepBulletCheckeds:
        dynamicFormContent.querySelectorAll<HTMLDivElement>(".TableStepBulletChecked"),
      fileInputButtons: dynamicFormContent.querySelectorAll<HTMLSpanElement>(".fileinput-button"),
    };

    this.styleStepBullets(elements.stepNumberBulletSelecteds);
    this.styleStepBullets(elements.tableStepBulletCheckeds);
    this.styleFileInputButtons(elements.fileInputButtons);

    // Update global references
    window.DynamicFormstepNumberBulletSelecteds = elements.stepNumberBulletSelecteds;
    window.DynamicFormtableStepBulletCheckeds = elements.tableStepBulletCheckeds;
    window.DynamicFormFileInputButtons = elements.fileInputButtons;
  }

  private setEditorComponents(linkUrl: string): void {
    this.editor.setComponents(`
      <div class="form-frame-container" id="frame-container">
        <div class="preloader-wrapper">
          <div class="preloader"></div>
        </div>
        <object 
          data="${linkUrl}"
          type="text/html"
          width="100%"
          height="800px"
          fallbackMessage="Unable to load the content. Please try opening it in a new window.">
        </object>
      </div>
    `);
  }
}
