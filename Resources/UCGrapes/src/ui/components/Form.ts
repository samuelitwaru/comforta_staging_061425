import { FormField } from "./FormField";

export class Form {
    private form: HTMLFormElement;
    private fields: FormField[];
    private selectedSupplierId: string | null = null;

    constructor(id: string) {
        this.form = document.createElement('form');
        this.form.id = id;
        this.fields = [];
    }

    addField(config: ConstructorParameters<typeof FormField>[0]) {
        const field = new FormField(config);
        this.fields.push(field);
        this.form.appendChild(field.getElement());
        return field;
    }

    render(container: HTMLElement) {
        container.appendChild(this.form);
    }

    setSelectedSupplierId(id: string | null) {
        this.selectedSupplierId = id;
    }
    getSelectedSupplierId(): string | null {
        return this.selectedSupplierId;
    }

    getData(): Record<string, string> {
        const data: Record<string, string> = {};
        this.fields.forEach(field => {
            const input = field.getElement().querySelector('input') as HTMLInputElement;
            data[input.id] = input.value;
        });

        // Add supplier ID if one was selected
        if (this.selectedSupplierId) {
            data['supplier_id'] = this.selectedSupplierId;
        }

        return data;
    }
}

// function createPageForm() {
//     const form = new Form('page-form');

//     // Add page title field
// form.addField({
//     label: 'Page Title',
//     type: 'text',
//     id: 'page_title',
//     placeholder: 'New page title',
//     required: true
// });

//     // Add description field
//     form.addField({
//         label: 'Description',
//         type: 'text',
//         id: 'page_description',
//         placeholder: 'Page description'
//     });

//     // Render form
//     form.render(document.body);

//     return form;
// }

// // Create the form
// const pageForm = createPageForm();