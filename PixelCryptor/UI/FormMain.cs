#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using PixelCryptor.Core.Structure;
#endregion

namespace PixelCryptor.UI {
	/// <summary>
	/// Main Form.
	/// </summary>
	public partial class FormMain : Form {
		#region Mutex
		static Mutex mutex = new Mutex(false, "CodeGazer.PixelCryptor");
		#endregion
		
		#region Fields
		private List<ScreenMaster> _currentScreenSet;
		private ScreenMaster _currentScreen;
		private CryptorProject _currentProject;

		private List<ScreenMaster> _screensEncode;
		private List<ScreenMaster> _screensDecode;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new Main form.
		/// </summary>
		public FormMain(string[] args) {		
			// Initialize basic form elements
			this.InitializeComponent();

			// Set the initial texts
			this.lblSelectionHeader.Text = Properties.Resources.TxtActionDefaultTitle;
			this.lblSelectionDescription.Text = Properties.Resources.TxtActionDefaultDescription;

			// Initialize the screen sequences
			this._screensEncode = new List<ScreenMaster>();
			this._screensEncode.Add(this.scrEncodeContent);
			this._screensEncode.Add(this.scrEncodeImage);
			this._screensEncode.Add(this.scrEncodeDestination);
			this._screensEncode.Add(this.scrEncodeProgress);
			this._screensEncode.Add(this.scrEncodeFinished);
			
			this._screensDecode = new List<ScreenMaster>();
			this._screensDecode.Add(this.scrDecodeImage);
			this._screensDecode.Add(this.scrDecodeContent);
			this._screensDecode.Add(this.scrDecodeDestination);
			this._screensDecode.Add(this.scrDecodeProgress);
			this._screensDecode.Add(this.scrDecodeFinished);

			// Add the screen events
			this.scrEncodeContent.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrEncodeImage.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrEncodeDestination.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrEncodeProgress.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrEncodeFinished.ScreenValidated += new ValidationHandler(ScreenValidated);

			this.scrDecodeContent.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrDecodeImage.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrDecodeDestination.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrDecodeProgress.ScreenValidated += new ValidationHandler(ScreenValidated);
			this.scrDecodeFinished.ScreenValidated += new ValidationHandler(ScreenValidated);

			// Initialize fields
			this._currentProject = null;

			// Process command arguments
			this.ProcessCommandLineArguments(args);
		}
		#endregion

		#region Events
		/// <summary>
		/// Paints the background of the control.
		/// </summary>
		protected override void OnPaintBackground(PaintEventArgs e) {
			Image image = (pnlMain.Visible) ? Properties.Resources.BackgroundMain : Properties.Resources.BackgroundWizard;
			e.Graphics.DrawImage(image, 0, 0);
		}
		
		/// <summary>
		/// User drags something to the Form.
		/// </summary>
		private void FormMain_DragEnter(object sender, DragEventArgs e) {
			// Active the Form
			this.Activate();
		}

		/// <summary>
		/// User leaves one of the main actions.
		/// </summary>
		private void MainItemLeave(object sender, EventArgs e) {
			this.lblSelectionHeader.Text = Properties.Resources.TxtActionDefaultTitle;
			this.lblSelectionDescription.Text = Properties.Resources.TxtActionDefaultDescription;
		}

		/// <summary>
		/// User moved over the Encode action.
		/// </summary>
		private void picEncode_MouseEnter(object sender, EventArgs e) {
			this.lblSelectionHeader.Text = Properties.Resources.TxtActionEncodeTitle;
			this.lblSelectionDescription.Text = Properties.Resources.TxtActionEncodeDescription;
		}

		/// <summary>
		/// User moved over the Decode action.
		/// </summary>
		private void picDecode_MouseEnter(object sender, EventArgs e) {
			this.lblSelectionHeader.Text = Properties.Resources.TxtActionDecodeTitle;
			this.lblSelectionDescription.Text = Properties.Resources.TxtActionDecodeDescription;
		}

		/// <summary>
		/// User moved over the About action.
		/// </summary>
		private void picAbout_MouseEnter(object sender, EventArgs e) {
			this.lblSelectionHeader.Text = Properties.Resources.TxtActionAboutTitle;
			this.lblSelectionDescription.Text = Properties.Resources.TxtActionAboutDescription;
		}

