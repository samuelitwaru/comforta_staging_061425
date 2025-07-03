export class FormField {
  private formField: HTMLDivElement;
  private validateFn?: (value: string) => boolean;

  constructor(config: {
    label?: string;
    type: string;
    id: string;
    value?: string;
    placeholder?: string;
    required?: boolean;
    errorMessage?: string;
    validate?: (value: string) => boolean;
    minLength?: number;
    hidden?: boolean;
    options?: { value: string; label: string }[];
    information?: string;
  }) {
    this.validateFn = config.validate;
    this.formField = document.createElement("div");
    this.formField.className = "form-field";
    this.formField.style.marginBottom = "10px";

    if (config.hidden) {
      this.formField.style.display = "none"; // Hide the entire field (label + input + error)
    }

    // label
    const label = document.createElement("label");
    if (config.label) {
      label.htmlFor = config.id;
      label.textContent = config.label;
    }

    //information
    const info = document.createElement("span");
    info.className = "info";
    info.style.cssText = `
            color: #888;
            font-size: 15px;
            display: flex;
            margin-top: 5px;
        `;
    if (config.information) {
      const infoIcon = document.createElement("i");
      infoIcon.className = "fa fa-info-circle";
      infoIcon.title = config.information;
      infoIcon.style.marginLeft = "5px";
      infoIcon.style.marginRight = "5px";
      info.appendChild(infoIcon);

      const infoText = document.createElement("label");
      infoText.textContent = config.information;
      info.appendChild(infoText);
    }

    // Create input or select element based on type
    let input: HTMLInputElement | HTMLSelectElement;
    if (config.type === "select" && config.options) {
      // Create select element
      const select = document.createElement("select");
      select.id = config.id;
      select.className = "tb-form-control";
      if (config.required) {
        select.required = true;
      }
      // Add options
      config.options.forEach((opt) => {
        const option = document.createElement("option");
        option.value = opt.value;
        option.textContent = opt.label;
        if (config.value && config.value === opt.value) {
          option.selected = true;
        }
        select.appendChild(option);
      });
      input = select;
    } else {
      // Create input element
      const inp = document.createElement("input");
      inp.type = config.type;
      inp.id = config.id;
      inp.className = "tb-form-control";
      inp.value = config.value || "";
      if (config.placeholder) {
        inp.placeholder = config.placeholder;
      }
      if (config.required) {
        inp.required = true;
      }
      input = inp;
    }

    // error messahe span
    const errorSpan = document.createElement("span");
    errorSpan.className = "error-message";
    errorSpan.style.cssText = `
            color: red;
            font-size: 12px;
            display: none;
            margin-top: 5px;
            font-weight: 300;
        `;

    errorSpan.textContent = config.errorMessage || "Error message";

    if (config.label) {
      this.formField.appendChild(label);
    }
    this.formField.appendChild(input);
    this.formField.appendChild(errorSpan);
    if (config.information) {
      this.formField.appendChild(info);
    }
  }

  getElement(): HTMLDivElement {
    return this.formField;
  }

  showError(message: string) {
    const errorSpan = this.formField.querySelector(".error-message") as HTMLSpanElement;
    errorSpan.style.display = "block";
    if (message) {
      errorSpan.textContent = message;
    }
  }

  hideError() {
    const errorSpan = this.formField.querySelector(".error-message") as HTMLSpanElement;
    errorSpan.style.display = "none";
  }

  validate(): boolean {
    // Try to get input or select element
    const input = this.formField.querySelector("input") as HTMLInputElement | null;
    const select = this.formField.querySelector("select") as HTMLSelectElement | null;
    const value = input ? input.value : select ? select.value : "";

    if (this.validateFn) {
      // Custom validation handles error display
      return this.validateFn(value);
    } else if (input) {
      // Native validation for input
      const isValid = input.checkValidity();
      if (!isValid) {
        this.showError(input.validationMessage || "Invalid input");
      } else {
        this.hideError();
      }
      return isValid;
    } else if (select) {
      // Native validation for select
      const isValid = select.checkValidity();
      if (!isValid) {
        this.showError(select.validationMessage || "Invalid selection");
      } else {
        this.hideError();
      }
      return isValid;
    }
    return false;
  }
}
