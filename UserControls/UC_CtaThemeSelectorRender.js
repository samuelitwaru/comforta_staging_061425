function UC_CtaThemeSelector($) {
	  
	  
	  
	  
	  
	  
	 this.setResultTheme = function(value) {
			this.ResultTheme = value;
		}

		this.getResultTheme = function() {
			return this.ResultTheme;
		} 

	var template = '<style>   .cta-color-picker {       width: 40px;       height: 40px;       border-radius: 2px;       border: none;       background-color: transparent;       appearance: none;       -webkit-appearance: none;       appearance: none;       -webkit-appearance: none;       box-sizing: border-box;       cursor: pointer;   }   .cta-color-picker:focus {       outline: none;       cursor: pointer;       background-color: transparent;       box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);   }</style><div class=\"color-container\">    <div class=\"color-selector\">        <input type=\"color\" class=\"cta-color-picker\" name=\"ctaColor1\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{ctaColor1}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{ctaColor1}}\" id=\"ctaColor1HexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"cta-color-picker\" name=\"ctaColor2\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{ctaColor2}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{ctaColor2}}\" id=\"ctaColor2HexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"cta-color-picker\" name=\"ctaColor3\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{ctaColor3}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{ctaColor3}}\" id=\"ctaColor3HexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"cta-color-picker\" name=\"ctaColor4\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{ctaColor4}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{ctaColor4}}\" id=\"ctaColor4HexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"cta-color-picker\" name=\"ctaColor5\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{ctaColor5}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{ctaColor5}}\" id=\"ctaColor5HexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"cta-color-picker\" name=\"ctaColor6\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{ctaColor6}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{ctaColor6}}\" id=\"ctaColor6HexValue\">    </div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

			    const UC = this;
			    const colorPickers = document.querySelectorAll('.cta-color-picker');
			    const colorData = {}; // Initialize an empty object to store color data.
			    const textInputs = document.querySelectorAll('[id$="HexValue"]'); // Select text inputs by ID ending

			    // Initialize CTA Theme with default values.
			    colorPickers.forEach(colorPicker => {
				   colorPicker.setAttribute('tabindex', '-1');
			        colorData[colorPicker.name] = colorPicker.value;
			    });

			    // Assign initial data to SDT
			    UC.ResultTheme.ctaColor1 = colorData.ctaColor1;
			    UC.ResultTheme.ctaColor2 = colorData.ctaColor2;
			    UC.ResultTheme.ctaColor3 = colorData.ctaColor3;
			    UC.ResultTheme.ctaColor4 = colorData.ctaColor4;
			    UC.ResultTheme.ctaColor5 = colorData.ctaColor5;
			    UC.ResultTheme.ctaColor6 = colorData.ctaColor6;

			    // Function to update colorData, SDT, and corresponding text input.
			    function updateColorData(name, value) {
			        colorData[name] = value;
			        UC.ResultTheme.ctaColor1 = colorData.ctaColor1;
			        UC.ResultTheme.ctaColor2 = colorData.ctaColor2;
			        UC.ResultTheme.ctaColor3 = colorData.ctaColor3;
			        UC.ResultTheme.ctaColor4 = colorData.ctaColor4;
				   UC.ResultTheme.ctaColor5 = colorData.ctaColor5;
			    	   UC.ResultTheme.ctaColor6 = colorData.ctaColor6;

			        // Update corresponding text input.
			        const textInput = document.getElementById(name + 'HexValue');
			        if (textInput) {
			            textInput.value = value;
			        }
			    }

			    // Function to update color picker and colorData from text input.
			    function updateColorFromText(name, value) {
			        const colorPicker = document.querySelector(`[name="${name}"]`);
			        if (colorPicker) {
			            colorPicker.value = value;
			            updateColorData(name, value);
			        }
			    }

			    // Add event listeners to update colorData from color pickers.
			    colorPickers.forEach(colorPicker => {
			        colorPicker.addEventListener('input', function () {
			            updateColorData(this.name, this.value);
			        });
			    });

			    // Add event listeners to update color pickers from text inputs.
			    textInputs.forEach(textInput => {
			        textInput.addEventListener('input', function () {
			            const name = this.id.replace('HexValue', '');
			            updateColorFromText(name, this.value);
			        });
			   
			   	   // select the color code on click
				   textInput.addEventListener('click', function(event) {
					   event.target.select();
				   });
			    });

		}



	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}