using System;
using CSCore.CoreAudioAPI;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Soundboard
{
    // TODO: Better interface for AudioDevice, like device volume, etc.

    public class AudioDevice : INotifyPropertyChanged, IDisposable
    {
        private bool _selected = false;

		public AudioDevice(MMDevice NewDevice)
		{
			MMDevice = NewDevice ?? throw new ArgumentNullException("NewDevice", "Device cannot be null.");
			MMDeviceVolume = AudioEndpointVolume.FromDevice(NewDevice);
            OriginalMicMute = MMDeviceVolume.IsMuted;
		}

        #region Properties

        public string FriendlyName { get { return MMDevice.FriendlyName; } }

		public string DeviceID 
		{
			get { return MMDevice.DeviceID; }
		}

		public MMDevice MMDevice { get; private set; }

		public AudioEndpointVolume MMDeviceVolume { get; private set; }

        public bool OriginalMicMute { get; private set; }

        public bool Selected 
        {
            get { return _selected; }
            set
            {
                if(value != _selected)
                {
                    _selected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose() 
		{
			MMDevice.Dispose();
			MMDeviceVolume.Dispose();
		}

		public override string ToString() 
		{
			return FriendlyName;
		}
	}
}
