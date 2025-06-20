import { InfoContentMapper } from "../../controls/editor/InfoContentMapper";
import { i18n } from "../../i18n/i18n";
import { Alert } from "../components/Alert";

export class CopyPasteManager {
  private tbContainer: HTMLElement;
  private editorPage: HTMLElement;
  private overlay: HTMLDivElement | null = null;
  private selectionBox: HTMLDivElement | null = null;
  private cropAreaDiv: HTMLDivElement | null = null;
  private outsideClickHandler?: (event: MouseEvent) => void;
  private croppingActive = false;
  private isSelecting = false;
  private isSelectionCancelled = false;
  private overlayVisible = false;

  private startX = 0;
  private startY = 0;
  private left = 0;
  private top = 0;
  private width = 0;
  private height = 0;

  constructor(tbContainerSelector = ".tb-container", editorPageSelector = ".mobile-frame.active-editor") {
    this.tbContainer = document.querySelector(tbContainerSelector) as HTMLElement;
    this.editorPage = this.tbContainer?.querySelector(editorPageSelector) as HTMLElement;
  }

  public toggle(onSelect?: (rect: DOMRect) => void) {
    if (this.overlayVisible) {
      this.hide();
    } else {
      this.show(onSelect);
    }
  }

  public show(onSelect?: (rect: DOMRect) => void) {
    this.hide(); // Remove existing overlay if present
    this.overlayVisible = true;
    this.croppingActive = false;
    this.isSelecting = false;
    this.isSelectionCancelled = false; // Reset on show

    this.tbContainer = document.querySelector(".tb-container") as HTMLElement;
    this.editorPage = this.tbContainer?.querySelector(".mobile-frame.active-editor") as HTMLElement;
    if (!this.tbContainer || !this.editorPage) return;


    // Hide all .delete-page-icon buttons on the active page
    if (this.editorPage) {
      this.editorPage.querySelectorAll('.delete-page-icon').forEach(btn => {
        (btn as HTMLElement).style.display = 'none';
      });
    }

    const containerRect = this.tbContainer.getBoundingClientRect();
    const editorRect = this.editorPage.getBoundingClientRect();

    this.top = editorRect.top - containerRect.top;
    this.left = editorRect.left - containerRect.left;
    this.width = editorRect.width;
    this.height = editorRect.height;

    this.overlay = document.createElement("div");
    this.overlay.id = "page-selection-overlay";
    this.overlay.style.position = "absolute";
    this.overlay.style.top = "0";
    this.overlay.style.left = "0";
    this.overlay.style.width = "100%";
    this.overlay.style.height = "100%";
    this.overlay.style.zIndex = "9999";
    this.overlay.style.pointerEvents = "none"; // Let children handle events

    this.editorPage.style.borderRadius = "20px";
    this.editorPage.style.overflow = "hidden";

    const areas = [
      { top: 0, left: 0, width: "100%", height: `${this.top}px` },
      { top: this.top, left: 0, width: `${this.left}px`, height: `${this.height}px` },
      { top: this.top, left: `${this.left + this.width}px`, width: `calc(100% - ${this.left + this.width}px)`, height: `${this.height}px` },
      { top: `${this.top + this.height}px`, left: 0, width: "100%", height: `calc(100% - ${this.top + this.height}px)` },
    ];

    areas.forEach(area => {
      const div = document.createElement("div");
      div.style.position = "absolute";
      div.style.top = typeof area.top === "number" ? `${area.top}px` : area.top;
      div.style.left = typeof area.left === "number" ? `${area.left}px` : area.left;
      div.style.width = area.width;
      div.style.height = area.height;
      div.style.background = "rgba(0,0,0,0.65)";
      div.style.pointerEvents = "auto";
      div.addEventListener("mousedown", () => this.hide());
      this.overlay!.appendChild(div);
    });

    const cropAreaDiv = document.createElement("div");
    cropAreaDiv.style.position = "absolute";
    cropAreaDiv.style.top = `${this.top}px`;
    cropAreaDiv.style.left = `${this.left}px`;
    cropAreaDiv.style.width = `${this.width}px`;
    cropAreaDiv.style.height = `${this.height}px`;
    cropAreaDiv.style.background = "transparent";
    cropAreaDiv.style.pointerEvents = "auto";
    cropAreaDiv.style.cursor = "crosshair"; // Initial cursor for new selection
    this.overlay.appendChild(cropAreaDiv);
    this.cropAreaDiv = cropAreaDiv; // Store reference

    this.tbContainer.appendChild(this.overlay);

    this.cropAreaDiv.addEventListener("mousedown", (event) => this.onMouseDown(event, onSelect));
    this.cropAreaDiv.addEventListener("mousemove", (event) => this.onMouseMove(event));
    this.cropAreaDiv.addEventListener("mouseup", (event) => this.onMouseUp(event, onSelect));

    this.updateIconStyle(true);

  }

