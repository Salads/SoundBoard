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
			this.GUI_PlayButton = new System.Windows.Forms.Button();
			this.GUI_StopButton = new System.Windows.Forms.Button();
			this.GUI_MuteMicCheckBox = new System.Windows.Forms.CheckBox();
			this.GUI_VolumeBar = new Soundboard.VolumeBar();
			this.GUI_SelectedSoundName = new System.Windows.Forms.Label();
			this.GUI_TackbarTest = new System.Windows.Forms.TrackBar();
			this.GUI_SlideTime = new System.Windows.Forms.Label();
			this.GUI_MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GUI_TackbarTest)).BeginInit();
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
			this.Menu_DeviceSettings.Click += new System.EventHandler(this.Menu_DeviceSettings_Click);
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
			this.Menu_ResetDeviceSettings.Click += new System.EventHandler(this.Menu_ResetDeviceSettings_Click);
			// 
			// Menu_ResetFiles
			// 
			this.Menu_ResetFiles.Name = "Menu_ResetFiles";
			this.Menu_ResetFiles.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetFiles.Text = "Reset Files";
			this.Menu_ResetFiles.Click += new System.EventHandler(this.Menu_ResetFiles_Click);
			// 
			// Menu_ResetAllSettings
			// 
			this.Menu_ResetAllSettings.Name = "Menu_ResetAllSettings";
			this.Menu_ResetAllSettings.Size = new System.Drawing.Size(185, 22);
			this.Menu_ResetAllSettings.Text = "Reset All Settings";
			this.Menu_ResetAllSettings.Click += new System.EventHandler(this.Menu_ResetAllSettings_Click);
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
			this.Menu_HowTo.Click += new System.EventHandler(this.Menu_HowTo_Click);
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
			this.GUI_SoundList.Size = new System.Drawing.Size(425, 270);
			this.GUI_SoundList.TabIndex = 1;
			this.GUI_SoundList.TabStop = false;
			this.GUI_SoundList.UseCompatibleStateImageBehavior = false;
			this.GUI_SoundList.View = System.Windows.Forms.View.Details;
			this.GUI_SoundList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.GUI_SoundList_ColumnWidthChanging);
			this.GUI_SoundList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.GUI_SoundList_DrawColumnHeader);
			this.GUI_SoundList.SelectedIndexChanged += new System.EventHandler(this.GUI_SoundList_SelectedIndexChanged);
			this.GUI_SoundList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GUI_SoundList_MouseDoubleClick);
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
			this.GUI_AddFileButton.Click += new System.EventHandler(this.GUI_AddFileButton_Click);
			// 
			// GUI_PlayButton
			// 
			this.GUI_PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GUI_PlayButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GUI_PlayButton.Location = new System.Drawing.Point(15, 450);
			this.GUI_PlayButton.Name = "GUI_PlayButton";
			this.GUI_PlayButton.Size = new System.Drawing.Size(25, 25);
			this.GUI_PlayButton.TabIndex = 3;
			this.GUI_PlayButton.Text = "Play";
			this.GUI_PlayButton.UseVisualStyleBackColor = true;
			this.GUI_PlayButton.Click += new System.EventHandler(this.GUI_PlayButton_Click);
			// 
			// GUI_StopButton
			// 
			this.GUI_StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GUI_StopButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GUI_StopButton.Location = new System.Drawing.Point(46, 450);
			this.GUI_StopButton.Name = "GUI_StopButton";
			this.GUI_StopButton.Size = new System.Drawing.Size(25, 25);
			this.GUI_StopButton.TabIndex = 4;
			this.GUI_StopButton.Text = "Stop";
			this.GUI_StopButton.UseVisualStyleBackColor = true;
			this.GUI_StopButton.Click += new System.EventHandler(this.GUI_StopButton_Click);
			// 
			// GUI_MuteMicCheckBox
			// 
			this.GUI_MuteMicCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GUI_MuteMicCheckBox.AutoSize = true;
			this.GUI_MuteMicCheckBox.Location = new System.Drawing.Point(12, 340);
			this.GUI_MuteMicCheckBox.Name = "GUI_MuteMicCheckBox";
			this.GUI_MuteMicCheckBox.Size = new System.Drawing.Size(160, 21);
			this.GUI_MuteMicCheckBox.TabIndex = 6;
			this.GUI_MuteMicCheckBox.Text = "Mute mic while playing";
			this.GUI_MuteMicCheckBox.UseVisualStyleBackColor = true;
			this.GUI_MuteMicCheckBox.CheckedChanged += new System.EventHandler(this.GUI_MuteMicCheckBox_CheckedChanged);
			// 
			// GUI_VolumeBar
			// 
			this.GUI_VolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GUI_VolumeBar.Location = new System.Drawing.Point(240, 397);
			this.GUI_VolumeBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.GUI_VolumeBar.Name = "GUI_VolumeBar";
			this.GUI_VolumeBar.Size = new System.Drawing.Size(197, 49);
			this.GUI_VolumeBar.TabIndex = 7;
			this.GUI_VolumeBar.Volume = ((uint)(50u));
			this.GUI_VolumeBar.VolumeChanged += new System.EventHandler(this.VolumeBar_ValueChanged);
			// 
			// GUI_SelectedSoundName
			// 
			this.GUI_SelectedSoundName.Location = new System.Drawing.Point(12, 364);
			this.GUI_SelectedSoundName.Name = "GUI_SelectedSoundName";
			this.GUI_SelectedSoundName.Size = new System.Drawing.Size(425, 29);
			this.GUI_SelectedSoundName.TabIndex = 8;
			this.GUI_SelectedSoundName.Text = "Nothing Selected";
			this.GUI_SelectedSoundName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GUI_TackbarTest
			// 
			this.GUI_TackbarTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GUI_TackbarTest.Location = new System.Drawing.Point(15, 399);
			this.GUI_TackbarTest.Maximum = 0;
			this.GUI_TackbarTest.Name = "GUI_TackbarTest";
			this.GUI_TackbarTest.Size = new System.Drawing.Size(219, 45);
			this.GUI_TackbarTest.TabIndex = 9;
			this.GUI_TackbarTest.TabStop = false;
			this.GUI_TackbarTest.TickStyle = System.Windows.Forms.TickStyle.None;
			this.GUI_TackbarTest.ValueChanged += new System.EventHandler(this.GUI_TackbarTest_ValueChanged);
			// 
			// GUI_SlideTime
			// 
			this.GUI_SlideTime.AutoSize = true;
			this.GUI_SlideTime.Location = new System.Drawing.Point(78, 454);
			this.GUI_SlideTime.Name = "GUI_SlideTime";
			this.GUI_SlideTime.Size = new System.Drawing.Size(61, 17);
			this.GUI_SlideTime.TabIndex = 10;
			this.GUI_SlideTime.Text = "0:00/0:00";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 505);
			this.Controls.Add(this.GUI_SlideTime);
			this.Controls.Add(this.GUI_TackbarTest);
			this.Controls.Add(this.GUI_SelectedSoundName);
			this.Controls.Add(this.GUI_VolumeBar);
			this.Controls.Add(this.GUI_MuteMicCheckBox);
			this.Controls.Add(this.GUI_StopButton);
			this.Controls.Add(this.GUI_PlayButton);
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Resize += new System.EventHandler(this.MainWindow_Resize);
			this.GUI_MenuStrip.ResumeLayout(false);
			this.GUI_MenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.GUI_TackbarTest)).EndInit();
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
		private System.Windows.Forms.Button GUI_PlayButton;
		private System.Windows.Forms.Button GUI_StopButton;
		private System.Windows.Forms.CheckBox GUI_MuteMicCheckBox;
		private VolumeBar GUI_VolumeBar;
		private System.Windows.Forms.Label GUI_SelectedSoundName;
		private System.Windows.Forms.TrackBar GUI_TackbarTest;
		private System.Windows.Forms.Label GUI_SlideTime;
	}
}

