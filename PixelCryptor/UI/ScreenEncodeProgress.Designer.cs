namespace PixelCryptor.UI {
	partial class ScreenEncodeProgress {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenEncodeProgress));
			this.lblHeader = new System.Windows.Forms.Label();
			this.workerProcess = new System.ComponentModel.BackgroundWorker();
			this.cgaEncode = new AnimatedPNG.CGAnimation();
			this.lblText1 = new System.Windows.Forms.Label();
			this.lblProgress = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblHeader.ForeColor = System.Drawing.Color.White;
			this.lblHeader.Location = new System.Drawing.Point(11, 10);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(359, 14);
			this.lblHeader.TabIndex = 2;
			this.lblHeader.Text = "Encoding - Your files and folders are being encoded...";
			// 
			// workerProcess
			// 
			this.workerProcess.WorkerReportsProgress = true;
			this.workerProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerProcess_DoWork);
			this.workerProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerProcess_RunWorkerCompleted);
			this.workerProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerProcess_ProgressChanged);
			// 
			// cgaEncode
			// 
			this.cgaEncode.BackColor = System.Drawing.Color.Transparent;
			this.cgaEncode.Images = ((System.Collections.Generic.List<System.Drawing.Image>) (resources.GetObject("cgaEncode.Images")));
			this.cgaEncode.Interval = 100;
			this.cgaEncode.Location = new System.Drawing.Point(145, 115);
			this.cgaEncode.Loop = true;
			this.cgaEncode.Name = "cgaEncode";
			this.cgaEncode.Size = new System.Drawing.Size(450, 150);
			this.cgaEncode.TabIndex = 3;
			// 
			// lblText1
			// 
			this.lblText1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblText1.ForeColor = System.Drawing.Color.White;
			this.lblText1.Location = new System.Drawing.Point(11, 24);
			this.lblText1.Margin = new System.Windows.Forms.Padding(0);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(667, 27);
			this.lblText1.TabIndex = 11;
			this.lblText1.Text = "PixelCryptor is now encrypting your files and folders. This may take a while, dep" +
				"ending on the size of the package.\r\nPlease wait until the process is completed.";
			// 
			// lblProgress
			// 
			this.lblProgress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblProgress.ForeColor = System.Drawing.Color.White;
			this.lblProgress.Location = new System.Drawing.Point(142, 273);
			this.lblProgress.Margin = new System.Windows.Forms.Padding(0);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(450, 22);
			this.lblProgress.TabIndex = 14;
			this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ScreenEncodeProgress
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.cgaEncode);
			this.Controls.Add(this.lblHeader);
			this.Name = "ScreenEncodeProgress";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.Label lblHeader;
		private System.ComponentModel.BackgroundWorker workerProcess;
		private AnimatedPNG.CGAnimation cgaEncode;
		private System.Windows.Forms.Label lblText1;
		private System.Windows.Forms.Label lblProgress;
	}
}
