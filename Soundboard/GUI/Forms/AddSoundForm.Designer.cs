namespace Soundboard.GUI
{
	partial class AddSoundForm
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
			this.ui_buttonBrowse = new System.Windows.Forms.Button();
			this.ui_labelFile = new System.Windows.Forms.Label();
			this.ui_textboxNickname = new System.Windows.Forms.TextBox();
			this.ui_labelNickname = new System.Windows.Forms.Label();
			this.ui_button_OK = new System.Windows.Forms.Button();
			this.ui_textbox_hotkey = new System.Windows.Forms.TextBox();
			this.ui_mediaControl = new Soundboard.MediaControl();
			this.SuspendLayout();
			// 
			// ui_buttonBrowse
			// 
			this.ui_buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_buttonBrowse.Location = new System.Drawing.Point(245, 14);
			this.ui_buttonBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_buttonBrowse.Name = "ui_buttonBrowse";
			this.ui_buttonBrowse.Size = new System.Drawing.Size(87, 26);
			this.ui_buttonBrowse.TabIndex = 0;
			this.ui_buttonBrowse.TabStop = false;
			this.ui_buttonBrowse.Text = "Browse";
			this.ui_buttonBrowse.UseVisualStyleBackColor = true;
			this.ui_buttonBrowse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_Browse_MouseClick);
			// 
			// ui_labelFile
			// 
			this.ui_labelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_labelFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ui_labelFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_labelFile.Location = new System.Drawing.Point(14, 14);
			this.ui_labelFile.Name = "ui_labelFile";
			this.ui_labelFile.Size = new System.Drawing.Size(218, 26);
			this.ui_labelFile.TabIndex = 1;
			this.ui_labelFile.Text = "No File Selected";
			this.ui_labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ui_textboxNickname
			// 
			this.ui_textboxNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_textboxNickname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_textboxNickname.Location = new System.Drawing.Point(10, 69);
			this.ui_textboxNickname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_textboxNickname.Name = "ui_textboxNickname";
			this.ui_textboxNickname.Size = new System.Drawing.Size(322, 23);
			this.ui_textboxNickname.TabIndex = 2;
			this.ui_textboxNickname.TabStop = false;
			// 
			// ui_labelNickname
			// 
			this.ui_labelNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_labelNickname.AutoSize = true;
			this.ui_labelNickname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_labelNickname.Location = new System.Drawing.Point(7, 50);
			this.ui_labelNickname.Name = "ui_labelNickname";
			this.ui_labelNickname.Size = new System.Drawing.Size(61, 15);
			this.ui_labelNickname.TabIndex = 3;
			this.ui_labelNickname.Text = "Nickname";
			// 
			// ui_button_OK
			// 
			this.ui_button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_button_OK.Location = new System.Drawing.Point(257, 331);
			this.ui_button_OK.Name = "ui_button_OK";
			this.ui_button_OK.Size = new System.Drawing.Size(75, 23);
			this.ui_button_OK.TabIndex = 5;
			this.ui_button_OK.Text = "OK";
			this.ui_button_OK.UseVisualStyleBackColor = true;
			this.ui_button_OK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_OK_MouseClick);
			// 
			// ui_textbox_hotkey
			// 
			this.ui_textbox_hotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_textbox_hotkey.Location = new System.Drawing.Point(10, 119);
			this.ui_textbox_hotkey.Name = "ui_textbox_hotkey";
			this.ui_textbox_hotkey.Size = new System.Drawing.Size(322, 23);
			this.ui_textbox_hotkey.TabIndex = 6;
			this.ui_textbox_hotkey.Click += new System.EventHandler(this.Textbox_Hotkey_Click);
			// 
			// ui_mediaControl
			// 
			this.ui_mediaControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_mediaControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_mediaControl.Location = new System.Drawing.Point(12, 149);
			this.ui_mediaControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_mediaControl.Name = "ui_mediaControl";
			this.ui_mediaControl.Size = new System.Drawing.Size(321, 176);
			this.ui_mediaControl.SoundPlayer = null;
			this.ui_mediaControl.TabIndex = 4;
			// 
			// AddSoundForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(340, 361);
			this.Controls.Add(this.ui_textbox_hotkey);
			this.Controls.Add(this.ui_button_OK);
			this.Controls.Add(this.ui_mediaControl);
			this.Controls.Add(this.ui_labelNickname);
			this.Controls.Add(this.ui_textboxNickname);
			this.Controls.Add(this.ui_labelFile);
			this.Controls.Add(this.ui_buttonBrowse);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "AddSoundForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Sound";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSoundForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ui_buttonBrowse;
		private System.Windows.Forms.Label ui_labelFile;
		private System.Windows.Forms.TextBox ui_textboxNickname;
		private System.Windows.Forms.Label ui_labelNickname;
		private MediaControl ui_mediaControl;
		private System.Windows.Forms.Button ui_button_OK;
		private System.Windows.Forms.TextBox ui_textbox_hotkey;
	}
}