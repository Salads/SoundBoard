using System;
using System.Windows.Forms;
using System.IO;
using CSCore.Codecs;
using CSCore;
using Soundboard.GUI;

namespace Soundboard
{
	public partial class MediaControl : UserControl
	{
		public SoundPlayer SoundPlayer { get; set; }

		private Sound m_selectedSound;
		private TimeSpan m_selectedSoundLength;

		public bool MuteMicrophoneWhilePlaying { get { return ui_muteMicWhilePlaying.Checked; } }

		public int StartSeconds
		{
			get { return ui_trackBar.Value; }
		}

		public MediaControl()
		{
			InitializeComponent();

			Load += MediaControl_Load;
		}

		private void MediaControl_Load(object sender, EventArgs e)
		{
			ui_volumeBar.Volume = SoundboardSettings.GlobalVolume;
			ui_muteMicWhilePlaying.Checked = SoundboardSettings.MuteMicrophoneWhilePlaying;
		}

		public void HookListView(ListView soundList)
		{
			soundList.ItemSelectionChanged += SoundList_ItemSelectionChanged;
		}

		private void SoundList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if(e.IsSelected)
			{
				SetSelectedSound(e.Item.Tag as Sound);
			}
		}

		public void SetSelectedSound(Sound selectedSound)
		{
			if(selectedSound == null) return;

			ui_selectedSoundLabel.Text = Path.GetFileName(selectedSound.Filename);

			// TODO(Salads): Perhaps theres a less expensive way to get audio length?
			var waveSource = CodecFactory.Instance.GetCodec(selectedSound.FullFilepath);

			m_selectedSoundLength = waveSource.GetLength();
			ui_timeLabel.Text = _GetTimeSpanFormatString(TimeSpan.Zero) + "/" + _GetTimeSpanFormatString(m_selectedSoundLength);
			
			ui_trackBar.Minimum = 0;
			ui_trackBar.Maximum = (int)m_selectedSoundLength.TotalSeconds;
			ui_trackBar.Value = selectedSound.StartTime == TimeSpan.Zero ? 0 : (int)selectedSound.StartTime.TotalSeconds;
			m_selectedSound = selectedSound;
		}

		public void SetSelectedSound(string filename)
		{
			SetSelectedSound(new Sound(filename));
		}

		#region Event Handlers

		private void EV_SliderChanged(object sender, EventArgs e)
		{
			ui_timeLabel.Text = _GetTimeSpanFormatString(TimeSpan.FromSeconds(ui_trackBar.Value)) + "/" + _GetTimeSpanFormatString(m_selectedSoundLength);
		}

		private void EV_PlayClicked(object sender, MouseEventArgs e)
		{
			if(m_selectedSound == null) return;

			SoundPlayer.Play(m_selectedSound, TimeSpan.FromSeconds(ui_trackBar.Value));
		}

		private void EV_StopClicked(object sender, MouseEventArgs e)
		{
			SoundPlayer.StopAllSounds();
		}

		private void EV_VolumeChanged(object sender, EventArgs e)
		{
			SoundPlayer.SetVolume(ui_volumeBar.VolumeNormalized);
			SoundboardSettings.GlobalVolume = ui_volumeBar.Volume;
		}

		private void EV_MuteMicChanged(object sender, EventArgs e)
		{
			SoundboardSettings.MuteMicrophoneWhilePlaying = ui_muteMicWhilePlaying.Checked;

			if(SoundPlayer.IsPlaying)
			{
				SoundboardSettings.SetMicMuted(SoundboardSettings.MuteMicrophoneWhilePlaying);
			}
			else
			{
				SoundboardSettings.SetMicMuted(false);
			}
		}
		#endregion

		// TODO: Look into better methods for this.
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
	}
}
