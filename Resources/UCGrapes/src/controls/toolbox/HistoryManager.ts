import { ToolboxManager } from "./ToolboxManager";

interface PageHistoryState {
  history: any[];
  currentIndex: number;
}

interface HistoryStatus {
  canUndo: boolean;
  canRedo: boolean;
  currentPosition: number;
  totalStates: number;
}

export class HistoryManager {
  private static pagesStore: Record<string, PageHistoryState> = {};
  
  currentPageId: string;
  limit: number;

  get pages() {
    return HistoryManager.pagesStore;
  }

  constructor(currentPageId: string, limit: number = 50) {
    this.currentPageId = currentPageId;
    this.limit = Math.max(1, limit); // Ensure minimum of 1

    if (!this.pages[currentPageId]) {
      this.addPage(currentPageId);
    }
  }

  addPage(pageId: string = this.currentPageId): void {
    if (!this.pages[pageId]) {
      this.pages[pageId] = {
        history: [],
        currentIndex: -1,
      };
    }
  }

  get currentState(): any | null {
    if (!this.currentPageId || !this.pages[this.currentPageId]) return null;
    const page = this.pages[this.currentPageId];
    return page.currentIndex >= 0 ? page.history[page.currentIndex] : null;
  }

  private deepClone(obj: any): any {
    try {
      return JSON.parse(JSON.stringify(obj));
    } catch (error) {
      console.warn('Failed to clone state:', error);
      return obj;
    }
  }

  private isEqual(a: any, b: any): boolean {
    try {
      return JSON.stringify(a) === JSON.stringify(b);
    } catch (error) {
      console.warn('Failed to compare states:', error);
      return false;
    }
  }

  addState(newState: any): any | null {
    if (!this.currentPageId) {
      console.warn('No current page ID set');
      return null;
    }

    if (newState === null || newState === undefined) {
      console.warn('Cannot add null or undefined state');
      return null;
    }

    if (!this.pages[this.currentPageId]) {
      this.addPage(this.currentPageId);
    }

    const page = this.pages[this.currentPageId];
    // If this is the first state
    if (page.history.length === 0) {
      page.history.push(this.deepClone(newState));
      page.currentIndex = 0;
      this.notifyStateChange();
      return this.currentState;
    }

    // Remove any future states if we're not at the end
    if (page.currentIndex < page.history.length - 1) {
      page.history = page.history.slice(0, page.currentIndex + 1);
    }

    // Check if state is different from current
    const currentState = page.history[page.currentIndex];
    if (this.isEqual(currentState, newState)) {
      return this.currentState;
    }

    // Add new state
    page.history.push(this.deepClone(newState));
    page.currentIndex++;

    // Maintain history limit
    if (page.history.length > this.limit) {
      page.history.shift();
      page.currentIndex = Math.max(0, page.currentIndex - 1);
    }

    this.notifyStateChange();
    return this.currentState;
  }

  canUndo(): boolean {
    if (!this.currentPageId || !this.pages[this.currentPageId]) return false;
    return this.pages[this.currentPageId].currentIndex > 0;
  }

  canRedo(): boolean {
    if (!this.currentPageId || !this.pages[this.currentPageId]) return false;
    const page = this.pages[this.currentPageId];
    return page.currentIndex < page.history.length - 1;
  }

  undo(): any | null {
    if (!this.canUndo()) return null;
    
    this.pages[this.currentPageId].currentIndex--;
    this.notifyStateChange();
    return this.currentState;
  }

  redo(): any | null {
    if (!this.canRedo()) return null;
    
    this.pages[this.currentPageId].currentIndex++;
    this.notifyStateChange();
    return this.currentState;
  }

  getHistoryStatus(): HistoryStatus {
    if (!this.currentPageId || !this.pages[this.currentPageId]) {
      return {
        canUndo: false,
        canRedo: false,
        currentPosition: 0,
        totalStates: 0
      };
    }

    const page = this.pages[this.currentPageId];
    return {
      canUndo: this.canUndo(),
      canRedo: this.canRedo(),
      currentPosition: page.currentIndex + 1,
      totalStates: page.history.length
    };
  }

  getPageData(pageId: string): any | null {
    if (!this.pages[pageId]) {
      this.addPage(pageId);
      return null;
    }

    const page = this.pages[pageId];
    return page.currentIndex >= 0 ? page.history[page.currentIndex] : null;
  }

  // Clear history for a specific page
  clearPageHistory(pageId: string = this.currentPageId): void {
    if (this.pages[pageId]) {
      this.pages[pageId] = {
        history: [],
        currentIndex: -1
      };
    }
  }

  // Get history length for a page
  getHistoryLength(pageId: string = this.currentPageId): number {
    if (!this.pages[pageId]) return 0;
    return this.pages[pageId].history.length;
  }

  private notifyStateChange(): void {
    try {
      new ToolboxManager().unDoReDo();
    } catch (error) {
      console.warn('Failed to notify ToolboxManager:', error);
    }
  }

  getAllHistory(): Record<string, PageHistoryState> {
    return this.pages;
  }

  static getAllPages(): Record<string, PageHistoryState> {
    return HistoryManager.pagesStore;
  }

  static clearAllHistory(): void {
    HistoryManager.pagesStore = {};
  }
}