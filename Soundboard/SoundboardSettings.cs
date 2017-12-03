using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CSCore;
using CSCore.CoreAudioAPI;
using System.Diagnostics;

namespace Soundboard
{
	public class SoundboardSettings
	{

		// TODO(Salads): Think about where to put this to make the Exntensions default args look cleaner.
		public const string _DEFAULT_LOCATION = "default.soundboard";

		[JsonProperty]
		public bool FirstRun { get; set; }

		[JsonProperty]
		public bool MuteMicWhilePlaying { get; set; }

		[JsonProperty]
		public Dictionary<string, Sound> Sounds { get; set; }

		[JsonProperty]
		public List<AudioDevice> PlaybackDevices { get; set; }

		[JsonProperty]
		public AudioDevice RecordingDevice { get; set; }

		/// <summary>
		/// Default constructor that does nothing.
		/// </summary>
		public SoundboardSettings()
		{
			_Initialize();
		}

		public SoundboardSettings(bool CreateIfDoesntExist = true, string Filename = _DEFAULT_LOCATION)
		{
			_Initialize();

			this.LoadFromFile(Filename, CreateIfDoesntExist);
		}

		private void _Initialize()
		{
			Sounds = new Dictionary<string, Sound>();
			PlaybackDevices = new List<AudioDevice>();
		}

		public bool ShouldSerializeRecordingDevice()
		{
			return RecordingDevice != null;
		}
	}

	public static class SoundboardSettingsExtensions
	{

		public static void ResetToDefault(this SoundboardSettings Settings)
		{
			_ReleaseUnmanaged(Settings);

			Settings.FirstRun = true;
			Settings.MuteMicWhilePlaying = false;
			Settings.ResetSounds();
			Settings.ResetDevices();
		}

		public static void ResetSounds(this SoundboardSettings Settings)
		{
			Settings.Sounds.Clear();
		}
		
		public static void ResetDevices(this SoundboardSettings Settings)
		{
			Settings.PlaybackDevices.ForEach(x => x?.Dispose());
			Settings.PlaybackDevices.Clear();

			Settings.RecordingDevice?.Dispose();
			Settings.RecordingDevice = null;
		}

		public static bool LoadFromFile(this SoundboardSettings Settings, string Filename = SoundboardSettings._DEFAULT_LOCATION, bool CreateIfDoesntExist = true)
		{
			if(!File.Exists(Filename))
			{
				if(CreateIfDoesntExist)
				{
					Settings.ResetToDefault();
					Settings.SaveToFile(Filename);
					return true;
				}
				else
				{
					return false;
				}
			}

			Settings.ResetToDefault();

			JObject JsonObject = JObject.Parse(File.ReadAllText(Filename));

			Settings.FirstRun = bool.Parse((string)JsonObject[nameof(Settings.FirstRun)]);
			Settings.MuteMicWhilePlaying = bool.Parse((string)JsonObject[nameof(Settings.MuteMicWhilePlaying)]);

			List<string> SavedPlaybackIDs = JsonObject[nameof(Settings.PlaybackDevices)].Select(x => (string)x).ToList();
			foreach (MMDevice Device in DeviceHelper.GetActivePlaybackDevices().Where(x => SavedPlaybackIDs.Contains(x.DeviceID)))
			{
				Settings.PlaybackDevices.Add(new AudioDevice(Device));
			}

			string SavedMicID = (string)JsonObject[nameof(Settings.RecordingDevice)];
			foreach(MMDevice Device in DeviceHelper.GetActiveRecordingDevices().Where(x => SavedMicID.Equals(x.DeviceID)))
			{
				Settings.RecordingDevice = new AudioDevice(Device);
				break;
			}

			Settings.Sounds = JsonObject[nameof(Settings.Sounds)].ToObject<Dictionary<string, Sound>>();

			return true;
		}

		public static void SaveToFile(this SoundboardSettings Settings, string Filename = SoundboardSettings._DEFAULT_LOCATION)
		{
			StringBuilder sb = new StringBuilder();
			using(StringWriter sw = new StringWriter(sb))
			using(JsonWriter writer = new JsonTextWriter(sw))
			{
				JsonSerializer Serializer = new JsonSerializer();
				Serializer.Formatting = Formatting.Indented;
				writer.Formatting = Formatting.Indented;

				writer.WriteStartObject();
				writer.WritePropertyName(nameof(Settings.FirstRun));
				writer.WriteValue(Settings.FirstRun);

				writer.WritePropertyName(nameof(Settings.MuteMicWhilePlaying));
				writer.WriteValue(Settings.MuteMicWhilePlaying);

				writer.WritePropertyName(nameof(Settings.PlaybackDevices));
				Serializer.Serialize(writer, Settings.PlaybackDevices.Select(x => x.DeviceID).ToList());

				writer.WritePropertyName(nameof(Settings.RecordingDevice));
				writer.WriteValue(Settings.RecordingDevice != null ? Settings.RecordingDevice.DeviceID : Guid.Empty.ToString());

				writer.WritePropertyName(nameof(Settings.Sounds));

				Serializer.Serialize(writer, Settings.Sounds);

				writer.WriteEndObject();

				File.WriteAllText(Filename, sb.ToString());
			}
		}

		private static void _ReleaseUnmanaged(SoundboardSettings Settings)
		{
			foreach (AudioDevice Device in Settings.PlaybackDevices)
			{
				Device?.Dispose();
			}

			Settings.RecordingDevice?.Dispose();
		}
	}
}
