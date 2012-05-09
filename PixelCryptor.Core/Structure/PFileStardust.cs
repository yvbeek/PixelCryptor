#region Using directives
using System;
using System.IO;
using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	internal class PFileStardust : PFile {
		#region Constructors
		/// <summary>
		/// Constructs a new blank file.
		/// </summary>
		internal PFileStardust(FileInfo fileInfo, PPackage package, PFolder parentFolder) : base(fileInfo, package, parentFolder) { }

		/// <summary>
		/// Constructs a new file, using the right version.
		/// </summary>
		internal PFileStardust() : base(PFileVersion.Stardust) { }
		#endregion

		#region Overridden Methods
		/// <summary>
		/// Extracts the file to the given location.
		/// </summary>
		internal override byte[] Extract(CodeReader reader, int bytesToRead) {
			return reader.Read(bytesToRead);
		}

		/// <summary>
		/// Loads the encoded header information.
		/// </summary>
		internal override PFile Load(CodeReader reader) {
			PFileStardust result = new PFileStardust();
			result._name = reader.ReadString();
			result._size = reader.ReadInt64();
			result._lastModified = new DateTime(reader.ReadInt64());
			return result;
		}

		/// <summary>
		/// Saves the file contents to disk.
		/// </summary>
		internal override void SaveContent(CodeWriter writer, byte[] contentToSave) {
			writer.Write(contentToSave);
		}

		/// <summary>
		/// Saves the file header to disk.
		/// </summary>
		internal override void SaveHeader(CodeWriter writer, PFile file) {
			writer.Write(file.Name);
			writer.Write(new FileInfo(file.FilePath).Length);
			writer.Write(file.LastModified.Ticks);
		}
		#endregion
	}
}
