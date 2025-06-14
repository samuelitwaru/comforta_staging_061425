import { Tile } from "../interfaces/Tile";

export class MapPageMapper {
  tile: Tile;
  
  constructor(tile: Tile) {
    this.tile = tile;
  }
  
  renderContent(container: HTMLElement): void {
    const columnElement = document.createElement("div");
    columnElement.className = "tbap-weblink-column";

    const mapContainer = document.createElement("div");
    mapContainer.style.position = "relative";
    mapContainer.style.width = "100%";
    mapContainer.style.height = "100vh";
    mapContainer.style.overflow = "hidden";

    const preloader = document.createElement("div");
    preloader.id = "map-preloader";
    preloader.style.position = "absolute";
    preloader.style.top = "0";
    preloader.style.left = "0";
    preloader.style.width = "100%";
    preloader.style.height = "100%";
    preloader.style.display = "flex";
    preloader.style.justifyContent = "center";
    preloader.style.alignItems = "center";
    preloader.style.zIndex = "1000";

    const spinner = document.createElement("img");
    spinner.src = "/Resources/UCGrapes1/src/images/spinner.gif";
    spinner.alt = "Loading map...";
    spinner.style.width = "32px";
    spinner.style.height = "32px";

    preloader.appendChild(spinner);
    mapContainer.appendChild(preloader);

    const iframe = document.createElement("iframe");
    iframe.id = "map-frame";
    iframe.style.width = "100%";
    iframe.style.height = "100%";
    iframe.style.border = "none";
    iframe.style.visibility = "hidden"; 
    iframe.allowFullscreen = true;
    iframe.loading = "lazy";

    mapContainer.appendChild(iframe);
    container.appendChild(mapContainer);

    setTimeout(() => {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                const lat = position.coords.latitude;
                const lng = position.coords.longitude;
                iframe.src = `https://www.google.com/maps/embed/v1/view?key=AIzaSyBBaQo7_sF2xk3uNIyKp_Z-4BbaTebGGa4&center=${lat},${lng}&zoom=18`;
            },
            (error) => {
                console.error("Geolocation error:", error);
                iframe.src = `https://www.google.com/maps/embed/v1/view?key=AIzaSyBBaQo7_sF2xk3uNIyKp_Z-4BbaTebGGa4&center=0,0&zoom=2`;
            }
        );

        iframe.addEventListener("load", () => {
            preloader.style.display = "none";
            iframe.style.visibility = "visible";
        });

        setTimeout(() => {
            preloader.style.display = "none";
            iframe.style.visibility = "visible";
        }, 7000);
    }, 500); 
}

}