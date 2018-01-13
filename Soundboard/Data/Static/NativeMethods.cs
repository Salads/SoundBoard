using RawInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Data.Static
{
	/// <summary>
	/// Static class to keep all the Win32 stuff in one neat place.
	/// </summary>
	static class NativeMethods
	{
		public const int EM_SETCUEBANNER = 0x1501;

		/// <summary>
		/// Window message; sent to windows that receive RawInput.
		/// </summary>
		public const Int32 WM_INPUT = 0x00FF;

		[DllImport("User32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll")]
		public static extern int GetKeyNameText(Int32 lParam, [Out] StringBuilder lpString, int nSize);

		/// <summary>Function to register a raw input device.</summary>
		/// <param name="pRawInputDevices">Array of raw input devices.</param>
		/// <param name="uiNumDevices">Number of devices.</param>
		/// <param name="cbSize">Size of the RAWINPUTDEVICE structure.</param>
		/// <returns>TRUE if successful, FALSE if not.</returns>
		[DllImport("user32.dll")]
		public static extern bool RegisterRawInputDevices([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize);

		/// <summary>
		/// Function to retrieve raw input data.
		/// </summary>
		/// <param name="hRawInput">Handle to the raw input.</param>
		/// <param name="uiCommand">Command to issue when retrieving data.</param>
		/// <param name="Data">Raw input data.</param>
		/// <param name="pcbSize">Number of bytes in the array.</param>
		/// <param name="cbSizeHeader">Size of the header.</param>
		/// <returns>0 if successful if pData is null, otherwise number of bytes if pData is not null.</returns>
		[DllImport("user32.dll")]
		unsafe public static extern UInt32 GetRawInputData(IntPtr hRawInput, UInt32 uiCommand, void* Data, ref UInt32 pcbSize, Int32 cbSizeHeader);
	}
}
