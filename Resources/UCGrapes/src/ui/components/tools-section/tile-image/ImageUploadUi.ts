import { backgroundImage } from "html2canvas/dist/types/css/property-descriptors/background-image";
import { ImageUploadManager } from "../../../../controls/ImageUploadManager";
import { InfoSectionManager } from "../../../../controls/InfoSectionManager";
import { i18n } from "../../../../i18n/i18n";
import { InfoType, Media, Tile } from "../../../../types";
import { SingleImageFile } from "./SingleImageFile";
import { backgroundRepeat } from "html2canvas/dist/types/css/property-descriptors/background-repeat";
import { randomIdGenerator } from "../../../../utils/helpers";
import { MultipleDeleteHandler } from "./MultipleDeleteHandler";
import { ImageEditor } from "./ImageEditor";

export class ImageUploadUi {
  private modalContent: HTMLElement;
  private controller: ImageUploadManager;
  private fileListElement: HTMLElement | null = null;
  private isEditingMode: boolean = false;
  public isInDeleteMode: boolean = false;
  private sectionId?: string;
  private MultipleDeleteHandler: MultipleDeleteHandler;
  private imageEditor: ImageEditor;

  constructor(controller: ImageUploadManager) {
    this.controller = controller;
    this.sectionId = controller.getSectionId;
    this.modalContent = document.createElement("div");
    this.MultipleDeleteHandler = new MultipleDeleteHandler(
      this.modalContent,
      this.controller,
      this.fileListElement,
      this.refreshUploadArea.bind(this),
      this.loadMediaFiles.bind(this)
    );
    this.imageEditor = new ImageEditor(this.controller, this.modalContent);
    
    // Set up callback for image editor
    this.imageEditor.onUploadNewImage = () => {
      this.isEditingMode = false;
      this.MultipleDeleteHandler.clearSelection();
      this.refreshUploadArea();

      // Wait a bit longer to ensure DOM is updated and event listeners are attached
      setTimeout(() => {
        this.triggerFileInput();
      }, 500);
    };
    
    this.init();
  }

  private init() {
    this.modalContent.innerHTML = "";
    this.modalContent.className = "tb-modal-content";

    this.createModalHeader();
    this.createUploadArea();
    this.createModalActions();
    this.MultipleDeleteHandler.createMultipleDeleteElement();
    this.createFileListElement();
    this.loadExistingImageAndFiles();
  }


  /* UI Creation Methods */
  private createModalHeader() {
    const modalHeader = document.createElement("div");
    modalHeader.className = "tb-modal-header";

    const h2 = document.createElement("h2");
    h2.innerText = i18n.t("sidebar.image_upload.modal_title");

    const closeBtn = document.createElement("span");
    closeBtn.className = "close";
    closeBtn.innerHTML = `
      <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
        <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"></path>
      </svg>
    `;
    closeBtn.addEventListener("click", (e) => {
      e.preventDefault();
      this.closeModal();
    });

    modalHeader.appendChild(h2);
    modalHeader.appendChild(closeBtn);
    this.modalContent.appendChild(modalHeader);
  }

  private createUploadArea() {
    const uploadArea = document.createElement("div");
    uploadArea.className = "upload-area";
    uploadArea.id = "uploadArea";
    uploadArea.innerHTML = `
      <svg xmlns="http://www.w3.org/2000/svg" width="40.999" height="28.865" viewBox="0 0 40.999 28.865">
        <path id="Path_1040" data-name="Path 1040" d="M21.924,11.025a3.459,3.459,0,0,0-3.287,3.608,3.459,3.459,0,0,0,3.287,3.608,3.459,3.459,0,0,0,3.287-3.608A3.459,3.459,0,0,0,21.924,11.025ZM36.716,21.849l-11.5,14.432-8.218-9.02L8.044,39.89h41Z" transform="translate(-8.044 -11.025)" fill="#afadad"></path>
      </svg>
      <div class="upload-text">
        ${i18n.t("sidebar.image_upload.upload_message")}
      </div>
    `;

    this.setupDragAndDrop(uploadArea);
    this.modalContent.appendChild(uploadArea);
  }

  private triggerFileInput() {
    // const fileInput = this.modalContent.querySelector('#fileInput') as HTMLInputElement;

    const uploadArea = this.modalContent.querySelector(
      ".upload-area"
    ) as HTMLElement;

    if (uploadArea) {
      // this.setupDragAndDrop(uploadArea);
      uploadArea.click();
    }
    // if (fileInput) {
    //   fileInput.click();
    // }
  }

