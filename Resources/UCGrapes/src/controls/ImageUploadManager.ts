import { ToolBoxService } from "../services/ToolBoxService";
import { Image, InfoType, Media, Tile } from "../types";
import { ImageUploadUi } from "../ui/components/tools-section/tile-image/ImageUploadUi";
import { TileProperties } from "./editor/TileProperties";
import { InfoSectionManager } from "./InfoSectionManager";

export class ImageUploadManager {
  private type: "tile" | "cta" | "content" | "info";
  private toolboxService: ToolBoxService;
  private selectedImages: Map<string, { Id: string; Url: string }>;
  private infoId?: string;
  private sectionId?: string;
  private croppedUrl?: string;
  private imgFrame!: HTMLElement;
  private saveCallback?: (urls: Array<{ Id: string; Url: string }>) => void;

  private currentPosition: {
    x: number;
    y: number;
    scale: number;
    left: string;
    top: string;
    backgroundSize: string;
    backgroundPosition: string;
  } | null = null;
  public infoSectionManager: InfoSectionManager;

  imageUploadUi: ImageUploadUi;
  constructor(
    type: any,
    infoId?: string,
    sectionId?: string,
    saveCallback?: (urls: Array<{ Id: string; Url: string }>) => void
  ) {
    this.type = type;
    this.infoId = infoId;
    this.sectionId = sectionId;
    this.saveCallback = saveCallback;
    this.toolboxService = new ToolBoxService();
    this.selectedImages = new Map();
    this.imageUploadUi = new ImageUploadUi(this);
    this.infoSectionManager = new InfoSectionManager();
  }

  /* State Management Methods */
  public addSelectedImage(image: { Id: string; Url: string }) {
    this.selectedImages.set(image.Id, image);
    this.imageUploadUi.updateModalActions();
  }

  public removeSelectedImage(imageId: string) {
    this.selectedImages.delete(imageId);
    this.imageUploadUi.updateModalActions();
  }

  public clearSelectedImages() {
    this.selectedImages.clear();
    this.imageUploadUi.updateModalActions();
  }

  public hasSelectedImages(): boolean {
    return this.selectedImages.size > 0;
  }

  public getSelectedImages(): Array<{ Id: string; Url: string }> {
    return Array.from(this.selectedImages.values());
  }

  // Get info content
  public getInfoContent(): InfoType | null {
    if (this.infoId) {
      return this.infoSectionManager.getInfoContent(this.infoId);
    }

    return null;
  }

  /* Position Management Methods */
  public captureCurrentPosition(
    frame: HTMLElement,
    container: HTMLElement
  ) {
    const frameRect = frame.getBoundingClientRect();
    const containerRect = container.getBoundingClientRect();

    const relativeX =
      ((frameRect.left - containerRect.left) / containerRect.width) * 100;
    const relativeY =
      ((frameRect.top - containerRect.top) / containerRect.height) * 100;

    const scaleX = containerRect.width / frameRect.width;
    const scaleY = containerRect.height / frameRect.height;
    const scale = Math.max(scaleX, scaleY);
    let backgroundSizePercent = scale * 100;
    const selectedComponent = (globalThis as any).selectedComponent;

    // if (selectedComponent) {
    //   const tileWrapperComp = selectedComponent.parent();
    //   const rowComponent = tileWrapperComp.parent();
    //   const components = rowComponent.components();

    //   if (components.length === 1) {
    //     if (tileWrapperComp?.getStyle()?.["height"] === "80px") {
    //       backgroundSizePercent = 110;
    //     } else if (tileWrapperComp?.getStyle()?.["height"] === "120px") {
    //       backgroundSizePercent = 120;
    //     } else if (tileWrapperComp?.getStyle()?.["height"] === "160px") {
    //       backgroundSizePercent = 150;
    //     }
    //   }
    // }

    const backgroundPosX =
      (relativeX / (100 - (frameRect.width / containerRect.width) * 100)) * 100;
    const backgroundPosY =
      (relativeY / (100 - (frameRect.height / containerRect.height) * 100)) *
      100;

    const clampedBackgroundPosX = Math.max(
      0,
      Math.min(100, backgroundPosX || 0)
    );
    const clampedBackgroundPosY = Math.max(
      0,
      Math.min(100, backgroundPosY || 0)
    );

    this.currentPosition = {
      x: relativeX,
      y: relativeY,

      left: frame.style.left,
      top: frame.style.top,

      scale: scale,
      backgroundSize: `${backgroundSizePercent}%`,
      backgroundPosition: `${clampedBackgroundPosX}% ${clampedBackgroundPosY}%`,
    };

    this.imgFrame = frame;
    return this.currentPosition;
  }

