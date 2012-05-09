namespace PixelCryptor.UI {
	partial class ScreenEncodeContent {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenEncodeContent));
			this.lblHeader = new System.Windows.Forms.Label();
			this.ffsSelector = new PixelCryptor.UI.FileFolderSelector();
			this.lblText1 = new System.Windows.Forms.Label();
			this.chkDeleteAfterEncode = new System.Windows.Forms.CheckBox();
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
			this.lblHeader.Size = new System.Drawing.Size(442, 14);
			this.lblHeader.TabIndex = 2;
			this.lblHeader.Text = "Encoding - Select which files and folders to include in the package";
			this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ffsSelector
			// 
			this.ffsSelector.AllowDrop = true;
			this.ffsSelector.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ffsSelector.Location = new System.Drawing.Point(14, 84);
			this.ffsSelector.Mode = PixelCryptor.UI.FileFolderSelector.OperationMode.Full;
			this.ffsSelector.Name = "ffsSelector";
			this.ffsSelector.Package = null;
			this.ffsSelector.Size = new System.Drawing.Size(706, 283);
			this.ffsSelector.TabIndex = 3;
			// 
			// lblText1
			// 
			this.lblText1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lblText1.ForeColor = System.Drawing.Color.White;
			this.lblText1.Location = new System.Drawing.Point(11, 24);
			this.lblText1.Margin = new System.Windows.Forms.Padding(0);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(709, 28);
			this.lblText1.TabIndex = 4;
			this.lblText1.Text = resources.GetString("lblText1.Text");
			// 
			// chkDeleteAfterEncode
			// 
			this.chkDeleteAfterEncode.AutoSize = true;
			this.chkDeleteAfterEncode.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.chkDeleteAfterEncode.ForeColor = System.Drawing.Color.White;
			this.chkDeleteAfterEncode.Location = new System.Drawing.Point(14, 58);
			this.chkDeleteAfterEncode.Name = "chkDeleteAfterEncode";
			this.chkDeleteAfterEncode.Size = new System.Drawing.Size(346, 17);
			this.chkDeleteAfterEncode.TabIndex = 5;
			this.chkDeleteAfterEncode.Text = "Delete the files and folders after the encoding operation";
			this.chkDeleteAfterEncode.UseVisualStyleBackColor = true;
			this.chkDeleteAfterEncode.CheckedChanged += new System.EventHandler(this.chkDeleteAfterEncode_CheckedChanged);
			// 
			// ScreenEncodeContent
			// 
			this.BackColor = System.Drawing.Color.SlateGray;
			this.Controls.Add(this.chkDeleteAfterEncode);
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.lblHeader);
			this.Controls.Add(this.ffsSelector);
			this.Name = "ScreenEncodeContent";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label lblHeader;
        private FileFolderSelector ffsSelector;
		private System.Windows.Forms.Label lblText1;
		private System.Windows.Forms.CheckBox chkDeleteAfterEncode;

    }
}
