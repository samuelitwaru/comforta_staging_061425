import { ChildEditor } from "../../../../controls/editor/ChildEditor";
import { InfoSectionManager } from "../../../../controls/InfoSectionManager";
import { AppVersionManager } from "../../../../controls/versions/AppVersionManager";
import { i18n } from "../../../../i18n/i18n";
import { baseURL, ToolBoxService } from "../../../../services/ToolBoxService";
import { CtaAttributes, InfoType } from "../../../../types";
import { randomIdGenerator } from "../../../../utils/helpers";
import { InfoSectionUI } from "../../../views/InfoSectionUI";
import { Alert } from "../../Alert";
import { ActionListDropDown } from "./ActionListDropDown";
import { ActionSelectContainer } from "./ActionSelectContainer";
import { FormModalService } from "./FormModalService";
import { PageAttacher } from "./PageAttacher";

type ActionType = "Email" | "Phone" | "WebLink" | "Map" | "Form";

export class PageCreationService {
  private appVersionManager: AppVersionManager;
  private toolBoxService: ToolBoxService;
  formModalService: FormModalService;
  private infoSectionUi: InfoSectionUI;
  private InfoSectionManager: InfoSectionManager;
  isInfoCtaSection: boolean;
  sectionId?: string;

  constructor(isInfoCtaSection = false, type?: ActionType, sectionId?: string) {
    this.isInfoCtaSection = isInfoCtaSection;
    this.sectionId = sectionId;
    this.appVersionManager = new AppVersionManager();
    this.toolBoxService = new ToolBoxService();
    this.formModalService = new FormModalService(isInfoCtaSection, type);
    this.infoSectionUi = new InfoSectionUI();
    this.InfoSectionManager = new InfoSectionManager();
  }

  handlePhone() {
    this.createFormAndModal("phone-form", i18n.t("cta_modal_forms.phone.modal_title"), "Phone", [
      {
        label: i18n.t("cta_modal_forms.phone.field_placeholder"),
        type: "tel",
        id: "field_value",
        placeholder: i18n.t("cta_modal_forms.phone.field_placeholder"),
        required: true,
        errorMessage: i18n.t("cta_modal_forms.field_error_message"),
        validate: (value: string) => this.formModalService.isValidPhone(value),
      },
      {
        label: i18n.t("cta_modal_forms.label"),
        type: "text",
        id: "field_label",
        placeholder: i18n.t("cta_modal_forms.phone.label_placeholder"),
        required: true,
        errorMessage: i18n.t("cta_modal_forms.label_error_message"),
        minLength: 2,
      },
    ]);
  }

  handleEmail() {
    this.createFormAndModal("email-form", i18n.t("cta_modal_forms.email.modal_title"), "Email", [
      {
        label: i18n.t("cta_modal_forms.email.field_label"),
        type: "email",
        id: "field_value",
        placeholder: i18n.t("cta_modal_forms.email.field_placeholder"),
        required: true,
        errorMessage: i18n.t("cta_modal_forms.field_error_message"),
        validate: (value: string) => this.formModalService.isValidEmail(value),
      },
      {
        label: i18n.t("cta_modal_forms.label"),
        type: "text",
        id: "field_label",
        placeholder: i18n.t("cta_modal_forms.email.label_placeholder"),
        required: true,
        errorMessage: i18n.t("cta_modal_forms.label_error_message"),
        minLength: 2,
      },
    ]);
  }

  handleForm() {
    this.createFormAndModal("form-form", i18n.t("cta_modal_forms.form.modal_title"), "Form", [
      {
        label: i18n.t("cta_modal_forms.form.field_placeholder"),
        type: "url",
        id: "field_value",
        placeholder: i18n.t("cta_modal_forms.form.field_placeholder"),
        required: true,
        hidden: true,
        errorMessage: i18n.t("cta_modal_forms.field_error_message"),
        validate: (value: string) => this.formModalService.isValidUrl(value),
      },
      {
        label: i18n.t("cta_modal_forms.form.field_placeholder"),
        type: "number",
        id: "field_id",
        required: false,
        hidden: true,
        errorMessage: i18n.t("cta_modal_forms.label_error_message"),
        validate: (value: string) => this.formModalService.isValidUrl(value),
      },
      {
        label: i18n.t("cta_modal_forms.label"),
        type: "text",
        id: "field_label",
        placeholder: i18n.t("cta_modal_forms.form.label_placeholder"),
        required: true,
        errorMessage: i18n.t("cta_modal_forms.label_error_message"),
        minLength: 5,
      },
    ]);
  }

  handleWebLinks() {    
    this.createFormAndModal(
      "web-link-form",
      i18n.t("cta_modal_forms.web_link.modal_title"),
      "WebLink",
      [
        {
          label: i18n.t("cta_modal_forms.web_link.field_placeholder"),
          type: "url",
          id: "field_value",
          placeholder: i18n.t("cta_modal_forms.web_link.field_placeholder"),
          required: true,
          errorMessage: i18n.t("cta_modal_forms.field_error_message"),
          validate: (value: string) => this.formModalService.isValidUrl(value),
        },
        {
          label: i18n.t("cta_modal_forms.label"),
          type: "text",
          id: "field_label",
          placeholder: i18n.t("cta_modal_forms.web_link.label_placeholder"),
          required: true,
          errorMessage: i18n.t("cta_modal_forms.label_error_message"),
          minLength: 5,
        },
      ]
    );
  }

