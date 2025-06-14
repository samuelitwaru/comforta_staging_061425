import { ThemeManager } from "../controls/ThemeManager";
import { Cta } from "../interfaces/Cta";
import { CtaAttributes } from "../interfaces/CtaAttributes";
import { ctaIcons } from "../utils/cta-icons";

export class CtaComponent {
    cta: CtaAttributes;
    themeManager: any;
    ctaButton: HTMLElement;
    constructor(cta: CtaAttributes) {
        this.cta = cta;
        this.themeManager = new ThemeManager();
        this.ctaButton = document.createElement("div");
        this.createButton();
    }

    private createButton () {
        if (this.cta.CtaButtonType == "Round") {
            this.createRoundButton();
        } else if (this.cta.CtaButtonType == "FullWidth") {
            this.createFullWidthButton();
        } else if (this.cta.CtaButtonType == "Image") {
            this.createImageButton();
        } else if (this.cta.CtaButtonType == "Icon") {
            this.createIconButton();
        } 
    }

    private createRoundButton (): void {
        this.ctaButton.classList.add("tbap-cta-round-button");

        const buttonDiv = document.createElement("div");
        buttonDiv.classList.add("tbap-cta-round-button__button");
        buttonDiv.style.backgroundColor = this.themeManager.getThemeCtaColor(this.cta.CtaBGColor);
        
        buttonDiv.innerHTML = this.getIcon();


        const label = document.createElement("div");
        label.classList.add("tbap-cta-round-button__label");
        if(this.cta.CtaLabel) label.innerText = this.truncateText(this.cta.CtaLabel);
        
        this.ctaButton.appendChild(buttonDiv);
        this.ctaButton.appendChild(label);
    }

    private createFullWidthButton (): void {
        this.ctaButton.classList.add("tbap-cta-plain-button");

        const buttonDiv = document.createElement("div");
        buttonDiv.classList.add("tbap-cta-plain-button__button");
        buttonDiv.style.backgroundColor = this.themeManager.getThemeCtaColor(this.cta.CtaBGColor);        

        const label = document.createElement("div");
        label.classList.add("tbap-cta-plain-button__label");
        label.style.color = this.cta.CtaColor ? this.cta.CtaColor : "#fff";
        if(this.cta.CtaLabel) label.innerText = this.cta.CtaLabel;
        
        buttonDiv.appendChild(label);
        this.ctaButton.appendChild(buttonDiv);
    }

    private createIconButton (): void {
        this.ctaButton.classList.add("tbap-cta-icon-button");

        const buttonDiv = document.createElement("div");
        buttonDiv.classList.add("tbap-cta-icon-button__button");
        buttonDiv.style.backgroundColor = this.themeManager.getThemeCtaColor(this.cta.CtaBGColor);
        

        const iconSvg = document.createElement("span");
        iconSvg.classList.add("tbap-cta-iconSvg-button__iconSvg");
        iconSvg.innerHTML = this.getIcon();

        const label = document.createElement("div");
        label.classList.add("tbap-cta-icon-button__label");
        label.style.color = this.cta.CtaColor ? this.cta.CtaColor : "#fff";
        if(this.cta.CtaLabel) label.innerText = this.cta.CtaLabel;

        const icon = document.createElement("i");
        icon.className = "fa fa-angle-right tbap-cta-icon-button__icon"
        icon.style.color = this.cta.CtaColor ? this.cta.CtaColor : "#fff";
        
        buttonDiv.appendChild(iconSvg);
        buttonDiv.appendChild(label);
        buttonDiv.appendChild(icon);
        this.ctaButton.appendChild(buttonDiv);
    }

