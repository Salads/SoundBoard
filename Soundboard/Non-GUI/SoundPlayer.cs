using CSCore;
using CSCore.Codecs;
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

		public SoundPlayer() {}

		public void Play(Sound sound, float normalizedVolume, TimeSpan? time = null)
		{
			if( time == null ){ time = TimeSpan.Zero; }

			string filename = sound.FullFilepath;
			foreach(AudioDevice device in SoundboardSettings.PlaybackDevices)
			{
				// REMARK(Salads): Need to create one for every output because the stream is handled in WaveSource.
				//					This means multiple outputs will advance stream position if we don't seperate them.
				IWaveSource waveSource = CodecFactory.Instance.GetCodec(filename)
					.ToSampleSource()
					.ToStereo()
					.ToWaveSource();
				waveSource.SetPosition(time.Value);

				ISoundOut NewSound = new WasapiOut() { Latency = 100, Device = device.Info };
				NewSound.Initialize(waveSource);
				NewSound.Stopped += EV_OnSoundStopped;
				NewSound.Volume = normalizedVolume;
				NewSound.Play();

				m_PlayingSounds.Add(NewSound);
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

		public void StopAllSounds()
		{
			foreach(ISoundOut PlayingSound in m_PlayingSounds)
			{
				// (Salads): I run a task here to make sounds stop more in time with each other.
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
