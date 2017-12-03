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
using CSCore.CoreAudioAPI;
using System.Diagnostics;
using Soundboard.Properties;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;

namespace Soundboard
{
	public partial class MainWindow : Form
	{
		private List<ISoundOut> m_PlayingSounds = new List<ISoundOut>();
		private IWaveSource m_SelectedWaveSource;
		private TimeSpan m_SelectedPosition;

		private SoundboardSettings m_Settings;

		public MainWindow()
		{
			InitializeComponent();
			SoundList_SyncWidths();

			m_Settings = new SoundboardSettings(CreateIfDoesntExist: true);

			if(m_Settings.FirstRun)
			{
				DialogResult FirstResult =
				MessageBox.Show("Would you like to visit the \"How to\" webpage?",
								"Welcome!",
								MessageBoxButtons.YesNo);

				if(FirstResult == DialogResult.Yes)
				{
					OpenHelpWebpage();
				}

				m_Settings.FirstRun = false;
			}

			// Sync the SoundList with our settings.
			foreach(Sound NewSound in m_Settings.Sounds.Values)
			{
				ListViewItem NewItem = new ListViewItem();
				NewItem.Text = NewSound.FilenameWithFolder;
				NewItem.Tag = NewSound;

				GUI_SoundList.Items.Add(NewItem);
			}
		}

		private void Menu_DeviceSettings_Click(object sender, EventArgs e)
		{
			using(DeviceSettingsWindow SettingsDialog = new DeviceSettingsWindow(m_Settings))
			{
				SettingsDialog.ShowDialog();
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

		// TODO(Salads): GUI sync for reset settings
		private void Menu_ResetDeviceSettings_Click(object sender, EventArgs e)
		{
			m_Settings.ResetDevices();
			m_Settings.SaveToFile();
		}

		private void Menu_ResetFiles_Click(object sender, EventArgs e)
		{
			m_Settings.ResetSounds();
			m_Settings.SaveToFile();
		}

		private void Menu_ResetAllSettings_Click(object sender, EventArgs e)
		{
			m_Settings.ResetToDefault();
			m_Settings.SaveToFile();
		}

		private void MainWindow_Resize(object sender, EventArgs e)
		{
			SoundList_SyncWidths();
		}

		private void SoundList_SyncWidths()
		{
			GUI_SoundList.Columns[0].Width = this.Width - (Width / 4);
			GUI_SoundList.Columns[1].Width = (GUI_SoundList.Width - GUI_SoundList.Columns[0].Width) - 4;
		}

		private void GUI_SoundList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), e.Bounds);
			e.DrawText();
		}

