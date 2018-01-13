using System;
using System.Runtime.InteropServices;

// TODO: Go through the RawInput stuff and change ranges from const to enums.

namespace RawInput
{
	/// <summary>
	/// RawInput methods and consts.
	/// </summary>
	public static partial class RI
	{
		/// <summary>
		/// Size of the RAWINPUTHEADER struct.
		/// Depends on build target.
		/// </summary>
#if WIN64
		public const int RAWINPUTHEADER_SIZE = 24;
#elif WIN32
		public const int RAWINPUTHEADER_SIZE = 16;
#endif
		/// <summary>
		/// Used with <see cref="RAWINPUTDEVICE.dwFlags"/> to receive input even when called is not in the foreground. 
		/// <see cref="RAWINPUTDEVICE.hwndTarget"/> must be set if you use this!
		/// </summary>
		public const UInt32 RIDEV_INPUTSINK = 0x00000100;

		/// <summary>
		/// Used with <see cref="GetRawInputData"/>. <para/>
		/// Tells the function to get <see cref="RAWINPUTHEADER"/> of a <see cref="RAWINPUT"/> struct.
		/// </summary>
		public const UInt32 RID_HEADER = 0x10000005;

		/// <summary>
		/// Used with <see cref="GetRawInputData"/>. <para/>
		/// Tells the function to get raw data for a <see cref="RAWINPUT"/> struct.
		/// </summary>
		public const UInt32 RID_INPUT = 0x10000003;

		/// <summary>
		/// If found in <see cref="RAWINPUTHEADER.dwType"/>, the <see cref="RAWINPUT"/> struct is for a mouse.
		/// </summary>
		public const UInt32 RIM_TYPEMOUSE = 0;

		/// <summary>
		/// If found in <see cref="RAWINPUTHEADER.dwType"/>, the <see cref="RAWINPUT"/> struct is for a keyboard.
		/// </summary>
		public const UInt32 RIM_TYPEKEYBOARD = 1;

		/// <summary>
		/// If found in <see cref="RAWINPUTHEADER.dwType"/>, the <see cref="RAWINPUT"/> struct is for a generic HID.
		/// </summary>
		public const UInt32 RIM_TYPEHID = 2;
	}

	/// <summary>
	/// Flags for <see cref="RAWKEYBOARD.Flags"/>
	/// </summary>
	[Flags]
	public enum RKeyboardFlags : UInt16
	{
		/// <summary>
		/// The key is down.
		/// </summary>
		RI_KEY_MAKE = 0,
		/// <summary>
		/// The key is up.
		/// </summary>
		RI_KEY_BREAK = 1,
		/// <summary>
		/// The scan code has the E0 prefix.
		/// </summary>
		RI_KEY_E0 = 2,
		/// <summary>
		/// The scan code has the E1 prefix.
		/// </summary>
		RI_KEY_E1 = 4
	}

	/// <summary>Value type for raw input devices.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTDEVICE
	{
		/// <summary>Top level collection Usage page for the raw input device.</summary>
		public UInt16 usUsagePage;
		/// <summary>Top level collection Usage for the raw input device. </summary>
		public UInt16 usUsage;
		/// <summary>Mode flag that specifies how to interpret the information provided by UsagePage and Usage.</summary>
		public UInt32 dwFlags;
		/// <summary>Handle to the target device. If NULL, it follows the keyboard focus.</summary>
		public IntPtr hwndTarget;
	}

	/// <summary>
	/// Value type for a raw input header.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTHEADER
	{
		/// <summary>Type of device the input is coming from.</summary>
		public UInt32 dwType;
		/// <summary>Size of the packet of data.</summary>
		public Int32 dwSize;
		/// <summary>Handle to the device sending the data.</summary>
		public IntPtr hDevice;
		/// <summary>wParam from the window message.</summary>
		public IntPtr wParam;
	}

	/// <summary>
	/// Enumeration containing the button data for raw mouse input.
	/// </summary>
	[Flags()]
	public enum RawMouseButtons : ushort
	{
		/// <summary>No button.</summary>
		None = 0,
		/// <summary>Left Mouse Button down.</summary>
		RI_MOUSE_BUTTON_1_DOWN = 0x0001,
		/// <summary>Left Mouse Button up.</summary>
		RI_MOUSE_BUTTON_1_UP = 0x0002,
		/// <summary>Right Mouse Button down.</summary>
		RI_MOUSE_BUTTON_2_DOWN = 0x0004,
		/// <summary>Right Mouse Button up.</summary>
		RI_MOUSE_BUTTON_2_UP = 0x0008,
		/// <summary>Middle Mouse Wheel Button down.</summary>
		RI_MOUSE_BUTTON_3_DOWN = 0x0010,
		/// <summary>Middle Mouse Wheel up.</summary>
		RI_MOUSE_BUTTON_3_UP = 0x0020,
		/// <summary>Button 4 down ( XButton1 ).</summary>
		RI_MOUSE_BUTTON_4_DOWN = 0x0040,
		/// <summary>Button 4 up ( XButton1 ).</summary>
		RI_MOUSE_BUTTON_4_UP = 0x0080,
		/// <summary>Button 5 down ( XButton2 ).</summary>
		RI_MOUSE_BUTTON_5_DOWN = 0x0100,
		/// <summary>Button 5 up ( XButton2 ).</summary>
		RI_MOUSE_BUTTON_5_UP = 0x0200,
		/// <summary>Mouse wheel moved.</summary>
		RI_MOUSE_WHEEL = 0x0400
	}

