import { ToolBoxService } from "../../services/ToolBoxService";
import { DebugResults, Image, InfoType, Tile } from "../../types";
import { AppVersionManager } from "./AppVersionManager";
import { DebugUIManager } from "./DebugUIManager";

export class DebugController {
  appVersions: AppVersionManager;
  constructor() {
    this.appVersions = new AppVersionManager();
  }

  async init() {
    const pageUrls: {
      page: string;
      urls: { url: string; affectedType: string; affectedName?: string }[];
    }[] = await this.getUrls();
    this.debugProcess(pageUrls);
  }

  private async debugProcess(pageUrls: any) {
    let results: DebugResults;
    try {
      const toolBoxService = new ToolBoxService();
      const response = await toolBoxService.debugApp(pageUrls);
      if (response) {
        results = response.SDT_DebugResults;
        (globalThis as any).debugResults = results;
        this.displayResults(results);
      }
    } catch (error) {
      throw new Error("Error in debug process" + error);
    }
  }

  private async getUrls() {
    const pageUrls: {
      page: string;
      pageId: string;
      urls: {
        url: string;
        affectedType: string;
        affectedName?: string;
        affectedInfoId: string;
        affectedTileId?: string;
        urlType: "ImgUrl" | "ActionUrl";
      }[];
    }[] = [];

    const activeVersion = await this.appVersions.refreshActiveVersion();
    const pages = activeVersion?.Pages;

    for (const page of pages) {
      const urls: {
        url: string;
        affectedType: string;
        affectedInfoId: string;
        affectedTileId?: string;
        affectedName?: string;
        urlType: "ImgUrl" | "ActionUrl";
      }[] = [];

      // Process content items
      const content = page.PageInfoStructure?.InfoContent;
      if (content) {
        for (const item of content as InfoType[]) {
          if (item.InfoType === "Image" && item.Images) {
            const images = item.Images;
            for (const image of images as Image[]) {
              urls.push({
                url: image.InfoImageValue || "",
                affectedType: "Content",
                affectedName: item.InfoType || "Unnamed Content",
                affectedInfoId: item.InfoId,
                urlType: "ImgUrl"
              });
            }
          }
          if (
            item.InfoType === "Cta" &&
            item.CtaAttributes &&
            item.CtaAttributes?.CtaButtonImgUrl
          ) {
            urls.push({
              url: item.CtaAttributes?.CtaButtonImgUrl,
              affectedType: "Cta",
              affectedName: item.InfoType || "Unnamed Cta",
              affectedInfoId: item.InfoId,
              urlType: "ImgUrl"
            });
            if (
              item.CtaAttributes?.CtaAction &&
              (item.CtaAttributes?.CtaType === "WebLink" || item.CtaAttributes?.CtaType === "Form")
            ) {
              urls.push({
                url: item.CtaAttributes?.CtaAction,
                affectedType: "Cta",
                affectedName: item.InfoType || "Unnamed Cta",
                affectedInfoId: item.InfoId,
                urlType: "ActionUrl"
              });
            }
          }
          if (item.InfoType === "TileRow" && item.Tiles) {
            item.Tiles?.forEach((tile: Tile) => {
              if (tile.Action?.ObjectUrl) {
                urls.push({
                  url: tile.Action.ObjectUrl,
                  affectedType: "Tile",
                  affectedName: tile.Name || "Unnamed Tile",
                  affectedInfoId: item.InfoId,
                  affectedTileId: tile.Id,
                  urlType: "ActionUrl"
                });
              }

              if (tile.BGImageUrl) {
                urls.push({
                  url: tile.BGImageUrl,
                  affectedType: "Tile",
                  affectedName: tile.Name || "Unnamed Tile",
                  affectedInfoId: item.InfoId,
                  affectedTileId: tile.Id,
                  urlType: "ImgUrl"
                });
              }
            });
          }
        }
      }

      // Only add the page if it has URLs
      if (urls.length > 0) {
        pageUrls.push({
          page: page.PageName || `Page-${pages.indexOf(page) + 1}`,
          pageId: page.PageId,
          urls,
        });
      }
    }

    return pageUrls;
  }

  displayResults(results: DebugResults) {
    const debugUIManager = new DebugUIManager(results);
    const debugDiv = document.getElementById("tb-debugging");
    if (debugDiv) {
      debugDiv.innerHTML = "";
      debugDiv.appendChild(debugUIManager.buildDebugUI());
    }
  }
}
