#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using PixelCryptor.IO;
#endregion

namespace PixelCryptor.UI {
	public static class ShellInfoProvider {
		#region Constants
		private const string cIdentifierFolderOpen = "folderOpen";
		private const string cIdentifierFolderClosed = "folderClosed";
		#endregion

		#region Fields
		private static ImageList _smallIconList;
		private static ImageList _largeIconList;
		private static List<string> _typeNames;

		private static List<string> _identifiers;
		#endregion

		#region Properties
		public static ImageList SmallIconList {
			get { return _smallIconList; }
		}

		public static ImageList LargeIconList {
			get { return _largeIconList; }
		}

		public static List<string> TypeNames {
			get { return _typeNames; }
		}
		#endregion

		#region Constructor
		static ShellInfoProvider() {
			// Initialise the fields
			_smallIconList = new ImageList();
			_smallIconList.ColorDepth = ColorDepth.Depth32Bit;
			_smallIconList.ImageSize = new Size(16, 16);

			_largeIconList = new ImageList();
			_largeIconList.ColorDepth = ColorDepth.Depth32Bit;
			_largeIconList.ImageSize = new Size(32, 32);

			_typeNames = new List<string>();
			_identifiers = new List<string>();

			// Pre-register folder information
			RegisterFolders();
		}
		#endregion

		#region Public methods
		public static int GetFolderIndex(bool stateClosed) {
			// Folders are pre-registered
			return stateClosed ? 0 : 1;
		}

		public static int GetFileIndex(string identifier) {
			// Retrieve the index for this identifier, register if unknown
			return RegisterFile(identifier);
		}

		public static int GetObjectIndex(string identifier) {
			// Retrieve the index for this identifier
			return _identifiers.IndexOf(identifier);
		}

		public static int RegisterObject(string identifier, Bitmap largeIcon, Bitmap smallIcon, string typeName) {
			// Register the icons and typename
			_largeIconList.Images.Add(largeIcon);
			_smallIconList.Images.Add(smallIcon);
			_typeNames.Add(typeName);

			// Add the identifier to the list of known identifiers
			_identifiers.Add(identifier);

			return _identifiers.Count - 1;
		}
		#endregion

		#region Private methods
		private static void RegisterFolders() {
			// Retrieve folder open and closed info
			RegisterShellObject(cIdentifierFolderOpen, ShellObjectInfo.GetFolderInfo(true));
			RegisterShellObject(cIdentifierFolderClosed, ShellObjectInfo.GetFolderInfo(false));
		}

		private static int RegisterFile(string identifier) {
			// Identifier already registered?
			int index = GetObjectIndex(identifier);

			if (index == -1)
				// Retrieve file info
				index = RegisterShellObject(identifier, ShellObjectInfo.GetFileInfo(identifier));

			return index;
		}

		private static int RegisterShellObject(string identifier, ShellObject obj) {
			return RegisterObject(identifier, obj.LargeIcon, obj.SmallIcon, obj.TypeName);
		}
		#endregion
	}
}
