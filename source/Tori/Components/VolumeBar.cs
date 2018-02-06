using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Soundboard
{
	public partial class VolumeBar : Control
	{
		private Rectangle m_VolumeBarRect = new Rectangle();
		private Rectangle m_BarHitboxRect = new Rectangle();
		private Pen m_VolumeBorderPen = new Pen(Color.Gray);
		private readonly float[] m_FullInterpPositions = { 0.0f, 0.8f, 0.85f, 1.0f };
		private readonly Color[] m_FullInterpColors = { Color.LightGreen, Color.LightGreen, Color.Yellow, Color.Red };

		private readonly uint VOLUME_MAX = 100;
		private readonly uint VOLUME_MIN = 0;

		private bool m_IsBeingDragged = false;

		private uint _Volume;

		/// <summary>
		/// Gets the volume in a normalized format between 0.0f and 1.0f.
		/// </summary>
		[Browsable(false)]
		public float VolumeNormalized 
		{
			get
			{
				return ((float)Volume / VOLUME_MAX);
			}
			set
			{
				if(value > 1.0f) { value = 1.0f; }
				if(value < 0.0f) { value = 0.0f; }

				Volume = (uint)(value * VOLUME_MAX);
			}
		}

		/// <summary>
		/// Gets/Sets the volume as a value between volume min and max. (Not normalized)
		/// </summary>
		[Category("Behavior")]
		[Description("Sets initial volume, from MinVolume to MaxVolume.")]
		public uint Volume
		{
			get
			{
				return _Volume;
			}

			set
			{
				if(value >= VOLUME_MIN && value <= VOLUME_MAX)
				{
					if(_Volume != value)
					{
						_Volume = value;
						VolumeChanged?.BeginInvoke(this, EventArgs.Empty, null, null);
						Invalidate();
					}
				}
			}
		}

		public VolumeBar()
		{
			SetStyle(ControlStyles.ResizeRedraw, true);

			InitializeComponent();
			DoubleBuffered = true;
		}

		[Category("Property Changed")]
		[Description("Fires when Volume is changed.")]
		public event EventHandler VolumeChanged;

		#region Event Handlers
		protected override void OnPaint(PaintEventArgs e)
		{
			int fullBarWidth = e.ClipRectangle.Width - 1;
			int fullBarHeight = e.ClipRectangle.Height / 2;
			int fullBarStartX = e.ClipRectangle.Left;
			int fullBarStartY = e.ClipRectangle.Top + fullBarHeight - 1;

			float normalizedVolume = VolumeNormalized;
			int volumeBarWidth = Convert.ToInt32(fullBarWidth * normalizedVolume);
			Rectangle VolumeBar = new Rectangle(fullBarStartX, fullBarStartY, volumeBarWidth, fullBarHeight);
			m_VolumeBarRect = new Rectangle(fullBarStartX, fullBarStartY, fullBarWidth, fullBarHeight);
			m_BarHitboxRect = m_VolumeBarRect;
			m_BarHitboxRect.Width++;

			if(_IsSizeValid(Size) && _IsRectangleValid(m_VolumeBarRect))
			{
				// Draw volume icon thing
				Bitmap iconSpeaker = Properties.Resources.__Volume_Mute;
				if(Volume > 65)
				{
					iconSpeaker = Properties.Resources.__Volume_High;
				}
				else if(Volume > 30)
				{
					iconSpeaker = Properties.Resources.__Volume_Medium;
				}
				else if(Volume > 0)
				{
					iconSpeaker = Properties.Resources.__Volume_Low;
				}

				int ImageDimension = fullBarHeight - 1;
                int ImageStartY = e.ClipRectangle.Y;

                e.Graphics.DrawImage(iconSpeaker, e.ClipRectangle.X, ImageStartY, ImageDimension, ImageDimension);
                // e.Graphics.DrawRectangle(Pens.Green, e.ClipRectangle.X, ImageStartY, ImageDimension, ImageDimension);

                // Draw text
                float emSize = ImageDimension / 2.0f;
                if(emSize > 0)
                {
                    Font labelFont = new Font(Font.FontFamily, emSize, FontStyle.Regular);

                    int descent = labelFont.FontFamily.GetCellDescent(FontStyle.Regular);
                    int ascent = labelFont.FontFamily.GetCellAscent(FontStyle.Regular);
                    int ascentPixel = (int)labelFont.Size * ascent / labelFont.FontFamily.GetEmHeight(FontStyle.Regular);
                    int descentPixel = (int)labelFont.Size * descent / labelFont.FontFamily.GetEmHeight(FontStyle.Regular);
                    int fontPixel = ascentPixel + descentPixel;

                    int diff = ImageDimension - fontPixel;

                    e.Graphics.DrawString(Volume + "%",
                        labelFont,
                        Brushes.Black,
                        new Point(e.ClipRectangle.X + ImageDimension, ImageStartY + (diff / 4)));
                }

				// Draw bar graphic
				if(volumeBarWidth > 0)
				{
					LinearGradientBrush gradient = new LinearGradientBrush(m_VolumeBarRect, Color.Empty, Color.Empty, LinearGradientMode.Horizontal);
					ColorBlend gradientColorBlend = new ColorBlend
					{
						Colors = m_FullInterpColors,
						Positions = m_FullInterpPositions
					};

					gradient.InterpolationColors = gradientColorBlend;
					e.Graphics.FillRectangle(gradient, m_VolumeBarRect);

					// Cheat a bit a just draw a rect.
					int barEndX = fullBarStartX + volumeBarWidth;
					int remainingWidth = e.ClipRectangle.Width - volumeBarWidth;
					e.Graphics.FillRectangle(new SolidBrush(BackColor), barEndX, fullBarStartY, remainingWidth, fullBarHeight);
				}
				
				// Draw border
				e.Graphics.DrawRectangle(m_VolumeBorderPen, m_VolumeBarRect);
			}

			base.OnPaint(e);
		}

        private void EV_SizeChanged(object sender, EventArgs e)
		{
			Invalidate();
		}

        #region Override Events
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            m_IsBeingDragged = true;
            _UpdateVolumeFromMouse();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            m_IsBeingDragged = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (m_IsBeingDragged)
            {
                _UpdateVolumeFromMouse();
            }
        }
        #endregion

        #endregion

        private void _UpdateVolumeFromMouse()
		{
			Point clientMousePos = PointToClient(Cursor.Position);
			if(!m_BarHitboxRect.Contains(clientMousePos) && !m_IsBeingDragged)
			{
				return;
			}

			if(clientMousePos.X < 0)
			{
				Volume = VOLUME_MIN;
				return;
			}
			else if(clientMousePos.X >= m_VolumeBarRect.Width)
			{
				Volume = VOLUME_MAX;
				return;
			}
			else
			{
				float normalizedMousePos = Convert.ToSingle(clientMousePos.X) / Convert.ToSingle(m_VolumeBarRect.Width);
				Volume = Convert.ToUInt32(normalizedMousePos * Convert.ToSingle(VOLUME_MAX));
			}
		}

		private bool _IsSizeValid(Size size)
		{
			return (size.Width > 0 && size.Height > 0);
		}

		private bool _IsRectangleValid(Rectangle rectangle)
		{
			return (rectangle.Width > 0 && rectangle.Height > 0);
		}
	}
}
