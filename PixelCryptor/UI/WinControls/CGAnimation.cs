#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace AnimatedPNG {
	/// <summary>
	/// A Code Gazer Animation for the display of images
	/// as an animation.
	/// </summary>	
	public partial class CGAnimation : UserControl {
		#region Fields
		private List<Image> _images;
		private int _imageIndex;
		private bool _loop;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Interval of the animation in milliseconds.
		/// </summary>
		public int Interval {
			get { return this.tmrAnimation.Interval; }
			set { this.tmrAnimation.Interval = value; }
		}

		/// <summary>
		/// Gets or sets the list of Images to cycle through.
		/// </summary>
		public List<Image> Images {
			get { return this._images; }
			set { this._images = value; }
		}

		/// <summary>
		/// Gets or sets if the animation loops or plays once.
		/// </summary>
		public bool Loop {
			get { return this._loop; }
			set { this._loop = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Instantiates a new CGAnimation.
		/// </summary>
		public CGAnimation() {
			// Painting directives for .NET
			this.SetStyle(
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.DoubleBuffer, true);

			// Initialize the control
			InitializeComponent();

			// Initialize/set the defaults
			this._images = new List<Image>();
			this._imageIndex = 0;
			this._loop = true;
		}
		#endregion

		#region Events
		/// <summary>
		/// Occurs when the timer interval elapsed.
		/// </summary>
		private void tmrAnimation_Tick(object sender, EventArgs e) {
			// Invalidate the paint area of this control
			this.Invalidate(false);

			// Still not the last image?
			if (this._imageIndex < this._images.Count - 1)
				// Increase the image index
				this._imageIndex++;
			else if (this._loop)
				// Continue at image 1
				this._imageIndex = 0;
			else
				// Stop the timer
				this.tmrAnimation.Stop();
		}

		/// <summary>
		/// Occurs when the system requests a repaint.
		/// </summary>
		protected override void OnPaint(PaintEventArgs e) {
			// Check if there are images available
			if (this._images != null && this._images.Count > 0)
				// Draw the image to the screen
				e.Graphics.DrawImage(this._images[this._imageIndex], this.ClientRectangle);
			else
				// No images, do a normal .NET paint
				base.OnPaint(e);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Sets the current image to index 0.
		/// </summary>
		public void Reset() {
			// Reset the image index
			this._imageIndex = 0;
		}
		
		/// <summary>
		/// Starts the animation.
		/// </summary>
		public void Start() {
			// Reset if necessary
			if (!this.Loop && this._imageIndex == this._images.Count - 1)
				this.Reset();
			
			// Start the timer
			this.tmrAnimation.Start();
		}

		/// <summary>
		/// Stops the animation.
		/// </summary>
		public void Stop() {
			// Stop the timer
			this.tmrAnimation.Stop();
		}
		#endregion
	}
}
