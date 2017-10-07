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
			/* Philosophy on validation
			 * 
			 * Normally, there could be
			 * a situation where a certain combination of settings "wouldn't work" in the sense that
			 * the point of the program would be defeated, or would be physically impossible. 
			 * However, I don't want the user to become "stuck" on the options screen
			 * if it happens that his computer is not capable of satisfying the requirements.
			 * 
			 * As such, I "validate" but don't force him to change settings, only notify him that 
			 * the setup is incorrect.
			 * 
			 * Back in the Main Window I will just stop him from being able to do something if the settings
			 * aren't right, and pop up a messagebox with the problem.
			 */

			if(GUI_PlaybackDevices.CheckedItems.Count <= 0)
			{
				if(DialogResult.Cancel == 
					MessageBox.Show(
						"No playback devices were selected!\nYou will not be able to hear or play sounds!\nContinue?", 
						"Error",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
				{
					return;
				}
			}
			else if(GUI_RecordingDevices.SelectedItem == null)
			{
				if(DialogResult.Cancel ==
					MessageBox.Show(
						"No microphone selected!\nYou will not be able to play sounds for others!\nContinue?",
						"Error",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
				{
					return;
				}
			}

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

			Close();
		}
	}
}
