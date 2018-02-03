using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using Soundboard.Data.Static;

namespace Soundboard.GUI
{
    /// <summary>
    /// Manages selected playback devices and recording device.
    /// </summary>
	public partial class DevicesSelector : UserControl
	{
		public DevicesSelector()
		{
			InitializeComponent();

			if(!DesignMode)
			{
				ui_RecordingDeviceSelector.Initialize(DeviceType.Recording);

                ui_DataGridView.AutoGenerateColumns = false;
                ui_DataGridView.DataSource = Devices.ActivePlaybackDevices;

                DataGridViewColumn colDeviceSelected = new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = nameof(AudioDevice.Selected),
                    Name = "✔",
                    MinimumWidth = 25,
                    Width = 25,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                ui_DataGridView.Columns.Add(colDeviceSelected);

                DataGridViewTextBoxColumn colDeviceName = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(AudioDevice.FriendlyName),
                    Name = "Playback Devices",
                    ReadOnly = true
                };
                ui_DataGridView.Columns.Add(colDeviceName);
            }

            ui_DataGridView.SelectionChanged += EV_PlaybackDevices_SelectionChanged;
        }

        private void EV_PlaybackDevices_SelectionChanged(object sender, EventArgs e)
        {
            ui_DataGridView.ClearSelection();
        }
    }
}
