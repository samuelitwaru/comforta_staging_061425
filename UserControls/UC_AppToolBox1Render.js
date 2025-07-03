function UC_AppToolBox1($) {
	  
	 this.setSDT_Page = function(value) {
			this.SDT_Page = value;
		}

		this.getSDT_Page = function() {
			return this.SDT_Page;
		} 
	 this.setSDT_Pages = function(value) {
			this.SDT_Pages = value;
		}

		this.getSDT_Pages = function() {
			return this.SDT_Pages;
		} 
	  
	  
	  
	  
	 this.setSDT_ProductServiceCollection = function(value) {
			this.SDT_ProductServiceCollection = value;
		}

		this.getSDT_ProductServiceCollection = function() {
			return this.SDT_ProductServiceCollection;
		} 
	 this.setSuppliers = function(value) {
			this.Suppliers = value;
		}

		this.getSuppliers = function() {
			return this.Suppliers;
		} 
	 this.setSDT_DynamicFormsCollection = function(value) {
			this.SDT_DynamicFormsCollection = value;
		}

		this.getSDT_DynamicFormsCollection = function() {
			return this.SDT_DynamicFormsCollection;
		} 
	 this.setBC_Trn_TemplateCollection = function(value) {
			this.BC_Trn_TemplateCollection = value;
		}

		this.getBC_Trn_TemplateCollection = function() {
			return this.BC_Trn_TemplateCollection;
		} 
	 this.setBC_Trn_ThemeCollection = function(value) {
			this.BC_Trn_ThemeCollection = value;
		}

		this.getBC_Trn_ThemeCollection = function() {
			return this.BC_Trn_ThemeCollection;
		} 
	 this.setBC_Trn_MediaCollection = function(value) {
			this.BC_Trn_MediaCollection = value;
		}

		this.getBC_Trn_MediaCollection = function() {
			return this.BC_Trn_MediaCollection;
		} 
	 this.setBC_Trn_Location = function(value) {
			this.BC_Trn_Location = value;
		}

		this.getBC_Trn_Location = function() {
			return this.BC_Trn_Location;
		} 
	  
	 this.setCurrent_Version = function(value) {
			this.Current_Version = value;
		}

		this.getCurrent_Version = function() {
			return this.Current_Version;
		} 
	  
	  
	  
	  
	 this.setIcons = function(value) {
			this.Icons = value;
		}

		this.getIcons = function() {
			return this.Icons;
		} 

	var template = '<div class=\"preloader\" id=\"preloader\">   <div class=\"spinner\"></div></div><div id=\"tb-body\">   <!-- Navbar -->   <div class=\"tb-navbar\" id=\"tb-navbar\">      <!--<h3 id=\"navbar_title\"></h3>-->      <div class=\"navbar-buttons\" id=\"navbar-buttons-left\"></div>	<div class=\"navbar-buttons\" id=\"navbar-buttons\"></div>   </div>   <div class=\"tb-container\">      	<!-- Editor Container -->      	<div class=\"main-content\" id=\"main-content\"></div>	      	<div class=\"sidebar sidebar-right\" id=\"tb-sidebar\">			<div id=\"page-info-title\"></div>			<div id=\"page-info-section\"></div>			<div id=\"tools-section\"></div>			<div id=\"mapping-section\" style=\"display: none;\">				<div class=\"mapping-header\">				<h3>					<span id=\"sidebar_mapping_title\">					</span>				</h3>				</div>				<div class=\"sidebar-section\">				<div id=\"tree-container\" class=\"tb-list-container\">				</div>				</div>        	</div>      	</div>				<div class=\"tb-alerts-container\" id=\"tb-alerts-container\">		</div>   </div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnOnSave = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnSave = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnSave']")
				.on('save', this.onOnSaveHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

			   try {
				   	this.d3 = d3;
					const themes = this.BC_Trn_ThemeCollection.map(theme => {
						theme.ThemeIcons = this.Icons
						const icons = this.Icons
						let res = {
							ThemeId: theme.Trn_ThemeId,
							ThemeName: theme.Trn_ThemeName,
							ThemeFontFamily: theme.Trn_ThemeFontFamily,
							ThemeColors: {},
							ThemeIcons: icons,
							Icons: this.Icons,
							ThemeCtaColors: theme.CtaColor.sort((a, b) => a.CtaColorName.localeCompare(b.CtaColorName))
						};
						
						// Sort and map ThemeColors by ColorName
						theme.Color
						.sort((a, b) => a.ColorName.localeCompare(b.ColorName))
						.forEach(color => {
							res.ThemeColors[color.ColorName] = color.ColorCode;
						});
						
						// Sort ThemeCtaColors by CtaColorName
						if (theme.CtaColor) {
							res.ThemeCtaColors = [...theme.CtaColor].sort((a, b) => {
								// Extract the number words from the names
								const numWords = ['One', 'Two', 'Three', 'Four', 'Five', 'Six'];
								const aNum = numWords.indexOf(a.CtaColorName.replace('CtaColor', ''));
								const bNum = numWords.indexOf(b.CtaColorName.replace('CtaColor', ''));
								return aNum - bNum;
							});
						}
						
						// Sort ThemeIcons by IconName
						if (theme.Icon) {
							res.ThemeIcons = [...theme.Icon].sort((a, b) => 
							a.IconName.localeCompare(b.IconName)
							);
						}
						
						return res;
					});
				
					
					if (typeof App !== 'undefined') {
						localStorage.clear();
						this.app = new App(
							this,
							themes,
							this.Suppliers,
							this.SDT_ProductServiceCollection, 
							this.SDT_DynamicFormsCollection, 
							this.BC_Trn_MediaCollection,
							this.Current_Theme,
							this.Current_Version,
							this.OrganisationLogo,
							this.Current_Language,
							this.addServiceButtonEvent
						);
						window.app = this.app
					} else {
						console.error("App class is not defined. Check if bundle.js is loaded.");
					}
				}catch(e) {
					console.log(e)
				}

		}


		this.onOnSaveHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 this.SDT_PageCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.SDT_PagesCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 this.SDT_ProductServiceCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.SuppliersCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.SDT_DynamicFormsCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_TemplateCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_ThemeCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_MediaCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_LocationCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.Current_VersionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 this.IconsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
			}

			if (this.OnSave) {
				this.OnSave();
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