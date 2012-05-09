namespace PixelCryptor.UI {
	partial class FormAbout {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
			this.lnkWebsite = new System.Windows.Forms.LinkLabel();
			this.lblUrl = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblVersion = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblCreators = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblCopyright = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblDisclaimer = new PixelCryptor.UI.WinControls.CGLabel();
			this.picLogo = new PixelCryptor.UI.WinControls.CGPicture();
			this.lblApplicationName = new PixelCryptor.UI.WinControls.CGLabel();
			((System.ComponentModel.ISupportInitialize) (this.picLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// lnkWebsite
			// 
			this.lnkWebsite.ActiveLinkColor = System.Drawing.Color.White;
			this.lnkWebsite.AutoSize = true;
			this.lnkWebsite.BackColor = System.Drawing.Color.Transparent;
			this.lnkWebsite.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkWebsite.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lnkWebsite.ForeColor = System.Drawing.Color.White;
			this.lnkWebsite.LinkColor = System.Drawing.Color.Transparent;
			this.lnkWebsite.Location = new System.Drawing.Point(200, 154);
			this.lnkWebsite.Name = "lnkWebsite";
			this.lnkWebsite.Size = new System.Drawing.Size(142, 14);
			this.lnkWebsite.TabIndex = 12;
			this.lnkWebsite.TabStop = true;
			this.lnkWebsite.Text = "http://www.codegazer.com";
			this.lnkWebsite.VisitedLinkColor = System.Drawing.Color.White;
			this.lnkWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// lblUrl
			// 
			this.lblUrl.AutoSize = true;
			this.lblUrl.BackColor = System.Drawing.Color.Transparent;
			this.lblUrl.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblUrl.ForeColor = System.Drawing.Color.White;
			this.lblUrl.Location = new System.Drawing.Point(103, 154);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(101, 14);
			this.lblUrl.TabIndex = 11;
			this.lblUrl.Text = "Visit our website at";
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblVersion.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblVersion.ForeColor = System.Drawing.Color.White;
			this.lblVersion.Location = new System.Drawing.Point(9, 112);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(62, 14);
			this.lblVersion.TabIndex = 10;
			this.lblVersion.Text = "Version {0}";
			// 
			// lblCreators
			// 
			this.lblCreators.AutoSize = true;
			this.lblCreators.BackColor = System.Drawing.Color.Transparent;
			this.lblCreators.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblCreators.ForeColor = System.Drawing.Color.White;
			this.lblCreators.Location = new System.Drawing.Point(9, 88);
			this.lblCreators.Name = "lblCreators";
			this.lblCreators.Size = new System.Drawing.Size(230, 14);
			this.lblCreators.TabIndex = 8;
			this.lblCreators.Text = "Created by Bernd de Graaf and Yvo van Beek";
			// 
			// lblCopyright
			// 
			this.lblCopyright.AutoSize = true;
			this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
			this.lblCopyright.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblCopyright.ForeColor = System.Drawing.Color.White;
			this.lblCopyright.Location = new System.Drawing.Point(9, 74);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(70, 14);
			this.lblCopyright.TabIndex = 6;
			this.lblCopyright.Text = "Copyright {0}";
			// 
			// lblDisclaimer
			// 
			this.lblDisclaimer.BackColor = System.Drawing.Color.Transparent;
			this.lblDisclaimer.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblDisclaimer.ForeColor = System.Drawing.Color.White;
			this.lblDisclaimer.Location = new System.Drawing.Point(9, 169);
			this.lblDisclaimer.Name = "lblDisclaimer";
			this.lblDisclaimer.Size = new System.Drawing.Size(423, 66);
			this.lblDisclaimer.TabIndex = 4;
			this.lblDisclaimer.Text = resources.GetString("lblDisclaimer.Text");
			this.lblDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picLogo
			// 
			this.picLogo.BackColor = System.Drawing.Color.Transparent;
			this.picLogo.Image = global::PixelCryptor.Properties.Resources.Logo64x64;
			this.picLogo.Location = new System.Drawing.Point(3, 8);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(64, 64);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picLogo.TabIndex = 2;
			this.picLogo.TabStop = false;
			this.picLogo.WaitOnLoad = true;
			// 
			// lblApplicationName
			// 
			this.lblApplicationName.AutoSize = true;
			this.lblApplicationName.BackColor = System.Drawing.Color.Transparent;
			this.lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblApplicationName.ForeColor = System.Drawing.Color.White;
			this.lblApplicationName.Location = new System.Drawing.Point(62, 20);
			this.lblApplicationName.Name = "lblApplicationName";
			this.lblApplicationName.Size = new System.Drawing.Size(174, 31);
			this.lblApplicationName.TabIndex = 0;
			this.lblApplicationName.Text = "PixelCryptor";
			// 
			// FormAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::PixelCryptor.Properties.Resources.BackgroundAbout;
			this.ClientSize = new System.Drawing.Size(444, 238);
			this.Controls.Add(this.lnkWebsite);
			this.Controls.Add(this.lblUrl);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblCreators);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.lblDisclaimer);
			this.Controls.Add(this.picLogo);
			this.Controls.Add(this.lblApplicationName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About PixelCryptor";
			((System.ComponentModel.ISupportInitialize) (this.picLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PixelCryptor.UI.WinControls.CGLabel lblApplicationName;
		private PixelCryptor.UI.WinControls.CGPicture picLogo;
		private PixelCryptor.UI.WinControls.CGLabel lblDisclaimer;
		private PixelCryptor.UI.WinControls.CGLabel lblCopyright;
		private PixelCryptor.UI.WinControls.CGLabel lblCreators;
		private PixelCryptor.UI.WinControls.CGLabel lblVersion;
		private PixelCryptor.UI.WinControls.CGLabel lblUrl;
		private System.Windows.Forms.LinkLabel lnkWebsite;

	}
}
