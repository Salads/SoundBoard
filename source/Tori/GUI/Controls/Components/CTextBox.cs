using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Soundboard.Data.Static;

namespace Soundboard.GUI.Controls.Components
{
	public partial class CTextBox : TextBox
	{
		private string _bannerText = string.Empty;

		/// <summary>
		/// Gets or sets the Banner Text for the TextBox
		/// </summary>
		[Category("Appearance")]
		public string BannerText 
		{
			get { return _bannerText; }
			set
			{
				_bannerText = value;
				UpdateCueBanner();
			}
		}

		public CTextBox() : base()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		private void UpdateCueBanner()
		{
			if(IsHandleCreated && _bannerText != null)
			{
				NativeMethods.SendMessage(Handle, NativeMethods.EM_SETCUEBANNER,  (IntPtr)1, Marshal.StringToHGlobalUni(_bannerText));
			}
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			UpdateCueBanner();
		}
	}
}
