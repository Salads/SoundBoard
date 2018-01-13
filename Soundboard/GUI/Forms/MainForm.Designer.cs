namespace Soundboard
{
	partial class MainForm
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
			this.Menu_ResetSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetDeviceSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetAllSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Help = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_HowTo = new System.Windows.Forms.ToolStripMenuItem();
			this.ui_tabControl = new System.Windows.Forms.TabControl();
			this.ui_tabMediaControl = new System.Windows.Forms.TabPage();
			this.ui_mediaControl = new Soundboard.MediaControl();
			this.ui_tabPageDevices = new System.Windows.Forms.TabPage();
			this.ui_deviceControl = new Soundboard.GUI.DevicesSelector();
			this.ui_tabPlaybackOptions = new System.Windows.Forms.TabPage();
			this.ui_soundViewer = new Soundboard.GUI.SoundViewer();
			this.GUI_MenuStrip.SuspendLayout();
			this.ui_tabControl.SuspendLayout();
			this.ui_tabMediaControl.SuspendLayout();
			this.ui_tabPageDevices.SuspendLayout();
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
			this.GUI_MenuStrip.Size = new System.Drawing.Size(462, 24);
			this.GUI_MenuStrip.TabIndex = 0;
			this.GUI_MenuStrip.Text = "menuStrip1";
			// 
			// ToolStripItem_Settings
			// 
			this.ToolStripItem_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ResetSettings});
			this.ToolStripItem_Settings.Name = "ToolStripItem_Settings";
			this.ToolStripItem_Settings.Size = new System.Drawing.Size(61, 20);
			this.ToolStripItem_Settings.Text = "Options";
			// 
			// Menu_ResetSettings
			// 
			this.Menu_ResetSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ResetDeviceSettings,
            this.Menu_ResetFiles,
            this.Menu_ResetAllSettings});
			this.Menu_ResetSettings.Name = "Menu_ResetSettings";
			this.Menu_ResetSettings.Size = new System.Drawing.Size(152, 22);
			this.Menu_ResetSettings.Text = "Reset Settings";
			// 
			// Menu_ResetDeviceSettings
			// 
			this.Menu_ResetDeviceSettings.Name = "Menu_ResetDeviceSettings";
			this.Menu_ResetDeviceSettings.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetDeviceSettings.Text = "Reset Device Settings";
			this.Menu_ResetDeviceSettings.Click += new System.EventHandler(this.EV_Menu_ResetDeviceSettings_Clicked);
			// 
			// Menu_ResetFiles
			// 
			this.Menu_ResetFiles.Name = "Menu_ResetFiles";
			this.Menu_ResetFiles.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetFiles.Text = "Reset Files";
			this.Menu_ResetFiles.Click += new System.EventHandler(this.EV_Menu_ResetSounds_Clicked);
			// 
			// Menu_ResetAllSettings
			// 
			this.Menu_ResetAllSettings.Name = "Menu_ResetAllSettings";
			this.Menu_ResetAllSettings.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetAllSettings.Text = "Reset All Settings";
			this.Menu_ResetAllSettings.Click += new System.EventHandler(this.EV_Menu_ResetAllSettings_Clicked);
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
			this.Menu_HowTo.Size = new System.Drawing.Size(124, 22);
			this.Menu_HowTo.Text = "How To...";
			this.Menu_HowTo.Click += new System.EventHandler(this.EV_Menu_HowTo_Clicked);
			// 
			// ui_tabControl
			// 
			this.ui_tabControl.Controls.Add(this.ui_tabMediaControl);
			this.ui_tabControl.Controls.Add(this.ui_tabPageDevices);
			this.ui_tabControl.Controls.Add(this.ui_tabPlaybackOptions);
			this.ui_tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ui_tabControl.HotTrack = true;
			this.ui_tabControl.Location = new System.Drawing.Point(0, 339);
			this.ui_tabControl.Multiline = true;
			this.ui_tabControl.Name = "ui_tabControl";
			this.ui_tabControl.SelectedIndex = 0;
			this.ui_tabControl.Size = new System.Drawing.Size(462, 180);
			this.ui_tabControl.TabIndex = 5;
			this.ui_tabControl.TabStop = false;
			this.ui_tabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EV_TabControl_KeyDown);
			// 
			// ui_tabMediaControl
			// 
			this.ui_tabMediaControl.BackColor = System.Drawing.SystemColors.Control;
			this.ui_tabMediaControl.Controls.Add(this.ui_mediaControl);
			this.ui_tabMediaControl.Location = new System.Drawing.Point(4, 24);
			this.ui_tabMediaControl.Name = "ui_tabMediaControl";
			this.ui_tabMediaControl.Padding = new System.Windows.Forms.Padding(3);
			this.ui_tabMediaControl.Size = new System.Drawing.Size(454, 152);
			this.ui_tabMediaControl.TabIndex = 0;
			this.ui_tabMediaControl.Text = "Manual Sound";
			// 
			// ui_mediaControl
			// 
			this.ui_mediaControl.BackColor = System.Drawing.SystemColors.Control;
			this.ui_mediaControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ui_mediaControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_mediaControl.Location = new System.Drawing.Point(3, 3);
			this.ui_mediaControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_mediaControl.Name = "ui_mediaControl";
			this.ui_mediaControl.ShowName = true;
			this.ui_mediaControl.Size = new System.Drawing.Size(448, 146);
			this.ui_mediaControl.SoundPlayer = null;
			this.ui_mediaControl.TabIndex = 0;
			// 
			// ui_tabPageDevices
			// 
			this.ui_tabPageDevices.Controls.Add(this.ui_deviceControl);
			this.ui_tabPageDevices.Location = new System.Drawing.Point(4, 24);
			this.ui_tabPageDevices.Name = "ui_tabPageDevices";
			this.ui_tabPageDevices.Padding = new System.Windows.Forms.Padding(3);
			this.ui_tabPageDevices.Size = new System.Drawing.Size(454, 152);
			this.ui_tabPageDevices.TabIndex = 1;
			this.ui_tabPageDevices.Text = "Devices";
			this.ui_tabPageDevices.UseVisualStyleBackColor = true;
			// 
			// ui_deviceControl
			// 
			this.ui_deviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ui_deviceControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_deviceControl.Location = new System.Drawing.Point(3, 3);
			this.ui_deviceControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_deviceControl.Name = "ui_deviceControl";
			this.ui_deviceControl.Size = new System.Drawing.Size(448, 146);
			this.ui_deviceControl.TabIndex = 0;
			// 
			// ui_tabPlaybackOptions
			// 
			this.ui_tabPlaybackOptions.Location = new System.Drawing.Point(4, 24);
			this.ui_tabPlaybackOptions.Name = "ui_tabPlaybackOptions";
			this.ui_tabPlaybackOptions.Padding = new System.Windows.Forms.Padding(3);
			this.ui_tabPlaybackOptions.Size = new System.Drawing.Size(454, 152);
			this.ui_tabPlaybackOptions.TabIndex = 2;
			this.ui_tabPlaybackOptions.Text = "Playback Options";
			this.ui_tabPlaybackOptions.UseVisualStyleBackColor = true;
			// 
			// ui_soundViewer
			// 
			this.ui_soundViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_soundViewer.BackColor = System.Drawing.SystemColors.Control;
			this.ui_soundViewer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_soundViewer.Location = new System.Drawing.Point(0, 21);
			this.ui_soundViewer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_soundViewer.Name = "ui_soundViewer";
			this.ui_soundViewer.Size = new System.Drawing.Size(462, 311);
			this.ui_soundViewer.SoundPlayer = null;
			this.ui_soundViewer.TabIndex = 4;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.ClientSize = new System.Drawing.Size(462, 519);
			this.Controls.Add(this.ui_tabControl);
			this.Controls.Add(this.ui_soundViewer);
			this.Controls.Add(this.GUI_MenuStrip);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.MainMenuStrip = this.GUI_MenuStrip;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Soundboard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EV_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.GUI_MenuStrip.ResumeLayout(false);
			this.GUI_MenuStrip.PerformLayout();
			this.ui_tabControl.ResumeLayout(false);
			this.ui_tabMediaControl.ResumeLayout(false);
			this.ui_tabPageDevices.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip GUI_MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ToolStripItem_Settings;
		private System.Windows.Forms.ToolStripMenuItem Menu_Help;
		private System.Windows.Forms.ToolStripMenuItem Menu_HowTo;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetSettings;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetDeviceSettings;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetAllSettings;
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetFiles;
		private GUI.SoundViewer ui_soundViewer;
		private System.Windows.Forms.TabControl ui_tabControl;
		private System.Windows.Forms.TabPage ui_tabMediaControl;
		private MediaControl ui_mediaControl;
		private System.Windows.Forms.TabPage ui_tabPageDevices;
		public GUI.DevicesSelector ui_deviceControl;
		private System.Windows.Forms.TabPage ui_tabPlaybackOptions;
	}
}

