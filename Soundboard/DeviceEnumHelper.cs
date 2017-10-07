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
			return GetAudioDevices(DataFlow.Render, DeviceState.Active);
		}

		public static MMDeviceCollection GetActiveRecordingDevices()
		{
			return GetAudioDevices(DataFlow.Capture, DeviceState.Active);
		}

		public static MMDeviceCollection GetAllActiveDevices()
		{
			return GetAudioDevices(DataFlow.All, DeviceState.Active);
		}

		public static MMDeviceCollection GetAudioDevices(DataFlow DataFlowFilter, DeviceState DeviceStateFilter)
		{
			using(MMDeviceEnumerator Enumerator = new MMDeviceEnumerator())
			{
				return Enumerator.EnumAudioEndpoints(DataFlowFilter, DeviceStateFilter);
			}
		}
	}
}