  private createFileListElement() {
    this.fileListElement = document.createElement("div");
    this.fileListElement.className = "file-list";
    this.fileListElement.id = "fileList";

    const loadingElement = document.createElement("div");
    loadingElement.id = "loading-media";
    loadingElement.className = "loading-media";
    this.fileListElement.appendChild(loadingElement);

    this.modalContent.appendChild(this.fileListElement);

    // Update the multiple delete manager with the new file list element
    this.MultipleDeleteHandler.updateFileListElement(this.fileListElement);
  }

  private createModalActions() {
    const modalActions = document.createElement("div");
    modalActions.className = "modal-actions";
    modalActions.style.display = "none";

    const cancelBtn = document.createElement("button");
    cancelBtn.className = "tb-btn tb-btn-outline";
    cancelBtn.id = "cancel-modal";
    cancelBtn.innerText = i18n.t("sidebar.image_upload.cancel");
    cancelBtn.addEventListener("click", (e) => {
      e.preventDefault();
      this.closeModal();
    });

    const saveBtn = document.createElement("button");
    saveBtn.className = "tb-btn tb-btn-primary";
    saveBtn.id = "save-modal";
    saveBtn.innerText = i18n.t("sidebar.image_upload.save");
    saveBtn.addEventListener("click", async (e) => {
      e.preventDefault();
      try {
        const opacityValue = this.imageEditor.getOpacityValue();
        const sectionId = this.imageEditor.getSectionId();
        await this.controller.handleSave(opacityValue, sectionId);
        this.closeModal();
      } catch (error) {
        console.error("Error saving images:", error);
      }
    });

    modalActions.appendChild(cancelBtn);
    modalActions.appendChild(saveBtn);
    this.modalContent.appendChild(modalActions);
  }

  /* UI Update Methods */
  public updateModalActions() {
    const modalActions = this.modalContent.querySelector(
      ".modal-actions"
    ) as HTMLElement;
    if (modalActions) {
      modalActions.style.display = this.controller.hasSelectedImages()
        ? "flex"
        : "none";
    }
  }

  public async loadExistingImageAndFiles() {
    const backgroundImageUrl = this.controller.getBackgroundImage();
    if (backgroundImageUrl) {
      await this.loadMediaFiles(backgroundImageUrl);
      return;
    }
    await this.loadMediaFiles();
  }

  public async loadMediaFiles(backgroundImageUrl?: string) {
    try {
      const media = await this.controller.loadMediaFiles();
      const selectContainer = this.modalContent.querySelector(
        "#multipleDelete"
      ) as HTMLElement;

      if (this.fileListElement) {
        this.fileListElement.innerHTML = "";
        this.fileListElement.removeAttribute("style");
        selectContainer.style.display = "block";

        if (media.length > 0) {
          let editorDisplayed = false;

          for (const item of media) {
            const singleImageFile = new SingleImageFile(
              item,
              this.controller,
              this
            );
            singleImageFile.render(this.fileListElement as HTMLElement);

            if (
              !editorDisplayed &&
              backgroundImageUrl &&
              item.MediaUrl === backgroundImageUrl
            ) {
              await this.displayImageEditor(item);
              editorDisplayed = true;
            }
          }

          const loadingElement = document.getElementById(
            "loading-media"
          ) as HTMLElement;
          if (loadingElement) {
            loadingElement.style.display = "none";
          }
        } else {
          if (selectContainer) {
            selectContainer.style.display = "none";
          }
          this.fileListElement.innerHTML = `<span color="#6c6c6c">No images added</span>`;
          this.fileListElement.style.display = "flex";
          this.fileListElement.style.justifyContent = "center";
          this.fileListElement.style.alignItems = "center";
        }
      }
    } catch (error) {
      console.error("Error loading media files:", error);
      if (this.fileListElement) {
        this.fileListElement.innerHTML =
          '<div class="error-message">Error loading media files. Please try again.</div>';
      }
    }
  }

  /* Image Editor Methods */
  public async displayImageEditor(mediaFile: Media, isSaved: boolean = true) {
    const isEditingModeActive = await this.imageEditor.displayImageEditor(mediaFile);
    if (isEditingModeActive) {
      this.updateModalActions();
      if (this.fileListElement && isSaved) {
        this.imageEditor.selectCurrentTileImage(this.fileListElement);
      }
      this.isEditingMode = true;
    }
  }

