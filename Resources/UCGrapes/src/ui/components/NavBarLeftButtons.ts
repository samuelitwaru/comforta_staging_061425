import { PublishManager } from "../../controls/toolbox/PublishManager";
import { AppVersionController } from "../../controls/versions/AppVersionController";
import { AppVersionManager } from "../../controls/versions/AppVersionManager";
import { DebugController } from "../../controls/versions/DebugController";
import { i18n } from "../../i18n/i18n";
import { ToolBoxService } from "../../services/ToolBoxService";
import { CopyPasteManager } from "../views/CopyPasteManager";
import { ShareLinkView } from "../views/ShareLinkView";
import { TrashView } from "../views/TrashView";
import { VersionSelectionView } from "../views/VersionSelectionView";
import { Button } from "./Button";
import { EditActions } from "./EditActions";
import { Modal } from "./Modal";

export class NavbarLeftButtons {
  container: HTMLElement;
  appVersions: AppVersionManager;
  debugController: DebugController;
  copyPasteManager: CopyPasteManager;

  constructor() {
    this.appVersions = new AppVersionManager();
    this.debugController = new DebugController();
    this.copyPasteManager = new CopyPasteManager(".tb-container", ".mobile-frame.active-editor");
    this.container = document.getElementById(
      "navbar-buttons-left"
    ) as HTMLElement;
    this.init();
  }

