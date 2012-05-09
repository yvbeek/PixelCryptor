#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenEncodeImage : ScreenMaster {
		#region Fields
		private readonly int _initImageWidth;
		private readonly int _initImageHeight;
		private Image _initImage;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new EncodeImage screen.
		/// </summary>
		public ScreenEncodeImage() {
			// Initialize basic screen elements
			this.InitializeComponent();

			// Store the initial image values
			this._initImageWidth = this.picImage.Width;
			this._initImageHeight = this.picImage.Height;
			this._initImage = this.picImage.Image;
		}
		#endregion

		#region Events
		/// <summary>
		/// User clicks on the Image.
		/// </summary>
		private void picImage_Click(object sender, EventArgs e) {
			// Show the image selector
			if (this.dlgSelectImage.ShowDialog() == DialogResult.OK) {
				// Update the project
				this._project.KeyPath = this.dlgSelectImage.FileName;

				// Update the UI
				this.SetImageLocation(this._project.KeyPath);

				// Revalidate the screen
				this.ValidateScreen();
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Activates this screen.
		/// </summary>
		public override void Activate(CryptorProject project) {
			// Call the base implementation
			base.Activate(project);

			// Set image location
			this.SetImageLocation(project.KeyPath);
		}

		/// <summary>
		/// Validates this screen.
		/// </summary>
		public override bool ValidateScreen() {
			// The screen is valid, when a key is defined
			bool isValid = !String.IsNullOrEmpty(this._project.KeyPath);

			// Call the event
			base.OnScreenValidated(isValid);

			// Return the result
			return isValid;
		}

		/// <summary>
		/// Set the location of the Image (the key).
		/// </summary>
		private void SetImageLocation(string fileName) {
			// Set image location
			if (String.IsNullOrEmpty(fileName))
				this.picImage.Image = this._initImage;
			else {
				// Change the cursor to Wait mode
				Form.ActiveForm.UseWaitCursor = true;

				try {
					// Load the image, freeze until fully loaded
					this.picImage.ImageLocation = fileName;
					this._project.CodeFileDimension = new Size(this.picImage.Width, this.picImage.Image.Height);

					// Is the image too big? Switch to Zoom mode
					if (this.picImage.Image.Width >= this._initImageWidth || this.picImage.Image.Height >= this._initImageHeight)
						this.picImage.SizeMode = PictureBoxSizeMode.Zoom;
					else
						this.picImage.SizeMode = PictureBoxSizeMode.CenterImage;
				} finally {
					// Change the cursor back to Default
					Form.ActiveForm.UseWaitCursor = false;
				}
			}
		}
		#endregion
	}
}
