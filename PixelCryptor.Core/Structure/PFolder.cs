#region Using directives
using System;
using System.Collections.Generic;
using System.IO;
using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	#region Enums
	/// <summary>
	/// Describes the header version of the PFolder.
	/// </summary>
	/// Using 'German City' Range.
	public enum PFolderVersion {
		/// <summary>
		/// Version Dusseldorf is the first version ever.
		/// </summary>
		Dusseldorf = 1,
		/// <summary>
		/// Variation of Dusseldorf; enriched with FileAttributes.
		/// </summary>
		Berlin = 2
	}
	#endregion

	public abstract class PFolder {
		#region Fields
		protected FileAttributes _attributes;
		protected int _fileCount;
		protected int _folderCount;
		private string _folderPath;
		private List<PFolder> _folders;
		private List<PFile> _files;
		protected DateTime _lastModified;
		protected string _name;
		private PPackage _package;
		private PFolder _parentFolder;
		protected readonly PFolderVersion _version;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the attributes of this PFolder.
		/// </summary>
		public FileAttributes Attributes {
			get { return this._attributes; }
		}

		/// <summary>
		/// Gets the amount of files in this PFolder.
		/// </summary>
		internal int FileCount {
			get { return (this._files != null) ? this._files.Count : this._fileCount; }
		}

		/// <summary>
		/// Gets a list of all files in this PFolder.
		/// </summary>
		public List<PFile> Files {
			get { return this._files; }
		}

		/// <summary>
		/// Gets the amount of subfolders in this PFolder.
		/// </summary>
		internal int FolderCount {
			get { return (this._folders != null) ? this._folders.Count : this._folderCount; }
		}

		/// <summary>
		/// Gets a list of all subfolders in this PFolder.
		/// </summary>
		public List<PFolder> Folders {
			get { return this._folders; }
		}

		/// <summary>
		/// Gets the date on which this PFolder was last modified.
		/// </summary>
		public DateTime LastModified {
			get { return this._lastModified; }
		}

		/// <summary>
		/// Gets or sets the name of this PFolder.
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
		/// Gets the folder this PFolder belongs to.
		/// </summary>
		public PFolder ParentFolder {
			internal set {
				this._parentFolder = value;
				this._package = value._package;
			}
			get { return this._parentFolder; }
		}

		/// <summary>
		/// Gets the protocol version of this PFolder.
		/// </summary>
		public PFolderVersion Version {
			get { return this._version; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new blank folder.
		/// </summary>
		protected PFolder(string name, PPackage package, PFolder parentFolder) {
			this._attributes = FileAttributes.Normal;
			this._name = name;
			this._files = new List<PFile>();
			this._folders = new List<PFolder>();
			this._package = package;
			this._parentFolder = parentFolder;
			this._lastModified = DateTime.Now;
		}

		/// <summary>
		/// Constructs a new folder, using the provided version.
		/// </summary>
		protected PFolder(PFolderVersion version) {
			this._attributes = FileAttributes.Normal;
			this._version = version;
		}
		#endregion

		#region Abstract Methods
		/// <summary>
		/// Loads the header information.
		/// </summary>
		abstract internal PFolder Load(CodeReader reader);

		/// <summary>
		/// Saves the folder to disk.
		/// </summary>
		abstract internal void Save(CodeWriter writer, PFolder folder);
		#endregion

		#region Instance Methods
		/// <summary>
		/// Adds the directory and all it's sub directories and files, returns a reference to the created PFolder.
		/// </summary>
		private PFolder Add(DirectoryInfo folderInfoToAdd) {
			// Add this folder
			PFolder folderToAdd = Create(folderInfoToAdd.Name, this._package, this);
			folderToAdd._folderPath = folderInfoToAdd.FullName;
			folderToAdd._lastModified = folderInfoToAdd.LastWriteTime;
			folderToAdd._attributes = folderInfoToAdd.Attributes;
			this._folders.Add(folderToAdd);

			// Add sub folders
			DirectoryInfo[] subDirectories = folderInfoToAdd.GetDirectories();
			foreach (DirectoryInfo subDirectory in subDirectories)
				folderToAdd.Add(subDirectory);

			// Add files
			FileInfo[] files = folderInfoToAdd.GetFiles();
			foreach (FileInfo file in files)
				folderToAdd.Add(file);

			// Return folder
			return folderToAdd;
		}

		/// <summary>
		/// Adds a file, returns a reference to the added file.
		/// </summary>
		private PFile Add(FileInfo fileInfoToAdd) {
			// Create file
			PFile fileToAdd = PFile.Create(fileInfoToAdd, this._package, this);

			// Add file
			this._files.Add(fileToAdd);

			// Return file
			return fileToAdd;
		}

		/// <summary>
		/// Adds the given file to this folder.
		/// </summary>
		public void Add(PFile file) {
			this._files.Add(file);
			file.ParentFolder = this;
		}

		/// <summary>
		/// Adds the given folder to this folder.
		/// </summary>
		public void Add(PFolder folder) {
			this._folders.Add(folder);
			folder.ParentFolder = this;
		}

		/// <summary>
		/// Adds a file, returns a reference to the added file.
		/// </summary>
		public PFile AddFile(string path) {
			return this.Add(new FileInfo(path));
		}

		/// <summary>
		/// Adds multiple files.
		/// </summary>
		public void AddFiles(string[] paths) {
			foreach (string path in paths)
				this.AddFile(path);
		}

		/// <summary>
		/// Adds a folder and all it's sub folders and files, returns a reference to the added folder.
		/// </summary>
		public PFolder AddFolderRecursive(string path) {
			return this.Add(new DirectoryInfo(path));
		}

		/// <summary>
		/// Adds a new folder, returns a reference to the created folder.
		/// </summary>
		public PFolder AddFolderNew(string name) {
			// Create folder
			PFolder folderToAdd = Create(name, this._package, this);

			// Add folder
			this._folders.Add(folderToAdd);

			// Return folder
			return folderToAdd;
		}

		/// <summary>
		/// Counts the amount of files in this folder and its sub folders.
		/// </summary>
		public int CountFiles() {
			int fileCount = this._files.Count;
			foreach (PFolder folder in this._folders)
				fileCount += folder.CountFiles();

			return fileCount;
		}

		/// <summary>
		/// Counts the amount of folders in this folder and its sub folders.
		/// </summary>
		public int CountFolders() {
			int folderCount = this._folders.Count;
			foreach (PFolder folder in this._folders)
				folderCount += folder.CountFolders();

			return folderCount;
		}

		/// <summary>
		/// Deletes all physical files and folders associated with this folder.
		/// </summary>
		internal List<PFolder> DeleteFromSystem() {
			// Okay, lets delete my files
			foreach (PFile file in this._files)
				file.DeleteFromSystem();

			// Now my folders
			List<PFolder> unDeletedFolders = new List<PFolder>();
			foreach (PFolder folder in this._folders)
				unDeletedFolders.AddRange(folder.DeleteFromSystem());

			// And what about me
			DirectoryInfo customInfo;
			if (!String.IsNullOrEmpty(this._folderPath)) {
				customInfo = new DirectoryInfo(this._folderPath);

				if (customInfo.GetFiles().Length > 0 || customInfo.GetDirectories().Length > 0)
					unDeletedFolders.Add(this);
				else {
					Directory.Delete(this._folderPath);
					this._folderPath = "";
				}
			}

			// Right. Now all is left is the reticulation of splines, here we go
			int unDeletedFolderCount = unDeletedFolders.Count + 1;
			List<PFolder> newUnDeletedFolders;

			while (unDeletedFolderCount != unDeletedFolders.Count) {
				// Reset variables
				unDeletedFolderCount = unDeletedFolders.Count;
				newUnDeletedFolders = new List<PFolder>();

				// Try and delete all undeleted other folders
				foreach (PFolder unDeletedFolder in unDeletedFolders) {
					customInfo = new DirectoryInfo(unDeletedFolder._folderPath);

					if (customInfo.GetFiles().Length > 0 || customInfo.GetDirectories().Length > 0)
						newUnDeletedFolders.Add(unDeletedFolder);
					else {
						Directory.Delete(unDeletedFolder._folderPath);
						unDeletedFolder._folderPath = "";
					}
				}

				// Reset collection
				unDeletedFolders = newUnDeletedFolders;
			}

			// Return undeleted folders
			return unDeletedFolders;
		}

		/// <summary>
		/// Extracts the folder to the given location.
		/// </summary>
		internal void Extract(CodeReader reader, string destinationPath) {
			// Get path of the folder
			string thisFolder = destinationPath;
			if (this._parentFolder != null)
				thisFolder = PPackage.CreateValidPath(destinationPath, this._name) + @"\";

			// Create folder and set attributes
			Directory.CreateDirectory(thisFolder);
			new DirectoryInfo(thisFolder).Attributes = this._attributes;

			// Extract sub folders
			foreach (PFolder folder in this._folders)
				folder.Extract(reader, thisFolder);

			// Extract files
			foreach (PFile file in this._files)
				file.Extract(reader, thisFolder);
		}

		/// <summary>
		/// Gets the amount of bytes that in the files in this PFolder.
		/// </summary>
		public long GetByteSize() {
			// Declare result variable
			long byteSize = 0;

			// Count files
			foreach (PFile file in this._files)
				byteSize += file.Size;

			// Count files in subfolders
			foreach (PFolder folder in this._folders)
				byteSize += folder.GetByteSize();

			// Return the total size
			return byteSize;
		}

		/// <summary>
		/// Removes the folder.
		/// </summary>
		public void Remove() {
			this._parentFolder.Folders.Remove(this);
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// Creates a new folder.
		/// </summary>
		internal static PFolder Create(string name, PPackage package, PFolder parentFolder) {
			return new PFolderDusseldorf(name, package, parentFolder);
		}

		/// <summary>
		/// Gets the folder protocol associated with this version.
		/// </summary>
		internal static PFolder GetProtocol(PFolderVersion version) {
			switch (version) {
				default:
				case PFolderVersion.Dusseldorf:
					return new PFolderDusseldorf();
				case PFolderVersion.Berlin:
					return new PFolderBerlin();
			}
		}

		/// <summary>
		/// Returns a new folder, using the provided protocol and reader.
		/// </summary>
		internal static PFolder Load(Protocol protocol, CodeReader reader, PPackage package) {
			// Create new folder using the provided protocol
			PFolder result = protocol.FolderProtocol.Load(reader);
			result._package = package;

			// Load all items in the folder
			LoadItems(protocol, result, reader, package);

			// Return the folder
			return result;
		}

		/// <summary>
		/// Loads all items in the given folder.
		/// </summary>
		private static void LoadItems(Protocol protocol, PFolder folderToProcess, CodeReader reader, PPackage package) {
			// Declare iteration variable
			int i;
			PFolder subFolder;
			PFile file;

			// Load sub folders
			folderToProcess._folders = new List<PFolder>();
			for (i = 0; i < folderToProcess._folderCount; i++) {
				subFolder = PFolder.Load(protocol, reader, package);
				subFolder.ParentFolder = folderToProcess;
				folderToProcess._folders.Add(subFolder);
			}

			// Load files
			folderToProcess._files = new List<PFile>();
			for (i = 0; i < folderToProcess._fileCount; i++) {
				file = PFile.Load(protocol, reader);
				file.ParentFolder = folderToProcess;
				folderToProcess._files.Add(file);
			}
		}

		/// <summary>
		/// Saves the folder content to disk.
		/// </summary>
		internal void SaveContent(Protocol protocol, CodeWriter writer) {
			// Save the sub folders
			foreach (PFolder folder in this._folders)
				folder.SaveContent(protocol, writer);

			// Save the files
			foreach (PFile file in this._files)
				file.SaveContent(protocol, writer);
		}

		/// <summary>
		/// Saves the folder header to disk.
		/// </summary>
		internal void SaveHeader(Protocol protocol, CodeWriter writer) {
			// Save the folder
			protocol.FolderProtocol.Save(writer, this);

			// Save the sub folders
			foreach (PFolder folder in this._folders)
				folder.SaveHeader(protocol, writer);

			// Save the files
			foreach (PFile file in this._files)
				file.SaveHeader(protocol, writer);
		}
		#endregion
	}
}
