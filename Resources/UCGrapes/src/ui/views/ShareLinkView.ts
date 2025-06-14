import { ToolboxManager } from "../../controls/toolbox/ToolboxManager";
import { AppVersionController } from "../../controls/versions/AppVersionController";
import { i18n } from "../../i18n/i18n";
import { Modal } from "../components/Modal";

export class ShareLinkView {
    private appVersionController: AppVersionController;
    private toolboxManager: ToolboxManager;

    constructor() {
        this.appVersionController = new AppVersionController();
        this.toolboxManager = new ToolboxManager();
    }

    private createButton(id: string, className: string, text: string): HTMLButtonElement {
        const btn = document.createElement('button');
        btn.id = id;
        btn.classList.add('tb-btn', className);
        btn.innerText = text;
        return btn;
    }

    async openShareLinkModal() {
        try {
            const div = this.createModalContent();
            
            const modal = new Modal({
                title: i18n.t("navbar.share.modal_title"),
                width: "500px",
                body: div,
            });

            modal.open();

            this.setupModalEventListeners(div, modal);

        } catch (error) {
            console.error('Error opening share link modal:', error);
        }
    }

    private createModalContent(): HTMLDivElement {
        const div = document.createElement("div");
        const p = document.createElement("p");
        // p.innerText = i18n.t("hello");
        p.innerText = i18n.t("navbar.share.modal_description");
        
        const linkSection = this.createLinkSection();
        const submitSection = this.createSubmitSection(linkSection);

        div.appendChild(p);
        div.appendChild(linkSection);
        div.appendChild(submitSection);

        return div;
    }

    private createLinkSection(): HTMLDivElement {
        const linkSection = document.createElement("div");
        linkSection.classList.add("share-link-body");
        linkSection.style.display = "flex";
        linkSection.style.flexDirection = "column";
        linkSection.style.padding = "10px";

        const link = document.createElement("a");
        link.target = "_blank";
        link.style.overflowWrap = "break-word";
        link.style.maxWidth = "100%";

        // We'll populate the link asynchronously
        this.populateLinkAsync(link);

        linkSection.appendChild(link);
        return linkSection;
    }

    private async populateLinkAsync(linkElement: HTMLAnchorElement) {
        try {
            const shareLink = await this.appVersionController.generateShareLink();
            linkElement.href = shareLink;
            linkElement.innerText = shareLink;
        } catch (error) {
            linkElement.innerText = 'Failed to generate link';
            linkElement.href = '#';
        }
    }

    private createSubmitSection(linkSection: HTMLDivElement): HTMLDivElement {
        const submitSection = document.createElement("div");
        submitSection.classList.add("popup-footer");
        submitSection.style.marginBottom = "-12px";

        const copyBtn = this.createButton(
            "copy-link",
            "tb-btn-primary",
            i18n.t("navbar.share.copy")
        );
        const cancelBtn = this.createButton(
            "cancel",
            "tb-btn-outline",
            i18n.t("navbar.share.close")
        );

        submitSection.appendChild(copyBtn);
        submitSection.appendChild(cancelBtn);

        return submitSection;
    }

    private setupModalEventListeners(div: HTMLDivElement, modal: Modal) {
        const link = div.querySelector('a');
        const copyBtn = div.querySelector('#copy-link');
        const cancelBtn = div.querySelector('#cancel');

        if (copyBtn && link) {
            copyBtn.addEventListener("click", async (e) => {
                e.preventDefault();
                
                if (link.href) {
                    const copied = await this.appVersionController.copyToClipboard(link.href);

                    if (copied) {
                        setTimeout(() => {
                            modal.close();
                            this.toolboxManager.openToastMessage(i18n.t("navbar.share.copied"));
                          }, 500);
                    } else {
                        modal.close();
                        console.error("Failed to copy link");
                    }
                }

            });
        }

        if (cancelBtn) {
            cancelBtn.addEventListener("click", (e) => {
                e.preventDefault();
                modal.close();
            });
        }
    }
}