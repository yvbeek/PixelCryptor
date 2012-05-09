#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI.WinControls {
	/// <summary>
	/// A Code Gazer Label is a truly transparent Label.
	/// </summary>
	public partial class CGLabel : Label {
		#region Properties
		/// <summary>
		/// Gets the CreateParams of this CGLabel.
		/// </summary>
		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20;
				return cp;
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor of this CGLabel.
		/// </summary>
		public CGLabel() {
			this.BackColor = Color.Transparent;
		}
		#endregion
	}
}
