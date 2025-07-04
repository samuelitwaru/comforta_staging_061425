import { ThemeManager } from "../../../controls/themes/ThemeManager";
import { AppConfig } from "../../../AppConfig";
// import { CtaAttributes } from "./CtaAttributes";

interface CtaAttributes {
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

export class PageTreeRendererInfoPage {
  themeManager: any;
  currentTheme: any;
  logo: any;
  constructor() {
    this.themeManager = new ThemeManager();
    this.currentTheme = this.themeManager.currentTheme;
    const config = AppConfig.getInstance();
    this.logo = config.organisationLogo;
  }

  private getCtaColor(colorName: string) {
    const ctaColor = this.currentTheme.ThemeCtaColors.find(
      (ctaColor: any) => ctaColor.CtaColorName === colorName
    );
    if (ctaColor) {
      return ctaColor.CtaColorCode;
    }
    return this.currentTheme.ThemeCtaColors[0].CtaColorCode;
  }

  private formatDate(): string {
    const date: string = new Date()
      .toLocaleDateString("en-GB", {
        day: "2-digit",
        month: "short",
        year: "numeric",
      })
      .replace(/(\d{2} \w{3}) (\d{4})/, "$1, $2");

    return date;
  }

  createMenuHTML(page: any) {
    const json = page.PageInfoStructure;
    const container = document.createElement("div");
    container.style.padding = "2.5px";
    const header = this.createHeaderHTML(page);
    container.appendChild(header);

    let roundCtaBuffer: any[] = [];

    json.InfoContent.forEach((row: any, index: number) => {
      if (row.InfoType === "Cta" && row.CtaAttributes.CtaButtonType === "Round") {
        roundCtaBuffer.push(row);

        // Process buffer if we have 3 CTAs or this is the last item or next item is not a Round CTA
        if (
          roundCtaBuffer.length === 3 ||
          index === json.InfoContent.length - 1 ||
          json.InfoContent[index + 1]?.InfoType !== "Cta" ||
          json.InfoContent[index + 1]?.CtaAttributes.CtaButtonType !== "Round"
        ) {
          const groupContainer = document.createElement("div");
          groupContainer.style.cssText = "display: flex; justify-content: center; flex-flow: wrap;";

          roundCtaBuffer.forEach((bufferedRow) => {
            const ctaButton = this.createCTAs(bufferedRow.CtaAttributes);
            groupContainer.appendChild(ctaButton);
          });

          container.appendChild(groupContainer);
          roundCtaBuffer = []; // Clear buffer
        }
      } else {
        // If we have any buffered Round CTAs, process them first
        if (roundCtaBuffer.length > 0) {
          const groupContainer = document.createElement("div");
          groupContainer.style.cssText =
            "display: flex; justify-content: center; gap: 10px; margin: 5px 0;";

          roundCtaBuffer.forEach((bufferedRow) => {
            const ctaButton = this.createCTAs(bufferedRow.CtaAttributes);
            groupContainer.appendChild(ctaButton);
          });

          container.appendChild(groupContainer);
          roundCtaBuffer = []; // Clear buffer
        }

        // Process non-Round CTA content as before
        if (row.InfoType === "TileRow") {
          const rowDiv = document.createElement("div");
          rowDiv.style.display = "flex";
          rowDiv.style.flexWrap = "wrap";
          rowDiv.style.margin = "2.5px 2.5px";
          rowDiv.style.gap = "2.5px";

          row.Tiles.forEach((tile: any) => {
            // console.log("tile.size", tile.Size);
            const tileHeight = tile.Size ? tile.Size / 3.2 : 25;

            const tileDiv = document.createElement("div");
            tileDiv.id = tile.Id;

            // Dynamically set alignment based on tile.Align
            const horizontalAlign = tile.Align === "center" ? "center" : "flex-start";
            const verticalAlign = tile.Align === "center" ? "center" : "flex-start";

            const icondiv = document.createElement("div");
            icondiv.style.color = tile.Color;
            if (tile.Icon) {
              icondiv.innerHTML = this.themeManager
                .getThemeIcon(tile.Icon)
                .replace(/fill="[^"]*"/g, 'fill="currentColor"')
                .replace(/style="[^"]*background[^"]*"/g, "")
                .replace(/<rect[^>]*fill="[^"]*"/g, '<rect fill="currentColor"')
                .replace("<svg", '<svg style="width: 7.5px; height: 7.5px;"');
            }

            const titlediv = document.createElement("div");
            titlediv.style.color = tile.Color;
            titlediv.style.textAlign = tile.Align;
            if (tile.Text) {
              titlediv.innerHTML = tile.Text;
            }

            tileDiv.appendChild(icondiv);
            tileDiv.appendChild(titlediv);

            tileDiv.style.cssText = `
                display: flex; /* Ensures flexbox layout */
                flex-direction: column; /* Aligns icon and title vertically */
                align-items: ${horizontalAlign}; /* Aligns content horizontally */
                justify-content: ${verticalAlign}; /* Aligns content vertically */
                padding: 2.5px;
                min-width: 25px;
                height: ${tileHeight}px;
                flex: 1;
                color: ${tile.Color};
                background-color: ${this.currentTheme.ThemeColors[tile.BGColor]};
                background-image: ${tile.BGImageUrl ? `url('${tile.BGImageUrl}')` : "none"};
                background-size: cover;
                background-repeat: no-repeat;
                background-position: center;
                text-align: ${tile.Align};
                border-radius: 5px;
                border: 2px dashed #4c53577d;
                font-size: 7px;
                font-family: ${this.currentTheme.ThemeFontFamily};
            `;

            rowDiv.appendChild(tileDiv);
          });

          container.appendChild(rowDiv);
        } else if (row.InfoType === "Description") {
          const descriptionDiv = document.createElement("div");
          descriptionDiv.style.margin = "2.5px";
          descriptionDiv.style.paddingLeft = "2.5px";
          descriptionDiv.style.paddingRight = "2.5px";
          descriptionDiv.style.color = "#333";
          descriptionDiv.style.fontSize = "7px";
          descriptionDiv.innerHTML = row.InfoValue;
          descriptionDiv.style.fontFamily = this.currentTheme.ThemeFontFamily;
          descriptionDiv.style.margin = "2.5px 2.5px";
          container.appendChild(descriptionDiv);
        } else if (row.InfoType === "Images") {
          const imageDiv = document.createElement("div");
          imageDiv.style.margin = "2.5px";
          imageDiv.style.borderRadius = "5px";
          imageDiv.style.overflow = "hidden";
          imageDiv.style.display = "flex";
          imageDiv.style.justifyContent = "center";
          imageDiv.style.alignItems = "center";
          const img = document.createElement("img");
          // img.src = row.InfoValue;
          img.src = row.Images[0].InfoImageValue;
          img.alt = "Image description";
          img.style.width = "100%";
          img.style.height = "50px";
          img.style.objectFit = "cover";
          imageDiv.appendChild(img);
          container.appendChild(imageDiv);
        } else if (row.InfoType === "Cta") {
          const buttonContainer = document.createElement("div");
          buttonContainer.style.display = "flex";
          const ctaButton = this.createCTAs(row.CtaAttributes);
          buttonContainer.appendChild(ctaButton);
          container.appendChild(buttonContainer);
        }
      }
    });

    return container.outerHTML;
  }