  public hide() {
    this.overlayVisible = false;
    this.croppingActive = false;
    this.isSelecting = false;
    this.isSelectionCancelled = false; // Reset on hide
    this.removeHighlightFromSections();

    if (this.overlay) {
      this.overlay.remove();
      this.overlay = null;
    }
    if (this.editorPage) {
      this.editorPage.style.borderRadius = "";
      this.editorPage.style.overflow = "";
    }

    // show again .delete-page-icon buttons on the active page
    if (this.editorPage) {
      this.editorPage.querySelectorAll('.delete-page-icon').forEach(btn => {
        (btn as HTMLElement).style.display = '';
      });
    }

    if (this.selectionBox) {
      this.selectionBox.remove();
      this.selectionBox = null;
    }
    this.cropAreaDiv = null;

    if (this.outsideClickHandler) {
      document.removeEventListener('mousedown', this.outsideClickHandler, true);
      this.outsideClickHandler = undefined;
    }

    this.updateIconStyle(false);

    // After selection, the cursor should change to default over the area
    if (this.editorPage) this.editorPage.style.cursor = "default";
  }

  private onMouseDown(event: MouseEvent, onSelect?: (rect: DOMRect) => void) {
    const target = event.target as HTMLElement;
    const clickX = event.clientX;
    const clickY = event.clientY;

    // --- Handle existing selection first ---
    if (this.selectionBox) {
      const selectionRect = this.selectionBox.getBoundingClientRect();
      const actionGroup = this.overlay?.querySelector('.cp-action-group');
      const actionGroupRect = actionGroup ? actionGroup.getBoundingClientRect() : null;

      const isInsideSelection = (
        clickX >= selectionRect.left &&
        clickX <= selectionRect.right &&
        clickY >= selectionRect.top &&
        clickY <= selectionRect.bottom
      );

      const isInsideActionGroup = actionGroupRect ? (
        clickX >= actionGroupRect.left &&
        clickX <= actionGroupRect.right &&
        clickY >= actionGroupRect.top &&
        clickY <= actionGroupRect.bottom
      ) : false;

      if (!isInsideSelection && !isInsideActionGroup) {
        // Clicked outside selection box and action group
        this.cancelSelection(); // Cancel the existing selection
        // CRUCIAL: Set a flag to prevent immediate re-selection
        this.isSelectionCancelled = true;
      }
      // A new selection should only start when there's NO selectionBox.
      return;
    }

    // AND the previous action was NOT a cancellation (to avoid dot-creation)
    if (this.isSelectionCancelled) {
      this.isSelectionCancelled = false; // Reset flag for the *next* interaction
      return; // Prevent new selection after a direct click-to-cancel
    }

    const x = event.clientX - this.tbContainer.getBoundingClientRect().left;
    const y = event.clientY - this.tbContainer.getBoundingClientRect().top;

    if (
      x >= this.left &&
      x <= this.left + this.width &&
      y >= this.top &&
      y <= this.top + this.height
    ) {
      this.isSelecting = true;
      this.startX = x;
      this.startY = y;

      this.selectionBox = document.createElement("div");
      this.selectionBox.style.position = "absolute";
      this.selectionBox.style.border = "2px dashed #2196f3";
      this.selectionBox.style.background = "rgba(33,150,243,0.1)";
      this.selectionBox.style.left = `${this.startX}px`;
      this.selectionBox.style.top = `${this.startY}px`;
      this.selectionBox.style.width = "0px";
      this.selectionBox.style.height = "0px";
      this.selectionBox.style.zIndex = "10000";
      this.overlay!.appendChild(this.selectionBox);

      event.preventDefault();
      this.croppingActive = true;
    } else {
      this.hide();
    }
  }

