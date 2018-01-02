using CSCore;
using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard
{
	public class SoundPlayer
	{
		private List<ISoundOut> m_PlayingSounds = new List<ISoundOut>();

		public bool IsPlaying { get { return m_PlayingSounds.Any(); } }

		public void Play(Sound sound, TimeSpan? startTime = null)
		{
			TimeSpan soundStartTime = ((startTime == null) ? sound.StartTime : startTime.Value);

			string filename = sound.FullFilepath;
			foreach(AudioDevice device in SoundboardSettings.PlaybackDevices)
			{
				//	Need to create one for every output because the stream is handled in WaveSource.
				//	This means multiple outputs will advance stream position if we don't seperate them.
				IWaveSource waveSource = CodecFactory.Instance.GetCodec(filename)
					.ToSampleSource()
					.ToStereo()
					.ToWaveSource();
				waveSource.SetPosition(soundStartTime);

				ISoundOut newSoundOut = new WasapiOut() { Latency = 33, Device = device.Info };
				newSoundOut.Initialize(waveSource);
				newSoundOut.Stopped += EV_OnSoundStopped;
				newSoundOut.Volume = SoundboardSettings.VolumeNormalized;
				newSoundOut.Play();

				m_PlayingSounds.Add(newSoundOut);
				SoundboardSettings.SetMicMuted(SoundboardSettings.MuteMicrophoneWhilePlaying);
			}
		}

		public void SetVolume(float normalizedVolume)
		{
			foreach(ISoundOut PlayingSound in m_PlayingSounds)
			{
				PlayingSound.Volume = normalizedVolume;
			}
		}

		public void StopSoundsOnDevice(AudioDevice device)
		{
			foreach(ISoundOut soundOut in m_PlayingSounds)
			{
				WasapiOut baseOut = soundOut as WasapiOut;
				if(baseOut == null) return;

				if(device.DeviceID == baseOut.Device.DeviceID)
				{
					_StopSound(soundOut);
				}
			}
		}

		public void StopAllSounds()
		{
			foreach(ISoundOut PlayingSound in m_PlayingSounds)
			{
				// Run a task here to make sounds stop more in time with each other.
				Task.Run(() => _StopSound(PlayingSound));
			}

			SoundboardSettings.SetMicMuted(false);

			m_PlayingSounds.Clear();
		}

		private void _StopSound(ISoundOut Sound)
		{
			if(Sound.PlaybackState != PlaybackState.Stopped)
			{
				Sound.Stop();
				Sound.Dispose();
			}
		}

		private void EV_OnSoundStopped(object sender, PlaybackStoppedEventArgs e)
		{
			ISoundOut Stopped = sender as ISoundOut;
			m_PlayingSounds.Remove(Stopped);

			if(!m_PlayingSounds.Any())
			{
				SoundboardSettings.SetMicMuted(false);
			}

			Stopped.Dispose();
		}
	}
}
