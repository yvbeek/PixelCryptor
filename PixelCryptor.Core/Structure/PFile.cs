#region Using directives
using System;
using System.IO;
using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	#region Enums
	/// <summary>
	/// Describes the header version of the PFile.
	/// </summary>
	/// Using 'Universe' Range.
	public enum PFileVersion {
		/// <summary>
		/// Version Stardust is the first version ever.
		/// </summary>
		Stardust = 1,
		/// <summary>
		/// Variation of Stardust; enriched with FileAttributes.
		/// </summary>
		Comet = 2
	}
	#endregion

	public abstract class PFile {
		#region Constants
		private const int cReadBuffer = 917504; // 896 KB
		private const int cWriteBuffer = 917504; // 896 KB
		#endregion

		#region Fields
		protected FileAttributes _attributes;
		protected string _filePath;
		protected DateTime _lastModified;
		protected string _name;
		private PPackage _package;
		private PFolder _parentFolder;
		protected Int64 _size;
		protected readonly PFileVersion _version;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the attributes of this PFile.
		/// </summary>
		public FileAttributes Attributes {
			get { return this._attributes; }
		}

		/// <summary>
		/// Gets the path to the physical location of this PFile.
		/// </summary>
		internal string FilePath {
			get { return this._filePath; }
		}

		/// <summary>
		/// Gets the date on which this PFile was last modified.
		/// </summary>
		public DateTime LastModified {
			get { return this._lastModified; }
		}

		/// <summary>
		/// Gets or sets the name of this PFile.
		/// </summary>
		public string Name {
			get { return this._name; }
			set { this._name = value; }
		}

		/// <summary>
		/// Gets the package this PFolder belongs to.
		/// </summary>
		internal PPackage Package {
			get { return this._package; }
		}

		/// <summary>
		/// Gets the folder this PFile belongs to.
		/// </summary>
		public PFolder ParentFolder {
			internal set {
				this._parentFolder = value;
				this._package = value.Package;
			}
			get { return this._parentFolder; }
		}

		/// <summary>
		/// Gets the size of this PFile.
		/// </summary>
		public Int64 Size {
			get { return this._size; }
		}

		/// <summary>
		/// Gets the protocol version of this PFile.
		/// </summary>
		public PFileVersion Version {
			get { return this._version; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new blank file
		/// </summary>
		protected PFile(FileInfo fileInfo, PPackage package, PFolder parentFolder) {
			this._attributes = fileInfo.Attributes;
			this._filePath = fileInfo.FullName;
			this._name = fileInfo.Name;
			this._package = package;
			this._parentFolder = parentFolder;
			this._size = fileInfo.Length;
			this._lastModified = fileInfo.LastWriteTime;
		}

		/// <summary>
		/// Constructs a new PFile, using the provided version.
		/// </summary>
		protected PFile(PFileVersion version) {
			this._attributes = FileAttributes.Normal;
			this._version = version;
		}
		#endregion

		#region Abstract Methods
		/// <summary>
		/// Extracts the file to the given location.
		/// </summary>
		abstract internal byte[] Extract(CodeReader reader, int bytesToRead);

		/// <summary>
		/// Loads the header information.
		/// </summary>
		abstract internal PFile Load(CodeReader reader);

		/// <summary>
		/// Saves the file content to disk.
		/// </summary>
		abstract internal void SaveContent(CodeWriter writer, byte[] contentToSave);

		/// <summary>
		/// Saves the file header to disk.
		/// </summary>
		abstract internal void SaveHeader(CodeWriter writer, PFile file);
		#endregion

		#region Instance Methods
		/// <summary>
		/// Deletes the physical file from the system.
		/// </summary>
		internal void DeleteFromSystem() {
			if (!String.IsNullOrEmpty(this._filePath))
				try {
					File.Delete(this._filePath);
					this._filePath = "";
				} catch { }
		}

		/// <summary>
		/// Removes the file.
		/// </summary>
		public void Remove() {
			this._parentFolder.Files.Remove(this);
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// Creates a new file.
		/// </summary>
		internal static PFile Create(FileInfo fileInfo, PPackage package, PFolder parentFolder) {
			return new PFileStardust(fileInfo, package, parentFolder);
		}

		/// <summary>
		/// Extracts the file to the given location.
		/// </summary>
		internal void Extract(CodeReader reader, string destinationPath) {
			// Create the path to the new file
			string fullFilePath = PPackage.CreateValidPath(destinationPath, this._name);

			// Open a stream to the file
			using (FileStream streamedFile = new FileStream(fullFilePath, FileMode.CreateNew, FileAccess.Write)) {
				// Declare variables for decoding
				long totalBytes = this._size;
				int bytesToRead;
				byte[] buffer;

				// Read/Decode/Write blocks of data
				for (long i = 0; i < totalBytes; i += cReadBuffer) {
					// Determine amount of bytes to read
					bytesToRead = (i + cReadBuffer < totalBytes) ? cReadBuffer : (int)(totalBytes - i);

					// Decode and read data
					buffer = this.Extract(reader, bytesToRead);

					// Write data
					streamedFile.Write(buffer, 0, bytesToRead);

					// Report progress
					PPackage.ReportDecodeProgress(bytesToRead);
				}
			}

			// Set file attributes
			new FileInfo(fullFilePath).Attributes = this._attributes;
		}

		/// <summary>
		/// Gets the file protocol associated with this version.
		/// </summary>
		internal static PFile GetProtocol(PFileVersion version) {
			switch (version) {
				default:
				case PFileVersion.Stardust:
					return new PFileStardust();
				case PFileVersion.Comet:
					return new PFileComet();
			}
		}

		/// <summary>
		/// Returns a new file, using the provided protocol and reader.
		/// </summary>
		internal static PFile Load(Protocol protocol, CodeReader reader) {
			// Return the file as requested
			return protocol.FileProtocol.Load(reader);
		}

		/// <summary>
		/// Saves the file contents to disk.
		/// </summary>
		internal void SaveContent(Protocol protocol, CodeWriter writer) {
			// Open a stream to the file
			using (FileStream streamedFile = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read)) {
				// Declare variables for encoding
				long totalBytes = streamedFile.Length;
				int bytesToRead;
				byte[] buffer;

				// Read/Encode/Write blocks of data
				for (long i = 0; i < totalBytes; i += cWriteBuffer) {
					// Determine amount of bytes to read
					bytesToRead = (i + cWriteBuffer < totalBytes) ? cWriteBuffer : (int)(totalBytes - i);

					// Read data
					buffer = new byte[bytesToRead];
					streamedFile.Read(buffer, 0, bytesToRead);

					// Encode and write data
					protocol.FileProtocol.SaveContent(writer, buffer);

					// Report progress
					this._package.ReportEncodeProgress(bytesToRead);
				}
			}
		}

		/// <summary>
		/// Saves the file header to disk.
		/// </summary>
		internal void SaveHeader(Protocol protocol, CodeWriter writer) {
			protocol.FileProtocol.SaveHeader(writer, this);
		}
		#endregion
	}
}