  createHeaderHTML(page: any) {
    const header = document.createElement("div");
    let appBar = `
        <div style="display:flex; padding:1px">
            <div class="">
                <div style="padding: 2px; font-size: 7px">${page.PageName.toUpperCase()}</div>
            </div>
        </div>
        `;

    if (page.PageName === "Home") {
      appBar = `
            <div class="home-app-bar" style="padding:2px"><div class="logo-added"><img src="${this.logo}" style="height: 20px;"></div>
            `;
    }

    header.innerHTML = `
            <div class="header" style="font-size: 6px;" ><span id="clock">8:36 AM</span><span class="icons"><i class="fas fa-signal"></i><i class="fas fa-wifi"></i><i class="fas fa-battery"></i></span></div>
            ${appBar}
        `;
    return header;
  }

  createMyActivityHTML(page: any) {
    const container = document.createElement("div");
    container.style.padding = "2.5px";
    const header = this.createHeaderHTML(page);
    container.appendChild(header);
    const body = document.createElement("div");
    body.innerHTML = `
        <div style="padding:2.5px;">
        <div class="activity-tabs" style="padding:2px;">
            <button style="background:${this.currentTheme.ThemeColors["backgroundColor"]}; font-size:6px; padding:2px; " class="activity-tab active">Messages</button>
            <button class="activity-tab inactive" style="font-size:6px; padding:2px">Requests</button>
          </div>
          <div align="center" style="font-size:6px">No Messages Yet</div>
        </div>
        `;
    container.appendChild(body);
    return container.outerHTML;
  }

  createAgendaHTML(page: any) {
    const container = document.createElement("div");
    container.style.padding = "2.5px";
    const header = this.createHeaderHTML(page);
    container.appendChild(header);
    const body = document.createElement("div");

    let pageData = `
                <div class="tb-date-selector"  
                  style="background-color: ${
  this.currentTheme.ThemeColors["backgroundColor"]
}; font-size: 6px; padding:2px;">
                  <span class="tb-arrow">❮</span>
                  <span class="tb-date-text" id="current-date" > ${this.formatDate()}</span>
                  <span class="tb-arrow">❯</span>
                </div>
                <div class="tb-schedule" id="schedule-container" >
              `;

    for (let hour = 0; hour < 24; hour++) {
      const formattedHour = hour.toString().padStart(2, "0") + ":00";
      pageData += `
                    <div class="tree-tb-time-slot" style="font-size:6px height= 10px">
                      <div class="tb-time" >${formattedHour}</div>
                      <div class="tb-events" ></div>
                      ${
  hour === new Date().getHours()
    ? `
                        <div class="tb-current-time-indicator" ></div>
                        <div class="tb-current-time-dot" ></div>`
    : ""
}

                    </div>
                  `;
    }
    pageData += `</div>`;

    body.innerHTML = pageData;
    container.appendChild(body);
    return container.outerHTML;
  }

  createMapHTML(page: any) {
    const container = document.createElement("div");
    container.style.padding = "2px";

    const header = this.createHeaderHTML(page);
    container.appendChild(header);

    const body = document.createElement("div");
    const lat = 52.0907;
    const lng = 5.1214;

    body.innerHTML = `
      <iframe>
        
        frameborder="0"
        style="height:300px; width:100%; border:0;"
        src="https://www.google.com/maps/embed/v1/view?key=AIzaSyBBaQo7_sF2xk3uNIyKp_Z-4BbaTebGGa4&center=${lat},${lng}&zoom=18"
        allowfullscreen>
      </iframe>
    `;

    container.appendChild(body);
    return container.outerHTML;
  }

  createLinkHTML(pageName: string, url: string) {
    const container = document.createElement("div");
    container.style.padding = "2px";
    const header = this.createHeaderHTML({ PageName: pageName });
    container.appendChild(header);
    const body = document.createElement("div");
    body.innerHTML = `
      <iframe src="${url}" style="pointer-events: none;" width="100%" height="100%" frameborder="0" marginheight="0" marginwidth="0">Loading…</iframe>
      `;
    container.appendChild(body);
    return container.outerHTML;
  }

