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

			string defaultOption = string.Empty;
			AudioDevice selectedDevice = null;

			if(m_DeviceType == DeviceType.Playback)
			{
				m_BindingListSource = Devices.ActivePlaybackDevices;
				defaultOption = "Select Playback Device (None)";
				selectedDevice = SBSettings.Instance.SelectedPreviewDevice;
			}
			else if(m_DeviceType == DeviceType.Recording)
			{
				m_BindingListSource = Devices.ActiveRecordingDevices;
				defaultOption = "Select Recording Device (None)";
				selectedDevice = SBSettings.Instance.SelectedRecordingDevice;
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
		}

		private void DeviceList_RemovingItem(object sender, ItemRemovedArgs<AudioDevice> e)
		{
			// If the removed device is the selected item, set the SelectedIndex to 0, the "None" choice.
			if(ReferenceEquals(e.RemovedItem, SBSettings.Instance.SelectedPreviewDevice) ||
			   ReferenceEquals(e.RemovedItem, SBSettings.Instance.SelectedRecordingDevice))
			{
				SelectedIndex = 0;
			}

			Items.Remove(e.RemovedItem);
		}

		private void DeviceList_Changed(object sender, ListChangedEventArgs e)
		{
			if(e.ListChangedType == ListChangedType.ItemAdded)
			{
				Items.Add(m_BindingListSource[e.NewIndex]);
			}
		}
	}
}
