using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCore;
using CSCore.CoreAudioAPI;

namespace Registry_Tester
{
	class Program
	{
		static void RefreshDeviceProperties()
		{
			Console.Clear();

			using(MMDeviceEnumerator x = new MMDeviceEnumerator())
			{
				// Get list of output devices.
				List<MMDevice> outputDevices = new List<MMDevice>();
				foreach(MMDevice speaker in x.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
				{
					//Console.WriteLine(speaker.FriendlyName + " -> " + speaker.DeviceID);
					outputDevices.Add(speaker);
				}

				foreach(MMDevice capture in x.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine(capture.FriendlyName + " -> " + capture.DeviceID);
					Console.ResetColor();

					// Print all Key, Value pars in the properties for the "Listen" tab.
					foreach(var p in capture.PropertyStore.Where(y => y.Key.ToString().Contains("24dbb0fc-9311-4b3d-9cf0-18ff155639d4")))
					{
						Console.WriteLine("Key: " + p.Key + " Value: " + p.Value);
					}

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Keys that have a output device GUID as their value");
					Console.ResetColor();

					Console.ForegroundColor = ConsoleColor.Yellow;
					List<string> matchingDeviceIDS = new List<string>();
					foreach(var p in capture.PropertyStore.Where(y => outputDevices.Select(i => i.DeviceID).Contains(y.Value.ToString())))
					{
						matchingDeviceIDS.Add(p.Value.ToString());
						Console.WriteLine("Matching Key: " + p.Key + " Value: " + p.Value);
					}

					Console.ForegroundColor = ConsoleColor.Red;
					foreach(string id in matchingDeviceIDS)
					{
						foreach(MMDevice speaker in x.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active).Where(z => matchingDeviceIDS.Contains(z.DeviceID)))
						{
							Console.WriteLine(speaker.FriendlyName + " ID: " + speaker.DeviceID);
						}
					}
					Console.ResetColor();

					Console.ResetColor();
					Console.WriteLine("\n");
				}
			}
		}

		static void Main(string[] args)
		{
			while(Console.Read() != 'q')
			{
				RefreshDeviceProperties();

				Console.WriteLine("Enter q to quit.");
			}
		}
	}
}