  private onMouseMove(event: MouseEvent) {
    if (!this.isSelecting || !this.selectionBox) return;
    // Don't draw if the user just cancelled a selection with a click and isn't actually dragging.
    if (this.isSelectionCancelled) return;

    const x = event.clientX - this.tbContainer.getBoundingClientRect().left;
    const y = event.clientY - this.tbContainer.getBoundingClientRect().top;

    const constrainedX = Math.max(this.left, Math.min(x, this.left + this.width));
    const constrainedY = Math.max(this.top, Math.min(y, this.top + this.height));

    const rectLeft = Math.min(this.startX, constrainedX);
    const rectTop = Math.min(this.startY, constrainedY);
    const rectWidth = Math.abs(constrainedX - this.startX);
    const rectHeight = Math.abs(constrainedY - this.startY);

    this.selectionBox.style.left = `${rectLeft}px`;
    this.selectionBox.style.top = `${rectTop}px`;
    this.selectionBox.style.width = `${rectWidth}px`;
    this.selectionBox.style.height = `${rectHeight}px`;
    this.selectionBox.style.pointerEvents = "none";
    this.selectionBox.style.zIndex = "10000";
    this.selectionBox.style.background = "rgba(33,150,243,0.1)";
    this.selectionBox.style.border = "2px dashed #2196f3";
  }

  private onMouseUp(event: MouseEvent, onSelect?: (rect: DOMRect) => void) {
    if (!this.isSelecting || !this.selectionBox) return;
    this.isSelecting = false;

    // If it was just a click (no drag), treat it as a cancellation to prevent tiny boxes
    if (this.selectionBox.offsetWidth === 0 || this.selectionBox.offsetHeight === 0) {
      this.cancelSelection();
      return;
    }

    const rect = this.selectionBox.getBoundingClientRect();
    const containerRect = this.tbContainer.getBoundingClientRect();

    const selectionRect = new DOMRect(
      rect.left - containerRect.left,
      rect.top - containerRect.top,
      rect.width,
      rect.height
    );

    // highlight the selected sections
    this.highlightSections(this.getSelectedInfoSections(selectionRect));

    if (onSelect) {
      onSelect(selectionRect);
    }

    this.showActionGroup(rect, containerRect, selectionRect, onSelect);
    this.addCancelOnOutsideClick();
  }

