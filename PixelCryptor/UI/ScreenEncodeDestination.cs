#region Using directives
using System;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenEncodeDestination : ScreenMaster {
		#region String constants
		private string cTooltipDestinationFile = "Select a destination filename for the package";
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new EncodeDestination screen.
		/// </summary>
		public ScreenEncodeDestination() {
			// Initialize basic screen elements
			this.InitializeComponent();

			// Bind the Tooltip
			ttpTooltip.SetToolTip(this.lnkSelectCodeFile, cTooltipDestinationFile);
		}
		#endregion

		#region Events
		private void lnkSelectCodeFile_Click(object sender, EventArgs e) {
			// Show the destination selector
			if (this.dlgSelectCodeFile.ShowDialog() == DialogResult.OK) {
				// Update the UI
				this.txtCodeFilePath.Text = this.dlgSelectCodeFile.FileName;
				this._project.CodeFilePath = this.dlgSelectCodeFile.FileName;

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
			// Call base activate
			base.Activate(project);

			// Set element value if possible
			if (!String.IsNullOrEmpty(project.CodeFilePath))
				this.txtCodeFilePath.Text = project.CodeFilePath;
			else
				this.txtCodeFilePath.Text = String.Empty;
		}

		/// <summary>
		/// Deactivates this screen.
		/// </summary>
		public override CryptorProject Deactivate() {
			// Clear the Textbox to prevent flickering
			this.txtCodeFilePath.Text = String.Empty;

			// Deactivate the screen
			return base.Deactivate();
		}

		/// <summary>
		/// Validates this screen.
		/// </summary>
		public override bool ValidateScreen() {
			// The screen is valid, when a key is defined
			bool isValid = !String.IsNullOrEmpty(this._project.CodeFilePath);

			// Call the event
			base.OnScreenValidated(isValid);

			// Return the result
			return isValid;
		}
		#endregion
	}
}
