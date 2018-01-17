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
using System.Runtime.CompilerServices;

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

	public class SBSettings : INotifyPropertyChanged
	{
		private static SBSettings m_Instance;
		public static SBSettings Instance 
		{
			get
			{
				if(m_Instance == null)
				{ m_Instance = new SBSettings(); }

				return m_Instance;
			}
		}

		private bool m_MuteMicrophoneWhilePlaying;
        private AudioDevice m_SelectedRecordingDevice;

		private const string _DEFAULT_LOCATION = "default.soundboard";

		public bool FirstRun { get; set; }

		public uint GlobalVolume { get; set; }

        public bool MuteMicrophoneWhilePlaying 
        {
            get { return m_MuteMicrophoneWhilePlaying; }
            set
            {
                m_MuteMicrophoneWhilePlaying = value;
                NotifyPropertyChanged();
            }
        }

        public CBindingList<Sound> Sounds { get; set; } = new CBindingList<Sound>();

		public CBindingList<AudioDevice> SelectedPlaybackDevices { get; set; } = new CBindingList<AudioDevice>();

		public AudioDevice SelectedRecordingDevice 
        {
            get { return m_SelectedRecordingDevice; }
            set
            {
                m_SelectedRecordingDevice = value;
                RecordingDeviceChanged?.BeginInvoke(this, new EventArgs(), null, null);
            }
        }

		public AudioDevice SelectedPreviewDevice { get; set; } = null;

		public Dictionary<Hotkey, Sound> HotkeyMap { get; set; } = new Dictionary<Hotkey, Sound>();

		//////////////////////////////////////////////////////////

		public bool MicMuted 
		{
			set
			{
				if(SelectedRecordingDevice != null)
				{
					SelectedRecordingDevice.Volume.IsMuted = value;
				}
			}
		}

        public float VolumeNormalized 
        {
            get
            {
                return GlobalVolume / (100.0f);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler RecordingDeviceChanged;

		private SBSettings()
		{
			Sounds.RemovingItem += Sounds_RemovingItem;
			Sounds.ListChanged += Sounds_ListChanged;
		}

		~SBSettings()
		{
			Sounds.RemovingItem -= Sounds_RemovingItem;
			Sounds.ListChanged -= Sounds_ListChanged;
		}

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void Sounds_ListChanged(object sender, ListChangedEventArgs e)
		{
			if(e.ListChangedType == ListChangedType.ItemAdded)
			{
				Sound newSound = Sounds[e.NewIndex];
				if(newSound == null) return;
				if(!newSound.HotKey.Any()) return;

				HotkeyMap.Add(newSound.HotKey, newSound);
			}
		}
		private void Sounds_RemovingItem(object sender, ItemRemovedArgs<Sound> e)
		{
			if(e.RemovedItem.HotKey.Any())
			{
				HotkeyMap.Remove(e.RemovedItem.HotKey);
			}
		}

        public void ApplyMicSettings()
        {
            if (Instance.MuteMicrophoneWhilePlaying)
            {
                Instance.MicMuted = true;
            }
            else
            {
                Instance.MicMuted = false;
            }
        }

		public void ResetToDefault()
		{
			FirstRun = true;
			MuteMicrophoneWhilePlaying = false;
			GlobalVolume = 20;
			ResetSounds();
			ResetDevices();
		}

		public void ResetSounds()
		{
			Sounds.Clear();
		}

		public void ResetDevices()
		{
			foreach(AudioDevice device in SelectedPlaybackDevices) { device.Dispose(); }
			SelectedPlaybackDevices.Clear();

			SelectedRecordingDevice?.Dispose();
			SelectedRecordingDevice = null;
		}

		public void LoadFromFile(string Filename = _DEFAULT_LOCATION) 
		{
			//	If we want to load from a file, that means we want to get rid of our old settings.
			//	If the file doesn't exist might as well set to default then save the file.
			if(!File.Exists(Filename))
			{
				ResetToDefault();
				SaveToFile(Filename);
				return;
			}

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

								var matchingPlaybackDevices = Devices.ActivePlaybackDevices.Where(x => previewDeviceGUID == x.DeviceID);
								if(Guid.Empty.ToString() == previewDeviceGUID || !matchingPlaybackDevices.Any())
								{
									SelectedPreviewDevice = null;
								}
								else
								{
									SelectedPreviewDevice = matchingPlaybackDevices.First();
								}

							} break;
					}
				}
			}
		}

		public void SaveToFile(string Filename = _DEFAULT_LOCATION) 
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