  createCTAs(CTAs: CtaAttributes) {
    interface Icons {
      [key: string]: string | number;
    }
    interface Models {
      [key: string]: Function;
    }
    const icons: Icons = {
      Phone: `<svg data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 49.417 49.418"><path id="call" data-gjs-type="svg-in" d="M29.782,3a2.149,2.149,0,1,0,0,4.3A19.3,19.3,0,0,1,49.119,26.634a2.149,2.149,0,1,0,4.3,0A23.667,23.667,0,0,0,29.782,3ZM12.032,7.305a2.548,2.548,0,0,0-.818.067,8.342,8.342,0,0,0-3.9,2.342C2.775,14.254.366,21.907,17.437,38.98S42.16,53.643,46.7,49.1a8.348,8.348,0,0,0,2.346-3.907,2.524,2.524,0,0,0-1.179-2.786c-2.424-1.418-7.654-4.484-10.08-5.9a2.523,2.523,0,0,0-2.568.012l-4.012,2.392a2.517,2.517,0,0,1-2.845-.168,65.811,65.811,0,0,1-5.711-4.981,65.07,65.07,0,0,1-4.981-5.711A2.512,2.512,0,0,1,17.5,25.2L19.9,21.191a2.533,2.533,0,0,0,.008-2.577L14.012,8.556A2.543,2.543,0,0,0,12.032,7.305Zm17.751,4.289a2.149,2.149,0,1,0,0,4.3A10.709,10.709,0,0,1,40.525,26.634a2.149,2.149,0,1,0,4.3,0A15.072,15.072,0,0,0,29.782,11.594Zm0,8.594a2.149,2.149,0,1,0,0,4.3,2.114,2.114,0,0,1,2.149,2.148,2.149,2.149,0,1,0,4.3,0A6.479,6.479,0,0,0,29.782,20.188Z" transform="translate(-4 -3)" fill="#fff"></path></svg>`,

      Email: `<svg data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="32" height="28" viewBox="0 0 41 32.8"><path id="Path_1218" data-gjs-type="svg-in" data-name="Path 1218" d="M6.1,4A4.068,4.068,0,0,0,2.789,5.7a1.5,1.5,0,0,0,.444,2.126l18,11.219a2.387,2.387,0,0,0,2.531,0L41.691,7.732a1.5,1.5,0,0,0,.384-2.2A4.063,4.063,0,0,0,38.9,4Zm35.907,8.376a.963.963,0,0,0-.508.152L23.765,23.711a2.392,2.392,0,0,1-2.531,0L3.5,12.656a.98.98,0,0,0-1.5.833V32.7a4.1,4.1,0,0,0,4.1,4.1H38.9A4.1,4.1,0,0,0,43,32.7V13.357A.981.981,0,0,0,42.007,12.376Z" transform="translate(-2 -4)" fill="#fff"></path></svg>`,

      Link: `<svg xmlns="http://www.w3.org/2000/svg" width="22" height="28" viewBox="0 0 9.552 9.552"><path id="Path_1213" data-name="Path 1213" d="M11.064,4A2.485,2.485,0,0,0,9.3,4.734l-.585.585A2.488,2.488,0,0,0,7.98,7.084a2.45,2.45,0,0,0,.174.908L8.8,7.346a1.706,1.706,0,0,1,.473-1.468l.585-.585a1.7,1.7,0,0,1,1.206-.5,1.675,1.675,0,0,1,1.194.5,1.7,1.7,0,0,1,0,2.4l-.585.585a1.7,1.7,0,0,1-1.206.5,1.456,1.456,0,0,1-.261-.025L9.559,9.4a2.45,2.45,0,0,0,.908.174,2.486,2.486,0,0,0,1.766-.734l.585-.585a2.488,2.488,0,0,0,.734-1.766A2.506,2.506,0,0,0,11.064,4Zm-.983,2.9L6.9,10.082l.572.572L10.654,7.47Zm-3,1.082a2.485,2.485,0,0,0-1.766.734L4.734,9.3A2.488,2.488,0,0,0,4,11.064a2.506,2.506,0,0,0,2.487,2.487,2.486,2.486,0,0,0,1.766-.734l.585-.585a2.488,2.488,0,0,0,.734-1.766A2.45,2.45,0,0,0,9.4,9.559l-.647.647a1.706,1.706,0,0,1-.473,1.468l-.585.585a1.7,1.7,0,0,1-1.206.5,1.675,1.675,0,0,1-1.194-.5,1.7,1.7,0,0,1,0-2.4l.585-.585a1.7,1.7,0,0,1,1.206-.5,1.457,1.457,0,0,1,.261.025l.647-.647A2.45,2.45,0,0,0,7.084,7.98Z" transform="translate(-4 -4)" fill="#fff"/></svg>`,

      Form: `<svg id="igqdh" data-gjs-type="svg" xmlns="http://www.w3.org/2000/svg" width="22" height="24" viewBox="0 0 13 16"><path id="Path_1209" data-gjs-type="svg-in" data-name="Path 1209" d="M9.828,4A1.823,1.823,0,0,0,8,5.8V18.2A1.823,1.823,0,0,0,9.828,20h9.344A1.823,1.823,0,0,0,21,18.2V9.8a.6.6,0,0,0-.179-.424l-.006-.006L15.54,4.176A.614.614,0,0,0,15.109,4Zm0,1.2H14.5V8.6a1.823,1.823,0,0,0,1.828,1.8h3.453v7.8a.6.6,0,0,1-.609.6H9.828a.6.6,0,0,1-.609-.6V5.8A.6.6,0,0,1,9.828,5.2Zm5.891.848L18.92,9.2H16.328a.6.6,0,0,1-.609-.6Z" transform="translate(-8 -4)" fill=""></path></svg>`,

      Map: `<svg fill="#fff" width="25.909" height="25.909" viewBox="0 0 36 36" version="1.1"  preserveAspectRatio="xMidYMid meet" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><path class="clr-i-outline clr-i-outline-path-1" d="M18,6.72a5.73,5.73,0,1,0,5.73,5.73A5.73,5.73,0,0,0,18,6.72Zm0,9.46a3.73,3.73,0,1,1,3.73-3.73A3.73,3.73,0,0,1,18,16.17Z"></path><path class="clr-i-outline clr-i-outline-path-2" d="M18,2A11.79,11.79,0,0,0,6.22,13.73c0,4.67,2.62,8.58,4.54,11.43l.35.52a99.61,99.61,0,0,0,6.14,8l.76.89.76-.89a99.82,99.82,0,0,0,6.14-8l.35-.53c1.91-2.85,4.53-6.75,4.53-11.42A11.79,11.79,0,0,0,18,2ZM23.59,24l-.36.53c-1.72,2.58-4,5.47-5.23,6.9-1.18-1.43-3.51-4.32-5.23-6.9L12.42,24c-1.77-2.64-4.2-6.25-4.2-10.31a9.78,9.78,0,1,1,19.56,0C27.78,17.79,25.36,21.4,23.59,24Z"></path><rect x="0" y="0" width="36" height="36" fill-opacity="0"/></svg>`,

      Basket: `<svg xmlns="http://www.w3.org/2000/svg" width="21.202" height="23.999" viewBox="0 0 21.202 23.999"><g id="noun-shopping-7351596" transform="translate(-78.269 -9.37)"><path id="Path_1308" data-name="Path 1308" d="M98.9,17.466a2.214,2.214,0,0,0-1.642-.732H94.479V15a5.627,5.627,0,1,0-11.255,0v1.737H80.481a2.211,2.211,0,0,0-2.195,2.492l1.585,12.219a2.214,2.214,0,0,0,2.191,1.924H95.991a2.207,2.207,0,0,0,2.2-1.981l1.269-12.219a2.2,2.2,0,0,0-.556-1.707ZM85.129,15a3.722,3.722,0,1,1,7.445,0v1.737H85.126V15ZM96.3,31.194a.3.3,0,0,1-.3.274H82.066a.3.3,0,0,1-.3-.267L80.18,18.983a.3.3,0,0,1,.072-.24.307.307,0,0,1,.229-.1H97.26a.3.3,0,0,1,.225.1.314.314,0,0,1,.076.236L96.292,31.194Z" transform="translate(0 0)" fill="#fff"/><path id="Path_1309" data-name="Path 1309" d="M322.894,552.19a.956.956,0,1,0,.956.956A.957.957,0,0,0,322.894,552.19Z" transform="translate(-238.718 -531.79)" fill="#fff"/><path id="Path_1310" data-name="Path 1310" d="M783.2,552.19a.956.956,0,1,0,.956.956A.957.957,0,0,0,783.2,552.19Z" transform="translate(-689.674 -531.79)" fill="#fff"/></g></svg>`,

      Business: `<svg xmlns="http://www.w3.org/2000/svg" width="25.909" height="22.657" viewBox="0 0 25.909 22.657"><path id="noun-business-7087804-converted-converted" d="M10.084.041A1.765,1.765,0,0,0,8.645.863a2.322,2.322,0,0,0-.31,1.442v.582L5.215,2.9c-3.114.017-3.121.017-3.4.115A2.724,2.724,0,0,0,.13,4.635L0,4.959V8.8c0,2.11.018,3.958.04,4.107a.807.807,0,0,0,.725.726l.177.028L.964,17.14c.013,2.079.039,3.585.066,3.737a2.363,2.363,0,0,0,1.7,1.752c.158.032,3.233.043,10.356.035l10.131-.012.381-.189A2.33,2.33,0,0,0,24.687,21.4a1.817,1.817,0,0,0,.2-.744c.028-.254.047-1.725.048-3.7l0-3.278.25-.069a1.331,1.331,0,0,0,.4-.193c.3-.244.288-.044.309-4.022.012-2.326,0-3.774-.028-4.124a1.764,1.764,0,0,0-.231-.907A2.734,2.734,0,0,0,24.034,3,21.582,21.582,0,0,0,20.676,2.9l-3.1-.018V2.412A2.2,2.2,0,0,0,17,.58,1.663,1.663,0,0,0,15.811.04C15.347,0,10.69,0,10.084.041M15.7,1.751c.122.025.144.128.145.678v.465H10.007l.026-.525a2.195,2.195,0,0,1,.073-.573A5.792,5.792,0,0,1,11.2,1.725c1.085-.025,4.345-.006,4.506.026m8.062,3a1.491,1.491,0,0,1,.254.237l.1.127.011,3.467c.011,3.085,0,3.467-.054,3.467-.036,0-1.975.244-4.309.542s-4.332.554-4.441.567l-.2.024-.03-.437a1.3,1.3,0,0,0-.6-1.2l-.261-.192-1.277.013c-1.446.015-1.441.014-1.8.387a1.221,1.221,0,0,0-.343.964c-.02.322-.044.454-.082.454s-1.568-.193-3.417-.429l-4.467-.569L1.74,12.035l-.028-.414c-.033-.5-.028-3.088.009-5.038l.028-1.429L1.871,5c.234-.308.229-.306,1.452-.333.607-.013,5.421-.023,10.7-.022l9.593,0,.154.109M13.388,14.468v1.425h-.863v-2.85h.863v1.425m-6.607-.063c2.149.273,3.93.505,3.956.514a3.2,3.2,0,0,1,.073.852,7.79,7.79,0,0,0,.075,1,1.441,1.441,0,0,0,.776.734,11.986,11.986,0,0,0,2.561.006,1.287,1.287,0,0,0,.8-.849c.023-.1.056-.544.073-.978.024-.617.043-.788.089-.788s1.8-.224,3.938-.5,3.935-.5,4-.5h.122l-.028,2.105q-.024,1.676-.029,3.353v1.247L23,20.8l-.188.189H3.064L2.871,20.8,2.678,20.6V13.875l.1.017c.053.009,1.856.24,4.006.513" transform="translate(0 -0.009)" fill="#fff" fill-rule="evenodd"/></svg>`,

      Calendar: `<svg xmlns="http://www.w3.org/2000/svg" width="19.929" height="23.811" viewBox="0 0 19.929 23.811"><path id="Group_718-converted" data-name="Group 718-converted" d="M5.809.048a1.008,1.008,0,0,0-.575.517c-.057.105-.065.214-.08,1.064l-.017.948L4.023,2.6a5.38,5.38,0,0,0-1.372.09A3.61,3.61,0,0,0,.109,5.237l-.092.332v15.2l.075.3a3.568,3.568,0,0,0,2.369,2.572c.554.181.219.173,7.513.173,7.4,0,6.994.011,7.6-.2a3.544,3.544,0,0,0,2.338-2.841c.028-.193.035-2.293.028-7.747l-.01-7.481-.091-.316A3.607,3.607,0,0,0,17.3,2.685,5.438,5.438,0,0,0,15.927,2.6l-1.114-.019L14.8,1.629,14.78.682,14.681.5a.922.922,0,0,0-.769-.5A.853.853,0,0,0,13.166.3c-.283.285-.3.359-.3,1.42v.878H7.082V1.718C7.082.649,7.068.578,6.788.3A.923.923,0,0,0,5.809.048M5.16,5.461c.01.888.014.947.082,1.073a.985.985,0,0,0,1.163.5.806.806,0,0,0,.379-.245c.282-.283.3-.359.3-1.4V4.522h5.786V5.38c0,1.052.015,1.125.294,1.4a.9.9,0,0,0,1.315.032c.3-.276.319-.355.319-1.412v-.88h.944a3.826,3.826,0,0,1,1.156.066,1.662,1.662,0,0,1,.925.768c.191.359.2.46.2,2.466V9.643H1.929V7.818c0-1.073.013-1.9.033-2a1.727,1.727,0,0,1,.75-1.08c.33-.193.443-.209,1.484-.211l.954,0,.01.939m12.861,10.51c0,3.007-.011,4.461-.035,4.6a1.648,1.648,0,0,1-1.255,1.275c-.249.052-13.263.052-13.512,0a1.646,1.646,0,0,1-1.254-1.254c-.026-.123-.036-1.5-.036-4.6V11.571H18.021v4.4m-6.549-.886c-.259.01-.362.027-.407.067s-.059.17-.059,1.927c0,1.829,0,1.875.066,1.94s.111.066,1.929.066,1.863,0,1.928-.066.067-.111.067-1.94,0-1.875-.066-1.933-.178-.06-1.588-.067q-.935-.007-1.87.006" transform="translate(-0.017 0.004)" fill="#fff" fill-rule="evenodd"/></svg>`,

      Card: `<svg xmlns="" width="30.636" height="21.438" viewBox="0 0 30.636 21.438"><path id="Path_1321-converted" data-name="Path 1321-converted" d="M2.954.053A3.566,3.566,0,0,0,.36,2.02C0,2.763.026,2.19.026,10.792v7.8L.165,19a3.5,3.5,0,0,0,.889,1.427,3.512,3.512,0,0,0,1.427.889l.409.139H27.8l.409-.139A3.715,3.715,0,0,0,30.523,19l.139-.409V2.89l-.139-.409a3.491,3.491,0,0,0-.889-1.427A3.491,3.491,0,0,0,28.207.165L27.8.026,15.5.018C8.732.015,3.088.03,2.954.053m24.9,1.906a1.739,1.739,0,0,1,.874.872,2.2,2.2,0,0,1,.164,1.042l.025.73H1.776L1.8,3.87a2.152,2.152,0,0,1,.163-1.035,1.737,1.737,0,0,1,1.225-.992c.117-.023,5.644-.039,12.283-.035l12.07.008.307.143m1.023,11.39v4.987l-.144.313a1.772,1.772,0,0,1-.879.874l-.307.143-12.017.013c-7.849.009-12.113,0-12.294-.037a1.7,1.7,0,0,1-1.389-1.378c-.058-.306-.075-9.836-.018-9.893.019-.019,6.113-.028,13.541-.021l13.507.012v4.987M4.6,10.741v.92h11V9.82H4.6v.921" transform="translate(-0.026 -0.018)" fill="#fff" fill-rule="evenodd"/></svg>`,

      Document: `<svg xmlns="http://www.w3.org/2000/svg" width="18.648" height="23.81" viewBox="0 0 18.648 23.81"><path id="file-text-converted" d="M2.658.045A3.408,3.408,0,0,0,1.34.567a4.264,4.264,0,0,0-.868.925A3.694,3.694,0,0,0,.07,2.5c-.051.239-.054.787-.054,9.416s0,9.177.054,9.416a3.7,3.7,0,0,0,.4,1.007,4.219,4.219,0,0,0,.868.925,3.551,3.551,0,0,0,1.24.513c.3.057,13.208.057,13.507,0a3.154,3.154,0,0,0,.853-.294,2.648,2.648,0,0,0,.735-.514,3.129,3.129,0,0,0,.959-1.906c.027-.217.034-2.1.027-7.034l-.01-6.738-.093-.175c-.071-.135-.823-.94-3.207-3.436Q13.736,1.987,12.115.3a1.278,1.278,0,0,0-.293-.2L11.651.016,7.28.011c-3.384,0-4.428,0-4.622.034M10.111,4.79c0,1.95.011,2.848.035,2.963a.972.972,0,0,0,.824.772c.108.018,1.321.03,2.945.031h2.761v6.093c0,3.938-.011,6.152-.031,6.258a1.139,1.139,0,0,1-.908.9c-.11.02-2.373.028-6.514.023-5.24-.007-6.365-.016-6.456-.051a1.374,1.374,0,0,1-.562-.441c-.232-.33-.214.456-.214-9.425s-.018-9.1.213-9.425a1.214,1.214,0,0,1,.627-.451c.145-.038.725-.045,3.726-.047l3.554,0v2.8m3.669.126c.84.881,1.527,1.612,1.527,1.625s-.721.024-1.6.024H12.1V3.159l.076.077,1.6,1.68m-8.993,2.8a.968.968,0,0,0-.473.388.986.986,0,0,0,.337,1.405c.215.127.443.144,1.713.134l1.181-.01.178-.083A1.056,1.056,0,0,0,8.246,9,.838.838,0,0,0,8.3,8.587a.977.977,0,0,0-.552-.845l-.14-.073L6.269,7.662a5.362,5.362,0,0,0-1.482.05m-.058,4.326a1.09,1.09,0,0,0-.626.531,1.181,1.181,0,0,0,0,.846,1.136,1.136,0,0,0,.5.489l.171.081,4.184.009c2.952.006,4.244,0,4.387-.026a.942.942,0,0,0,.581-.318.991.991,0,0,0-.307-1.554l-.134-.071-4.34-.006c-2.387,0-4.375.006-4.418.019m.054,3.987a.993.993,0,0,0-.433,1.711,1.189,1.189,0,0,0,.306.183c.167.063.221.064,4.444.064,4.252,0,4.277,0,4.448-.065A1.138,1.138,0,0,0,14.1,17.4a1.1,1.1,0,0,0-.012-.817,1.041,1.041,0,0,0-.494-.5l-.171-.081L9.162,16c-2.429,0-4.312.007-4.379.023" transform="translate(-0.016 -0.01)" fill="#fff" fill-rule="evenodd"/></svg>`,

      Entertainment: `<svg xmlns="http://www.w3.org/2000/svg" width="24.688" height="24.678" viewBox="0 0 24.688 24.678"><path id="noun-entertainment-7156613-converted" d="M9.749.041a.786.786,0,0,0-.482.385C9.183.6,9.182.651,9.182,3.735c0,1.8.018,3.314.042,3.559a9.016,9.016,0,0,0,.542,2.3l.137.355.678-.265c.374-.146.683-.269.687-.273q-.078-.266-.171-.527a7.271,7.271,0,0,1-.391-1.837c-.022-.267-.041-1.5-.041-2.737V2.062l.443.22a13.094,13.094,0,0,0,5.816,1.34,12.977,12.977,0,0,0,5.715-1.276c.283-.135.53-.246.549-.246.05,0,.044,4.408-.007,4.979A6.9,6.9,0,0,1,22.437,9.7a6.718,6.718,0,0,1-1.188,1.72c-.516.543-2.574,2.424-2.77,2.531-.15.083-.227.093-.7.093h-.529v1.482h.6c1.137,0,1.214-.042,2.852-1.546a17.756,17.756,0,0,0,2.2-2.2,9.017,9.017,0,0,0,1.69-3.932,25.148,25.148,0,0,0,.1-3.747c.013-2.376,0-3.354-.029-3.508A.73.73,0,0,0,23.8.04,3.868,3.868,0,0,0,23.2.354a14.807,14.807,0,0,1-1.662.86,11.939,11.939,0,0,1-9.321-.059A14.425,14.425,0,0,1,10.586.294,1.638,1.638,0,0,0,9.9,0a1.084,1.084,0,0,0-.154.037m3.859,5.425a2.7,2.7,0,0,0-.967.266,2.2,2.2,0,0,0-.689.5,2.257,2.257,0,0,0-.338.375,5.067,5.067,0,0,0,.558.5l.556.458.208-.22a1,1,0,0,1,.8-.387,1.065,1.065,0,0,1,.824.395.692.692,0,0,0,.188.181,5.911,5.911,0,0,0,.591-.458l.55-.457L15.7,6.4a2.8,2.8,0,0,0-1.285-.838,3.18,3.18,0,0,0-.8-.091m6.227.019a2.75,2.75,0,0,0-1.664.923l-.18.212.567.474.568.474.206-.22a1.045,1.045,0,0,1,.8-.388,1.1,1.1,0,0,1,.826.4l.187.208.561-.459a5.62,5.62,0,0,0,.564-.5,2.515,2.515,0,0,0-.339-.374,2.473,2.473,0,0,0-2.1-.753M14,7.551c-.053.029-.377.331-.72.67a11.663,11.663,0,0,1-3.424,2.433,11.456,11.456,0,0,1-5.352,1.107,11.15,11.15,0,0,1-3.237-.522c-.582-.179-.752-.16-1.036.116a.669.669,0,0,0-.213.6c.07.331,1.517,5.693,1.63,6.039a8.9,8.9,0,0,0,1,2.1,9.2,9.2,0,0,0,2.687,2.63c.541.335,3.394,1.806,3.657,1.885a2.251,2.251,0,0,0,.638.073,6.124,6.124,0,0,0,1.729-.363c1.511-.407,1.771-.516,2.141-.9A36.641,36.641,0,0,0,15.876,19.7a8.7,8.7,0,0,0,.861-4.853,11.818,11.818,0,0,0-.46-2.121L16,11.683l.121-.1a1.151,1.151,0,0,1,.822-.275.936.936,0,0,1,.539.109,1.637,1.637,0,0,1,.619.635.4.4,0,0,0,.31.22,11.2,11.2,0,0,0,1.159-.494,2.809,2.809,0,0,0-.55-1.009,2.743,2.743,0,0,0-3.171-.737,1,1,0,0,1-.259.1q-.154-.536-.294-1.076a11.7,11.7,0,0,0-.368-1.214.779.779,0,0,0-.924-.284m.521,4.38c.324,1.217.615,2.342.648,2.5a7.318,7.318,0,0,1-.777,4.9c-.3.535-1.8,2.881-1.928,3.011-.175.184-.286.223-1.616.575-1.109.293-1.2.312-1.38.271s-2.141-1.042-3.061-1.558a7.355,7.355,0,0,1-3.224-3.723c-.076-.2-.408-1.365-.738-2.6S1.84,13.039,1.827,13c-.018-.06-.007-.071.053-.052.165.052,1.008.194,1.517.255a16.493,16.493,0,0,0,2.676.019,13.472,13.472,0,0,0,7.515-3.23,4.047,4.047,0,0,1,.329-.27c.011,0,.286.995.609,2.212m-2.6,1.8a2.688,2.688,0,0,0-1.694,1.352.8.8,0,0,0-.121.357c.019.019.318.165.664.324l.629.289.1-.2a1.035,1.035,0,0,1,1.62-.466c.122.08.235.13.251.111a9.483,9.483,0,0,0,.8-1.2,2.734,2.734,0,0,0-2.251-.563m-6,1.628a2.548,2.548,0,0,0-1.456.786,2.909,2.909,0,0,0-.558.9c0,.041.217.161.628.347.345.157.641.291.657.3s.084-.094.151-.226a1.134,1.134,0,0,1,.669-.6.907.907,0,0,1,.9.164,1.358,1.358,0,0,0,.243.143,2.781,2.781,0,0,0,.313-.4c.155-.221.344-.489.421-.6l.139-.195-.317-.207a2.667,2.667,0,0,0-1.792-.412m5.193,3.484a1.378,1.378,0,0,1-.356.756,1.309,1.309,0,0,1-1.5.246,1.847,1.847,0,0,1-.376-.326,1.912,1.912,0,0,0-.25-.249c-.033,0-1.118.862-1.13.9a1.1,1.1,0,0,0,.194.267,2.693,2.693,0,0,0,2.142,1.031,2.633,2.633,0,0,0,1.276-.308,2.128,2.128,0,0,0,.681-.5,2.706,2.706,0,0,0,.8-1.645c.022-.136.018-.2-.013-.215q-.3-.058-.6-.1-.343-.051-.685-.105l-.13-.022-.048.275" transform="translate(-0.012 -0.003)" fill="#fff" fill-rule="evenodd"/></svg>`,

      Food: `<svg xmlns="http://www.w3.org/2000/svg" width="30.333" height="24.656" viewBox="0 0 30.333 24.656"><g id="food-17" transform="translate(-32 437.536)"><path id="Path_1266" data-name="Path 1266" d="M341.073-437.452a1.061,1.061,0,0,0-.544.782c0,.109.17,1.2.374,2.435s.374,2.272.374,2.306-.2.075-.5.075a1.05,1.05,0,0,0-1.088.544c-.122.238-.116.354.36,8.964.272,4.795.517,8.794.544,8.875a1.116,1.116,0,0,0,.53.53c.1.034,1.483.061,3.224.061,3.367,0,3.305.007,3.6-.422.156-.211.163-.354.612-8.413.544-9.671.53-9.358.381-9.644-.245-.469-.2-.456-3.1-.5l-2.618-.034-.422-2.523c-.231-1.387-.456-2.591-.5-2.666A1,1,0,0,0,341.073-437.452Zm6.012,8.127c-.027.347-.218,3.754-.428,7.57l-.381,6.937-1.959.02a15.214,15.214,0,0,1-1.952-.048c0-.034-.184-3.367-.408-7.406s-.408-7.427-.408-7.522v-.177h5.57Z" transform="translate(-286.697 0)" fill="#fff"/><path id="Path_1267" data-name="Path 1267" d="M40.5-325.785a12.692,12.692,0,0,0-4.829,1.292,6.823,6.823,0,0,0-3.5,4.516c-.19.884-.109,1.258.32,1.571l.224.156H42c9.209,0,9.283,0,9.522-.136a1.18,1.18,0,0,0,.36-.374c.32-.612-.218-2.442-1.068-3.632A8.57,8.57,0,0,0,49-324.119a12.581,12.581,0,0,0-7.107-1.7C41.3-325.813,40.672-325.8,40.5-325.785Zm4.013,2.02c2.353.408,3.945,1.258,4.876,2.625a3.467,3.467,0,0,1,.456.864l.048.156H42.039c-5.693,0-7.862-.02-7.862-.075a4.688,4.688,0,0,1,.966-1.523,7.684,7.684,0,0,1,4.917-2.115A24.288,24.288,0,0,1,44.515-323.766Z" transform="translate(-0.069 -104.118)" fill="#fff"/><path id="Path_1268" data-name="Path 1268" d="M60.429-199.864a.933.933,0,0,0-.292,1.272c.272.456-.231.428,7.937.428,7.3,0,7.4,0,7.624-.136a.991.991,0,0,0,.422-.782.991.991,0,0,0-.422-.782c-.224-.136-.32-.136-7.638-.136C60.83-200,60.64-199.993,60.429-199.864Z" transform="translate(-26.096 -221.381)" fill="#fff"/><path id="Path_1269" data-name="Path 1269" d="M32.748-158.6a1.222,1.222,0,0,0-.36.17c-.381.272-.388.333-.388,2.652,0,2.387.014,2.469.483,2.72.224.116.619.122,9.562.109l9.324-.02.184-.17c.367-.347.374-.374.374-2.632,0-2.346-.014-2.435-.476-2.707-.238-.136-.32-.136-9.385-.143C37.033-158.632,32.843-158.618,32.748-158.6ZM50.023-155.8v.952H33.9v-1.9H50.023Z" transform="translate(0 -259.941)" fill="#fff"/></g></svg>`,

      Globe: `<svg xmlns="http://www.w3.org/2000/svg" width="22.531" height="22.53" viewBox="0 0 22.531 22.53"><path id="noun-website-7190948" d="M144.859,133.6h0a11.265,11.265,0,1,0,11.266,11.265A11.264,11.264,0,0,0,144.858,133.6Zm-3.679,2.292h0a16.019,16.019,0,0,0-1.689,3.267h0a14.548,14.548,0,0,1-1.777-.85,9.7,9.7,0,0,1,3.465-2.418Zm7.358,0h0A9.714,9.714,0,0,1,152,138.31h0a14.769,14.769,0,0,1-1.775.849,16.119,16.119,0,0,0-1.689-3.269Zm-2.894-.692h0c.138.01.272.025.408.042h0a14.507,14.507,0,0,1,2.683,4.418h0a14.555,14.555,0,0,1-3.09.5Zm-1.572,4.962h0a14.568,14.568,0,0,1-3.091-.5h0a14.535,14.535,0,0,1,2.681-4.418c.136-.017.272-.031.41-.042Zm-3.574.994h0a16.111,16.111,0,0,0,3.576.577l0,2.345h-4.031a14.525,14.525,0,0,1,.456-2.922Zm-3.758-1.594h0a16.07,16.07,0,0,0,2.266,1.095h0a16.139,16.139,0,0,0-.538,3.422H135.2a9.632,9.632,0,0,1,1.546-4.518Zm12.478,1.593h0a14.525,14.525,0,0,1,.457,2.924h-4.032l0-2.345a16.165,16.165,0,0,0,3.576-.579Zm3.758-1.594h0a9.645,9.645,0,0,1,1.546,4.518h-3.276a16.068,16.068,0,0,0-.537-3.423h0a16.1,16.1,0,0,0,2.262-1.1Zm-8.9,8.435a15.961,15.961,0,0,0-3.574.577,14.468,14.468,0,0,1-.456-2.924h4.031Zm5.6-2.346h0a14.538,14.538,0,0,1-.457,2.922,16.093,16.093,0,0,0-3.574-.579V145.65Zm-11.206,0a16.079,16.079,0,0,0,.537,3.422h0a15.861,15.861,0,0,0-2.263,1.095h0a9.633,9.633,0,0,1-1.546-4.518Zm16.054,0h0a9.635,9.635,0,0,1-1.548,4.518,16.1,16.1,0,0,0-2.263-1.095h0a16.1,16.1,0,0,0,.537-3.424Zm-4.3,4.92h0a14.457,14.457,0,0,1,1.777.849h0a9.71,9.71,0,0,1-3.465,2.416,16.074,16.074,0,0,0,1.688-3.267Zm-10.735,0a16.08,16.08,0,0,0,1.688,3.267h0a9.728,9.728,0,0,1-3.465-2.417h0a14.293,14.293,0,0,1,1.771-.848Zm6.155-1h0a14.433,14.433,0,0,1,3.092.5h0a14.526,14.526,0,0,1-2.682,4.417h0c-.136.016-.273.031-.411.042Zm-1.574,0v4.962c-.138-.011-.275-.025-.412-.042h0a14.572,14.572,0,0,1-2.679-4.418h0a14.494,14.494,0,0,1,3.09-.5Z" transform="translate(-133.593 -133.6)" fill="#fff"/></svg>`,

      Info: `<svg xmlns="http://www.w3.org/2000/svg" width="22.932" height="22.946" viewBox="0 0 22.932 22.946"><path id="Path_1302-converted" data-name="Path 1302-converted" d="M10.757.027c-.074.009-.324.035-.554.058A11.477,11.477,0,1,0,22.638,14.2a9.365,9.365,0,0,0,.3-2.709,9.4,9.4,0,0,0-.281-2.621A11.52,11.52,0,0,0,12.92.1a19.476,19.476,0,0,0-2.162-.07m2.119,1.934a9.076,9.076,0,0,1,2.876.9,9.574,9.574,0,0,1,4.362,4.362A8.632,8.632,0,0,1,20.8,9.042a8.768,8.768,0,0,1,.3,2.445,9.044,9.044,0,0,1-.986,4.268,9.643,9.643,0,0,1-6.735,5.182,7.954,7.954,0,0,1-1.895.174,8.674,8.674,0,0,1-2.679-.366,9.676,9.676,0,0,1-6.772-7.392,8.52,8.52,0,0,1-.167-1.9,9.118,9.118,0,0,1,.988-4.229A9.608,9.608,0,0,1,12.876,1.962M11.064,4.373a1.931,1.931,0,0,0-.9.511,1.783,1.783,0,0,0-.55,1.322,1.882,1.882,0,0,0,1.875,1.876A1.882,1.882,0,0,0,13.36,6.205a1.783,1.783,0,0,0-.55-1.322,1.891,1.891,0,0,0-1.746-.511m-1.943,5.67.01.928.469.011.469.011v5.356H9.111l.01.909.01.909h4.708l.01-.909.01-.909H12.9V9.114H9.111l.01.928" transform="translate(-0.01 -0.017)" fill="#fff" fill-rule="evenodd"/></svg>`,

      Pill: `<svg xmlns="http://www.w3.org/2000/svg" width="22.203" height="22.204" viewBox="0 0 22.203 22.204"><path id="Path_1320-converted" data-name="Path 1320-converted" d="M15.1.021a6.773,6.773,0,0,0-2.613.744c-.925.476-.725.29-5.943,5.5-2.626,2.62-4.88,4.89-5.007,5.043A6.725,6.725,0,0,0,.088,14.494,9.213,9.213,0,0,0,.07,16.532a6.721,6.721,0,0,0,1.9,3.749A6.455,6.455,0,0,0,4.337,21.8a6.169,6.169,0,0,0,2.335.414A6.25,6.25,0,0,0,9.021,21.8a6.511,6.511,0,0,0,1.692-.923c.324-.24,9.528-9.4,9.963-9.923A6.668,6.668,0,0,0,16.607.091a10,10,0,0,0-1.5-.07m1.242,1.927A4.82,4.82,0,0,1,20.3,5.912a6.166,6.166,0,0,1-.04,1.761,5.145,5.145,0,0,1-.857,1.88c-.216.294-3.7,3.829-3.773,3.829-.052,0-6.768-6.716-6.768-6.768,0-.022.805-.839,1.789-1.816,1.209-1.2,1.886-1.846,2.09-1.99a5.04,5.04,0,0,1,2.028-.859,6.02,6.02,0,0,1,1.581,0" transform="translate(-0.022 -0.014)" fill="#fff" fill-rule="evenodd"/></svg>`,

      Taxi: `<svg xmlns="http://www.w3.org/2000/svg" width="23.189" height="23.616" viewBox="0 0 23.189 23.616"><path id="noun-taxi-5761860-converted" d="M9.13.042a1.913,1.913,0,0,0-1.262.98,2.426,2.426,0,0,0-.212,1.153v.377H6.1c-1.732,0-1.793.007-2.3.257a2.9,2.9,0,0,0-1.005.919c-.3.5-.29.432-.663,4.115q-.166,1.7-.354,3.389a1.79,1.79,0,0,1-.222.055A2.013,2.013,0,0,0,.041,12.864c-.032.187-.041,1.144-.032,3.3C.02,19.11.023,19.2.1,19.414a2.452,2.452,0,0,0,.392.7,2.284,2.284,0,0,0,.787.542l.229.084v.706a3.016,3.016,0,0,0,.073.942,1.854,1.854,0,0,0,.971,1.1l.251.12h3.21l.251-.12a1.854,1.854,0,0,0,.971-1.1,2.879,2.879,0,0,0,.073-.908V20.8h8.545v.454a3.067,3.067,0,0,0,.2,1.354,1.992,1.992,0,0,0,.872.87l.264.125,1.523.011c1.725.012,1.759.008,2.176-.272a2.034,2.034,0,0,0,.694-.833,2.446,2.446,0,0,0,.1-1l.014-.778.226-.083a2.265,2.265,0,0,0,.784-.541,2.406,2.406,0,0,0,.385-.683l.087-.229.011-3.035c.009-2.154,0-3.112-.032-3.3a2.021,2.021,0,0,0-1.52-1.579c-.213-.043-.215-.044-.236-.2-.012-.088-.16-1.56-.33-3.272s-.334-3.226-.367-3.364a2.221,2.221,0,0,0-.668-1.161,2.136,2.136,0,0,0-.627-.476c-.519-.252-.576-.258-2.309-.258H15.544V2.175a2.426,2.426,0,0,0-.212-1.153A1.887,1.887,0,0,0,14.04.039c-.254-.048-4.663-.046-4.91,0m4.758,1.607c.06.055.071.127.071.484v.419H9.241V2.139c0-.329.013-.426.064-.483s.183-.071,2.288-.071a9.351,9.351,0,0,1,2.3.064m4.828,2.537a.92.92,0,0,1,.459.618c.023.112.173,1.517.333,3.123s.3,3,.314,3.1l.024.183H11.6c-4.533,0-8.241-.01-8.241-.023,0-.142.631-6.236.661-6.386a.92.92,0,0,1,.459-.618L4.656,4.1H18.544l.172.087M21.5,12.944l.113.127v2.92c0,3.171.006,3.081-.212,3.18-.078.036-2.364.046-9.807.046-10.561,0-9.861.015-9.964-.211-.035-.076-.047-.838-.047-3.014V13.08l.083-.1a.52.52,0,0,1,.164-.139c.045-.018,4.464-.029,9.82-.025l9.737.007.113.126m-15.866.631a2.33,2.33,0,0,0-1.462.732,2.55,2.55,0,0,0-.659,1.16,3.475,3.475,0,0,0,0,1.16,2.636,2.636,0,0,0,.945,1.419,2.264,2.264,0,0,0,1.479.479A2.215,2.215,0,0,0,7.7,17.791a2.442,2.442,0,0,0,0-3.489,2.353,2.353,0,0,0-2.06-.727m11.252,0a2.5,2.5,0,0,0-2.063,1.709,2.671,2.671,0,0,0-.021,1.459,2.515,2.515,0,0,0,1.765,1.72,3.237,3.237,0,0,0,1.256,0,2.521,2.521,0,0,0,1.78-1.782,2.491,2.491,0,0,0-2.717-3.106m-10.6,1.6a.9.9,0,0,1,.158,1.593.634.634,0,0,1-.471.109.622.622,0,0,1-.49-.125.885.885,0,0,1,.088-1.532.875.875,0,0,1,.715-.045m11.288.015a1.188,1.188,0,0,1,.286.2.885.885,0,0,1-.133,1.349c-.18.13-.207.137-.5.137a.62.62,0,0,1-.491-.125.885.885,0,0,1,.088-1.532.875.875,0,0,1,.751-.03M5.761,21.37c0,.474-.01.579-.064.638s-.15.071-1.268.071a4.707,4.707,0,0,1-1.28-.055c-.067-.049-.076-.114-.087-.638L3.049,20.8H5.761v.567m14.384,0c0,.474-.01.579-.064.638s-.151.071-1.293.071c-1.226,0-1.229,0-1.289-.086-.048-.068-.06-.2-.06-.638V20.8h2.706v.567" transform="translate(-0.006 -0.004)" fill="#fff" fill-rule="evenodd"/></svg>`,
    };

    const models: Models = {
      FullWidth: (cta: any) => `
              <div class="plain-button-container-tree">
                <button class="plain-button-tree" style="background:${this.getCtaColor(cta.CtaBGColor)}">
                  <span class="label">${cta.CtaLabel}</span>
                </button>
              </div>
            `,

      Round: (cta: any) => `
      
              <div class="cta-round-button-tree">
                <div class="cta-round-button-icon-tree" style="background:${this.getCtaColor(cta.CtaBGColor)}">${icons[cta.CtaType]}</div>
                <div style="font-size:8px;">${cta.CtaLabel}<div>
              </div>
            `,
      Image: (cta: any) => `
              <div class="cta-image-button-tree" style="background:${this.getCtaColor(
    cta.CtaBGColor
  )}">
                <div class="cta-image-button-image-tree"> <img src= "${
  cta.CtaButtonImgUrl
}" alt="Image" style="width: 18px; height: 18px; object-fit: cover; border-radius: 5px;"/></div>
                <div class="cta-image-button-label-tree">${cta.CtaLabel}</div>
                <i class="fa fa-angle-right img-button-arrow-tree"></i>
              </div>
              `,
      Icon: (cta: any) => `
              <div class="cta-icon-button-tree" style="background:${this.getCtaColor(
    cta.CtaBGColor
  )}">
                <div class="cta-icon-button-icon-tree" >${icons[cta.CtaButtonIcon]}</div>
                <div class="cta-icon-button-label-tree">
                  ${cta.CtaLabel}
                </div>
                <i class="fa fa-angle-right img-button-arrow-tree"></i>
              </div>
              `,
    };

    // CTA buttons container
    const ctaContainer = document.createElement("div");
    ctaContainer.setAttribute(
      "style",
      "display: flex; justify-content: center; align-items: center; flex-wrap: wrap; gap: 5px;"
    );

    if (CTAs.CtaButtonType) {
      const modelRenderer = models[CTAs.CtaButtonType];
      if (modelRenderer) {
        ctaContainer.innerHTML += modelRenderer(CTAs);
        return ctaContainer;
      }
    }

    return ctaContainer;
  }
}