  public getCurrentPosition() {
    return this.currentPosition;
  }

  private async createImageFromUrl(image: { Id: string; Url: string }) {
    if (!this.currentPosition || !this.imgFrame) return;

    const img = new Image();
    img.crossOrigin = "anonymous";
    img.src = image.Url;

    await new Promise<void>((resolve, reject) => {
      img.onload = () => resolve();
      img.onerror = () => reject(new Error("Image failed to load"));
    });

    const canvas = document.createElement("canvas");
    const ctx = canvas.getContext("2d");
    if (!ctx) return;

    // Get the frame dimensions from currentPosition
    const frameWidth = this.imgFrame.clientWidth;
    const frameHeight = this.imgFrame.clientHeight;

    // Set canvas to the exact frame size
    canvas.width = frameWidth;
    canvas.height = frameHeight;

    // Calculate the source crop dimensions based on background size and position
    const bgSize = parseFloat(this.currentPosition.backgroundSize) / 100;
    const [bgPosX, bgPosY] = this.currentPosition.backgroundPosition
      .split(" ")
      .map((pos) => parseFloat(pos) / 100);

    // Calculate the source image dimensions after scaling
    const sourceWidth = img.naturalWidth / bgSize;
    const sourceHeight = img.naturalHeight / bgSize;

    // Calculate the source crop position
    const sourceX = (img.naturalWidth - sourceWidth) * bgPosX;
    const sourceY = (img.naturalHeight - sourceHeight) * bgPosY;

    // Draw the image cropped to the frame dimensions
    ctx.drawImage(
      img,
      sourceX, // source x
      sourceY, // source y
      sourceWidth, // source width
      sourceHeight, // source height
      0, // destination x
      0, // destination y
      frameWidth, // destination width
      frameHeight // destination height
    );
    // Apply brightness enhancement
    const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
    const data = imageData.data;
    for (let i = 0; i < data.length; i += 4) {
      data[i] = Math.min(255, data[i] * 1.1); // red
      data[i + 1] = Math.min(255, data[i + 1] * 1.1); // green
      data[i + 2] = Math.min(255, data[i + 2] * 1.1); // blue
    }
    ctx.putImageData(imageData, 0, 0);

    const croppedDataUrl = canvas.toDataURL("image/jpeg");
    const mediaSize = Math.round(croppedDataUrl.length * (3 / 4) - 2);
    const uniqueId = Date.now().toString();
    const uniqueFileName = `cropped-image-${uniqueId}.jpeg`;

    const newMedia: Media = {
      MediaId: uniqueId,
      MediaName: uniqueFileName,
      MediaUrl: croppedDataUrl,
      MediaType: "jpeg",
      MediaSize: mediaSize,
    };

    const response = await this.toolboxService.uploadCroppedFile(
      newMedia.MediaUrl,
      newMedia.MediaName,
      newMedia.MediaSize,
      newMedia.MediaType,
      image.Id
    );

    return response.BC_Trn_Media.MediaUrl;
  }

  /* Image Handling Methods */
  public async handleSave(opacityValue: number, nextSectionId?: string) {
    try {
      const selectedImages = this.getSelectedImages();
      if (this.saveCallback) {
        this.saveCallback(selectedImages);
      } else if (this.type === "info") {
        await this.saveMultipleImages(selectedImages, nextSectionId);
      } else if (this.type === "cta") {
        this.updateInfoCtaButtonImage(selectedImages[0]);
      } else {
        await this.saveSingleImage(selectedImages[0], opacityValue);
      }
    } catch (error) {
      console.error("Error during save:", error);
      throw error;
    }
  }

  private async saveMultipleImages(
    images: Array<{ Id: string; Url: string }>,
    nextSectionId?: string
  ) {
    await this.infoSectionManager.addMultipleImages(
      images,
      Boolean(this.infoId),
      this.infoId,
      nextSectionId
    );
  }

