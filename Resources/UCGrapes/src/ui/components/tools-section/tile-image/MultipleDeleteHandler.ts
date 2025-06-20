// MultipleDeleteManager.ts
import { ImageUploadManager } from "../../../../controls/ImageUploadManager";
import { ConfirmationBox } from "../../ConfirmationBox";

export class MultipleDeleteHandler {
  private modalContent: HTMLElement;
  private controller: ImageUploadManager;
  private fileListElement: HTMLElement | null = null;
  private isMultipleDeleteChecked: boolean = false;
  public isInDeleteMode: boolean = false;
  private selectedImagesToDelete: Set<string> = new Set();
  private checkboxLabel!: HTMLLabelElement;
  public deleteImageButton!: HTMLSpanElement;
  private onRefreshCallback: () => void;
  private onLoadMediaCallback: () => void;
  private outsideClickHandler: ((event: Event) => void) | null = null;
  private multipleDeleteElement: HTMLElement | null = null;

  constructor(
    modalContent: HTMLElement,
    controller: ImageUploadManager,
    fileListElement: HTMLElement | null,
    onRefreshCallback: () => void,
    onLoadMediaCallback: () => void
  ) {
    this.modalContent = modalContent;
    this.controller = controller;
    this.fileListElement = fileListElement;
    this.onRefreshCallback = onRefreshCallback;
    this.onLoadMediaCallback = onLoadMediaCallback;
  }

