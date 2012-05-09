#region Using directives
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.IO {
	/// <summary>
	/// Class for Filesystem information.
	/// </summary>
	public static class ShellObjectInfo {
		#region Enums
		/// <summary>
		/// Folder state, opened or closed.
		/// </summary>
		public enum FolderState {
			/// <summary>
			/// Open folder state.
			/// </summary>
			Open = 0,
			/// <summary>
			/// Closed folder state.
			/// </summary>
			Closed = 1
		}
		#endregion

		#region Methods
		/// <summary>
		/// Retrieve the filesystem info on a file or extension.
		/// </summary>
		public static ShellObject GetFileInfo(string name) {
			return GetInfo(Shell32.FileInfoItemType.File, name);
		}

		/// <summary>
		/// Retrieve the filesystem info on a folder.
		/// </summary>
		public static ShellObject GetFolderInfo() {
			return GetFolderInfo("");
		}

		/// <summary>
		/// Retrieve the filesystem info on a folder.
		/// </summary>
		public static ShellObject GetFolderInfo(string name) {
			return GetInfo(Shell32.FileInfoItemType.Folder, name);
		}

		/// <summary>
		/// Retrieve the filesystem info on a folder.
		/// </summary>
		public static ShellObject GetFolderInfo(bool stateClosed) {
			return GetFolderInfo("", stateClosed);
		}

		/// <summary>
		/// Retrieve the filesystem info on a folder.
		/// </summary>
		public static ShellObject GetFolderInfo(string name, bool stateClosed) {
			return stateClosed ? GetFolderInfo(name) : GetInfo(Shell32.FileInfoItemType.Folder, name, Shell32.FileInfoFlag.IconOpened);
		}

		/// <summary>
		/// Get Shell file or folder info.
		/// </summary>
		private static ShellObject GetInfo(Shell32.FileInfoItemType identifier, string name) {
			return GetInfo(identifier, name, 0);
		}

		/// <summary>
		/// Get Shell file or folder info with extra flags.
		/// </summary>
		private static ShellObject GetInfo(Shell32.FileInfoItemType identifier, string name, Shell32.FileInfoFlag extraFlags) {
			// Create a filesystemobject to hold the result
			ShellObject result = new ShellObject();

			// Create a structure to hold the information
			Shell32.SHFILEINFO info = new Shell32.SHFILEINFO();
			int infoSize = Marshal.SizeOf(typeof(Shell32.SHFILEINFO));

			// Build the flags
			Shell32.FileInfoFlag flags = Shell32.FileInfoFlag.Icon | Shell32.FileInfoFlag.UseFileAttributes;
			flags |= extraFlags;

			// Retrieve the small icon
			Shell32.SHGetFileInfo(name, identifier, ref info, infoSize, flags | Shell32.FileInfoFlag.IconSizeSmall);
			result.SmallIcon = Icon.FromHandle(info.hIcon).ToBitmap();
			User32.DestroyIcon(info.hIcon);

			// Retrieve the large icon and type info
			Shell32.SHGetFileInfo(name, identifier, ref info, infoSize, flags | Shell32.FileInfoFlag.IconSizeLarge | Shell32.FileInfoFlag.TypeName);
			result.LargeIcon = Icon.FromHandle(info.hIcon).ToBitmap();
			result.TypeName = info.szTypeName;
			User32.DestroyIcon(info.hIcon);

			return result;
		}
		#endregion

		#region Inner classes
		/// <summary>
		/// Wrapper for external Shell32.dll functions.
		/// </summary>
		public class Shell32 {
			#region Enums
			/// <summary>
			/// Item type for the Shell32 FileInfo method.
			/// </summary>
			public enum FileInfoItemType : uint {
				Folder = 0x10,
				File = 0x80
			}

			/// <summary>
			/// Flags for the Shell32 FileInfo method.
			/// </summary>
			[Flags()]
			public enum FileInfoFlag : uint {
				Icon = 0x100,
				DisplayName = 0x200,
				TypeName = 0x400,
				Attributes = 0x800,
				IconLocation = 0x1000,
				ExeType = 0x2000,
				SystemIconIndex = 0x4000,
				ShellIconSize = 0x4,

				IconSizeSmall = 0x1,
				IconSizeLarge = 0x0,
				IconSelected = 0x10000,
				IconOpened = 0x2,
				IconLinkOverlay = 0x8000,

				PathIsPIDL = 0x8,
				UseFileAttributes = 0x10,
			}
			#endregion

			#region Structures
			/// <summary>
			/// Structure for storeing the file info.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct SHFILEINFO {
				public IntPtr hIcon;
				public int iIcon;
				public uint dwAttributes;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
				public string szDisplayName;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
				public string szTypeName;
			};
			#endregion

			#region External methods
			/// <summary>
			/// Retrieve file info to gather the file icon.
			/// </summary>
			[DllImport("Shell32.dll")]
			public static extern IntPtr SHGetFileInfo(
				string pszPath,
				FileInfoItemType dwFileAttributes,
				ref SHFILEINFO psfi,
				int cbfileInfo,
				FileInfoFlag uFlags
				);
			#endregion
		}

		/// <summary>
		/// Wrapper for external User32.dll functions.
		/// </summary>
		public class User32 {
			#region External methods
			/// <summary>
			/// Destroy an icon handle.
			/// </summary>
			/// <param name="hIcon">Pointer to icon handle.</param>
			[DllImport("User32.dll")]
			public static extern int DestroyIcon(IntPtr hIcon);
			#endregion
		}
		#endregion
	}
}
