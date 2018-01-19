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
using static System.Windows.Forms.ListView;

namespace Soundboard.GUI
{
	// TODO: Use DataGridView instead for built-in filtering and data binding.

	/// <summary>
	/// Handles adding/deleting/editing sounds. <para/>
	/// Contains ListView (Sounds), Textbox (Search), and Button(Add Sound)
	/// </summary>
	public partial class SoundViewer : UserControl
	{
		public event ListViewItemSelectionChangedEventHandler ItemSelectionChanged
		{
			add { ui_listview_Sounds.ItemSelectionChanged += value; }
			remove { ui_listview_Sounds.ItemSelectionChanged -= value; }
		}

        public event MouseEventHandler SoundDoubleClicked
        {
            add { ui_listview_Sounds.MouseDoubleClick += value; }
            remove { ui_listview_Sounds.MouseDoubleClick -= value; }
        }

        public event EventHandler BeforeAddSoundClicked;

        public SelectedListViewItemCollection SelectedItems 
        {
            get { return ui_listview_Sounds.SelectedItems; }
        }

		public SoundViewer()
		{
			InitializeComponent();

			RefreshSoundsInList();
			ui_listview_Sounds.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
			ui_listview_Sounds.Columns[0].Width = ui_listview_Sounds.Width - (ui_listview_Sounds.Columns[1].Width + 15);
		}

		public void RefreshSoundsInList(string filter = "")
		{
			ui_listview_Sounds.Items.Clear();
			List<Sound> sounds = SBSettings.Instance.Sounds.Where(x => x.FullFilepath.ToLower().Contains(filter) || x.Nickname.ToLower().Contains(filter)).ToList();

			foreach(Sound sound in sounds)
			{
				ListViewItem newItem = new ListViewItem
				{
					// TODO: Add options for default text.
					Text = sound.DisplayName,
					Tag = sound
				};

				newItem.SubItems.Add(sound.HotKey.ToString());

                ui_listview_Sounds.Items.Add(newItem);
			}
		}

        #region Event Handlers

        private void EV_Button_AddSound_MouseClick(object sender, MouseEventArgs e)
        {
            BeforeAddSoundClicked?.Invoke(this, new EventArgs());
            SBSettings.Instance.MicMuted = false;

            using (NewSoundForm form = new NewSoundForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SBSettings.Instance.Sounds.Add(form.SoundResult);
                    RefreshSoundsInList();
                }
            }
        }

        #region Toolstrip Handlers
        private void EV_ToolStrip_Edit_Click(object sender, EventArgs e)
        {
            Sound selectedSound = ui_listview_Sounds.SelectedItems[0]?.Tag as Sound;
            if (selectedSound == null) return;

            // Remove the selectedSound here to make sure the hotkey map doesnt conflict.
            SBSettings.Instance.Sounds.Remove(selectedSound);

            using (NewSoundForm form = new NewSoundForm(selectedSound))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SBSettings.Instance.Sounds.Add(form.SoundResult);
                }
                else // If we cancel just add back the previous sound.
                {
                    SBSettings.Instance.Sounds.Add(selectedSound);
                }

                RefreshSoundsInList();
            }
        }

        private void EV_ToolStrip_Delete_Click(object sender, EventArgs e)
        {
            if (ui_listview_Sounds.SelectedItems.Count < 1) return;
            SBSettings.Instance.Sounds.Remove(ui_listview_Sounds.SelectedItems[0].Tag as Sound);
            RefreshSoundsInList();
        }
        #endregion

        private void EV_Searchbox_TextChanged(object sender, EventArgs e)
        {
            RefreshSoundsInList(ui_textboxSearch.Text);
        }

        private void EV_SoundList_Resize(object sender, EventArgs e)
        {
            ui_listview_Sounds.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            ui_listview_Sounds.Columns[0].Width = ui_listview_Sounds.Width - (ui_listview_Sounds.Columns[1].Width + 15);
        }

        private void EV_SoundList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ui_contextStrip.Show(Cursor.Position);
            }
        }


        #endregion
    }
}