  /* Drag and Drop Methods */
  private setupDragAndDrop(uploadArea: HTMLElement) {
    const fileInput = document.createElement("input");
    fileInput.type = "file";
    fileInput.id = "fileInput";
    fileInput.multiple = true;
    fileInput.accept = "image/jpeg, image/jpg, image/png";
    fileInput.style.display = "none";
    uploadArea.appendChild(fileInput);

    const uploadText = uploadArea.querySelector(".upload-text");
    if (uploadText) {
      uploadText.addEventListener("click", (e) => {
        e.stopPropagation();
        if (this.checkIfIsEditingMode()) return;
        fileInput.click();
      });
    }

    uploadArea.addEventListener("click", (e) => {
      const isValidTarget =
        e.target === uploadArea ||
        e.target === uploadText ||
        (e.target as HTMLElement).closest("svg") ||
        (e.target as HTMLElement).closest(".upload-text");

      if (isValidTarget) {
        if (this.checkIfIsEditingMode()) return;
        fileInput.click();
      }
    });

    fileInput.addEventListener("change", async () => {
      if (fileInput.files && fileInput.files.length > 0) {
        this.showUploadSpinner(fileInput.files.length);

        const startTime = Date.now();
        const minSpinnerDuration = 1000;

        try {
          await this.uploadImages(fileInput.files);

          const elapsedTime = Date.now() - startTime;
          const remainingTime = Math.max(0, minSpinnerDuration - elapsedTime);

          if (remainingTime > 0) {
            await new Promise((resolve) => setTimeout(resolve, remainingTime));
          }

          this.refreshUploadArea();
          this.showSuccessMessage();
        } catch (error) {
          console.error("Error uploading files:", error);
          this.refreshUploadArea();
        }
      }
    });

    uploadArea.addEventListener("dragover", (e) => {
      e.preventDefault();
      if (this.checkIfIsEditingMode()) return;
      uploadArea.classList.add("drag-over");
    });

    uploadArea.addEventListener("dragleave", (e) => {
      e.preventDefault();
      if (this.checkIfIsEditingMode()) return;
      uploadArea.classList.remove("drag-over");
    });

    uploadArea.addEventListener("drop", async (e) => {
      e.preventDefault();
      if (this.checkIfIsEditingMode()) return;
      uploadArea.classList.remove("drag-over");

      if (e.dataTransfer?.files && e.dataTransfer.files.length > 0) {
        this.showUploadSpinner(e.dataTransfer.files.length);

        const startTime = Date.now();
        const minSpinnerDuration = 1000;
        try {
          await this.uploadImages(e.dataTransfer.files);

          const elapsedTime = Date.now() - startTime;
          const remainingTime = Math.max(0, minSpinnerDuration - elapsedTime);

          if (remainingTime > 0) {
            await new Promise((resolve) => setTimeout(resolve, remainingTime));
          }
          this.refreshUploadArea();
          this.showSuccessMessage();
        } catch (error) {
          console.error("Error uploading files:", error);
          this.refreshUploadArea();
        }
      }
    });
  }

  private async uploadImages(files: FileList) {
    const dataTransfer = new DataTransfer();
    const totalFiles = files.length;

    // Compression phase
    for (let i = 0; i < files.length; i++) {
      const file = files[i];
      this.updateProgress(i + 1, totalFiles, "compressing");
      const compressedFile = await this.controller.compressLargeFile(file);
      dataTransfer.items.add(compressedFile);
    }

    const fileArray = Array.from(dataTransfer.files);

    // Upload phase
    for (let i = 0; i < fileArray.length; i++) {
      const file = fileArray[i];
      this.updateProgress(i + 1, totalFiles, "uploading");
      await this.controller.handleFileUpload(file);
    }

    await this.loadMediaFiles();
  }

  private updateProgress(
    current: number,
    total: number,
    phase: "compressing" | "uploading"
  ) {
    const progressContainer = this.modalContent.querySelector(
      ".progress-container"
    );
    if (!progressContainer) return;

    const progressBar = progressContainer.querySelector(
      ".progress-bar"
    ) as HTMLElement;
    const progressText = progressContainer.querySelector(
      ".progress-text"
    ) as HTMLElement;
    const progressCounter = progressContainer.querySelector(
      ".progress-counter"
    ) as HTMLElement;

    if (progressBar && progressText && progressCounter) {
      const percentage = Math.round((current / total) * 100);
      progressBar.style.width = `${percentage}%`;

      const phaseText =
        phase === "compressing"
          ? i18n.t("sidebar.image_upload.preparing_images")
          : i18n.t("sidebar.image_upload.uploading_images");
      progressText.textContent = `${phaseText}`;
      progressCounter.textContent = `${current} / ${total}`;
    }
  }

