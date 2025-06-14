function UC_ThemeSelector($) {
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	 this.setSelectedTheme = function(value) {
			this.SelectedTheme = value;
		}

		this.getSelectedTheme = function() {
			return this.SelectedTheme;
		} 

	var template = '<style>   	.theme-color-picker {		width: 35px;		height: 35px;		border-radius: 2px;		border: none;		background-color: transparent;		appearance: none;		-webkit-appearance: none;		appearance: none;		-webkit-appearance: none;		box-sizing: border-box;		cursor: pointer;   	}   	.theme-color-picker:focus {		outline: none;		cursor: pointer;		background-color: transparent;		box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);   	}      	.color-container {	    	width: fit-content;		border: solid 2px #e8e8e8;		border-radius: 8px;		margin-top: 5px;		padding: 3px 6px;   	}		.color-selector {        display: flex;        align-items: center; /* Center items vertically */        justify-content: space-between; /* Space items horizontally */        margin: 2px 0; /* Add a little vertical margin */    }        .color-selector input[type=\"text\"] {        	font-family: inherit;		font-size: inherit;		line-height: inherit;		border: solid 2px #e8e8e8;		width: 100px;    }</style><div class=\"color-container\">    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"accentColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{accentColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{accentColorValue}}\" id=\"accentColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"backgroundColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{backgroundColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{backgroundColorValue}}\" id=\"backgroundColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"borderColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{borderColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{borderColorValue}}\" id=\"borderColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"buttonBGColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{buttonBGColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{buttonBGColorValue}}\" id=\"buttonBGColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"buttonTextColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{buttonTextColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{buttonTextColorValue}}\" id=\"buttonTextColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"cardBgColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{cardBgColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{cardBgColorValue}}\" id=\"cardBgColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"cardTextColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{cardTextColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{cardTextColorValue}}\" id=\"cardTextColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"primaryColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{primaryColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{primaryColorValue}}\" id=\"primaryColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"secondaryColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{secondaryColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{secondaryColorValue}}\" id=\"secondaryColorHexValue\">    </div>    <div class=\"color-selector\">        <input type=\"color\" class=\"theme-color-picker\" name=\"textColor\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\"            value=\"{{textColorValue}}\">        <input type=\"text\" pattern=\"^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$\" value=\"{{textColorValue}}\" id=\"textColorHexValue\">    </div></div>';
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
			    const colorPickers = document.querySelectorAll('.theme-color-picker');
			    const themeData = {}; // Initialize an empty object to store color data
			    const textInputs = document.querySelectorAll('[id$="HexValue"]'); // Select text inputs by ID ending

			    // Initialize themeData with default values
			    colorPickers.forEach(colorPicker => {
				   colorPicker.setAttribute('tabindex', '-1');
			        themeData[colorPicker.name] = colorPicker.value;
			    });

			    // Assign data to SDT
			    UC.SelectedTheme.accentColorValue = themeData.accentColor;
			    UC.SelectedTheme.backgroundColorValue = themeData.backgroundColor;
			    UC.SelectedTheme.borderColorValue = themeData.borderColor;
			    UC.SelectedTheme.buttonBGColorValue = themeData.buttonBGColor;
			    UC.SelectedTheme.buttonTextColorValue = themeData.buttonTextColor;
			    UC.SelectedTheme.cardBgColorValue = themeData.cardBgColor;
			    UC.SelectedTheme.cardTextColorValue = themeData.cardTextColor;
			    UC.SelectedTheme.primaryColorValue = themeData.primaryColor;
			    UC.SelectedTheme.secondaryColorValue = themeData.secondaryColor;
			    UC.SelectedTheme.textColorValue = themeData.textColor;

			    // Function to update themeData, SDT, and corresponding text input
			    function updateColorData(name, value) {
			        themeData[name] = value;
			        UC.SelectedTheme.accentColorValue = themeData.accentColor;
			        UC.SelectedTheme.backgroundColorValue = themeData.backgroundColor;
			        UC.SelectedTheme.borderColorValue = themeData.borderColor;
			        UC.SelectedTheme.buttonBGColorValue = themeData.buttonBGColor;
			        UC.SelectedTheme.buttonTextColorValue = themeData.buttonTextColor;
			        UC.SelectedTheme.cardBgColorValue = themeData.cardBgColor;
			        UC.SelectedTheme.cardTextColorValue = themeData.cardTextColor;
			        UC.SelectedTheme.primaryColorValue = themeData.primaryColor;
			        UC.SelectedTheme.secondaryColorValue = themeData.secondaryColor;
			        UC.SelectedTheme.textColorValue = themeData.textColor;

			        // Update corresponding text input.
			        const textInput = document.getElementById(name + 'HexValue');
			        if (textInput) {
			            textInput.value = value;
			        }
			    }

			    // Function to update color picker and themeData from text input
			    function updateColorFromText(name, value) {
			        const colorPicker = document.querySelector(`[name="${name}"]`);
			        if (colorPicker) {
			            colorPicker.value = value;
			            updateColorData(name, value);
			        }
			    }

			    // Add event listeners to update themeData from color pickers
			    colorPickers.forEach(colorPicker => {
			        colorPicker.addEventListener('input', function () {
			            updateColorData(this.name, this.value);
			        });
			    });

			    // Add event listeners to update color pickers from text inputs
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