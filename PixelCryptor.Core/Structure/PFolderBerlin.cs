#region Using directives
using System;
using System.IO;

using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	internal class PFolderBerlin : PFolder {
		#region Constructors
		/// <summary>
		/// Constructs a new blank folder.
		/// </summary>
		internal PFolderBerlin(string name, PPackage package, PFolder parentFolder) : base(name, package, parentFolder) { }

		/// <summary>
		/// Constructs a new folder, using the right version.
		/// </summary>
		internal PFolderBerlin() : base(PFolderVersion.Berlin) { }
		#endregion

		#region Overridden Methods
		/// <summary>
		/// Loads the encoded header information.
		/// </summary>
		internal override PFolder Load(CodeReader reader) {
			PFolderBerlin result = new PFolderBerlin();
			result._name = reader.ReadString();
			result._folderCount = reader.ReadUInt16();
			result._fileCount = reader.ReadUInt16();
			result._lastModified = new DateTime(reader.ReadInt64());
			result._attributes = (FileAttributes) reader.ReadInt32();
			return result;
		}

		/// <summary>
		/// Saves the folder to disk.
		/// </summary>
		internal override void Save(CodeWriter writer, PFolder folder) {
			writer.Write(folder.Name);
			writer.Write((UInt16) folder.Folders.Count);
			writer.Write((UInt16) folder.Files.Count);
			writer.Write(folder.LastModified.Ticks);
			writer.Write((int) folder.Attributes);
		}
		#endregion
	}
}
