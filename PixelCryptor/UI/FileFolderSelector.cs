#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using PixelCryptor.Core.Structure;
using PixelCryptor.UI.WinControls;
#endregion

namespace PixelCryptor.UI {
	public partial class FileFolderSelector : UserControl {
		#region Constants
		private const string cIdentifierPackage = "package";
		private const string cNewFolderName = "New Folder";
		#endregion

		#region Enums
		/// <summary>
		/// The mode in which the selector operates.
		/// </summary>
		public enum OperationMode {
			/// <summary>
			/// Full mode, all options are available to the user.
			/// </summary>
			Full,
			/// <summary>
			/// Read only mode, the user can only navigate and change views.
			/// </summary>
			ReadOnly
		}
		#endregion

		#region Fields
		private Dictionary<PFolder, TreeNode> _nodeMapping;
		private Dictionary<View, Bitmap> _mappedViewImages;
		private PPackage _package;
		private Control _lastFocusedControl;
		private OperationMode _mode;
		#endregion

		#region Properties
		public PPackage Package {
			get { return this._package; }
			set {
				// Set the package
				this._package = value;

				// Clear mapping
				this._nodeMapping.Clear();

				// Clear nodes
				this.tvwContent.Nodes.Clear();

				// Clear file list view
				this.flvContent.Items.Clear();

				if (value != null) {
					// Register the TreeView package icon            
					int index = ShellInfoProvider.GetObjectIndex(cIdentifierPackage);
					if (index == -1) {
						Bitmap bitmap = Properties.Resources.LogoIcon.ToBitmap();
						index = ShellInfoProvider.RegisterObject(cIdentifierPackage, bitmap, bitmap, "Package");
					}

					// Create root node
					TreeNode rootNode = this.tvwContent.Nodes.Add("Package");
					rootNode.ImageIndex = index;
					rootNode.SelectedImageIndex = index;

					// Bind package to root node
					rootNode.Tag = this._package.Root;
					this._nodeMapping.Add(this._package.Root, rootNode);
					foreach (PFolder folder in this._package.Folders)
						this.AddFolderNode(rootNode, folder);

					// Expand the root
					rootNode.Expand();

					// Select the root
					this.tvwContent.SelectedNode = null;
					this.tvwContent.SelectedNode = rootNode;
				}
			}
		}

