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
	public static class SoundboardSettings
	{
		private const string _DEFAULT_LOCATION = "default.soundboard";

		[JsonProperty]
		public static bool FirstRun { get; set; }

		[JsonProperty]
		public static bool MuteMicrophoneWhilePlaying{ get; set; }

		[JsonProperty]
		public static uint GlobalVolume { get; set; }

		[JsonProperty]
		public static Dictionary<string, Sound> Sounds { get; set; }

		[JsonProperty]
		public static List<AudioDevice> PlaybackDevices { get; set; }

		[JsonProperty]
		public static AudioDevice RecordingDevice { get; set; }

		/// <summary>
		/// Default constructor that does nothing.
		/// </summary>
		static SoundboardSettings()
		{
			_Initialize();
		}

		private static void _Initialize()
		{
			Sounds = new Dictionary<string, Sound>();
			PlaybackDevices = new List<AudioDevice>();
		}

		public static bool ShouldSerializeRecordingDevice()
		{
			return RecordingDevice != null;
		}

		public static void SetMicMuted(bool mute)
		{
			if(RecordingDevice != null)
			{
				RecordingDevice.Volume.IsMuted = mute;
			}
		}

		public static void ResetToDefault()
		{
			FirstRun = true;
			MuteMicrophoneWhilePlaying = false;
			GlobalVolume = 20;
			ResetSounds();
			ResetDevices();
		}

		public static void ResetSounds()
		{
			Sounds.Clear();
		}

		public static void ResetDevices()
		{
			PlaybackDevices.ForEach(x => x?.Dispose());
			PlaybackDevices.Clear();

			RecordingDevice?.Dispose();
			RecordingDevice = null;
		}

		public static bool LoadFromFile(string Filename = _DEFAULT_LOCATION, bool CreateIfDoesntExist = true)
		{
			if(!File.Exists(Filename))
			{
				if(CreateIfDoesntExist)
				{
					ResetToDefault();
					SaveToFile(Filename);
					return true;
				}
				else
				{
					return false;
				}
			}

			ResetToDefault();

			JObject JsonObject = JObject.Parse(File.ReadAllText(Filename));

			FirstRun = bool.Parse((string)JsonObject[nameof(FirstRun)]);
			MuteMicrophoneWhilePlaying = bool.Parse((string)JsonObject[nameof(MuteMicrophoneWhilePlaying)]);
			GlobalVolume = uint.Parse((string)JsonObject[nameof(GlobalVolume)]);

			List<string> SavedPlaybackIDs = JsonObject[nameof(PlaybackDevices)].Select(x => (string)x).ToList();
			foreach(MMDevice Device in DeviceHelper.GetActivePlaybackDevices().Where(x => SavedPlaybackIDs.Contains(x.DeviceID)))
			{
				PlaybackDevices.Add(new AudioDevice(Device));
			}

			string SavedMicID = (string)JsonObject[nameof(RecordingDevice)];
			foreach(MMDevice Device in DeviceHelper.GetActiveRecordingDevices().Where(x => SavedMicID.Equals(x.DeviceID)))
			{
				RecordingDevice = new AudioDevice(Device);
				break;
			}

			Sounds = JsonObject[nameof(Sounds)].ToObject<Dictionary<string, Sound>>();

			return true;
		}

		public static void SaveToFile(string Filename = _DEFAULT_LOCATION)
		{
			StringBuilder sb = new StringBuilder();
			using(StringWriter sw = new StringWriter(sb))
			using(JsonWriter writer = new JsonTextWriter(sw))
			{
				JsonSerializer Serializer = new JsonSerializer
				{
					Formatting = Formatting.Indented
				};
				writer.Formatting = Formatting.Indented;

				writer.WriteStartObject();
				writer.WritePropertyName(nameof(FirstRun));
				writer.WriteValue(FirstRun);

				writer.WritePropertyName(nameof(MuteMicrophoneWhilePlaying));
				writer.WriteValue(MuteMicrophoneWhilePlaying);

				writer.WritePropertyName(nameof(GlobalVolume));
				writer.WriteValue(GlobalVolume);

				writer.WritePropertyName(nameof(PlaybackDevices));
				Serializer.Serialize(writer, PlaybackDevices.Select(x => x.DeviceID).ToList());

				writer.WritePropertyName(nameof(RecordingDevice));
				writer.WriteValue(RecordingDevice != null ? RecordingDevice.DeviceID : Guid.Empty.ToString());

				writer.WritePropertyName(nameof(Sounds));

				Serializer.Serialize(writer, Sounds);

				writer.WriteEndObject();

				File.WriteAllText(Filename, sb.ToString());
			}
		}
	}
}
