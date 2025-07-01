import { ImageUploadManager } from "../../../../controls/ImageUploadManager";
import { i18n } from "../../../../i18n/i18n";
import { InfoType, Media, Tile } from "../../../../types";

export class ImageEditor {
  private controller: ImageUploadManager;
  private modalContent: HTMLElement;
  private opacityValue!: number;
  private sectionId?: string;
  private previousContainerDimensions?: { width: number; height: number };

  constructor(controller: ImageUploadManager, modalContent: HTMLElement) {
    this.controller = controller;
    this.modalContent = modalContent;
    this.sectionId = controller.getSectionId;
  }

  public async displayImageEditor(mediaFile: Media) {
    if (this.controller.getType === "info" || this.controller.getType === "cta") {
      return;
    }

    const decodedUrl = decodeURIComponent(decodeURIComponent(mediaFile.MediaUrl));

    const image = {
      Id: mediaFile.MediaId,
      Url: decodedUrl,
    };

    this.controller.clearSelectedImages();
    this.controller.addSelectedImage(image);
    const uploadArea = this.modalContent.querySelector(".upload-area") as HTMLElement;

    // Create the image element first to get dimensions
    const imgElement = document.createElement("img");
    imgElement.src = decodedUrl;
    imgElement.style.display = "block";
    imgElement.style.maxHeight = "350px";
    imgElement.style.maxWidth = "680px";
    imgElement.style.width = "auto";
    imgElement.style.height = "auto";

    const imageContainer = document.createElement("div");
    imageContainer.className = "image-editor-container";

    // Wait for image to load to get proper dimensions
    await new Promise((resolve) => {
      imgElement.onload = () => {
        // Get the actual rendered dimensions of the image
        const imgWidth = imgElement.offsetWidth || imgElement.naturalWidth;
        const imgHeight = imgElement.offsetHeight || imgElement.naturalHeight;

        // Calculate the actual displayed size considering max constraints
        let displayWidth = imgElement.naturalWidth;
        let displayHeight = imgElement.naturalHeight;

        // Apply max width constraint
        if (displayWidth > 680) {
          const ratio = 680 / displayWidth;
          displayWidth = 680;
          displayHeight = displayHeight * ratio;
        }

        // Apply max height constraint
        if (displayHeight > 350) {
          const ratio = 350 / displayHeight;
          displayHeight = 350;
          displayWidth = displayWidth * ratio;
        }

        // Set container to exactly match the image size
        Object.assign(imageContainer.style, {
          position: "relative",
          width: `${displayWidth}px`,
          height: `${displayHeight}px`,
          overflow: "hidden",
          border: "1px solid rgb(204 204 204 / 43%)",
          display: "inline-block",
        });

        resolve(true);
      };

      // Fallback if image fails to load
      imgElement.onerror = () => {
        Object.assign(imageContainer.style, {
          position: "relative",
          width: "300px",
          height: "300px",
          overflow: "hidden",
          border: "1px solid rgb(204 204 204 / 43%)",
          display: "inline-block",
        });
        resolve(true);
      };
    });

    // Add the image to the container
    imageContainer.appendChild(imgElement);

    const frame = document.createElement("div");
    frame.id = "position-frame";
    Object.assign(frame.style, {
      position: "absolute",
      border: "2px solid #5068a8",
      backgroundColor: "rgba(80, 104, 168, 0.15)",
      cursor: "move",
    });

    imageContainer.appendChild(frame);
    if (uploadArea) {
      uploadArea.innerHTML = "";
      uploadArea.appendChild(imageContainer);
    }
    this.setupPositionFrame(frame, imageContainer);
    this.createOpacitySlider(uploadArea);
    this.createUploadNewImageButton(uploadArea);

    return true; // Indicates editing mode is active
  }

  public selectCurrentTileImage(fileListElement: HTMLElement) {
    const selectedImage = this.controller.getSelectedImages()[0];
    if (!selectedImage || !fileListElement) return;

    let selectedElement: HTMLElement | null = null;

    fileListElement.querySelectorAll(".file-item").forEach((el) => {
      const singleImageFile = el as HTMLElement;
      if (singleImageFile.id === selectedImage.Id) {
        selectedElement = singleImageFile;
        const checkbox = singleImageFile.querySelector(".select-media-checkbox") as HTMLElement;
        if (checkbox) {
          checkbox.className = "select-media-checkbox fa-solid fa-square-check selected-checkbox";
          checkbox.style.display = "block";
        }
      }
    });

    if (selectedElement) {
      fileListElement.insertBefore(selectedElement, fileListElement.firstChild);
    }
  }

