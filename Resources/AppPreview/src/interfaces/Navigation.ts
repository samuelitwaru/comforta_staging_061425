export interface NavigationEntry {
    pageId: string;
    tileId: string;
    targetId: string;
    level: number;
}

export interface NavigationData {
  history: NavigationEntry[];
}