using RawInput;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.Data
{
	public static class RawInputHandler
	{
		public static bool HasKeysPressed
		{
			get { return !m_pressedKeys.Any(); }
		}

		public static bool ExecuteHotkeys { get; set; } = true;

		private static Hotkey m_pressedKeys = new Hotkey();
		private static Dictionary<Hotkey, Sound> m_hotkeyMap = new Dictionary<Hotkey, Sound>();
		private static bool _LastKeyWasDown = false;
		private static bool _KeysChanged = false;

		public static event EventHandler<HotkeyPressedArgs> HotkeyPressed;
		public static event EventHandler<KeysChangedArgs> KeysChanged;

		static RawInputHandler()
		{
			ConstructHotkeyMap();

			SoundboardSettings.Sounds.CollectionChanged += Sounds_CollectionChanged;
		}

		/// <summary>
		/// Syncs the hotkey map to the global sounds collection when it changes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void Sounds_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach(var item in e.NewItems)
				{
					Sound newSound = item as Sound;
					m_hotkeyMap.Add(newSound.HotKey, newSound);
				}
			}
			else if(e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach(var item in e.OldItems)
				{
					Sound oldSound = item as Sound;
					m_hotkeyMap.Remove(oldSound.HotKey);
				}
			}
			else if(e.Action == NotifyCollectionChangedAction.Reset)
			{
				m_hotkeyMap.Clear();
			}
		}

		public static void ConstructHotkeyMap()
		{
			m_hotkeyMap.Clear();

			foreach (Sound sound in SoundboardSettings.Sounds)
			{
				if(sound.HotKey.Any())
				{
					m_hotkeyMap.Add(sound.HotKey, sound);
				}
			}
		}

		private static void _CheckHotkeys()
		{
			//_PrintHotkeys();

			if(ExecuteHotkeys && m_hotkeyMap.Keys.Contains(m_pressedKeys))
			{
				HotkeyPressed?.Invoke(null, new HotkeyPressedArgs(m_hotkeyMap[m_pressedKeys]));
			}
		}

		private static void _PrintHotkeys()
		{
			Debug.WriteLine("HotKey: " + m_pressedKeys.ToString() + ", " + "Contains: " + m_hotkeyMap.ContainsKey(m_pressedKeys));
		}

		public static void HandleRawInput(ref Message message)
		{
			unsafe
			{
				_KeysChanged = false;
				UInt32 dataSize = 0;
				RI.GetRawInputData(message.LParam, RI.RID_INPUT, (void*)0, ref dataSize, Marshal.SizeOf<RAWINPUTHEADER>());

				Byte* lpData = stackalloc Byte[(int)dataSize];
				RI.GetRawInputData(message.LParam, RI.RID_INPUT, lpData, ref dataSize, Marshal.SizeOf<RAWINPUTHEADER>());

				RAWINPUT* input = (RAWINPUT*)lpData;
				if(input->header.dwType == RI.RIM_TYPEKEYBOARD)
				{
					RKeyboardFlags flags = (RKeyboardFlags)input->keyboard.Flags;
					Keys key = (Keys)input->keyboard.VKey;

					Application.OpenForms[0].Text = "ExtraInformation: " + input->keyboard.ExtraInformation;

					if(flags.HasFlag(RKeyboardFlags.RI_KEY_MAKE) && !m_pressedKeys.Contains(key))
					{
						// DEBUG
						byte scanCode = (byte)input->keyboard.MakeCode;
						Int32 reconstructedMessage = 0;
						reconstructedMessage |= (scanCode << 16);

						StringBuilder str = new StringBuilder();
						RI.GetKeyNameText(reconstructedMessage, str, 64);
						Debug.WriteLine("\"" + str + "\"" + " : " + key + " : " + new KeysConverter().ConvertToString(key));
						//

						_LastKeyWasDown = true;
						_KeysChanged = true;
						m_pressedKeys.Add(key);
						KeysChanged?.Invoke(null, new KeysChangedArgs(key, KeysChangedAction.Added));
					}
					else if(flags.HasFlag(RKeyboardFlags.RI_KEY_BREAK) && m_pressedKeys.Contains(key))
					{
						_LastKeyWasDown = false;
						_KeysChanged = true;
						m_pressedKeys.Remove(key);
						KeysChanged?.Invoke(null, new KeysChangedArgs(key, KeysChangedAction.Removed));
					}
				}
				else if(input->header.dwType == RI.RIM_TYPEMOUSE)
				{
					ProcessMouseEvents(input->mouse.usButtonFlags);
				}
				else
				{
					Debug.WriteLine("HID Device detected");
				}

				if(m_pressedKeys.Any() && _LastKeyWasDown && _KeysChanged)
				{
					// _PrintKeysToOutput();

					_CheckHotkeys();
				}
			}
		}

		[Conditional("DEBUG")]
		private static void _PrintKeysToOutput()
		{
			for(int x = 0; x < m_pressedKeys.Count; ++x)
			{
				Debug.Write(m_pressedKeys.ElementAt(x));
				Debug.WriteIf(x < m_pressedKeys.Count - 1, " + ");
			}
			Debug.WriteLine("");
		}

		private static string ConstructFlagLogLine(string flagName, RawMouseButtons flags, RawMouseButtons flag)
		{
			return flagName + ": " + flags.HasFlag(flag);
		}

		private static void GetKeyFromFlag(RawMouseButtons flag, ref Keys key, ref bool down)
		{
			if(flag == RawMouseButtons.None)
			{
				key = Keys.None;
				down = false;
			}
			else if(flag == RawMouseButtons.RI_MOUSE_BUTTON_1_DOWN || flag == RawMouseButtons.RI_MOUSE_BUTTON_1_UP)
			{
				key = Keys.LButton;
				down = flag == RawMouseButtons.RI_MOUSE_BUTTON_1_DOWN ? true : false;
			}
			else if(flag == RawMouseButtons.RI_MOUSE_BUTTON_2_DOWN || flag == RawMouseButtons.RI_MOUSE_BUTTON_2_UP)
			{
				key = Keys.RButton;
				down = flag == RawMouseButtons.RI_MOUSE_BUTTON_2_DOWN ? true : false;
			}
			else if(flag == RawMouseButtons.RI_MOUSE_BUTTON_3_DOWN || flag == RawMouseButtons.RI_MOUSE_BUTTON_3_UP)
			{
				key = Keys.MButton;
				down = flag == RawMouseButtons.RI_MOUSE_BUTTON_3_DOWN ? true : false;
			}
			else if(flag == RawMouseButtons.RI_MOUSE_BUTTON_4_DOWN || flag == RawMouseButtons.RI_MOUSE_BUTTON_4_UP)
			{
				key = Keys.XButton1;
				down = flag == RawMouseButtons.RI_MOUSE_BUTTON_4_DOWN ? true : false;
			}
			else if(flag == RawMouseButtons.RI_MOUSE_BUTTON_5_DOWN || flag == RawMouseButtons.RI_MOUSE_BUTTON_5_UP)
			{
				key = Keys.XButton2;
				down = flag == RawMouseButtons.RI_MOUSE_BUTTON_5_DOWN ? true : false;
			}
		}

		private static void ProcessMouseEvents(RawMouseButtons flags)
		{
			if(flags == RawMouseButtons.None) return;

			foreach(RawMouseButtons flag in Enum.GetValues(typeof(RawMouseButtons)))
			{
				if(flags.HasFlag(flag))
				{
					Keys key = Keys.None;
					bool down = false;
					GetKeyFromFlag(flag, ref key, ref down);

					if(down && !m_pressedKeys.Contains(key))
					{
						_LastKeyWasDown = true;
						_KeysChanged = true;
						m_pressedKeys.Add(key);
						KeysChanged?.Invoke(null, new KeysChangedArgs(key, KeysChangedAction.Added));
					}
					else if (!down && m_pressedKeys.Contains(key))
					{
						_LastKeyWasDown = false;
						_KeysChanged = true;
						m_pressedKeys.Remove(key);
						KeysChanged?.Invoke(null, new KeysChangedArgs(key, KeysChangedAction.Removed));
					}
				}
			}
		}
	}

	public enum KeysChangedAction
	{
		Removed,
		Added
	}

	public class HotkeyPressedArgs
	{
		public Sound Sound { get; set; }

		public HotkeyPressedArgs(Sound sound) => Sound = sound;
	}

	public class KeysChangedArgs
	{
		public Keys Key { get; private set; }
		public KeysChangedAction Action { get; private set; }

		public KeysChangedArgs(Keys key, KeysChangedAction action)
		{
			Key = key;
			Action = action;
		}
	}
}
