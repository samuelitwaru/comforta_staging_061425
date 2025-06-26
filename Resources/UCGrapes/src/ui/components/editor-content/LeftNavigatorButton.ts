export class LeftNavigatorButton {
  private container: HTMLElement;

  constructor() {
    this.container = document.createElement("div");
    this.init();
  }

  init() {
    this.container.style.display = "none";
    this.container.className = "navigator page-navigator-left";
    this.container.innerHTML = `<span id="scroll-left"><i class="fa fa-arrow-left-long"></i></span>`;

  }

  render(container: HTMLElement) {
    container.appendChild(this.container);
  }
}
