#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using PixelCryptor.Core.Structure;
using PixelCryptor.IO;
using PixelCryptor.Utilities;
#endregion

namespace PixelCryptor.UI.WinControls {
	/// <summary>
	/// Respresents a Windows list view control, which displays a collection of files that can
	/// be displayed using one of four ways.
	/// </summary>
	public class CGListView : ListView {
		#region Fields
		private Dictionary<string, int> _iconMappings;
		private Dictionary<string, string> _typeMappings;

		private CGListViewItemCollection _items;

		private CGListViewColumnSorter _sorter;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the collection of files and folders.
		/// </summary>
		public new CGListViewItemCollection Items {
			get { return this._items; }
		}

		/// <summary>
		/// Gets or sets the current view of this CGListView.
		/// </summary>
		public new View View {
			get { return base.View; }
			set {
				base.View = value;
				this.PrepareView();
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CGListView class.
		/// </summary>
		public CGListView()
			: base() {		
			// Initialize the list items
			this._items = new CGListViewItemCollection(this);

			// Initialize the mapping variables
			this._iconMappings = new Dictionary<string, int>(5);
			this._typeMappings = new Dictionary<string, string>(5);

			// Initialize the image lists
			this.LargeImageList = ShellInfoProvider.LargeIconList;
			this.SmallImageList = ShellInfoProvider.SmallIconList;

			// Initialize sorting
			this._sorter = new CGListViewColumnSorter();
			this._sorter.ColumnIndex = 0;
			base.ListViewItemSorter = this._sorter;

			// Prepare the right view
			this.PrepareView();

			// Bind events
			this.ColumnClick += new ColumnClickEventHandler(CGListView_ColumnClick);
		}
		#endregion

		#region Events
		/// <summary>
		/// Click event for the CGListView columns.
		/// </summary>
		private void CGListView_ColumnClick(object sender, ColumnClickEventArgs e) {
			// Determine if clicked column is already the column that is being sorted.
			if (e.Column == this._sorter.ColumnIndex) {
				// Reverse the current sort direction for this column.
				switch (this._sorter.Order) {
					default:
					case SortOrder.Descending:
						this._sorter.Order = SortOrder.Ascending;
						break;
					case SortOrder.Ascending:
						this._sorter.Order = SortOrder.Descending;
						break;
				}

			} else {
				// Set the column number that is to be sorted; default to ascending.
				this._sorter.ColumnIndex = e.Column;
				this._sorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			this.Sort();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Changes the current view to the next in line.
		/// </summary>
		internal void NextView() {
			switch (base.View) {
				case View.LargeIcon:
					this.View = View.Tile;
					break;
				case View.Tile:
					this.View = View.List;
					break;
				case View.List:
					this.View = View.Details;
					break;
				default:
				case View.Details:
					this.View = View.LargeIcon;
					break;
			}
		}

		/// <summary>
		/// Prepares the CGListView for the current view.
		/// </summary>
		internal void PrepareView() {
			// Clear the current columns
			this.Columns.Clear();

			// Define columns
			switch (this.View) {
				default:
					this.Columns.Add("Name", 174);
					this.Columns.Add("Size", 70, HorizontalAlignment.Right);
					this.Columns.Add("Type", 117);
					this.Columns.Add("Date Modified", 131);
					break;
				case View.Tile:
					this.Columns.Add(new ColumnHeader());
					this.Columns.Add(new ColumnHeader());
					this.Columns.Add(new ColumnHeader());
					break;
			}

			// Prepare items
			foreach (CGListViewItem item in this._items)
				item.PrepareView(this.View);
		}
		#endregion

		#region Filesystem methods
		/// <summary>
		/// Initializes the icon and type name of an item.
		/// </summary>
		internal void PrepareItem(CGListViewItem item) {
			// Retrieve the index of this item
			int index;
			if (item.ObjectType == CGListViewItemType.Folder)
				index = ShellInfoProvider.GetFolderIndex(true);
			else
				index = ShellInfoProvider.GetFileIndex(Path.GetExtension(item.Name));

			// Set the item properties
			item.ImageIndex = index;
			item.TypeName = ShellInfoProvider.TypeNames[index];
		}
		#endregion

		#region ListView implementation hiding
		/// <summary>
		/// Hides the Clear method.
		/// </summary>
		private new void Clear() { }

		/// <summary>
		/// Hides the ListViewItemSorter property.
		/// </summary>
		private new void ListViewItemSorter() { }

		/// <summary>
		/// Hides the Sorting property.
		/// </summary>
		private new void Sorting() { }
		#endregion

		#region ListView classes & structs
		/// <summary>
		/// Represents the collection of files and folders in a CGListView control.
		/// </summary>
		public class CGListViewItemCollection : ListViewItemCollection {
			#region Fields
			private CGListView _listView;
			#endregion

			#region Constructors
			/// <summary>
			/// Initializes a new instance of the CGListViewItemCollection class.
			/// </summary>
			public CGListViewItemCollection(CGListView owner) : base(owner) {
				this._listView = owner;
			}
			#endregion

			#region Methods
			/// <summary>
			/// Adds a PFolder to the ListView.
			/// </summary>
			public CGListViewItem AddFolder(PFolder folder) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.Folder, folder.Name, folder.LastModified, folder.Attributes);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom folder to the ListView.
			/// </summary>
			public CGListViewItem AddFolder(string name) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.Folder, name);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom folder to the ListView.
			/// </summary>
			public CGListViewItem AddFolder(string name, DateTime lastModified) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.Folder, name, lastModified);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom folder to the ListView.
			/// </summary>
			public CGListViewItem AddFolder(string name, DateTime lastModified, FileAttributes attributes) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.Folder, name, lastModified, attributes);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a PFile to the ListView.
			/// </summary>
			public CGListViewItem AddFile(PFile file) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.File, file.Name, file.Size, file.LastModified, file.Attributes);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom file to the ListView.
			/// </summary>
			public CGListViewItem AddFile(string name) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.File, name);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom file to the ListView.
			/// </summary>
			public CGListViewItem AddFile(string name, DateTime lastModified) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.File, name, lastModified);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom file to the ListView.
			/// </summary>
			public CGListViewItem AddFile(string name, int size) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.File, name, size);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom file to the ListView.
			/// </summary>
			public CGListViewItem AddFile(string name, int size, DateTime lastModified) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.File, name, size, lastModified);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}

			/// <summary>
			/// Adds a custom file to the ListView.
			/// </summary>
			public CGListViewItem AddFile(string name, int size, DateTime lastModified, FileAttributes attributes) {
				// Create and add the item
				CGListViewItem item = new CGListViewItem(CGListViewItemType.File, name, size, lastModified, attributes);
				base.Add(item);

				// Prepare the item
				this._listView.PrepareItem(item);

				// Return the newly created item
				return item;
			}
			#endregion
		}

		/// <summary>
		/// Represents a sorter class for the CGListView control.
		/// </summary>
		private class CGListViewColumnSorter : IComparer {
			#region Fields
			private int _columnIndex;
			private SortOrder _columnOrder;
			private CaseInsensitiveComparer _comparer;
			#endregion

			#region Properties
			/// <summary>
			/// Gets or sets the index of the column to which to apply the sorting operation (Defaults to '0').
			/// </summary>
			public int ColumnIndex {
				get { return this._columnIndex; }
				set { this._columnIndex = value; }
			}

			/// <summary>
			/// Gets or sets the order of sorting to apply (Ascending or Descending).
			/// </summary>
			public SortOrder Order {
				set { this._columnOrder = value; }
				get { return this._columnOrder; }
			}
			#endregion

			#region Constructors
			/// <summary>
			/// Initializes a new instance of the CGListViewColumnSorter class.
			/// </summary>
			public CGListViewColumnSorter() {
				this._columnIndex = 0;
				this._columnOrder = SortOrder.None;
				this._comparer = new CaseInsensitiveComparer();
			}
			#endregion

			#region Methods
			/// <summary>
			/// Compares the two objects passed using a case insensitive comparison.
			/// </summary>
			/// <param name="x">First object to be compared</param>
			/// <param name="y">Second object to be compared</param>
			/// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
			public int Compare(object x, object y) {
				// Cast the objects
				CGListViewItem item1 = (CGListViewItem) x;
				CGListViewItem item2 = (CGListViewItem) y;

				// Compare the two items
				int compareResult;
				if (item1.ObjectType == item2.ObjectType)
					if (this._columnIndex == 0)
						compareResult = this._comparer.Compare(item1.Text, item2.Text);
					else
						compareResult = this._comparer.Compare(item1.SubItems[this._columnIndex].Tag, item2.SubItems[this._columnIndex].Tag);
				else
					compareResult = (item1.ObjectType == CGListViewItemType.Folder) ? -1 : 1;

				// Calculate correct return value based on object comparison
				switch (this._columnOrder) {
					case SortOrder.Ascending:
						return compareResult;
					case SortOrder.Descending:
						return -compareResult;
					default:
						return 0;
				}
			}
			#endregion
		}
		#endregion
	}

	/// <summary>
	/// ItemTypes in the CGListView control.
	/// </summary>
	public enum CGListViewItemType {
		/// <summary>
		/// A folder item.
		/// </summary>
		Folder,
		/// <summary>
		/// A file item.
		/// </summary>
		File
	}

	/// <summary>
	/// Represents a file or folder in the CGListView control.
	/// </summary>
	public class CGListViewItem : ListViewItem {
		#region Fields
		private CGListViewItemType _objectType;

		private ListViewSubItem _itemLastModified;
		private ListViewSubItem _itemSize;
		private ListViewSubItem _itemTypeName;

		private FileAttributes _attributes;
		#endregion

		#region Properties
		private new ListView ListView { get { return null; } set { } }

		/// <summary>
		/// Gets or sets the Attributes of this item.
		/// </summary>
		private FileAttributes Attributes {
			get { return this._attributes; }
			set { this._attributes = value; }
		}

		/// <summary>
		/// Gets the CGListView, which is the owner of this item.
		/// </summary>
		public CGListView CGListView {
			get { return (CGListView) base.ListView; }
		}

		/// <summary>
		/// Gets the CGListViewItemType of this item.
		/// </summary>
		public CGListViewItemType ObjectType {
			get { return this._objectType; }
		}

		/// <summary>
		/// Gets or sets the LastModified date of this item.
		/// </summary>
		public DateTime LastModified {
			get { return (DateTime) this._itemLastModified.Tag; }
			set {
				this._itemLastModified.Tag = value;
				this._itemLastModified.Text = value.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the name of this item.
		/// </summary>
		public new string Name {
			get { return this.Text; }
			set {
				this.Text = value;

				if (this.CGListView != null)
					this.CGListView.PrepareItem(this);
			}
		}

		/// <summary>
		/// Gets or sets the size in bytes of this item.
		/// </summary>
		public long Size {
			get { return (long) this._itemSize.Tag; }
			internal set {
				this._itemSize.Tag = value;
				this._itemSize.Text = TextConversionUtilities.FormatFileSize(value);
			}
		}

		/// <summary>
		/// Gets or sets the type name of this item.
		/// </summary>
		public string TypeName {
			get { return this._itemTypeName.Text; }
			internal set {
				this._itemTypeName.Tag = value;
				this._itemTypeName.Text = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CGListViewItem class.
		/// </summary>
		public CGListViewItem(CGListViewItemType objectType, string name) : this(objectType, name, -1) { }

		/// <summary>
		/// Initializes a new instance of the CGListViewItem class.
		/// </summary>			
		public CGListViewItem(CGListViewItemType objectType, string name, long size) : this(objectType, name, size, DateTime.Now) { }

		/// <summary>
		/// Initializes a new instance of the CGListViewItem class.
		/// </summary>			
		public CGListViewItem(CGListViewItemType objectType, string name, DateTime lastModified) : this(objectType, name, -1, lastModified) { }

		/// <summary>
		/// Initializes a new instance of the CGListViewItem class.
		/// </summary>			
		public CGListViewItem(CGListViewItemType objectType, string name, long size, DateTime lastModified) : this(objectType, name, size, lastModified, FileAttributes.Normal) { }

		/// <summary>
		/// Initializes a new instance of the CGListViewItem class.
		/// </summary>			
		public CGListViewItem(CGListViewItemType objectType, string name, DateTime lastModified, FileAttributes attributes) : this(objectType, name, -1, lastModified, attributes) { }

		/// <summary>
		/// Initializes a new instance of the CGListViewItem class.
		/// </summary>			
		public CGListViewItem(CGListViewItemType objectType, string name, long size, DateTime lastModified, FileAttributes attributes) {
			// Set object type
			this._objectType = objectType;

			// Create items
			this._itemLastModified = new ListViewSubItem();
			this._itemSize = new ListViewSubItem();
			this._itemTypeName = new ListViewSubItem();

			// Set the values of the item
			this.LastModified = lastModified;
			this.Name = name;
			this.Size = size;
			
			// Set the item's attributes
			this._attributes = attributes;

			// Bind type if possible
			if (this.CGListView != null)
				this.CGListView.PrepareItem(this);

			// Prepare the view
			this.PrepareView(View.Details);
		}
		#endregion

		#region Utility methods
		/// <summary>
		/// Prepares the item to be viewed the correct way.
		/// </summary>
		public void PrepareView(View view) {
			// Remove the old subitems
			if (this.SubItems.Contains(this._itemSize))
				this.SubItems.Remove(this._itemSize);
			if (this.SubItems.Contains(this._itemTypeName))
				this.SubItems.Remove(this._itemTypeName);
			if (this.SubItems.Contains(this._itemLastModified))
				this.SubItems.Remove(this._itemLastModified);

			// Create the new subitems
			this.UseItemStyleForSubItems = false;

			switch (view) {
				default:
					// Set style
					this._itemTypeName.ForeColor = Color.Black;
					this._itemSize.ForeColor = Color.Black;

					// Add the items
					this.SubItems.Add(this._itemSize);
					this.SubItems.Add(this._itemTypeName);
					this.SubItems.Add(this._itemLastModified);
					break;
				case View.Tile:
					// Set style
					this._itemTypeName.ForeColor = Color.Gray;
					this._itemSize.ForeColor = Color.Gray;

					// Add the items
					this.SubItems.Add(this._itemTypeName);
					break;
			}

			// Change UI to represent the attributes
			if ((this._attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
				foreach (ListViewSubItem subitem in this.SubItems)
					subitem.ForeColor = Color.Gray;

		}
		#endregion
	}
}
