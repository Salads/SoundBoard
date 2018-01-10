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
		private bool IsCapturingHotkey { get; set; }
		private string m_selectedFilepath;

		private Hotkey m_currentKeys = new Hotkey();
		private SoundPlayer m_soundPlayer = new SoundPlayer()
		{
			VolumeNormalized = SoundboardSettings.VolumeNormalized
		};

		public AddSoundForm()
		{
			InitializeComponent();
			ui_mediaControl.SoundPlayer = m_soundPlayer;
			ui_mediaControl.ShowName = false;
			RawInputHandler.ExecuteHotkeys = false;

			_InitializeDeviceDropdown();

			ui_combobox_PreviewDevice.SelectedIndexChanged += Ui_combobox_PreviewDevice_SelectedIndexChanged;
			ui_button_hotkey.MouseClick += Ui_button_hotkey_MouseClick;
			RawInputHandler.KeysChanged += OnKeyAdded;
		}

		private void Ui_button_hotkey_MouseClick(object sender, MouseEventArgs e)
		{
			ui_button_hotkey.BackColor = Color.OrangeRed;
			m_currentKeys.Clear();
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
		private void OnKeyAdded(object sender, KeysChangedArgs e)
		{
			if(!IsCapturingHotkey) return;

			if(e.Action == KeysChangedAction.Added)
			{
				m_currentKeys.Add(e.Key);
			}
			else if(e.Action == KeysChangedAction.Removed)
			{
				IsCapturingHotkey = false;
				ui_button_hotkey.BackColor = SystemColors.ControlDark;
			}

			ui_button_hotkey.Text = m_currentKeys.ToString();
		}

		private void ui_button_clearHotkey_MouseClick(object sender, MouseEventArgs e)
		{
			m_currentKeys.Clear();
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
					_PopulateControlsFromFilename(diag.FileNames.First());
					ui_tooltip.SetToolTip(ui_labelFile, ui_labelFile.Text);
				}
			}
		}

		private void EV_OK_MouseClick(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(ui_labelFile.Text);
			Sound newSound = new Sound(m_selectedFilepath)
			{
				Nickname = ui_textboxNickname.Text,
				StartTime = ui_mediaControl.Position
			};

			// Copy by value into the actual hotkey.
			newSound.HotKey.CopyFrom(m_currentKeys);

			SoundboardSettings.Sounds.Add(newSound);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void AddSoundForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_soundPlayer.StopAllSounds();
			RawInputHandler.ExecuteHotkeys = true;
		}
		#endregion

		private void _PopulateControlsFromFilename(string filename)
		{
			m_selectedFilepath = filename;
			ui_labelFile.Text = Path.GetFileName(filename);
			ui_mediaControl.SetSelectedSound(filename);
		}
	}
}
