import { I18n } from "i18n-js";

export const i18nModule = new I18n({
  en: {
    Messages: "Messages",
    Requests: "Requests",
    NoMessagesYet: "No Messages Yet",
  },
  nl: {
    Messages: "Berichten",
    Requests: "Verzoeken",
    NoMessagesYet: "Nog geen berichten",
  },
});

export const i18n = new I18n({
  en: {
    navbar: {
      tree: "Tree",
      publish: {
        label: "Publish",
        modal_title: "Publish",
        modal_description:
          "Are you sure you want to publish? Once published, all currently visible pages will be finalized and visible to residents. This action cannot be undone.",
        notify_residents: "Notify residents about the updates made",
        modal_confirm: "Publish",
        modal_cancel: "Cancel",
        sidebar_mapping_title: "Mapping",
        current_version: "Current published version: ",
        new_version: "Version being published: ",
      },
      debug: {
        label: "Debug",
        modal_title: "App Debugging",
        total_urls: "Total URLs",
        total_successful: "Successful",
        total_failed: "Failed",
        full_url: "Full URL",
        status_code: "Status Code",
        status_message: "Status Message",
        affected_tile: "Affected Tile",
        affected_content: "Affected Content",
        affected_cta: "Affected CTA",
      },
      share: {
        label: "Share",
        modal_title: "Share link for a preview",
        modal_description:
          "A shareable link has been generated for you. Copy it and share for previews!",
        copy: "Copy",
        close: "Close",
        copied: "Linked copied to clipboard",
      },
      trash: {
        label: "Trash",
        modal_title: "Trash",
        modal_description:
          "A shareable link has been generated for you. Copy it and share for previews!",
        copy: "Copy",
        close: "Close",
        copied: "Linked copied to clipboard",
      },
      appversion: {
        select_version: "Select version",
        create_new: "Create new version",
        duplicate_title: "Duplicate version",
        rename_version: "Rename version",
        delete_version: "Delete version",
        delete_version_message: "Are you sure you want to delete this version?",
        dropdow: {
          duplicate: "Duplicate",
          rename: "Rename",
          move_to_trash: "Move to trash",
        },
        field_placeholder: "Enter version name",
        save: "Save",
        cancel: "Cancel",
        delete: "Delete",
        duplicate: "Duplicate",
        rename: "Rename",
        move_to_trash: "Move to trash",
      },
      copy_selection_label: "Copy Page Selection",
    },
    undo: "Undo",
    redo: "Redo",
    translate: "Translate",
    sidebar: {
      pages: "Pages",
      linked_pages: "Linked Pages",
      templates: {
        label: "Templates",
        click_to_add_template: "Click to add template",
        confirmation_title: "Confirmation",
        confirmation_message: "When you continue, all the changes you have made will be cleared.",
      },
      confirmation_accept: "Confirm",
      confirmation_cancel: "Cancel",
      image_upload: {
        modal_title: "Edit Content",
        cancel: "Cancel",
        save: "Save",
        upload_message: "<p>Drag and drop or <a href='#' id='browseLink'>browse</a></p>",
        upload_success_message: "The images have been published successfully.",
        no_images_added: "No images added",
        preparing_images: "Preparing images...",
        uploading_images: "Uploading images...",
        select_images: "Select images",
        select_image: "Select images",
        deselect_all: "Deselect all",
        delete_image_title: "Delete image",
        delete_image_modal_title: "Delete media",
        delete_image_message: "Are you sure you want to delete this image?",
        delete_images_message: "Are you sure you want to delete selected images?",
      },
      icon_category: {
        general: "Technical Services & Support",
        real_estate_rental: "Real Estate & Rental",
        community_connection: "Community & Connection",
        building_furnishing: "Building & Furnishing",
        services_hospitality: "Services & Hospitality",
        mobility_transport: "Mobility & Transport",
        care_wellbeing: "Care & Wellbeing",
        communication_media: "Communication & Media",
      },
      action_list: {
        page: "Pages",
        services: "Services",
        forms: "Forms",
        weblink: "Web link",
        module: "Modules",
        content: "Content",
        call_to_action: "Call to Action",
        dropdown: {
          address: "Address",
          phone: "Phone",
          email: "Email",
          form: "Form",
          weblink: "Web link",
        },
        tile: "Tile",
        image: "Image",
        description: "Description",
        paste_tile: "Paste Tile",
        paste_selection: "Paste Selection",
      },
      input_place_holder: "Enter title",
    },
    default: {
      reception: "Reception",
      mycare: "My Care",
      myliving: "My Living",
      myservice: "My Service",
      location: "Location",
      map: "Map",
      myactivity: "My Activity",
      calendar: "Calendar",
    },
    tile: {
      add_template_right: "Add tile right",
      add_template_bottom: "Add tile below",
      delete_tile: "Delete tile",
      title: "Title",
      add_menu_page: "Add menu page",
      add_content_page: "Add content page",
      information_page: "New Page",
      existing_pages: "Existing Pages",
      call_to_action: "Direct Link",
      forms: "Forms",
      modules: "Modules",
      email: "Email",
      phone: "Phone",
      maps: "Maps",
      calendar: "Calendar",
      services: "Services",
      edit_content: "Edit Content",
      save_button: "Save",
      cancel_button: "Cancel",
      copy_tile: "Copy Tile",
    },
    messages: {
      success: {
        published: "App published successfully",
        page_created: "Page created successfully",
        sections_copy_success: "Selected sections copied successfully.",
        sections_cut_success: "Selected sections cut successfully.",
      },
      error: {
        page_linking: "Page cannot be linked to itself",
        select_tile: "Select a tile to continue",
        empty_page_name: "Enter page name",
        templates_on_menu_pages: "Templates can only be added to menu pages",
        no_active_page: "No active page",
        empty_version_name: "Version name is required.",
        existing_version_name: "A version with this name already exists.",
        long_version_name: "Version name cannot exceed 50 characters.",
        sections_copy_error: "No valid selected sections to copy. Try again.",
        sections_cut_error: "No valid selected sections to cut. Try again.",
        select_language: "Please select a language.",
      },
    },
    Messages: "Messages",
    Requests: "Requests",
    NoMessagesYet: "No Messages Yet",

    section: {
      delete: "Delete",
      edit: "Edit",
      remove_section: "Remove section",
      remove_message: "Are you sure you want to remove this section?",
      description_modal: {
        title: "Description",
        placeholder: "Start typing here...",
      },
    },

    cta_modal_forms: {
      save: "Save",
      cancel: "Cancel",
      connect_supplier: "Connect supplier(optional)",
      label: "Label",
      field_error_message: "This field is required",
      label_error_message: "Please enter a valid label",
      email: {
        modal_title: "Add Email Address",
        field_label: "Email Address",
        field_placeholder: "Enter Email Address",
        label_placeholder: "Get in touch",
      },
      phone: {
        modal_title: "Add Phone Number",
        field_label: "Phone Number",
        field_placeholder: "Enter Phone Number",
        label_placeholder: "Call us now",
      },
      web_link: {
        modal_title: "Add Web Link",
        field_label: "Link URL",
        field_placeholder: "Enter Web Link",
        label_placeholder: "Visit our website",
      },
      form: {
        modal_title: "Add Form",
        field_label: "Form",
        field_placeholder: "Enter Form",
        label_placeholder: "Get in touch",
      },
      address: {
        modal_title: "Add Address",
        field_label: "Address",
        field_placeholder: "Enter Address",
        label_placeholder: "Visit us",
      },
    },
  },

  nl: {
    navbar: {
      tree: "Boom",
      publish: {
        label: "Publiceren",
        modal_title: "Publiceren",
        modal_description:
          "Weet je zeker dat je wilt publiceren? Zodra gepubliceerd, worden alle momenteel zichtbare pagina's afgerond en zichtbaar voor bewoners. Deze actie kan niet ongedaan worden gemaakt.",
        notify_residents: "Bewoners op de hoogte stellen van de gemaakte updates",
        modal_confirm: "Publiceren",
        modal_cancel: "Annuleren",
        sidebar_mapping_title: "Indeling",
        current_version: "Huidige gepubliceerde versie: ",
        new_version: "Versie wordt gepubliceerd: ",
      },
      debug: {
        label: "Debug",
        modal_title: "App Debugging",
        total_urls: "Totaal aantal URL's",
        total_successful: "Succesvol",
        total_failed: "Mislukt",
        full_url: "Volledige URL",
        status_code: "Statuscode",
        status_message: "Statusbericht",
        affected_tile: "Beïnvloede tegel",
        affected_content: "Beïnvloede inhoud",
        affected_cta: "Beïnvloede CTA",
      },
      share: {
        label: "Delen",
        modal_title: "Deel link voor een voorbeeldweergave",
        modal_description:
          "Er is een deelbare link gegenereerd voor jou. Kopieer deze en deel hem voor previews!",
        copy: "Kopiëren",
        close: "Sluiten",
        copied: "Link gekopieerd naar klembord",
      },
      appversion: {
        select_version: "Selecteer versie",
        create_new: "Nieuwe versie maken",
        duplicate_title: "Versie dupliceren",
        rename_version: "Versie hernoemen",
        delete_version: "Versie verwijderen",
        delete_version_message: "Weet je zeker dat je deze versie wilt verwijderen?",
        dropdow: {
          duplicate: "Dupliceren",
          rename: "Hernoemen",
          move_to_trash: "Verplaats naar prullenbak",
        },
        field_placeholder: "Voer versienaam in",
        save: "Opslaan",
        cancel: "Annuleren",
        delete: "Verwijderen",
        duplicate: "Dupliceren",
        rename: "Hernoemen",
        move_to_trash: "Naar prullenbak verplaatsen",
      },
      copy_selection_label: "Pagina selectie kopiëren",
    },
    undo: "Ongedaan maken",
    redo: "Opnieuw",
    translate: "Vertalen",
    sidebar: {
      pages: "Pagina's",
      linked_pages: "Gekoppelde pagina's",
      templates: {
        label: "Sjablonen",
        click_to_add_template: "Klik om een sjabloon toe te voegen",
        confirmation_title: "Bevestiging",
        confirmation_message:
          "Als je doorgaat, worden alle wijzigingen die je hebt gemaakt gewist.",
      },
      confirmation_accept: "Bevestigen",
      confirmation_cancel: "Annuleren",
      image_upload: {
        modal_title: "Inhoud bewerken",
        cancel: "Annuleren",
        save: "Opslaan",
        upload_message: "<p>Sleep en plaats of <a href='#' id='browseLink'>blader</a></p>",
        upload_success_message: "De afbeeldingen zijn succesvol gepubliceerd.",
        no_images_added: "Geen afbeeldingen toegevoegd",
        preparing_images: "Afbeeldingen voorbereiden...",
        uploading_images: "Afbeeldingen uploaden...",
        select_images: "Afbeeldingen selecteren",
        select_image: "Selecteer afbeelding",
        deselect_all: "Alles deselecteren",
        delete_image_title: "Afbeelding verwijderen",
        delete_image_modal_title: "Media verwijderen",
        delete_image_message: "Weet je zeker dat je deze afbeelding wilt verwijderen?",
        delete_images_message:
          "Weet je zeker dat je de geselecteerde afbeeldingen wilt verwijderen?",
      },
      icon_category: {
        general: "Technische diensten en ondersteuning",
        real_estate_rental: "Onroerend goed en verhuur",
        community_connection: "Gemeenschap & Verbinding",
        building_furnishing: "Bouw & Inrichting",
        services_hospitality: "Diensten en gastvrijheid",
        mobility_transport: "Mobiliteit & Transport",
        care_wellbeing: "Zorg & Welzijn",
        communication_media: "Communicatie & Media",
      },
      action_list: {
        page: "Pagina's",
        services: "Diensten",
        forms: "Formulieren",
        weblink: "Weblink",
        module: "Modules",
        content: "Inhoud",
        call_to_action: "Oproep tot actie ",
        dropdown: {
          address: "Adres",
          phone: "Telefoon",
          email: "E-mail",
          form: "Formulier",
          weblink: "Weblink",
        },
        tile: "Tegel",
        image: "Afbeelding",
        description: "Beschrijving",
        paste_tile: "Tegel plakken",
        paste_selection: "Selectie plakken",
      },
      input_place_holder: "Voer titel in",
    },
    default: {
      reception: "Receptie",
      mycare: "Mijn Zorg",
      myliving: "Mijn Wonen",
      myservice: "Mijn Dienst",
      location: "Locatie",
      map: "Kaart",
      myactivity: "Mijn Activiteit",
      calendar: "Kalender",
    },
    tile: {
      add_template_right: "Tegel rechts toevoegen",
      add_template_bottom: "Tegel hieronder toevoegen",
      delete_tile: "Tegel verwijderen",
      title: "Titel",
      add_menu_page: "Menu­pagina toevoegen",
      add_content_page: "Inhouds­pagina toevoegen",
      forms: "Formulieren",
      modules: "Modules",
      existing_pages: "Bestaande pagina's",
      call_to_action: "Directe link",
      email: "E-mail",
      phone: "Telefoon",
      maps: "Kaarten",
      calendar: "Kalender",
      services: "Diensten",
      information_page: "Nieuwe Pagina",
      edit_content: "Inhoud Bewerken",
      save_button: "Bevestig",
      cancel_button: "Annuleer",
      copy_tile: "Kopieer tegel",
    },
    messages: {
      success: {
        published: "App succesvol gepubliceerd",
        page_created: "Pagina succesvol aangemaakt",
        sections_copy_success: "Geselecteerde secties succesvol gekopieerd.",
        sections_cut_success: "Geselecteerde secties succesvol geknipt.",
      },
      error: {
        page_linking: "Pagina kan niet aan zichzelf worden gekoppeld",
        select_tile: "Selecteer een tegel om door te gaan",
        empty_page_name: "Voer een paginanaam in",
        templates_on_menu_pages: "Sjablonen kunnen alleen aan menupagina's worden toegevoegd",
        no_active_page: "Geen actieve pagina",
        empty_version_name: "Versienaam is verplicht.",
        existing_version_name: "Er bestaat al een versie met deze naam.",
        long_version_name: "Versienaam mag niet langer zijn dan 50 tekens.",
        sections_copy_error:
          "Geen geldige geselecteerde secties om te kopiëren. Probeer het opnieuw.",
        sections_cut_error:
          "Geen geldige geselecteerde secties om te knippen. Probeer het opnieuw.",
      },
    },
    Messages: "Berichten",
    Requests: "Verzoeken",
    NoMessagesYet: "Nog geen berichten",

    section: {
      delete: "Verwijderen",
      edit: "Bewerken",
      remove_section: "Sectie verwijderen",
      remove_message: "Weet je zeker dat je deze sectie wilt verwijderen?",
      description_modal: {
        title: "Beschrijving",
        placeholder: "Begin hier met typen...",
      },
    },

    cta_modal_forms: {
      save: "Opslaan",
      cancel: "Annuleren",
      connect_supplier: "Leverancier koppelen (optioneel)",
      label: "Label",
      field_error_message: "Dit veld is verplicht",
      label_error_message: "Voer een geldig label in",
      email: {
        modal_title: "E-mailadres toevoegen",
        field_label: "E-mailadres",
        field_placeholder: "Voer e-mailadres in",
        label_placeholder: "Neem contact op",
      },
      phone: {
        modal_title: "Telefoonnummer toevoegen",
        field_label: "Telefoonnummer",
        field_placeholder: "Voer telefoonnummer in",
        label_placeholder: "Bel ons nu",
      },
      web_link: {
        modal_title: "Weblink toevoegen",
        field_label: "Link URL",
        field_placeholder: "Voer weblink in",
        label_placeholder: "Bezoek onze website",
      },
      form: {
        modal_title: "Formulier toevoegen",
        field_label: "Formulier",
        field_placeholder: "Voer formulier in",
        label_placeholder: "Neem contact op",
      },
      address: {
        modal_title: "Adres toevoegen",
        field_label: "Adres",
        field_placeholder: "Voer adres in",
        label_placeholder: "Bezoek ons",
      },
    },
  },
});
