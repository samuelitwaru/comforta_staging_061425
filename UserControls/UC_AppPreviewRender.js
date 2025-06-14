function UC_AppPreview($) {
	 this.setAppVersion = function(value) {
			this.AppVersion = value;
		}

		this.getAppVersion = function() {
			return this.AppVersion;
		} 

	var template = '<div class=\"tbap-container\">  <div class=\"tbap-mobile-frame\" id=\"frame\">	  </div></div>';
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

				console.log("AppVersion: ", this.AppVersion)
				localStorage.removeItem("navigation");
				if (typeof PreviewApp !== 'undefined') {
					new PreviewApp(this.AppVersion);
				} else {
					console.error("PreviewApp class is not defined. Check if bundle.js is loaded.");
				}

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