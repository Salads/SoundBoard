namespace Soundboard
{
	partial class DeviceSettingsWindow
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
			this.GUI_PlaybackDevices = new System.Windows.Forms.CheckedListBox();
			this.GUI_RecordingDevices = new System.Windows.Forms.ComboBox();
			this.Button_OK = new System.Windows.Forms.Button();
			this.GUI_LabelPlayback = new System.Windows.Forms.Label();
			this.GUI_LabelMicrophone = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// GUI_PlaybackDevices
			// 
			this.GUI_PlaybackDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GUI_PlaybackDevices.FormattingEnabled = true;
			this.GUI_PlaybackDevices.Location = new System.Drawing.Point(13, 33);
			this.GUI_PlaybackDevices.Name = "GUI_PlaybackDevices";
			this.GUI_PlaybackDevices.Size = new System.Drawing.Size(330, 204);
			this.GUI_PlaybackDevices.TabIndex = 0;
			// 
			// GUI_RecordingDevices
			// 
			this.GUI_RecordingDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GUI_RecordingDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.GUI_RecordingDevices.FormattingEnabled = true;
			this.GUI_RecordingDevices.Location = new System.Drawing.Point(12, 272);
			this.GUI_RecordingDevices.Name = "GUI_RecordingDevices";
			this.GUI_RecordingDevices.Size = new System.Drawing.Size(330, 25);
			this.GUI_RecordingDevices.TabIndex = 1;
			// 
			// Button_OK
			// 
			this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Button_OK.Location = new System.Drawing.Point(268, 312);
			this.Button_OK.Name = "Button_OK";
			this.Button_OK.Size = new System.Drawing.Size(75, 23);
			this.Button_OK.TabIndex = 2;
			this.Button_OK.TabStop = false;
			this.Button_OK.Text = "OK";
			this.Button_OK.UseVisualStyleBackColor = true;
			this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
			// 
			// GUI_LabelPlayback
			// 
			this.GUI_LabelPlayback.AutoSize = true;
			this.GUI_LabelPlayback.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GUI_LabelPlayback.Location = new System.Drawing.Point(10, 13);
			this.GUI_LabelPlayback.Name = "GUI_LabelPlayback";
			this.GUI_LabelPlayback.Size = new System.Drawing.Size(110, 17);
			this.GUI_LabelPlayback.TabIndex = 4;
			this.GUI_LabelPlayback.Text = "Playback Devices";
			// 
			// GUI_LabelMicrophone
			// 
			this.GUI_LabelMicrophone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GUI_LabelMicrophone.AutoSize = true;
			this.GUI_LabelMicrophone.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GUI_LabelMicrophone.Location = new System.Drawing.Point(12, 252);
			this.GUI_LabelMicrophone.Name = "GUI_LabelMicrophone";
			this.GUI_LabelMicrophone.Size = new System.Drawing.Size(112, 17);
			this.GUI_LabelMicrophone.TabIndex = 5;
			this.GUI_LabelMicrophone.Text = "Recording Device";
			// 
			// DeviceSettingsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 347);
			this.Controls.Add(this.GUI_LabelMicrophone);
			this.Controls.Add(this.GUI_LabelPlayback);
			this.Controls.Add(this.Button_OK);
			this.Controls.Add(this.GUI_RecordingDevices);
			this.Controls.Add(this.GUI_PlaybackDevices);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeviceSettingsWindow";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Device Settings";
			this.Load += new System.EventHandler(this.SettingsWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox GUI_PlaybackDevices;
		private System.Windows.Forms.ComboBox GUI_RecordingDevices;
		private System.Windows.Forms.Button Button_OK;
		private System.Windows.Forms.Label GUI_LabelPlayback;
		private System.Windows.Forms.Label GUI_LabelMicrophone;
	}
}