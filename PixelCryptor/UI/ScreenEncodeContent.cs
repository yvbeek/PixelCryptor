#region Using directives
using System;
using System.Windows.Forms;

using PixelCryptor.Core.Structure;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenEncodeContent : ScreenMaster {
		#region Constructors
		/// <summary>
		/// Constructs a new EncodeContent screen.
		/// </summary>
		public ScreenEncodeContent() {
			// Initialize basic screen elements
			this.InitializeComponent();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Activates this screen.
		/// </summary>
		public override void Activate(CryptorProject project) {
			// Call the base implementation
			base.Activate(project);

			// Create a new package
			project.Package = PPackage.Create();

			// Set the package
			this.ffsSelector.Package = project.Package;

			// Refresh the file folder selector
			this.ffsSelector.Invalidate();
		}

		/// <summary>
		/// Deactivates this screen.
		/// </summary>
		public override CryptorProject Deactivate() {
			// Transfer the user preferences
			this._project.DeleteAfterEncode = this.chkDeleteAfterEncode.Checked;

			// Deactivate the screen
			return base.Deactivate();
		}
		#endregion

		#region Events
		/// <summary>
		/// User changed the 'delete after encoding operation' checkbox value.
		/// </summary>
		private void chkDeleteAfterEncode_CheckedChanged(object sender, EventArgs e) {
			if (chkDeleteAfterEncode.Checked && MessageBox.Show(Properties.Resources.MsgDeleteAfterEncodeDescription, Properties.Resources.MsgDeleteAfterEncodeTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				chkDeleteAfterEncode.Checked = false;
		}
		#endregion
	}
}
