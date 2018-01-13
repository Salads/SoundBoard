using CSCore.CoreAudioAPI;
using Soundboard.Data.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using Soundboard.Data;

namespace Soundboard.GUI.Controls.Components
{
	public class PlaybackDevicesSelector : ListView
	{
		public PlaybackDevicesSelector()
		{
		}

		~PlaybackDevicesSelector()
		{
			ItemChecked -= PlaybackDeviceSelector_ItemChecked;
			SizeChanged -= PlaybackDeviceSelector_SizeChanged;
			Devices.ActivePlaybackDevices.ListChanged -= ActivePlaybackDevices_ListChanged;
			Devices.ActivePlaybackDevices.RemovingItem -= ActivePlaybackDevices_RemovingItem;
		}

		public void InitializeOptions()
		{
			ItemChecked -= PlaybackDeviceSelector_ItemChecked;
			SizeChanged -= PlaybackDeviceSelector_SizeChanged;
			Devices.ActivePlaybackDevices.ListChanged -= ActivePlaybackDevices_ListChanged;
			Devices.ActivePlaybackDevices.RemovingItem -= ActivePlaybackDevices_RemovingItem;

			Items.Clear();

			List<string> savedOutputIDs = SoundboardSettings.SelectedPlaybackDevices.Select(x => x.DeviceID).ToList();
			foreach(AudioDevice device in Devices.ActivePlaybackDevices)
			{
				ListViewItem newItem = new ListViewItem()
				{
					Text = device.FriendlyName,
					Checked = savedOutputIDs.Contains(device.DeviceID),
					Tag = device
				};

				Items.Add(newItem);
			};

			ItemChecked += PlaybackDeviceSelector_ItemChecked;
			SizeChanged += PlaybackDeviceSelector_SizeChanged;
			Devices.ActivePlaybackDevices.ListChanged += ActivePlaybackDevices_ListChanged;
			Devices.ActivePlaybackDevices.RemovingItem += ActivePlaybackDevices_RemovingItem;

		}

		private void ActivePlaybackDevices_RemovingItem(object sender, ItemRemovedArgs<AudioDevice> e)
		{
			foreach(ListViewItem item in Items)
			{
				if(item.Tag as AudioDevice == e.RemovedItem)
				{
					Items.Remove(item);
				}
			}
		}

		private void ActivePlaybackDevices_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			if(e.ListChangedType == ListChangedType.ItemAdded)
			{
				AudioDevice newDevice = Devices.ActivePlaybackDevices[e.NewIndex];

				ListViewItem newItem = new ListViewItem()
				{
					Text = newDevice.FriendlyName,
					Checked = SoundboardSettings.SelectedPlaybackDevices.Contains(newDevice),
					Tag = newDevice
				};

				Items.Add(newItem);
			}
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
				if(!SoundboardSettings.SelectedPlaybackDevices.Contains(changedDevice))
				{
					SoundboardSettings.SelectedPlaybackDevices.Add(changedDevice);
				}
			}
			else
			{
				SoundboardSettings.SelectedPlaybackDevices.Remove(changedDevice);
				// TODO: Stop sounds on device here?
			}
		}
	}
}
