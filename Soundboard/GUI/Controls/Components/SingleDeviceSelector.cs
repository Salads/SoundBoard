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

namespace Soundboard.GUI
{
	public enum DeviceType
	{
		Preview,
		Recording
	}

	public class SingleDeviceSelector : ComboBox
	{
		private CBindingList<AudioDevice> m_BindingListSource = null;
        private bool IsInitialized { get; set; } = false;

        public DeviceType DeviceType { get; private set; }

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

        protected override void OnSelectedIndexChanged(EventArgs e) 
        {
            if (!IsInitialized)
            {
                return;
            }

            if(SelectedIndex == 0)
            {
                if(DeviceType == DeviceType.Preview)
                {
                    SBSettings.Instance.SelectedPreviewDevice = null;
                }
                else if(DeviceType == DeviceType.Recording)
                {
                    AudioDevice recordingDevice = SBSettings.Instance.SelectedRecordingDevice;
                    SBSettings.Instance.MicMuted = recordingDevice?.OriginalMicMute ?? false;
                    SBSettings.Instance.SelectedRecordingDevice = null;
                }
            }
            else
            {
                if (DeviceType == DeviceType.Preview)
                {
                    SBSettings.Instance.SelectedPreviewDevice = Devices.ActivePlaybackDevices[SelectedIndex - 1];
                    Debug.WriteLine("Selected Preview Device: " + SBSettings.Instance.SelectedPreviewDevice);
                }
                else if (DeviceType == DeviceType.Recording)
                {
                    AudioDevice recordingDevice = SBSettings.Instance.SelectedRecordingDevice;
                    SBSettings.Instance.MicMuted = recordingDevice?.OriginalMicMute ?? false;
                    SBSettings.Instance.SelectedRecordingDevice = Devices.ActiveRecordingDevices[SelectedIndex - 1];
                    Debug.WriteLine("Selected Recording Device: " + SBSettings.Instance.SelectedRecordingDevice);
                }
            }

            base.OnSelectedIndexChanged(e);
        }

        public void Initialize(DeviceType deviceType)
		{
			DeviceType = deviceType;

			if(m_BindingListSource != null) 
			{
				m_BindingListSource.ListChanged -= DeviceList_Changed;
				m_BindingListSource.RemovingItem -= DeviceList_RemovingItem;
			}

            Items.Clear();
			AudioDevice selectedDevice = null;

			if(DeviceType == DeviceType.Preview)
			{
				m_BindingListSource = Devices.ActivePlaybackDevices;
				Items.Add("Select Playback Device (None)");
				selectedDevice = SBSettings.Instance.SelectedPreviewDevice;
			}
			else if(DeviceType == DeviceType.Recording)
			{
				m_BindingListSource = Devices.ActiveRecordingDevices;
				Items.Add("Select Recording Device (None)");
				selectedDevice = SBSettings.Instance.SelectedRecordingDevice;
			}

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

            IsInitialized = true;
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
