#region Using directives
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endregion

namespace PixelCryptor.UI.WinControls {
	/// <summary>
	/// A Code Gazer Button for the display of buttons
	/// vista style.
	/// </summary>	
	public class CGButton : System.Windows.Forms.Button {
		#region Fields
		private ButtonStates _buttonState;
		protected ButtonColors _colorsNormal;
		protected ButtonColors _colorsHover;
		protected ButtonColors _colorsPressed;
		protected ButtonColors _colorsDisabled;
		#endregion

		#region Constructor
		/// <summary>
		/// CodeGazer button for the Vista looks.
		/// </summary>
		public CGButton()
			: base() {
			// Painting directives for .NET
			this.SetStyle(
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.DoubleBuffer, true);

			// Set the button to flatstyle
			this.FlatStyle = FlatStyle.Flat;

			// Button starts normal
			this._buttonState = ButtonStates.Normal;

			// Define the default colors
			this.ResetToDefaultColors();

		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the normal colors.
		/// </summary>
		public ButtonColors ColorsNormal {
			get { return this._colorsNormal; }
			set {
				this._colorsNormal = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the hover colors.
		/// </summary>
		public ButtonColors ColorsHover {
			get { return this._colorsHover; }
			set {
				this._colorsHover = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the pressed colors.
		/// </summary>
		public ButtonColors ColorsPressed {
			get { return this._colorsPressed; }
			set {
				this._colorsPressed = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the disabled colors.
		/// </summary>
		public ButtonColors ColorsDisabled {
			get { return this._colorsDisabled; }
			set {
				this._colorsDisabled = value;
				this.Invalidate();
			}
		}
		#endregion

		#region Events
		/// <summary>
		/// Button is assigned to a new parent.
		/// </summary>
		protected override void OnParentChanged(EventArgs e) {
			if (this.Parent == null) return;

			// Reset the region
			this.RecreateRegion();

			// Call the base implementation
			base.OnParentChanged(e);
		}

		/// <summary>
		/// User enters the button area with the mouse.
		/// </summary>
		protected override void OnMouseEnter(EventArgs e) {
			// Set the mouse state to MouseOver
			this._buttonState = ButtonStates.MouseOver;

			// Request a repaint
			this.Invalidate();

			// Call the base implementation
			base.OnMouseEnter(e);
		}

		/// <summary>
		/// User leaves the button area with the mouse.
		/// </summary>
		protected override void OnMouseLeave(EventArgs e) {
			// Set the mouse state to normal
			this._buttonState = ButtonStates.Normal;

			// Request a repaint
			this.Invalidate();

			// Call the base implementation
			base.OnMouseLeave(e);
		}

		/// <summary>
		/// User clicks on the mouse button.
		/// </summary>
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) {
			// Only accept left mouse button clicks
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;

			// Set the mouse state to pushed
			this._buttonState = ButtonStates.Pushed;

			// Request a repaint
			this.Invalidate();

			// Call the base implementation
			base.OnMouseDown(e);
		}

		/// <summary>
		/// User released the mouse button.
		/// </summary>
		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e) {
			// Only accept left mouse button clicks
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				_buttonState = ButtonStates.MouseOver;

			// Request a repaint
			this.Invalidate();

			// Call the base implementation
			base.OnMouseUp(e);
		}

		/// <summary>
		/// User enters the button area.
		/// </summary>
		protected override void OnEnter(System.EventArgs e) {
			// Request a repaint
			this.Invalidate();

			// Call the base implementation
			base.OnEnter(e);
		}

		/// <summary>
		/// User leaves the button area.
		/// </summary>
		protected override void OnLeave(System.EventArgs e) {
			// Request a repaint
			this.Invalidate();

			// Call the base implementation
			base.OnLeave(e);
		}

		/// <summary>
		/// User clicks on the button.
		/// </summary>
		protected override void OnClick(System.EventArgs e) {
			// When pushed...
			if (_buttonState == ButtonStates.Pushed) {
				// Set back to normal
				_buttonState = ButtonStates.Normal;

				// Request a repaint
				this.Invalidate();
			}

			// Call the base implementation
			base.OnClick(e);
		}

		/// <summary>
		/// Button size has changed.
		/// </summary>
		protected override void OnSizeChanged(EventArgs e) {
			// Call the base implementation
			base.OnSizeChanged(e);

			// Reset the region
			this.RecreateRegion();

			// Request a repaint
			this.Invalidate();
		}

		/// <summary>
		/// Paint the button control.
		/// </summary>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent) {
			ButtonColors colors = this._colorsNormal;
			Graphics graph = pevent.Graphics;

			// Get the right set of colors
			if (!this.Enabled)
				colors = this._colorsDisabled;
			else if (this._buttonState == ButtonStates.MouseOver)
				colors = this._colorsHover;
			else if (this._buttonState == ButtonStates.Pushed)
				colors = this._colorsPressed;

			// Prepaire the tools
			Rectangle baseRectangle = new Rectangle(0, 0, this.Width, this.Height);
			Rectangle rectangle = baseRectangle;
			LinearGradientBrush gradient;
			int alpha = 220;
			
			// Prepaire the inner border fill effect
			ColorBlend borderBlend = new ColorBlend();
			borderBlend.Colors = new Color[] { Color.FromArgb(alpha, colors.FillColor1), Color.FromArgb(alpha, colors.FillColor2), Color.FromArgb(alpha, colors.FillColor3), Color.FromArgb(alpha, colors.FillColor4) };
			borderBlend.Positions = new float[] { 0, 0.5F, 0.5F + 0.00000001F, 1 };

			// Fill the inner border (button face)
			gradient = new LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), Color.White, Color.White);
			gradient.InterpolationColors = borderBlend;
			graph.FillRectangle(gradient, rectangle);

			// Draw the border (button border)
			gradient.LinearColors = new Color[] { colors.BorderColor1, colors.BorderColor2 };
			graph.DrawPath(new Pen(gradient), this.GetPath(this.Width - 1, this.Height - 1));
			
			// Calculate the top part of the button
			rectangle.Inflate(-2, -2);
			rectangle.Height = rectangle.Height / 2;

			// Fill the top part of the button (button face)
			gradient = new LinearGradientBrush(rectangle, colors.FillColor1, colors.FillColor2, LinearGradientMode.Vertical);
			graph.FillRectangle(gradient, rectangle);
			gradient.Dispose();

			// Calculate the bottom part of the button
			Rectangle rectangleBottom = new Rectangle(0, this.Height, this.Width, this.Height / 2);

			// Prepare the ellipse effect at the bottom part of the button
			int radius = (int) Math.Sqrt((double) ((rectangleBottom.Width * rectangleBottom.Width) + (rectangleBottom.Height * rectangleBottom.Height)));
			GraphicsPath pathEllipse = new GraphicsPath();
			pathEllipse.AddEllipse(rectangleBottom.X - (radius - rectangleBottom.Width), rectangleBottom.Y - ((radius - rectangleBottom.Height) / 2), radius, radius);

			// Fill the bottom part of the button (button face)
			SolidBrush solidBrush = new SolidBrush(colors.FillColor3);
			rectangle.Y += rectangle.Height;
			graph.FillRectangle(solidBrush, rectangle);
			solidBrush.Dispose();

			// Paint the ellipse effect at the bottom part of the button
			PathGradientBrush pathBrush = new PathGradientBrush(pathEllipse);
			pathBrush.FocusScales = new PointF(0.2F, 0.2F);
			pathBrush.CenterColor = colors.FillColor4;
			pathBrush.SurroundColors = new Color[] { colors.FillColor3 };
			pevent.Graphics.FillRectangle(pathBrush, rectangle);
			pathBrush.Dispose();
			pathEllipse.Dispose();

			// Prepare the text
			StringFormat format = new StringFormat();
			format.Alignment = this.GetHorizontalAlignment(this.TextAlign);
			format.LineAlignment = this.GetVerticalAligment(this.TextAlign);
			format.Trimming = StringTrimming.EllipsisCharacter;
			format.HotkeyPrefix = HotkeyPrefix.Show;

			// Calculate the destination for the text
			RectangleF layoutRect = baseRectangle;
			layoutRect.Inflate(-4, -4);

			// Write the text
			SolidBrush textBrush = new SolidBrush(this.Enabled ? this.ForeColor : Color.FromArgb(80,80,80));
			graph.DrawString(this.Text, this.Font, textBrush, layoutRect, format);
			textBrush.Dispose();

			// Has focus? Draw the focus area
			if (this.Focused)
				ControlPaint.DrawFocusRectangle(graph, new Rectangle(1, 1, this.Width - 2, this.Height - 2));
		}
		#endregion

		#region Drawing methods
		/// <summary>
		/// Resets the current colors to the Default.
		/// </summary>
		protected void ResetToDefaultColors() {
			// Normal colors
			this._colorsNormal.BorderColor1 = Color.FromArgb(142, 143, 143);
			this._colorsNormal.BorderColor2 = Color.FromArgb(142, 143, 143);
			this._colorsNormal.FillColor1 = Color.FromArgb(240, 240, 240);
			this._colorsNormal.FillColor2 = Color.FromArgb(235, 235, 235);
			this._colorsNormal.FillColor3 = Color.FromArgb(224, 224, 224);
			this._colorsNormal.FillColor4 = Color.FromArgb(215, 215, 215);

			// Hover colors
			this._colorsHover.BorderColor1 = Color.FromArgb(60, 127, 177);
			this._colorsHover.BorderColor2 = Color.FromArgb(60, 127, 177);
			this._colorsHover.FillColor1 = Color.FromArgb(221, 242, 252);
			this._colorsHover.FillColor2 = Color.FromArgb(215, 239, 252);
			this._colorsHover.FillColor3 = Color.FromArgb(189, 228, 250);
			this._colorsHover.FillColor4 = Color.FromArgb(171, 221, 248);

			// Pressed colors
			this._colorsPressed.BorderColor1 = Color.FromArgb(246, 241, 228);
			this._colorsPressed.BorderColor2 = Color.FromArgb(228, 218, 197);
			this._colorsPressed.FillColor1 = Color.FromArgb(255, 254, 227);
			this._colorsPressed.FillColor2 = Color.FromArgb(255, 231, 151);
			this._colorsPressed.FillColor3 = Color.FromArgb(254, 214, 101);
			this._colorsPressed.FillColor4 = Color.FromArgb(255, 239, 179);

			// Disabled colors
			this._colorsDisabled.BorderColor1 = Color.FromArgb(246, 241, 228);
			this._colorsDisabled.BorderColor2 = Color.FromArgb(228, 218, 197);
			this._colorsDisabled.FillColor1 = Color.FromArgb(200, 200, 200);
			this._colorsDisabled.FillColor2 = Color.FromArgb(200, 200, 200);
			this._colorsDisabled.FillColor3 = Color.FromArgb(200, 200, 200);
			this._colorsDisabled.FillColor4 = Color.FromArgb(200, 200, 200);
		}

		/// <summary>
		/// Gets the parts of the button as a path.
		/// </summary>
		protected GraphicsPath GetPath(int width, int height) {
			int X = width;
			int Y = height;

			Rectangle[] rects0;
			Rectangle[] rects1;

			rects0 = new Rectangle[2];
			rects0[0] = new Rectangle(2, 4, 2, Y - 8);
			rects0[1] = new Rectangle(X - 4, 4, 2, Y - 8);

			rects1 = new Rectangle[8];
			rects1[0] = new Rectangle(2, 1, 2, 2);
			rects1[1] = new Rectangle(1, 2, 2, 2);
			rects1[2] = new Rectangle(X - 4, 1, 2, 2);
			rects1[3] = new Rectangle(X - 3, 2, 2, 2);
			rects1[4] = new Rectangle(2, Y - 3, 2, 2);
			rects1[5] = new Rectangle(1, Y - 4, 2, 2);
			rects1[6] = new Rectangle(X - 4, Y - 3, 2, 2);
			rects1[7] = new Rectangle(X - 3, Y - 4, 2, 2);

			Point[] points = {
								 new Point(1, 0),
								 new Point(X-1, 0),
								 new Point(X-1, 1),
								 new Point(X, 1),
								 new Point(X, Y-1),
								 new Point(X-1, Y-1),
								 new Point(X-1, Y),
								 new Point(1, Y),
								 new Point(1, Y-1),
								 new Point(0, Y-1),
								 new Point(0, 1),
								 new Point(1, 1)};

			GraphicsPath path = new GraphicsPath();
			path.AddLines(points);

			return path;
		}

		/// <summary>
		/// Recreates the clickable region of the button.
		/// </summary>
		private void RecreateRegion() {
			this.Region = new Region(GetPath(this.Width, this.Height));
		}
		#endregion

		#region Conversion methods
		/// <summary>
		/// Get the horizontal alignment from the ContentAlignment.
		/// </summary>
		protected StringAlignment GetHorizontalAlignment(ContentAlignment alignment) {
			if (alignment == ContentAlignment.TopLeft | alignment == ContentAlignment.MiddleLeft | alignment == ContentAlignment.BottomLeft)
				return StringAlignment.Near;
			else if (alignment == ContentAlignment.TopRight | (alignment == ContentAlignment.MiddleRight) | alignment == ContentAlignment.BottomRight)
				return StringAlignment.Far;
			else
				return StringAlignment.Center;
		}

		/// <summary>
		/// Get the vertical alignment from the ContentAlignment.
		/// </summary>
		protected StringAlignment GetVerticalAligment(ContentAlignment alignment) {
			if (alignment == ContentAlignment.TopLeft | alignment == ContentAlignment.TopCenter | alignment == ContentAlignment.TopRight)
				return StringAlignment.Near;
			else if (alignment == ContentAlignment.BottomLeft | (alignment == ContentAlignment.BottomCenter) | alignment == ContentAlignment.BottomRight)
				return StringAlignment.Far;
			else
				return StringAlignment.Center;
		}
		#endregion

		/// <summary>
		/// CodeGazer button states.
		/// </summary>
		protected enum ButtonStates {
			Normal,
			MouseOver,
			Pushed
		}

		/// <summary>
		/// CodeGazer button colors.
		/// </summary>
		public struct ButtonColors {
			public Color BorderColor1;
			public Color BorderColor2;

			public Color FillColor1;
			public Color FillColor2;
			public Color FillColor3;
			public Color FillColor4;
		}
	}
}