#region Using directives
using System;
using System.Windows.Forms;

using PixelCryptor.Core.Structure;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenDecodeContent : ScreenMaster {
		#region Fields
		private bool _packageValid;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new EncodeContent screen.
		/// </summary>
		public ScreenDecodeContent() {
			// Initialize basic screen elements
			this.InitializeComponent();
		}
		#endregion

		#region Events
		/// <summary>
		/// User clicks on the SelectCodeFile link.
		/// </summary>
		private void lnkSelectCodeFile_Click(object sender, EventArgs e) {
			// Show the code file selector
			if (this.dlgSelectCodeFile.ShowDialog() == DialogResult.OK) {
				// Try to set the codefile
				if (!this.SelectCodeFile(this.dlgSelectCodeFile.FileName))
					MessageBox.Show(Properties.Resources.MsgInvalidPackageText, Properties.Resources.MsgInvalidPackageTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

			// Select the current codefile
			if (project.CodeFilePath == null) {
				this._packageValid = false;
				this.txtCodeFilePath.Text = "";
				this.ffsSelector.Package = null;
			} else if (!this.SelectCodeFile(project.CodeFilePath))
				MessageBox.Show(Properties.Resources.MsgInvalidPackageText, Properties.Resources.MsgInvalidPackageTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			// Refresh the file folder selector
			this.ffsSelector.Invalidate();
		}

		/// <summary>
		/// Processes a new codefile selection.
		/// </summary>
		private bool SelectCodeFile(string codefile) {			
			// Set the text
			this.txtCodeFilePath.Text = codefile;
			
			try {
				// Update the project
				this._project.Package = PPackage.Load(this._project.KeyPath, codefile);
				this._project.CodeFilePath = codefile;

				// Update the UI
				this.ffsSelector.Package = this._project.Package;
				this._packageValid = true;
			} catch {
				// Failed, package is invalid
				this._packageValid = false;
			}

			// Revalidate the screen
			this.ValidateScreen();

			return this._packageValid;
		}

		/// <summary>
		/// Validates this screen.
		/// </summary>
		public override bool ValidateScreen() {
			// The screen is valid, when a key is defined
			bool isValid = this._packageValid;

			// Call the event
			base.OnScreenValidated(isValid);

			// Return the result
			return isValid;
		}
		#endregion
	}
}
