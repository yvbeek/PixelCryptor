namespace PixelCryptor.UI {
	partial class ScreenEncodeFinished {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenEncodeFinished));
			this.lblHeader = new System.Windows.Forms.Label();
			this.grpPackage = new System.Windows.Forms.GroupBox();
			this.lnkOpenPackage = new PixelCryptor.UI.WinControls.CGPicture();
			this.lblFilesAndFolders = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblPackageSize = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblPackageFileName = new PixelCryptor.UI.WinControls.CGLabel();
			this.cgPicture1 = new PixelCryptor.UI.WinControls.CGPicture();
			this.grpKey = new System.Windows.Forms.GroupBox();
			this.lblKeyDimension = new PixelCryptor.UI.WinControls.CGLabel();
			this.lnkOpenKey = new PixelCryptor.UI.WinControls.CGPicture();
			this.lblKeySize = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblKeyFileName = new PixelCryptor.UI.WinControls.CGLabel();
			this.cgPicture2 = new PixelCryptor.UI.WinControls.CGPicture();
			this.ttpTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.lblText1 = new System.Windows.Forms.Label();
			this.lnkWebsite = new System.Windows.Forms.LinkLabel();
			this.lblThankYou = new System.Windows.Forms.Label();
			this.grpPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkOpenPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture1)).BeginInit();
			this.grpKey.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkOpenKey)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture2)).BeginInit();
			this.SuspendLayout();
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblHeader.ForeColor = System.Drawing.Color.White;
			this.lblHeader.Location = new System.Drawing.Point(11, 10);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(403, 14);
			this.lblHeader.TabIndex = 3;
			this.lblHeader.Text = "Encoding - Your files and folders were encoded successfully";
			// 
			// grpPackage
			// 
			this.grpPackage.Controls.Add(this.lnkOpenPackage);
			this.grpPackage.Controls.Add(this.lblFilesAndFolders);
			this.grpPackage.Controls.Add(this.lblPackageSize);
			this.grpPackage.Controls.Add(this.lblPackageFileName);
			this.grpPackage.Controls.Add(this.cgPicture1);
			this.grpPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.grpPackage.ForeColor = System.Drawing.Color.White;
			this.grpPackage.Location = new System.Drawing.Point(185, 76);
			this.grpPackage.Name = "grpPackage";
			this.grpPackage.Size = new System.Drawing.Size(370, 98);
			this.grpPackage.TabIndex = 7;
			this.grpPackage.TabStop = false;
			this.grpPackage.Text = "The package";
			// 
			// lnkOpenPackage
			// 
			this.lnkOpenPackage.BackColor = System.Drawing.Color.Transparent;
			this.lnkOpenPackage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkOpenPackage.Image = ((System.Drawing.Image) (resources.GetObject("lnkOpenPackage.Image")));
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
			this.lblFilesAndFolders.Location = new System.Drawing.Point(79, 45);
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
			this.lblPackageSize.Location = new System.Drawing.Point(79, 61);
			this.lblPackageSize.Name = "lblPackageSize";
			this.lblPackageSize.Size = new System.Drawing.Size(70, 13);
			this.lblPackageSize.TabIndex = 7;
			this.lblPackageSize.Text = "PackageSize";
			// 
			// lblPackageFileName
			// 
			this.lblPackageFileName.AutoSize = true;
			this.lblPackageFileName.BackColor = System.Drawing.Color.Transparent;
			this.lblPackageFileName.Location = new System.Drawing.Point(79, 27);
			this.lblPackageFileName.Name = "lblPackageFileName";
			this.lblPackageFileName.Size = new System.Drawing.Size(102, 15);
			this.lblPackageFileName.TabIndex = 6;
			this.lblPackageFileName.Text = "Package name";
			// 
			// cgPicture1
			// 
			this.cgPicture1.BackColor = System.Drawing.Color.Transparent;
			this.cgPicture1.Image = global::PixelCryptor.Properties.Resources.Logo64x64;
			this.cgPicture1.Location = new System.Drawing.Point(9, 22);
			this.cgPicture1.Name = "cgPicture1";
			this.cgPicture1.Size = new System.Drawing.Size(64, 64);
			this.cgPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.cgPicture1.TabIndex = 5;
			this.cgPicture1.TabStop = false;
			this.cgPicture1.WaitOnLoad = true;
			// 
			// grpKey
			// 
			this.grpKey.Controls.Add(this.lblKeyDimension);
			this.grpKey.Controls.Add(this.lnkOpenKey);
			this.grpKey.Controls.Add(this.lblKeySize);
			this.grpKey.Controls.Add(this.lblKeyFileName);
			this.grpKey.Controls.Add(this.cgPicture2);
			this.grpKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.grpKey.ForeColor = System.Drawing.Color.White;
			this.grpKey.Location = new System.Drawing.Point(185, 194);
			this.grpKey.Name = "grpKey";
			this.grpKey.Size = new System.Drawing.Size(370, 98);
			this.grpKey.TabIndex = 8;
			this.grpKey.TabStop = false;
			this.grpKey.Text = "The image key";
			// 
			// lblKeyDimension
			// 
			this.lblKeyDimension.AutoSize = true;
			this.lblKeyDimension.BackColor = System.Drawing.Color.Transparent;
			this.lblKeyDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblKeyDimension.Location = new System.Drawing.Point(79, 48);
			this.lblKeyDimension.Name = "lblKeyDimension";
			this.lblKeyDimension.Size = new System.Drawing.Size(74, 13);
			this.lblKeyDimension.TabIndex = 11;
			this.lblKeyDimension.Text = "KeyDimension";
			// 
			// lnkOpenKey
			// 
			this.lnkOpenKey.BackColor = System.Drawing.Color.Transparent;
			this.lnkOpenKey.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkOpenKey.Image = ((System.Drawing.Image) (resources.GetObject("lnkOpenKey.Image")));
			this.lnkOpenKey.Location = new System.Drawing.Point(343, 71);
			this.lnkOpenKey.Name = "lnkOpenKey";
			this.lnkOpenKey.Size = new System.Drawing.Size(21, 21);
			this.lnkOpenKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.lnkOpenKey.TabIndex = 10;
			this.lnkOpenKey.TabStop = false;
			this.lnkOpenKey.WaitOnLoad = true;
			this.lnkOpenKey.Click += new System.EventHandler(this.lnkOpenKey_Click);
			// 
			// lblKeySize
			// 
			this.lblKeySize.AutoSize = true;
			this.lblKeySize.BackColor = System.Drawing.Color.Transparent;
			this.lblKeySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblKeySize.Location = new System.Drawing.Point(79, 63);
			this.lblKeySize.Name = "lblKeySize";
			this.lblKeySize.Size = new System.Drawing.Size(45, 13);
			this.lblKeySize.TabIndex = 9;
			this.lblKeySize.Text = "KeySize";
			// 
			// lblKeyFileName
			// 
			this.lblKeyFileName.AutoSize = true;
			this.lblKeyFileName.BackColor = System.Drawing.Color.Transparent;
			this.lblKeyFileName.Location = new System.Drawing.Point(79, 31);
			this.lblKeyFileName.Name = "lblKeyFileName";
			this.lblKeyFileName.Size = new System.Drawing.Size(70, 15);
			this.lblKeyFileName.TabIndex = 7;
			this.lblKeyFileName.Text = "Key name";
			// 
			// cgPicture2
			// 
			this.cgPicture2.BackColor = System.Drawing.Color.Transparent;
			this.cgPicture2.Image = ((System.Drawing.Image) (resources.GetObject("cgPicture2.Image")));
			this.cgPicture2.Location = new System.Drawing.Point(9, 22);
			this.cgPicture2.Name = "cgPicture2";
			this.cgPicture2.Size = new System.Drawing.Size(64, 64);
			this.cgPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.cgPicture2.TabIndex = 5;
			this.cgPicture2.TabStop = false;
			this.cgPicture2.WaitOnLoad = true;
			// 
			// lblText1
			// 
			this.lblText1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblText1.ForeColor = System.Drawing.Color.White;
			this.lblText1.Location = new System.Drawing.Point(11, 24);
			this.lblText1.Margin = new System.Windows.Forms.Padding(0);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(709, 28);
			this.lblText1.TabIndex = 9;
			this.lblText1.Text = "Congratulations the encryption process completed successfully. Below you can see " +
				"the package and key information. Click on the small arrows to jump to the folder" +
				" containing the package/key. ";
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
			this.lnkWebsite.Location = new System.Drawing.Point(287, 344);
			this.lnkWebsite.Name = "lnkWebsite";
			this.lnkWebsite.Size = new System.Drawing.Size(162, 13);
			this.lnkWebsite.TabIndex = 15;
			this.lnkWebsite.TabStop = true;
			this.lnkWebsite.Text = "http://www.codegazer.com";
			this.lnkWebsite.VisitedLinkColor = System.Drawing.Color.White;
			this.lnkWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebsite_LinkClicked);
			// 
			// lblThankYou
			// 
			this.lblThankYou.AutoSize = true;
			this.lblThankYou.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblThankYou.ForeColor = System.Drawing.Color.White;
			this.lblThankYou.Location = new System.Drawing.Point(218, 317);
			this.lblThankYou.Margin = new System.Windows.Forms.Padding(0);
			this.lblThankYou.Name = "lblThankYou";
			this.lblThankYou.Size = new System.Drawing.Size(306, 26);
			this.lblThankYou.TabIndex = 14;
			this.lblThankYou.Text = "Thank you for using our product.\r\nPlease let us know what you think of our produc" +
				"t at:";
			this.lblThankYou.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ScreenEncodeFinished
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.lnkWebsite);
			this.Controls.Add(this.lblThankYou);
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.grpKey);
			this.Controls.Add(this.grpPackage);
			this.Controls.Add(this.lblHeader);
			this.Name = "ScreenEncodeFinished";
			this.grpPackage.ResumeLayout(false);
			this.grpPackage.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkOpenPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture1)).EndInit();
			this.grpKey.ResumeLayout(false);
			this.grpKey.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkOpenKey)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.GroupBox grpPackage;
		private PixelCryptor.UI.WinControls.CGPicture cgPicture1;
		private System.Windows.Forms.GroupBox grpKey;
		private PixelCryptor.UI.WinControls.CGPicture cgPicture2;
		private PixelCryptor.UI.WinControls.CGLabel lblPackageSize;
		private PixelCryptor.UI.WinControls.CGLabel lblPackageFileName;
		private PixelCryptor.UI.WinControls.CGLabel lblFilesAndFolders;
		private PixelCryptor.UI.WinControls.CGLabel lblKeySize;
		private PixelCryptor.UI.WinControls.CGLabel lblKeyFileName;
		private PixelCryptor.UI.WinControls.CGPicture lnkOpenPackage;
		private PixelCryptor.UI.WinControls.CGPicture lnkOpenKey;
		private PixelCryptor.UI.WinControls.CGLabel lblKeyDimension;
		private System.Windows.Forms.ToolTip ttpTooltip;
		private System.Windows.Forms.Label lblText1;
		private System.Windows.Forms.LinkLabel lnkWebsite;
		private System.Windows.Forms.Label lblThankYou;
	}
}