  private async saveSingleImage(
    image: { Id: string; Url: string },
    opacityValue: number
  ) {
    const selectedComponent = (globalThis as any).selectedComponent;
    if (!selectedComponent) return;
    selectedComponent.getEl().style.removeProperty("background-color");

    const originalMediaUrl = encodeURI(image.Url);

    const croppedUrl = await this.createImageFromUrl(image);
    const safeMediaUrl = encodeURI(croppedUrl || image.Url);

    const styleProperties: any = {
      "background-image": `url(${safeMediaUrl})`,
      "background-blend-mode": "overlay",
      "background-color": "transparent",
    };

    if (this.currentPosition) {
      styleProperties["background-size"] = "cover";
      styleProperties["background-position"] = "center";
      styleProperties[
        "background-color"
      ] = `rgba(0, 0, 0, ${opacityValue}) !important`;
    }

    selectedComponent.addStyle(styleProperties);

    const tileWrapper = selectedComponent.parent();
    const rowComponent = tileWrapper.parent();
    const pageData = (globalThis as any).pageData;

    if (pageData.PageType === "Information") {
      const rowId = rowComponent.getId();
      const tileId = tileWrapper.getId();

      const updates: Record<any, any> = {
        BGImageUrl: safeMediaUrl,
        OriginalImageUrl: originalMediaUrl,
        Opacity: opacityValue,
      };

      if (this.currentPosition) {
        Object.assign(updates, {
          BGSize: this.currentPosition.backgroundSize,
          BGPosition: this.currentPosition.backgroundPosition,
          Top: this.currentPosition.top,
          Left: this.currentPosition.left,
        });
      }

      for (const [key, value] of Object.entries(updates)) {
        this.infoSectionManager.updateInfoTileAttributes(
          rowId,
          tileId,
          key,
          value
        );
      }

      const tileAttributes = this.updateInfoTileAttributes(rowId, tileId);
      const tileProperties = new TileProperties(
        selectedComponent,
        tileAttributes
      );
      tileProperties.setTileAttributes();
    }
  }

  private updateInfoTileAttributes(
    rowComponentId: any,
    tileWrapperId: any
  ): any {
    if (!rowComponentId || !tileWrapperId) return;
    const tileInfoSectionAttributes: InfoType = (
      globalThis as any
    ).infoContentMapper.getInfoContent(rowComponentId);

    return tileInfoSectionAttributes?.Tiles?.find(
      (tile: any) => tile.Id === tileWrapperId
    );
  }

  private updateInfoCtaButtonImage(image: { Id: string; Url: string }) {
    const safeMediaUrl = encodeURI(image.Url);
    this.infoSectionManager.updateInfoCtaButtonImage(safeMediaUrl, this.infoId);
  }

  /* Media Management Methods */
  public async loadMediaFiles() {
    try {
      const media = await this.toolboxService.getMediaFiles();
      if (media && media.length > 0) {
        return this.sortMediaBySelection(media);
      }
      return [];
    } catch (error) {
      console.error("Error loading media files:", error);
      throw error;
    }
  }

  public async deleteImages(selectedImages: Set<string>) {
    const imageIds: string[] = [...selectedImages];
    if (!imageIds || imageIds.length === 0) return;

    try {
      const deletePromises = imageIds.map((id) =>
        this.toolboxService.deleteMedia(id)
      );
      await Promise.all(deletePromises);
    } catch (error) {
      console.error("Error deleting images:", error);
      throw error;
    }
  }

  private sortMediaBySelection(media: Media[]): Media[] {
    if (this.type !== "info" || !this.infoId) {
      return media;
    }

    return media.sort((a, b) => {
      const isASelected = this.isMediaSelected(a.MediaId);
      const isBSelected = this.isMediaSelected(b.MediaId);

      if (isASelected === isBSelected) {
        return 0;
      }
      return isASelected ? -1 : 1;
    });
  }

