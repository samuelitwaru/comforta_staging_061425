import { PublishManager } from "../../controls/toolbox/PublishManager";
import { AppVersionManager } from "../../controls/versions/AppVersionManager";
import { ToolBoxService } from "../../services/ToolBoxService";
import { Button } from "./Button";
import { EditActions } from "./EditActions";
import { Modal } from "./Modal";
import { ThemeSelection } from "./ThemeSelection";
import { i18n } from "../../i18n/i18n";
import { PageBubbleTree } from "./page-tree/PageBubbleTree";
import { PageTree } from "./page-tree/PageTree";

export class NavbarButtons {
  container: HTMLElement;
  appVersions: AppVersionManager;

  constructor() {
    this.appVersions = new AppVersionManager();
    this.container = document.getElementById("navbar-buttons") as HTMLElement;
    this.init();
  }

  init() {
    const editActions = new EditActions();

    const themeSelection = new ThemeSelection();

    const publishButtonSvg = `<svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 18">
        <path id="Path_958" data-name="Path 958" d="M13.5,3.594l-.519.507L7.925,9.263l1.038,1.06,3.814-3.9V18.644h1.444V6.429l3.814,3.9,1.038-1.06L14.019,4.1ZM7,20.119v1.475H20V20.119Z" transform="translate(-7 -3.594)" fill="#fff"></path>
      </svg>`;

    const publishButton = new Button("publish", i18n.t("navbar.publish.label"), {
      svg: publishButtonSvg,
      labelId: "navbar_tree_label",
    });

    editActions.render(this.container);

    themeSelection.render(this.container);

    // treeButton.render(this.container);
    publishButton.render(this.container);

    publishButton.button.addEventListener("click", (e) => {
      e.preventDefault();
      new PublishManager().openModal();
    });
  }

  render(container: HTMLElement) {
    container.appendChild(this.container);
  }
}
