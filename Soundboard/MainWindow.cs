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
	public partial class MainWindow : Form
	{
		private List<AudioDevice> m_PlaybackDevices = new List<AudioDevice>();
		private AudioDevice m_RecordingDevice = null;

		private bool m_MuteMicWhilePlaying = true;

		public MainWindow()
		{
			InitializeComponent();

			ReloadDeviceSettings();
			if(SettingsHelper.Get().FirstRun == true)
			{
				DialogResult FirstResult = 
					MessageBox.Show(
					"Hi! Would you like to visit the \"How to\" webpage?", 
					"Welcome!", 
					MessageBoxButtons.YesNo);

				if (FirstResult == DialogResult.Yes)
				{
					OpenHelpWebpage();
				}

				SettingsHelper.Get().FirstRun = false;
				SettingsHelper.Get().Save();
			}
		}

		private void ReloadDeviceSettings()
		{
			m_PlaybackDevices.Clear();
			m_RecordingDevice = null;

			using(MMDeviceCollection ActivePlaybacks = DeviceEnumHelper.GetActivePlaybackDevices())
			{
				foreach(MMDevice PlaybackDevice in ActivePlaybacks)
				{
					if(SettingsHelper.Get().SelectedPlaybackDevices.Contains(PlaybackDevice.DeviceID))
					{
						m_PlaybackDevices.Add(new AudioDevice(PlaybackDevice));
					}
				}
			}

			using(MMDeviceCollection ActiveRecorders = DeviceEnumHelper.GetActiveRecordingDevices())
			{
				foreach(MMDevice RecordingDevice in ActiveRecorders)
				{
					if(SettingsHelper.Get().SelectedRecordingDevice.Equals(RecordingDevice.DeviceID))
					{
						m_RecordingDevice = new AudioDevice(RecordingDevice);
						break;
					}
				}
			}

			m_MuteMicWhilePlaying = SettingsHelper.Get().MuteMicWhilePlaying;
		}

		private void Menu_DeviceSettings_Click(object sender, EventArgs e)
		{
			using(DeviceSettingsWindow SettingsDialog = new DeviceSettingsWindow())
			{
				if(SettingsDialog.ShowDialog() == DialogResult.OK)
				{
					ReloadDeviceSettings();
				}
			}
		}

		private void Menu_HowTo_Click(object sender, EventArgs e)
		{
			OpenHelpWebpage();
		}

		private void OpenHelpWebpage()
		{
			Process.Start("https://salads.github.io/Soundboard");
		}

		private void Menu_ResetDeviceSettings_Click(object sender, EventArgs e)
		{
			SettingsHelper.ResetDeviceSettingsToDefault();
		}

		private void Menu_ResetFiles_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void Menu_ResetHotkeys_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void Menu_ResetAllSettings_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
