using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCore.CoreAudioAPI;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Soundboard
{
	public class AudioDevice : IDisposable
	{
		public AudioDevice()
		{
			Info = null;
			Volume = null;
		}

		public AudioDevice(MMDevice NewDevice)
		{
			Info = NewDevice ?? throw new ArgumentNullException("NewDevice", "Device cannot be null.");
			Volume = AudioEndpointVolume.FromDevice(NewDevice);
		}

		public AudioDevice(string deviceID)
		{
			using(MMDeviceCollection Devices = DeviceHelper.GetAllActiveDevices())
			{
				try
				{
					MMDevice Device = Devices.First(x => x.DeviceID == deviceID);
					Info = Device;
					Volume = AudioEndpointVolume.FromDevice(Device);
				}
				catch(InvalidOperationException e)
				{
					throw new DeviceNotFoundException(deviceID + " doesn't exist!", e);
				}
			}
		}

		public string DeviceID
		{
			get { return Info.DeviceID; }
		}

		public MMDevice Info { get; private set; }

		public AudioEndpointVolume Volume { get; private set; }

		public void Dispose()
		{
			Info.Dispose();
			Volume.Dispose();
		}

		public override string ToString()
		{
			return Info.ToString();
		}
	}

	public class DeviceNotFoundException : Exception
	{
		public DeviceNotFoundException() { }

		public DeviceNotFoundException(string Message) : base(Message) { }

		public DeviceNotFoundException(string Message, Exception Inner) : base(Message, Inner) { }
	}
}