  private async setupPositionFrame(frame: HTMLElement, container: HTMLElement) {
    const selectedComponent = (globalThis as any).selectedComponent;
    let aspectRatio = 1;
    const tile: Tile | undefined = this.getTile(selectedComponent);
    let frameWidth: number;
    let frameHeight: number;

    // Get actual container dimensions
    const containerWidth = container.clientWidth;
    const containerHeight = container.clientHeight;

    // Store previous container dimensions if they exist
    const previousContainer = this.previousContainerDimensions;
    let shouldScalePosition = false;
    let positionScaleX = 1;
    let positionScaleY = 1;

    // Calculate position scaling if we have previous dimensions
    if (
      previousContainer &&
      (previousContainer.width !== containerWidth || previousContainer.height !== containerHeight)
    ) {
      shouldScalePosition = true;
      positionScaleX = containerWidth / previousContainer.width;
      positionScaleY = containerHeight / previousContainer.height;
    }

    if (tile && tile.BGImageUrl) {
      // Use image dimensions when tile has background image
      const image = this.convertUrlToImage(tile.BGImageUrl) as HTMLImageElement;
      frameWidth = image.naturalWidth;
      frameHeight = image.naturalHeight;

      // Scale frame to fit within container while maintaining aspect ratio
      const imageAspectRatio = frameWidth / frameHeight;
      if (frameWidth > containerWidth || frameHeight > containerHeight) {
        const widthScale = containerWidth / frameWidth;
        const heightScale = containerHeight / frameHeight;
        const scale = Math.min(widthScale, heightScale);

        frameWidth = frameWidth * scale;
        frameHeight = frameHeight * scale;
      }
    } else if (selectedComponent) {
      // Use selected component dimensions when no background image
      const selectedComponentEl = selectedComponent.getEl() as HTMLElement;
      const componentWidth = selectedComponentEl.clientWidth;
      const componentHeight = selectedComponentEl.clientHeight;
      aspectRatio = parseFloat((componentWidth / componentHeight).toFixed(2));

      if (aspectRatio > 3) aspectRatio = 2.3;

      // Scale frame relative to container size instead of component size
      frameWidth = Math.min(containerWidth * 0.8, componentWidth);
      frameHeight = Math.min(containerHeight * 0.8, componentHeight);

      // Maintain aspect ratio
      const currentAspectRatio = frameWidth / frameHeight;
      if (currentAspectRatio !== aspectRatio) {
        if (frameWidth / aspectRatio <= containerHeight) {
          frameHeight = frameWidth / aspectRatio;
        } else {
          frameWidth = frameHeight * aspectRatio;
        }
      }
    } else {
      // Fallback values based on container size
      frameWidth = Math.min(containerWidth * 0.6, 300);
      frameHeight = Math.min(containerHeight * 0.6, 300);
    }

    // Ensure frame doesn't exceed container bounds
    frameWidth = Math.min(frameWidth, containerWidth);
    frameHeight = Math.min(frameHeight, containerHeight);
    aspectRatio = frameWidth / frameHeight;

    // Handle frame positioning
    let frameLeft = 0;
    let frameTop = 0;

    if (tile && tile.Left && tile.Top) {
      // Parse existing tile position
      frameLeft = parseFloat(tile.Left.replace("px", ""));
      frameTop = parseFloat(tile.Top.replace("px", ""));

      // Scale position if container dimensions changed
      if (shouldScalePosition) {
        frameLeft = frameLeft * positionScaleX;
        frameTop = frameTop * positionScaleY;
      }
    } else {
      // Use previous frame position if available
      const prevLeft = parseFloat(frame.style.left?.replace("px", "") || "0");
      const prevTop = parseFloat(frame.style.top?.replace("px", "") || "0");

      if (shouldScalePosition) {
        frameLeft = prevLeft * positionScaleX;
        frameTop = prevTop * positionScaleY;
      } else {
        frameLeft = prevLeft;
        frameTop = prevTop;
      }
    }

    // Ensure frame stays within container bounds after scaling
    const maxLeft = containerWidth - frameWidth;
    const maxTop = containerHeight - frameHeight;

    frameLeft = Math.max(0, Math.min(frameLeft, maxLeft));
    frameTop = Math.max(0, Math.min(frameTop, maxTop));

    // If frame is still outside bounds (e.g., very small new image), center it
    if (frameLeft < 0 || frameTop < 0 || frameLeft > maxLeft || frameTop > maxTop) {
      frameLeft = Math.max(0, (containerWidth - frameWidth) / 2);
      frameTop = Math.max(0, (containerHeight - frameHeight) / 2);
    }

    // Apply positioning
    frame.style.left = `${frameLeft}px`;
    frame.style.top = `${frameTop}px`;

    // Apply opacity filter to the image instead of container
    const imgElement = container.querySelector("img") as HTMLImageElement;
    if (imgElement) {
      imgElement.style.filter = `brightness(${tile?.Opacity ? 1 - tile.Opacity / 100 : 1})`;
    }

    // Set frame dimensions
    frame.style.width = `${frameWidth > 0 ? frameWidth : 50}px`;
    frame.style.height = `${frameHeight > 0 ? frameHeight : 50}px`;

    // Store current container dimensions for next time
    this.previousContainerDimensions = {
      width: containerWidth,
      height: containerHeight,
    };

    this.controller.captureCurrentPosition(frame, container);
    this.addResizeHandles(frame, container, aspectRatio);
    this.addDragFunctionality(frame, container, aspectRatio);
  }

