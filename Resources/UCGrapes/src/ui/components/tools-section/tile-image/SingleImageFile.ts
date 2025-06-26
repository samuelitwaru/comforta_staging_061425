import { display } from "html2canvas/dist/types/css/property-descriptors/display";
import { ContentDataManager } from "../../../../controls/editor/ContentDataManager";
import { TileProperties } from "../../../../controls/editor/TileProperties";
import { ImageUploadManager } from "../../../../controls/ImageUploadManager";
import { InfoSectionManager } from "../../../../controls/InfoSectionManager";
import { ToolBoxService } from "../../../../services/ToolBoxService";
import { Image, ImageType, InfoType, Media } from "../../../../types";
import { ConfirmationBox } from "../../ConfirmationBox";
import { ImageUpload } from "./ImageUpload";
import { ImageUploadUi } from "./ImageUploadUi";
import { zIndex } from "html2canvas/dist/types/css/property-descriptors/z-index";
import { i18n } from "../../../../i18n/i18n";

export class SingleImageFile {
  private readonly mediaFile: Media;
  private readonly type: ImageType;
  private readonly infoId?: string;
  private readonly sectionId?: string;
  private readonly toolboxService: ToolBoxService;
  private readonly imageUpload: ImageUploadUi;
  private container: HTMLElement;
  private fileListContainer?: HTMLElement;
  private isCurrentlySelected: boolean = false;
  private controller: ImageUploadManager;
  private checkbox: HTMLElement | null = null;

  constructor(
    mediaFile: Media,
    controller: ImageUploadManager,
    imageUpload: ImageUploadUi
  ) {
    this.mediaFile = mediaFile;
    this.controller = controller;
    this.type = this.controller.getType;
    this.infoId = this.controller.getInfoId;
    this.sectionId = this.controller.getSectionId;
    this.toolboxService = new ToolBoxService();
    this.imageUpload = imageUpload;
    this.container = this.createContainer();

    // Initialize selection state before creating UI
    this.initializeSelectionState();
    this.initializeComponent();
  }

  /* Initialization Methods */
  private initializeSelectionState(): boolean {
    if (this.type !== "info" || !this.infoId) {
      this.isCurrentlySelected = false;
      return false;
    }

    try {
      const existingImages = this.getExistingImages();
      const isSelected = existingImages.some(
        (image) => image.InfoImageId === `id-${this.mediaFile.MediaId}`
      );

      this.isCurrentlySelected = isSelected;

      if (isSelected) {
        this.controller.addSelectedImage({
          Id: this.mediaFile.MediaId,
          Url: this.mediaFile.MediaUrl,
        });
      }

      return isSelected;
    } catch (error) {
      console.error("Error initializing existing images:", error);
      this.isCurrentlySelected = false;
      return false;
    }
  }

  private isImageSelected(): boolean {
    return this.isCurrentlySelected;
  }

  private getExistingImages(): Image[] {
    const pageId = (globalThis as any).currentPageId;
    if (!pageId) return [];

    const storedData = localStorage.getItem(`data-${pageId}`);
    if (!storedData) return [];

    const data = JSON.parse(storedData);
    const content = data?.PageInfoStructure?.InfoContent?.find(
      (content: InfoType) => content.InfoId === this.infoId
    );

    return content?.Images || [];
  }

  private createContainer(): HTMLElement {
    const container = document.createElement("div");
    container.className = "file-item valid";
    container.id = this.mediaFile.MediaId;
    return container;
  }

  private initializeComponent(): void {
    const img = this.createPreviewImage();
    const actionColumn = this.createActionColumn();

    this.container.appendChild(img);
    this.container.appendChild(actionColumn);

    // Setup click event for container to trigger checkbox selection
    this.setupContainerClickEvent();
  }

  /* UI Creation Methods */
  private createPreviewImage(): HTMLImageElement {
    const img = document.createElement("img");
    img.src = this.mediaFile.MediaUrl;
    img.alt = this.mediaFile.MediaName;
    img.className = "preview-image";
    return img;
  }