		/// <summary>
		/// User moved over the Exit action.
		/// </summary>
		private void picHelp_MouseEnter(object sender, EventArgs e) {
			this.lblSelectionHeader.Text = Properties.Resources.TxtActionHelpTitle;
			this.lblSelectionDescription.Text = Properties.Resources.TxtActionHelpDescription;
		}

		/// <summary>
		/// User clicked on the About image.
		/// </summary>
		private void picAbout_Click(object sender, EventArgs e) {
			new FormAbout().ShowDialog(this);
		}

		/// <summary>
		/// User clicked on the Encode image.
		/// </summary>
		private void picEncode_MouseClick(object sender, MouseEventArgs e) {
			this.StartEncode();
		}

		/// <summary>
		/// User clicked on the Decode image.
		/// </summary>
		private void picDecode_MouseClick(object sender, MouseEventArgs e) {
			this.StartDecode();
		}

		/// <summary>
		/// User clicked on the Help image.
		/// </summary>
		private void picHelp_MouseClick(object sender, MouseEventArgs e) {
			this.ShowHelp();
		}

		/// <summary>
		/// User clicked on the Main button.
		/// </summary>
		private void btnMain_Click(object sender, EventArgs e) {
			this.ShowMain();
		}

		/// <summary>
		/// User clicked on the Previous button.
		/// </summary>
		private void btnPrevious_Click(object sender, EventArgs e) {
			this.ShowPreviousScreen();
		}

		/// <summary>
		/// User clicked on the Next button.
		/// </summary>
		private void btnNext_Click(object sender, EventArgs e) {
			this.ShowNextScreen();
		}

		/// <summary>
		/// Changes the form to reflect the screen validation properties.
		/// </summary>
		private void ScreenValidated(ScreenMaster sender, bool isValid) {
			// Automatic next on validation?
			if (sender.NextOnValid && isValid)
				// Show next screen
				this.ShowNextScreen();
			else
				// Enable the next button
				this.btnNext.Enabled = isValid;
		}
		#endregion

		#region Main screen methods
		/// <summary>
		/// Shows the main screen.
		/// </summary>
		private void ShowMain() {
			// Hide the last selection if necessary
			if (this._currentScreen != null) {
				this._currentScreen.Deactivate();
				this._currentScreen = null;
			}

			// Start with a clean CryptorProject
			this._currentProject = new CryptorProject();

			// Hide wizard panel, show main panel
			this.pnlMain.Visible = true;
			this.pnlWizard.Visible = false;
		}

		/// <summary>
		/// Shows the wizard for a set of screens.
		/// </summary>
		private void ShowWizard(List<ScreenMaster> screenSet) {		
			// Hide main panel, show wizard panel
			this.pnlWizard.Visible = true;
			this.pnlMain.Visible = false;

			// Store the screenset selection
			this._currentScreenSet = screenSet;

			// Clear the current screen
			this._currentScreen = null;

			// Show the first screen
			this.ShowScreen(screenSet[0]);
		}

		/// <summary>
		/// Shows the help file.
		/// </summary>
		private void ShowHelp() {
			Help.ShowHelp(this, "PixelCryptor.chm");
		}

		/// <summary>
		/// Starts the decode wizard.
		/// </summary>
		private void StartDecode() {
			this.StartDecode(new CryptorProject());
		}

		/// <summary>
		/// Starts the decode wizard with an existing CryptorProject.
		/// </summary>
		private void StartDecode(CryptorProject project) {
			// Set the current project
			this._currentProject = project;

			// Show the wizard
			this.ShowWizard(this._screensDecode);
		}

		/// <summary>
		/// Starts the encode wizard.
		/// </summary>
		private void StartEncode() {
			this.StartEncode(new CryptorProject());
		}

		/// <summary>
		/// Starts the encode wizard with an existing CryptorProject.
		/// </summary>
		private void StartEncode(CryptorProject project) {
			// Set the current project
			this._currentProject = project;

			// Show the wizard
			this.ShowWizard(this._screensEncode);
		}
		#endregion

