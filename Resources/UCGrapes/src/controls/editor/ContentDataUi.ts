import { Modal } from "../../ui/components/Modal";
import Quill from "quill";
import { ContentDataManager } from "./ContentDataManager";
import { ImageUpload } from "../../ui/components/tools-section/tile-image/ImageUpload";
import { ConfirmationBox } from "../../ui/components/ConfirmationBox";
import { InfoSectionManager } from "../InfoSectionManager";
import { CtaIconsListPopup } from "../../ui/views/CtaIconsListPopup";
import { i18n } from "../../i18n/i18n";
import { InfoType } from "../../types";
import { ImageUploadManager } from "../ImageUploadManager";

export class ContentDataUi {
  e: any;
  editor: any;
  page: any;
  contentDataManager: any;
  infoSectionController: any;
  slideIndex: number = 1;

  constructor(e: any, editor: any, page: any) {
    this.e = e;
    this.editor = editor;
    this.page = page;
    this.infoSectionController = new InfoSectionManager();
    this.contentDataManager = new ContentDataManager(this.editor, this.page);

    //this.showSlides(this.slideIndex);
    this.init();
  }
  private init() {
    this.openContentEditModal();
    this.openImageEditModal();
    this.openDeleteModal();
    this.updateCtaButtonImage();
    this.updateCtaButtonIcon();
    this.handleSliderClick();
  }

  private handleSliderClick() {
    const parentContainer = (this.e.target as Element).closest(
      "[data-gjs-type='info-image-section']"
    );
    if ((this.e.target as Element).closest(".prev-img-slide")) {
      this.plusSlides(-1, parentContainer);
    }
    if ((this.e.target as Element).closest(".next-img-slide")) {
      this.plusSlides(1, parentContainer);
    }
  }

  private plusSlides(n: number, parentContainer: any) {
    const slides = parentContainer?.querySelectorAll(".mySlides");

    if (!slides || slides.length === 0) {
      return;
    }

    let currentIndex = 0; // Start from 0-based index

    for (let i = 0; i < slides.length; i++) {
      if (slides[i].style.display === "block") {
        currentIndex = i;
        break;
      }
    }

    let newIndex = currentIndex + n;

    if (newIndex >= slides.length) {
      newIndex = 0; // Go to first slide
    } else if (newIndex < 0) {
      newIndex = slides.length - 1; // Go to last slide
    }

    this.showSlides(newIndex, parentContainer);
  }

  private showSlides(slideIndex: number, parentContainer: any) {
    const slides = parentContainer?.querySelectorAll(".mySlides");

    if (!slides || slides.length === 0) {
      return;
    }

    // Hide all slides
    for (let i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }

    // Show the selected slide
    if (slides[slideIndex]) {
      slides[slideIndex].style.display = "block";
    }

  }

