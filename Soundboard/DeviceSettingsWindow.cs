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

		private void SettingsWindow_Load(object sender, EventArgs e)
		{
			GUI_RecordingDevices.Items.Add("None");
			GUI_RecordingDevices.SelectedIndex = 0;

			using(MMDeviceCollection Collection = DeviceHelper.GetAllActiveDevices())
			foreach(MMDevice Device in Collection)
			{
				if(Device.DataFlow == DataFlow.Render)
				{
					bool IsSaved = SoundboardSettings.PlaybackDevices.Where(x => x.DeviceID == Device.DeviceID).Any();
					GUI_PlaybackDevices.Items.Add(Device, IsSaved);
				}
				else if(Device.DataFlow == DataFlow.Capture)
				{
					GUI_RecordingDevices.Items.Add(Device);
					if(SoundboardSettings.RecordingDevice?.Info.DeviceID == Device.DeviceID)
					{
						GUI_RecordingDevices.SelectedItem = Device;
					}
				}
			}
		}

		private void Button_OK_Click(object sender, EventArgs e)
		{
			// Block if no playback devices are selected.
			if(GUI_PlaybackDevices.CheckedItems.Count <= 0)
			{
				MessageBox.Show("No playback devices were selected!\nYou will not be able to hear or play sounds!",
								"Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if(GUI_RecordingDevices.SelectedIndex == 0)
			{
				// Warn the user that they have no mic selected, and the mute mic while setting wont do anything.
				DialogResult Result = MessageBox.Show("No microphone selected!\nThe \"mute mic while playing\" checkbox wont do anything!\nContinue?",
														"Warning",
														MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if(Result == DialogResult.Cancel) {  return; }
			}

			// Go ahead and apply the settings.
			SoundboardSettings.ResetDevices();
			foreach(MMDevice Device in GUI_PlaybackDevices.CheckedItems)
			{
				SoundboardSettings.PlaybackDevices.Add(new AudioDevice(Device));
			}

			if(GUI_RecordingDevices.SelectedIndex != 0)
			{
				SoundboardSettings.RecordingDevice = new AudioDevice(GUI_RecordingDevices.SelectedItem as MMDevice);
			}

			DialogResult = DialogResult.OK;

			Close();
		}
	}
}
