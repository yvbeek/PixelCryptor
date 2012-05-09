namespace PixelCryptor.UI {
	partial class ScreenDecodeDestination {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.lblHeader = new System.Windows.Forms.Label();
			this.dlgSelectDestinationFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.grpPackage = new System.Windows.Forms.GroupBox();
			this.txtDestinationFolderPath = new System.Windows.Forms.TextBox();
			this.lnkSelectDestinationFolder = new PixelCryptor.UI.WinControls.CGPicture();
			this.cgPicture1 = new PixelCryptor.UI.WinControls.CGPicture();
			this.ttpTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.lblText1 = new System.Windows.Forms.Label();
			this.grpPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkSelectDestinationFolder)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblHeader.ForeColor = System.Drawing.Color.White;
			this.lblHeader.Location = new System.Drawing.Point(11, 10);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(379, 14);
			this.lblHeader.TabIndex = 2;
			this.lblHeader.Text = "Decoding - Select a destination for the package contents";
			// 
			// grpPackage
			// 
			this.grpPackage.Controls.Add(this.txtDestinationFolderPath);
			this.grpPackage.Controls.Add(this.lnkSelectDestinationFolder);
			this.grpPackage.Controls.Add(this.cgPicture1);
			this.grpPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.grpPackage.ForeColor = System.Drawing.Color.White;
			this.grpPackage.Location = new System.Drawing.Point(185, 145);
			this.grpPackage.Name = "grpPackage";
			this.grpPackage.Size = new System.Drawing.Size(370, 98);
			this.grpPackage.TabIndex = 8;
			this.grpPackage.TabStop = false;
			this.grpPackage.Text = "The destination folder";
			// 
			// txtCodeFilePath
			// 
			this.txtDestinationFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.txtDestinationFolderPath.Location = new System.Drawing.Point(82, 44);
			this.txtDestinationFolderPath.Name = "txtCodeFilePath";
			this.txtDestinationFolderPath.ReadOnly = true;
			this.txtDestinationFolderPath.Size = new System.Drawing.Size(240, 20);
			this.txtDestinationFolderPath.TabIndex = 10;
			// 
			// lnkSelectDestinationFolder
			// 
			this.lnkSelectDestinationFolder.BackColor = System.Drawing.Color.Transparent;
			this.lnkSelectDestinationFolder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkSelectDestinationFolder.Image = global::PixelCryptor.Properties.Resources.ButtonBrowse;
			this.lnkSelectDestinationFolder.Location = new System.Drawing.Point(326, 44);
			this.lnkSelectDestinationFolder.Name = "lnkSelectDestinationFolder";
			this.lnkSelectDestinationFolder.Size = new System.Drawing.Size(21, 21);
			this.lnkSelectDestinationFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.lnkSelectDestinationFolder.TabIndex = 9;
			this.lnkSelectDestinationFolder.TabStop = false;
			this.lnkSelectDestinationFolder.WaitOnLoad = true;
			this.lnkSelectDestinationFolder.Click += new System.EventHandler(this.lnkSelectDestinationFolder_Click);
			// 
			// cgPicture1
			// 
			this.cgPicture1.BackColor = System.Drawing.Color.Transparent;
			this.cgPicture1.Image = global::PixelCryptor.Properties.Resources.DestinationFolder;
			this.cgPicture1.Location = new System.Drawing.Point(9, 22);
			this.cgPicture1.Name = "cgPicture1";
			this.cgPicture1.Size = new System.Drawing.Size(64, 64);
			this.cgPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.cgPicture1.TabIndex = 5;
			this.cgPicture1.TabStop = false;
			this.cgPicture1.WaitOnLoad = true;
			// 
			// lblText1
			// 
			this.lblText1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblText1.ForeColor = System.Drawing.Color.White;
			this.lblText1.Location = new System.Drawing.Point(11, 24);
			this.lblText1.Margin = new System.Windows.Forms.Padding(0);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(462, 27);
			this.lblText1.TabIndex = 11;
			this.lblText1.Text = "PixelCryptor will decrypt your files and folders to the folder you select.\r\nClick" +
				" on the small browse icon to select a location for content the package.";
			// 
			// ScreenDecodeDestination
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.grpPackage);
			this.Controls.Add(this.lblHeader);
			this.Name = "ScreenDecodeDestination";
			this.grpPackage.ResumeLayout(false);
			this.grpPackage.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkSelectDestinationFolder)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.FolderBrowserDialog dlgSelectDestinationFolder;
		private System.Windows.Forms.GroupBox grpPackage;
		private System.Windows.Forms.TextBox txtDestinationFolderPath;
		private PixelCryptor.UI.WinControls.CGPicture lnkSelectDestinationFolder;
		private PixelCryptor.UI.WinControls.CGPicture cgPicture1;
		private System.Windows.Forms.ToolTip ttpTooltip;
		private System.Windows.Forms.Label lblText1;
	}
}
