using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soundboard.Properties;
using System.Collections.Specialized;

namespace Soundboard
{
	public static class SettingsHelper
	{
		internal static Settings Get()
		{
			return Settings.Default;
		}

		public static void ResetDeviceSettingsToDefault()
		{
			Settings _Settings = Get();

			_Settings.MuteMicWhilePlaying = true;
			_Settings.SelectedPlaybackDevices = new StringCollection();
			_Settings.SelectedRecordingDevice = String.Empty;
			_Settings.Save();
		}
	}
}
