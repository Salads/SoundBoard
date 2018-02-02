using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Soundboard
{
    static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            SBSettings.Instance.LoadFromFile();
            if (SBSettings.Instance.FirstRun)
            {
                DialogResult FirstResult =
                MessageBox.Show("Would you like to visit the \"How to\" webpage?",
                                "Welcome!",
                                MessageBoxButtons.YesNo);

                if (FirstResult == DialogResult.Yes)
                {
                    Process.Start("https://salads.github.io/Soundboard");
                }

                SBSettings.Instance.FirstRun = false;
                SBSettings.Instance.SaveToFile();
            }

			Application.Run(new MainForm());
		}
	}
}
