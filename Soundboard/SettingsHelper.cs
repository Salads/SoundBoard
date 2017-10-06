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
		internal static Settings GetSettings()
		{
			return Settings.Default;
		}

		public static void ResetSettingsToDefault()
		{
			Settings _Settings = GetSettings();

			_Settings.MuteMicWhilePlaying = true;
			_Settings.FirstRun = true; // TODO(Salads): Should I leave this alone?
			_Settings.SelectedPlaybackDevices = new StringCollection();
			_Settings.SelectedRecordingDevice = String.Empty;
			_Settings.Save();
		}
	}
}
