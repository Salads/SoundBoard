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

			ReloadSettings();
		}

		private void ToolStripItem_Settings_Click(object sender, EventArgs e)
		{
			using(SettingsWindow SettingsDialog = new SettingsWindow())
			{
				if(SettingsDialog.ShowDialog() == DialogResult.OK)
				{
					ReloadSettings();
				}
			}

		}

		private void ReloadSettings()
		{
			m_PlaybackDevices.Clear();
			m_RecordingDevice = null;

			using(MMDeviceCollection ActivePlaybacks = DeviceEnumHelper.GetActivePlaybackDevices())
			{
				foreach(MMDevice PlaybackDevice in ActivePlaybacks)
				{
					if(SettingsHelper.GetSettings().SelectedPlaybackDevices.Contains(PlaybackDevice.DeviceID))
					{
						m_PlaybackDevices.Add(new AudioDevice(PlaybackDevice));
					}
				}
			}

			using(MMDeviceCollection ActiveRecorders = DeviceEnumHelper.GetActiveRecordingDevices())
			{
				foreach(MMDevice RecordingDevice in ActiveRecorders)
				{
					if(SettingsHelper.GetSettings().SelectedRecordingDevice.Equals(RecordingDevice.DeviceID))
					{
						m_RecordingDevice = new AudioDevice(RecordingDevice);
					}
				}
			}

			m_MuteMicWhilePlaying = SettingsHelper.GetSettings().MuteMicWhilePlaying;
		}
	}
}
