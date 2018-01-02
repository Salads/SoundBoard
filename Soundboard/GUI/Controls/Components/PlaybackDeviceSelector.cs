using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.GUI.Controls.Components
{
	public class PlaybackDeviceSelector : ListView
	{
		public PlaybackDeviceSelector() : base()
		{
		}

		/// <summary>
		/// Initializes the Control. Not in constructor to be designer friendly.
		/// </summary>
		public void Initialize()
		{
			_InitializeDevices();

			ItemChecked += PlaybackDeviceSelector_ItemChecked;
			SizeChanged += PlaybackDeviceSelector_SizeChanged;
		}

		// TODO: https://stackoverflow.com/questions/2488622/how-to-hide-the-vertical-scroll-bar-in-a-net-listview-control-in-details-mode
		// The current method of getting rid of the horz scrollbar is not sufficient.
		private void PlaybackDeviceSelector_SizeChanged(object sender, EventArgs e)
		{
			Columns[0].Width = Width - 4 - SystemInformation.VerticalScrollBarWidth;
		}

		private void PlaybackDeviceSelector_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			AudioDevice changedDevice = e.Item.Tag as AudioDevice;
			if(changedDevice == null) return; // Should never happen

			if(e.Item.Checked)
			{
				if(!SoundboardSettings.PlaybackDevices.Contains(changedDevice))
				{
					SoundboardSettings.PlaybackDevices.Add(changedDevice);
				}
			}
			else
			{
				SoundboardSettings.PlaybackDevices.Remove(changedDevice);
				// TODO: Stop sounds on device here.
			}
		}

		private void _InitializeDevices()
		{
			Items.Clear();

			List<string> savedOutputIDs = SoundboardSettings.PlaybackDevices.Select(x => x.DeviceID).ToList();
			foreach(MMDevice output in DeviceHelper.GetActivePlaybackDevices())
			{
				ListViewItem newItem = new ListViewItem()
				{
					Text = output.FriendlyName,
					Checked = savedOutputIDs.Contains(output.DeviceID),
					Tag = new AudioDevice(output)
				};

				Items.Add(newItem);
			};
		}
	}
}