		public OperationMode Mode {
			get { return this._mode; }
			set {
				if (this._mode != value) {
					this._mode = value;
					this.ActivateMode();
				}
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new FileFolderSelector.
		/// </summary>
		public FileFolderSelector() {			
			this.InitializeComponent();

			// Initialize fields
			this._nodeMapping = new Dictionary<PFolder, TreeNode>();

			// Intialize the TreeView and FileListView
			this.tvwContent.ImageList = ShellInfoProvider.SmallIconList;

			this.flvContent.SmallImageList = ShellInfoProvider.SmallIconList;
			this.flvContent.LargeImageList = ShellInfoProvider.LargeIconList;

			// Set default focussed control
			this._lastFocusedControl = this.tvwContent;

			// Map images
			this._mappedViewImages = new Dictionary<View, Bitmap>();
			this._mappedViewImages.Add(View.LargeIcon, Properties.Resources.ViewLargeIcon);
			this._mappedViewImages.Add(View.SmallIcon, Properties.Resources.ViewSmallIcons);
			this._mappedViewImages.Add(View.Tile, Properties.Resources.ViewTiles);
			this._mappedViewImages.Add(View.List, Properties.Resources.ViewList);
			this._mappedViewImages.Add(View.Details, Properties.Resources.ViewDetails);

			// Set view mode
			this._mode = OperationMode.Full;
			this.ActivateMode();
		}
		#endregion

		#region Events
		#region File List View
		private void flvContent_AfterLabelEdit(object sender, LabelEditEventArgs e) {
			if (!e.CancelEdit && !String.IsNullOrEmpty(e.Label)) {
				// Rename item
				if (this.flvContent.Items[e.Item].Tag is PFolder) {
					PFolder folderToEdit = (PFolder) this.flvContent.Items[e.Item].Tag;
					folderToEdit.Name = e.Label;
					this._nodeMapping[folderToEdit].Text = e.Label;
					this.tvwContent.Refresh();
				} else {
					PFile fileToEdit = (PFile) this.flvContent.Items[e.Item].Tag;
					fileToEdit.Name = e.Label;

					// Reselect node
					this.tvwContent.SelectedNode = null;
					this.tvwContent.SelectedNode = this._nodeMapping[fileToEdit.ParentFolder];
				}
			} else
				e.CancelEdit = true;
		}

		private void flvContent_DragEnter(object sender, DragEventArgs e) {
			this.ActivateForm();

			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void flvContent_DragDrop(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				// Get current destination
				PFolder destinationFolder = (PFolder) (this.tvwContent.SelectedNode != null ? this.tvwContent.SelectedNode.Tag : this.tvwContent.Nodes[0].Tag);
				if (this.flvContent.Items.Count > 0) {
					// Get the destination item
					Point point = this.flvContent.PointToClient(new Point(e.X, e.Y));
					ListViewItem destinationItem = this.flvContent.GetItemAt(point.X, point.Y);

					// Get destination folder
					if (destinationItem != null && destinationItem.Tag is PFolder)
						destinationFolder = (PFolder) destinationItem.Tag;
				}

				// Get dragged item paths
				string[] paths = (string[]) e.Data.GetData(DataFormats.FileDrop);

				// Add to package and screen
				foreach (string path in paths)
					if (!File.Exists(path))
						this.AddFolder(destinationFolder, path);
					else
						this.AddFile(destinationFolder, path);

				// Reselect node
				this.tvwContent.SelectedNode = null;
				this.tvwContent.SelectedNode = this._nodeMapping[destinationFolder];
			}
		}

		private void flvContent_Enter(object sender, EventArgs e) {
			this._lastFocusedControl = this.flvContent;
		}

		private void flvContent_ItemActivate(object sender, EventArgs e) {
			// Display a folder when selected in the FileListView
			if (flvContent.SelectedItems.Count == 1) {
				CGListViewItem item = (CGListViewItem) flvContent.SelectedItems[0];
				if (item.ObjectType == CGListViewItemType.Folder) {
					this.tvwContent.SelectedNode = this._nodeMapping[(PFolder) item.Tag];
					this.tvwContent.SelectedNode.EnsureVisible();
					this.tvwContent.Select();
				}
			}
		}

		private void flvContent_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.Delete:
					this.FileListViewRemove();
					break;
				case Keys.F2:
					if (this.flvContent.SelectedItems.Count > 0)
						this.flvContent.SelectedItems[0].BeginEdit();
					break;
			}
		}
		#endregion

		#region Tool Strip
		/// <summary>
		/// User wants to Create a new Folder.
		/// </summary>
		private void btnCreateFolder_Click(object sender, EventArgs e) {
			// Find root node
			PFolder rootFolder = (PFolder) this.tvwContent.Nodes[0].Tag;
			if (this.tvwContent.SelectedNode != null)
				rootFolder = (PFolder) this.tvwContent.SelectedNode.Tag;

			// Create the folder
			this.CreateFolder(rootFolder, cNewFolderName);

			// Reselect
			this.tvwContent.SelectedNode = null;
			this.tvwContent.SelectedNode = this._nodeMapping[rootFolder];
		}
		
		/// <summary>
		/// User wants to Add a File.
		/// </summary>
		private void btnAddFile_Click(object sender, EventArgs e) {
			if (dlgSelectFile.ShowDialog() == DialogResult.OK) {
				// Find root node
				PFolder rootFolder = (PFolder) this.tvwContent.Nodes[0].Tag;
				if (this.tvwContent.SelectedNode != null)
					rootFolder = (PFolder) this.tvwContent.SelectedNode.Tag;

				// Add the file
				this.AddFile(rootFolder, dlgSelectFile.FileName);

				// Reselect
				this.tvwContent.SelectedNode = null;
				this.tvwContent.SelectedNode = this._nodeMapping[rootFolder];
			}
		}