  handleAddress() {
    this.createFormAndModal("address-form", i18n.t("cta_modal_forms.address.modal_title"), "Map", [
      {
        label: i18n.t("cta_modal_forms.address.field_label"),
        type: "text",
        id: "field_value",
        placeholder: i18n.t("cta_modal_forms.address.field_placeholder"),
        required: true,
        errorMessage: i18n.t("cta_modal_forms.field_error_message"),
        validate: (value: string) => this.formModalService.isValidAddress(value),
      },
      {
        label: i18n.t("cta_modal_forms.label"),
        type: "text",
        id: "field_label",
        placeholder: i18n.t("cta_modal_forms.address.label_placeholder"),
        required: true,
        errorMessage: i18n.t("cta_modal_forms.label_error_message"),
        minLength: 5,
      },
    ]);
  }

  private createFormAndModal(
    formId: string,
    title: string,
    type: string,
    fields: any[]
  ) {
    const form = this.formModalService.createForm(formId, fields);
    this.formModalService.createModal({
      title,
      form,
      onSave: () => this.processFormData(form.getData(), type),
    });
  }

  private async processFormData(
    formData: Record<string, string>,
    type: string
  ) {
    if (this.isInfoCtaSection) {
      this.addCtaButtonSection(type, formData);
      return;
    }
    const selectedComponent = (globalThis as any).selectedComponent;
    if (!selectedComponent) return;

    const tileTitle = selectedComponent.find(".tile-title")[0];
    if (tileTitle) tileTitle.components(formData.field_label);

    const tileId = selectedComponent.parent().getId();
    const rowId = selectedComponent.parent().parent().getId();

    // Find or create child page
    let childPage;
    if (type === "WebLink" || type === "Form") {
      childPage = await this.findOrCreateChildPage(type, formData);
    }

    const updates = [
      ["Text", formData.field_label],
      ["Name", formData.field_label],
      ["Action.ObjectType", type],
      ["Action.ObjectId", childPage?.PageId || randomIdGenerator(10)],
      ["Action.ObjectUrl", formData.field_value],
    ];

    const pageData = (globalThis as any).pageData;
    let tileAttributes;

    if (pageData.PageType === "Information") {
      for (const [property, value] of updates) {
        this.InfoSectionManager.updateInfoTileAttributes(
          rowId,
          tileId,
          property,
          value
        );
      }

      const tileInfoSectionAttributes: InfoType = (
        globalThis as any
      ).infoContentMapper.getInfoContent(rowId);
      tileAttributes = tileInfoSectionAttributes?.Tiles?.find(
        (tile: any) => tile.Id === tileId
      );
    } else {
      for (const [property, value] of updates) {
        (globalThis as any).tileMapper.updateTile(tileId, property, value);
      }
      tileAttributes = (globalThis as any).tileMapper.getTile(rowId, tileId);
    }
    
    new PageAttacher().removeOtherEditors();
    if (childPage) {
      new ChildEditor(childPage.PageId, childPage).init(tileAttributes);
    }
  }

  private async findOrCreateChildPage(
    type: string,
    formData: Record<string, string>
  ) {
    const version = (globalThis as any).activeVersion;
    let childPage = version?.Pages.find((page: any) => {
      if (type === "WebLink") {
        return (
          page.PageType === "WebLink" &&
          page.PageLinkStructure.Url === formData.field_value
        );
      }
      return false;
    });

    if (!childPage) {
      try {
        const appVersion = await this.appVersionManager.getActiveVersion();
        const formId = type === "Form" ? Number(formData?.field_id) : 0;
        const response = await this.toolBoxService.createLinkPage(
          appVersion.AppVersionId,
          formData.field_label,
          formData.field_value,
          formId,
          ''
        );
        childPage = response.MenuPage;
      } catch (error) {
        console.error("Error creating link page:", error);
        return null;
      }
    }

    return childPage;
  }

  async addCtaButtonSection(type: string = "Phone", formData: any = {}) {
    const iconMap: Record<string, string> = {
      Phone: "Phone",
      Email: "Email",
      WebLink: "Link",
      Map: "Globe",
      Form: "Document",
      Address: "Globe",
    };

    const icon = iconMap[type] || "Info";

    const cta: CtaAttributes = {
      CtaId: randomIdGenerator(15),
      CtaType: type,
      CtaLabel: formData.field_label || "Call Us",
      CtaAction: formData.field_value,
      CtaColor: "#ffffff",
      CtaBGColor: "ctaColor1",
      CtaButtonType: "Image",
      CtaButtonImgUrl: "/Resources/UCGrapes/public/images/image.png",
      CtaButtonIcon: icon,
      CtaSupplierIsConnected: Boolean(formData.supplier_id),
      CtaConnectedSupplierId: formData.supplier_id || null,
      Action: {
        ObjectId: type === "Form" ? formData?.field_id : randomIdGenerator(2),
        ObjectType: type === "Form" ? "DynamicForm" : type,
        ObjectUrl: formData.field_value,
      },
    };

    let childPage;
    // if (type === "WebLink" || type === "Form") {
    //   childPage = await this.findOrCreateChildPage(type, formData);
    //   if (childPage) {
    //     new ChildEditor(childPage.PageId, childPage).init({});
    //   }
    // }
    const button = this.infoSectionUi.addCtaButton(cta);
    this.InfoSectionManager.addCtaButton(button, cta, this.sectionId);
  }
}
