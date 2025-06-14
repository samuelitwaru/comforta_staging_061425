function UC_CustomImageUpload($) {
	  
	  
	  
	  
	 this.setUploadedFiles = function(value) {
			this.UploadedFiles = value;
		}

		this.getUploadedFiles = function() {
			return this.UploadedFiles;
		} 
	 this.setFilesToEdit = function(value) {
			this.FilesToEdit = value;
		}

		this.getFilesToEdit = function() {
			return this.FilesToEdit;
		} 

	var template = '<style>.uc-uploader-container {  display: flex;  flex-direction: column;  margin-bottom: 15px;}.uc-upload-controls {  display: flex;  align-items: center;}.uc-upload-btn {  background-color: #222f54;  color: white;  padding: 0.4rem 1.2rem;  font-size: 0.95rem;  border: none;  border-radius: 6px;  cursor: pointer;  display: inline-flex;  align-items: center;  justify-content: center;  margin-bottom: 15px;  white-space: nowrap;  transition: background-color 0.3s ease, border-color 0.3s ease, color 0.3s ease;}.uc-upload-btn.dragover {  border: 2px dashed #ccc;  background-color: transparent;}.uc-image-preview {  display: flex;  flex-direction: column;  gap: 0.75rem;  width: 100%;}.uc-image-preview {  display: grid;  grid-template-columns: repeat(auto-fill, minmax(100px, 1fr));  gap: 12px;}.uc-preview img {  width: 60px;  height: 60px;  object-fit: cover;  border-radius: 4px;  flex-shrink: 0;  margin-right: 1rem;}.uc-preview-footer {  display: flex;  align-items: center;  justify-content: space-between;  gap: 0.5rem;  background: white;  padding-right: 14px;  border: 1px solid #ccc;  border-radius: 8px;  width: 100%;}.uc-image-wrapper {  position: relative;  display: inline-block;}.uc-image-wrapper img {  width: 100px;  height: 100px;  object-fit: cover;  border-radius: 6px;  display: block;}.uc-image-wrapper .uc-delete-btn {  position: absolute;  top: 4px;  right: 4px;  background: rgba(255, 0, 0, 0.6);  color: white;  font-weight: bold;  border: none;  border-radius: 50%;  width: 20px;  height: 20px;  font-size: 8px;  cursor: pointer;  display: flex;  align-items: center;  justify-content: center;}.uc-image-wrapper .uc-delete-btn:hover {  background: red;  color: white;}.uc-delete-btn {  background: none;  border: none;  cursor: pointer;  color: #999;  font-size: 0.8rem;  margin-left: auto;  display: flex;  align-items: center;  justify-content: center;}.uc-delete-btn:hover {  color: #e11d48;}.uc-progress-bar {  height: 4px;  width: 100%;  background-color: #eee;  position: relative;  overflow: hidden;}.uc-progress-fill {  height: 100%;  width: 0%;  background-color: #22c55e;  transition: width 0.3s ease;}.uc-image-grid {  display: grid;  grid-template-columns: repeat(auto-fill, minmax(80px, 1fr));  gap: 0.75rem;}.uc-image-grid img {  width: 100%;  height: auto;  border-radius: 6px;  object-fit: cover;}</style><div class=\"uc-uploader-container\">  <div class=\"uc-upload-controls\">    <div id=\"ucUploadImageBtn\" class=\"uc-upload-btn\">&plus; &nbsp;&nbsp;<span>Add Image</span></div>  </div>  <input type=\"file\" id=\"ucImageControlInput\" multiple accept=\"image/*\" style=\"display: none;\">  <div id=\"ucImagePreview\" class=\"uc-image-preview\"></div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnOnFailedUpload = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnFailedUpload = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnFailedUpload']")
				.on('failedupload', this.onOnFailedUploadHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

			    	const UC = this;
				const ucImageControlInput = document.getElementById('ucImageControlInput');
				const ucPreviewContainer = document.getElementById('ucImagePreview');
				const ucUploadImageBtn = document.getElementById('ucUploadImageBtn');
				
				console.log('mode: ', UC.isReadOnlyMode);
				
				if (UC.isReadOnlyMode === 'true') {
					ucUploadImageBtn.remove();
					ucImageControlInput.remove();
					ucPreviewContainer.classList.add('uc-image-grid');
				} else {
					ucPreviewContainer.classList.add('uc-image-preview');
				}

				
				let imageFiles = [];
				const MAX_FILES = UC.MaxNumberOfFiles;
				const MAX_FILE_SIZE_MB = 10;
				const ALLOWED_TYPES = ['image/jpeg', 'image/png', 'image/webp', 'image/gif'];

				ucUploadImageBtn.addEventListener('click', () => {
					ucImageControlInput.click();
				});
				
				ucImageControlInput.addEventListener('change', (e) => handleFiles(e.target.files));
				
				ucUploadImageBtn.addEventListener('dragover', (e) => {
					e.preventDefault();
					ucUploadImageBtn.classList.add('dragover');
				});
				
				ucUploadImageBtn.addEventListener('dragleave', () => {
					ucUploadImageBtn.classList.remove('dragover');
				});
				
				ucUploadImageBtn.addEventListener('drop', (e) => {
					e.preventDefault();
					ucUploadImageBtn.classList.remove('dragover');
					if (e.dataTransfer.files.length) {
						handleFiles(e.dataTransfer.files);
					}
				});

				function handleFiles(files) {
					const filesArray = [...files];
				
					if (UC.UploadedFiles.length + filesArray.length > MAX_FILES) {
						UC.FailedUploadMessage = `You can only upload a maximum of ${MAX_FILES} images.`;
						UC.OnFailedUpload();
						return;
					}
				
					filesArray.forEach(file => {
					// Validate file type
					if (!ALLOWED_TYPES.includes(file.type)) {
						UC.FailedUploadMessage = `File "${file.name}" is not a supported image type.`;
						UC.OnFailedUpload();
						return;
					}
				
					// Validate file size
					if (file.size > MAX_FILE_SIZE_MB * 1024 * 1024) {
						UC.FailedUploadMessage = `File "${file.name}" is larger than ${MAX_FILE_SIZE_MB}MB and was skipped.`;
						UC.OnFailedUpload();
						return;
					}
				
					const imageId = Date.now() + Math.random(); // Unique ID
					const preview = document.createElement('div');
					preview.classList.add('uc-preview');
					preview.setAttribute('data-id', imageId);
				
					// Create preview HTML layout
					// New layout: image with optional delete button at top-right
					if (UC.isReadOnlyMode === 'true') {
						preview.innerHTML = `
							<div class="uc-image-wrapper">
								<img src="" alt="Preview" />
							</div>
						`;
					} else {
						preview.innerHTML = `
							<div class="uc-image-wrapper">
								<img src="" alt="Preview" />
								<button class="uc-delete-btn" title="Remove">✖</button>
							</div>
						`;
					}
				
					ucPreviewContainer.appendChild(preview);
					const imgElement = preview.querySelector('img');
				
					// For GIF files, we don't compress them but still show a preview
					if (file.type === 'image/gif') {
						const reader = new FileReader();
				
						reader.onload = (e) => {
							// const base64Raw = e.target.result.split(',')[1]; // optional: remove metadata
							imgElement.src = e.target.result; // set the gif preview
				
							// Add file to UploadedFiles list
							imageFiles.push({
								id: imageId,
								FullName: file.name,
								Name: file.name.split('.').slice(0, -1).join('.'),
								Extension: file.name.split('.').pop(),
								Size: file.size,
								File: e.target.result // base64Raw
							});
							UC.UploadedFiles = imageFiles;
						};
				
						reader.readAsDataURL(file); // for GIFs, just read as is (no compression)
					} else {
						// For non-GIF files, we apply compression
						compressImage(file, (percent) => {
							// Optional: show compression progress
						}).then(compressedBlob => {
							const reader = new FileReader();
				
							reader.onload = (e) => {
								// const base64Raw = e.target.result.split(',')[1]; // optional: remove metadata
								imgElement.src = e.target.result; // set the preview for compressed image
				
								// Push the compressed file (base64) to the imageFiles array
								imageFiles.push({
									id: imageId,
									FullName: file.name,
									Name: file.name.split('.').slice(0, -1).join('.'),
									Extension: file.name.split('.').pop(),
									Size: compressedBlob.size,
									File: e.target.result // base64Raw
								});
								UC.UploadedFiles = imageFiles;
							};
				
							reader.readAsDataURL(compressedBlob); // for non-GIF files, read the compressed image
						});
					}
				});

				
					ucImageControlInput.type = '';  // Reset the file input
					ucImageControlInput.type = 'file'; // Re-enable file selection
					UC.UploadedFiles = imageFiles;  // Store the updated files in the state
					
					console.log('Uploaded Files', imageFiles);
					console.log('Uploaded Files', UC.UploadedFiles);
				}


				ucPreviewContainer.addEventListener('click', (e) => {
					if (e.target.classList.contains('uc-delete-btn')) {
						const preview = e.target.closest('.uc-preview');
						const id = preview.getAttribute('data-id');
						
						// delete preview
						preview.remove();
				
						// Remove the file from the UploadedFiles array
						imageFiles = imageFiles.filter(img => img.id != id); // update local state
						UC.UploadedFiles = imageFiles;
					}
				});


				function compressImage(file, onProgress = () => { }) {
					return new Promise((resolve, reject) => {
						const img = new Image();
						const reader = new FileReader();
				
						img.crossOrigin = 'anonymous';
				
						reader.onload = (e) => {
							img.src = e.target.result;
						};
				
						img.onload = () => {
							const canvas = document.createElement('canvas');
							const maxWidth = 1600;
							const scaleFactor = Math.min(1, maxWidth / img.width);
				
							canvas.width = img.width * scaleFactor;
							canvas.height = img.height * scaleFactor;
				
							const ctx = canvas.getContext('2d');
							ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
				
							onProgress(50); // Optional: Update mid-progress if useful
				
							canvas.toBlob(
								(blob) => {
										if (blob) {
											onProgress(100);
											resolve(blob);
										} else {
											reject(new Error('Compression failed: blob is null'));
										}
								},
								'image/jpeg',
								0.7
							);
						};
				
						img.onerror = () => reject(new Error('Image loading failed'));
						reader.onerror = () => reject(new Error('File reading failed'));
				
						reader.readAsDataURL(file);
					});
				}



				function formatBytes(bytes) {
					const kb = bytes / 1024;
					return `${Math.round(kb)}KB`;
				}


				// Preload existing images from FilesToEdit
				if (UC.FilesToEdit && Array.isArray(UC.FilesToEdit) && UC.FilesToEdit.length > 0) {
					UC.FilesToEdit.forEach(fileData => {
						const imageId = Date.now() + Math.random();
						const preview = document.createElement('div');
						preview.classList.add('uc-preview');
						preview.setAttribute('data-id', imageId);
					
						if (UC.isReadOnlyMode === 'true') {
							preview.innerHTML = `<img src="${fileData.File}" alt="Preview" />`;
						} else {
							preview.innerHTML = `
								<div class="uc-image-wrapper">
									<img src="${fileData.File}" alt="Preview" />
									<button class="uc-delete-btn" title="Remove">✖</button>
								</div>
							`;
						}
					
						ucPreviewContainer.appendChild(preview);
					
						imageFiles.push({
							id: imageId,
							FullName: fileData.FullName,
							Name: fileData.Name,
							Extension: fileData.Extension,
							Size: fileData.Size,
							File: fileData.File
						});
					});
				
					UC.UploadedFiles = imageFiles; // Update state after restoring previews
				}

				
		}


		this.onOnFailedUploadHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 this.UploadedFilesCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.FilesToEditCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
			}

			if (this.OnFailedUpload) {
				this.OnFailedUpload();
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