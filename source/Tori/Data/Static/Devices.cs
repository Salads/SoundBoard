using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Data.Static
{
    /// <summary>
    /// This class keeps track of all the MMDevices on the system
    /// </summary>
    public class Devices
    {
        private MMDeviceEnumerator m_Enumerator = new MMDeviceEnumerator();
        private static Devices _instance = null;

        public static Devices Instance
        {
            get
            {
                if (_instance == null) _instance = new Devices();
                return _instance;
            }
        }


        public CBindingList<AudioDevice> ActivePlaybackDevices { get; private set; } = new CBindingList<AudioDevice>();
        public CBindingList<AudioDevice> ActiveRecordingDevices { get; private set; } = new CBindingList<AudioDevice>();

        public event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged
        {
            add { m_Enumerator.DeviceStateChanged += value; }
            remove { m_Enumerator.DeviceStateChanged -= value; }
        }
        public event EventHandler<DeviceNotificationEventArgs> DeviceAdded
        {
            add { m_Enumerator.DeviceAdded += value; }
            remove { m_Enumerator.DeviceAdded -= value; }
        }
        public event EventHandler<DeviceNotificationEventArgs> DeviceRemoved
        {
            add { m_Enumerator.DeviceRemoved += value; }
            remove { m_Enumerator.DeviceRemoved -= value; }
        }

        public Devices()
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
		}
    }
}
