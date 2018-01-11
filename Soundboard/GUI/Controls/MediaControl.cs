using System;
using System.Windows.Forms;
using System.IO;
using CSCore.Codecs;
using CSCore;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Soundboard.Data.Interfaces;

namespace Soundboard
{
	public partial class MediaControl : UserControl, ISoundPlayerUser
	{
		private Sound m_selectedSound;
		private TimeSpan m_selectedSoundLength;

		public SoundPlayer SoundPlayer { get; set; }

		public bool ShowName
		{
			get { return ui_selectedSoundLabel.Visible; }
			set { ui_selectedSoundLabel.Visible = value; }
		}

		public TimeSpan Position { get { return TimeSpan.FromSeconds(ui_trackBar.Value); } }

		/// <summary>
		/// Creates a new MediaControl, creating a new instance of a <see cref="SoundPlayer"/> to play sounds.
		/// </summary>wdaads
		public MediaControl()
		{
			InitializeComponent();
			ui_volumeBar.Volume = SoundboardSettings.GlobalVolume;

			// I set this here because initialization would cause some issues.
			ui_volumeBar.VolumeChanged += new EventHandler(EV_VolumeChanged);
			ui_volumeBar.Invalidate();
		}

		public void SoundList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if(e.IsSelected)
			{
				SetSelectedSound(e.Item.Tag as Sound);
			}
		}

		public void SetSelectedSound(Sound selectedSound)
		{
			if(selectedSound == null) return;

			ui_selectedSoundLabel.Text = Path.GetFileName(selectedSound.Nickname != null ? selectedSound.Nickname : selectedSound.Filename);

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

			SoundPlayer?.Play(m_selectedSound, TimeSpan.FromSeconds(ui_trackBar.Value));
		}

		private void EV_StopClicked(object sender, MouseEventArgs e)
		{
			SoundPlayer?.StopAllSounds();
		}

		private void EV_VolumeChanged(object sender, EventArgs e)
		{
			SoundPlayer.VolumeNormalized = ui_volumeBar.VolumeNormalized;
			SoundboardSettings.GlobalVolume = ui_volumeBar.Volume;
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
