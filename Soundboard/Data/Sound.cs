using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Soundboard
{
	public class Sound
	{
		private string _FullFilepath;
		
		public Hotkey HotKey { get; private set; } = new Hotkey();

		public TimeSpan StartTime { get; set; } = TimeSpan.Zero;

		/// <summary>
		/// Gets or sets the full filepath for a supported audio file.
		/// </summary>
		/// <exception cref="FileNotFoundException">Thrown when the file given does not exist.</exception>
		public string FullFilepath
		{
			get { return _FullFilepath; }
			set
			{
				if(!File.Exists(value)) throw new FileNotFoundException();

				_FullFilepath = value;
				Filename = Path.GetFileName(_FullFilepath);
				FilenameWithFolder = _ConstructFilenameWithFolder(_FullFilepath);
			}
		}

		/// <summary>
		/// Gets or sets a user chosen name for the Sound.
		/// </summary>
		public string Nickname { get; set; }

		/// <summary>
		/// Gets the filename with extension. Set automatically by setting <see cref="FullFilepath"/>.
		/// </summary>
		public string Filename { get; private set; }

		/// <summary>
		/// Gets a path of the filename and it's parent folder. Set by setting <see cref="FullFilepath"/>.
		/// </summary>
		public string FilenameWithFolder { get; private set; }

        public string DisplayName { get { return string.IsNullOrWhiteSpace(Nickname) ? FilenameWithFolder : Nickname; } }

		public Sound(string filepath)
		{
			FullFilepath = filepath;
		}

		private string _ConstructFilenameWithFolder(string filepath)
		{
			string[] Split = FullFilepath.Split(Path.DirectorySeparatorChar);
			return @"" + Split[Split.Length - 2] + Path.DirectorySeparatorChar + Split[Split.Length - 1];
		}
	}
}
