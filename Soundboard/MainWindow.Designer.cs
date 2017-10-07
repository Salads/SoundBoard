namespace Soundboard
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.GUI_MenuStrip = new System.Windows.Forms.MenuStrip();
			this.ToolStripItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Help = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_HowTo = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_DeviceSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetDeviceSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetAllSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetHotkeys = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.GUI_MenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// GUI_MenuStrip
			// 
			this.GUI_MenuStrip.BackColor = System.Drawing.Color.Gainsboro;
			this.GUI_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripItem_Settings,
            this.Menu_Help});
			this.GUI_MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.GUI_MenuStrip.Name = "GUI_MenuStrip";
			this.GUI_MenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.GUI_MenuStrip.Size = new System.Drawing.Size(433, 24);
			this.GUI_MenuStrip.TabIndex = 0;
			this.GUI_MenuStrip.Text = "menuStrip1";
			// 
			// ToolStripItem_Settings
			// 
			this.ToolStripItem_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_DeviceSettings,
            this.Menu_ResetSettings});
			this.ToolStripItem_Settings.Name = "ToolStripItem_Settings";
			this.ToolStripItem_Settings.Size = new System.Drawing.Size(61, 20);
			this.ToolStripItem_Settings.Text = "Options";
			// 
			// Menu_Help
			// 
			this.Menu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_HowTo});
			this.Menu_Help.Name = "Menu_Help";
			this.Menu_Help.Size = new System.Drawing.Size(44, 20);
			this.Menu_Help.Text = "Help";
			// 
			// Menu_HowTo
			// 
			this.Menu_HowTo.Name = "Menu_HowTo";
			this.Menu_HowTo.Size = new System.Drawing.Size(152, 22);
			this.Menu_HowTo.Text = "How To...";
			this.Menu_HowTo.Click += new System.EventHandler(this.Menu_HowTo_Click);
			// 
			// Menu_DeviceSettings
			// 
			this.Menu_DeviceSettings.Name = "Menu_DeviceSettings";
			this.Menu_DeviceSettings.Size = new System.Drawing.Size(154, 22);
			this.Menu_DeviceSettings.Text = "Device Settings";
			this.Menu_DeviceSettings.Click += new System.EventHandler(this.Menu_DeviceSettings_Click);
			// 
			// Menu_ResetSettings
			// 
			this.Menu_ResetSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ResetDeviceSettings,
            this.Menu_ResetHotkeys,
            this.Menu_ResetFiles,
            this.Menu_ResetAllSettings});
			this.Menu_ResetSettings.Name = "Menu_ResetSettings";
			this.Menu_ResetSettings.Size = new System.Drawing.Size(154, 22);
			this.Menu_ResetSettings.Text = "Reset Settings";
			// 
			// Menu_ResetDeviceSettings
			// 
			this.Menu_ResetDeviceSettings.Name = "Menu_ResetDeviceSettings";
			this.Menu_ResetDeviceSettings.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetDeviceSettings.Text = "Reset Device Settings";
			this.Menu_ResetDeviceSettings.Click += new System.EventHandler(this.Menu_ResetDeviceSettings_Click);
			// 
			// Menu_ResetAllSettings
			// 
			this.Menu_ResetAllSettings.Name = "Menu_ResetAllSettings";
			this.Menu_ResetAllSettings.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetAllSettings.Text = "Reset All Settings";
			this.Menu_ResetAllSettings.Click += new System.EventHandler(this.Menu_ResetAllSettings_Click);
			// 
			// Menu_ResetHotkeys
			// 
			this.Menu_ResetHotkeys.Name = "Menu_ResetHotkeys";
			this.Menu_ResetHotkeys.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetHotkeys.Text = "Reset Hotkeys";
			this.Menu_ResetHotkeys.Click += new System.EventHandler(this.Menu_ResetHotkeys_Click);
			// 
			// Menu_ResetFiles
			// 
			this.Menu_ResetFiles.Name = "Menu_ResetFiles";
			this.Menu_ResetFiles.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetFiles.Text = "Reset Files";
			this.Menu_ResetFiles.Click += new System.EventHandler(this.Menu_ResetFiles_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 258);
			this.Controls.Add(this.GUI_MenuStrip);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.GUI_MenuStrip;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Soundboard";
			this.GUI_MenuStrip.ResumeLayout(false);
			this.GUI_MenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip GUI_MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ToolStripItem_Settings;
		private System.Windows.Forms.ToolStripMenuItem Menu_Help;
		private System.Windows.Forms.ToolStripMenuItem Menu_HowTo;
		private System.Windows.Forms.ToolStripMenuItem Menu_DeviceSettings;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetSettings;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetDeviceSettings;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetAllSettings;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetHotkeys;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetFiles;
	}
}

