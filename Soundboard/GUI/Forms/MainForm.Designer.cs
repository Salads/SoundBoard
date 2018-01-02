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
			this.ui_tabSoundControl = new System.Windows.Forms.TabPage();
			this.ui_mediaControl = new Soundboard.MediaControl();
			this.ui_tabPageDevices = new System.Windows.Forms.TabPage();
			this.ui_deviceControl = new Soundboard.GUI.DevicesSelector();
			this.ui_soundList = new Soundboard.GUI.SoundList();
			this.GUI_MenuStrip.SuspendLayout();
			this.ui_tabControl.SuspendLayout();
			this.ui_tabSoundControl.SuspendLayout();
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
			this.GUI_MenuStrip.Size = new System.Drawing.Size(466, 24);
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
			this.Menu_ResetSettings.Size = new System.Drawing.Size(147, 22);
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
			this.ui_tabControl.Controls.Add(this.ui_tabSoundControl);
			this.ui_tabControl.Controls.Add(this.ui_tabPageDevices);
			this.ui_tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ui_tabControl.HotTrack = true;
			this.ui_tabControl.Location = new System.Drawing.Point(0, 344);
			this.ui_tabControl.Name = "ui_tabControl";
			this.ui_tabControl.SelectedIndex = 0;
			this.ui_tabControl.Size = new System.Drawing.Size(466, 207);
			this.ui_tabControl.TabIndex = 5;
			this.ui_tabControl.TabStop = false;
			// 
			// ui_tabSoundControl
			// 
			this.ui_tabSoundControl.BackColor = System.Drawing.SystemColors.Control;
			this.ui_tabSoundControl.Controls.Add(this.ui_mediaControl);
			this.ui_tabSoundControl.Location = new System.Drawing.Point(4, 24);
			this.ui_tabSoundControl.Name = "ui_tabSoundControl";
			this.ui_tabSoundControl.Padding = new System.Windows.Forms.Padding(3);
			this.ui_tabSoundControl.Size = new System.Drawing.Size(458, 179);
			this.ui_tabSoundControl.TabIndex = 0;
			this.ui_tabSoundControl.Text = "Manual Sound";
			// 
			// ui_soundControl
			// 
			this.ui_mediaControl.BackColor = System.Drawing.SystemColors.Control;
			this.ui_mediaControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ui_mediaControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_mediaControl.Location = new System.Drawing.Point(3, 3);
			this.ui_mediaControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_mediaControl.Name = "ui_soundControl";
			this.ui_mediaControl.Size = new System.Drawing.Size(452, 173);
			this.ui_mediaControl.TabIndex = 0;
			// 
			// ui_tabPageDevices
			// 
			this.ui_tabPageDevices.Controls.Add(this.ui_deviceControl);
			this.ui_tabPageDevices.Location = new System.Drawing.Point(4, 24);
			this.ui_tabPageDevices.Name = "ui_tabPageDevices";
			this.ui_tabPageDevices.Padding = new System.Windows.Forms.Padding(3);
			this.ui_tabPageDevices.Size = new System.Drawing.Size(458, 179);
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
			this.ui_deviceControl.Size = new System.Drawing.Size(452, 173);
			this.ui_deviceControl.TabIndex = 0;
			// 
			// ui_soundBank
			// 
			this.ui_soundList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_soundList.BackColor = System.Drawing.SystemColors.Control;
			this.ui_soundList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_soundList.Location = new System.Drawing.Point(0, 21);
			this.ui_soundList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_soundList.Name = "ui_soundBank";
			this.ui_soundList.Size = new System.Drawing.Size(466, 316);
			this.ui_soundList.TabIndex = 4;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(466, 551);
			this.Controls.Add(this.ui_tabControl);
			this.Controls.Add(this.ui_soundList);
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
			this.GUI_MenuStrip.ResumeLayout(false);
			this.GUI_MenuStrip.PerformLayout();
			this.ui_tabControl.ResumeLayout(false);
			this.ui_tabSoundControl.ResumeLayout(false);
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
		private GUI.SoundList ui_soundList;
		private System.Windows.Forms.TabControl ui_tabControl;
		private System.Windows.Forms.TabPage ui_tabSoundControl;
		private MediaControl ui_mediaControl;
		private System.Windows.Forms.TabPage ui_tabPageDevices;
		public GUI.DevicesSelector ui_deviceControl;
	}
}