  private createActionColumn(): HTMLElement {
    const actionColumn = document.createElement("div");
    actionColumn.className = "action-column";

    Object.assign(actionColumn.style, {
      display: "flex",
      flexDirection: "row",
      gap: "5px",
      alignItems: "center",
      width: "calc(100% + 10px)",
      zIndex: "3",
      position: "absolute",
      top: "-16px",
      left: "-5px",
    });

    this.checkbox = this.createImageCheckbox();
    actionColumn.appendChild(this.checkbox);

    if (this.type !== "info") {
      this.checkbox.style.display = "none";
    }

    actionColumn.appendChild(this.createDeleteButton());

    return actionColumn;
  }

  public createImageCheckbox(): HTMLElement {
    const checkbox = document.createElement("span");
    checkbox.setAttribute("role", "checkbox");
    checkbox.setAttribute("aria-label", "Select image");
    checkbox.setAttribute("tabindex", "0");
    checkbox.title = i18n.t("sidebar.image_upload.select_image");
    checkbox.className = "select-media-checkbox";

    Object.assign(checkbox.style, {
      fontSize: "25px",
      lineHeight: "0.8",
      backgroundColor: "#fff",
      color: "#5068a8",
      cursor: "pointer",
      borderRadius: "4px",
      marginLeft: "2px",
    });

    this.updateCheckboxVisual(checkbox, this.isCurrentlySelected);

    checkbox.addEventListener("click", (e) => {
      if (this.checkMultipleDeleteMode()) return;
      e.stopPropagation();
      this.handleCheckboxClick();
    });

    checkbox.addEventListener("keydown", (e) => {
      if (e.key === " " || e.key === "Enter") {
        e.preventDefault();
        this.handleCheckboxClick();
      }
    });

    return checkbox;
  }

  private createDeleteButton(): HTMLElement {
    const deleteSpan = document.createElement("span");
    deleteSpan.className = "delete-media fa-regular fa-trash-can";
    deleteSpan.title = i18n.t("sidebar.image_upload.delete_image_title");

    if (this.imageUpload.isInDeleteMode) deleteSpan.style.display = "none";

    Object.assign(deleteSpan.style, {
      width: "33px",
      height: "33px",
      fontSize: "16px",
      color: "#5068a8",
      display: "flex",
      alignItems: "center",
      justifyContent: "center",
      cursor: "pointer",
      border: "1px solid #5068a8",
      marginLeft: "auto",
      marginRight: "4px",
      borderRadius: "50%",
    });

    deleteSpan.addEventListener("click", (e) => {
      e.stopPropagation();
      if (this.checkMultipleDeleteMode()) return;
      this.deleteEvent();
    });

    return deleteSpan;
  }

  private updateCheckboxVisual(checkbox: HTMLElement, isChecked: boolean): void {
    checkbox.classList.remove(
      "fa-solid", "fa-square-check", "selected-checkbox",
      "fa-regular", "fa-square"
    );

    if (isChecked) {
      checkbox.classList.add("fa-solid", "fa-square-check", "selected-checkbox");
      checkbox.style.color = "#5068a8"; // Green for selected
    } else {
      checkbox.classList.add("fa-regular", "fa-square");
      checkbox.style.color = "#5068a8"; // Default blue
    }

    checkbox.setAttribute("aria-checked", String(isChecked));
  }

  private handleCheckboxClick(): void {
    if (this.type === "info") {
      this.toggleImageSelection();
    } else {
      this.handleSingleSelection();
    }
  }

  private toggleImageSelection(): void {
    const newState = !this.isCurrentlySelected;
    this.setSelectionState(newState);
  }

  private handleSingleSelection(): void {
    // Clear other selections first
    this.controller.clearSelectedImages();
    this.clearOtherSelections();

    // Select this image
    this.setSelectionState(true);

    // Show image editor
    this.imageUpload.displayImageEditor(this.mediaFile, false);
  }

