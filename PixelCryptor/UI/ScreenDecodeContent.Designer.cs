namespace PixelCryptor.UI {
	partial class ScreenDecodeContent {
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
			this.lblHeader = new System.Windows.Forms.Label();
			this.ffsSelector = new PixelCryptor.UI.FileFolderSelector();
			this.dlgSelectCodeFile = new System.Windows.Forms.OpenFileDialog();
			this.txtCodeFilePath = new System.Windows.Forms.TextBox();
			this.lnkSelectCodeFile = new PixelCryptor.UI.WinControls.CGPicture();
			this.lblText1 = new System.Windows.Forms.Label();
			this.lblText2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) (this.lnkSelectCodeFile)).BeginInit();
			this.SuspendLayout();
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblHeader.ForeColor = System.Drawing.Color.White;
			this.lblHeader.Location = new System.Drawing.Point(11, 10);
			this.lblHeader.Margin = new System.Windows.Forms.Padding(0);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(275, 14);
			this.lblHeader.TabIndex = 2;
			this.lblHeader.Text = "Decoding - Select the package to decode";
			// 
			// ffsSelector
			// 
			this.ffsSelector.AllowDrop = true;
			this.ffsSelector.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ffsSelector.Location = new System.Drawing.Point(14, 103);
			this.ffsSelector.Mode = PixelCryptor.UI.FileFolderSelector.OperationMode.ReadOnly;
			this.ffsSelector.Name = "ffsSelector";
			this.ffsSelector.Package = null;
			this.ffsSelector.Size = new System.Drawing.Size(706, 264);
			this.ffsSelector.TabIndex = 3;
			// 
			// dlgSelectCodeFile
			// 
			this.dlgSelectCodeFile.Filter = "PixelCryptor files (*.cgp)|*.cgp";
			// 
			// txtCodeFilePath
			// 
			this.txtCodeFilePath.Location = new System.Drawing.Point(14, 49);
			this.txtCodeFilePath.Name = "txtCodeFilePath";
			this.txtCodeFilePath.ReadOnly = true;
			this.txtCodeFilePath.ShortcutsEnabled = false;
			this.txtCodeFilePath.Size = new System.Drawing.Size(465, 20);
			this.txtCodeFilePath.TabIndex = 7;
			this.txtCodeFilePath.WordWrap = false;
			// 
			// lnkSelectCodeFile
			// 
			this.lnkSelectCodeFile.BackColor = System.Drawing.Color.Transparent;
			this.lnkSelectCodeFile.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkSelectCodeFile.Image = global::PixelCryptor.Properties.Resources.ButtonBrowse;
			this.lnkSelectCodeFile.Location = new System.Drawing.Point(483, 49);
			this.lnkSelectCodeFile.Name = "lnkSelectCodeFile";
			this.lnkSelectCodeFile.Size = new System.Drawing.Size(21, 21);
			this.lnkSelectCodeFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.lnkSelectCodeFile.TabIndex = 10;
			this.lnkSelectCodeFile.TabStop = false;
			this.lnkSelectCodeFile.WaitOnLoad = true;
			this.lnkSelectCodeFile.Click += new System.EventHandler(this.lnkSelectCodeFile_Click);
			// 
			// lblText1
			// 
			this.lblText1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblText1.ForeColor = System.Drawing.Color.White;
			this.lblText1.Location = new System.Drawing.Point(11, 24);
			this.lblText1.Margin = new System.Windows.Forms.Padding(0);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(709, 14);
			this.lblText1.TabIndex = 11;
			this.lblText1.Text = "Use the small browse icon to select a package. The package and image key will be " +
				"combined to check if they match.";
			// 
			// lblText2
			// 
			this.lblText2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblText2.ForeColor = System.Drawing.Color.White;
			this.lblText2.Location = new System.Drawing.Point(11, 79);
			this.lblText2.Margin = new System.Windows.Forms.Padding(0);
			this.lblText2.Name = "lblText2";
			this.lblText2.Size = new System.Drawing.Size(709, 14);
			this.lblText2.TabIndex = 12;
			this.lblText2.Text = "The file/folder view below will show the content of the package on a succesfull m" +
				"atch.";
			// 
			// ScreenDecodeContent
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.lblText2);
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.lnkSelectCodeFile);
			this.Controls.Add(this.txtCodeFilePath);
			this.Controls.Add(this.ffsSelector);
			this.Controls.Add(this.lblHeader);
			this.Name = "ScreenDecodeContent";
			((System.ComponentModel.ISupportInitialize) (this.lnkSelectCodeFile)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label lblHeader;
		private FileFolderSelector ffsSelector;
		private System.Windows.Forms.OpenFileDialog dlgSelectCodeFile;
		private System.Windows.Forms.TextBox txtCodeFilePath;
		private PixelCryptor.UI.WinControls.CGPicture lnkSelectCodeFile;
		private System.Windows.Forms.Label lblText1;
		private System.Windows.Forms.Label lblText2;

    }
}