  private openContentEditModal() {
    if ((this.e.target as Element).closest(".tb-edit-content-icon")) {
      const modalBody = document.createElement("div");
      const infoDescSection = this.e.target.closest(
        '[data-gjs-type="info-desc-section"].info-desc-section'
      );
      const modalContent = document.createElement("div");
      modalContent.id = "editor";
      modalContent.innerHTML = `${this.getDescription()}`;
      modalContent.style.minHeight = "150px";

      const submitSection = document.createElement("div");
      submitSection.classList.add("popup-footer");
      submitSection.style.marginBottom = "-12px";

      const saveBtn = this.createButton(
        "submit_form",
        "tb-btn-primary",
        i18n.t("tile.save_button")
      );
      const hasContent =
        modalContent.innerHTML !== "<p><br></p>" &&
        modalContent.innerHTML.trim() !== "";
      if (!hasContent) {
        saveBtn.disabled = true;
        saveBtn.style.opacity = "0.6";
        saveBtn.style.cursor = "not-allowed";
      }
      const cancelBtn = this.createButton(
        "cancel_form",
        "tb-btn-outline",
        i18n.t("tile.cancel_button")
      );

      const characterCounterSection = document.createElement("div");
      characterCounterSection.classList.add("row");
      const characterCounterSpan = document.createElement("span");
      characterCounterSection.style.paddingLeft = "20px";
      characterCounterSpan.style.fontSize = "small";
      characterCounterSpan.style.fontStyle = "italic";
      characterCounterSection.appendChild(characterCounterSpan);

      submitSection.appendChild(saveBtn);
      submitSection.appendChild(cancelBtn);

      modalBody.appendChild(modalContent);
      modalBody.appendChild(characterCounterSection);
      modalBody.appendChild(submitSection);

      const modal = new Modal({
        title: i18n.t("tile.edit_content"),
        width: "500px",
        body: modalBody,
      });
      modal.open();

      const Delta = Quill.import('delta');
      const quill = new Quill("#editor", {
        formats: [
          'bold',
          'italic',
          'underline',
          'link',
          'list'
        ],
        modules: {
          toolbar: [
            ["bold", "italic", "underline", "link"],
            [{ list: "ordered" }, { list: "bullet" }],
          ],
          clipboard: {
            matchers: [
              [ 
                Node.ELEMENT_NODE,
                (node: Node, delta: any) => {
                  return delta.compose(new Delta().retain(delta.length(), {
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
                    video: false
                  }));
                }
              ] 
            ]
          }
        },
        theme: "snow",
        placeholder: "Start typing here...",
      });

      characterCounterSpan.innerHTML = (quill.getLength() - 1)+ "/1000";

      setTimeout(() => {
        // First focus the editor
        quill.focus();

        // Then move the cursor to the end
        const length = quill.getLength();
        quill.setSelection(length, 0);
      }, 0);

      quill.on("text-change", () => {
        const editorContent = quill.root.innerHTML;
        // Check if editor has meaningful content (not just empty paragraphs)
        const hasContent =
          editorContent !== "<p><br></p>" && editorContent.trim() !== "";
        saveBtn.disabled = !hasContent;

        if (quill.getLength() > 1000) {
          quill.deleteText(1000, quill.getLength());
          characterCounterSpan
          characterCounterSpan.innerHTML = "1000/1000"
          //console.log("InfoSectionManager");
      } else {
        const textLeft = quill.getLength() - 1;
        characterCounterSpan.innerHTML = textLeft + "/1000"
      }

        // Update button styling based on disabled state
        if (saveBtn.disabled) {
          saveBtn.style.opacity = "0.6";
          saveBtn.style.cursor = "not-allowed";
        } else {
          saveBtn.style.opacity = "1";
          saveBtn.style.cursor = "pointer";
        }
      });

      saveBtn.addEventListener("click", () => {
        const content = document.querySelector(
          "#editor .ql-editor"
        ) as HTMLElement;
        const correctedContent = this.correctULTagFromQuill(content.innerHTML);

        if (this.page.PageType === "Information" && infoDescSection) {
          this.infoSectionController.updateDescription(
            correctedContent.trim(),
            infoDescSection.id
          );
          modal.close();
          return;
        }
        this.contentDataManager.saveContentDescription(correctedContent.trim());
        modal.close();
      });

      cancelBtn.addEventListener("click", () => {
        modal.close();
      });
    }
  }

  private openImageEditModal() {
    if ((this.e.target as Element).closest(".tb-edit-image-icon")) {
      const image = this.e.target.closest(
        '[data-gjs-type="info-image-section"].info-image-section'
      );

      const modal = document.createElement("div");
      modal.classList.add("tb-modal");
      modal.style.display = "flex";
      const type = this.page.PageType === "Information" ? "info" : "content";
      const modalContent = new ImageUploadManager(type, (image as HTMLElement)?.id);
      modalContent.render(modal);

      const uploadInput = document.createElement("input");
      uploadInput.type = "file";
      uploadInput.multiple = true;
      uploadInput.accept = "image/jpeg, image/jpg, image/png";
      uploadInput.id = "fileInput";
      uploadInput.style.display = "none";

      document.body.appendChild(modal);
      document.body.appendChild(uploadInput);
    } else if ((this.e.target as Element).closest(".tb-edit-image-icon")) {
      const image = this.e.target.closest(
        '[data-gjs-type="info-image-section"].info-image-section'
      );

      const modal = document.createElement("div");
      modal.classList.add("tb-modal");
      modal.style.display = "flex";
      const type = this.page.PageType === "Information" ? "info" : "content";
      const modalContent = new ImageUpload(type, (image as HTMLElement)?.id);
      modalContent.render(modal);

      const uploadInput = document.createElement("input");
      uploadInput.type = "file";
      uploadInput.multiple = true;
      uploadInput.accept = "image/jpeg, image/jpg, image/png";
      uploadInput.id = "fileInput";
      uploadInput.style.display = "none";

      document.body.appendChild(modal);
      document.body.appendChild(uploadInput);
    }
  }

