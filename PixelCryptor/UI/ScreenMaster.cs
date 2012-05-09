#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;

using PixelCryptor.Core.Structure;
#endregion

namespace PixelCryptor.UI {
	/// <summary>
	/// Validation handler for the validate event.
	/// </summary>
	public delegate void ValidationHandler(ScreenMaster sender, bool isValid);

	/// <summary>
	/// Master screen, base class for other screens.
	/// </summary>
	public partial class ScreenMaster : UserControl {
		#region Fields
		protected CryptorProject _project;
		protected WizardButtons _buttons;
		protected bool _nextOnValid;
		#endregion

		#region Properties
		/// <summary>
		/// Buttons enabled when this Screen is active.
		/// </summary>
		public WizardButtons Buttons {
			get { return _buttons; }
		}

		/// <summary>
		/// Automaticly go to the next screen on succesfull validation.
		/// </summary>
		public bool NextOnValid {
			get { return _nextOnValid; }
		}

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20;
				return cp;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new Master screen.
		/// </summary>
		public ScreenMaster() {
			// Initialize basic screen elements
			this.InitializeComponent();

			// Specify which buttons to use with this screen
			this._buttons = WizardButtons.Default;
			this._nextOnValid = false;
		}
		#endregion

		#region Events
		public event ValidationHandler ScreenValidated;

		/// <summary>
		/// Invoke the validation event.
		/// </summary>
		protected virtual void OnScreenValidated(bool isValid) {
			if (this.ScreenValidated != null)
				this.ScreenValidated(this, isValid);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Activates this screen.
		/// </summary>
		public virtual void Activate(CryptorProject project) {
			// Set project
			this._project = project;

			// Show the current screen
			this.Visible = true;

			// Validate screen
			this.ValidateScreen();
		}

		/// <summary>
		/// Deactivates this screen.
		/// </summary>
		public virtual CryptorProject Deactivate() {
			// Hide the current screen
			this.Visible = false;

			// Return the project
			return this._project;
		}

		/// <summary>
		/// Validates this screen.
		/// </summary>
		public virtual bool ValidateScreen() {
			this.OnScreenValidated(true);
			return true;
		}
		#endregion
	}
}
