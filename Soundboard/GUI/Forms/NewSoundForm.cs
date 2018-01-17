using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using Soundboard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soundboard.Data.Static;
using System.Diagnostics;

namespace Soundboard.GUI
{
    /// <summary>
    /// Opens a form that returns a new Sound. Can initialize from existing sounds.
    /// </summary>
	public partial class NewSoundForm : Form
	{
        private string m_FullFilename;
		private Hotkey m_Hotkey = new Hotkey();

		private bool IsCapturingHotkey { get; set; }
		private SoundPlayer m_soundPlayer = new SoundPlayer();

		public Sound SoundResult { get; set; }

		public NewSoundForm()
		{
			InitializeComponent();

            SBSettings.Instance.MicMuted = false;
			ui_mediaControl.SoundPlayer = m_soundPlayer;
			ui_mediaControl.ShowName = false;
            ui_mediaControl.UsePreviewDevice = true;
			RawInputHandler.ExecuteHotkeys = false; // Don't want to be playing other sounds when tinkering with a new one

            if(!DesignMode)
            {
                ui_PreviewDeviceSelector.Initialize(GUI.Controls.Components.DeviceType.Playback);
                ui_button_Hotkey.MouseClick += EV_Button_Hotkey_MouseClick;
                RawInputHandler.KeysChanged += EV_RawInput_KeysChanged;
            }
		}

		public NewSoundForm(Sound sound) : this()
		{
			Text = "Edit Sound";
			_PopulateControls(sound);
		}

        private void _PopulateControls(string filename)
        {
            m_FullFilename = filename;
            ui_label_filename.Text = Path.GetFileName(filename);
            ui_mediaControl.SetSelectedSound(filename);
        }

        private void _PopulateControls(Sound sound)
        {
            m_FullFilename = sound.FullFilepath;
            ui_label_filename.Text = sound.Filename;
            ui_textbox_nickname.Text = sound.Nickname;

            m_Hotkey.CopyFrom(sound.HotKey);
            if (sound.HotKey.Any())
            {
                ui_button_Hotkey.Text = sound.HotKey.ToString();
            }

            ui_mediaControl.SetSelectedSound(sound); // Sets StartTime
        }

        #region Event Handlers

        #region Control Event Handlers

        private void EV_Browse_MouseClick(object sender, MouseEventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.Filter = CodecFactory.SupportedFilesFilterEn;
                if (diag.ShowDialog() == DialogResult.OK && diag.FileNames.Any())
                {
                    _PopulateControls(diag.FileNames.First());
                    ui_tooltip.SetToolTip(ui_label_filename, ui_label_filename.Text);
                }
            }
        }

        private void EV_Button_Hotkey_MouseClick(object sender, MouseEventArgs e)
        {
            ui_button_Hotkey.BackColor = Color.OrangeRed;
            ui_button_Hotkey.FlatAppearance.MouseOverBackColor = ui_button_Hotkey.BackColor;
            m_Hotkey.Clear();
            IsCapturingHotkey = true;
        }

        private void EV_Button_ClearHotkey_Click(object sender, EventArgs e)
        {
            m_Hotkey.Clear();
            ui_button_Hotkey.Text = "No Hotkey Set (Click To Set)";
        }

        private void EV_OK_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(ui_label_filename.Text);

            SoundResult = new Sound(m_FullFilename)
            {
                Nickname = ui_textbox_nickname.Text,
                StartTime = ui_mediaControl.Position
            };
            SoundResult.HotKey.CopyFrom(m_Hotkey);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void EV_Button_Cancel_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
        #endregion

        // TODO: Maybe sub/unsub when recording hotkey?
        private void EV_RawInput_KeysChanged(object sender, KeysChangedArgs e)
		{
			if(!IsCapturingHotkey) return;

			if(e.Action == KeysChangedAction.Added)
			{
				m_Hotkey.Add(e.Key);
                ui_button_Hotkey.Text = m_Hotkey.ToString();
            }
			else if(e.Action == KeysChangedAction.Removed)
			{
				IsCapturingHotkey = false;
				ui_button_Hotkey.BackColor = SystemColors.ControlDark;
				ui_button_Hotkey.FlatAppearance.MouseOverBackColor = Color.Goldenrod;

                if(SBSettings.Instance.HotkeyMap.ContainsKey(m_Hotkey))
                {
                    MessageBox.Show("Hotkey already in use!", "Error", MessageBoxButtons.OK);
                    ui_button_ClearHotkey.PerformClick();
                }
			}
		}

		private void EV_AddSoundForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_soundPlayer.StopAllSounds();
			RawInputHandler.ExecuteHotkeys = true;
		}

        #endregion
    }
}
