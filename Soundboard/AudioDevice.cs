using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCore.CoreAudioAPI;

namespace Soundboard
{
	public class AudioDevice
	{
		public AudioDevice(MMDevice NewDevice)
		{
			Info = NewDevice ?? throw new ArgumentNullException("NewDevice", "Device cannot be null.");
			Volume = AudioEndpointVolume.FromDevice(NewDevice);
		}

		public MMDevice Info { get; private set; }

		public AudioEndpointVolume Volume { get; private set; }

		public override string ToString()
		{
			return Info.ToString();
		}
	}
}
