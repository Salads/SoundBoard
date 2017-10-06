using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCore.CoreAudioAPI;

namespace Soundboard
{
	public static class DeviceEnumHelper
	{
		public static MMDeviceCollection GetActivePlaybackDevices()
		{
			using(MMDeviceEnumerator Enumerator = new MMDeviceEnumerator())
			{
				return Enumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
			}
		}

		public static MMDeviceCollection GetActiveRecordingDevices()
		{
			using(MMDeviceEnumerator Enumerator = new MMDeviceEnumerator())
			{
				return Enumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active);
			}
		}

		public static MMDeviceCollection GetAllActiveDevices()
		{
			using(MMDeviceEnumerator Enumerator = new MMDeviceEnumerator())
			{
				return Enumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active);
			}
		}
	}
}
