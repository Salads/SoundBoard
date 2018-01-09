using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soundboard.Data.Static;

namespace Soundboard.GUI.Controls.Components
{
	public class RecordingDeviceSelector : ComboBox
	{
		public RecordingDeviceSelector()
		{
			_InitializeDevices();

			SelectedIndexChanged += RecordingDeviceSelector_SelectedIndexChanged;
			Devices.ActiveRecordingDevices.ListChanged += ActiveRecordingDevices_ListChanged;
		}

		~RecordingDeviceSelector()
		{
			Devices.ActiveRecordingDevices.ListChanged -= ActiveRecordingDevices_ListChanged;
		}

		private void _InitializeDevices()
		{
			Items.Clear();
			Items.Add("Select Microphone (None)");
			SelectedIndex = 0;

			foreach(AudioDevice recordingDevice in Devices.ActiveRecordingDevices)
			{
				Items.Add(recordingDevice);

				if(ReferenceEquals(recordingDevice, SoundboardSettings.SelectedRecordingDevice))
				{
					SelectedItem = recordingDevice;
				}
			}
		}

		private void ActiveRecordingDevices_ListChanged(object sender, ListChangedEventArgs e)
		{
			if(e.ListChangedType == ListChangedType.ItemAdded)
			{
				Items.Insert(1, Devices.ActiveRecordingDevices[e.NewIndex]);
			}
			else if(e.ListChangedType == ListChangedType.ItemDeleted)
			{
				_InitializeDevices();
			}
		}

		private void RecordingDeviceSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			SoundboardSettings.SelectedRecordingDevice = SelectedItem as AudioDevice;
		}
	}
}
