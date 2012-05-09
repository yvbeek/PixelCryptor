#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI.WinControls {
	/// <summary>
	/// A Code Gazer ToolStrip is a truly transparent ToolStrip.
	/// </summary>
	public partial class CGToolStrip : ToolStrip {
		#region Properties
		/// <summary>
		/// Gets the CreateParams of this CGToolStrip.
		/// </summary>
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
		/// Constructs a new CGToolStrip.
		/// </summary>
		public CGToolStrip() {
			this.Renderer = new CGToolStripRenderer();
		}
		#endregion

		private class CGToolStripRenderer : ToolStripSystemRenderer {
			protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {}
		}
	}
}