  private openDeleteModal() {
    if ((this.e.target as Element).closest(".tb-delete-image-icon")) {
      if (
        this.page.PageType === "Location" ||
        this.page.PageType === "Reception"
      ) {
        return;
      }

      const title =
        this.page.PageType === "Information"
          ? "Remove Section"
          : "Remove Section";
      const message = "Are you sure you want to remove this section?";

      const handleConfirmation = async () => {
        if (this.page.PageType === "Information") {
          const targetElement = this.e.target as Element;
          const infoSection =
            targetElement.closest(
              '[data-gjs-type="info-desc-section"].info-desc-section'
            ) ||
            targetElement.closest(
              '[data-gjs-type="info-image-section"].info-image-section'
            );

          if (infoSection) {
            this.infoSectionController.deleteInfoImageOrDesc(
              (infoSection as HTMLElement).id
            );
          }
        } else {
          this.contentDataManager.deleteContentImage();
        }
      };

      const confirmationBox = new ConfirmationBox(
        message,
        title,
        handleConfirmation
      );
      confirmationBox.render(document.body);
    }
  }

  private updateCtaButtonImage() {
    const ctaImageEditButton = (this.e.target as Element).closest(
      ".edit-cta-image"
    );
    if (ctaImageEditButton) {
      const cta = this.e.target.closest('[data-gjs-type="info-cta-section"]');
      const ctaParentContainer = ctaImageEditButton.closest(
        ".img-button-container"
      );
      (globalThis as any).ctaContainerId = ctaParentContainer
        ? ctaParentContainer.id
        : "";

      const modal = document.createElement("div");
      modal.classList.add("tb-modal");
      modal.style.display = "flex";
      const modalContent = new ImageUploadManager("cta", (cta as HTMLElement).id);
      modalContent.render(modal);

      const uploadInput = document.createElement("input");
      uploadInput.type = "file";
      uploadInput.multiple = true;
      uploadInput.accept = "image/jpeg, image/jpg, image/png";
      uploadInput.id = "fileInput";
      uploadInput.style.display = "none";

      document.body.appendChild(modal);
      document.body.appendChild(uploadInput);
    }
  }

  private updateCtaButtonIcon() {
    const ctaIconEditButton = (this.e.target as Element).closest(
      ".icon-edit-button"
    );
    const selectedComponent = (globalThis as any).selectedComponent;
    if (
      ctaIconEditButton &&
      selectedComponent &&
      selectedComponent.getClasses().includes("img-button-container")
    ) {
      this.e.preventDefault();
      this.e.stopPropagation();
      const editButton = ctaIconEditButton.closest(
        ".icon-edit-button"
      ) as HTMLElement;
      const templateContainer = editButton.closest(
        "[data-gjs-type='info-cta-section']"
      ) as HTMLElement;

      // Get the mobileFrame for positioning context
      const mobileFrame = document.getElementById(
        `${(globalThis as any).frameId}-frame`
      ) as HTMLElement;
      const iframe = mobileFrame?.querySelector("iframe") as HTMLIFrameElement;
      const iframeRect = iframe?.getBoundingClientRect();

      // Pass the mobileFrame to the ActionListPopUp constructor
      const list = new CtaIconsListPopup(templateContainer, mobileFrame);

      const triggerRect = editButton.getBoundingClientRect();

      list.render();
    }
  }

  private getDescription() {
    if (this.page.PageType === "Information") {
      const description = this.e.target.closest(
        '[data-gjs-type="info-desc-section"].info-desc-section'
      );
      if (description) {
        return description.querySelector(".info-desc-content").innerHTML;
      }
    } else {
      const description = this.e.target.closest(".content-page-block");
      if (description) {
        const descComponent = this.editor.Components.getWrapper().find(
          "#contentDescription"
        )[0];
        if (descComponent) {
          return descComponent.getEl().innerHTML;
        }
      }
    }
  }

  private createButton(
    id: string,
    className: string,
    text: string
  ): HTMLButtonElement {
    const btn = document.createElement("button");
    btn.id = id;
    btn.classList.add("tb-btn", className);
    btn.innerText = text;
    return btn;
  }

  private correctULTagFromQuill(html: string): string {
    if (!html) return html;

    // Replace <ol> blocks containing bullet-style <li> with <ul>
    const parser = new DOMParser();
    const doc = parser.parseFromString(html, "text/html");

    const ols = doc.querySelectorAll("ol");

    ols.forEach((ol) => {
      const allBullet = Array.from(ol.children).every(
        (li) => li.getAttribute("data-list") === "bullet"
      );

      if (allBullet) {
        const ul = document.createElement("ul");
        Array.from(ol.children).forEach((li) => {
          ul.appendChild(li.cloneNode(true));
        });
        ol.replaceWith(ul);
      }
    });

    return doc.body.innerHTML;
  }
}
