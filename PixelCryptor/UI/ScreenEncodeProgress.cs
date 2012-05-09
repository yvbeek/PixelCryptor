#region Using directives
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using PixelCryptor.Core.Structure;
using PixelCryptor.Utilities;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenEncodeProgress : ScreenMaster {
		#region Fields
		private bool _isRunning;
		private string _byteSizeTotalText;
		private long _byteSizeTotal;
		private long _byteSizeCrypted;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new EncodeProgress screen.
		/// </summary>
		public ScreenEncodeProgress() {
			// Initialize basic screen elements
			this.InitializeComponent();

			// Specify which buttons to use with this screen
			this._buttons = WizardButtons.None;
			this._nextOnValid = true;

			// Prepare the animation
			for (int i = 1; i < 35; i++)
				cgaEncode.Images.Add((Image) Properties.Resources.ResourceManager.GetObject("AnimationEncode" + i));
		}
		#endregion

		#region Events
		/// <summary>
		/// Worker process starts encoding.
		/// </summary>
		private void workerProcess_DoWork(object sender, DoWorkEventArgs e) {
			// Retrieve project details
			CryptorProject project = (CryptorProject) e.Argument;

			// Report zero progress
			workerProcess.ReportProgress(0);

			// Save the package
			project.Package.Save(project.KeyPath, project.CodeFilePath, project.DeleteAfterEncode);
		}

		/// <summary>
		/// Package reports progress.
		/// </summary>
		private void Package_BytesEncrypted(int byteAmount) {
			workerProcess.ReportProgress(byteAmount);
		}

		/// <summary>
		/// Worker reports progress.
		/// </summary>
		private void workerProcess_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			// Show the number of bytes crypted
			this._byteSizeCrypted += e.ProgressPercentage;

			if (this._project.DeleteAfterEncode && this._byteSizeCrypted >= this._byteSizeTotal)
				this.lblProgress.Text = "Encoding done, deleting original files and folders...";
			else
				this.lblProgress.Text = TextConversionUtilities.FormatFileSize(this._byteSizeCrypted) + " of " + this._byteSizeTotalText + " (" + (int) (100f / this._byteSizeTotal * this._byteSizeCrypted) + "%)";
		}

		/// <summary>
		/// Worker process completed.
		/// </summary>
		private void workerProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			// Done encoding
			this._isRunning = false;

			// Stop and reset the animation
			this.cgaEncode.Stop();
			this.cgaEncode.Reset();

			// Revalidate to move to the next screen
			this.ValidateScreen();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Activates the screen.
		/// </summary>
		public override void Activate(CryptorProject project) {
			// Mark the Encoder as busy
			this._isRunning = true;

			// Call the base implementation
			base.Activate(project);

			// Start the animation
			this.cgaEncode.Start();

			// Get the total byte size
			this._byteSizeCrypted = 0;
			this._byteSizeTotal = Math.Max(1, project.Package.GetByteSize());
			this._byteSizeTotalText = TextConversionUtilities.FormatFileSize(this._byteSizeTotal);

			// Attach the BytesCrypted event
			project.Package.BytesEncrypted += new BytesCryptedHandler(Package_BytesEncrypted);

			// Start encoding
			this.workerProcess.RunWorkerAsync(project);
		}

		/// <summary>
		/// Deactivate this screen.
		/// </summary>
		public override CryptorProject Deactivate() {
			// Clear progress label to prevent flickering
			this.lblProgress.Text = "";

			// Deactivate the screen
			return base.Deactivate();
		}

		/// <summary>
		/// Validates the screen.
		/// </summary>
		public override bool ValidateScreen() {
			// The screen is valid, when the encoding process is done
			bool isValid = !this._isRunning;

			// Call the event
			base.OnScreenValidated(isValid);

			// Return the result
			return isValid;
		}
		#endregion
	}
}
