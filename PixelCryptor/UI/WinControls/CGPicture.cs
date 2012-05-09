#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI.WinControls {
	/// <summary>
	/// A Code Gazer Picture is a truly transparent PictureBox.
	/// </summary>
	public partial class CGPicture : PictureBox {
		#region Properties
		/// <summary>
		/// Gets the CreateParams of this CGPicture.
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
		/// Default constructor of this CGPicture.
		/// </summary>
		public CGPicture() {
			this.BackColor = Color.Transparent;
			this.WaitOnLoad = true;
		}
		#endregion
	}
}
