#region Using directives
using System;
using System.Text;
#endregion

namespace PixelCryptor.Utilities {
	internal static class TextConversionUtilities {
		/// <summary>
		/// Returns a file size as a formatted string with a unit.
		/// </summary>
		internal static string FormatFileSize(long fileSize) {
			if (fileSize < 0)
				return String.Empty;
			else if (fileSize >= 1024 * 1024 * 1024)
				return string.Format("{0:########0.00} GB", ((double) fileSize) / (1024 * 1024 * 1024));
			else if (fileSize >= 1024 * 1024)
				return string.Format("{0:####0.00} MB", ((double) fileSize) / (1024 * 1024));
			else if (fileSize >= 1024)
				return string.Format("{0:####0.00} KB", ((double) fileSize) / 1024);
			else
				return string.Format("{0} bytes", fileSize);
		}
	}
}
