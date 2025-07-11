export interface AppVersion {
    AppVersionId: string;
    AppVersionName: string;
    IsActive: boolean;
    Pages: Page[];
    SDT_Theme: any;
    OrganisationLogo :string;
}

export interface Colors {
  ColorCode: string;
  ColorName: string;
  ColorId: string;
}

export interface Content {
  ContentType: string;
  ContentValue: string;
}

export interface Cta {
  CtaType: string;
  CtaLabel: string;
  CtaAction: string;
  CtaBGColor: string;
  CtaButtonType: string;
  CtaButtonImgUrl: string;
}

export interface CtaAttributes {
  CtaId: string;
  CtaType: string;
  CtaLabel?: string;
  CtaAction?: string;
  CtaColor?: string;
  CtaBGColor?: string;
  CtaButtonType?: string;
  CtaButtonImgUrl?: string;
  CtaButtonIcon?: string;
  CtaSupplierIsConnected?: boolean;
  CtaConnectedSupplierId?: string;
}

export interface CtaColors {
  CtaColorCode: string;
  CtaColorName: string;
  CtaColorId: string;
}

export interface Icons {
  IconName: string;
  IconSVG: string;
}

export interface Image {
  InfoImageId: string;
  InfoImageValue?: string;
}

export interface InfoType {
  InfoId: string;
  InfoType: string;
  InfoValue?: string;
  CtaAttributes?: CtaAttributes;
  Tiles?: Tile[];
  Images?: Image[];
  Columns?: Column[];
}

export interface Column {
  ColId: string;
  Tiles: Tile[];
}

export interface NavigationEntry {
  pageId: string;
  tileId: string;
  targetId: string;
  level: number;
}

export interface NavigationData {
  history: NavigationEntry[];
}

export interface Page {
    PageId: string;
    PageName: string;
    PageType: string;
    PageStructure: string;
    PageMenuStructure: PageMenuStructure;
    PageContentStructure: PageContentStructure;
    PageInfoStructure: PageInfoContentStructure
}

export interface PageContentStructure {
    Content: Content[];
    Cta: CtaAttributes[];
}

export interface PageInfoContentStructure {
    InfoContent: InfoType[];
}

export interface PageMenuStructure {
    Rows: Row[];
}

export interface Row {
    Id: string;
    Tiles: Tile[];
}

export interface SDT_Theme {
    ThemeFontFamily: string,
    Colors: Colors[];
    Icons: Icons[];
    CtaColors: CtaColors[];
}

export interface Tile {
  Id: string;
  Name: string;
  Text: string;
  Color: string;
  Align: string;
  Icon: string;
  BGColor: string;
  BGImageUrl: string;
  Opacity: number;
  Action: TileAction;
  Size: number;
  Height?: string;
}

export interface TileAction {
  ObjectId: string;
  ObjectType: string;
  ObjectUrl: string;
}