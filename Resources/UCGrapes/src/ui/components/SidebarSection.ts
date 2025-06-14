class SidebarSection {
    private sidebarSection: HTMLDivElement;

    constructor(content: HTMLDivElement) {
        this.sidebarSection = document.createElement("div");
        this.sidebarSection.classList.add("sidebar-section");
        this.sidebarSection.classList.add("theme-section");
        this.sidebarSection.style.paddingTop = "0";

        this.sidebarSection.appendChild(content);
    }

    
    render(container: HTMLElement) {
        container.appendChild(this.sidebarSection);
    }
}

// const content = document.createElement("div");
// content.innerHTML = `
//     <h2>Theme</h2>
//     <p>Hello world</p>
// `;
// const sidebarSection = new SidebarSection(content);
// sidebarSection.render(document.body);
