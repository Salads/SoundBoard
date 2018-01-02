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
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Soundboard
{
	public enum SettingTags : int
	{
		TAG_FirstRun,
		TAG_MuteMicWhilePlaying,
		TAG_GlobalVolume,
		TAG_Sounds,
		TAG_PlaybackDeviceGUIDs,
		TAG_RecordingDeviceGUID
	}

	// TODO: OnChanged events for these settings.

	public static class SoundboardSettings
	{
		private const string _DEFAULT_LOCATION = "default.soundboard";

		public static bool FirstRun { get; set; }

		public static bool MuteMicrophoneWhilePlaying{ get; set; }

		public static uint GlobalVolume { get; set; }

		public static float VolumeNormalized
		{
			get
			{
				return GlobalVolume / (100.0f);
			}
		}

		public static ObservableCollection<Sound> Sounds { get; set; } = new ObservableCollection<Sound>();

		public static ObservableCollection<AudioDevice> PlaybackDevices { get; set; } = new ObservableCollection<AudioDevice>();

		public static AudioDevice RecordingDevice { get; set; } = null;

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
			foreach(AudioDevice device in PlaybackDevices) { device.Dispose(); }
			PlaybackDevices.Clear();

			RecordingDevice?.Dispose();
			RecordingDevice = null;
		}

		public static void LoadFromFile(string Filename = _DEFAULT_LOCATION)
		{
			//	If we want to load from a file, that means we want to get rid of our old settings.
			//	If the file doesn't exist might as well set to default then save the file.
			if(!File.Exists(Filename))
			{
				ResetToDefault();
				SaveToFile(Filename);
				return;
			}

			Debug.WriteLine("Loading from default");

			// Just to be sanitary. (safeguard in case settings are loaded again somewhere)
			ResetToDefault();

			using(BinaryReader reader = new BinaryReader(File.OpenRead(Filename)))
			{
				while(reader.BaseStream.Position != reader.BaseStream.Length)
				{
					SettingTags Tag = (SettingTags)(reader.ReadInt32());
					switch(Tag)
					{
						case SettingTags.TAG_FirstRun:
							FirstRun = reader.ReadBoolean();
							break;

						case SettingTags.TAG_MuteMicWhilePlaying:
							MuteMicrophoneWhilePlaying = reader.ReadBoolean();
							break;

						case SettingTags.TAG_GlobalVolume:
							GlobalVolume = reader.ReadUInt32();
							break;

						case SettingTags.TAG_PlaybackDeviceGUIDs:
							{
								int Count = reader.ReadInt32();
								List<string> savedGUIDs = new List<string>();
								for(int x = 0; x < Count; ++x)
								{
									savedGUIDs.Add(reader.ReadString());
								}

								foreach(MMDevice Device in DeviceHelper.GetActivePlaybackDevices().Where(x => savedGUIDs.Contains(x.DeviceID)))
								{
									PlaybackDevices.Add(new AudioDevice(Device));
								}
							} break;

						case SettingTags.TAG_RecordingDeviceGUID:
							{
								string recordingDeviceGUID = reader.ReadString();
								if(Guid.Empty.ToString() == recordingDeviceGUID)
								{
									RecordingDevice = null;
								}
								else
								{
									foreach(MMDevice Device in DeviceHelper.GetActiveRecordingDevices().Where(x => recordingDeviceGUID.Equals(x.DeviceID)))
									{
										RecordingDevice = new AudioDevice(Device);
										break;
									}
								}
							} break;

						case SettingTags.TAG_Sounds:
							{
								int soundsCount = reader.ReadInt32();
								for(int x = 0; x < soundsCount; ++x)
								{
									string savedSoundPath = reader.ReadString();
									string rawStartTime = reader.ReadString();
									string nickname = reader.ReadString();

									Sound newSound = new Sound(savedSoundPath)
									{
										StartTime = TimeSpan.Parse(rawStartTime),
										Nickname = nickname
									};

									int hotkeyKeysCount = reader.ReadInt32();
									for(int i = 0; i < hotkeyKeysCount; ++i)
									{
										newSound.HotKey.Add((Keys)reader.ReadInt32());
									}

									Debug.WriteLine("Loaded: " + newSound.Nickname + " : " + newSound.HotKey.ToString());
									Sounds.Add(newSound);
								}
							} break;
					}
				}
			}
		}

		public static void SaveToFile(string Filename = _DEFAULT_LOCATION)
		{
			using(BinaryWriter writer = new BinaryWriter(File.Create(Filename)))
			{
				writer.Write((int)SettingTags.TAG_FirstRun);
				writer.Write(FirstRun);

				writer.Write((int)SettingTags.TAG_MuteMicWhilePlaying);
				writer.Write(MuteMicrophoneWhilePlaying);

				writer.Write((int)SettingTags.TAG_GlobalVolume);
				writer.Write(GlobalVolume);

				writer.Write((int)SettingTags.TAG_PlaybackDeviceGUIDs);
				writer.Write(PlaybackDevices.Count);
				foreach(AudioDevice device in PlaybackDevices)
				{
					writer.Write(device.DeviceID);
				}

				writer.Write((int)SettingTags.TAG_RecordingDeviceGUID);
				if(RecordingDevice == null)
				{
					writer.Write(Guid.Empty.ToString());
				}
				else
				{
					writer.Write(RecordingDevice.DeviceID);
				}

				writer.Write((int)SettingTags.TAG_Sounds);
				writer.Write(Sounds.Count);
				foreach(Sound sound in Sounds)
				{
					writer.Write(sound.FullFilepath);
					writer.Write(sound.StartTime.ToString());
					writer.Write(sound.Nickname);

					writer.Write(sound.HotKey.Count);
					foreach(Keys key in sound.HotKey)
					{
						writer.Write((int)key);
					}
				}
			}
		}
	}
}
