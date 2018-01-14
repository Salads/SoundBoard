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
using System.ComponentModel;
using Soundboard.Data.Static;

namespace Soundboard
{
	public partial class MainForm : Form
	{
		private SoundPlayer m_MainSoundPlayer = new SoundPlayer()
		{
			VolumeNormalized = SoundboardSettings.Instance.VolumeNormalized
		};

		public MainForm()
		{
			InitializeComponent();

			RI.RegisterDevices(Handle);
			ui_mediaControl.SoundPlayer = ui_soundViewer.SoundPlayer = m_MainSoundPlayer;

			if(SoundboardSettings.Instance.FirstRun)
			{
				DialogResult FirstResult =
				MessageBox.Show("Would you like to visit the \"How to\" webpage?",
								"Welcome!",
								MessageBoxButtons.YesNo);

				if(FirstResult == DialogResult.Yes)
				{
					_OpenHelpWebsite();
				}

				SoundboardSettings.Instance.FirstRun = false;
			}
		}

		#region Event Handlers

		#region Menu Events

		private void EV_Menu_HowTo_Clicked(object sender, EventArgs e)
		{
			_OpenHelpWebsite();
		}

		private void EV_Menu_ResetDeviceSettings_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.Instance.ResetDevices();
			SoundboardSettings.Instance.SaveToFile();
		}

		private void EV_Menu_ResetSounds_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.Instance.ResetSounds();
			SoundboardSettings.Instance.SaveToFile();
			ui_soundViewer.RefreshSoundsInList();
		}

		private void EV_Menu_ResetAllSettings_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.Instance.ResetToDefault();
			SoundboardSettings.Instance.SaveToFile();
			ui_soundViewer.RefreshSoundsInList();
		}
		#endregion

		private void EV_SelectedPlaybackDevices_ItemRemoved(object sender, ItemRemovedArgs<AudioDevice> e)
		{
			m_MainSoundPlayer.StopSoundsOnDevice(e.RemovedItem);
		}

		private void EV_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_MainSoundPlayer.StopAllSounds();
			SoundboardSettings.Instance.SaveToFile();
		}

		private void EV_HotkeyPressed(object sender, HotkeyPressedArgs e)
		{
			Debug.WriteLine("Hotkey Pressed");
			m_MainSoundPlayer.Play(e.Sound);
		}

		private void EV_TabControl_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
				e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
			{
				e.Handled = true;
			}
		}
		#endregion

		protected override void WndProc(ref Message m)
		{
			if(m.Msg == NativeMethods.WM_INPUT)
			{
				RawInputHandler.HandleRawInput(ref m);
				return;
			}

			base.WndProc(ref m);
		}

		private void _OpenHelpWebsite()
		{
			Process.Start("https://salads.github.io/Soundboard");
		}

		// This is needed to force the tab control to initialize it's containing controls. 
		// It was causing an event to fire which would stop playing sounds when a device is unselected.
		private void MainForm_Load(object sender, EventArgs e)
		{
			ui_tabControl.SelectedIndex = 1;
			ui_tabControl.SelectedIndex = 2;
			ui_tabControl.SelectedIndex = 0;

			ui_soundViewer.ItemSelectionChanged += ui_mediaControl.SoundList_ItemSelectionChanged;
			RawInputHandler.HotkeyPressed += EV_HotkeyPressed;
			SoundboardSettings.Instance.SelectedPlaybackDevices.RemovingItem += EV_SelectedPlaybackDevices_ItemRemoved;
		}
	}
}