  private convertUrlToImage(imageUrl: string | undefined) {
    if (!imageUrl) return;
    const img = new Image();
    img.src = imageUrl;
    return img;
  }

  private getTile(selectedComponent: any) {
    let tile;
    const infoContent: InfoType | null = this.controller.getInfoContent();
    if (infoContent) {
      const tileId = selectedComponent.parent().getId();
      const tiles: Tile[] | undefined = infoContent?.Tiles;
      if (tiles?.length) {
        tile = tiles.find((t) => t.Id === tileId);
      }
    }

    return tile;
  }

  private addResizeHandles(frame: HTMLElement, container: HTMLElement, tileAspectRatio: number) {
    const handles = ["top-left", "top-right", "bottom-left", "bottom-right"];
    handles.forEach((handle) => {
      const handleDiv = document.createElement("div");
      handleDiv.className = `resize-handle ${handle}`;
      Object.assign(handleDiv.style, {
        position: "absolute",
        width: "10px",
        height: "10px",
        backgroundColor: "#5068a8",
        zIndex: "11",
        cursor: "nw-resize",
      });

      if (handle.includes("top")) handleDiv.style.top = "-5px";
      if (handle.includes("bottom")) handleDiv.style.bottom = "-5px";
      if (handle.includes("left")) handleDiv.style.left = "-5px";
      if (handle.includes("right")) handleDiv.style.right = "-5px";

      frame.appendChild(handleDiv);
      this.addResizeLogic(handleDiv, frame, handle, container, tileAspectRatio);
    });
  }

  private addResizeLogic(
    handleDiv: HTMLElement,
    frame: HTMLElement,
    handle: string,
    container: HTMLElement,
    tileAspectRatio: number
  ) {
    handleDiv.addEventListener("mousedown", (e) => {
      e.preventDefault();
      e.stopPropagation();

      const startX = e.clientX;
      const startY = e.clientY;
      const startWidth = frame.offsetWidth;
      const startHeight = frame.offsetHeight;
      const startLeft = frame.offsetLeft;
      const startTop = frame.offsetTop;
      const containerWidth = container.offsetWidth;
      const containerHeight = container.offsetHeight;
      const aspectRatio = startWidth / startHeight;

      this.controller.captureCurrentPosition(frame, container);

      const onMouseMove = (moveEvent: MouseEvent) => {
        const dx = moveEvent.clientX - startX;
        const dy = moveEvent.clientY - startY;

        let newWidth = startWidth;
        let newHeight = startHeight;
        let newLeft = startLeft;
        let newTop = startTop;

        if (handle === "bottom-right") {
          newWidth = Math.min(startWidth + dx, containerWidth - startLeft);
          newHeight = newWidth / aspectRatio;
        } else if (handle === "bottom-left") {
          newWidth = Math.min(startWidth - dx, startLeft + startWidth);
          newLeft = Math.max(startLeft + dx, 0);
          newHeight = newWidth / aspectRatio;
        } else if (handle === "top-right") {
          newWidth = Math.min(startWidth + dx, containerWidth - startLeft);
          newHeight = newWidth / aspectRatio;
          newTop = Math.max(startTop + (startHeight - newHeight), 0);
        } else if (handle === "top-left") {
          newWidth = Math.min(startWidth - dx, startLeft + startWidth);
          newLeft = Math.max(startLeft + dx, 0);
          newHeight = newWidth / aspectRatio;
          newTop = Math.max(startTop + (startHeight - newHeight), 0);
        }

        newWidth = Math.max(newWidth, 20);
        newHeight = Math.max(newHeight, 20);

        frame.style.width = `${newWidth}px`;
        frame.style.height = `${newHeight}px`;
        frame.style.left = `${newLeft}px`;
        frame.style.top = `${newTop}px`;

        this.controller.captureCurrentPosition(frame, container);
      };

      const onMouseUp = () => {
        document.removeEventListener("mousemove", onMouseMove);
        document.removeEventListener("mouseup", onMouseUp);
        this.controller.captureCurrentPosition(frame, container);
      };

      document.addEventListener("mousemove", onMouseMove);
      document.addEventListener("mouseup", onMouseUp);
    });
  }

