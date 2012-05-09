#region Using directives
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using PixelCryptor.Utilities;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenEncodeFinished : ScreenMaster {
		#region String constants
		private const string cFilesAndFolders = "{0} files and {1} folders";
		private const string cKeyDimension = "{0} x {1}";
		private const string cTooltipOpenKeyFolder = "Click here to open the key folder";
		private const string cTooltipOpenPackageFolder = "Click here to open the package folder";
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new EncodeFinished screen.
		/// </summary>
		public ScreenEncodeFinished() {
			// Initialize basic screen elements
			InitializeComponent();

			// Specify which buttons to use with this screen
			_buttons = WizardButtons.Main | WizardButtons.Next;

			// Bind the Tooltip
			ttpTooltip.SetToolTip(lnkOpenKey, cTooltipOpenKeyFolder);
			ttpTooltip.SetToolTip(lnkOpenPackage, cTooltipOpenPackageFolder);
		}
		#endregion

		#region Events
		/// <summary>
		/// Opens the key folder.
		/// </summary>
		private void lnkOpenKey_Click(object sender, EventArgs e) {
			Process.Start(Path.GetDirectoryName(this._project.KeyPath));
		}

		/// <summary>
		/// Opens the package folder.
		/// </summary>
		private void lnkOpenPackage_Click(object sender, EventArgs e) {
			Process.Start(Path.GetDirectoryName(this._project.CodeFilePath));
		}

		/// <summary>
		/// Opens the CodeGazer website.
		/// </summary>
		private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start("http://www.codegazer.com/");
		}
		#endregion

		#region Methods
		/// <summary>
		/// Activates this screen.
		/// </summary>
		public override void Activate(CryptorProject project) {
			// Call the base implementation
			base.Activate(project);

			// Set element values
			this.lblPackageFileName.Text = Path.GetFileNameWithoutExtension(this._project.CodeFilePath);
			this.lblFilesAndFolders.Text = String.Format(cFilesAndFolders, this._project.Package.CountFiles(), this._project.Package.CountFolders());
			this.lblPackageSize.Text = TextConversionUtilities.FormatFileSize(new FileInfo(_project.CodeFilePath).Length);

			this.lblKeyFileName.Text = Path.GetFileNameWithoutExtension(this._project.KeyPath);
			this.lblKeyDimension.Text = String.Format(cKeyDimension, project.CodeFileDimension.Width, project.CodeFileDimension.Height);
			this.lblKeySize.Text = TextConversionUtilities.FormatFileSize(new FileInfo(_project.KeyPath).Length);
		}
		#endregion
	}
}
