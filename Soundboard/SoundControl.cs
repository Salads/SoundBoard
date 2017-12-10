using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;
using System.IO;
using CSCore.Codecs;
using CSCore;

namespace Soundboard
{
	public partial class SoundControl : UserControl
	{
		private SoundPlayer m_SoundPlayer = new SoundPlayer();
		private TimeSpan m_selectedSoundLength;
		
		public SelectedListViewItemCollection SelectedSounds { get; set; }

		public bool MuteMicrophoneWhilePlaying { get { return ui_muteMicWhilePlaying.Checked; } }

		public SoundControl()
		{
			InitializeComponent();

			ui_volumeBar.Volume = SoundboardSettings.GlobalVolume;
		}

		public void UpdateSelectedSound(bool playImmediately = false)
		{
			if(SelectedSounds.Count == 0) { return; }

			Sound selectedSound = SelectedSounds[0].Tag as Sound;
			ui_selectedSoundLabel.Text = Path.GetFileName(selectedSound.Filename);

			// TODO(Salads): Perhaps theres a less expensive way to get audio length?
			var waveSource = CodecFactory.Instance.GetCodec(selectedSound.FullFilepath);

			m_selectedSoundLength = waveSource.GetLength();
			ui_timeLabel.Text = _GetTimeSpanFormatString(TimeSpan.Zero) + "/" + _GetTimeSpanFormatString(m_selectedSoundLength);

			ui_trackBar.Value = 0;
			ui_trackBar.Minimum = 0;
			ui_trackBar.Maximum = (int)m_selectedSoundLength.TotalSeconds;

			if(playImmediately)
			{
				m_SoundPlayer.Play(selectedSound, ui_volumeBar.VolumeNormalized, TimeSpan.FromSeconds(ui_trackBar.Value));
			}
		}

		public void StopAllSounds()
		{
			m_SoundPlayer.StopAllSounds();
		}

		private void EV_SliderChanged(object sender, EventArgs e)
		{
			ui_timeLabel.Text = _GetTimeSpanFormatString(TimeSpan.FromSeconds(ui_trackBar.Value)) + "/" + _GetTimeSpanFormatString(m_selectedSoundLength);
		}

		private string _GetTimeSpanFormatString(TimeSpan TheTimeSpan)
		{
			string Result = string.Empty;
			if(TheTimeSpan.Days != 0)
			{
				int CorrectLength = Math.Max(TheTimeSpan.Days.ToString().Length, 2);

				Result += string.Empty.PadLeft(CorrectLength, 'd');
				Result += "\\.";
			}

			if(TheTimeSpan.Hours != 0)
			{
				int CorrectLength = Math.Max(TheTimeSpan.Hours.ToString().Length, 2);

				Result += string.Empty.PadLeft(CorrectLength, 'h');
				Result += "\\:";
			}

			int MinuteLength = Math.Max(TheTimeSpan.Minutes.ToString().Length, 2);

			Result += string.Empty.PadLeft(MinuteLength, 'm');
			Result += "\\:";

			int SecondLength = Math.Max(TheTimeSpan.Seconds.ToString().Length, 2);

			Result += string.Empty.PadLeft(SecondLength, 's');

			return TheTimeSpan.ToString(Result);
		}

		private void EV_PlayClicked(object sender, MouseEventArgs e)
		{
			if(SelectedSounds.Count == 0)
			{
				return;
			}

			Sound selectedSound = SelectedSounds[0].Tag as Sound;
			if(selectedSound == null) return;

			m_SoundPlayer.Play(selectedSound, ui_volumeBar.VolumeNormalized, TimeSpan.FromSeconds(ui_trackBar.Value));
		}

		private void EV_StopClicked(object sender, MouseEventArgs e)
		{
			m_SoundPlayer.StopAllSounds();
		}

		private void EV_VolumeChanged(object sender, EventArgs e)
		{
			m_SoundPlayer.SetVolume(ui_volumeBar.VolumeNormalized);
			SoundboardSettings.GlobalVolume = ui_volumeBar.Volume;
		}

		private void EV_MuteMicChanged(object sender, EventArgs e)
		{
			SoundboardSettings.MuteMicrophoneWhilePlaying = ui_muteMicWhilePlaying.Checked;

			if(m_SoundPlayer.IsPlaying)
			{
				SoundboardSettings.SetMicMuted(SoundboardSettings.MuteMicrophoneWhilePlaying);
			}
		}
	}
}
