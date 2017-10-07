using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;
using System.Diagnostics;
using Soundboard.Properties;

namespace Soundboard
{
	public partial class DeviceSettingsWindow : Form
	{
		public DeviceSettingsWindow()
		{
			InitializeComponent();
		}

		private void SettingsWindow_Load(object sender, EventArgs e)
		{
			using(MMDeviceCollection AudioDevices = DeviceEnumHelper.GetAllActiveDevices())
			{
				foreach(MMDevice Device in AudioDevices)
				{
					if(Device.DataFlow == DataFlow.Render)
					{
						bool IsSaved = false;
						if(SettingsHelper.Get().SelectedPlaybackDevices.Contains(Device.DeviceID))
						{
							IsSaved = true;
						}

						GUI_PlaybackDevices.Items.Add(Device, IsSaved);
					}
					else if(Device.DataFlow == DataFlow.Capture)
					{
						GUI_RecordingDevices.Items.Add(Device);

						if(SettingsHelper.Get().SelectedRecordingDevice == Device.DeviceID)
						{
							GUI_RecordingDevices.SelectedItem = Device;
						}
					}
				}
			}

			if(GUI_RecordingDevices.Items.Count > 0 && GUI_RecordingDevices.SelectedItem == null)
			{
				GUI_RecordingDevices.SelectedIndex = 0;
			}

			GUI_MicToggle.Checked = SettingsHelper.Get().MuteMicWhilePlaying;
		}

		private void Button_OK_Click(object sender, EventArgs e)
		{

			// TODO(Salads): Validate and implement behavior for settings
			if(GUI_PlaybackDevices.CheckedItems.Count <= 0)
			{
				DialogResult = DialogResult.Abort;
			}
			else
			{
				Settings _Settings = SettingsHelper.Get();
				_Settings.SelectedPlaybackDevices.Clear();
				foreach(MMDevice Device in GUI_PlaybackDevices.CheckedItems)
				{
					_Settings.SelectedPlaybackDevices.Add(Device.DeviceID);
				}

				_Settings.SelectedRecordingDevice = (GUI_RecordingDevices.SelectedItem as MMDevice).DeviceID;
				_Settings.MuteMicWhilePlaying = GUI_MicToggle.Checked;
				_Settings.Save();

				DialogResult = DialogResult.OK;
			}

			Close();
		}
	}
}