		/// <summary>
		/// User wants to Add a Folder.
		/// </summary>
		private void btnAddFolder_Click(object sender, EventArgs e) {
			if (dlgSelectFolder.ShowDialog() == DialogResult.OK) {
				// Find root node
				PFolder rootFolder = (PFolder) this.tvwContent.Nodes[0].Tag;
				if (this.tvwContent.SelectedNode != null)
					rootFolder = (PFolder) this.tvwContent.SelectedNode.Tag;

				// Add the folder
				this.AddFolder(rootFolder, dlgSelectFolder.SelectedPath);

				// Reselect
				this.tvwContent.SelectedNode = null;
				this.tvwContent.SelectedNode = this._nodeMapping[rootFolder];
			}
		}

		/// <summary>
		/// User wants to Remove his selection.
		/// </summary>
		private void btnRemove_Click(object sender, EventArgs e) {
			if (this._lastFocusedControl is TreeView)
				this.TreeViewRemove();
			else
				this.FileListViewRemove();
		}

		/// <summary>
		/// User selects Large Icons display mode.
		/// </summary>
		private void btnLargeIcons_Click(object sender, EventArgs e) {
			flvContent.View = View.LargeIcon;
			this.SetViewImage();
		}

		/// <summary>
		/// User selects Small Icons display mode.
		/// </summary>
		private void btnSmallIcons_Click(object sender, EventArgs e) {
			flvContent.View = View.SmallIcon;
			this.SetViewImage();
		}

		/// <summary>
		/// User selects Tile display mode.
		/// </summary>
		private void btnTiles_Click(object sender, EventArgs e) {
			flvContent.View = View.Tile;
			this.SetViewImage();
		}

		/// <summary>
		/// User selects List display mode.
		/// </summary>
		private void btnList_Click(object sender, EventArgs e) {
			flvContent.View = View.List;
			this.SetViewImage();
		}

		/// <summary>
		/// User selects Details display mode.
		/// </summary>
		private void btnDetails_Click(object sender, EventArgs e) {
			flvContent.View = View.Details;
			this.SetViewImage();
		}

		/// <summary>
		/// User clicks the views split button.
		/// </summary>
		private void btnSplitViews_ButtonClick(object sender, EventArgs e) {
			this.flvContent.NextView();
			this.SetViewImage();
		}
		#endregion

		#region Tree View
		private void tvwContent_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (!e.CancelEdit && !String.IsNullOrEmpty(e.Label)) {
				// Rename
				PFolder editedItem = (PFolder) e.Node.Tag;
				editedItem.Name = e.Label;

				// Reselect the node
				this.tvwContent.SelectedNode = null;
				this.tvwContent.SelectedNode = this._nodeMapping[editedItem];
			} else
				e.CancelEdit = true;
		}

		private void tvwContent_AfterSelect(object sender, TreeViewEventArgs e) {
			// Show the contents of a folder
			if (e.Node != null)
				this.DisplayFolder((PFolder) e.Node.Tag);
		}

