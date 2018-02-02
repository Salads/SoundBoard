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
			this.ui_checkbox_MuteMicWhilePlaying = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// ui_checkbox_MuteMicWhilePlaying
			// 
			this.ui_checkbox_MuteMicWhilePlaying.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_checkbox_MuteMicWhilePlaying.AutoSize = true;
			this.ui_checkbox_MuteMicWhilePlaying.Location = new System.Drawing.Point(5, 5);
			this.ui_checkbox_MuteMicWhilePlaying.Name = "ui_checkbox_MuteMicWhilePlaying";
			this.ui_checkbox_MuteMicWhilePlaying.Size = new System.Drawing.Size(197, 19);
			this.ui_checkbox_MuteMicWhilePlaying.TabIndex = 0;
			this.ui_checkbox_MuteMicWhilePlaying.TabStop = false;
			this.ui_checkbox_MuteMicWhilePlaying.Text = "Mute Microphone While Playing";
			this.ui_checkbox_MuteMicWhilePlaying.UseVisualStyleBackColor = true;
			// 
			// PlaybackOptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ui_checkbox_MuteMicWhilePlaying);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "PlaybackOptionsControl";
			this.Size = new System.Drawing.Size(342, 96);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox ui_checkbox_MuteMicWhilePlaying;
	}
}
