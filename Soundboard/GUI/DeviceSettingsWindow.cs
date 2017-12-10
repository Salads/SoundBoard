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

	/// <summary>
	/// This form will let the user pick their audio devices.
	/// </summary>
	public partial class DeviceSettingsWindow : Form
	{
		public DeviceSettingsWindow()
		{
			InitializeComponent();
		}

		private void EV_SettingsWindow_OnLoad(object sender, EventArgs e)
		{
			ui_recordingDevices.Items.Add("None");
			ui_recordingDevices.SelectedIndex = 0;

			using(MMDeviceCollection deviceCollection = DeviceHelper.GetAllActiveDevices())
			foreach(MMDevice device in deviceCollection)
			{
				if(device.DataFlow == DataFlow.Render)
				{
					bool isSaved = SoundboardSettings.PlaybackDevices.Where(x => x.DeviceID == device.DeviceID).Any();
					ui_playbackDevices.Items.Add(device, isSaved);
				}
				else if(device.DataFlow == DataFlow.Capture)
				{
					ui_recordingDevices.Items.Add(device);
					if(SoundboardSettings.RecordingDevice?.Info.DeviceID == device.DeviceID)
					{
						ui_recordingDevices.SelectedItem = device;
					}
				}
			}
		}

		private void EV_OK_Clicked(object sender, EventArgs e)
		{
			// TODO(Salads): There may be a pretty clever way to do this.
			// Block if no playback devices are selected.
			if(ui_playbackDevices.CheckedItems.Count <= 0)
			{
				DialogResult result = MessageBox.Show("No playback devices were selected!\nYou will not be able to hear or play sounds!",
														"Warning",
														MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if(result == DialogResult.Cancel) { return; }
			}

			if(ui_recordingDevices.SelectedIndex == 0)
			{
				// Warn the user that they have no mic selected, and the mute mic while setting wont do anything.
				DialogResult result = MessageBox.Show("No microphone selected!\nThe \"mute mic while playing\" checkbox wont do anything!\nContinue?",
														"Warning",
														MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if(result == DialogResult.Cancel) {  return; }
			}

			// Go ahead and apply the settings.
			SoundboardSettings.ResetDevices();
			foreach(MMDevice Device in ui_playbackDevices.CheckedItems)
			{
				SoundboardSettings.PlaybackDevices.Add(new AudioDevice(Device));
			}

			if(ui_recordingDevices.SelectedIndex != 0)
			{
				SoundboardSettings.RecordingDevice = new AudioDevice(ui_recordingDevices.SelectedItem as MMDevice);
			}

			DialogResult = DialogResult.OK;

			Close();
		}
	}
}
