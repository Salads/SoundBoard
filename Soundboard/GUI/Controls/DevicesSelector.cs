using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using Soundboard.Data.Static;

namespace Soundboard.GUI
{
	public partial class DevicesSelector : UserControl
	{
		public DevicesSelector()
		{
			InitializeComponent();

			if(!DesignMode)
			{
				ui_PlaybackDevicesSelector.Initialize();
				ui_RecordingDeviceSelector.Initialize(GUI.Controls.Components.DeviceType.Recording);
				ui_RecordingDeviceSelector.SelectedIndexChanged += EV_RecordingDeviceSelector_SelectedIndexChanged;
			}
		}

		private void EV_RecordingDeviceSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
            // Unmute the previous recording device if there is one.
            SBSettings.Instance.MicMuted = false;

			SBSettings.Instance.SelectedRecordingDevice = (ui_RecordingDeviceSelector.SelectedIndex == 0 ? null : ui_RecordingDeviceSelector.SelectedItem as AudioDevice);
		}
	}
}
