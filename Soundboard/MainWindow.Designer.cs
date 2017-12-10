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
			this.Menu_DeviceSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetDeviceSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_ResetAllSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Help = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_HowTo = new System.Windows.Forms.ToolStripMenuItem();
			this.GUI_SoundList = new System.Windows.Forms.ListView();
			this.Header_Filenames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Header_Hotkey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.GUI_AddFileButton = new System.Windows.Forms.Button();
			this.ui_soundPanel = new Soundboard.SoundControl();
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
			this.GUI_MenuStrip.Size = new System.Drawing.Size(449, 24);
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
			// Menu_DeviceSettings
			// 
			this.Menu_DeviceSettings.Name = "Menu_DeviceSettings";
			this.Menu_DeviceSettings.Size = new System.Drawing.Size(154, 22);
			this.Menu_DeviceSettings.Text = "Device Settings";
			this.Menu_DeviceSettings.Click += new System.EventHandler(this.EV_Menu_DeviceSettings_Clicked);
			// 
			// Menu_ResetSettings
			// 
			this.Menu_ResetSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ResetDeviceSettings,
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
			// GUI_SoundList
			// 
			this.GUI_SoundList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.GUI_SoundList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GUI_SoundList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Header_Filenames,
            this.Header_Hotkey});
			this.GUI_SoundList.FullRowSelect = true;
			this.GUI_SoundList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.GUI_SoundList.LabelWrap = false;
			this.GUI_SoundList.Location = new System.Drawing.Point(12, 64);
			this.GUI_SoundList.MultiSelect = false;
			this.GUI_SoundList.Name = "GUI_SoundList";
			this.GUI_SoundList.ShowGroups = false;
			this.GUI_SoundList.Size = new System.Drawing.Size(425, 309);
			this.GUI_SoundList.TabIndex = 1;
			this.GUI_SoundList.TabStop = false;
			this.GUI_SoundList.UseCompatibleStateImageBehavior = false;
			this.GUI_SoundList.View = System.Windows.Forms.View.Details;
			this.GUI_SoundList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.EV_SoundList_SizeChanging);
			this.GUI_SoundList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.EV_SoundList_OnDrawHeader);
			this.GUI_SoundList.SelectedIndexChanged += new System.EventHandler(this.EV_SelectedSoundIndexChanged);
			this.GUI_SoundList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EV_SoundDoubleClicked);
			// 
			// Header_Filenames
			// 
			this.Header_Filenames.Text = "Files";
			this.Header_Filenames.Width = 300;
			// 
			// Header_Hotkey
			// 
			this.Header_Hotkey.Text = "Hotkeys";
			this.Header_Hotkey.Width = 121;
			// 
			// GUI_AddFileButton
			// 
			this.GUI_AddFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GUI_AddFileButton.Location = new System.Drawing.Point(12, 35);
			this.GUI_AddFileButton.Name = "GUI_AddFileButton";
			this.GUI_AddFileButton.Size = new System.Drawing.Size(75, 23);
			this.GUI_AddFileButton.TabIndex = 2;
			this.GUI_AddFileButton.Text = "Add File";
			this.GUI_AddFileButton.UseVisualStyleBackColor = true;
			this.GUI_AddFileButton.Click += new System.EventHandler(this.EV_AddFile_Clicked);
			// 
			// ui_soundPanel
			// 
			this.ui_soundPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_soundPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_soundPanel.Location = new System.Drawing.Point(12, 380);
			this.ui_soundPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_soundPanel.Name = "ui_soundPanel";
			this.ui_soundPanel.SelectedSounds = null;
			this.ui_soundPanel.Size = new System.Drawing.Size(425, 160);
			this.ui_soundPanel.TabIndex = 3;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 553);
			this.Controls.Add(this.ui_soundPanel);
			this.Controls.Add(this.GUI_AddFileButton);
			this.Controls.Add(this.GUI_SoundList);
			this.Controls.Add(this.GUI_MenuStrip);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.MainMenuStrip = this.GUI_MenuStrip;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Soundboard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EV_FormClosing);
			this.Resize += new System.EventHandler(this.EV_MainWindow_OnResize);
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
		private System.Windows.Forms.ToolStripMenuItem Menu_ResetFiles;
		private System.Windows.Forms.ListView GUI_SoundList;
		private System.Windows.Forms.ColumnHeader Header_Filenames;
		private System.Windows.Forms.ColumnHeader Header_Hotkey;
		private System.Windows.Forms.Button GUI_AddFileButton;
		private SoundControl ui_soundPanel;
	}
}