  private showActionGroup(rect: DOMRect, containerRect: DOMRect, selectionRect: DOMRect, onSelect?: (rect: DOMRect) => void) {
    const existingGroup = this.overlay!.querySelector('.cp-action-group');
    if (existingGroup) existingGroup.remove();

    const actionGroup = document.createElement('div');
    actionGroup.className = 'cp-action-group';
    actionGroup.style.position = 'absolute';
    // Position the action group relative to the container and the selection box
    let groupLeft = rect.left - containerRect.left;
    let groupTop = rect.top - containerRect.top + rect.height + 8; // 8px below the box

    // Basic boundary checks for the action group
    const groupApproxWidth = 3 * 36 + 2 * 12; // 3 buttons * 36px width + 2 gaps * 12px
    const groupApproxHeight = 36; // Button height

    if (groupLeft + groupApproxWidth > containerRect.width) {
      groupLeft = containerRect.width - groupApproxWidth;
    }
    if (groupTop + groupApproxHeight > containerRect.height) {
      groupTop = rect.top - containerRect.top - groupApproxHeight - 8;
    }
    groupLeft = Math.max(0, groupLeft); // Ensure it's not off the left
    groupTop = Math.max(0, groupTop); // Ensure it's not off the top

    actionGroup.style.left = `${groupLeft}px`;
    actionGroup.style.top = `${groupTop}px`;
    actionGroup.style.display = 'flex';
    actionGroup.style.gap = '12px';
    actionGroup.style.zIndex = '10001';
    actionGroup.style.pointerEvents = 'auto';

    const makeIconBtn = (svg: string, title: string) => {
      const btn = document.createElement('button');
      btn.type = "button";
      btn.innerHTML = svg;
      btn.title = title;
      btn.style.background = '#fff';
      btn.style.border = '1px solid #bbb';
      btn.style.borderRadius = '50%';
      btn.style.width = '36px';
      btn.style.height = '36px';
      btn.style.display = 'flex';
      btn.style.alignItems = 'center';
      btn.style.justifyContent = 'center';
      btn.style.cursor = 'pointer';
      btn.style.boxShadow = '0 2px 8px rgba(0,0,0,0.12)';
      return btn;
    };

    const copySvg = `<svg width="20" height="20" viewBox="0 0 24 24" fill="none">
                      <rect x="7" y="7" width="11" height="13" rx="2" fill="#fff" stroke="#2196f3" stroke-width="2"/>
                      <rect x="4" y="4" width="11" height="13" rx="2" fill="#e3f2fd" stroke="#2196f3" stroke-width="2" opacity="0.7"/>
                    </svg>`;
    const cutSvg = `<svg width="20" height="20" fill="none" stroke="#f44336" stroke-width="2" viewBox="0 0 24 24"><circle cx="6" cy="6" r="3"/><circle cx="6" cy="18" r="3"/><line x1="20" y1="4" x2="8.12" y2="15.88"/><line x1="14.47" y1="14.48" x2="20" y2="20"/></svg>`;
    const cancelSvg = `<svg width="20" height="20" fill="none" stroke="#888" stroke-width="2" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><line x1="15" y1="9" x2="9" y2="15"/><line x1="9" y1="9" x2="15" y2="15"/></svg>`;

    const copyBtn = makeIconBtn(copySvg, "Copy");
    const cutBtn = makeIconBtn(cutSvg, "Cut");
    const cancelBtn = makeIconBtn(cancelSvg, "Cancel");

    copyBtn.addEventListener("click", (e) => {
      e.stopPropagation();
      e.preventDefault();
      const selectedSections = this.getSelectedInfoSections(selectionRect);
      const selectedSectionIds = selectedSections.map(el => el.id).filter(Boolean);

      if (selectedSectionIds.length === 0) {
        new Alert("error", i18n.t("messages.error.sections_copy_error"));
      } else {
        new Alert("success", i18n.t("messages.success.sections_copy_success"));
        this.setSelectedCopiedSections(selectedSectionIds);
        this.hide();
      }
    });

    cutBtn.addEventListener("click", (e) => {
      e.stopPropagation();
      e.preventDefault();
      const selectedSections = this.getSelectedInfoSections(selectionRect);
      const selectedSectionIds = selectedSections.map(el => el.id).filter(Boolean);

      if (selectedSectionIds.length === 0) {
        new Alert("error", i18n.t("messages.error.sections_cut_error"));
      } else {
        new Alert("success", i18n.t("messages.success.sections_cut_success"));
        this.setSelectedCopiedSections(selectedSectionIds);
        const activePage = (globalThis as any).pageData;
        const infoMapper = new InfoContentMapper(activePage.PageId);
        infoMapper.cutInfoSectionsFromPage(selectedSectionIds, activePage.PageId);
        this.hide();
      }
    });

    cancelBtn.addEventListener("click", (e) => {
      e.stopPropagation();
      e.preventDefault();
      this.cancelSelection();
    });

    actionGroup.appendChild(copyBtn);
    actionGroup.appendChild(cutBtn);
    // actionGroup.appendChild(cancelBtn);
    this.overlay!.appendChild(actionGroup);

    // After selection, the cursor should change to default over the area
    if (this.cropAreaDiv) this.cropAreaDiv.style.cursor = "default";
    if (this.editorPage) this.editorPage.style.cursor = "default";
    if (this.overlay) this.overlay.style.cursor = "default";
  }

  private getSelectedInfoSections(selectionRect: DOMRect): HTMLElement[] {
    if (!this.editorPage) return [];

    const iframe = this.editorPage.querySelector('iframe.gjs-frame') as HTMLIFrameElement;
    if (!iframe || !iframe.contentDocument) return [];

    const container = iframe.contentDocument.querySelector('.container-column-info');
    if (!container) return [];

    const allSections = Array.from(container.querySelectorAll('[data-gjs-type]')) as HTMLElement[];

    const infoSections = allSections.filter(el => {
      const type = el.getAttribute('data-gjs-type');
      return type && /^info.*section$/.test(type);
    });

    const iframeRect = iframe.getBoundingClientRect();

    const selectedSections = infoSections.filter(el => {
      const elRect = el.getBoundingClientRect();

      const absLeft = iframeRect.left + elRect.left;
      const absTop = iframeRect.top + elRect.top;
      const absRight = absLeft + elRect.width;
      const absBottom = absTop + elRect.height;

      const selLeft = this.tbContainer.getBoundingClientRect().left + selectionRect.x;
      const selTop = this.tbContainer.getBoundingClientRect().top + selectionRect.y;
      const selRight = selLeft + selectionRect.width;
      const selBottom = selTop + selectionRect.height;

      const intersects =
        absRight > selLeft &&
        absLeft < selRight &&
        absBottom > selTop &&
        absTop < selBottom;

      return intersects;
    });

    return selectedSections;
  }

