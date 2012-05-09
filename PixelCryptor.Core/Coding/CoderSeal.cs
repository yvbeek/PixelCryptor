#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
#endregion

namespace PixelCryptor.Core.Coding {
	#region Enums
	internal enum ColorCode {
		Red,
		Green,
		Blue
	}
	#endregion

	internal class CoderSeal : Coder {
		#region Inner classes
		private struct SimpleColor {
			public byte Red;
			public byte Green;
			public byte Blue;

			public SimpleColor(byte red, byte green, byte blue) {
				Red = red;
				Green = green;
				Blue = blue;
			}
		}

		private class ImageData {
			#region Fields
			private SimpleColor[] _colors;
			private int _currentIndex;
			private int _length;
			#endregion

			#region Constructors
			public ImageData(Bitmap keyFile) {
				int index = 0;
				int width = keyFile.Width;
				int height = keyFile.Height;

				_length = width * height;
				_colors = new SimpleColor[_length];
				_currentIndex = -1;

				for (int x = 0; x < width; x++)
					for (int y = 0; y < height; y++) {
						Color pixel = keyFile.GetPixel(x, y);
						_colors[index++] = new SimpleColor(pixel.R, pixel.G, pixel.B);
					}
			}
			#endregion

			#region Methods
			public SimpleColor GetNextColor() {
				if (++_currentIndex >= _length)
					_currentIndex = 0;

				return _colors[_currentIndex];
			}
			#endregion
		}
		#endregion

		#region Fields
		private ImageData _imageData;
		private SimpleColor _currentColor;
		private ColorCode _colorTracker;
		#endregion

		#region Constructors
		internal CoderSeal() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="CoderFox"/> class.
		/// </summary>
		/// <param name="keyPath">A string containing the path to the image that serves as key.</param>
		internal CoderSeal(string keyPath)
			: base(keyPath) {
			// Get image data
						using (Bitmap keyFile = (Bitmap)Bitmap.FromFile(_keyPath))
				_imageData = new ImageData(keyFile);

			// Set default field values
			_colorTracker = ColorCode.Red;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Recodes the given byte.
		/// </summary>
		internal override byte Recode(byte codedByte) {
			// Get key byte
			byte keyByte;
			switch (_colorTracker) {
				case ColorCode.Blue:
					// Set source information and next color
					keyByte = _currentColor.Blue;
					_colorTracker = ColorCode.Red;
					break;
				case ColorCode.Green:
					// Set source information and next color
					keyByte = _currentColor.Green;
					_colorTracker = ColorCode.Blue;
					break;
				case ColorCode.Red:
					// Color code red always sets the new color and updates the position information
					_currentColor = _imageData.GetNextColor();

					// Set source information and next color
					keyByte = _currentColor.Red;
					_colorTracker = ColorCode.Green;
					break;
				default:
					throw new Exception("Bonk");
			}

			// Return the recoded byte
			return (byte)(keyByte - codedByte);
		}
		#endregion
	}
}
