namespace PixelCryptor.UI {
	partial class ScreenEncodeImage {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenEncodeImage));
			this.dlgSelectImage = new System.Windows.Forms.OpenFileDialog();
			this.lblHeader = new System.Windows.Forms.Label();
			this.picImage = new PixelCryptor.UI.WinControls.CGPicture();
			this.pnlFrame = new System.Windows.Forms.Panel();
			this.lblText1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) (this.picImage)).BeginInit();
			this.SuspendLayout();
			// 
			// dlgSelectImage
			// 
			this.dlgSelectImage.Filter = resources.GetString("dlgSelectImage.Filter");
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblHeader.ForeColor = System.Drawing.Color.White;
			this.lblHeader.Location = new System.Drawing.Point(11, 10);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(406, 14);
			this.lblHeader.TabIndex = 1;
			this.lblHeader.Text = "Encoding - Select which image to use for the encode process";
			// 
			// picImage
			// 
			this.picImage.BackColor = System.Drawing.Color.White;
			this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picImage.Image = global::PixelCryptor.Properties.Resources.ImageNoSelection;
			this.picImage.Location = new System.Drawing.Point(170, 102);
			this.picImage.Name = "picImage";
			this.picImage.Size = new System.Drawing.Size(400, 223);
			this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picImage.TabIndex = 5;
			this.picImage.TabStop = false;
			this.picImage.WaitOnLoad = true;
			this.picImage.Click += new System.EventHandler(this.picImage_Click);
			// 
			// pnlFrame
			// 
			this.pnlFrame.BackgroundImage = global::PixelCryptor.Properties.Resources.ImageFrame;
			this.pnlFrame.Location = new System.Drawing.Point(155, 89);
			this.pnlFrame.Name = "pnlFrame";
			this.pnlFrame.Size = new System.Drawing.Size(430, 250);
			this.pnlFrame.TabIndex = 6;
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
			// ScreenEncodeImage
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.picImage);
			this.Controls.Add(this.pnlFrame);
			this.Controls.Add(this.lblHeader);
			this.MinimumSize = new System.Drawing.Size(0, 0);
			this.Name = "ScreenEncodeImage";
			((System.ComponentModel.ISupportInitialize) (this.picImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.OpenFileDialog dlgSelectImage;
		private System.Windows.Forms.Label lblHeader;
		private PixelCryptor.UI.WinControls.CGPicture picImage;
		private System.Windows.Forms.Panel pnlFrame;
		private System.Windows.Forms.Label lblText1;
	}
}
