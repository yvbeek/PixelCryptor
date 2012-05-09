#region Using directives
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using PixelCryptor.Utilities;
#endregion

namespace PixelCryptor.UI {
	public partial class ScreenDecodeFinished : ScreenMaster {
		#region String constants
		private const string cFilesAndFolders = "{0} files and {1} folders";
		private const string cTooltipOpenPackageFolder = "Click here to open the folder with the package content";
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new DecodeFinished screen.
		/// </summary>
		public ScreenDecodeFinished() {
			// Initialize basic screen elements
			InitializeComponent();

			// Specify which buttons to use for this screen
			_buttons = WizardButtons.Main | WizardButtons.Next;

			// Bind the Tooltip
			ttpTooltip.SetToolTip(lnkOpenPackage, cTooltipOpenPackageFolder);
		}
		#endregion

		#region Events
		/// <summary>
		/// Opens the package folder.
		/// </summary>
		private void lnkOpenPackage_Click(object sender, EventArgs e) {
			Process.Start(_project.DestinationFolderPath);
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
			lblDestinationFolderName.Text = Path.GetFileName(_project.DestinationFolderPath);
			lblFilesAndFolders.Text = String.Format(cFilesAndFolders, _project.Package.CountFiles(), _project.Package.CountFolders());
			lblPackageSize.Text = TextConversionUtilities.FormatFileSize(new FileInfo(_project.CodeFilePath).Length);
		}
		#endregion
	}
}