		private void GUI_SoundList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			e.NewWidth = GUI_SoundList.Columns[e.ColumnIndex].Width;
			e.Cancel = true;
		}

		private void GUI_AddFileButton_Click(object sender, EventArgs e)
		{
			using(OpenFileDialog diag = new OpenFileDialog())
			{
				diag.Filter = CodecFactory.SupportedFilesFilterEn;
				if(diag.ShowDialog() == DialogResult.OK && diag.FileNames.Any())
				{
					

					Sound NewSound = new Sound(diag.FileName, new Hotkey());
					ListViewItem NewItem = new ListViewItem();
					NewItem.Text = NewSound.FilenameWithFolder;
					NewItem.Tag = NewSound;

					GUI_SoundList.Items.Add(NewItem);
					m_Settings.Sounds.Add(diag.FileName, NewSound);
				}
			}
		}

		private void GUI_PlayButton_Click(object sender, EventArgs e)
		{
			if(GUI_SoundList.SelectedItems.Count <= 0)
			{
				return;
			}

			Sound Selected = GUI_SoundList.SelectedItems[0].Tag as Sound;
			if(Selected == null) return;

			string FileName = Selected.FullFilepath;

			foreach(AudioDevice PlaybackDevice in m_Settings.PlaybackDevices)
			{
				// NOTE(Salads): Need to create one for every output because the stream is handled in WaveSource.
				//				 This means multiple outputs will advance stream position if we don't seperate them.
				IWaveSource NewSource = CodecFactory.Instance.GetCodec(FileName)
					.ToSampleSource()
					.ToStereo()
					.ToWaveSource();
				NewSource.SetPosition(m_SelectedPosition);

				ISoundOut NewSound = new WasapiOut() { Latency = 100, Device = PlaybackDevice.Info };
				NewSound.Initialize(NewSource);
				NewSound.Stopped += Sound_OnStopped;
				NewSound.Volume = GUI_VolumeBar.VolumeNormalized;
				NewSound.Play();

				m_PlayingSounds.Add(NewSound);
			}

			if(m_Settings.RecordingDevice != null)
			{
				m_Settings.RecordingDevice.Volume.IsMuted = GUI_MuteMicCheckBox.Checked;
			}
		}

		private void Sound_OnStopped(object sender, PlaybackStoppedEventArgs e)
		{
			ISoundOut Stopped = sender as ISoundOut;
			m_PlayingSounds.Remove(Stopped);

			if(m_Settings.RecordingDevice != null && !m_PlayingSounds.Any())
			{
				m_Settings.RecordingDevice.Volume.IsMuted = false;
			}

			Stopped.Dispose();
		}

		private void GUI_StopButton_Click(object sender, EventArgs e)
		{
			StopAllSounds();
		}

		private void StopAllSounds()
		{
			foreach(ISoundOut PlayingSound in m_PlayingSounds)
			{
				// NOTE(Salads): I run a task here to make sounds stop more in time with each other.
				Task.Run(() => StopSound(PlayingSound));
			}

			if(m_Settings.RecordingDevice != null)
			{
				m_Settings.RecordingDevice.Volume.IsMuted = false;
			}

			m_PlayingSounds.Clear();
		}

		private void StopSound(ISoundOut Sound)
		{
			if(Sound.PlaybackState != PlaybackState.Stopped)
			{
				Sound.Stop();
				Sound.Dispose();
			}
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopAllSounds();
			m_Settings.MuteMicWhilePlaying = GUI_MuteMicCheckBox.Checked;

			m_Settings.SaveToFile();
		}

		private void GUI_MuteMicCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if(m_Settings.RecordingDevice != null && m_PlayingSounds.Any())
			{
				m_Settings.RecordingDevice.Volume.IsMuted = GUI_MuteMicCheckBox.Checked;
			}
		}

		private void VolumeBar_ValueChanged(object sender, EventArgs e)
		{
			foreach(ISoundOut PlayingSound in m_PlayingSounds)
			{
				PlayingSound.Volume = GUI_VolumeBar.VolumeNormalized;
			}
		}

		private void GUI_SoundList_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_SelectedPosition = TimeSpan.FromSeconds(0);
			GUI_TackbarTest.Value = GUI_TackbarTest.Minimum;

			int SelectedItemsCount = GUI_SoundList.SelectedItems.Count;

			if(SelectedItemsCount <= 0)
			{
				GUI_SelectedSoundName.Text = "Nothing Selected";
			}
			else if(SelectedItemsCount > 0)
			{
				GUI_SelectedSoundName.Text = Path.GetFileName(GUI_SoundList.SelectedItems[0].Text);

				if(SelectedItemsCount > 1)
				{
					GUI_SelectedSoundName.Text += "(+" + (SelectedItemsCount - 1) + ")";
				}
			}

			if(GUI_SoundList.SelectedItems.Count <= 0)
			{
				return;
			}

			Sound Selected = GUI_SoundList.SelectedItems[0].Tag as Sound;
			if(Selected == null) return;

			string FileName = Selected.FullFilepath;

			m_SelectedWaveSource = CodecFactory.Instance.GetCodec(FileName)
					.ToSampleSource()
					.ToStereo()
					.ToWaveSource();

			TimeSpan Pos = m_SelectedWaveSource.GetPosition();
			TimeSpan Length = m_SelectedWaveSource.GetLength();
			GUI_SlideTime.Text = GetTimeSpanFormatString(Pos) + "/" + GetTimeSpanFormatString(Length);

			GUI_TackbarTest.Maximum = (int)Length.TotalSeconds;
		}

		private string GetTimeSpanFormatString(TimeSpan TheTimeSpan)
		{
			string Result = string.Empty;
			if(TheTimeSpan.Days != 0)
			{
				int CorrectLength = Math.Max(TheTimeSpan.Days.ToString().Length, 2);

				Result += string.Empty.PadLeft(CorrectLength, 'd');
				Result += "\\.";
			}

			if(TheTimeSpan.Hours != 0)
			{
				int CorrectLength = Math.Max(TheTimeSpan.Hours.ToString().Length, 2);

				Result += string.Empty.PadLeft(CorrectLength, 'h');
				Result += "\\:";
			}

			int MinuteLength = Math.Max(TheTimeSpan.Minutes.ToString().Length, 2);

			Result += string.Empty.PadLeft(MinuteLength, 'm');
			Result += "\\:";

			int SecondLength = Math.Max(TheTimeSpan.Seconds.ToString().Length, 2);

			Result += string.Empty.PadLeft(SecondLength, 's');

			return TheTimeSpan.ToString(Result);
		}

		private void GUI_SoundList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			GUI_PlayButton_Click(null, EventArgs.Empty);
		}

		private void GUI_TackbarTest_ValueChanged(object sender, EventArgs e)
		{
			TimeSpan Length = m_SelectedWaveSource.GetLength();

			TimeSpan NewPos = TimeSpan.FromSeconds(GUI_TackbarTest.Value);
			m_SelectedPosition = NewPos;
			GUI_SlideTime.Text = GetTimeSpanFormatString(NewPos) + "/" + GetTimeSpanFormatString(Length);
		}
	}
}
