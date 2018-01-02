using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.GUI.Controls.Components
{
	public partial class RecordingDeviceSelector : ComboBox
	{
		public RecordingDeviceSelector() : base()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initializes the Control. Not in constructor to be designer friendly.
		/// </summary>
		public void Initialize()
		{
			_InitializeDevices();
			SelectedIndexChanged += RecordingDeviceSelector_SelectedIndexChanged;

			DropDownStyle = ComboBoxStyle.DropDownList;
		}

		private void RecordingDeviceSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(SelectedIndex == 0) return; // "None" 

			SoundboardSettings.RecordingDevice = SelectedItem as AudioDevice;
		}

		private void _InitializeDevices()
		{
			Items.Clear();
			Items.Add("None");
			SelectedIndex = 0;

			string savedDeviceID = SoundboardSettings.RecordingDevice?.DeviceID;
			foreach (MMDevice device in DeviceHelper.GetActiveRecordingDevices())
			{
				AudioDevice newAudioDevice = new AudioDevice(device);
				Items.Add(newAudioDevice);

				if(savedDeviceID == newAudioDevice.DeviceID)
				{
					SelectedItem = newAudioDevice;
				}
			}
		}
	}
}
