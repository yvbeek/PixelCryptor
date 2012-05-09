#region Using directives
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
#endregion

namespace PixelCryptor.UI {
	partial class FormAbout : Form {
		#region Properties
		/// <summary>
		/// Gets the title of the assembly.
		/// </summary>
		public string AssemblyTitle {
			get {
				// Get all Title attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// If there is at least one Title attribute
				if (attributes.Length > 0) {
					// Select the first one
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute) attributes[0];
					// If it is not an empty string, return it
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		/// <summary>
		/// Gets the version of the assembly.
		/// </summary>
		public string AssemblyVersion {
			get {
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		/// <summary>
		/// Gets the description of the assembly.
		/// </summary>
		public string AssemblyDescription {
			get {
				// Get all Description attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// If there aren't any Description attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Description attribute, return its value
				return ((AssemblyDescriptionAttribute) attributes[0]).Description;
			}
		}

		/// <summary>
		/// Gets the product name of the assembly.
		/// </summary>
		public string AssemblyProduct {
			get {
				// Get all Product attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// If there aren't any Product attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Product attribute, return its value
				return ((AssemblyProductAttribute) attributes[0]).Product;
			}
		}

		/// <summary>
		/// Gets the copyright information of the assembly.
		/// </summary>
		public string AssemblyCopyright {
			get {
				// Get all Copyright attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// If there aren't any Copyright attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Copyright attribute, return its value
				return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
			}
		}

		/// <summary>
		/// Gets the company name of the assembly.
		/// </summary>
		public string AssemblyCompany {
			get {
				// Get all Company attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// If there aren't any Company attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Company attribute, return its value
				return ((AssemblyCompanyAttribute) attributes[0]).Company;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new About form.
		/// </summary>
		public FormAbout() {
			// Initialize the component
			this.InitializeComponent();

			// Set dynamic texts
			this.lblCopyright.Text = String.Format(this.lblCopyright.Text, AssemblyCopyright);
			this.lblVersion.Text = String.Format(this.lblVersion.Text, AssemblyVersion);
		}
		#endregion

		#region Events
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start("http://www.codegazer.com/");
		}
		#endregion
	}
}
