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

		public string FriendlyName { get { return Info.FriendlyName; } }

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