 private showUploadSpinner(fileCount: number = 1) {
    const uploadArea = this.modalContent.querySelector(
      ".upload-area"
    ) as HTMLElement;
    if (uploadArea) {
      const showProgress = fileCount > 1;

      uploadArea.innerHTML = `
        <div class="upload-spinner" style="display: flex; flex-direction: column; align-items: center; justify-content: center;">
          <div style="
            width: 35px; 
            height: 35px; 
            border: 3px solid #e3e3e3; 
            border-top: 3px solid #5068a8; 
            border-radius: 50%; 
            animation: spin 0.8s linear infinite;
            margin-bottom: ${showProgress ? "20px" : "0px"};
          "></div>
          ${
            showProgress
              ? `
            <div class="progress-container" style="width: 100%; max-width: 200px;">
              <div class="progress-text" style="
                font-size: 12px;
                color: #666;
                text-align: center;
                margin-bottom: 8px;
              ">${i18n.t("sidebar.image_upload.preparing_images")}</div>
              
              <div style="
                width: 100%;
                height: 8px;
                background-color: #e3e3e3;
                border-radius: 4px;
                overflow: hidden;
                margin-bottom: 8px;
              ">
                <div class="progress-bar" style="
                  height: 100%;
                  background-color: #5068a8;
                  width: 0%;
                  transition: width 0.3s ease;
                "></div>
              </div>
              
              <div class="progress-counter" style="
                font-size: 11px;
                color: #888;
                text-align: center;
                font-weight: 500;
              ">0 / ${fileCount}</div>
            </div>
          `
              : ""
          }
        </div>
        <style>
          @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
          }
        </style>
      `;
    }
  }
  public refreshUploadArea() {
    const uploadArea = this.modalContent.querySelector(
      ".upload-area"
    ) as HTMLElement;
    if (uploadArea) {
      uploadArea.innerHTML = `
    <svg xmlns="http://www.w3.org/2000/svg" width="40.999" height="28.865" viewBox="0 0 40.999 28.865">
      <path id="Path_1040" data-name="Path 1040" d="M21.924,11.025a3.459,3.459,0,0,0-3.287,3.608,3.459,3.459,0,0,0,3.287,3.608,3.459,3.459,0,0,0,3.287-3.608A3.459,3.459,0,0,0,21.924,11.025ZM36.716,21.849l-11.5,14.432-8.218-9.02L8.044,39.89h41Z" transform="translate(-8.044 -11.025)" fill="#afadad"></path>
    </svg>
    <div class="upload-text">
      ${i18n.t("sidebar.image_upload.upload_message")}
    </div>
    <input type="file" id="fileInput" multiple="" accept="image/jpeg, image/jpg, image/png" style="display: none;">
    `;
      this.isEditingMode = false;
    }
  }

  private showSuccessMessage() {
    const uploadArea = this.modalContent.querySelector(
      ".upload-area"
    ) as HTMLElement;
    if (uploadArea) {
      const uploadText = uploadArea.querySelector(
        ".upload-text"
      ) as HTMLElement;

      if (uploadText) {
        const successMessage = document.createElement("div");
        successMessage.className = "success-message";
        successMessage.style.cssText =
          "color: #4CAF50; font-size: 14px; margin-top: 10px;";
        successMessage.innerText = i18n.t(
          "sidebar.image_upload.upload_success_message"
        );

        uploadText.insertAdjacentElement("afterend", successMessage);

        setTimeout(() => {
          if (successMessage && successMessage.parentNode) {
            successMessage.style.transition = "opacity 0.5s ease-out";
            successMessage.style.opacity = "0";

            setTimeout(() => {
              if (successMessage && successMessage.parentNode) {
                successMessage.remove();
              }
            }, 500);
          }
        }, 4500);
      }
    }
  }

  private checkIfIsEditingMode() {
    if (this.isEditingMode) return true;
    return false;
  }

  /* Utility Methods */
  private closeModal() {
    const modal = this.modalContent.parentElement as HTMLElement;
    if (modal) {
      modal.style.display = "none";
      modal.remove();
    }
  }

  public render(container: HTMLElement) {
    container.appendChild(this.modalContent);
  }
}