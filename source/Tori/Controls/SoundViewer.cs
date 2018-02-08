using System;
using System.Windows.Forms;
using Soundboard.Data;
using Equin.ApplicationFramework;

namespace Soundboard.GUI
{
    /// <summary>
    /// Handles adding/deleting/editing sounds. <para/>
    /// Contains ListView (Sounds), Textbox (Search), and Button(Add Sound)
    /// </summary>
    public partial class SoundViewer : UserControl
    {
        private BindingListView<Sound> m_soundsSource;

        public event DataGridViewCellEventHandler CellDoubleClick
        {
            add { ui_DataGridView_Sounds.CellDoubleClick += value; }
            remove { ui_DataGridView_Sounds.CellDoubleClick -= value; }
        }

        public event DataGridViewCellMouseEventHandler CellMouseDown
        {
            add { ui_DataGridView_Sounds.CellMouseDown += value; }
            remove { ui_DataGridView_Sounds.CellMouseDown -= value; }
        }

        public DataGridViewRowCollection SoundRows
        {
            get { return ui_DataGridView_Sounds.Rows; }
        }

        public SoundViewer()
		{
			InitializeComponent();
            ConstructDataGridColumns();
            if (!DesignMode)
            {
                m_soundsSource = new BindingListView<Sound>(SBSettings.Instance.Sounds);
                ui_DataGridView_Sounds.DataSource = m_soundsSource;
                ui_DataGridView_Sounds.CellMouseClick += EV_DataGridViewSounds_CellMouseClick;
            }
        }

        private void EV_DataGridViewSounds_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                ui_DataGridView_Sounds.Rows[e.RowIndex].Selected = true;
                ui_contextStrip.Show(Cursor.Position);
            }
        }

        private void ConstructDataGridColumns()
        {
            ui_DataGridView_Sounds.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colSoundName = new DataGridViewTextBoxColumn()
            {
                Name = "Sound",
                DataPropertyName = nameof(Sound.DisplayName),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.Programmatic
            }; ui_DataGridView_Sounds.Columns.Add(colSoundName);

            DataGridViewTextBoxColumn colHotkey = new DataGridViewTextBoxColumn()
            {
                Name = "Hotkey",
                DataPropertyName = nameof(Sound.HotKey),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                SortMode = DataGridViewColumnSortMode.NotSortable
            }; ui_DataGridView_Sounds.Columns.Add(colHotkey);
        }

        #region Event Handlers

        private void EV_Button_AddSound_MouseClick(object sender, MouseEventArgs e)
        {
            SBSettings.Instance.MicMuted = SBSettings.Instance.SelectedRecordingDevice?.OriginalMicMute ?? false;

            using (NewSoundForm form = new NewSoundForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SBSettings.Instance.Sounds.Add(form.SoundResult);
                }
            }
        }

        #endregion

        private void EV_TextboxSearch_TextChanged(object sender, EventArgs e)
        {
            m_soundsSource.ApplyFilter(x => x.DisplayName.ToLower().Contains(ui_textboxSearch.Text.ToLower()));
        }

        private void EV_ToolStripDelete_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_DataGridView_Sounds.SelectedRows.Count < 0) return;

            ui_DataGridView_Sounds.Rows.Remove(ui_DataGridView_Sounds.SelectedRows[0]);
        }

        private void EV_ToolStripEdit_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_DataGridView_Sounds.SelectedRows.Count < 0) return;

            Sound item = (ui_DataGridView_Sounds.SelectedRows[0].DataBoundItem as ObjectView<Sound>).Object;
            using (NewSoundForm editSoundForm = new NewSoundForm(item))
            {
                SBSettings.Instance.Sounds.Remove(item);
                if(editSoundForm.ShowDialog() == DialogResult.OK)
                {
                    SBSettings.Instance.Sounds.Add(editSoundForm.SoundResult);
                }
                else
                {
                    SBSettings.Instance.Sounds.Add(item);
                }
            }
        }
    }
}
