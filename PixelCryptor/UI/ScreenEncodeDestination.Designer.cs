namespace PixelCryptor.UI {
    partial class ScreenEncodeDestination {
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
			this.dlgSelectCodeFile = new System.Windows.Forms.SaveFileDialog();
			this.grpPackage = new System.Windows.Forms.GroupBox();
			this.txtCodeFilePath = new System.Windows.Forms.TextBox();
			this.lnkSelectCodeFile = new PixelCryptor.UI.WinControls.CGPicture();
			this.cgPicture1 = new PixelCryptor.UI.WinControls.CGPicture();
			this.ttpTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.lblText1 = new System.Windows.Forms.Label();
			this.grpPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkSelectCodeFile)).BeginInit();
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
			this.lblHeader.Size = new System.Drawing.Size(317, 14);
			this.lblHeader.TabIndex = 2;
			this.lblHeader.Text = "Encoding - Select a destination for the package";
			// 
			// dlgSelectCodeFile
			// 
			this.dlgSelectCodeFile.Filter = "PixelCryptor files (*.cgp)|*.cgp";
			// 
			// grpPackage
			// 
			this.grpPackage.Controls.Add(this.txtCodeFilePath);
			this.grpPackage.Controls.Add(this.lnkSelectCodeFile);
			this.grpPackage.Controls.Add(this.cgPicture1);
			this.grpPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.grpPackage.ForeColor = System.Drawing.Color.White;
			this.grpPackage.Location = new System.Drawing.Point(185, 145);
			this.grpPackage.Name = "grpPackage";
			this.grpPackage.Size = new System.Drawing.Size(370, 98);
			this.grpPackage.TabIndex = 9;
			this.grpPackage.TabStop = false;
			this.grpPackage.Text = "The destination file";
			// 
			// txtCodeFilePath
			// 
			this.txtCodeFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.txtCodeFilePath.Location = new System.Drawing.Point(82, 44);
			this.txtCodeFilePath.Name = "txtCodeFilePath";
			this.txtCodeFilePath.ReadOnly = true;
			this.txtCodeFilePath.Size = new System.Drawing.Size(240, 20);
			this.txtCodeFilePath.TabIndex = 10;
			// 
			// lnkSelectCodeFile
			// 
			this.lnkSelectCodeFile.BackColor = System.Drawing.Color.Transparent;
			this.lnkSelectCodeFile.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkSelectCodeFile.Image = global::PixelCryptor.Properties.Resources.ButtonBrowse;
			this.lnkSelectCodeFile.Location = new System.Drawing.Point(326, 44);
			this.lnkSelectCodeFile.Name = "lnkSelectCodeFile";
			this.lnkSelectCodeFile.Size = new System.Drawing.Size(21, 21);
			this.lnkSelectCodeFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.lnkSelectCodeFile.TabIndex = 9;
			this.lnkSelectCodeFile.TabStop = false;
			this.lnkSelectCodeFile.WaitOnLoad = true;
			this.lnkSelectCodeFile.Click += new System.EventHandler(this.lnkSelectCodeFile_Click);
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
			// lblText1
			// 
			this.lblText1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblText1.ForeColor = System.Drawing.Color.White;
			this.lblText1.Location = new System.Drawing.Point(11, 24);
			this.lblText1.Margin = new System.Windows.Forms.Padding(0);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(424, 27);
			this.lblText1.TabIndex = 10;
			this.lblText1.Text = "PixelCryptor will encrypt your files and folders into one CGP file.\r\nClick on the" +
				" small browse icon to select a location for the package.";
			// 
			// ScreenEncodeDestination
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.grpPackage);
			this.Controls.Add(this.lblHeader);
			this.Name = "ScreenEncodeDestination";
			this.grpPackage.ResumeLayout(false);
			this.grpPackage.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.lnkSelectCodeFile)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.cgPicture1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.SaveFileDialog dlgSelectCodeFile;
		private System.Windows.Forms.GroupBox grpPackage;
		private System.Windows.Forms.TextBox txtCodeFilePath;
		private PixelCryptor.UI.WinControls.CGPicture lnkSelectCodeFile;
		private PixelCryptor.UI.WinControls.CGPicture cgPicture1;
		private System.Windows.Forms.ToolTip ttpTooltip;
		private System.Windows.Forms.Label lblText1;
    }
}
