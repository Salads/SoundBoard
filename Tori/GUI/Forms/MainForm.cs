using System;
using System.Windows.Forms;
using System.Diagnostics;
using RawInput;
using Soundboard.Data;
using System.ComponentModel;
using Soundboard.Data.Static;

namespace Soundboard
{
    public partial class MainForm : Form
	{
		private SoundPlayer m_MainSoundPlayer = new SoundPlayer()
		{
			VolumeNormalized = SBSettings.Instance.VolumeNormalized
		};

        public MainForm()
        {
            InitializeComponent();

            RI.RegisterDevices(Handle);
            ui_mediaControl.SoundPlayer = m_MainSoundPlayer;

            RawInputHandler.HotkeyPressed += EV_HotkeyPressed;

            m_MainSoundPlayer.SoundStarted += EV_MainSoundPlayer_SoundStarted;
            m_MainSoundPlayer.SoundStopped += EV_MainSoundPlayer_SoundStopped;
            ui_soundViewer.ItemSelectionChanged += EV_SoundViewer_SelectionChanged;
            ui_soundViewer.BeforeAddSoundClicked += EV_SoundViewer_BeforeAddSound;
            ui_soundViewer.SoundDoubleClicked += EV_SoundViewer_SoundDoubleClicked;

            SBSettings.Instance.RecordingDeviceChanged += EV_RecordingDeviceChanged;
            SBSettings.Instance.PropertyChanged += Settings_PropertyChanged;
            SBSettings.Instance.SelectedPlaybackDevices.RemovingItem += EV_SelectedPlaybackDevices_ItemRemoved;
        }

        #region Event Handlers

        #region Menu Events

        private void EV_Menu_HowTo_Clicked(object sender, EventArgs e)
		{
            Process.Start("https://salads.github.io/Soundboard");
        }

		private void EV_Menu_ResetDeviceSettings_Clicked(object sender, EventArgs e)
		{
			SBSettings.Instance.ResetDevices();
			SBSettings.Instance.SaveToFile();
		}

		private void EV_Menu_ResetSounds_Clicked(object sender, EventArgs e)
		{
			SBSettings.Instance.ResetSounds();
			SBSettings.Instance.SaveToFile();
			ui_soundViewer.RefreshSoundsInList();
		}

		private void EV_Menu_ResetAllSettings_Clicked(object sender, EventArgs e)
		{
			SBSettings.Instance.ResetToDefault();
			SBSettings.Instance.SaveToFile();
			ui_soundViewer.RefreshSoundsInList();
		}
        #endregion

        #region Mute Microphone Setting Events

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Apply mic settings if changed while playing.
            if (e.PropertyName == nameof(SBSettings.Instance.MuteMicrophoneWhilePlaying))
            {
                if (m_MainSoundPlayer.IsPlaying)
                {
                    SBSettings.Instance.ApplyMicSettings();
                }
            }
        }

        private void EV_RecordingDeviceChanged(object sender, EventArgs e)
        {
            if (m_MainSoundPlayer.IsPlaying)
            {
                SBSettings.Instance.ApplyMicSettings();
            }
        }

        private void EV_MainSoundPlayer_SoundStopped(object sender, EventArgs e)
        {
            if(!m_MainSoundPlayer.IsPlaying)
            {
                SBSettings.Instance.MicMuted = SBSettings.Instance.SelectedRecordingDevice?.OriginalMicMute ?? false;
            }
        }

        private void EV_MainSoundPlayer_SoundStarted(object sender, EventArgs e)
        {
            if(m_MainSoundPlayer.IsPlaying)
            {
                SBSettings.Instance.ApplyMicSettings();
            }
        }

        #endregion

        private void EV_SoundViewer_SelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                ui_mediaControl.SetSelectedSound(e.Item.Tag as Sound);
            }
        }

        private void EV_SelectedPlaybackDevices_ItemRemoved(object sender, ItemRemovedArgs<AudioDevice> e) 
		{
            m_MainSoundPlayer.StopSoundsOnDevice(e.RemovedItem);
        }

		private void EV_HotkeyPressed(object sender, HotkeyPressedArgs e) 
		{
            if(m_MainSoundPlayer.IsPlaying)
            {
                SBSettings.Instance.ApplyMicSettings();
            }
           
			m_MainSoundPlayer.Play(e.Sound, SBSettings.Instance.SelectedPlaybackDevices);
		}

		private void EV_TabControl_KeyDown(object sender, KeyEventArgs e) 
		{
            // Prevent tab control using keys to navigate since we're using hotkeys that may interfere.
			if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
				e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
			{
				e.Handled = true;
			}
		}

        private void EV_SoundViewer_SoundDoubleClicked(object sender, MouseEventArgs e)
        {
            if (ui_soundViewer.SelectedItems[0] != null)
            {
                m_MainSoundPlayer.Play(ui_soundViewer.SelectedItems[0].Tag as Sound, SBSettings.Instance.SelectedPlaybackDevices);
            }
        }

        private void EV_SoundViewer_BeforeAddSound(object sender, EventArgs e)
        {
            m_MainSoundPlayer.StopAllSounds();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // This is needed to force the tab control to initialize it's containing controls. 
            // It was causing an event to fire which would stop playing sounds when a device is unselected.
            ui_tabControl.SelectedIndex = 1;
            ui_tabControl.SelectedIndex = 2;
            ui_tabControl.SelectedIndex = 0;
        }

        private void EV_FormClosing(object sender, FormClosingEventArgs e) 
        {
            m_MainSoundPlayer.StopAllSounds();
            SBSettings.Instance.MicMuted = SBSettings.Instance.SelectedRecordingDevice?.OriginalMicMute ?? false;
            SBSettings.Instance.SaveToFile();
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
    }
}