  private setSelectedCopiedSections(selectedSectionIds: string[]): void {
    const activePage = (globalThis as any).pageData;

    const data: any = JSON.parse(
      localStorage.getItem(`data-${activePage.PageId}`) || "{}"
    );

    let copiedStructures: any[] = [];

    if (data?.PageInfoStructure?.InfoContent) {
      data.PageInfoStructure.InfoContent.forEach((infoContent: any) => {
        if (
          infoContent?.InfoId &&
          selectedSectionIds.includes(infoContent.InfoId)
        ) {
          copiedStructures.push(infoContent);
        }
      });
    }

    if (copiedStructures.length === 0) {
      console.error("No matching structures found in localStorage for selected section IDs:", selectedSectionIds);
      return;
    }

    localStorage.setItem('copiedInfoSections', JSON.stringify(copiedStructures));
  }

  private updateIconStyle(isActive: boolean) {
    const copySelectButton = document.getElementById('copySelectButton');
    const svgPath = copySelectButton?.querySelector('svg path');
    if (svgPath) {
      svgPath.setAttribute('fill', isActive ? '#222f54' : '#7c8791');
    }
  }

  private addCancelOnOutsideClick() {
    document.removeEventListener('mousedown', this.outsideClickHandler as any, true);

    this.outsideClickHandler = (event: MouseEvent) => {
      if (!this.selectionBox) {
        document.removeEventListener('mousedown', this.outsideClickHandler as any, true);
        this.outsideClickHandler = undefined;
        return;
      }

      const target = event.target as HTMLElement;
      const clickX = event.clientX;
      const clickY = event.clientY;

      const selectionRect = this.selectionBox.getBoundingClientRect();
      const actionGroup = this.overlay?.querySelector('.cp-action-group');
      const actionGroupRect = actionGroup ? actionGroup.getBoundingClientRect() : null;

      const isInsideSelection = (
        clickX >= selectionRect.left &&
        clickX <= selectionRect.right &&
        clickY >= selectionRect.top &&
        clickY <= selectionRect.bottom
      );

      const isInsideActionGroup = actionGroupRect ? (
        clickX >= actionGroupRect.left &&
        clickX <= actionGroupRect.right &&
        clickY >= actionGroupRect.top &&
        clickY <= actionGroupRect.bottom
      ) : false;

      if (!isInsideSelection && !isInsideActionGroup) {
        this.cancelSelection();
      }
    };

    document.addEventListener('mousedown', this.outsideClickHandler, true);
  }

  private cancelSelection() {
    this.isSelectionCancelled = true; // Set cancelled flag to prevent immediate re-selection.
    this.removeHighlightFromSections();

    if (this.selectionBox) {
      this.selectionBox.remove();
      this.selectionBox = null;
    }
    const actionGroup = this.overlay?.querySelector('.cp-action-group');
    if (actionGroup) {
      actionGroup.remove();
    }
    this.croppingActive = false;
    this.isSelecting = false;

    if (this.cropAreaDiv) this.cropAreaDiv.style.cursor = "crosshair";
    if (this.editorPage) this.editorPage.style.cursor = "crosshair";

    if (this.outsideClickHandler) {
      document.removeEventListener('mousedown', this.outsideClickHandler, true);
      this.outsideClickHandler = undefined;
    }
  }

  // private highlightSections(sections: HTMLElement[]) {
  //   sections.forEach(section => section.classList.add('copypaste-highlight'));
  // }

  private highlightSections(sections: HTMLElement[]) {
    sections.forEach(section => {
      section.classList.remove('copypaste-highlight');
      void section.offsetWidth; // Force reflow to restart animation
      section.classList.add('copypaste-highlight');
    });
  }

  private removeHighlightFromSections() {
    if (!this.editorPage) return;
    const iframe = this.editorPage.querySelector('iframe.gjs-frame') as HTMLIFrameElement;
    if (!iframe || !iframe.contentDocument) return;
    const highlighted = iframe.contentDocument.querySelectorAll('.copypaste-highlight');
    highlighted.forEach(el => el.classList.remove('copypaste-highlight'));
  }
}