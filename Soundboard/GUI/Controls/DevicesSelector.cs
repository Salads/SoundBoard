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
	// TODO: Put these events into the component?

	public partial class DevicesSelector : UserControl
	{
		public DevicesSelector()
		{
			InitializeComponent();

			ui_RecordingDeviceSelector.Initialize(GUI.Controls.Components.DeviceType.Recording);
			ui_PlaybackDevicesSelector.InitializeOptions();
		}
	}
}
