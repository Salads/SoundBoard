namespace Soundboard.GUI.Controls
{
	partial class PlaybackOptionsControl
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
			this.ui_checkbox_MuteWhilePlaying = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// ui_checkbox_MuteWhilePlaying
			// 
			this.ui_checkbox_MuteWhilePlaying.AutoSize = true;
			this.ui_checkbox_MuteWhilePlaying.Location = new System.Drawing.Point(5, 5);
			this.ui_checkbox_MuteWhilePlaying.Name = "ui_checkbox_MuteWhilePlaying";
			this.ui_checkbox_MuteWhilePlaying.Size = new System.Drawing.Size(197, 19);
			this.ui_checkbox_MuteWhilePlaying.TabIndex = 0;
			this.ui_checkbox_MuteWhilePlaying.Text = "Mute Microphone While Playing";
			this.ui_checkbox_MuteWhilePlaying.UseVisualStyleBackColor = true;
			this.ui_checkbox_MuteWhilePlaying.CheckedChanged += new System.EventHandler(this.MuteWhilePlaying_CheckedChanged);
			// 
			// PlaybackOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ui_checkbox_MuteWhilePlaying);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "PlaybackOptions";
			this.Size = new System.Drawing.Size(342, 96);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox ui_checkbox_MuteWhilePlaying;
	}
}
