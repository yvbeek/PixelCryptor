namespace PixelCryptor.UI {
	partial class FormMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.hlpProvider = new System.Windows.Forms.HelpProvider();
			this.pnlMain = new PixelCryptor.UI.WinControls.CGPanel();
			this.picEncode = new PixelCryptor.UI.WinControls.CGPicture();
			this.lblSelectionDescription = new PixelCryptor.UI.WinControls.CGLabel();
			this.lblSelectionHeader = new PixelCryptor.UI.WinControls.CGLabel();
			this.picDecode = new PixelCryptor.UI.WinControls.CGPicture();
			this.picHelp = new PixelCryptor.UI.WinControls.CGPicture();
			this.picAbout = new PixelCryptor.UI.WinControls.CGPicture();
			this.pnlWizard = new PixelCryptor.UI.WinControls.CGPanel();
			this.btnMain = new PixelCryptor.UI.WinControls.CGButton();
			this.btnPrevious = new PixelCryptor.UI.WinControls.CGButton();
			this.btnNext = new PixelCryptor.UI.WinControls.CGButton();
			this.scrEncodeContent = new PixelCryptor.UI.ScreenEncodeContent();
			this.scrEncodeImage = new PixelCryptor.UI.ScreenEncodeImage();
			this.scrEncodeDestination = new PixelCryptor.UI.ScreenEncodeDestination();
			this.scrEncodeProgress = new PixelCryptor.UI.ScreenEncodeProgress();
			this.scrEncodeFinished = new PixelCryptor.UI.ScreenEncodeFinished();
			this.scrDecodeImage = new PixelCryptor.UI.ScreenDecodeImage();
			this.scrDecodeContent = new PixelCryptor.UI.ScreenDecodeContent();
			this.scrDecodeDestination = new PixelCryptor.UI.ScreenDecodeDestination();
			this.scrDecodeProgress = new PixelCryptor.UI.ScreenDecodeProgress();
			this.scrDecodeFinished = new PixelCryptor.UI.ScreenDecodeFinished();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picEncode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picDecode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
			this.pnlWizard.SuspendLayout();
			this.SuspendLayout();
			// 
			// hlpProvider
			// 
			this.hlpProvider.HelpNamespace = "PixelCryptor.chm";
			// 
			// pnlMain
			// 
			this.pnlMain.BackColor = System.Drawing.Color.Transparent;
			this.pnlMain.Controls.Add(this.picEncode);
			this.pnlMain.Controls.Add(this.lblSelectionDescription);
			this.pnlMain.Controls.Add(this.lblSelectionHeader);
			this.pnlMain.Controls.Add(this.picDecode);
			this.pnlMain.Controls.Add(this.picHelp);
			this.pnlMain.Controls.Add(this.picAbout);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(734, 424);
			this.pnlMain.TabIndex = 9;
			// 
			// picEncode
			// 
			this.picEncode.BackColor = System.Drawing.Color.Transparent;
			this.picEncode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picEncode.Image = ((System.Drawing.Image)(resources.GetObject("picEncode.Image")));
			this.picEncode.Location = new System.Drawing.Point(241, 170);
			this.picEncode.Name = "picEncode";
			this.picEncode.Size = new System.Drawing.Size(100, 100);
			this.picEncode.TabIndex = 16;
			this.picEncode.TabStop = false;
			this.picEncode.WaitOnLoad = true;
			this.picEncode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picEncode_MouseClick);
			this.picEncode.MouseEnter += new System.EventHandler(this.picEncode_MouseEnter);
			this.picEncode.MouseLeave += new System.EventHandler(this.MainItemLeave);
			// 
			// lblSelectionDescription
			// 
			this.lblSelectionDescription.BackColor = System.Drawing.Color.Transparent;
			this.lblSelectionDescription.ForeColor = System.Drawing.Color.White;
			this.lblSelectionDescription.Location = new System.Drawing.Point(167, 350);
			this.lblSelectionDescription.Name = "lblSelectionDescription";
			this.lblSelectionDescription.Size = new System.Drawing.Size(400, 23);
			this.lblSelectionDescription.TabIndex = 15;
			this.lblSelectionDescription.Text = "Item Description";
			this.lblSelectionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSelectionHeader
			// 
			this.lblSelectionHeader.BackColor = System.Drawing.Color.Transparent;
			this.lblSelectionHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSelectionHeader.ForeColor = System.Drawing.Color.White;
			this.lblSelectionHeader.Location = new System.Drawing.Point(167, 309);
			this.lblSelectionHeader.Name = "lblSelectionHeader";
			this.lblSelectionHeader.Size = new System.Drawing.Size(400, 41);
			this.lblSelectionHeader.TabIndex = 14;
			this.lblSelectionHeader.Text = "Item Header";
			this.lblSelectionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// picDecode
			// 
			this.picDecode.BackColor = System.Drawing.Color.Transparent;
			this.picDecode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picDecode.Image = global::PixelCryptor.Properties.Resources.MainDecode;
			this.picDecode.Location = new System.Drawing.Point(411, 170);
			this.picDecode.Name = "picDecode";
			this.picDecode.Size = new System.Drawing.Size(100, 100);
			this.picDecode.TabIndex = 12;
			this.picDecode.TabStop = false;
			this.picDecode.WaitOnLoad = true;
			this.picDecode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDecode_MouseClick);
			this.picDecode.MouseEnter += new System.EventHandler(this.picDecode_MouseEnter);
			this.picDecode.MouseLeave += new System.EventHandler(this.MainItemLeave);
			// 
			// picHelp
			// 
			this.picHelp.BackColor = System.Drawing.Color.Transparent;
			this.picHelp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picHelp.Image = global::PixelCryptor.Properties.Resources.MainHelp;
			this.picHelp.Location = new System.Drawing.Point(592, 199);
			this.picHelp.Name = "picHelp";
			this.picHelp.Size = new System.Drawing.Size(100, 100);
			this.picHelp.TabIndex = 11;
			this.picHelp.TabStop = false;
			this.picHelp.WaitOnLoad = true;
			this.picHelp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
			this.picHelp.MouseEnter += new System.EventHandler(this.picHelp_MouseEnter);
			this.picHelp.MouseLeave += new System.EventHandler(this.MainItemLeave);
			// 
			// picAbout
			// 
			this.picAbout.BackColor = System.Drawing.Color.Transparent;
			this.picAbout.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picAbout.Image = global::PixelCryptor.Properties.Resources.MainAbout;
			this.picAbout.Location = new System.Drawing.Point(52, 200);
			this.picAbout.Name = "picAbout";
			this.picAbout.Size = new System.Drawing.Size(100, 100);
			this.picAbout.TabIndex = 10;
			this.picAbout.TabStop = false;
			this.picAbout.WaitOnLoad = true;
			this.picAbout.Click += new System.EventHandler(this.picAbout_Click);
			this.picAbout.MouseEnter += new System.EventHandler(this.picAbout_MouseEnter);
			this.picAbout.MouseLeave += new System.EventHandler(this.MainItemLeave);
			// 
			// pnlWizard
			// 
			this.pnlWizard.BackColor = System.Drawing.Color.Transparent;
			this.pnlWizard.Controls.Add(this.btnMain);
			this.pnlWizard.Controls.Add(this.btnPrevious);
			this.pnlWizard.Controls.Add(this.btnNext);
			this.pnlWizard.Controls.Add(this.scrEncodeContent);
			this.pnlWizard.Controls.Add(this.scrEncodeImage);
			this.pnlWizard.Controls.Add(this.scrEncodeDestination);
			this.pnlWizard.Controls.Add(this.scrEncodeProgress);
			this.pnlWizard.Controls.Add(this.scrEncodeFinished);
			this.pnlWizard.Controls.Add(this.scrDecodeImage);
			this.pnlWizard.Controls.Add(this.scrDecodeContent);
			this.pnlWizard.Controls.Add(this.scrDecodeDestination);
			this.pnlWizard.Controls.Add(this.scrDecodeProgress);
			this.pnlWizard.Controls.Add(this.scrDecodeFinished);
			this.pnlWizard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlWizard.Location = new System.Drawing.Point(0, 0);
			this.pnlWizard.Margin = new System.Windows.Forms.Padding(0);
			this.pnlWizard.Name = "pnlWizard";
			this.pnlWizard.Size = new System.Drawing.Size(734, 424);
			this.pnlWizard.TabIndex = 9;
			this.pnlWizard.Visible = false;
			// 
			// btnMain
			// 
			this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMain.Location = new System.Drawing.Point(11, 394);
			this.btnMain.Name = "btnMain";
			this.btnMain.Size = new System.Drawing.Size(75, 21);
			this.btnMain.TabIndex = 0;
			this.btnMain.Text = "Main";
			this.btnMain.UseVisualStyleBackColor = true;
			this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrevious.Location = new System.Drawing.Point(566, 394);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(75, 21);
			this.btnPrevious.TabIndex = 1;
			this.btnPrevious.Text = "Previous";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnNext
			// 
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNext.Location = new System.Drawing.Point(647, 394);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 21);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// scrEncodeContent
			// 
			this.scrEncodeContent.BackColor = System.Drawing.Color.Transparent;
			this.scrEncodeContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrEncodeContent.Location = new System.Drawing.Point(0, 0);
			this.scrEncodeContent.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrEncodeContent.Name = "scrEncodeContent";
			this.scrEncodeContent.Size = new System.Drawing.Size(740, 424);
			this.scrEncodeContent.TabIndex = 8;
			this.scrEncodeContent.Visible = false;
			// 
			// scrEncodeImage
			// 
			this.scrEncodeImage.BackColor = System.Drawing.Color.Transparent;
			this.scrEncodeImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrEncodeImage.Location = new System.Drawing.Point(0, 0);
			this.scrEncodeImage.Margin = new System.Windows.Forms.Padding(5);
			this.scrEncodeImage.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrEncodeImage.Name = "scrEncodeImage";
			this.scrEncodeImage.Size = new System.Drawing.Size(740, 424);
			this.scrEncodeImage.TabIndex = 2;
			this.scrEncodeImage.Visible = false;
			// 
			// scrEncodeDestination
			// 
			this.scrEncodeDestination.BackColor = System.Drawing.Color.Transparent;
			this.scrEncodeDestination.Location = new System.Drawing.Point(0, 0);
			this.scrEncodeDestination.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrEncodeDestination.Name = "scrEncodeDestination";
			this.scrEncodeDestination.Size = new System.Drawing.Size(740, 380);
			this.scrEncodeDestination.TabIndex = 2;
			this.scrEncodeDestination.Visible = false;
			// 
			// scrEncodeProgress
			// 
			this.scrEncodeProgress.BackColor = System.Drawing.Color.Transparent;
			this.scrEncodeProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrEncodeProgress.Location = new System.Drawing.Point(0, 0);
			this.scrEncodeProgress.Margin = new System.Windows.Forms.Padding(5);
			this.scrEncodeProgress.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrEncodeProgress.Name = "scrEncodeProgress";
			this.scrEncodeProgress.Size = new System.Drawing.Size(740, 424);
			this.scrEncodeProgress.TabIndex = 1;
			this.scrEncodeProgress.Visible = false;
			// 
			// scrEncodeFinished
			// 
			this.scrEncodeFinished.BackColor = System.Drawing.Color.Transparent;
			this.scrEncodeFinished.Location = new System.Drawing.Point(0, 0);
			this.scrEncodeFinished.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrEncodeFinished.Name = "scrEncodeFinished";
			this.scrEncodeFinished.Size = new System.Drawing.Size(740, 380);
			this.scrEncodeFinished.TabIndex = 10;
			this.scrEncodeFinished.Visible = false;
			// 
			// scrDecodeImage
			// 
			this.scrDecodeImage.BackColor = System.Drawing.Color.Transparent;
			this.scrDecodeImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrDecodeImage.Location = new System.Drawing.Point(0, 0);
			this.scrDecodeImage.Name = "scrDecodeImage";
			this.scrDecodeImage.Size = new System.Drawing.Size(734, 424);
			this.scrDecodeImage.TabIndex = 10;
			this.scrDecodeImage.Visible = false;
			// 
			// scrDecodeContent
			// 
			this.scrDecodeContent.BackColor = System.Drawing.Color.Transparent;
			this.scrDecodeContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrDecodeContent.Location = new System.Drawing.Point(0, 0);
			this.scrDecodeContent.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrDecodeContent.Name = "scrDecodeContent";
			this.scrDecodeContent.Size = new System.Drawing.Size(740, 424);
			this.scrDecodeContent.TabIndex = 11;
			this.scrDecodeContent.Visible = false;
			// 
			// scrDecodeDestination
			// 
			this.scrDecodeDestination.BackColor = System.Drawing.Color.Transparent;
			this.scrDecodeDestination.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrDecodeDestination.Location = new System.Drawing.Point(0, 0);
			this.scrDecodeDestination.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrDecodeDestination.Name = "scrDecodeDestination";
			this.scrDecodeDestination.Size = new System.Drawing.Size(740, 424);
			this.scrDecodeDestination.TabIndex = 12;
			this.scrDecodeDestination.Visible = false;
			// 
			// scrDecodeProgress
			// 
			this.scrDecodeProgress.BackColor = System.Drawing.Color.Transparent;
			this.scrDecodeProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrDecodeProgress.Location = new System.Drawing.Point(0, 0);
			this.scrDecodeProgress.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrDecodeProgress.Name = "scrDecodeProgress";
			this.scrDecodeProgress.Size = new System.Drawing.Size(740, 424);
			this.scrDecodeProgress.TabIndex = 13;
			this.scrDecodeProgress.Visible = false;
			// 
			// scrDecodeFinished
			// 
			this.scrDecodeFinished.BackColor = System.Drawing.Color.Transparent;
			this.scrDecodeFinished.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrDecodeFinished.Location = new System.Drawing.Point(0, 0);
			this.scrDecodeFinished.MinimumSize = new System.Drawing.Size(740, 380);
			this.scrDecodeFinished.Name = "scrDecodeFinished";
			this.scrDecodeFinished.Size = new System.Drawing.Size(740, 424);
			this.scrDecodeFinished.TabIndex = 14;
			this.scrDecodeFinished.Visible = false;
			// 
			// FormMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.BackgroundImage = global::PixelCryptor.Properties.Resources.BackgroundMain;
			this.ClientSize = new System.Drawing.Size(734, 424);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlWizard);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.hlpProvider.SetHelpKeyword(this, "About");
			this.hlpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
			this.hlpProvider.SetHelpString(this, "");
			this.Icon = global::PixelCryptor.Properties.Resources.LogoIcon;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.hlpProvider.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "PixelCryptor";
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picEncode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picDecode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
			this.pnlWizard.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ScreenEncodeProgress scrEncodeProgress;
		private ScreenEncodeImage scrEncodeImage;
		private ScreenEncodeContent scrEncodeContent;
		private PixelCryptor.UI.WinControls.CGPanel pnlWizard;
		private PixelCryptor.UI.WinControls.CGPanel pnlMain;
		private ScreenEncodeDestination scrEncodeDestination;
		private ScreenEncodeFinished scrEncodeFinished;
		private ScreenDecodeImage scrDecodeImage;
		private ScreenDecodeContent scrDecodeContent;
		private ScreenDecodeDestination scrDecodeDestination;
		private ScreenDecodeProgress scrDecodeProgress;
		private ScreenDecodeFinished scrDecodeFinished;
		private PixelCryptor.UI.WinControls.CGButton btnMain;
		private PixelCryptor.UI.WinControls.CGButton btnPrevious;
		private PixelCryptor.UI.WinControls.CGButton btnNext;
		private WinControls.CGPicture picAbout;
		private WinControls.CGPicture picDecode;
		private WinControls.CGPicture picHelp;
		private WinControls.CGLabel lblSelectionDescription;
		private WinControls.CGLabel lblSelectionHeader;
		private PixelCryptor.UI.WinControls.CGPicture picEncode;
		private System.Windows.Forms.HelpProvider hlpProvider;
	}
}