  private setSelectionState(isSelected: boolean): void {
    const wasSelected = this.isCurrentlySelected;
    this.isCurrentlySelected = isSelected;

    // Update checkbox visual
    if (this.checkbox) {
      this.updateCheckboxVisual(this.checkbox, isSelected);
      
      // Show/hide checkbox based on type and selection
      if (this.type !== "info") {
        this.checkbox.style.display = isSelected ? "block" : "none";
      }
    }

    // Update container visual state
    if (isSelected) {
      this.container.classList.add("selected");
    } else {
      this.container.classList.remove("selected", "highlighted");
    }

    // Handle controller state
    if (isSelected) {
      this.controller.addSelectedImage({
        Id: this.mediaFile.MediaId,
        Url: this.mediaFile.MediaUrl,
      });
      this.dispatchSelectionEvent("selected");
    } else if (!isSelected) {
      this.controller.removeSelectedImage(this.mediaFile.MediaId);
      this.dispatchSelectionEvent("unselected");
    }
  }

  private dispatchSelectionEvent(action: "selected" | "unselected"): void {
    const event = new CustomEvent("imageSelectionChanged", {
      detail: {
        mediaId: this.mediaFile.MediaId,
        mediaUrl: this.mediaFile.MediaUrl,
        action: action,
        isSelected: this.isCurrentlySelected,
      },
    });

    this.container.dispatchEvent(event);
  }

  private setupContainerClickEvent(): void {
    this.container.addEventListener("click", (e) => {
      e.preventDefault();
      if (this.checkMultipleDeleteMode()) return;
      if ((e.target as HTMLElement).closest('.action-column')) {
        return;
      }
      // Trigger checkbox behavior
      this.handleCheckboxClick();
    });
  }

  private checkMultipleDeleteMode(): boolean {
    const multipleDeleteToggle = document.getElementById("selectAllCheckbox") as HTMLInputElement;
    
    if (multipleDeleteToggle && multipleDeleteToggle.ariaChecked === "true") {
        return true;
    }
    
    return false;
  }

  private clearOtherSelections(): void {
    document.querySelectorAll(".file-item").forEach((element) => {
      if (element !== this.container) {
        element.classList.remove("selected");
        const checkbox = element.querySelector(".select-media-checkbox") as HTMLElement;
        if (checkbox) {
          // Reset other checkboxes
          checkbox.classList.remove(
            "fa-solid", "fa-square-check", "selected-checkbox"
          );
          checkbox.classList.add("fa-regular", "fa-square");
          checkbox.style.color = "#5068a8";
          
          // Hide checkbox if not info type
          const container = element.closest('.file-item') as HTMLElement;
          if (container && !container.classList.contains('info-type')) {
            checkbox.style.display = "none";
          }
        }
      }
    });
  }

  public deleteEvent(): void {
    const confirmationBox = new ConfirmationBox(
      "Are you sure you want to delete this media file?",
      "Delete media",
      this.handleDeleteConfirmation.bind(this)
    );
    confirmationBox.render(document.body);
  }

  private async handleDeleteConfirmation(): Promise<void> {
    try {
      if (this.isCurrentlySelected) {
        this.setSelectionState(false);
      }

      await this.toolboxService.deleteMedia(this.mediaFile.MediaId);
      this.removeFromDOM();
      this.imageUpload.loadMediaFiles();
      this.imageUpload.refreshUploadArea();
      await this.controller.refreshEditorPages();
    } catch (error) {
      console.error("Error deleting media:", error);
    }
  }

  private removeFromDOM(): void {
    const mediaItem = document.getElementById(this.mediaFile.MediaId);
    mediaItem?.remove();
  }

  /* Public Methods */
  public getElement(): HTMLElement {
    return this.container;
  }

  public render(container: HTMLElement): void {
    // Add type class for easier identification
    if (this.type === "info") {
      this.container.classList.add("info-type");
    }
    container.appendChild(this.container);
  }

  public unselectImage(): void {
    this.setSelectionState(false);
  }

  public getSelectionState(): boolean {
    return this.isCurrentlySelected;
  }

  public selectImage(): void {
    this.setSelectionState(true);
  }

  // Method to programmatically trigger checkbox click
  public triggerSelection(): void {
    this.handleCheckboxClick();
  }
}