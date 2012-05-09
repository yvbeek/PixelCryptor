#region Using directives
using System;
using System.Collections.Generic;
using System.IO;
using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	#region Delegates
	public delegate void BytesCryptedHandler(int byteAmount);
	#endregion

	#region Enums
	/// <summary>
	/// Describes the header version of the PPackage.
	/// </summary>
	/// Using 'Wines' Range.
	public enum PPackageVersion {
		/// <summary>
		/// Version StEmilion is the first version ever.
		/// </summary>
		StEmilion = 1
	}
	#endregion

	public abstract class PPackage {
		#region Fields
		protected DateTime _date;
		protected PFolder _root;
		protected readonly PPackageVersion _version;
		#endregion

		#region Properties
		public DateTime Date {
			get { return this._date; }
		}

		public List<PFile> Files {
			get { return this._root.Files; }
		}

		public List<PFolder> Folders {
			get { return this._root.Folders; }
		}

		public PFolder Root {
			get { return this._root; }
		}

		public PPackageVersion Version {
			get { return this._version; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new blank package.
		/// </summary>
		protected PPackage(bool withRoot) {
			if (withRoot)
				this._root = PFolder.Create(@"Root", this, null);
		}

		/// <summary>
		/// Constructs a new PPackage, using the provided version.
		/// </summary>
		protected PPackage(PPackageVersion version) {
			this._version = version;
		}
		#endregion

		#region Events
		public event BytesCryptedHandler BytesEncrypted;
		public static event BytesCryptedHandler BytesDecrypted;
		#endregion

		#region Protocol
		/// <summary>
		/// Gets the package protocol associated with this version.
		/// </summary>
		internal static PPackage GetProtocol(PPackageVersion version) {
			switch (version) {
				default:
				case PPackageVersion.StEmilion:
					return new PPackageStEmilion();
			}
		}
		#endregion

		#region Abstract Methods
		/// <summary>
		/// Loads the header information.
		/// </summary>
		abstract internal PPackage Load(CodeReader reader);

		/// <summary>
		/// Saves the package to disk.
		/// </summary>
		abstract internal void Save(CodeWriter writer, PPackage package);
		#endregion

		#region Instance Methods
		/// <summary>
		/// Counts the amount of files in this package.
		/// </summary>
		public int CountFiles() {
			return this.Root.CountFiles();
		}

		/// <summary>
		/// Counts the amount of folders in this package.
		/// </summary>
		public int CountFolders() {
			return this.Root.CountFolders();
		}

		/// <summary>
		/// Gets the amount of bytes that in the files in this package.
		/// </summary>
		public long GetByteSize() {
			return this._root.GetByteSize();
		}

		/// <summary>
		/// Reports the encode progress via the BytesEncrypted event.
		/// </summary>
		internal void ReportEncodeProgress(int byteAmount) {
			if (this.BytesEncrypted != null)
				this.BytesEncrypted.Invoke(byteAmount);
		}

		/// <summary>
		/// Saves the package to disk.
		/// </summary>
		public void Save(string keyPath, string codeFilePath, bool deleteAfterEncode) {
			using (CodeWriter writer = new CodeWriter(Protocol.cCurrentVersion, keyPath, codeFilePath)) {
				// Get protocol
				Protocol protocol = writer.Protocol;

				// Save the package
				protocol.PackageProtocol.Save(writer, this);

				// Save the root folder header
				_root.SaveHeader(protocol, writer);

				// Save the root folder content
				_root.SaveContent(protocol, writer);

				// See if the encoded files have to be deleted
				if (deleteAfterEncode)
					_root.DeleteFromSystem();
			}
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// Creates a new package.
		/// </summary>
		public static PPackage Create() {
			return new PPackageStEmilion(true);
		}

		/// <summary>
		/// Creates a valid path for the given data.
		/// </summary>
		internal static string CreateValidPath(string directory, string fileOrFolderName) {
			// Create standard path
			string destinationPath = directory + fileOrFolderName;

			// Check if path already exists, rename to prevent data loss
			if (File.Exists(destinationPath)) {
				// Create pattern for the path
				string patternPath = directory + Path.GetFileNameWithoutExtension(fileOrFolderName) + "[{0}]";
				if (Path.HasExtension(fileOrFolderName))
					patternPath += Path.GetExtension(fileOrFolderName);

				// Create name
				int counter = 0;
				while (File.Exists((destinationPath = String.Format(patternPath, ++counter)))) { }
			}

			// Return result
			return destinationPath;
		}

		/// <summary>
		/// Extracts the package to the given location.
		/// </summary>
		public static PPackage Extract(string keyPath, string codeFilePath, string destinationPath) {
			using (CodeReader reader = new CodeReader(keyPath, codeFilePath)) {
				// Get protocol
				Protocol protocol = reader.Protocol;

				// Reload the package to ensure we have the latest version
				PPackage result = LoadInternal(reader);

				// Extract the contents
				result._root.Extract(reader, destinationPath + @"\");

				// Return the latest package
				return result;
			}
		}

		/// <summary>
		/// Returns a new package, using the provided keyPath and codeFilePath.
		/// </summary>
		public static PPackage Load(string keyPath, string codeFilePath) {
			using (CodeReader reader = new CodeReader(keyPath, codeFilePath))
				return LoadInternal(reader);
		}

		/// <summary>
		/// Returns a new package, using the provided reader.
		/// </summary>
		private static PPackage LoadInternal(CodeReader reader) {
			// Get protocol
			Protocol protocol = reader.Protocol;

			// Create new folder using the provided protocol
			PPackage result = protocol.PackageProtocol.Load(reader);

			// Load root
			result._root = PFolder.Load(protocol, reader, result);

			// Return the folder
			return result;
		}

		/// <summary>
		/// Reports the decode progress via the BytesDecrypted event.
		/// </summary>
		internal static void ReportDecodeProgress(int byteAmount) {
			if (BytesDecrypted != null)
				BytesDecrypted.Invoke(byteAmount);
		}
		#endregion
	}
}
