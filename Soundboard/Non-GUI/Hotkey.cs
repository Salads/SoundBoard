using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Soundboard
{
	public class Hotkey
	{
		public Hotkey Empty
		{
			get
			{
				return new Hotkey();
			}
		}

		public Hotkey()
		{
			Modifiers = ModifierKeys.None;
			Key = Key.None;
		}

		public ModifierKeys Modifiers { get; set; }
		public Key Key { get; set; }
	}
}