	/// <summary>
	/// Enumeration containing the flags for raw mouse data.
	/// </summary>
	[Flags()]
	public enum RawMouseFlags : ushort
	{
		/// <summary>Relative to the last position.</summary>
		MoveRelative = 0,
		/// <summary>Absolute positioning.</summary>
		MoveAbsolute = 1,
		/// <summary>Coordinate data is mapped to a virtual desktop.</summary>
		VirtualDesktop = 2,
		/// <summary>Attributes for the mouse have changed.</summary>
		AttributesChanged = 4
	}

	/// <summary>
	/// Contains information about the state of the mouse.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct RAWMOUSE
	{
		/// <summary>
		/// The mouse state.
		/// </summary>
		[FieldOffset(0)]
		public RawMouseFlags usFlags;
		/// <summary>
		/// Flags for the event.
		/// </summary>
		[FieldOffset(4)]
		public RawMouseButtons usButtonFlags;
		/// <summary>
		/// If the mouse wheel is moved, this will contain the delta amount.
		/// </summary>
		[FieldOffset(6)]
		public ushort usButtonData;
		/// <summary>
		/// Raw button data.
		/// </summary>
		[FieldOffset(8)]
		public uint ulRawButtons;
		/// <summary>
		/// The motion in the X direction. This is signed relative motion or 
		/// absolute motion, depending on the value of usFlags. 
		/// </summary>
		[FieldOffset(12)]
		public int lLastX;
		/// <summary>
		/// The motion in the Y direction. This is signed relative motion or absolute motion, 
		/// depending on the value of usFlags. 
		/// </summary>
		[FieldOffset(16)]
		public int lLastY;
		/// <summary>
		/// The device-specific additional information for the event. 
		/// </summary>
		[FieldOffset(20)]
		public uint ulExtraInformation;
	}

	/// <summary>
	/// Value type for raw input from a keyboard.
	/// </summary>    
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWKEYBOARD
	{
		/// <summary>Scan code for key depression.</summary>
		public UInt16 MakeCode;
		/// <summary>Scan code information.</summary>
		public UInt16 Flags;
		/// <summary>Reserved.</summary>
		public UInt16 Reserved;
		/// <summary>Virtual key code.</summary>
		public UInt16 VKey;
		/// <summary>Corresponding window message.</summary>
		public UInt32 Message;
		/// <summary>Extra information.</summary>
		public UInt32 ExtraInformation;
	}

	/// <summary>
	/// Describes the format of the raw input from a Human Interface Device (HID). <para/>
	/// Each <see cref="RI.WM_INPUT"/> can indicate several inputs, but all of the inputs come from the same HID. The size of the bRawData array is dwSizeHid * dwCount.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct RAWHID
	{
		/// <summary>
		/// The size, in bytes, of each HID input in bRawData.
		/// </summary>
		UInt32 dwSizeHid;
		/// <summary>
		/// The number of HID inputs in bRawData.
		/// </summary>
		UInt32 dwCount;
		/// <summary>
		/// The raw input data, as an array of bytes.
		/// </summary>
		Byte* bRawData;
	}

	/// <summary>
	/// Contains the raw input from a device. <para/>
	/// Retrieved from raw byte array from <see cref="RI.GetRawInputData"/>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct RAWINPUT
	{
		/// <summary>
		/// The raw input data.
		/// </summary>
		[FieldOffset(0)]
		public RAWINPUTHEADER header;

		/// <summary>
		/// If the data comes from a mouse, this is the raw input data.
		/// </summary>
		[FieldOffset(RI.RAWINPUTHEADER_SIZE)]
		public RAWMOUSE mouse;

		/// <summary>
		/// If the data comes from a keyboard, this is the raw input data.
		/// </summary>
		[FieldOffset(RI.RAWINPUTHEADER_SIZE)]
		public RAWKEYBOARD keyboard;

		/// <summary>
		/// If the data comes from an HID, this is the raw input data.
		/// </summary>
		[FieldOffset(RI.RAWINPUTHEADER_SIZE)]
		public RAWHID hid;
	}
}