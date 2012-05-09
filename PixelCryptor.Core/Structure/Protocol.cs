#region Using directives
using System;
using PixelCryptor.Core.Coding;
#endregion

namespace PixelCryptor.Core.Structure {
	#region Enums
	/// <summary>
	/// Describes the version of the Package at hand.
	/// </summary>
	/// <remarks>
	/// Using the 'Heroes of the ancient world' range.
	/// </remarks>
	internal enum ProtocolVersion {
		/// <summary>
		/// Version Spartacus, the mack daddy of them all.
		/// </summary>
		Spartacus = 1,
		/// <summary>
		/// Version Hercules, includes the new PFile with attribute options.
		/// </summary>
		Hercules = 2,
		/// <summary>
		/// Makes use of the new (seal) coder.
		/// </summary>
		Argon = 3
	}
	#endregion

	internal class Protocol {
		#region Constants
		internal const ProtocolVersion cCurrentVersion = ProtocolVersion.Argon;
		#endregion

		#region Fields
		private ProtocolVersion _currentVersion;
		private Coder _coder;
		private PPackage _packageProtocol;
		private PFolder _folderProtocol;
		private PFile _fileProtocol;
		#endregion

		#region Properties
		internal ProtocolVersion CurrentVersion {
			get { return this._currentVersion; }
		}

		internal Coder Coder {
			get { return this._coder; }
		}

		internal PPackage PackageProtocol {
			get { return this._packageProtocol; }
		}

		internal PFolder FolderProtocol {
			get { return this._folderProtocol; }
		}

		internal PFile FileProtocol {
			get { return this._fileProtocol; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new protocol using the provided version.
		/// </summary>
		internal Protocol(ProtocolVersion version, string keyPath) {
			// Set protocol version
			_currentVersion = version;

			// Declare sub versions
			CoderVersion coderVersion;
			PPackageVersion pPackageVersion;
			PFolderVersion pFolderVersion;
			PFileVersion pFileVersion;

			// Collect current protocol sub versions
			switch (version) {
				case ProtocolVersion.Spartacus:
					coderVersion = CoderVersion.Fox;
					pPackageVersion = PPackageVersion.StEmilion;
					pFolderVersion = PFolderVersion.Dusseldorf;
					pFileVersion = PFileVersion.Stardust;
					break;
				case ProtocolVersion.Hercules:
					coderVersion = CoderVersion.Fox;
					pPackageVersion = PPackageVersion.StEmilion;
					pFolderVersion = PFolderVersion.Berlin;
					pFileVersion = PFileVersion.Comet;
					break;
				default:
				case ProtocolVersion.Argon:
					coderVersion = CoderVersion.Seal;
					pPackageVersion = PPackageVersion.StEmilion;
					pFolderVersion = PFolderVersion.Berlin;
					pFileVersion = PFileVersion.Comet;
					break;
			}

			// Get sub protocols
			_coder = Coder.GetCoder(coderVersion, keyPath);
			_packageProtocol = PPackage.GetProtocol(pPackageVersion);
			_folderProtocol = PFolder.GetProtocol(pFolderVersion);
			_fileProtocol = PFile.GetProtocol(pFileVersion);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Gets the default protocol.
		/// </summary>
		internal static Protocol GetDefaultProtocol(string keyPath) {
			return new Protocol(cCurrentVersion, keyPath);
		}

		/// <summary>
		/// Gets the protocol using the version stored in the reader.
		/// </summary>
		internal static Protocol GetProtocol(CodeReader reader, string keyPath) {
			return new Protocol((ProtocolVersion) reader.ReadUInt32(), keyPath);
		}

		/// <summary>
		/// Saves the protocol version.
		/// </summary>
		internal static void SaveProtocol(ProtocolVersion version, CodeWriter writer) {
			writer.Write((UInt32) version);
		}
		#endregion
	}
}
