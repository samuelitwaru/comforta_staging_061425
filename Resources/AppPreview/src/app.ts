import { HomePageController } from "./controls/HomePageController";
import { AppVersion } from "./interfaces/AppVersion";

export class ToolboxPreview {
  constructor() {
    this.init();
  }

  private init() {
    const homePageController = new HomePageController();
    homePageController.init();
  }
}
