#region Using directives
using System;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenDecodeDestination : ScreenMaster {
		#region String constants
		private string cTooltipDestinationFolder = "Select a destination for the content of the package";
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new DecodeDestination screen.
		/// </summary>
		public ScreenDecodeDestination() {
			// Initialize basic screen elements
			this.InitializeComponent();

			// Bind the Tooltip
			ttpTooltip.SetToolTip(this.lnkSelectDestinationFolder, cTooltipDestinationFolder);
		}
		#endregion

		#region Events
		private void lnkSelectDestinationFolder_Click(object sender, EventArgs e) {
			// Show the destination selector
			if (this.dlgSelectDestinationFolder.ShowDialog() == DialogResult.OK) {
				// Update the project
				this._project.DestinationFolderPath = this.dlgSelectDestinationFolder.SelectedPath;

				// Update the UI
				this.txtDestinationFolderPath.Text = this._project.DestinationFolderPath;

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

			// Set element value if possible
			if (!String.IsNullOrEmpty(project.DestinationFolderPath))
				this.txtDestinationFolderPath.Text = project.DestinationFolderPath;
			else
				this.txtDestinationFolderPath.Text = String.Empty;
		}

		/// <summary>
		/// Deactivates this screen.
		/// </summary>
		public override CryptorProject Deactivate() {
			// Clear the Textbox to prevent flickering
			this.txtDestinationFolderPath.Text = String.Empty;

			// Deactivate the screen
			return base.Deactivate();
		}

		/// <summary>
		/// Validates this screen.
		/// </summary>
		public override bool ValidateScreen() {
			// The screen is valid, when a key is defined
			bool isValid = !String.IsNullOrEmpty(this._project.DestinationFolderPath);

			// Call the event
			base.OnScreenValidated(isValid);

			// Return the result
			return isValid;
		}
		#endregion
	}
}
