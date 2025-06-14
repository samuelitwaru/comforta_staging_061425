function UC_Avatar($) {
	 this.setUploadedFile = function(value) {
			this.UploadedFile = value;
		}

		this.getUploadedFile = function() {
			return this.UploadedFile;
		} 
	  

	var template = '</form><style>.profile-user-img{  	width: 128px;	height: 128px;	object-fit: cover;	box-shadow: 0px 2px 4px 0px rgba(0, 0, 0, 0.12);}.avatar-upload {     position: relative;    margin-bottom: 20px;    display: flex;    align-items: center;    justify-content: flex-start;    padding-left: 10px;     .avatar-edit {        position: absolute;        left: 20%;        z-index: 9;        top: 70%;        display: inline-block;        input {            display: none;            ~ label {                display: inline-block;                width: 34px;                height: 34px;                margin-bottom: 0;                border-radius: 100%;                background: #FFFFFF;                border: 1px solid #d2d6de;                box-shadow: 0px 2px 4px 0px rgba(0, 0, 0, 0.12);                cursor: pointer;                           font-weight: normal;			 position: relative;                transition: all .2s ease-in-out;                &:hover {                    background: #f1f1f1;                    border-color: #d6d6d6;                }			&.edit-button:after {				content: \"✎\";				font-size: large;				color: #222f54;				position: absolute;				left: 0;				right: 0;				text-align: center;				line-height: 34px;				margin: auto;			}			&.delete-button:after {				content: \"×\"; /* Or \"🗑\" */				font-size: large;				color: #dc3545;				position: absolute;				left: 0;				right: 0;				text-align: center;				line-height: 34px;				margin: auto;			}            }        }    }}</style><div class=\"avatar-upload\"> <div class=\"avatar-edit\">   <form action=\"\" method=\"post\" id=\"form-image\">     <input type=\'file\' id=\"imageUpload\" accept=\".png, .jpg, .jpeg\" />	<label data-tooltip=\"delete avatar\" class=\"delete-button\"></label>	<label data-tooltip=\"change avatar\" for=\"imageUpload\" class=\"edit-button\"></label>   </form> </div> <div class=\"avatar-preview\">   <img class=\"profile-user-img img-responsive img-circle\" id=\"imagePreview\" src=\"{{PreviewImageLink}}\" alt=\"User profile picture\"> </div></div> <form id=\'gx-remain\'>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnOnUpload = 0; 
	var _iOnOnFailedUpload = 0; 
	var _iOnOnClickDelete = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnUpload = 0; 
			_iOnOnFailedUpload = 0; 
			_iOnOnClickDelete = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnUpload']")
				.on('upload', this.onOnUploadHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='OnFailedUpload']")
				.on('failedupload', this.onOnFailedUploadHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='OnClickDelete']")
				.on('clickdelete', this.onOnClickDeleteHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

				const UC = this;
				const deleteIcon = document.querySelector(".delete-button");
			//	const imagePreview = document.querySelector("#imagePreview");
				$(document).ready(function(){
					$("#imageUpload").change(function(data){
						var imageFile = data.target.files[0];
						if (imageFile.size > 2097152) {
							UC.OnFailedUpload();
							return;
						}
						var reader = new FileReader();
						reader.readAsDataURL(imageFile);
						reader.onload = function(evt){
							UC.UploadedFile.Base64Image = evt.target.result;
							UC.OnUpload();
							$('#imagePreview').attr('src', evt.target.result);
							$('#imagePreview').hide();
							$('#imagePreview').fadeIn(650);
						}
					});
				});

				deleteIcon.addEventListener("click", (event) => {
				   UC.OnClickDelete();
			    });

		}


		this.onOnUploadHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.UploadedFileCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
			}

			if (this.OnUpload) {
				this.OnUpload();
			}
		} 

		this.onOnFailedUploadHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.UploadedFileCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
			}

			if (this.OnFailedUpload) {
				this.OnFailedUpload();
			}
		} 

		this.onOnClickDeleteHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.UploadedFileCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
			}

			if (this.OnClickDelete) {
				this.OnClickDelete();
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