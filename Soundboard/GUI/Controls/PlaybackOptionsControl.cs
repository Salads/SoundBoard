using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.GUI.Controls
{
	public partial class PlaybackOptionsControl : UserControl
	{
		public PlaybackOptionsControl()
		{
			InitializeComponent();

			ui_checkbox_MuteWhilePlaying.DataBindings.Add(nameof(SBSettings.Instance.MuteMicrophoneWhilePlaying), SBSettings.Instance, "Checked");
		}

		private void MuteWhilePlaying_CheckedChanged(object sender, EventArgs e)
		{
			// SoundboardSettings.Instance..MuteMicrophoneWhilePlaying = ui_checkbox_MuteWhilePlaying.Checked;
		}
	}
}
