import { ThemeManager } from "../../../../controls/themes/ThemeManager";
import { IconList } from "./IconList";
import { i18n } from "../../../../i18n/i18n";
import { getIconCategories } from "../../../../utils/helpers";

export class IconListCategories {
  container: HTMLElement;
  selectionDiv: HTMLElement;
  categoryOptions: HTMLElement;
  selectedCategory: HTMLSpanElement;
  private themeManager: ThemeManager;
  categoryTitle: string;
  searchInput!: HTMLInputElement;
  // icons: string[];

  constructor(categoryTitle: string = "Technical Services & Support") {
    this.categoryTitle = categoryTitle;
    this.container = document.createElement("div") as HTMLElement;
    this.selectionDiv = document.createElement("div") as HTMLElement;
    this.categoryOptions = document.createElement("div") as HTMLElement;
    this.selectedCategory = document.createElement("span") as HTMLElement;
    this.themeManager = new ThemeManager();
    this.init();

    document.addEventListener("click", this.handleOutsideClick.bind(this));
  }

  init() {
    this.container.className = "sidebar-section services-section";
    this.container.id = "icon-categories-list";

    this.selectionDiv.className = "tb-custom-category-selection";
    this.selectionDiv.id = 'icon-category-select'
    this.renderIconSearch();

    const openSelection = document.createElement("button");
    openSelection.className = "category-select-button";
    openSelection.setAttribute("aria-haspopup", "listbox");
    openSelection.setAttribute("aria-expanded", "false");

    this.selectedCategory.className = "selected-category-value";
    this.selectedCategory.textContent = i18n.t("sidebar.icon_category.general");
    openSelection.appendChild(this.selectedCategory);

    openSelection.onclick = (e) => {
      e.preventDefault();
      const isOpen: boolean = openSelection.classList.contains("open");
      if (isOpen) {
        this.closeSelection();
        return;
      }

      this.categoryOptions.classList.toggle("show");
      openSelection.classList.toggle("open");
      openSelection.setAttribute("aria-expanded", "true");
    };

    this.selectionDiv.appendChild(openSelection);
    
    const searchToggleButton = document.createElement("button")
    searchToggleButton.className = 'icon-search-button'
    searchToggleButton.innerHTML = `<i class="fas fa-search search-icon"></i>`
    this.selectionDiv.append(searchToggleButton)

    searchToggleButton.addEventListener('click', (event:MouseEvent) => {
      event.preventDefault()
      this.showIconSearch()
    })

    this.container.appendChild(this.selectionDiv);
    this.showIconSelect()
    this.initializeCategoryOptions();
    this.loadThemeIcons(this.categoryTitle);

  }

  renderIconSearch() {
    const searchDiv = document.createElement("div");
    searchDiv.id = 'icon-search'
    searchDiv.innerHTML = `
      <i class="fas fa-search search-icon"></i>
    `;
    searchDiv.className = "icon-search-container tb-hide";
    this.searchInput = document.createElement("input");
    this.searchInput.type = "text";
    this.searchInput.placeholder = i18n.t("sidebar.icon_search_text");
    this.searchInput.className = "search-input";

    const closeSearchButton = document.createElement("button");
    closeSearchButton.className = "close-icon-search";
    closeSearchButton.innerHTML = `<i class="fas fa-times"></i>`;
    closeSearchButton.onclick = (e:any) => {
      e.preventDefault();
      // hide search div and clear input
      this.searchInput.value = "";
      this.loadThemeIcons(this.categoryTitle);
      this.showIconSelect()
    };

    searchDiv.appendChild(this.searchInput);
    searchDiv.appendChild(closeSearchButton);
    this.container.appendChild(searchDiv);
    this.searchInput.addEventListener("input", (e:any) => {
      const query = (e.target as HTMLInputElement).value;
      if (query) {
        this.loadThemeIcons(this.categoryTitle, query);
        return;
      }
    });
  }

  showIconSelect() {
    const searchDiv = document.getElementById('icon-search')
    const selectDiv = document.getElementById('icon-category-select')
    searchDiv?.classList.add('tb-hide')
    selectDiv?.classList.remove('tb-hide')
  }
  showIconSearch() {
    const searchDiv = document.getElementById('icon-search')
    const selectDiv = document.getElementById('icon-category-select')
    selectDiv?.classList.add('tb-hide')
    searchDiv?.classList.remove('tb-hide')
    this.searchInput.focus()
  }

  initializeCategoryOptions() {
    this.categoryOptions.className = "category-options-list";
    this.categoryOptions.setAttribute("role", "listbox");

    let categories: { name: string; label: string }[] = getIconCategories()
    
    categories.forEach((category) => {
      const categoryOption = document.createElement("div") as HTMLElement;
      categoryOption.className = "category-option";
      categoryOption.role = "option";
      categoryOption.setAttribute("data-value", category.name);
      categoryOption.textContent = category.label;

      categoryOption.onclick = () => {
        const allOptions =
          this.categoryOptions.querySelectorAll(".category-option");
        allOptions.forEach((opt) => opt.classList.remove("selected"));
        categoryOption.classList.add("selected");

        this.selectedCategory.textContent = category.label;

        this.loadThemeIcons(category.name);
        this.closeSelection();
      };

      this.categoryOptions.appendChild(categoryOption);
    });
    this.selectionDiv.appendChild(this.categoryOptions);
  }

  closeSelection() {
    const isOpen: boolean = this.categoryOptions.classList.contains("show");
    if (isOpen) {
      this.categoryOptions.classList.remove("show");

      const button = this.container.querySelector(
        ".category-select-button"
      ) as HTMLElement;
      button.setAttribute("aria-expanded", "false");
      button.classList.toggle("open");
    }
  }

  loadThemeIcons(iconsCategory: string, searchQuery: string = "") {
    document.querySelectorAll("#icons-list").forEach((el) => el.remove());
    const iconsList = document.createElement("div") as HTMLElement;
    iconsList.classList.add("icons-list");
    iconsList.id = "icons-list";

    const themeIcons = new IconList(this.themeManager, iconsCategory || this.categoryTitle, searchQuery);
    themeIcons.render(iconsList);

    this.container.appendChild(iconsList); 
  }

  private handleOutsideClick(event: MouseEvent) {
    if (
      this.categoryOptions.classList.contains("show") &&
      !this.container.contains(event.target as Node)
    ) {
      this.closeSelection();
    }
  }

  render(container: HTMLElement) {    
    const existingCategory = container.querySelector("#icon-categories-list");
    if (existingCategory) {
      existingCategory.replaceWith(this.container);
      return;
    }
    container.appendChild(this.container);
  }
}
