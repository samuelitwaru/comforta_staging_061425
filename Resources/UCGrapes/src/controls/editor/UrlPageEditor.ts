import { fontWeight } from "html2canvas/dist/types/css/property-descriptors/font-weight";

export class UrlPageEditor {
    editor: any;
    constructor(editor: any) {
        this.editor = editor;
    }

    async initialise(linkUrl: any) {
        try {
            this.editor.DomComponents.clear();
    
          // Define custom 'object' component
          this.editor.DomComponents.addType("object", {
            isComponent: (el: any) => el.tagName === "OBJECT",
    
            model: {
              defaults: {
                tagName: "object",
                draggable: true,
                droppable: false,
                attributes: {
                  width: "100%",
                  height: "300vh",
                },
                styles: `
                  .form-frame-container {
                    overflow-x: hidden;
                    overflow-y: auto;
                    position: relative;
                    min-height: 300px;
                  }
      
                  /* Preloader styles */
                  .preloader-wrapper {
                    position: absolute;
                    top: 50%;
                    left: 50%;
                    transform: translate(-50%, -50%);
                    z-index: 1000;
                  }
      
                  .preloader {
                    width: 32px;
                    height: 32px;
                    background-image: url('/Resources/UCGrapes/public/images/spinner.gif');
                    background-size: contain;
                    background-repeat: no-repeat;
                  }
      
                  /* Custom scrollbar styles */
                  .form-frame-container::-webkit-scrollbar {
                    width: 6px;
                    height: 0;
                  }
      
                  .form-frame-container::-webkit-scrollbar-track {
                    background: #f1f1f1;
                    border-radius: 3px;
                  }
      
                  .form-frame-container::-webkit-scrollbar-thumb {
                    background: #888;
                    border-radius: 3px;
                  }
      
                  .form-frame-container::-webkit-scrollbar-thumb:hover {
                    background: #555;
                  }
      
                  /* Firefox scrollbar styles */
                  .form-frame-container {
                    scrollbar-width: thin;
                    scrollbar-color: #888 #f1f1f1;
                  }
                  .fallback-message {
                    margin-bottom: 10px;
                    color: #666;
                  }
                `,
              },
            },
    
            view: {
              onRender({ el, model }: any) {
                const fallbackMessage =
                  model.get("attributes").fallbackMessage ||
                  "Content cannot be displayed";
    
                const fallbackContent = `
                  <div class="fallback-content">
                    <p class="fallback-message">${fallbackMessage}</p>
                    <a href="${model.get("attributes").data}" 
                       target="_blank" 
                       class="fallback-link">
                      Open in New Window
                    </a>
                  </div>
                `;
    
                el.insertAdjacentHTML("beforeend", fallbackContent);
    
                el.addEventListener("load", () => {
                  // Hide preloader and fallback on successful load
                  const container = el.closest(".form-frame-container");
                  const preloaderWrapper =
                    container.querySelector(".preloader-wrapper");
                  if (preloaderWrapper) preloaderWrapper.style.display = "none";
    
                  const fallback = el.querySelector(".fallback-content");
                  if (fallback) {
                  }
                  fallback.style.display = "none";

                  const dynamicFormContent = el.contentDocument;
                  window.DynamicForm = dynamicFormContent;
                  
                  const submitButtons = dynamicFormContent.querySelectorAll(".MobileSubmitBtn");
                  window.DynamicFormSubmitButtons = submitButtons;
                  submitButtons.forEach((button:HTMLInputElement) => {
                    button.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                    button.style.border = '0px';
                  });

                  const fileInputbuttons = dynamicFormContent.querySelectorAll(".fileinput-button");
                  window.DynamicFormFileInputButtons = fileInputbuttons;
                  fileInputbuttons.forEach((span: HTMLSpanElement) => {
                    span.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                    span.style.fontWeight = 'normal';
                    span.style.fontSize = '14px';
                    span.style.fontStyle = 'normal';
                    span.style.border = '0px';
                    span.style.borderRadius = '4px';
                  });

                  const stepNumberBulletSelecteds = dynamicFormContent.querySelectorAll(".TableStepBulletSelected");
                  window.DynamicFormstepNumberBulletSelecteds = stepNumberBulletSelecteds;
                  stepNumberBulletSelecteds.forEach((span: HTMLDivElement) => {
                    span.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                  });

                  const tableStepBulletCheckeds = dynamicFormContent.querySelectorAll(".TableStepBulletChecked");
                  window.DynamicFormtableStepBulletCheckeds = tableStepBulletCheckeds;
                  tableStepBulletCheckeds.forEach((span: HTMLDivElement) => {
                    span.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                  });

                  let nextButtons = dynamicFormContent.querySelectorAll(".NxtWzdBtn");
                  window.DynamicFormWizardNext = nextButtons;
                  let prevButtons = dynamicFormContent.querySelectorAll(".PrevWzdBtn");
                  window.DynamicFormWizardPrevious = prevButtons;

                  const cellWizardActions = dynamicFormContent.querySelectorAll(".CellWizardActions");
                  cellWizardActions.forEach((cell: HTMLDivElement) => {
                    const observer = new MutationObserver((mutations) => {
                      mutations.forEach((mutation) => {
                        // Handle different types of mutations
                        if (mutation.type === 'attributes') {
                          console.log('Actions Attribute changed:', mutation.attributeName);
                          // Add your attribute change handling logic here
                        } else if (mutation.type === 'childList') {
                          console.log('Actions Child elements changed');
                          // Add your child list change handling logic here
                        } else if (mutation.type === 'characterData') {
                          console.log('Actions Text content changed');
                          // Add your text content change handling logic here
                        }

                        let nextButtons = dynamicFormContent.querySelectorAll(".NxtWzdBtn");
                        window.DynamicFormWizardNext = nextButtons;
                        nextButtons.forEach((button:HTMLButtonElement) => {
                          button.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                          button.style.border = '0px';
                        });

                        let prevButtons = dynamicFormContent.querySelectorAll(".PrevWzdBtn");
                        window.DynamicFormWizardPrevious = prevButtons;
                        prevButtons.forEach((button:HTMLButtonElement) => {
                          button.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                          button.style.border = '0px';
                        });
                      });
                    });
                    // Configure the observer
                    const config = {
                      attributes: true,      // Watch for attribute changes
                      childList: true,      // Watch for changes to child elements
                      characterData: true,  // Watch for changes to text content
                      subtree: true         // Watch all descendants, not just direct children
                    };

                    // Start observing
                    observer.observe(cell, config);
                  });

                  const wizardStepsCell = dynamicFormContent.querySelectorAll(".WizardStepsCell");
                  // Add MutationObserver to monitor changes to wizardStepCell elements
                  wizardStepsCell.forEach((cell: HTMLDivElement) => {
                    const observer = new MutationObserver((mutations) => {
                      mutations.forEach((mutation) => {
                        // Handle different types of mutations
                        if (mutation.type === 'attributes') {
                          console.log('Steps Attribute changed:', mutation.attributeName);
                          // Add your attribute change handling logic here
                        } else if (mutation.type === 'childList') {
                          console.log('Steps Child elements changed');
                          // Add your child list change handling logic here
                        } else if (mutation.type === 'characterData') {
                          console.log('Steps Text content changed');
                          // Add your text content change handling logic here
                        }

                        // Update styles for any new or modified elements
                        const stepNumberBulletSelecteds = dynamicFormContent.querySelectorAll(".TableStepBulletSelected");
                        window.DynamicFormstepNumberBulletSelecteds = stepNumberBulletSelecteds;
                        stepNumberBulletSelecteds.forEach((span: HTMLDivElement) => {
                          span.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                        });

                        const tableStepBulletCheckeds = dynamicFormContent.querySelectorAll(".TableStepBulletChecked");
                        window.DynamicFormtableStepBulletCheckeds = tableStepBulletCheckeds;
                        tableStepBulletCheckeds.forEach((span: HTMLDivElement) => {
                          span.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                        });

                        const fileInputbuttons = dynamicFormContent.querySelectorAll(".fileinput-button");
                        window.DynamicFormFileInputButtons = fileInputbuttons;
                        fileInputbuttons.forEach((span: HTMLSpanElement) => {
                          span.style.backgroundColor = window.DynamicFormSubmitButtonColor;
                          span.style.fontWeight = 'normal';
                          span.style.fontSize = '14px';
                          span.style.fontStyle = 'normal';
                          span.style.border = '0px';
                          span.style.borderRadius = '4px';
                        });
                      });
                    });

                    // Configure the observer
                    const config = {
                      attributes: true,      // Watch for attribute changes
                      childList: true,      // Watch for changes to child elements
                      characterData: true,  // Watch for changes to text content
                      subtree: true         // Watch all descendants, not just direct children
                    };

                    // Start observing
                    observer.observe(cell, config);
                  });

                });
    
                el.addEventListener("error", (e: any) => {
                  // Hide preloader and show fallback on error
                  const container = el.closest(".form-frame-container");
                  const preloaderWrapper =
                    container.querySelector(".preloader-wrapper");
                  if (preloaderWrapper) preloaderWrapper.style.display = "none";
    
                  const fallback = el.querySelector(".fallback-content");
                  if (fallback) {
                    fallback.style.display = "flex";
                    fallback.style.flexDirection = "column";
                    fallback.style.justifyContent = "start";
                  }
                });
              },
            },
          });
    
          // Add the component to the editor with preloader in a wrapper
          this.editor.setComponents(`
            <div class="form-frame-container" id="frame-container">
              <div class="preloader-wrapper">
                <div class="preloader"></div>
              </div>
              <object 
                data="${linkUrl}"
                type="text/html"
                width="100%"
                height="800px"
                fallbackMessage="Unable to load the content. Please try opening it in a new window.">
              </object>
            </div>
          `);
        } catch (error: any) {
          console.error("Error setting up object component:", error.message);
        }
      }

}