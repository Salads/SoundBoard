namespace Soundboard
{
	public partial class MediaControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaControl));
			this.ui_play = new System.Windows.Forms.Button();
			this.ui_stop = new System.Windows.Forms.Button();
			this.ui_timeLabel = new System.Windows.Forms.Label();
			this.ui_trackBar = new System.Windows.Forms.TrackBar();
			this.ui_selectedSoundLabel = new System.Windows.Forms.Label();
			this.ui_volumeBar = new Soundboard.VolumeBar();
			((System.ComponentModel.ISupportInitialize)(this.ui_trackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// ui_play
			// 
			this.ui_play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ui_play.BackColor = System.Drawing.Color.Transparent;
			this.ui_play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ui_play.BackgroundImage")));
			this.ui_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ui_play.FlatAppearance.BorderSize = 0;
			this.ui_play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ui_play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
			this.ui_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ui_play.Location = new System.Drawing.Point(3, 122);
			this.ui_play.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_play.MaximumSize = new System.Drawing.Size(23, 20);
			this.ui_play.Name = "ui_play";
			this.ui_play.Size = new System.Drawing.Size(23, 20);
			this.ui_play.TabIndex = 1;
			this.ui_play.TabStop = false;
			this.ui_play.UseMnemonic = false;
			this.ui_play.UseVisualStyleBackColor = false;
			this.ui_play.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_PlayClicked);
			// 
			// ui_stop
			// 
			this.ui_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ui_stop.BackColor = System.Drawing.Color.Transparent;
			this.ui_stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ui_stop.BackgroundImage")));
			this.ui_stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ui_stop.FlatAppearance.BorderSize = 0;
			this.ui_stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.ui_stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
			this.ui_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ui_stop.Location = new System.Drawing.Point(32, 123);
			this.ui_stop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_stop.MaximumSize = new System.Drawing.Size(23, 20);
			this.ui_stop.Name = "ui_stop";
			this.ui_stop.Size = new System.Drawing.Size(23, 20);
			this.ui_stop.TabIndex = 2;
			this.ui_stop.TabStop = false;
			this.ui_stop.UseVisualStyleBackColor = false;
			this.ui_stop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_StopClicked);
			// 
			// ui_timeLabel
			// 
			this.ui_timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_timeLabel.Location = new System.Drawing.Point(8, 32);
			this.ui_timeLabel.Name = "ui_timeLabel";
			this.ui_timeLabel.Size = new System.Drawing.Size(447, 15);
			this.ui_timeLabel.TabIndex = 3;
			this.ui_timeLabel.Text = "0:00/0:00";
			// 
			// ui_trackBar
			// 
			this.ui_trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_trackBar.Location = new System.Drawing.Point(3, 50);
			this.ui_trackBar.Maximum = 0;
			this.ui_trackBar.Name = "ui_trackBar";
			this.ui_trackBar.Size = new System.Drawing.Size(453, 45);
			this.ui_trackBar.TabIndex = 4;
			this.ui_trackBar.TabStop = false;
			this.ui_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.ui_trackBar.ValueChanged += new System.EventHandler(this.EV_SliderChanged);
			// 
			// ui_selectedSoundLabel
			// 
			this.ui_selectedSoundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_selectedSoundLabel.AutoSize = true;
			this.ui_selectedSoundLabel.Location = new System.Drawing.Point(8, 6);
			this.ui_selectedSoundLabel.Name = "ui_selectedSoundLabel";
			this.ui_selectedSoundLabel.Size = new System.Drawing.Size(107, 15);
			this.ui_selectedSoundLabel.TabIndex = 6;
			this.ui_selectedSoundLabel.Text = "Nothing Selected...";
			// 
			// ui_volumeBar
			// 
			this.ui_volumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_volumeBar.Location = new System.Drawing.Point(166, 101);
			this.ui_volumeBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_volumeBar.Name = "ui_volumeBar";
			this.ui_volumeBar.Size = new System.Drawing.Size(291, 38);
			this.ui_volumeBar.TabIndex = 0;
			this.ui_volumeBar.Volume = ((uint)(20u));
			// 
			// MediaControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ui_selectedSoundLabel);
			this.Controls.Add(this.ui_trackBar);
			this.Controls.Add(this.ui_timeLabel);
			this.Controls.Add(this.ui_stop);
			this.Controls.Add(this.ui_play);
			this.Controls.Add(this.ui_volumeBar);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MediaControl";
			this.Size = new System.Drawing.Size(460, 146);
			((System.ComponentModel.ISupportInitialize)(this.ui_trackBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private VolumeBar ui_volumeBar;
		private System.Windows.Forms.Button ui_play;
		private System.Windows.Forms.Button ui_stop;
		private System.Windows.Forms.Label ui_timeLabel;
		private System.Windows.Forms.TrackBar ui_trackBar;
		private System.Windows.Forms.Label ui_selectedSoundLabel;
	}
}
