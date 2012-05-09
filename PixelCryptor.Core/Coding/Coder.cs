#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
#endregion

namespace PixelCryptor.Core.Coding {
	#region Enums
	/// <summary>
	/// Describes the header version of the Coder.
	/// </summary>
	/// <remarks>
	/// Using the 'Animals' range.
	/// </remarks>
	internal enum CoderVersion {
		/// <summary>
		/// Version Fox is the first version ever.
		/// </summary>
		Fox = 1,
		/// <summary>
		/// This version contains several bug fixes and speed upgrades.
		/// </summary>
		Seal = 2
	}
	#endregion

	internal abstract class Coder {
		#region Constant Fields
		private const CoderVersion cDefaultCoder = CoderVersion.Seal;
		#endregion

		#region Fields
		protected string _keyPath;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new Coder.
		/// </summary>
		internal Coder() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Coder"/> class.
		/// </summary>
		/// <param name="keyPath">A string containing the path to the image that serves as key.</param>
		internal Coder(string keyPath) {
			_keyPath = keyPath;
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// Returns a new default coder.
		/// </summary>
		internal static Coder GetDefaultCoder(string keyPath) {
			return GetCoder(cDefaultCoder, keyPath);
		}

		/// <summary>
		/// Gets the package protocol associated with this version.
		/// </summary>
		internal static Coder GetCoder(CoderVersion version, string keyPath) {
			switch (version) {
				default:
				case CoderVersion.Seal:
					return new CoderSeal(keyPath);
				case CoderVersion.Fox:
					return new CoderFox(keyPath);
			}
		}

		/// <summary>
		/// Gets the package protocol associated with this version.
		/// </summary>
		internal static Coder GetCoder(CoderVersion version) {
			switch (version) {
				default:
				case CoderVersion.Seal:
					return new CoderSeal();
				case CoderVersion.Fox:
					return new CoderFox();
			}
		}
		#endregion

		#region Abstract Methods
		/// <summary>
		/// Recodes the given byte.
		/// </summary>
		abstract internal byte Recode(byte codedByte);
		#endregion
	}
}
