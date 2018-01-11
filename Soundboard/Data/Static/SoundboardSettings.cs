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
using Soundboard.Data.Static;
using Soundboard.Data;
using System.ComponentModel;

namespace Soundboard
{
	public enum SettingTags : int
	{
		TAG_FirstRun,
		TAG_MuteMicWhilePlaying,
		TAG_GlobalVolume,
		TAG_Sounds,
		TAG_PlaybackDeviceGUIDs,
		TAG_RecordingDeviceGUID,
		TAG_PreviewDeviceGUID
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

		public static MyBindingList<Sound> Sounds { get; set; } = new MyBindingList<Sound>();

		public static ObservableCollection<AudioDevice> SelectedPlaybackDevices { get; set; } = new ObservableCollection<AudioDevice>();

		public static AudioDevice SelectedRecordingDevice { get; set; } = null;

		public static AudioDevice SelectedPreviewDevice { get; set; } = null;

		public static Dictionary<Hotkey, Sound> HotkeyMap { get; set; } = new Dictionary<Hotkey, Sound>();


		static SoundboardSettings()
		{
			Sounds.RemovingItem += Sounds_RemovingItem;
			Sounds.ListChanged += Sounds_ListChanged;
		}

		private static void Sounds_ListChanged(object sender, ListChangedEventArgs e)
		{
			if(e.ListChangedType == ListChangedType.ItemAdded)
			{
				Sound newSound = Sounds[e.NewIndex];
				if(newSound == null) return;
				if(!newSound.HotKey.Any()) return;

				HotkeyMap.Add(newSound.HotKey, newSound);
			}
		}

		private static void Sounds_RemovingItem(object sender, ItemRemovedArgs<Sound> e)
		{
			if(e.RemovedItem.HotKey.Any())
			{
				HotkeyMap.Remove(e.RemovedItem.HotKey);
			}
		}

		public static void SetMicMuted(bool mute)
		{
			if(SelectedRecordingDevice != null)
			{
				SelectedRecordingDevice.Volume.IsMuted = mute;
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
			foreach(AudioDevice device in SelectedPlaybackDevices) { device.Dispose(); }
			SelectedPlaybackDevices.Clear();

			SelectedRecordingDevice?.Dispose();
			SelectedRecordingDevice = null;
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

								foreach(AudioDevice device in Devices.ActivePlaybackDevices.Where(x => savedGUIDs.Contains(x.DeviceID)))
								{
									SelectedPlaybackDevices.Add(device);
								}
							} break;

						case SettingTags.TAG_RecordingDeviceGUID:
							{
								string recordingDeviceGUID = reader.ReadString();

								var matchingRecordingDevices = Devices.ActiveRecordingDevices.Where(x => recordingDeviceGUID == x.DeviceID);
								if(Guid.Empty.ToString() == recordingDeviceGUID || !matchingRecordingDevices.Any())
								{
									SelectedRecordingDevice = null;
								}
								else
								{
									SelectedRecordingDevice = matchingRecordingDevices.First();
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
						case SettingTags.TAG_PreviewDeviceGUID:
							{
								string previewDeviceGUID = reader.ReadString();

								var matchingRecordingDevices = Devices.ActivePlaybackDevices.Where(x => previewDeviceGUID == x.DeviceID);
								if(Guid.Empty.ToString() == previewDeviceGUID || !matchingRecordingDevices.Any())
								{
									SelectedPreviewDevice = null;
								}
								else
								{
									SelectedPreviewDevice = matchingRecordingDevices.First();
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
				writer.Write(SelectedPlaybackDevices.Count);
				foreach(AudioDevice device in SelectedPlaybackDevices)
				{
					writer.Write(device.DeviceID);
				}

				writer.Write((int)SettingTags.TAG_RecordingDeviceGUID);
				if(SelectedRecordingDevice == null)
				{
					writer.Write(Guid.Empty.ToString());
				}
				else
				{
					writer.Write(SelectedRecordingDevice.DeviceID);
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

				writer.Write((int)SettingTags.TAG_PreviewDeviceGUID);
				if(SelectedPreviewDevice == null)
				{
					writer.Write(Guid.Empty.ToString());
				}
				else
				{
					writer.Write(SelectedPreviewDevice.DeviceID);
				}
			}
		}
	}
}
