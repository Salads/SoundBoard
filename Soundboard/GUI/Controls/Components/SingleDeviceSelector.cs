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
using Soundboard.Data;

namespace Soundboard.GUI.Controls.Components
{
	public enum DeviceType
	{
		Playback,
		Recording
	}

	public class SingleDeviceSelector : ComboBox
	{
		private CBindingList<AudioDevice> m_BindingListSource = null;
		private DeviceType m_DeviceType;

		public SingleDeviceSelector()
		{}

		~SingleDeviceSelector()
		{
			if(m_BindingListSource != null)
			{
				m_BindingListSource.ListChanged -= DeviceList_Changed; 
				m_BindingListSource.RemovingItem -= DeviceList_RemovingItem;
			}
		}

		public void Initialize(DeviceType deviceType)
		{
			m_DeviceType = deviceType;

			if(m_BindingListSource != null)
			{
				m_BindingListSource.ListChanged -= DeviceList_Changed;
				m_BindingListSource.RemovingItem -= DeviceList_RemovingItem;
			}
			SelectedIndexChanged -= SingleDeviceSelector_SelectedIndexChanged;

			string defaultOption = string.Empty;
			AudioDevice selectedDevice = null;

			if(m_DeviceType == DeviceType.Playback)
			{
				m_BindingListSource = Devices.ActivePlaybackDevices;
				defaultOption = "Select Playback Device (None)";
				selectedDevice = SoundboardSettings.SelectedPreviewDevice;
			}
			else if(m_DeviceType == DeviceType.Recording)
			{
				m_BindingListSource = Devices.ActiveRecordingDevices;
				defaultOption = "Select Recording Device (None)";
				selectedDevice = SoundboardSettings.SelectedRecordingDevice;
			}

			Items.Clear();
			Items.Add(defaultOption);
			SelectedIndex = 0;

			foreach(AudioDevice device in m_BindingListSource)
			{
				Items.Add(device);
				if(ReferenceEquals(device, selectedDevice))
				{
					SelectedItem = device;
				}
			}
			
			m_BindingListSource.ListChanged += DeviceList_Changed;
			m_BindingListSource.RemovingItem += DeviceList_RemovingItem;
			SelectedIndexChanged += SingleDeviceSelector_SelectedIndexChanged;
		}

		private void SingleDeviceSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(m_DeviceType == DeviceType.Playback)
			{
				SoundboardSettings.SelectedPreviewDevice = (SelectedIndex == 0 ? null : SelectedItem as AudioDevice);
			}
			else if(m_DeviceType == DeviceType.Recording)
			{
				SoundboardSettings.SelectedRecordingDevice = (SelectedIndex == 0 ? null : SelectedItem as AudioDevice);
			}
		}

		private void DeviceList_RemovingItem(object sender, ItemRemovedArgs<AudioDevice> e)
		{
			if(ReferenceEquals(e.RemovedItem, SoundboardSettings.SelectedPreviewDevice)
				|| ReferenceEquals(e.RemovedItem, SoundboardSettings.SelectedRecordingDevice))
			{
				SelectedIndex = 0;
			}

			Items.Remove(e.RemovedItem);
		}

		private void DeviceList_Changed(object sender, ListChangedEventArgs e)
		{
			if(e.ListChangedType == ListChangedType.ItemAdded)
			{
				if(m_DeviceType == DeviceType.Playback)
				{
					Items.Add(Devices.ActivePlaybackDevices[e.NewIndex]);
				}
				else if(m_DeviceType == DeviceType.Recording)
				{
					Items.Add(Devices.ActiveRecordingDevices[e.NewIndex]);
				}
			}
		}
	}
}