		#region Wizard screen methods
		/// <summary>
		/// Shows a screen with a project selection.
		/// </summary>
		private void ShowScreen(ScreenMaster screen) {
			// Deactivate the old screen if necessary
			if (this._currentScreen != null)
				this._currentProject = this._currentScreen.Deactivate();

			// Store the new selection
			this._currentScreen = screen;

			// Change the buttons
			this.ToggleButtons(screen);

			// Show the screen
			screen.Activate(this._currentProject);
		}

		/// <summary>
		/// Shows the screen with the specified offset of the current index.
		/// </summary>
		private void ShowScreenByOffset(int offset) {
			int index = this._currentScreenSet.IndexOf(_currentScreen) + offset;
			if (index < 0 || index == this._currentScreenSet.Count)
				this.ShowMain();
			else
				this.ShowScreen(this._currentScreenSet[index]);
		}

		/// <summary>
		/// Shows the previous screen.
		/// </summary>
		private void ShowPreviousScreen() {
			this.ShowScreenByOffset(-1);
		}

		/// <summary>
		/// Shows the next screen.
		/// </summary>
		private void ShowNextScreen() {
			this.ShowScreenByOffset(1);
		}

		/// <summary>
		/// Toggle the buttons based on Screen configuration.
		/// </summary>
		private void ToggleButtons(ScreenMaster screen) {
			// Is this the last item?
			bool isLast = (this._currentScreenSet.IndexOf(screen) == this._currentScreenSet.Count - 1);
			this.btnNext.Text = (isLast) ? "Finished" : "Next";

			// Toggle the buttons
			this.btnMain.Enabled = (screen.Buttons & WizardButtons.Main) == WizardButtons.Main;
			this.btnPrevious.Enabled = (screen.Buttons & WizardButtons.Previous) == WizardButtons.Previous;
			this.btnNext.Enabled = (screen.Buttons & WizardButtons.Next) == WizardButtons.Next;
		}
		#endregion

		#region Miscellaneous methods
		/// <summary>
		/// Processes the commandline arguments. 
		/// </summary>
		private void ProcessCommandLineArguments(string[] args) {
			CryptorProject project = null;
			string argOption, argValue;

			for (int i = 0; i < args.Length; i++) {
				// Is this the last argument?
				argOption = args[i];
				argValue = ((i + 1) < args.Length) ? args[++i] : null;

				switch (argOption) {
					// A codefile path has been specified
					case "/cf":
					case "/codefilepath":
						// Preselect the codefile
						if (!string.IsNullOrEmpty(argValue)) {
							project = new CryptorProject();
							project.CodeFilePath = Path.GetFullPath(argValue);
						} else
							this.ShowHelpAndExit();
						break;

					// Invalid arguments or help is requested
					default:
					case "/?":
					case "/h":
						this.ShowHelpAndExit();
						break;
				}
			}

			// Start the decode process if necessary
			if (project != null)
				StartDecode(project);
		}

		/// <summary>
		/// Shows the commandline help screen and exits.
		/// </summary>
		private void ShowHelpAndExit() {
			// Show help screen and exit
			MessageBox.Show(Properties.Resources.MsgCommandLineHelpText, Properties.Resources.MsgCommandLineHelpTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
			Environment.Exit(1);
		}
		#endregion
	}

	/// <summary>
	/// PixelCryptor project.
	/// </summary>
	public class CryptorProject {
		public PPackage Package;
		public string KeyPath;
		public string CodeFilePath;
		public Size CodeFileDimension;
		public string DestinationFolderPath;
		public bool DeleteAfterEncode;
	}

	/// <summary>
	/// Wizard buttons.
	/// </summary>
	[Flags()]
	public enum WizardButtons {
		/// <summary>
		/// No button.
		/// </summary>
		None,
		/// <summary>
		/// The Main button.
		/// </summary>
		Main = 1,
		/// <summary>
		/// The Previous button.
		/// </summary>
		Previous = 2,
		/// <summary>
		/// The Next button.
		/// </summary>
		Next = 4,
		/// <summary>
		/// The default buttons, showing Main, Previous and Next.
		/// </summary>
		Default = Main | Previous | Next
	}
}
