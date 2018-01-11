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
	public partial class AddSoundForm : Form
	{
		private string SoundFullFilename { get; set; }
		private string SoundNickName { get { return ui_textboxNickname.Text; } set { ui_textboxNickname.Text = value; } }
		private Hotkey SoundHotkey { get; set; } = new Hotkey();
		private TimeSpan SoundStartTime { get { return ui_mediaControl.Position; } }

		public bool EditMode { get; private set;} = false;
		private bool IsCapturingHotkey { get; set; }
		
		private SoundPlayer m_soundPlayer = new SoundPlayer();

		public Sound SoundResult { get; set; }

		public AddSoundForm()
		{
			InitializeComponent();
			ui_mediaControl.SoundPlayer = m_soundPlayer;
			ui_mediaControl.ShowName = false;
			RawInputHandler.ExecuteHotkeys = false;

			_InitializeDeviceDropdown();

			ui_combobox_PreviewDevice.SelectedIndexChanged += Ui_combobox_PreviewDevice_SelectedIndexChanged;
			ui_button_hotkey.MouseClick += Ui_button_hotkey_MouseClick;
			RawInputHandler.KeysChanged += RawInput_KeysChanged;
		}

		public AddSoundForm(Sound sound) : this()
		{
			EditMode = true;
			Text = "Edit Sound";
			SoundResult = sound;
			_PopulateControls(SoundResult);
		}

		private void Ui_button_hotkey_MouseClick(object sender, MouseEventArgs e)
		{
			ui_button_hotkey.BackColor = Color.OrangeRed;
			ui_button_hotkey.FlatAppearance.MouseOverBackColor = ui_button_hotkey.BackColor;
			SoundHotkey.Clear();
			IsCapturingHotkey = true;
		}

		// TODO: Data binding
		private void _InitializeDeviceDropdown()
		{
			ui_combobox_PreviewDevice.Items.Clear();
			ui_combobox_PreviewDevice.Items.Add("Select Preview Device (None)");
			ui_combobox_PreviewDevice.SelectedIndex = 0;

			foreach(AudioDevice device in Devices.ActivePlaybackDevices)
			{
				ui_combobox_PreviewDevice.Items.Add(device);
				if(ReferenceEquals(device, SoundboardSettings.SelectedPreviewDevice))
				{
					ui_combobox_PreviewDevice.SelectedItem = device;
					m_soundPlayer.SetPlaybackDevice(device);
				}
			}
		}

		#region Event Handlers
		private void RawInput_KeysChanged(object sender, KeysChangedArgs e)
		{
			if(!IsCapturingHotkey) return;

			if(e.Action == KeysChangedAction.Added)
			{
				SoundHotkey.Add(e.Key);
			}
			else if(e.Action == KeysChangedAction.Removed)
			{
				IsCapturingHotkey = false;
				ui_button_hotkey.BackColor = SystemColors.ControlDark;
				ui_button_hotkey.FlatAppearance.MouseOverBackColor = Color.Goldenrod;
			}

			ui_button_hotkey.Text = SoundHotkey.ToString();
		}

		private void ui_button_clearHotkey_MouseClick(object sender, MouseEventArgs e)
		{
			SoundHotkey.Clear();
			ui_button_hotkey.Text = "No Hotkey Set (Click To Set)";
		}

		private void Ui_combobox_PreviewDevice_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_soundPlayer.StopAllSounds();
			SoundboardSettings.SelectedPreviewDevice = ui_combobox_PreviewDevice.SelectedItem as AudioDevice;

			if(SoundboardSettings.SelectedPreviewDevice != null)
			{
				m_soundPlayer.SetPlaybackDevice(SoundboardSettings.SelectedPreviewDevice);
			}
		}

		private void EV_Browse_MouseClick(object sender, MouseEventArgs e)
		{
			using(OpenFileDialog diag = new OpenFileDialog())
			{
				diag.Filter = CodecFactory.SupportedFilesFilterEn;
				if(diag.ShowDialog() == DialogResult.OK && diag.FileNames.Any())
				{
					_PopulateControls(diag.FileNames.First());
					ui_tooltip.SetToolTip(ui_labelFile, ui_labelFile.Text);
				}
			}
		}

		private void EV_OK_MouseClick(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(ui_labelFile.Text);
			
			if(EditMode)
			{
				SoundResult.FullFilepath = SoundFullFilename;
				SoundResult.Nickname = SoundNickName;
				SoundResult.StartTime = SoundStartTime;

				if(SoundResult.HotKey != SoundHotkey)
				{
					SoundboardSettings.HotkeyMap.Remove(SoundResult.HotKey);
					SoundResult.HotKey.CopyFrom(SoundHotkey);

					if(SoundResult.HotKey.Any())
					{
						SoundboardSettings.HotkeyMap.Add(SoundResult.HotKey, SoundResult);
					}
				}
			}
			else
			{
				SoundResult = new Sound(SoundFullFilename)
				{
					Nickname = SoundNickName,
					StartTime = SoundStartTime
				};
				SoundResult.HotKey.CopyFrom(SoundHotkey);
			}
			
			DialogResult = DialogResult.OK;
			Close();
		}

		private void AddSoundForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_soundPlayer.StopAllSounds();
			RawInputHandler.ExecuteHotkeys = true;
		}
		#endregion

		private void _PopulateControls(string filename)
		{
			SoundFullFilename = filename;
			ui_labelFile.Text = Path.GetFileName(filename);
			ui_mediaControl.SetSelectedSound(filename);
		}

		private void _PopulateControls(Sound sound)
		{
			SoundFullFilename = sound.FullFilepath;
			ui_labelFile.Text = sound.Filename;
			SoundNickName = sound.Nickname;
			SoundHotkey.CopyFrom(sound.HotKey);
			ui_mediaControl.SetSelectedSound(sound); // Also sets StartTime

			if(sound.HotKey.Any())
			{
				ui_button_hotkey.Text = sound.HotKey.ToString();
			}
		}

		private void ui_button_cancel_MouseClick(object sender, MouseEventArgs e)
		{
			DialogResult = DialogResult.Abort;
			Close();
		}
	}
}
