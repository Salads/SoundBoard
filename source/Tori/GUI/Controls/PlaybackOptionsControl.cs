using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Soundboard.GUI.Controls
{
	public partial class PlaybackOptionsControl : UserControl
	{
		public PlaybackOptionsControl()
		{
			InitializeComponent();

			ui_checkbox_MuteMicWhilePlaying.DataBindings.Add("Checked", SBSettings.Instance, "MuteMicrophoneWhilePlaying", false, DataSourceUpdateMode.OnPropertyChanged);
		}
	}
}