  private isMediaSelected(mediaId: string): boolean {
    try {
      const existingImages = this.getExistingImages();
      return existingImages.some(
        (image) => image.InfoImageId === `id-${mediaId}`
      );
    } catch (error) {
      console.error("Error checking selected media:", error);
      return false;
    }
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

  public async handleFileUpload(file: File) {
    if (file.type.startsWith("image/")) {
      try {
        const dataUrl = await this.readFileAsDataURL(file);
        const fileName = this.cleanFileName(file.name);

        const newMedia: Media = {
          MediaId: Date.now().toString(),
          MediaName: fileName,
          MediaUrl: dataUrl,
          MediaType: file.type,
          MediaSize: file.size,
        };

        await this.toolboxService.uploadFile(
          newMedia.MediaUrl,
          newMedia.MediaName,
          newMedia.MediaSize,
          newMedia.MediaType
        );
      } catch (error) {
        console.error("Error processing file:", error);
      }
    }
  }

  public async getFile(url: string) {
    const response = await fetch(url);
    const blob = await response.blob();
    return new File([blob], "image.jpg", { type: blob.type });
  }

  public getBackgroundImage() {
    const selectedComponent = (globalThis as any).selectedComponent;
    if (!selectedComponent) return null;

    const tileWrapper = selectedComponent.parent();
    const rowComponent = tileWrapper.parent();
    const pageData = (globalThis as any).pageData;

    const tileAttributes: Tile = this.updateInfoTileAttributes(
      rowComponent.getId(),
      tileWrapper.getId()
    );
    let backgroundImage;
    if (tileAttributes?.OriginalImageUrl) {
      backgroundImage = tileAttributes?.OriginalImageUrl;
    } else {
      const tileElement = selectedComponent.getStyle();
      backgroundImage = tileElement["background-image"];
      if (!backgroundImage) return null;
    }
    return backgroundImage.replace(/url\(["']?|["']?\)/g, "");
  }

  private readFileAsDataURL(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onload = () => {
        if (reader.result) {
          resolve(reader.result as string);
        } else {
          reject(new Error("FileReader did not produce a result"));
        }
      };
      reader.onerror = () => reject(reader.error);
      reader.readAsDataURL(file);
    });
  }

  private cleanFileName(fileName: string): string {
    const randomSuffix = Math.floor(Math.random() * 10000);
    const nameParts = fileName.split(".");
    const extension = nameParts.length > 1 ? nameParts.pop() : "";
    const baseName = nameParts.join(".");

    const sanitizedBase = baseName
      .toLowerCase()
      .replace(/\s+/g, "-") 
      .replace(/[()]/g, "") 
      .replace(/[^a-z0-9-_]/g, ""); 

    return `${sanitizedBase}-${randomSuffix}.${extension}`;
  }

  public createFileList(files: File[]): FileList {
    const dataTransfer = new DataTransfer();
    files.forEach((file) => dataTransfer.items.add(file));
    return dataTransfer.files;
  }

  public async compressLargeFile(file: File): Promise<File> {
    const maxSizeInBytes = 2 * 1024 * 1024; // 2MB

    if (file.size > maxSizeInBytes) {
      const compressedFile = await this.compressImage(file, maxSizeInBytes);
      return compressedFile;
    }

    return file;
  }

  private async compressImage(
    file: File,
    maxSizeInBytes: number
  ): Promise<File> {
    return new Promise((resolve) => {
      const canvas = document.createElement("canvas");
      const ctx = canvas.getContext("2d")!;
      const img = new Image();

      img.onload = () => {
        let { width, height } = img;
        const maxDimension = 1920; // Max width/height

        if (width > height && width > maxDimension) {
          height = (height * maxDimension) / width;
          width = maxDimension;
        } else if (height > maxDimension) {
          width = (width * maxDimension) / height;
          height = maxDimension;
        }

        canvas.width = width;
        canvas.height = height;

        // Draw and compress
        ctx.drawImage(img, 0, 0, width, height);

        // Start with quality 0.9 and reduce until under size limit
        let quality = 0.9;
        const tryCompress = () => {
          canvas.toBlob(
            (blob) => {
              if (blob && (blob.size <= maxSizeInBytes || quality <= 0.1)) {
                const compressedFile = new File([blob], file.name, {
                  type: file.type,
                  lastModified: Date.now(),
                });
                resolve(compressedFile);
              } else {
                quality -= 0.1;
                tryCompress();
              }
            },
            file.type,
            quality
          );
        };

        tryCompress();
      };

      img.src = URL.createObjectURL(file);
    });
  }

  public render(container: HTMLElement) {
    this.imageUploadUi.render(container);
  }

  get getInfoId() {
    return this.infoId;
  }

  get getType() {
    return this.type;
  }

  get getSectionId() {
    return this.sectionId;
  }
}
