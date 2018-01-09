using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace RawInput
{
	public static partial class RI
	{
		[DllImport("user32.dll")]
		public static extern int GetKeyNameText(Int32 lParam, [Out] StringBuilder lpString, int nSize);

		public static void RegisterDevices(IntPtr windowHandle)
		{
			RAWINPUTDEVICE[] devices = new RAWINPUTDEVICE[2];

			// FUTURE: Encapsulate these constants in a hashtable or something?

			// Mouse
			devices[0].usUsagePage = 0x01;
			devices[0].usUsage = 0x02;
			devices[0].dwFlags = RI.RIDEV_INPUTSINK;
			devices[0].hwndTarget = windowHandle;

			// Keyboard
			devices[1].usUsagePage = 0x01;
			devices[1].usUsage = 0x06;
			devices[1].dwFlags = RI.RIDEV_INPUTSINK;
			devices[1].hwndTarget = windowHandle;

			//// Keypad (Don't know what this actually is, maybe a seperate numpad? Keyboard seems to pick up the numpad fine.)
			//devices[2].UsagePage = 0x01;
			//devices[2].Usage = 0x07;
			//devices[2].Flags = RIDEV_INPUTSINK;
			//devices[2].WindowHandle = windowHandle;

			if(RI.RegisterRawInputDevices(devices, 2, Marshal.SizeOf(devices[0])))
			{
				Debug.WriteLine("Registered RawInput Devices.");
			}
			else
			{
				Debug.WriteLine("[ERROR] RawInput registration failed!");
			}
		}
	}
}