  public createMultipleDeleteElement(): void {
    const deleteImageDiv: HTMLDivElement = document.createElement("div");
    deleteImageDiv.className = "multiple-delete";
    deleteImageDiv.id = "multipleDelete";
    deleteImageDiv.style.display = "none"; 
    this.multipleDeleteElement = deleteImageDiv;

    // Create checkbox container
    const checkboxContainer: HTMLDivElement = document.createElement("div");
    checkboxContainer.className = "checkbox-container";

    // Create checkbox
    const checkbox: HTMLSpanElement = document.createElement("span");
    checkbox.role = "checkbox";
    checkbox.id = "selectAllCheckbox";
    checkbox.className = "select-all-checkbox fa-regular fa-square";
    checkbox.setAttribute("aria-checked", "false");

    // Create label for checkbox
    this.checkboxLabel = document.createElement("label");
    this.checkboxLabel.htmlFor = "selectAllCheckbox";
    this.checkboxLabel.className = "checkbox-label";
    this.checkboxLabel.innerText = "Select images";
    this.checkboxLabel.style.cursor = "pointer";

    // Create counter span
    const counterSpan: HTMLSpanElement = document.createElement("span");
    counterSpan.className = "selection-counter";
    counterSpan.id = "selectionCounter";
    counterSpan.style.display = "none"; // Initially hidden

    // Create deselect all span
    const deselectSpan: HTMLSpanElement = document.createElement("span");
    deselectSpan.className = "deselect-all";
    deselectSpan.id = "deselectAll";
    deselectSpan.innerText = "Deselect all";
    deselectSpan.style.display = "none"; // Initially hidden

    this.deleteImageButton = document.createElement("span");
    this.deleteImageButton.className = "delete-images-button";
    this.deleteImageButton.innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" width="28.5" height="30" viewBox="0 0 14.5 16">
        <g id="Icon_feather-trash-2" data-name="Icon feather-trash-2" transform="translate(0.5 0.5)">
          <path id="Path_68" data-name="Path 68" d="M4.5,9H18" transform="translate(-4.5 -6)" fill="none" stroke="#cb4545" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
          <path id="Path_69" data-name="Path 69" d="M18.572,6V16.5A1.542,1.542,0,0,1,16.99,18H9.082A1.542,1.542,0,0,1,7.5,16.5V6M9.872,6V4.5A1.542,1.542,0,0,1,11.454,3h3.163A1.542,1.542,0,0,1,16.2,4.5V6" transform="translate(-6.286 -3)" fill="none" stroke="#cb4545" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
          <path id="Path_70" data-name="Path 70" d="M15,16.5v3.643" transform="translate(-9.75 -9.199)" fill="none" stroke="#cb4545" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
          <path id="Path_71" data-name="Path 71" d="M21,16.5v3.643" transform="translate(-12.75 -9.199)" fill="none" stroke="#cb4545" stroke-linecap="round" stroke-linejoin="round" stroke-width="1"/>
        </g>
      </svg>`;

    // Append elements to checkbox container
    checkboxContainer.appendChild(checkbox);
    checkboxContainer.appendChild(this.checkboxLabel);
    checkboxContainer.appendChild(counterSpan);
    checkboxContainer.appendChild(deselectSpan);
    checkboxContainer.appendChild(this.deleteImageButton);

    // Append container to main div
    deleteImageDiv.appendChild(checkboxContainer);

    // Add event listeners
    this.setupMultipleDeleteListeners(
      this.checkboxLabel,
      checkbox,
      counterSpan,
      deselectSpan,
      this.deleteImageButton
    );

    this.modalContent.appendChild(deleteImageDiv);
  }

  private setupMultipleDeleteListeners(
    checkboxLabel: HTMLLabelElement,
    checkbox: HTMLSpanElement,
    counterSpan: HTMLSpanElement,
    deselectSpan: HTMLSpanElement,
    deleteImageButton: HTMLSpanElement
  ): void {
    checkboxLabel.addEventListener("click", (e: Event): void => {
      e.preventDefault();
      checkbox.click();
      e.stopPropagation();
    });
    checkbox.addEventListener("click", (e: Event) => {
      this.isMultipleDeleteChecked = !this.isMultipleDeleteChecked;

      if (this.isMultipleDeleteChecked) {
        // Update checkbox appearance
        checkbox.className = "select-all-checkbox fa-solid fa-square-check";
        checkbox.setAttribute("aria-checked", "true");

        // Hide label, show counter and deselect option
        this.checkboxLabel.style.display = "none";
        counterSpan.style.display = "inline";
        deselectSpan.style.display = "inline";

        // Add checkboxes to images
        this.removeImageCheckboxes();
        this.addImageCheckboxes();

        // Update counter
        this.updateSelectionCounter(counterSpan);
        this.onRefreshCallback();
        const modalActions = this.modalContent.querySelector(
          ".modal-actions"
        ) as HTMLElement;
        if (modalActions) modalActions.style.display = "none";

        // Add outside click listener when entering delete mode
        this.addOutsideClickListener(checkbox, counterSpan, deselectSpan);
      } else {
        this.resetSelection(checkbox, counterSpan, deselectSpan);
      }
    });

    // Deselect all click event
    deselectSpan.addEventListener("click", (): void => {
      this.resetSelection(checkbox, counterSpan, deselectSpan);
    });

    deleteImageButton.addEventListener("click", (e: Event): void => {
      e.preventDefault();
      e.stopPropagation();
      this.deleteEvent();
    });
  }

  private addOutsideClickListener(
    checkbox: HTMLSpanElement,
    counterSpan: HTMLSpanElement,
    deselectSpan: HTMLSpanElement
  ): void {
    // Remove existing listener if it exists
    this.removeOutsideClickListener();

    // Create the outside click handler
    this.outsideClickHandler = (event: Event): void => {
      const target = event.target as HTMLElement;

      // Check if the click is outside the multiple delete interface and file list
      const isInsideMultipleDelete =
        this.multipleDeleteElement?.contains(target);
      const isInsideFileList = this.fileListElement?.contains(target);
      const isInsideModal = this.modalContent.contains(target);

      // Only reset if:
      // 1. The click is inside the modal (to avoid interfering with other UI)
      // 2. The click is NOT inside the multiple delete interface
      // 3. The click is NOT inside the file list (to allow image selection)
      if (isInsideModal && !isInsideMultipleDelete && !isInsideFileList) {
        this.resetSelection(checkbox, counterSpan, deselectSpan);
      }
    };

    // Add the listener to the document
    document.addEventListener("click", this.outsideClickHandler, true);
  }

  private removeOutsideClickListener(): void {
    if (this.outsideClickHandler) {
      document.removeEventListener("click", this.outsideClickHandler, true);
      this.outsideClickHandler = null;
    }
  }

  public deleteEvent(): void {
    const confirmationBox = new ConfirmationBox(
      `Are you sure you want to delete these media files?`,
      "Delete media",
      this.handleDeleteConfirmation.bind(this)
    );
    confirmationBox.render(document.body);
  }

  private async handleDeleteConfirmation(): Promise<void> {
    try {
      await this.controller.deleteImages(this.selectedImagesToDelete);
      this.onLoadMediaCallback();
      this.clearSelection();
      this.onRefreshCallback();
      const modalActions = this.modalContent.querySelector(
        ".modal-actions"
      ) as HTMLElement;
      if (modalActions) modalActions.style.display = "none";
    } catch (error) {
      console.error("Error deleting media:", error);
    }
  }

  private resetSelection(
    checkbox: HTMLSpanElement,
    counterSpan: HTMLSpanElement,
    deselectSpan: HTMLSpanElement
  ): void {
    // Reset main checkbox
    checkbox.className = "select-all-checkbox fa-regular fa-square";
    checkbox.setAttribute("aria-checked", "false");
    this.isMultipleDeleteChecked = false;

    // Show label, hide counter and deselect option
    this.checkboxLabel.style.display = "inline";
    counterSpan.style.display = "none";
    deselectSpan.style.display = "none";
    this.deleteImageButton.style.display = "none";

    // Clear selected images and reset state
    this.selectedImagesToDelete.clear();
    this.isInDeleteMode = false;

    const deleteSingleMediaButtons = this.fileListElement?.querySelectorAll(
              ".delete-media"
            ) as NodeListOf<HTMLElement>;
    if (deleteSingleMediaButtons) {
        deleteSingleMediaButtons.forEach((button) => {
            button.style.removeProperty("opacity");
        });
    }

    // Remove all image checkboxes
    this.removeImageCheckboxes();

    // Remove the outside click listener
    this.removeOutsideClickListener();
  }

  private updateSelectionCounter(counterSpan: HTMLSpanElement): void {
    const count: number = this.selectedImagesToDelete.size;
    if (count > 0) {
      //   counterSpan.innerHTML = `&nbsp;&nbsp; ${count} selected &nbsp;`;
      //   counterSpan.style.display = "inline";
      this.deleteImageButton.style.display = "inline";
    } else {
      counterSpan.style.display = "none";
      this.deleteImageButton.style.display = "none";
    }
  }

  private addImageCheckboxes(): void {
    const images: NodeListOf<Element> | undefined =
      this.fileListElement?.querySelectorAll(".file-item");

    images?.forEach((image: Element): void => {
      const imageElement = image as HTMLElement;
      this.isInDeleteMode = true;

      const checkbox = imageElement.querySelector(
        ".select-media-checkbox"
      ) as HTMLElement;

      if (checkbox) {
        checkbox.style.display = "block";
        checkbox.style.fontSize = "20px";

        // Remove existing event listeners to prevent duplicates
        const newCheckbox = checkbox.cloneNode(true) as HTMLElement;
        checkbox.parentNode?.replaceChild(newCheckbox, checkbox);

        // Add click listener to checkbox
        newCheckbox.addEventListener("click", (e: Event): void => {
          e.stopPropagation();
          this.handleCheckboxClick(newCheckbox, imageElement);
        });

        // Add click listener to image element for selection in delete mode
        const imageClickHandler = (e: Event): void => {
          if (this.isInDeleteMode) {
            e.preventDefault();
            this.handleCheckboxClick(newCheckbox, imageElement);
          }
        };

        imageElement.addEventListener("click", imageClickHandler);

        // Store the handler reference for cleanup if needed
        (imageElement as any)._selectionHandler = imageClickHandler;

        imageElement.addEventListener("mouseover", (e: MouseEvent): void => {
          if (this.isInDeleteMode) {
            e.preventDefault();
            const deleteSingleMediaButton = imageElement.querySelector(
              ".delete-media"
            ) as HTMLElement;
            if (deleteSingleMediaButton)
              deleteSingleMediaButton.style.opacity = "0";
          }
        });
      }
    });
  }

  private handleCheckboxClick(
    checkbox: HTMLElement,
    imageElement: HTMLElement
  ): void {
    const isChecked = checkbox.classList.contains("selected-checkbox");
    const fileId = imageElement?.id;
    if (!isChecked) {
      // Select the image
      checkbox.className =
        "select-media-checkbox fa-solid fa-square-check selected-checkbox";
      checkbox.setAttribute("aria-checked", "true");

      if (fileId) {
        this.selectedImagesToDelete.add(fileId);
      }
    } else {
      // Deselect the image
      checkbox.className = "select-media-checkbox fa-regular fa-square";
      checkbox.setAttribute("aria-checked", "false");

      if (fileId) {
        this.selectedImagesToDelete.delete(fileId);
      }
    }

    // Update counter
    const counterSpan: HTMLSpanElement | null = document.getElementById(
      "selectionCounter"
    ) as HTMLSpanElement;

    if (counterSpan) {
      this.updateSelectionCounter(counterSpan);
    }
  }

  private removeImageCheckboxes(): void {
    const imageCheckboxes: NodeListOf<HTMLElement> | undefined =
      this.fileListElement?.querySelectorAll(".select-media-checkbox");

    const images: NodeListOf<Element> | undefined =
      this.fileListElement?.querySelectorAll(".file-item");

    imageCheckboxes?.forEach((checkbox: HTMLElement): void => {
      checkbox.className = "select-media-checkbox fa-regular fa-square";
      checkbox.style.display = "none";
      checkbox.setAttribute("aria-checked", "false");
    });

    images?.forEach((image: Element): void => {
      const imageElement = image as HTMLElement;
      if ((imageElement as any)._selectionHandler) {
        imageElement.removeEventListener(
          "click",
          (imageElement as any)._selectionHandler
        );
        delete (imageElement as any)._selectionHandler;
      }
    });
  }

  public getSelectedImages(): string[] {
    return Array.from(this.selectedImagesToDelete);
  }

  public getSelectedImagesCount(): number {
    return this.selectedImagesToDelete.size;
  }

  public clearSelection(): void {
    this.selectedImagesToDelete.clear();
    this.controller.clearSelectedImages();
    const checkbox = document.getElementById(
      "selectAllCheckbox"
    ) as HTMLSpanElement;
    const counterSpan = document.getElementById(
      "selectionCounter"
    ) as HTMLSpanElement;
    const deselectSpan = document.getElementById(
      "deselectAll"
    ) as HTMLSpanElement;

    if (checkbox && counterSpan && deselectSpan) {
      this.resetSelection(checkbox, counterSpan, deselectSpan);
    }
  }

  public updateFileListElement(fileListElement: HTMLElement | null): void {
    this.fileListElement = fileListElement;
  }

  public destroy(): void {
    this.removeOutsideClickListener();
  }
}