		private void tvwContent_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (e.Node == this.tvwContent.Nodes[0])
				e.CancelEdit = true;
		}

		private void tvwContent_DragDrop(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				// Get the destination node
				TreeNode destinationNode = this.tvwContent.GetNodeAt(this.tvwContent.PointToClient(new Point(e.X, e.Y)));

				// Get dragged item paths
				string[] paths = (string[]) e.Data.GetData(DataFormats.FileDrop);

				// Add to package and screen
				foreach (string path in paths)
					if (!File.Exists(path))
						this.AddFolder((PFolder) destinationNode.Tag, path);
					else
						this.AddFile((PFolder) destinationNode.Tag, path);

				// Select the master node
				this.tvwContent.SelectedNode = this._nodeMapping[(PFolder) destinationNode.Tag];
			}
		}

		private void tvwContent_DragEnter(object sender, DragEventArgs e) {
			this.ActivateForm();
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void tvwContent_Enter(object sender, EventArgs e) {
			this._lastFocusedControl = this.tvwContent;
		}

		private void tvwContent_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.Delete:
					this.TreeViewRemove();
					break;
				case Keys.F2:
					if (this.tvwContent.SelectedNode != null && this.tvwContent.SelectedNode != this.tvwContent.Nodes[0])
						this.tvwContent.SelectedNode.BeginEdit();
					break;
			}
		}
		#endregion
		#endregion

		#region Methods
		/// <summary>
		/// Activates the parent form.
		/// </summary>
		private void ActivateForm() {
			Control control = this.Parent;

			while (!(control is Form))
				control = control.Parent;

			((Form) control).Activate();
		}

		/// <summary>
		/// Activates the current mode.
		/// </summary>
		private void ActivateMode() {
			switch (this._mode) {
				case OperationMode.Full:
					this.btnAddFile.Visible = true;
					this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);

					this.btnAddFolder.Visible = true;
					this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);

					this.btnRemove.Visible = true;
					this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

					this.btnSplitViews.Margin = this.tstMain.Items[1].Margin;
					this.btnSplitViews.Padding = this.tstMain.Items[1].Padding;

					this.tvwContent.DragDrop += new DragEventHandler(this.tvwContent_DragDrop);
					this.tvwContent.Enter += new EventHandler(this.tvwContent_Enter);
					this.tvwContent.AfterLabelEdit += new NodeLabelEditEventHandler(this.tvwContent_AfterLabelEdit);
					this.tvwContent.DragEnter += new DragEventHandler(this.tvwContent_DragEnter);
					this.tvwContent.BeforeLabelEdit += new NodeLabelEditEventHandler(this.tvwContent_BeforeLabelEdit);
					this.tvwContent.KeyDown += new KeyEventHandler(this.tvwContent_KeyDown);

					this.flvContent.DragEnter += new DragEventHandler(this.flvContent_DragEnter);
					this.flvContent.DragDrop += new DragEventHandler(this.flvContent_DragDrop);
					this.flvContent.Enter += new EventHandler(this.flvContent_Enter);
					this.flvContent.KeyDown += new KeyEventHandler(this.flvContent_KeyDown);
					this.flvContent.AfterLabelEdit += new LabelEditEventHandler(this.flvContent_AfterLabelEdit);
					break;
				case OperationMode.ReadOnly:
					this.btnAddFolder.Visible = false;
					this.btnAddFolder.Click -= this.btnAddFolder_Click;
					
					this.btnAddFile.Visible = false;
					this.btnAddFile.Click -= this.btnAddFile_Click;

					this.btnRemove.Visible = false;
					this.btnRemove.Click -= this.btnRemove_Click;

					this.btnSplitViews.Margin = this.tstMain.Items[0].Margin;
					this.btnSplitViews.Padding = this.tstMain.Items[0].Padding;

					this.tvwContent.DragDrop -= this.tvwContent_DragDrop;
					this.tvwContent.Enter -= this.tvwContent_Enter;
					this.tvwContent.AfterLabelEdit -= this.tvwContent_AfterLabelEdit;
					this.tvwContent.DragEnter -= this.tvwContent_DragEnter;
					this.tvwContent.BeforeLabelEdit -= this.tvwContent_BeforeLabelEdit;
					this.tvwContent.KeyDown -= this.tvwContent_KeyDown;

					this.flvContent.DragEnter -= this.flvContent_DragEnter;
					this.flvContent.DragDrop -= this.flvContent_DragDrop;
					this.flvContent.Enter -= this.flvContent_Enter;
					this.flvContent.KeyDown -= this.flvContent_KeyDown;
					this.flvContent.AfterLabelEdit -= this.flvContent_AfterLabelEdit;
					break;
			}
		}

		/// <summary>
		/// Adds the file @ path to the given folder.
		/// </summary>
		private void AddFile(PFolder folder, string path) {
			// Add the file to the folder
			folder.AddFile(path);

			// Select the node to refresh FileListView
			this.tvwContent.SelectedNode = this._nodeMapping[folder];
		}

		/// <summary>
		/// Creates a new folder under the given folder.
		/// </summary>
		private void CreateFolder(PFolder folder, string name) {
			// Create the new folder
			PFolder newFolder = folder.AddFolderNew(name);

			// Add the nodes to the TreeView
			this.tvwContent.SelectedNode = this.AddFolderNode(this._nodeMapping[folder], newFolder);
		}

		/// <summary>
		/// Adds the folder @ path and all its children to the given folder.
		/// </summary>
		private void AddFolder(PFolder folder, string path) {
			// Add the folder and it's subfolders to the folder
			PFolder newFolder = folder.AddFolderRecursive(path);

			// Add the nodes to the TreeView
			this.tvwContent.SelectedNode = this.AddFolderNode(this._nodeMapping[folder], newFolder);
		}

		/// <summary>
		/// Adds a node to the given folder.
		/// </summary>
		private TreeNode AddFolderNode(TreeNode parentNode, PFolder folder) {
			// Add the folder to the TreeView
			TreeNode node = parentNode.Nodes.Add(folder.Name);
			node.Tag = folder;
			node.ImageIndex = ShellInfoProvider.GetFolderIndex(true);
			node.SelectedImageIndex = ShellInfoProvider.GetFolderIndex(false);

			// Add the package folder - treenode mapping
			this._nodeMapping.Add(folder, node);

			// Add the subfolders to the TreeView
			foreach (PFolder subFolder in folder.Folders)
				this.AddFolderNode(node, subFolder);

			// Return the newly created node
			return node;
		}

		/// <summary>
		/// Displays the given folder.
		/// </summary>
		private void DisplayFolder(PFolder folder) {
			// Clear the FileListView
			this.flvContent.Items.Clear();

			// Add the sub folders
			foreach (PFolder subFolder in folder.Folders)
				this.flvContent.Items.AddFolder(subFolder).Tag = subFolder;

			// Add the files
			foreach (PFile file in folder.Files)
				this.flvContent.Items.AddFile(file).Tag = file;

			// Prepare for display
			this.flvContent.PrepareView();
		}

		/// <summary>
		/// Removes the current selection from the FileListView.
		/// </summary>
		private void FileListViewRemove() {
			if (this.flvContent.SelectedItems.Count > 0) {
				PFolder parentFolder = null;
				PFolder folderToRemove;
				PFile fileToRemove;

				// Remove selected items
				foreach (ListViewItem selectedItem in this.flvContent.SelectedItems)
					if (selectedItem.Tag is PFolder) {
						folderToRemove = (PFolder) selectedItem.Tag;
						parentFolder = folderToRemove.ParentFolder;
						this.RemoveFolder(folderToRemove);
					} else {
						fileToRemove = (PFile) selectedItem.Tag;
						parentFolder = fileToRemove.ParentFolder;
						fileToRemove.Remove();
					}

				// Reselect node
				this.tvwContent.SelectedNode = null;
				this.tvwContent.SelectedNode = this._nodeMapping[parentFolder];
			}
		}

		/// <summary>
		/// Removes the given folder from the package and updates the screen.
		/// </summary>
		private void RemoveFolder(PFolder folder) {
			// Remove the folder and it's subfolders from the package
			folder.Remove();

			// Remove the nodes from the tree and mappings
			this.RemoveFolderNode(this._nodeMapping[folder]);
		}

		/// <summary>
		/// Removes the given node from the tree.
		/// </summary>
		private void RemoveFolderNode(TreeNode nodeToRemove) {
			// Remove the node
			nodeToRemove.Remove();

			// Remove from mapping
			this._nodeMapping.Remove((PFolder) nodeToRemove.Tag);

			// Remove child nodes
			foreach (TreeNode subNode in nodeToRemove.Nodes)
				this.RemoveFolderNode(subNode);
		}

		/// <summary>
		/// Sets the image on the view button to match the view.
		/// </summary>
		private void SetViewImage() {
			btnSplitViews.Image = this._mappedViewImages[flvContent.View];
		}

		/// <summary>
		/// Removes the currently selected node from the TreeView.
		/// </summary>
		private void TreeViewRemove() {
			if (this.tvwContent.SelectedNode != null && this.tvwContent.SelectedNode != this.tvwContent.Nodes[0])
				this.RemoveFolder((PFolder) this.tvwContent.SelectedNode.Tag);
		}
		#endregion
	}
}
