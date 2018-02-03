using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Data.Static
{
	/// <summary>
	/// This class keeps track of all the MMDevices on the system, and updates them when they change.
	/// </summary>
	static class Devices
	{
		private static MMDeviceEnumerator m_Enumerator = new MMDeviceEnumerator();

		public static CBindingList<AudioDevice> ActivePlaybackDevices { get; private set; } = new CBindingList<AudioDevice>();
		public static CBindingList<AudioDevice> ActiveRecordingDevices { get; private set; } = new CBindingList<AudioDevice>();

		static Devices()
		{
			foreach(MMDevice device in m_Enumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active))
			{
				if(device.DataFlow == DataFlow.Render)
				{
					ActivePlaybackDevices.Add(new AudioDevice(device));
				}
				else if(device.DataFlow == DataFlow.Capture)
				{
					ActiveRecordingDevices.Add(new AudioDevice(device));
				}
			}

			m_Enumerator.DeviceAdded += MMDeviceEnumerator_DeviceAdded;
			m_Enumerator.DeviceRemoved += MMDeviceEnumerator_DeviceRemoved;
		}

		private static void MMDeviceEnumerator_DeviceRemoved(object sender, DeviceNotificationEventArgs e)
		{
			foreach(AudioDevice pDevice in ActivePlaybackDevices.Where(x => x.DeviceID == e.DeviceId))
			{
				ActivePlaybackDevices.Remove(pDevice);

				// Set preview device to null if it was the removed device
				if(ReferenceEquals(pDevice, SBSettings.Instance.SelectedPreviewDevice))
				{
					SBSettings.Instance.SelectedPreviewDevice = null;
				}

				pDevice.Dispose();
			}

			// Do the same for recording devices
			foreach(AudioDevice rDevice in ActiveRecordingDevices.Where(x => x.DeviceID == e.DeviceId))
			{
				ActiveRecordingDevices.Remove(rDevice);
				if(ReferenceEquals(rDevice, SBSettings.Instance.SelectedRecordingDevice))
				{
					SBSettings.Instance.SelectedRecordingDevice = null;
				}

				rDevice.Dispose();
			}
		}

		private static void MMDeviceEnumerator_DeviceAdded(object sender, DeviceNotificationEventArgs e)
		{
			if(e.TryGetDevice(out MMDevice newDevice))
			{
				if(newDevice.DeviceState != DeviceState.Active) return;

				if(newDevice.DataFlow == DataFlow.Render)
				{
					ActivePlaybackDevices.Add(new AudioDevice(newDevice));
				}
				else if(newDevice.DataFlow == DataFlow.Capture)
				{
					ActiveRecordingDevices.Add(new AudioDevice(newDevice));
				}
			}
		}
	}
}
