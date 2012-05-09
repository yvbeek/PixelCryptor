namespace PixelCryptor.UI {
	partial class ScreenDecodeFinished {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenDecodeFinished));
			this.lblHeader = new System.Windows.Forms.Label();
			this.grpPackage = new System.Windows.Forms.GroupBox();
			this.lnkOpenPackage = new PixelCryptor.UI.WinControls.CGPicture();
			this.lblFilesAndFolders = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblPackageSize = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblDestinationFolderName = new PixelCryptor.UI.WinControls.CGLabel();
			this.cgPicture1 = new PixelCryptor.UI.WinControls.CGPicture();
			this.ttpTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.lblText1 = new System.Windows.Forms.Label();
			this.lblThankYou = new System.Windows.Forms.Label();
			this.lnkWebsite = new System.Windows.Forms.LinkLabel();
			this.grpPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkOpenPackage)).BeginInit();
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
			this.lblHeader.Size = new System.Drawing.Size(397, 14);
			this.lblHeader.TabIndex = 3;
			this.lblHeader.Text = "Decoding - The files and folders were decoded successfully";
			// 
			// grpPackage
			// 
			this.grpPackage.Controls.Add(this.lnkOpenPackage);
			this.grpPackage.Controls.Add(this.lblFilesAndFolders);
			this.grpPackage.Controls.Add(this.lblPackageSize);
			this.grpPackage.Controls.Add(this.lblDestinationFolderName);
			this.grpPackage.Controls.Add(this.cgPicture1);
			this.grpPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.grpPackage.ForeColor = System.Drawing.Color.White;
			this.grpPackage.Location = new System.Drawing.Point(185, 123);
			this.grpPackage.Name = "grpPackage";
			this.grpPackage.Size = new System.Drawing.Size(370, 98);
			this.grpPackage.TabIndex = 8;
			this.grpPackage.TabStop = false;
			this.grpPackage.Text = "The contents";
			// 
			// lnkOpenPackage
			// 
			this.lnkOpenPackage.BackColor = System.Drawing.Color.Transparent;
			this.lnkOpenPackage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkOpenPackage.Image = global::PixelCryptor.Properties.Resources.ButtonGo;
			this.lnkOpenPackage.Location = new System.Drawing.Point(343, 71);
			this.lnkOpenPackage.Name = "lnkOpenPackage";
			this.lnkOpenPackage.Size = new System.Drawing.Size(21, 21);
			this.lnkOpenPackage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.lnkOpenPackage.TabIndex = 9;
			this.lnkOpenPackage.TabStop = false;
			this.lnkOpenPackage.WaitOnLoad = true;
			this.lnkOpenPackage.Click += new System.EventHandler(this.lnkOpenPackage_Click);
			// 
			// lblFilesAndFolders
			// 
			this.lblFilesAndFolders.AutoSize = true;
			this.lblFilesAndFolders.BackColor = System.Drawing.Color.Transparent;
			this.lblFilesAndFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblFilesAndFolders.Location = new System.Drawing.Point(79, 47);
			this.lblFilesAndFolders.Name = "lblFilesAndFolders";
			this.lblFilesAndFolders.Size = new System.Drawing.Size(103, 13);
			this.lblFilesAndFolders.TabIndex = 8;
			this.lblFilesAndFolders.Text = "File and folder count";
			// 
			// lblPackageSize
			// 
			this.lblPackageSize.AutoSize = true;
			this.lblPackageSize.BackColor = System.Drawing.Color.Transparent;
			this.lblPackageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblPackageSize.Location = new System.Drawing.Point(79, 64);
			this.lblPackageSize.Name = "lblPackageSize";
			this.lblPackageSize.Size = new System.Drawing.Size(70, 13);
			this.lblPackageSize.TabIndex = 7;
			this.lblPackageSize.Text = "PackageSize";
			// 
			// lblDestinationFolderName
			// 
			this.lblDestinationFolderName.AutoSize = true;
			this.lblDestinationFolderName.BackColor = System.Drawing.Color.Transparent;
			this.lblDestinationFolderName.Location = new System.Drawing.Point(79, 29);
			this.lblDestinationFolderName.Name = "lblDestinationFolderName";
			this.lblDestinationFolderName.Size = new System.Drawing.Size(161, 15);
			this.lblDestinationFolderName.TabIndex = 6;
			this.lblDestinationFolderName.Text = "Destination folder name";
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
			this.lblText1.Size = new System.Drawing.Size(709, 28);
			this.lblText1.TabIndex = 10;
			this.lblText1.Text = resources.GetString("lblText1.Text");
			// 
			// lblThankYou
			// 
			this.lblThankYou.AutoSize = true;
			this.lblThankYou.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblThankYou.ForeColor = System.Drawing.Color.White;
			this.lblThankYou.Location = new System.Drawing.Point(218, 277);
			this.lblThankYou.Margin = new System.Windows.Forms.Padding(0);
			this.lblThankYou.Name = "lblThankYou";
			this.lblThankYou.Size = new System.Drawing.Size(306, 26);
			this.lblThankYou.TabIndex = 11;
			this.lblThankYou.Text = "Thank you for using our product.\r\nPlease let us know what you think of our produc" +
				"t at:";
			this.lblThankYou.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lnkWebsite
			// 
			this.lnkWebsite.ActiveLinkColor = System.Drawing.Color.White;
			this.lnkWebsite.AutoSize = true;
			this.lnkWebsite.BackColor = System.Drawing.Color.Transparent;
			this.lnkWebsite.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkWebsite.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.lnkWebsite.ForeColor = System.Drawing.Color.White;
			this.lnkWebsite.LinkColor = System.Drawing.Color.Transparent;
			this.lnkWebsite.Location = new System.Drawing.Point(287, 303);
			this.lnkWebsite.Name = "lnkWebsite";
			this.lnkWebsite.Size = new System.Drawing.Size(162, 13);
			this.lnkWebsite.TabIndex = 13;
			this.lnkWebsite.TabStop = true;
			this.lnkWebsite.Text = "http://www.codegazer.com";
			this.lnkWebsite.VisitedLinkColor = System.Drawing.Color.White;
			this.lnkWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebsite_LinkClicked);
			// 
			// ScreenDecodeFinished
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.lnkWebsite);
			this.Controls.Add(this.lblThankYou);
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.grpPackage);
			this.Controls.Add(this.lblHeader);
			this.Name = "ScreenDecodeFinished";
			this.grpPackage.ResumeLayout(false);
			this.grpPackage.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkOpenPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.GroupBox grpPackage;
		private PixelCryptor.UI.WinControls.CGPicture lnkOpenPackage;
		private PixelCryptor.UI.WinControls.CGLabel lblFilesAndFolders;
		private PixelCryptor.UI.WinControls.CGLabel lblPackageSize;
		private PixelCryptor.UI.WinControls.CGLabel lblDestinationFolderName;
		private PixelCryptor.UI.WinControls.CGPicture cgPicture1;
		private System.Windows.Forms.ToolTip ttpTooltip;
		private System.Windows.Forms.Label lblText1;
		private System.Windows.Forms.Label lblThankYou;
		private System.Windows.Forms.LinkLabel lnkWebsite;
	}
}