  init() {
    const debugSvg = `
        <svg xmlns="http://www.w3.org/2000/svg" width="19.043" height="21.199" viewBox="0 0 19.043 21.199">
          <g id="debug" transform="translate(-26.101 512)">
            <path id="Path_2337" data-name="Path 2337" d="M144.787-511.909a.7.7,0,0,0-.373.551,8.048,8.048,0,0,0,.654,2.158l.2.451-.228.248A4,4,0,0,0,144-506.45a.655.655,0,0,0,1.118.464,1,1,0,0,0,.244-.443,3.438,3.438,0,0,1,1.76-1.926,3.89,3.89,0,0,1,3.032,0,3.413,3.413,0,0,1,1.764,1.938.8.8,0,0,0,.248.443.663.663,0,0,0,1.048-.191c.224-.422-.253-1.537-1.006-2.357l-.207-.228.207-.456a6.542,6.542,0,0,0,.638-2.232.709.709,0,0,0-.663-.563.787.787,0,0,0-.555.3,3.619,3.619,0,0,0-.207.629,7.436,7.436,0,0,1-.526,1.454c-.046.066-.075.062-.356-.054a3.982,3.982,0,0,0-1.9-.323,3.972,3.972,0,0,0-1.876.311,2.461,2.461,0,0,1-.331.124,6.153,6.153,0,0,1-.63-1.694c-.079-.389-.182-.555-.41-.663A.587.587,0,0,0,144.787-511.909Z" transform="translate(-113.017)" fill="#7c8791"/>
            <path id="Path_2338" data-name="Path 2338" d="M29.116-406.013a.83.83,0,0,0-.236.277.667.667,0,0,0-.07.48,3.714,3.714,0,0,0,1.259,2.386,1.068,1.068,0,0,1,.248.269c-.008.017-.1.191-.207.385s-.244.48-.306.634c-.1.244-.128.282-.2.257a16.882,16.882,0,0,0-2.684-.4c-.4-.012-.563.058-.729.3a.485.485,0,0,0-.083.389c.029.447.244.617.841.663a17.491,17.491,0,0,1,1.814.253c.48.091.567.12.551.178a16.06,16.06,0,0,0-.041,4.622,7.775,7.775,0,0,0,1.822,4.286,6.04,6.04,0,0,0,4.821,1.727,6.4,6.4,0,0,0,3.259-.9,6.22,6.22,0,0,0,1.537-1.52,9.364,9.364,0,0,0,1.321-4.108,21.11,21.11,0,0,0,0-3.624c-.041-.228-.083-.443-.1-.48-.017-.058.07-.087.551-.178a17.834,17.834,0,0,1,1.835-.253c.576-.046.8-.224.82-.663a.485.485,0,0,0-.083-.389c-.166-.244-.331-.315-.729-.3a16.882,16.882,0,0,0-2.684.4c-.075.025-.1-.012-.2-.257-.062-.153-.2-.439-.306-.634s-.2-.369-.207-.385a1.068,1.068,0,0,1,.248-.269,3.714,3.714,0,0,0,1.259-2.386.667.667,0,0,0-.07-.48.617.617,0,0,0-.58-.373c-.41,0-.638.232-.7.712a2.005,2.005,0,0,1-.468,1.139,3.117,3.117,0,0,1-.4.431l-.207.17-.153-.1a7.46,7.46,0,0,0-2.928-.841,10.165,10.165,0,0,0-5.5.816l-.195.128-.215-.178a3.516,3.516,0,0,1-.646-.8,2.212,2.212,0,0,1-.22-.77.7.7,0,0,0-.331-.617A.69.69,0,0,0,29.116-406.013Zm7.293,2.725a10.04,10.04,0,0,1,2.477.534,3.619,3.619,0,0,1,1.416,2.009,8.015,8.015,0,0,1,.46,2.974c-.008,3.061-.675,5.131-1.992,6.171a4.507,4.507,0,0,1-2.858.928,5.324,5.324,0,0,1-2.713-.485c-1.47-.716-2.29-2.187-2.609-4.659a20.054,20.054,0,0,1-.1-2.746c.112-1.942,1.006-3.868,1.967-4.233a11.946,11.946,0,0,1,2.477-.509A9.768,9.768,0,0,1,36.409-403.288Z" transform="translate(0 -101.502)" fill="#7c8791"/>
            <path id="Path_2339" data-name="Path 2339" d="M194.807-327.881a.811.811,0,0,0-.447.505.724.724,0,0,0,.149.572,5.654,5.654,0,0,0,.634.431c.3.178.663.406.82.505l.277.178v4.291a34.46,34.46,0,0,0,.066,4.431.7.7,0,0,0,1.147.083l.091-.128.021-4.349.021-4.349.766-.464c.87-.53,1.015-.646,1.077-.882a.612.612,0,0,0-.182-.65.632.632,0,0,0-.663-.178c-.066.025-.472.261-.9.522l-.779.476-.779-.476C195.143-327.964,195.118-327.972,194.807-327.881Z" transform="translate(-161.281 -176.453)" fill="#7c8791"/>
            <path id="Path_2340" data-name="Path 2340" d="M39.478-215.775c-.306.108-.447.311-.692.994a12.842,12.842,0,0,0-.435,1.739,3.47,3.47,0,0,0,.128,1.574c.058.273.124.712.149.973.062.646.012.882-.236,1.135a.756.756,0,0,0-.257.658.67.67,0,0,0,.965.493,1.891,1.891,0,0,0,.8-1.073,5.355,5.355,0,0,0-.1-2.51,2.457,2.457,0,0,1-.1-1.064,7.638,7.638,0,0,1,.58-1.976.672.672,0,0,0-.435-.961A.38.38,0,0,0,39.478-215.775Z" transform="translate(-11.53 -283.904)" fill="#7c8791"/>
            <path id="Path_2341" data-name="Path 2341" d="M420.687-215.867a.677.677,0,0,0-.414.957,7.637,7.637,0,0,1,.58,1.976,2.457,2.457,0,0,1-.1,1.064,5.355,5.355,0,0,0-.1,2.51,1.891,1.891,0,0,0,.8,1.073.669.669,0,0,0,.969-.538.72.72,0,0,0-.282-.634c-.306-.3-.319-.87-.046-2.191a3.33,3.33,0,0,0,.1-1.479,9.7,9.7,0,0,0-.663-2.294.837.837,0,0,0-.505-.451,1,1,0,0,0-.174-.037A1.394,1.394,0,0,0,420.687-215.867Z" transform="translate(-377.776 -283.825)" fill="#7c8791"/>
          </g>
        </svg>
    `;

    const debugButton = document.createElement("button");
    debugButton.innerHTML = debugSvg;
    debugButton.setAttribute("title", i18n.t("navbar.debug.label"))

    debugButton.classList.add("tb-icon-button")
    debugButton.addEventListener("click", (e) => {
      e.preventDefault();
      this.initialiseDebug();

      const paths = debugButton.querySelectorAll("path");
      paths.forEach((path: SVGPathElement) => {
        path.setAttribute("fill", "#222f54");
      });

      this.debugController.init();
    });

    const shareButtonSvg: string = `
        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="21" viewBox="0 0 20 21">
          <path id="share" d="M15.674.034A4.075,4.075,0,0,0,14.457.4,3.6,3.6,0,0,0,12.721,2.05a3.485,3.485,0,0,0-.276,2.555.585.585,0,0,1,.039.258c-.015.013-1.318.74-2.894,1.617L6.724,8.074l-.2-.185A3.979,3.979,0,0,0,4.5,6.912a4.952,4.952,0,0,0-1.564.049A3.893,3.893,0,0,0,.442,8.826a3.58,3.58,0,0,0,1.476,4.868,4.011,4.011,0,0,0,4.559-.5l.247-.22,2.866,1.59c1.576.874,2.878,1.6,2.894,1.615a.589.589,0,0,1-.039.259,3.556,3.556,0,0,0,.807,3.329,3.9,3.9,0,0,0,2.131,1.2,6,6,0,0,0,1.775-.045,3.9,3.9,0,0,0,1.908-1.147A3.545,3.545,0,0,0,20,17.219a3.636,3.636,0,0,0-2.087-3.1,3.843,3.843,0,0,0-2.157-.386,3.954,3.954,0,0,0-2.24.982,1.408,1.408,0,0,1-.23.193c-.017,0-5.7-3.142-5.777-3.2a1.657,1.657,0,0,1,.058-.26,3.619,3.619,0,0,0,0-1.852c-.05-.186-.056-.246-.025-.274s5.636-3.153,5.712-3.18c.028-.011.132.062.257.175a3.323,3.323,0,0,0,.891.605,3.939,3.939,0,0,0,3.231.127A3.66,3.66,0,0,0,20,3.52,3.7,3.7,0,0,0,17.341.181,4.6,4.6,0,0,0,15.674.034m1.1,1.512a2.4,2.4,0,0,1,1.452,1.141,1.877,1.877,0,0,1,.229.986,1.9,1.9,0,0,1-.236,1,2.686,2.686,0,0,1-1.01.963,2.4,2.4,0,0,1-1.779.124,2.263,2.263,0,0,1-1.335-1.127,2.472,2.472,0,0,1-.186-.461,3.617,3.617,0,0,1,0-1,2.389,2.389,0,0,1,.532-.956,2.3,2.3,0,0,1,1.484-.736,3.691,3.691,0,0,1,.849.065M4.287,8.363A2.3,2.3,0,0,1,6.068,9.932a2.55,2.55,0,0,1,0,1.181,2.3,2.3,0,0,1-1.533,1.513,2.038,2.038,0,0,1-.717.072,1.705,1.705,0,0,1-.711-.085,2.177,2.177,0,0,1-.89-.549,2.115,2.115,0,0,1-.6-.969,2.828,2.828,0,0,1,0-1.144,2.313,2.313,0,0,1,1.72-1.575,3.146,3.146,0,0,1,.952-.013m12.471,6.885a2.026,2.026,0,0,1,1.018.582,1.881,1.881,0,0,1,.678,1.543,1.877,1.877,0,0,1-.229.986,2.55,2.55,0,0,1-1.014.984,2.207,2.207,0,0,1-1.054.223,2.089,2.089,0,0,1-1.622-.651,1.7,1.7,0,0,1-.439-.575,1.733,1.733,0,0,1-.223-.966A1.7,1.7,0,0,1,14.1,16.4a1.768,1.768,0,0,1,.44-.573,2.211,2.211,0,0,1,1.784-.644,3.185,3.185,0,0,1,.433.062" transform="translate(-0.005 -0.012)" fill="#7c8791" fill-rule="evenodd"/>
        </svg>
    `;

    const shareButton = document.createElement("button")
    shareButton.setAttribute("title", i18n.t("navbar.share.label"))
    shareButton.innerHTML = shareButtonSvg;
    shareButton.classList.add("tb-icon-button")

    const trashButtonSvg = `
    <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" 
      width="20" height="24" viewBox="0 0 64 64" enable-background="new 0 0 64 64" xml:space="preserve">
      <g>
        <polyline fill="none" stroke="#000000" stroke-width="2" stroke-miterlimit="10" points="25,8 25,1 39,1 39,8 	"/>
        <polyline fill="none" stroke="#000000" stroke-width="2" stroke-miterlimit="10" points="14,10 14,63 50,63 50,10 	"/>
        <line fill="none" stroke="#000000" stroke-width="2" stroke-miterlimit="10" x1="26" y1="20" x2="26" y2="54"/>
        <line fill="none" stroke="#000000" stroke-width="2" stroke-miterlimit="10" x1="38" y1="20" x2="38" y2="54"/>
        <line fill="none" stroke="#000000" stroke-width="2" stroke-miterlimit="10" x1="10" y1="9" x2="54" y2="9"/>
      </g>
    </svg>
    `;

    const trashButton = document.createElement("button")
    trashButton.setAttribute("title", i18n.t("navbar.trash.label"));
    trashButton.innerHTML = trashButtonSvg;
    trashButton.classList.add("tb-icon-button");

    // add button to initialize cropping window.
    const copySelectorSvg = `
      <svg id="copySelectButton" xmlns="http://www.w3.org/2000/svg" width="21" height="21" viewBox="0 0 21 21">
        <path id="selection" d="M2.516.052a3.074,3.074,0,0,0-2.5,2.8.936.936,0,0,0,.245.83.911.911,0,0,0,.957.257.955.955,0,0,0,.654-.917A1.172,1.172,0,0,1,3.021,1.869a1.024,1.024,0,0,0,.756-.352A.916.916,0,0,0,3.5.125,1.526,1.526,0,0,0,2.516.052m4.51,0a.954.954,0,0,0-.623.7.95.95,0,0,0,.335.907c.238.182.363.2,1.179.189.747-.012.747-.012.913-.11a1.141,1.141,0,0,0,.287-.263A.92.92,0,0,0,8.773.094c-.134-.071-.2-.078-.879-.086a3.352,3.352,0,0,0-.868.04m5.32,0a.983.983,0,0,0-.6.605.942.942,0,0,0,.43,1.086c.167.1.167.1.913.11a3.169,3.169,0,0,0,.9-.043.929.929,0,0,0,.365-1.52C14.1.036,14.031.018,13.214.008a3.358,3.358,0,0,0-.868.04m5.327,0a.922.922,0,0,0-.607,1.182.958.958,0,0,0,.911.638,1.172,1.172,0,0,1,1.157,1.154.958.958,0,0,0,.655.921.911.911,0,0,0,.957-.257.936.936,0,0,0,.245-.83,3.059,3.059,0,0,0-2.533-2.8,1.645,1.645,0,0,0-.785,0M.747,6.409a.9.9,0,0,0-.667.548C0,7.133,0,7.162.006,7.884c.013.827.03.9.264,1.136a.926.926,0,0,0,1.47-.188c.1-.167.1-.167.11-.912.013-.866-.013-1-.245-1.235a.942.942,0,0,0-.858-.277m19.147,0a.869.869,0,0,0-.5.282c-.225.232-.252.369-.239,1.23.012.745.012.745.11.912a.926.926,0,0,0,1.47.188c.234-.234.251-.308.264-1.136.01-.722.007-.751-.073-.927a.922.922,0,0,0-1.029-.548M.692,11.741a.953.953,0,0,0-.651.614A4.444,4.444,0,0,0,0,13.178c0,.664.005.714.083.88a.911.911,0,0,0,.844.557A.929.929,0,0,0,1.8,14a7.581,7.581,0,0,0,.015-1.653.956.956,0,0,0-1.126-.609m19.186-.016a.978.978,0,0,0-.682.589A6.852,6.852,0,0,0,19.2,14a.929.929,0,0,0,.876.612.911.911,0,0,0,.848-.566c.081-.177.083-.205.073-.927-.01-.653-.019-.763-.079-.882a.978.978,0,0,0-1.039-.515M.711,17.046a1.119,1.119,0,0,0-.516.335,1,1,0,0,0-.185.768,3.066,3.066,0,0,0,2.845,2.845.936.936,0,0,0,.829-.245.911.911,0,0,0,.257-.957.93.93,0,0,0-.884-.645,1.2,1.2,0,0,1-1.19-1.164.941.941,0,0,0-.521-.86,1.143,1.143,0,0,0-.636-.078m19.128,0a1,1,0,0,0-.617.513,2.261,2.261,0,0,0-.088.427,1.2,1.2,0,0,1-1.19,1.158.93.93,0,0,0-.884.645.911.911,0,0,0,.257.957.936.936,0,0,0,.829.245A3.081,3.081,0,0,0,20.683,19.3a2.754,2.754,0,0,0,.273-1.636.96.96,0,0,0-1.118-.615M7.012,19.2a.939.939,0,0,0-.622.882.911.911,0,0,0,.566.848c.177.081.205.083.927.073.827-.013.9-.03,1.136-.264a.837.837,0,0,0,.273-.657.811.811,0,0,0-.286-.671c-.236-.23-.365-.257-1.18-.254a4.508,4.508,0,0,0-.814.044m5.283.012a1.128,1.128,0,0,0-.517.485,1.03,1.03,0,0,0,.011.777,1.1,1.1,0,0,0,.449.45c.119.06.229.069.882.079.722.01.751.007.927-.073A.926.926,0,0,0,13.99,19.2a7.352,7.352,0,0,0-1.7.012" transform="translate(0 -0.003)" fill="#7c8791" fill-rule="evenodd"/>
      </svg>
    `;

    const copySelectButton = document.createElement("button");
    copySelectButton.setAttribute("title", i18n.t("navbar.copy_selection_label"));
    copySelectButton.innerHTML = copySelectorSvg;
    copySelectButton.classList.add("tb-icon-button");

    copySelectButton.addEventListener("click", (e) => {
      e.preventDefault();
      // Use the manager to show/toggle the overlay and snipping logic
      this.copyPasteManager.toggle(() => {
        // console.log("Selected area:", selectionRect);
      });
    });

    const versionSelection = new VersionSelectionView();

    versionSelection.render(this.container);
    this.container.appendChild(debugButton);
    this.container.appendChild(shareButton)
    this.container.appendChild(copySelectButton);
    // this.container.appendChild(trashButton);
    // shareButton.render(this.container);

    shareButton.addEventListener("click", (e) => {
      e.preventDefault();
      new ShareLinkView().openShareLinkModal();
    });

    trashButton.addEventListener("click", (e) => {
      e.preventDefault();
      new TrashView().openTrashModal();
    })

  }

  initialiseDebug() {
    const debugDiv = document.createElement("div");
    debugDiv.id = "tb-debugging";
    debugDiv.innerHTML = `
      <div class="tb_debug-spinner-container">
          <div class="tb_debug-spinner"></div>
      </div>
      <p style="text-align: center; font-size: 14px; margin-top: 10px">${i18n.t("navbar.debug.processing_message")}</p>
    `;

    const modal = new Modal({
      title: i18n.t("navbar.debug.modal_title"),
      width: "800px",
      body: debugDiv,
    });

    modal.open();
  }

  render(container: HTMLElement) {
    container.appendChild(this.container);
  }
}
