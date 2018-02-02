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
        private string ResultFilename { get; set; }
        private string ResultNickname { get { return ui_textbox_nickname.Text; } set { ui_textbox_nickname.Text = value; } }
        private Hotkey ResultHotkey { get; set; } = new Hotkey();
        private TimeSpan ResultStartTime { get { return ui_mediaControl.Position; } }

		private bool IsCapturingHotkey { get; set; }
		private SoundPlayer m_soundPlayer = new SoundPlayer();

		public Sound SoundResult { get; set; }

		public NewSoundForm()
		{
			InitializeComponent();

            SBSettings.Instance.MicMuted = SBSettings.Instance.SelectedRecordingDevice?.OriginalMicMute ?? false;
            ui_mediaControl.SoundPlayer = m_soundPlayer;
			ui_mediaControl.ShowName = false;
            ui_mediaControl.UsePreviewDevice = true;
			RawInputHandler.ExecuteHotkeys = false; // Don't want to be playing other sounds when tinkering with a new one

            if(!DesignMode)
            {
                ui_PreviewDeviceSelector.Initialize(DeviceType.Preview);
                ui_PreviewDeviceSelector.SelectedIndexChanged += EV_PreviewDeviceSelector_IndexChanged;
                ui_button_Hotkey.MouseClick += EV_Button_Hotkey_MouseClick;
                RawInputHandler.KeysChanged += EV_RawInput_KeysChanged;
            }
		}

        /// <summary>
        /// Constructor for editing sounds.
        /// </summary>
        /// <param name="sound">Sound to edit</param>
        public NewSoundForm(Sound sound) : this()
		{
			Text = "Edit Sound";
			_PopulateControls(sound);
		}

        private bool _ValidateOptions()
        {
            bool filename_valid = File.Exists(ResultFilename);
            bool nickname_valid = !string.IsNullOrWhiteSpace(ui_textbox_nickname.Text);
            bool hotkey_valid = !ResultHotkey.Any() || !SBSettings.Instance.HotkeyMap.ContainsKey(ResultHotkey);

            // didn't check time since it's assumed correct all the time.
            string error_result = string.Empty;
            if(!filename_valid)
            {
                error_result += "File doesn't exist!" + Environment.NewLine;
            }

            if(!hotkey_valid)
            {
                error_result += "Hotkey is already in use!";
            }

            if(!nickname_valid) // Since nickname isn't needed, just trim down the whitespace.
            {
                ResultNickname = " ";
            }

            if(error_result != string.Empty)
            {
                MessageBox.Show(error_result, "Invalid Sound Options!", MessageBoxButtons.OK);
            }

            return filename_valid && hotkey_valid;
        }
            

        private void _PopulateControls(string filename)
        {
            ResultFilename = filename;
            ui_label_filename.Text = Path.GetFileName(filename);
            ui_mediaControl.SetSelectedSound(filename);
        }

        private void _PopulateControls(Sound sound)
        {
            ResultFilename = sound.FullFilepath;
            ui_label_filename.Text = sound.Filename;
            ui_textbox_nickname.Text = sound.Nickname;

            ResultHotkey.CopyFrom(sound.HotKey);
            if (sound.HotKey.Any())
            {
                ui_button_Hotkey.Text = sound.HotKey.ToString();
            }

            ui_mediaControl.SetSelectedSound(sound); // Sets StartTime
        }

        #region Event Handlers

        #region Control Event Handlers

        private void EV_PreviewDeviceSelector_IndexChanged(object sender, EventArgs e)
        {
            m_soundPlayer.StopAllSounds();
        }

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
            ResultHotkey.Clear();
            IsCapturingHotkey = true;
        }

        private void EV_Button_ClearHotkey_Click(object sender, EventArgs e)
        {
            ResultHotkey.Clear();
            ui_button_Hotkey.Text = "No Hotkey Set (Click To Set)";
        }

        private void EV_OK_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_ValidateOptions()) return;

            SoundResult = new Sound(ResultFilename)
            {
                Nickname = ResultNickname,
                StartTime = ResultStartTime
            };
            SoundResult.HotKey.CopyFrom(ResultHotkey);

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
				ResultHotkey.Add(e.Key);
                ui_button_Hotkey.Text = ResultHotkey.ToString();
            }
			else if(e.Action == KeysChangedAction.Removed)
			{
				IsCapturingHotkey = false;
				ui_button_Hotkey.BackColor = SystemColors.ControlDark;
				ui_button_Hotkey.FlatAppearance.MouseOverBackColor = Color.Goldenrod;

                if(SBSettings.Instance.HotkeyMap.ContainsKey(ResultHotkey))
                {
                    MessageBox.Show("Hotkey \"" + ResultHotkey.ToString() + "\" already in use!", "Error", MessageBoxButtons.OK);
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
