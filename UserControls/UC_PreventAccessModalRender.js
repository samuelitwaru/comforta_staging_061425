function UC_PreventAccessModal($) {
	 this.setCurrentAppVersion = function(value) {
			this.CurrentAppVersion = value;
		}

		this.getCurrentAppVersion = function() {
			return this.CurrentAppVersion;
		} 
	  

	var template = '<style>    body.pv-modal-open {      	overflow: hidden; /* Prevent background scrolling */    }    .pv-modal-backdrop {     	position: fixed;		top: 0;		right: 0;		bottom: 0;		left: 0;		z-index: 1040;		background-color: #000;		opacity: 0.8;    }    .pv-modal {		background: white;		border-radius: 8px;		width: 90%;		max-width: 500px;		box-shadow: 0 0 10px rgba(0, 0, 0, 0.25);		/* text-align: center; */		z-index: 1041;		position: fixed;		top:100px;		left: 33%;    }    /* Optional: Blur background content */    .blur {      	filter: blur(4px);    }</style><div>  	<div id=\"content\" class=\"blur\">    	<h1>Main Page Content</h1>    	<p>You can\'t interact with this until the modal is closed.</p> 	</div>		<div class=\"pv-modal\">		<div class=\"popup-header\">			<span>Access Blocked</span>		</div>		<hr style=\"margin:0px\"/>		<div class=\"popup-body\">			<p>The App builder is being used by another receptionist.</p>			<div class=\"popup-footer\">				<a target=\"_blank\" style=\"text-decoration:none\" href=\"{{PreviewLink}}\" class=\"tb-btn tb-btn-primary\" id=\'pv-button-review\'>Review Only</a>				<button class=\"tb-btn tb-btn-outline\" id=\'pv-button\'>Close</button>			</div>		</div>	</div>		<div id=\"pv-modal\" align=\"center\" class=\"pv-modal-backdrop\">	</div></div>';
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

					
					const pvButton = document.querySelector('#pv-button')
					pvButton.addEventListener('click', e=>{
						e.preventDefault()
						window.history.back();
					})
				
					// Show modal on load
					window.onload = function() {
						//document.body.classList.add('pv-modal-open');
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