using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore.Codecs;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Soundboard.Data.Interfaces;

namespace Soundboard.GUI
{
	// TODO: Use DataGridView instead for built-in filtering and data binding.

	/// <summary>
	/// Handles adding/deleting/editing sounds. <para/>
	/// Contains ListView (Sounds), Textbox (Search), and Button(Add Sound)
	/// </summary>
	public partial class SoundViewer : UserControl, ISoundPlayerUser
	{
		// TODO: Make a derived Textbox control and put this Win32 malarky in there instead.
		private const int EM_SETCUEBANNER = 0x1501;
		
		public SoundPlayer SoundPlayer { get; set; }

		public event ListViewItemSelectionChangedEventHandler ItemSelectionChanged
		{
			add { ui_soundList.ItemSelectionChanged += value; }
			remove { ui_soundList.ItemSelectionChanged -= value; }
		}

		public SoundViewer()
		{
			InitializeComponent();
			SendMessage(ui_textboxSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
			RefreshSoundsInList();
		}

		/// <summary>
		/// Imported, lParam is a string because we only use it for ghost text of textbox.
		/// </summary>
		[DllImport("User32.dll")] // TODO: Move this to somewhere proper.
		private static extern Int32 SendMessage(IntPtr hWnd, UInt32 Msg, UInt32 wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		#region Event Handlers

		private void EV_Button_AddSound_MouseClick(object sender, MouseEventArgs e)
		{
			using(AddSoundForm form = new AddSoundForm())
			{
				if(form.ShowDialog() == DialogResult.OK)
				{
					RefreshSoundsInList();
				}
			}
		}

		private void EV_ListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(ui_soundList.SelectedItems[0] != null)
			{
				SoundPlayer.Play(ui_soundList.SelectedItems[0].Tag as Sound);
			}
		}

		private void EV_Searchbox_TextChanged(object sender, EventArgs e)
		{
			RefreshSoundsInList(ui_textboxSearch.Text);
		}

		private void EV_SoundList_Resize(object sender, EventArgs e)
		{
			int FullWidth = Width - 4 - SystemInformation.VerticalScrollBarWidth;
			ui_soundList.Columns[0].Width = (int)(0.70f * FullWidth);
			ui_soundList.Columns[1].Width = (int)(0.30f * FullWidth);
		}

		private void SoundList_MouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				ui_contextStrip.Show(Cursor.Position);
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(ui_soundList.SelectedItems.Count < 1) return;
			SoundboardSettings.Sounds.Remove(ui_soundList.SelectedItems[0].Tag as Sound);
			RefreshSoundsInList();
		}
		#endregion

		public void RefreshSoundsInList(string filter = "")
		{
			ui_soundList.Items.Clear();
			List<Sound> sounds = SoundboardSettings.Sounds.Where(x => x.FullFilepath.ToLower().Contains(filter) || x.Nickname.ToLower().Contains(filter)).ToList();

			foreach(Sound sound in sounds)
			{
				ListViewItem newItem = new ListViewItem
				{
					// TODO: Add options for default text.
					Text = (string.IsNullOrEmpty(sound.Nickname) ? sound.FilenameWithFolder : sound.Nickname),
					Tag = sound
				};

				newItem.SubItems.Add(sound.HotKey.ToString());
				ui_soundList.Items.Add(newItem);
			}
		}
	}
}
