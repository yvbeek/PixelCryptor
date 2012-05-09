#region Using directives
using System;
using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	internal class PFolderDusseldorf : PFolder {
		#region Constructors
		/// <summary>
		/// Constructs a new blank folder.
		/// </summary>
		internal PFolderDusseldorf(string name, PPackage package, PFolder parentFolder) : base(name, package, parentFolder) { }

		/// <summary>
		/// Constructs a new folder, using the right version.
		/// </summary>
		internal PFolderDusseldorf() : base(PFolderVersion.Dusseldorf) { }
		#endregion

		#region Overridden Methods
		/// <summary>
		/// Loads the encoded header information.
		/// </summary>
		internal override PFolder Load(CodeReader reader) {
			PFolderDusseldorf result = new PFolderDusseldorf();
			result._name = reader.ReadString();
			result._folderCount = reader.ReadUInt16();
			result._fileCount = reader.ReadUInt16();
			result._lastModified = new DateTime(reader.ReadInt64());
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
		}
		#endregion
	}
}
