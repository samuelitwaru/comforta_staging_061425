function WWP_IconButton($) {
	  
	  
	  
	  

	var template = '<button  data-event=\"Event\"  class=\"{{Class}}\" title=\"{{TooltipText}}\"> 	<i class=\"{{BeforeIconClass}}\"></i>	{{#CaptionAsHtml}}{{Caption}}{{/CaptionAsHtml}}	{{^CaptionAsHtml}}<div></div>{{/CaptionAsHtml}}	<i class=\"{{AfterIconClass}}\"></i></button>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnEvent = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnEvent = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Event']")
				.on('click', this.onEventHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.initButton(); 
	}

	this.Scripts = [];

		this.initButton = function() {

					if (!this.CaptionAsHtml){
						const containerEl = document.getElementById(this.ContainerName);	
						containerEl.getElementsByTagName("div")[0].outerHTML = this.Caption
																				.replace(/&/g, "&amp;")
																				.replace(/</g, "&lt;")
																				.replace(/>/g, "&gt;")
																				.replace(/"/g, "&quot;")
																				.replace(/'/g, "&#039;");
					}
				
		}


		this.onEventHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
			}

			if (this.Event) {
				this.Event();
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