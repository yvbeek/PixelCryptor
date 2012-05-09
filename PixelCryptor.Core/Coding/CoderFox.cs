#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
#endregion

namespace PixelCryptor.Core.Coding {
	internal class CoderFox : Coder {
		#region Fields
		private Bitmap _keyFile;
		private Color _currentColor;
		private int _colorTracker;
		private int _x;
		private int _y;
		#endregion

		#region Constructors
		internal CoderFox() { }

		/// <summary>
		/// Creates a new Coder, based on the given parameters.
		/// </summary>
		internal CoderFox(string keyPath) : base(keyPath) {
			// Open key
			this._keyFile = (Bitmap) Bitmap.FromFile(this._keyPath);

			// Initialize parameters
			this._colorTracker = 0;
			this._x = 0;
			this._y = 0;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Recodes the given byte.
		/// </summary>
		internal override byte Recode(byte codedByte) {
			// Declare result byte
			byte result;

			// Recode byte
			if (this._colorTracker == 0)
				result = (byte) (this._currentColor.R - codedByte);
			else if (this._colorTracker == 1)
				result = (byte) (this._currentColor.G - codedByte);
			else
				result = (byte) (this._currentColor.B - codedByte);

			// Update indexes for next use
			if (++this._colorTracker > 2) {
				this._colorTracker = 0;

				if (++this._x >= this._keyFile.Width) {
					this._x = 0;
					if (++this._y >= this._keyFile.Height)
						this._y = 0;
				}

				this._currentColor = this._keyFile.GetPixel(this._x, this._y);
			}

			// Return recoded byte
			return result;
		}
		#endregion
	}
}
