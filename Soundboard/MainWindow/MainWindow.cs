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
		public MainWindow()
		{
			InitializeComponent();
			SoundList_SyncWidths();

			ui_soundPanel.SelectedSounds = GUI_SoundList.SelectedItems;

			SoundboardSettings.LoadFromFile();

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

			// Sync the SoundList with our settings.
			foreach(Sound NewSound in SoundboardSettings.Sounds.Values)
			{
				ListViewItem NewItem = new ListViewItem();
				NewItem.Text = NewSound.FilenameWithFolder;
				NewItem.Tag = NewSound;

				GUI_SoundList.Items.Add(NewItem);
			}
		}

		private void EV_Menu_DeviceSettings_Clicked(object sender, EventArgs e)
		{
			using(DeviceSettingsWindow SettingsDialog = new DeviceSettingsWindow())
			{
				SettingsDialog.ShowDialog();
			}
		}

		private void EV_Menu_HowTo_Clicked(object sender, EventArgs e)
		{
			OpenHelpWebpage();
		}

		private void OpenHelpWebpage()
		{
			Process.Start("https://salads.github.io/Soundboard");
		}

		// TODO(Salads): GUI sync for reset settings
		private void EV_Menu_ResetDeviceSettings_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.ResetDevices();
			SoundboardSettings.SaveToFile();
		}

		private void EV_Menu_ResetSounds_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.ResetSounds();
			SoundboardSettings.SaveToFile();
		}

		private void EV_Menu_ResetAllSettings_Clicked(object sender, EventArgs e)
		{
			SoundboardSettings.ResetToDefault();
			SoundboardSettings.SaveToFile();
		}

		private void EV_MainWindow_OnResize(object sender, EventArgs e)
		{
			SoundList_SyncWidths();
		}

		private void SoundList_SyncWidths()
		{
			GUI_SoundList.Columns[0].Width = this.Width - (Width / 4);
			GUI_SoundList.Columns[1].Width = (GUI_SoundList.Width - GUI_SoundList.Columns[0].Width) - 4;
		}

		private void EV_SoundList_OnDrawHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), e.Bounds);
			e.DrawText();
		}

		private void EV_SoundList_SizeChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			e.NewWidth = GUI_SoundList.Columns[e.ColumnIndex].Width;
			e.Cancel = true;
		}

		private void EV_AddFile_Clicked(object sender, EventArgs e)
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
					SoundboardSettings.Sounds.Add(diag.FileName, NewSound);
				}
			}
		}

		private void EV_FormClosing(object sender, FormClosingEventArgs e)
		{
			ui_soundPanel.StopAllSounds();
			SoundboardSettings.SaveToFile();
		}

		private void EV_SelectedSoundIndexChanged(object sender, EventArgs e)
		{
			ui_soundPanel.UpdateSelectedSound();
		}

		private void EV_SoundDoubleClicked(object sender, MouseEventArgs e)
		{
			ui_soundPanel.UpdateSelectedSound(true);
		}
	}
}
