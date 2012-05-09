namespace PixelCryptor.UI {
	partial class FileFolderSelector {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileFolderSelector));
			this.splitter = new System.Windows.Forms.SplitContainer();
			this.tvwContent = new System.Windows.Forms.TreeView();
			this.flvContent = new PixelCryptor.UI.WinControls.CGListView();
			this.btnSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.dlgSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
			this.tstMain = new PixelCryptor.UI.WinControls.CGToolStrip();
			this.btnCreateFolder = new System.Windows.Forms.ToolStripButton();
			this.btnAddFolder = new System.Windows.Forms.ToolStripButton();
			this.btnAddFile = new System.Windows.Forms.ToolStripButton();
			this.btnRemove = new System.Windows.Forms.ToolStripButton();
			this.btnSplitViews = new System.Windows.Forms.ToolStripSplitButton();
			this.btnLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.btnTiles = new System.Windows.Forms.ToolStripMenuItem();
			this.btnList = new System.Windows.Forms.ToolStripMenuItem();
			this.btnDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.splitter.Panel1.SuspendLayout();
			this.splitter.Panel2.SuspendLayout();
			this.splitter.SuspendLayout();
			this.tstMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitter
			// 
			this.splitter.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitter.Location = new System.Drawing.Point(0, 37);
			this.splitter.Margin = new System.Windows.Forms.Padding(0);
			this.splitter.Name = "splitter";
			// 
			// splitter.Panel1
			// 
			this.splitter.Panel1.Controls.Add(this.tvwContent);
			// 
			// splitter.Panel2
			// 
			this.splitter.Panel2.Controls.Add(this.flvContent);
			this.splitter.Size = new System.Drawing.Size(644, 330);
			this.splitter.SplitterDistance = 188;
			this.splitter.TabIndex = 5;
			// 
			// tvwContent
			// 
			this.tvwContent.AllowDrop = true;
			this.tvwContent.BackColor = System.Drawing.Color.White;
			this.tvwContent.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.tvwContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwContent.LabelEdit = true;
			this.tvwContent.Location = new System.Drawing.Point(0, 0);
			this.tvwContent.Name = "tvwContent";
			this.tvwContent.ShowRootLines = false;
			this.tvwContent.Size = new System.Drawing.Size(188, 330);
			this.tvwContent.TabIndex = 0;
			this.tvwContent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwContent_AfterSelect);
			// 
			// flvContent
			// 
			this.flvContent.AllowDrop = true;
			this.flvContent.BackColor = System.Drawing.Color.White;
			this.flvContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flvContent.LabelEdit = true;
			this.flvContent.Location = new System.Drawing.Point(0, 0);
			this.flvContent.Name = "flvContent";
			this.flvContent.Size = new System.Drawing.Size(452, 330);
			this.flvContent.TabIndex = 0;
			this.flvContent.UseCompatibleStateImageBehavior = false;
			this.flvContent.View = System.Windows.Forms.View.Details;
			this.flvContent.ItemActivate += new System.EventHandler(this.flvContent_ItemActivate);
			// 
			// btnSmallIcons
			// 
			this.btnSmallIcons.Name = "btnSmallIcons";
			this.btnSmallIcons.Size = new System.Drawing.Size(141, 22);
			this.btnSmallIcons.Text = "Small Icons";
			this.btnSmallIcons.Click += new System.EventHandler(this.btnSmallIcons_Click);
			// 
			// dlgSelectFolder
			// 
			this.dlgSelectFolder.Description = "Select which folder to include in the package...";
			// 
			// dlgSelectFile
			// 
			this.dlgSelectFile.Filter = "All files (*.*)|*.*";
			// 
			// tstMain
			// 
			this.tstMain.AllowMerge = false;
			this.tstMain.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (213)))), ((int) (((byte) (220)))), ((int) (((byte) (225)))));
			this.tstMain.CanOverflow = false;
			this.tstMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tstMain.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.tstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateFolder,
            this.btnAddFolder,
            this.btnAddFile,
            this.btnRemove,
            this.btnSplitViews});
			this.tstMain.Location = new System.Drawing.Point(0, 0);
			this.tstMain.MinimumSize = new System.Drawing.Size(0, 32);
			this.tstMain.Name = "tstMain";
			this.tstMain.Size = new System.Drawing.Size(644, 32);
			this.tstMain.TabIndex = 0;
			// 
			// btnCreateFolder
			// 
			this.btnCreateFolder.AutoToolTip = false;
			this.btnCreateFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.btnCreateFolder.ForeColor = System.Drawing.Color.Black;
			this.btnCreateFolder.Image = global::PixelCryptor.Properties.Resources.ButtonNewFolder;
			this.btnCreateFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCreateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCreateFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.btnCreateFolder.Name = "btnCreateFolder";
			this.btnCreateFolder.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.btnCreateFolder.Size = new System.Drawing.Size(100, 32);
			this.btnCreateFolder.Tag = "";
			this.btnCreateFolder.Text = "Create Folder";
			this.btnCreateFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCreateFolder.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnCreateFolder.ToolTipText = "Create a new folder in the package";
			this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
			// 
			// btnAddFolder
			// 
			this.btnAddFolder.AutoToolTip = false;
			this.btnAddFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.btnAddFolder.ForeColor = System.Drawing.Color.Black;
			this.btnAddFolder.Image = ((System.Drawing.Image) (resources.GetObject("btnAddFolder.Image")));
			this.btnAddFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.btnAddFolder.Size = new System.Drawing.Size(91, 32);
			this.btnAddFolder.Tag = "";
			this.btnAddFolder.Text = " Add Folder";
			this.btnAddFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAddFolder.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnAddFolder.ToolTipText = "Add a folder to the package";
			// 
			// btnAddFile
			// 
			this.btnAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.btnAddFile.ForeColor = System.Drawing.Color.Black;
			this.btnAddFile.Image = global::PixelCryptor.Properties.Resources.ButtonAddFile;
			this.btnAddFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddFile.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.btnAddFile.Name = "btnAddFile";
			this.btnAddFile.Padding = new System.Windows.Forms.Padding(3, 2, 1, 2);
			this.btnAddFile.Size = new System.Drawing.Size(80, 32);
			this.btnAddFile.Tag = "";
			this.btnAddFile.Text = " Add File";
			this.btnAddFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAddFile.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnAddFile.ToolTipText = "Add a file to the package";
			// 
			// btnRemove
			// 
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.btnRemove.ForeColor = System.Drawing.Color.Black;
			this.btnRemove.Image = global::PixelCryptor.Properties.Resources.ButtonRemoveSelection;
			this.btnRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRemove.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Padding = new System.Windows.Forms.Padding(3, 2, 1, 2);
			this.btnRemove.Size = new System.Drawing.Size(82, 32);
			this.btnRemove.Text = " Remove";
			this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRemove.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnRemove.ToolTipText = "Remove current selection from the package";
			// 
			// btnSplitViews
			// 
			this.btnSplitViews.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLargeIcons,
            this.btnTiles,
            this.btnList,
            this.btnDetails});
			this.btnSplitViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.btnSplitViews.ForeColor = System.Drawing.Color.Black;
			this.btnSplitViews.Image = global::PixelCryptor.Properties.Resources.ViewDetails;
			this.btnSplitViews.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSplitViews.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSplitViews.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.btnSplitViews.Name = "btnSplitViews";
			this.btnSplitViews.Padding = new System.Windows.Forms.Padding(3, 2, 1, 2);
			this.btnSplitViews.Size = new System.Drawing.Size(74, 32);
			this.btnSplitViews.Text = " Views";
			this.btnSplitViews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSplitViews.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnSplitViews.ToolTipText = "Choose how to view the contents on the right side";
			this.btnSplitViews.ButtonClick += new System.EventHandler(this.btnSplitViews_ButtonClick);
			// 
			// btnLargeIcons
			// 
			this.btnLargeIcons.Image = global::PixelCryptor.Properties.Resources.ViewLargeIcon;
			this.btnLargeIcons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnLargeIcons.Name = "btnLargeIcons";
			this.btnLargeIcons.Size = new System.Drawing.Size(130, 22);
			this.btnLargeIcons.Text = "Large Icons";
			this.btnLargeIcons.ToolTipText = "Switch to Large Icon view";
			this.btnLargeIcons.Click += new System.EventHandler(this.btnLargeIcons_Click);
			// 
			// btnTiles
			// 
			this.btnTiles.Image = ((System.Drawing.Image) (resources.GetObject("btnTiles.Image")));
			this.btnTiles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnTiles.Name = "btnTiles";
			this.btnTiles.Size = new System.Drawing.Size(130, 22);
			this.btnTiles.Text = "Tiles";
			this.btnTiles.Click += new System.EventHandler(this.btnTiles_Click);
			// 
			// btnList
			// 
			this.btnList.Image = global::PixelCryptor.Properties.Resources.ViewList;
			this.btnList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnList.Name = "btnList";
			this.btnList.Size = new System.Drawing.Size(130, 22);
			this.btnList.Text = "List";
			this.btnList.Click += new System.EventHandler(this.btnList_Click);
			// 
			// btnDetails
			// 
			this.btnDetails.Image = global::PixelCryptor.Properties.Resources.ViewDetails;
			this.btnDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnDetails.Name = "btnDetails";
			this.btnDetails.Size = new System.Drawing.Size(130, 22);
			this.btnDetails.Text = "Details";
			this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
			// 
			// FileFolderSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tstMain);
			this.Controls.Add(this.splitter);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "FileFolderSelector";
			this.Size = new System.Drawing.Size(644, 365);
			this.splitter.Panel1.ResumeLayout(false);
			this.splitter.Panel2.ResumeLayout(false);
			this.splitter.ResumeLayout(false);
			this.tstMain.ResumeLayout(false);
			this.tstMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog dlgSelectFolder;
		private System.Windows.Forms.OpenFileDialog dlgSelectFile;
		private System.Windows.Forms.SplitContainer splitter;
		private System.Windows.Forms.TreeView tvwContent;
		private WinControls.CGListView flvContent;
		private WinControls.CGToolStrip tstMain;
		private System.Windows.Forms.ToolStripSplitButton btnSplitViews;
		private System.Windows.Forms.ToolStripMenuItem btnLargeIcons;
		private System.Windows.Forms.ToolStripButton btnAddFolder;
		private System.Windows.Forms.ToolStripButton btnRemove;
		private System.Windows.Forms.ToolStripButton btnAddFile;
		private System.Windows.Forms.ToolStripMenuItem btnTiles;
		private System.Windows.Forms.ToolStripMenuItem btnSmallIcons;
		private System.Windows.Forms.ToolStripMenuItem btnList;
		private System.Windows.Forms.ToolStripMenuItem btnDetails;
		private System.Windows.Forms.ToolStripButton btnCreateFolder;
	}
}
