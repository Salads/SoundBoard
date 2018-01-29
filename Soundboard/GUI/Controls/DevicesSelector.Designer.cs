namespace Soundboard.GUI
{
	partial class DevicesSelector
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ui_RecordingDeviceSelector = new Soundboard.GUI.SingleDeviceSelector();
			this.ui_PlaybackDevicesSelector = new Soundboard.GUI.Controls.Components.PlaybackDevicesSelector();
			this.colDevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// ui_RecordingDeviceSelector
			// 
			this.ui_RecordingDeviceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_RecordingDeviceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ui_RecordingDeviceSelector.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_RecordingDeviceSelector.FormattingEnabled = true;
			this.ui_RecordingDeviceSelector.Location = new System.Drawing.Point(3, 223);
			this.ui_RecordingDeviceSelector.Name = "ui_RecordingDeviceSelector";
			this.ui_RecordingDeviceSelector.Size = new System.Drawing.Size(399, 23);
			this.ui_RecordingDeviceSelector.TabIndex = 2;
			this.ui_RecordingDeviceSelector.TabStop = false;
			// 
			// ui_playbackDeviceListViewSelector
			// 
			this.ui_PlaybackDevicesSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_PlaybackDevicesSelector.CheckBoxes = true;
			this.ui_PlaybackDevicesSelector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDevice});
			this.ui_PlaybackDevicesSelector.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_PlaybackDevicesSelector.FullRowSelect = true;
			this.ui_PlaybackDevicesSelector.GridLines = true;
			this.ui_PlaybackDevicesSelector.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ui_PlaybackDevicesSelector.LabelWrap = false;
			this.ui_PlaybackDevicesSelector.Location = new System.Drawing.Point(3, 3);
			this.ui_PlaybackDevicesSelector.Name = "ui_playbackDeviceListViewSelector";
			this.ui_PlaybackDevicesSelector.Size = new System.Drawing.Size(399, 210);
			this.ui_PlaybackDevicesSelector.TabIndex = 1;
			this.ui_PlaybackDevicesSelector.TabStop = false;
			this.ui_PlaybackDevicesSelector.UseCompatibleStateImageBehavior = false;
			this.ui_PlaybackDevicesSelector.View = System.Windows.Forms.View.Details;
			// 
			// colDevice
			// 
			this.colDevice.Text = "Playback Devices";
			this.colDevice.Width = 378;
			// 
			// DevicesSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ui_RecordingDeviceSelector);
			this.Controls.Add(this.ui_PlaybackDevicesSelector);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "DevicesSelector";
			this.Size = new System.Drawing.Size(405, 255);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.Components.PlaybackDevicesSelector ui_PlaybackDevicesSelector;
		private SingleDeviceSelector ui_RecordingDeviceSelector;
		private System.Windows.Forms.ColumnHeader colDevice;
	}
}
