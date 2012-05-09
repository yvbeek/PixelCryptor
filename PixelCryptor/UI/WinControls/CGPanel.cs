#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI.WinControls {
	/// <summary>
	/// A Code Gazer Panel is a truly transparent Panel.
	/// </summary>
	public partial class CGPanel : Panel {
		#region Constructors
		/// <summary>
		/// Constructs a new CGPanel.
		/// </summary>
		public CGPanel() {
			this.BackColor = Color.Transparent;
		}
		#endregion
	}
}
