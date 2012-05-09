#region Using directives
using System;
using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	internal class PPackageStEmilion : PPackage {
		#region Constructors
		/// <summary>
		/// Constructs a new blank package.
		/// </summary>
		internal PPackageStEmilion(bool withRoot) : base(withRoot) { }

		/// <summary>
		/// Constructs a new package, using the right version.
		/// </summary>
		internal PPackageStEmilion() : base(PPackageVersion.StEmilion) { }
		#endregion

		#region Overridden Methods
		/// <summary>
		/// Loads the encoded header information.
		/// </summary>
		internal override PPackage Load(CodeReader reader) {
			PPackageStEmilion result = new PPackageStEmilion();
			result._date = new DateTime(reader.ReadInt64());
			return result;
		}

		/// <summary>
		/// Saves the package to disk.
		/// </summary>
		internal override void Save(CodeWriter writer, PPackage package) {
			writer.Write(package.Date.Ticks);
		}
		#endregion
	}
}
