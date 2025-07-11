import { HomePageController } from "./controls/HomePageController";

export class ToolboxPreview {
  constructor() {
    this.init();
  }

  private init() {
    const homePageController = new HomePageController();
    homePageController.init();
  }
}
