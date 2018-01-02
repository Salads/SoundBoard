using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using CSCore.Codecs;
using RawInput;
using System.Runtime.InteropServices;
using Soundboard.Data;
using System.Collections.Specialized;

namespace Soundboard
{
	public partial class MainForm : Form
	{
		private SoundPlayer m_MainSoundPlayer = new SoundPlayer();

		public MainForm()
		{
			InitializeComponent();

			RI.RegisterDevices(Handle);
			ui_soundList.SoundPlayer = ui_mediaControl.SoundPlayer = m_MainSoundPlayer;
			ui_mediaControl.HookListView(ui_soundList.ui_soundList);
			ui_soundList.RefreshSoundsInList();

			RawInputHandler.HotkeyPressed += EV_HotkeyPressed;
			SoundboardSettings.PlaybackDevices.CollectionChanged += PlaybackDevices_CollectionChanged;

			if(SoundboardSettings.FirstRun)
			{
				DialogResult FirstResult =
				MessageBox.Show("Would you like to visit the \"How to\" webpage?",
								"Welcome!",
								MessageBoxButtons.YesNo);

				if(FirstResult == DialogResult.Yes)
				{
					OpenHelpWebpage();
				}

				SoundboardSettings.FirstRun = false;
			}
		}

		#region Event Handlers

		#region Menu Events

		private void EV_Menu_HowTo_Clicked(object sender, EventArgs e)
		{
			OpenHelpWebpage();
		}

		private void EV_Menu_ResetDeviceSettings_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.ResetDevices();
			SoundboardSettings.SaveToFile();
		}

		private void EV_Menu_ResetSounds_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.ResetSounds();
			SoundboardSettings.SaveToFile();
			ui_soundList.RefreshSoundsInList();
		}

		private void EV_Menu_ResetAllSettings_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.ResetToDefault();
			SoundboardSettings.SaveToFile();
			ui_soundList.RefreshSoundsInList();
		}
		#endregion

		private void PlaybackDevices_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach(var item in e.OldItems)
				{
					AudioDevice device = item as AudioDevice;
					if(device == null) continue;

					m_MainSoundPlayer.StopSoundsOnDevice(device);
				}
			}
		}

		private void EV_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_MainSoundPlayer.StopAllSounds();
			SoundboardSettings.SaveToFile();
		}

		private void EV_HotkeyPressed(object sender, HotkeyPressedArgs e)
		{
			m_MainSoundPlayer.Play(e.Sound);
		}
		#endregion

		protected override void WndProc(ref Message m)
		{
			if(m.Msg == RI.WM_INPUT)
			{
				RawInputHandler.HandleRawInput(ref m);
				return;
			}

			base.WndProc(ref m);
		}

		private void OpenHelpWebpage()
		{
			Process.Start("https://salads.github.io/Soundboard");
		}
	}
}
