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
			this.ui_recordingDeviceSelector = new Soundboard.GUI.Controls.Components.RecordingDeviceSelector();
			this.ui_playbackDeviceSelector = new Soundboard.GUI.Controls.Components.PlaybackDeviceSelector();
			this.colDevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// ui_recordingDeviceSelector
			// 
			this.ui_recordingDeviceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_recordingDeviceSelector.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_recordingDeviceSelector.FormattingEnabled = true;
			this.ui_recordingDeviceSelector.Location = new System.Drawing.Point(3, 223);
			this.ui_recordingDeviceSelector.Name = "ui_recordingDeviceSelector";
			this.ui_recordingDeviceSelector.Size = new System.Drawing.Size(399, 23);
			this.ui_recordingDeviceSelector.TabIndex = 2;
			// 
			// ui_playbackDeviceSelector
			// 
			this.ui_playbackDeviceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_playbackDeviceSelector.CheckBoxes = true;
			this.ui_playbackDeviceSelector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDevice});
			this.ui_playbackDeviceSelector.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_playbackDeviceSelector.FullRowSelect = true;
			this.ui_playbackDeviceSelector.GridLines = true;
			this.ui_playbackDeviceSelector.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ui_playbackDeviceSelector.LabelWrap = false;
			this.ui_playbackDeviceSelector.Location = new System.Drawing.Point(3, 3);
			this.ui_playbackDeviceSelector.Name = "ui_playbackDeviceSelector";
			this.ui_playbackDeviceSelector.Size = new System.Drawing.Size(399, 210);
			this.ui_playbackDeviceSelector.TabIndex = 1;
			this.ui_playbackDeviceSelector.TabStop = false;
			this.ui_playbackDeviceSelector.UseCompatibleStateImageBehavior = false;
			this.ui_playbackDeviceSelector.View = System.Windows.Forms.View.Details;
			// 
			// colDevice
			// 
			this.colDevice.Text = "Devices";
			this.colDevice.Width = 100;
			// 
			// DevicesSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ui_recordingDeviceSelector);
			this.Controls.Add(this.ui_playbackDeviceSelector);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "DevicesSelector";
			this.Size = new System.Drawing.Size(405, 255);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.Components.PlaybackDeviceSelector ui_playbackDeviceSelector;
		private Controls.Components.RecordingDeviceSelector ui_recordingDeviceSelector;
		private System.Windows.Forms.ColumnHeader colDevice;
	}
}
