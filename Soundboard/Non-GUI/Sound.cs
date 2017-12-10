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
		private string m_FullPath = string.Empty;
		private Hotkey m_HotkeyCombo = null;

		/// <summary>
		/// Gets the filename with extension.
		/// </summary>
		[JsonIgnore]
		public string Filename
		{
			get
			{
				return Path.GetFileName(m_FullPath);
			}
		}

		/// <summary>
		/// Gets a string of the filename and it's folder.
		/// </summary>
		[JsonIgnore]
		public string FilenameWithFolder
		{
			get
			{
				string[] Split = m_FullPath.Split(Path.DirectorySeparatorChar);
				return @"" + Split[Split.Length - 2] + Path.DirectorySeparatorChar + Split[Split.Length - 1];
			}
		}

		[JsonProperty]
		public string FullFilepath
		{
			get { return m_FullPath; }
			set { m_FullPath = value; }
		}

		/// <summary>
		/// Returns true if the Sound is valid. (The file exists)
		/// </summary>
		[JsonIgnore]
		public bool IsValid
		{
			get
			{
				return File.Exists(m_FullPath);
			}
		}

		public Sound(string FullPath, Hotkey HotkeyCombo)
		{
			m_FullPath = FullPath;
			m_HotkeyCombo = HotkeyCombo;
		}
	}
}