  private addDragFunctionality(
    frame: HTMLElement,
    container: HTMLElement,
    tileAspectRatio: number
  ) {
    let isDragging = false;
    let offsetX = 0;
    let offsetY = 0;

    frame.addEventListener("mousedown", (e) => {
      e.preventDefault();
      e.stopPropagation();
      isDragging = true;
      offsetX = e.clientX - frame.getBoundingClientRect().left;
      offsetY = e.clientY - frame.getBoundingClientRect().top;
      document.body.style.userSelect = "none";
    });

    document.addEventListener("mousemove", (e) => {
      if (isDragging) {
        e.preventDefault();
        e.stopPropagation();
        const parentRect = container.getBoundingClientRect();

        let newLeft = e.clientX - offsetX - parentRect.left;
        let newTop = e.clientY - offsetY - parentRect.top;

        if (newLeft < 0) newLeft = 0;
        if (newLeft + frame.offsetWidth > parentRect.width) {
          newLeft = parentRect.width - frame.offsetWidth;
        }
        if (newTop < 0) newTop = 0;
        if (newTop + frame.offsetHeight > parentRect.height) {
          newTop = parentRect.height - frame.offsetHeight;
        }

        frame.style.left = `${newLeft}px`;
        frame.style.top = `${newTop}px`;

        this.controller.captureCurrentPosition(frame, container);
      }
    });

    document.addEventListener("mouseup", (e) => {
      if (isDragging) {
        e.preventDefault();
        e.stopPropagation();
        isDragging = false;
        document.body.style.userSelect = "auto";
        this.controller.captureCurrentPosition(frame, container);
      }
    });
  }

  private createOpacitySlider(uploadArea: HTMLElement) {
    const selectedComponent = (globalThis as any).selectedComponent;
    const modalFooter = document.createElement("div");
    modalFooter.className = "modal-footer-slider";
    const tile: Tile | undefined = this.getTile(selectedComponent);

    const opacitySlider = document.createElement("input");
    Object.assign(opacitySlider, {
      type: "range",
      min: "0",
      max: "100",
      step: "1",
      value: tile?.Opacity || "0",
    });
    Object.assign(opacitySlider.style, {
      width: "100%",
      marginLeft: "32px",
    });

    const opacityLabel = document.createElement("span");
    opacityLabel.innerText = `${opacitySlider.value}%`;
    Object.assign(opacityLabel.style, {
      fontSize: "14px",
      color: "#333",
    });

    opacitySlider.addEventListener("input", () => {
      const opacityValue = parseInt(opacitySlider.value, 10) / 100;
      opacityLabel.innerText = `${opacitySlider.value}%`;

      const selectedComponent = (globalThis as any).selectedComponent;
      if (!selectedComponent) return;

      this.opacityValue = opacityValue * 100;

      const container = uploadArea.querySelector(".image-editor-container") as HTMLDivElement;
      const imgElement = container?.querySelector("img") as HTMLImageElement;

      if (!imgElement) return;

      // Apply opacity filter to the image element instead of container
      imgElement.style.filter = `brightness(${1 - opacityValue})`;
    });

    const sliderWrapper = document.createElement("div");
    Object.assign(sliderWrapper.style, {
      display: "flex",
      alignItems: "center",
      gap: "10px",
    });

    sliderWrapper.appendChild(opacitySlider);
    sliderWrapper.appendChild(opacityLabel);
    modalFooter.appendChild(sliderWrapper);
    this.modalContent.appendChild(modalFooter);

    if (uploadArea) {
      uploadArea.appendChild(modalFooter);
    }
  }

  private createUploadNewImageButton(uploadArea: HTMLElement) {
    const uploadText = document.createElement("span") as HTMLElement;
    uploadText.innerHTML = `${i18n.t("sidebar.image_upload.upload_message")}`;
    uploadText.style.textDecoration = "underline";
    uploadText.style.cursor = "pointer";
    uploadText.style.marginTop = "10px";
    uploadText.style.color = "#969696";

    uploadText.addEventListener("click", (e) => {
      e.stopPropagation();
      // This will be handled by the UI class through a callback
      if (this.onUploadNewImage) {
        this.onUploadNewImage();
      }
    });

    uploadArea.appendChild(uploadText);
  }

  public getOpacityValue(): number {
    return this.opacityValue;
  }

  public getSectionId(): string | undefined {
    return this.sectionId;
  }

  // Callback property to communicate with UI class
  public onUploadNewImage?: () => void;
}
