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
	// TODO: Better interface for AudioDevice, like device volume, etc.

	public class AudioDevice : IDisposable
	{
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
			return FriendlyName;
		}
	}
}
