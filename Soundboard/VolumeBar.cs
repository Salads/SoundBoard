using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Soundboard;

namespace Soundboard
{
	public partial class VolumeBar : UserControl
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
				return (Volume - (float)VOLUME_MIN) / ((float)VOLUME_MAX - VOLUME_MIN);
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
			InitializeComponent();

			DoubleBuffered = true;
		}

		[Category("Property Changed")]
		[Description("Fires when Volume is changed.")]
		public event EventHandler VolumeChanged;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			int FullBarWidth = e.ClipRectangle.Width - 1;
			int FullBarHeight = e.ClipRectangle.Height / 2;
			int FullBarStartX = e.ClipRectangle.Left;
			int FullBarStartY = e.ClipRectangle.Top + FullBarHeight - 1;

			float NormalizedVolume = _GetNormalizedVolume();
			int VolumeBarWidth = Convert.ToInt32(FullBarWidth * NormalizedVolume);
			Rectangle VolumeBar = new Rectangle(FullBarStartX, FullBarStartY, VolumeBarWidth, FullBarHeight);
			m_VolumeBarRect = new Rectangle(FullBarStartX, FullBarStartY, FullBarWidth, FullBarHeight);
			m_BarHitboxRect = m_VolumeBarRect;
			m_BarHitboxRect.Width++;

			if(_IsSizeValid(Size) && _IsRectangleValid(m_VolumeBarRect))
			{
				// Draw volume icon thing
				Bitmap SpeakerIcon = Properties.Resources.__Volume_Mute;
				if(Volume > 65)
				{
					SpeakerIcon = Properties.Resources.__Volume_High;
				}
				else if(Volume > 30)
				{
					SpeakerIcon = Properties.Resources.__Volume_Medium;
				}
				else if(Volume > 0)
				{
					SpeakerIcon = Properties.Resources.__Volume_Low;
				}

				e.Graphics.DrawImage(SpeakerIcon, e.ClipRectangle.X, e.ClipRectangle.Y - 4, 25, 25);

				// Draw text
				e.Graphics.DrawString("" + Volume + "%",
					Font,
					Brushes.Black,
					new Point(e.ClipRectangle.X + 30, e.ClipRectangle.Y));

				// Draw bar graphic
				if(VolumeBarWidth > 0)
				{
					LinearGradientBrush Gradient = new LinearGradientBrush(m_VolumeBarRect, Color.Empty, Color.Empty, LinearGradientMode.Horizontal);
					ColorBlend GradientColorBlend = new ColorBlend
					{
						Colors = m_FullInterpColors,
						Positions = m_FullInterpPositions
					};

					Gradient.InterpolationColors = GradientColorBlend;
					e.Graphics.FillRectangle(Gradient, m_VolumeBarRect);

					// Cheat a bit a just draw a rect.
					int BarEndX = FullBarStartX + VolumeBarWidth;
					int RemainingWidth = e.ClipRectangle.Width - VolumeBarWidth;
					e.Graphics.FillRectangle(new SolidBrush(BackColor), BarEndX, FullBarStartY, RemainingWidth, FullBarHeight);
				}
				
				// Draw border
				e.Graphics.DrawRectangle(m_VolumeBorderPen, m_VolumeBarRect);
			}
		}

		private float _GetNormalizedVolume()
		{
			return Volume / Convert.ToSingle(VOLUME_MAX);
		}

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

			if(m_IsBeingDragged)
			{
				_UpdateVolumeFromMouse();
			}
		}

		private void _UpdateVolumeFromMouse()
		{
			Point ClientMousePos = PointToClient(Cursor.Position);
			if(!m_BarHitboxRect.Contains(ClientMousePos) && !m_IsBeingDragged)
			{
				return;
			}

			if(ClientMousePos.X < 0)
			{
				Volume = VOLUME_MIN;
				return;
			}
			else if(ClientMousePos.X >= m_VolumeBarRect.Width)
			{
				Volume = VOLUME_MAX;
				return;
			}
			else
			{
				float NormalizedMousePos = Convert.ToSingle(ClientMousePos.X) / Convert.ToSingle(m_VolumeBarRect.Width);
				Volume = Convert.ToUInt32(NormalizedMousePos * Convert.ToSingle(VOLUME_MAX));
			}
		}

		private bool _IsSizeValid(Size TheSize)
		{
			return (TheSize.Width > 0 && TheSize.Height > 0);
		}

		private bool _IsRectangleValid(Rectangle TheRectangle)
		{
			return (TheRectangle.Width > 0 && TheRectangle.Height > 0);
		}
	}
}