    private createImageButton (): void {
        this.ctaButton.classList.add("tbap-cta-img-button");

        const buttonDiv = document.createElement("div");
        buttonDiv.classList.add("tbap-cta-img-button__button");
        buttonDiv.style.backgroundColor = this.themeManager.getThemeCtaColor(this.cta.CtaBGColor);
        

        const img = document.createElement("img");
        img.classList.add("tbap-cta-img-button__img");
        if(this.cta.CtaButtonImgUrl) img.src = this.cta.CtaButtonImgUrl;

        const label = document.createElement("div");
        label.classList.add("tbap-cta-img-button__label");
        label.style.color = this.cta.CtaColor ? this.cta.CtaColor : "#fff";
        if(this.cta.CtaLabel) label.innerText = this.cta.CtaLabel;

        const icon = document.createElement("i");
        icon.className = "fa fa-angle-right tbap-cta-img-button__icon"
        icon.style.color = this.cta.CtaColor ? this.cta.CtaColor : "#fff";
        
        buttonDiv.appendChild(img);
        buttonDiv.appendChild(label);
        buttonDiv.appendChild(icon);
        this.ctaButton.appendChild(buttonDiv);
    }

    getIcon(): string {
        if (this.cta.CtaButtonIcon) {
          const svg = ctaIcons.find(icon => icon.name === this.cta.CtaButtonIcon)?.svg;
          const tempElement = document.createElement('div') as HTMLElement;
          tempElement.innerHTML = svg || ``;
          const newSvgElement = tempElement.querySelector('svg');
          
          if (newSvgElement) {
              newSvgElement.setAttribute('height', '32');
              newSvgElement.setAttribute('width', '32');
              
              const pathElements = newSvgElement.querySelectorAll('path');
              pathElements.forEach(path => {
                  path.setAttribute('fill',  this.cta?.CtaColor || '#fff');
              });
              
              return tempElement.innerHTML;
          }
        } else {
            let icon: string = "";
            switch(this.cta.CtaType) {
                case "Phone":
                    return `
                    <svg id="ixdtl" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32" height="32"
                        viewBox="0 0 49.417 49.418">
                        <path id="call" data-gjs-type="svg-in"
                            d="M29.782,3a2.149,2.149,0,1,0,0,4.3A19.3,19.3,0,0,1,49.119,26.634a2.149,2.149,0,1,0,4.3,0A23.667,23.667,0,0,0,29.782,3ZM12.032,7.305a2.548,2.548,0,0,0-.818.067,8.342,8.342,0,0,0-3.9,2.342C2.775,14.254.366,21.907,17.437,38.98S42.16,53.643,46.7,49.1a8.348,8.348,0,0,0,2.346-3.907,2.524,2.524,0,0,0-1.179-2.786c-2.424-1.418-7.654-4.484-10.08-5.9a2.523,2.523,0,0,0-2.568.012l-4.012,2.392a2.517,2.517,0,0,1-2.845-.168,65.811,65.811,0,0,1-5.711-4.981,65.07,65.07,0,0,1-4.981-5.711A2.512,2.512,0,0,1,17.5,25.2L19.9,21.191a2.533,2.533,0,0,0,.008-2.577L14.012,8.556A2.543,2.543,0,0,0,12.032,7.305Zm17.751,4.289a2.149,2.149,0,1,0,0,4.3A10.709,10.709,0,0,1,40.525,26.634a2.149,2.149,0,1,0,4.3,0A15.072,15.072,0,0,0,29.782,11.594Zm0,8.594a2.149,2.149,0,1,0,0,4.3,2.114,2.114,0,0,1,2.149,2.148,2.149,2.149,0,1,0,4.3,0A6.479,6.479,0,0,0,29.782,20.188Z"
                            transform="translate(-4 -3)" fill="#fff"></path>
                    </svg>
                    `;
                    break;
                case "Email":
                    return `
                    <svg id="inavf" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32"
                        height="28" viewBox="0 0 41 32.8">
                        <path id="Path_1218" data-gjs-type="svg-in" data-name="Path 1218"
                            d="M6.1,4A4.068,4.068,0,0,0,2.789,5.7a1.5,1.5,0,0,0,.444,2.126l18,11.219a2.387,2.387,0,0,0,2.531,0L41.691,7.732a1.5,1.5,0,0,0,.384-2.2A4.063,4.063,0,0,0,38.9,4Zm35.907,8.376a.963.963,0,0,0-.508.152L23.765,23.711a2.392,2.392,0,0,1-2.531,0L3.5,12.656a.98.98,0,0,0-1.5.833V32.7a4.1,4.1,0,0,0,4.1,4.1H38.9A4.1,4.1,0,0,0,43,32.7V13.357A.981.981,0,0,0,42.007,12.376Z"
                            transform="translate(-2 -4)" fill="#fff"></path>
                    </svg>
                    `;
                    break;
                case "WebLink":
                    return `
                    <svg id="i8bct" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 16 16">
                        <path id="Path_1213" data-gjs-type="svg-in" data-name="Path 1213" d="M15.833,4a4.163,4.163,0,0,0-2.958,1.229l-.979.979a4.168,4.168,0,0,0-1.229,2.958,4.1,4.1,0,0,0,.292,1.521L12.042,9.6a2.857,2.857,0,0,1,.792-2.458l.979-.979a2.853,2.853,0,0,1,2.021-.833,2.805,2.805,0,0,1,2,.833,2.85,2.85,0,0,1,0,4.021l-.979.979A2.853,2.853,0,0,1,14.833,12a2.439,2.439,0,0,1-.437-.042l-1.083,1.083a4.1,4.1,0,0,0,1.521.292A4.163,4.163,0,0,0,17.792,12.1l.979-.979A4.168,4.168,0,0,0,20,8.167,4.2,4.2,0,0,0,15.833,4ZM14.188,8.854,8.854,14.188l.958.958,5.333-5.333ZM9.167,10.667A4.163,4.163,0,0,0,6.208,11.9l-.979.979A4.168,4.168,0,0,0,4,15.833,4.2,4.2,0,0,0,8.167,20a4.163,4.163,0,0,0,2.958-1.229l.979-.979a4.168,4.168,0,0,0,1.229-2.958,4.1,4.1,0,0,0-.292-1.521L11.958,14.4a2.857,2.857,0,0,1-.792,2.458l-.979.979a2.853,2.853,0,0,1-2.021.833,2.805,2.805,0,0,1-2-.833,2.85,2.85,0,0,1,0-4.021l.979-.979A2.853,2.853,0,0,1,9.167,12a2.44,2.44,0,0,1,.438.042l1.083-1.083A4.1,4.1,0,0,0,9.167,10.667Z" transform="translate(-4 -4)" fill="#fff">
                        </path>
                    </svg>
                    `;
                    break;
                case "Form":
                    return `
                    <svg id="igqdh" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="26" height="30"
                        viewBox="0 0 13 16">
                        <path id="Path_1209" data-gjs-type="svg-in" data-name="Path 1209"
                            d="M9.828,4A1.823,1.823,0,0,0,8,5.8V18.2A1.823,1.823,0,0,0,9.828,20h9.344A1.823,1.823,0,0,0,21,18.2V9.8a.6.6,0,0,0-.179-.424l-.006-.006L15.54,4.176A.614.614,0,0,0,15.109,4Zm0,1.2H14.5V8.6a1.823,1.823,0,0,0,1.828,1.8h3.453v7.8a.6.6,0,0,1-.609.6H9.828a.6.6,0,0,1-.609-.6V5.8A.6.6,0,0,1,9.828,5.2Zm5.891.848L18.92,9.2H16.328a.6.6,0,0,1-.609-.6Z"
                            transform="translate(-8 -4)" fill="#fff"></path>
                    </svg>
                    `;
                    break;
                default:
                    break;
            }
            return icon;
        }
        return "";
      }

    getCta(): HTMLElement {
        return this.ctaButton;
    }
    
    handleCtaClick(ctaAttributes: CtaAttributes | undefined): void {
        if (ctaAttributes) {
            const type = ctaAttributes.CtaType;
            const action = ctaAttributes.CtaAction;
    
            switch (type) {
                case "Phone":
                    window.location.href = `tel:${action}`;
                    break;
                case "Email":
                    window.location.href = `mailto:${action}`;
                    break;
                case "WebLink":
                case "Form":
                    if (action) {
                        const url = action.startsWith('http') ? action : `https://${action}`;
                        window.open(url, "_blank");
                    }
                    break;
                default:
                    break;
            }
        }
    }
    
    private truncateText(text: string, maxLength: number = 10): string {
        return text.length > maxLength ? text.substring(0, maxLength) + '...' : text;
    }
}