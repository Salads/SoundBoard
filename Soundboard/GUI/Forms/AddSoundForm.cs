using CSCore.Codecs;
using Soundboard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.GUI
{
	public partial class AddSoundForm : Form
	{
		private bool IsCapturingHotkey { get; set; }

		private Hotkey m_CurrentKeystroke = new Hotkey();
		private SoundPlayer m_soundPlayer = new SoundPlayer();

		public AddSoundForm()
		{
			InitializeComponent();
			RawInputHandler.KeysChanged += OnKeyAdded;
			ui_mediaControl.SoundPlayer = m_soundPlayer;

			RawInputHandler.HotkeysEnabled = false;
		}

		private void _PopulateControlsFromFilename(string filename)
		{
			ui_labelFile.Text = filename;
			ui_mediaControl.SetSelectedSound(filename);
		}

		private void OnKeyAdded(object sender, KeysChangedArgs e)
		{
			if(!IsCapturingHotkey) return;

			if(e.Action == KeysChangedAction.Added)
			{
				m_CurrentKeystroke.Add(e.Key);
			}
			else if(e.Action == KeysChangedAction.Removed)
			{
				IsCapturingHotkey = false;
			}

			ui_textbox_hotkey.Text = m_CurrentKeystroke.ToString();
		}

		private void EV_Browse_MouseClick(object sender, MouseEventArgs e)
		{
			using(OpenFileDialog diag = new OpenFileDialog())
			{
				diag.Filter = CodecFactory.SupportedFilesFilterEn;
				if(diag.ShowDialog() == DialogResult.OK && diag.FileNames.Any())
				{
					_PopulateControlsFromFilename(diag.FileNames.First());
				}
			}
		}

		private void EV_OK_MouseClick(object sender, MouseEventArgs e)
		{
			Sound newSound = new Sound(ui_labelFile.Text)
			{
				Nickname = ui_textboxNickname.Text,
				StartTime = TimeSpan.FromSeconds(ui_mediaControl.StartSeconds)
			};

			// Copy by value into the actual hotkey.
			newSound.HotKey.CopyFrom(m_CurrentKeystroke);

			SoundboardSettings.Sounds.Add(newSound);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void Textbox_Hotkey_Click(object sender, EventArgs e)
		{
			IsCapturingHotkey = true;
			m_CurrentKeystroke.Clear();
		}

		private void AddSoundForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_soundPlayer.StopAllSounds();
			RawInputHandler.HotkeysEnabled = true;
		}
	}
}
