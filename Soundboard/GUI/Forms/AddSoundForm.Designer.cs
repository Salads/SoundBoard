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
			this.components = new System.ComponentModel.Container();
			this.ui_buttonBrowse = new System.Windows.Forms.Button();
			this.ui_labelFile = new System.Windows.Forms.Label();
			this.ui_textboxNickname = new System.Windows.Forms.TextBox();
			this.ui_labelNickname = new System.Windows.Forms.Label();
			this.ui_button_OK = new System.Windows.Forms.Button();
			this.ui_combobox_PreviewDevice = new System.Windows.Forms.ComboBox();
			this.ui_tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.ui_button_clearHotkey = new System.Windows.Forms.Button();
			this.ui_mediaControl = new Soundboard.MediaControl();
			this.ui_button_hotkey = new System.Windows.Forms.Button();
			this.ui_button_cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ui_buttonBrowse
			// 
			this.ui_buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_buttonBrowse.Location = new System.Drawing.Point(261, 14);
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
			this.ui_labelFile.Size = new System.Drawing.Size(236, 26);
			this.ui_labelFile.TabIndex = 1;
			this.ui_labelFile.Text = "No File Selected";
			this.ui_labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ui_labelFile.UseMnemonic = false;
			// 
			// ui_textboxNickname
			// 
			this.ui_textboxNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_textboxNickname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_textboxNickname.Location = new System.Drawing.Point(10, 69);
			this.ui_textboxNickname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_textboxNickname.Name = "ui_textboxNickname";
			this.ui_textboxNickname.Size = new System.Drawing.Size(338, 23);
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
			this.ui_button_OK.Location = new System.Drawing.Point(273, 357);
			this.ui_button_OK.Name = "ui_button_OK";
			this.ui_button_OK.Size = new System.Drawing.Size(75, 23);
			this.ui_button_OK.TabIndex = 5;
			this.ui_button_OK.Text = "OK";
			this.ui_button_OK.UseVisualStyleBackColor = true;
			this.ui_button_OK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_OK_MouseClick);
			// 
			// ui_combobox_PreviewDevice
			// 
			this.ui_combobox_PreviewDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_combobox_PreviewDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ui_combobox_PreviewDevice.FormattingEnabled = true;
			this.ui_combobox_PreviewDevice.Location = new System.Drawing.Point(10, 171);
			this.ui_combobox_PreviewDevice.Name = "ui_combobox_PreviewDevice";
			this.ui_combobox_PreviewDevice.Size = new System.Drawing.Size(338, 23);
			this.ui_combobox_PreviewDevice.TabIndex = 7;
			this.ui_combobox_PreviewDevice.TabStop = false;
			// 
			// ui_tooltip
			// 
			this.ui_tooltip.AutoPopDelay = 5000;
			this.ui_tooltip.InitialDelay = 100;
			this.ui_tooltip.ReshowDelay = 100;
			// 
			// ui_button_clearHotkey
			// 
			this.ui_button_clearHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_button_clearHotkey.Location = new System.Drawing.Point(261, 119);
			this.ui_button_clearHotkey.Name = "ui_button_clearHotkey";
			this.ui_button_clearHotkey.Size = new System.Drawing.Size(83, 23);
			this.ui_button_clearHotkey.TabIndex = 8;
			this.ui_button_clearHotkey.Text = "Clear";
			this.ui_button_clearHotkey.UseVisualStyleBackColor = true;
			this.ui_button_clearHotkey.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_button_clearHotkey_MouseClick);
			// 
			// ui_mediaControl
			// 
			this.ui_mediaControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_mediaControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_mediaControl.Location = new System.Drawing.Point(-1, 201);
			this.ui_mediaControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_mediaControl.Name = "ui_mediaControl";
			this.ui_mediaControl.ShowName = true;
			this.ui_mediaControl.Size = new System.Drawing.Size(349, 155);
			this.ui_mediaControl.SoundPlayer = null;
			this.ui_mediaControl.TabIndex = 4;
			// 
			// ui_button_hotkey
			// 
			this.ui_button_hotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_button_hotkey.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ui_button_hotkey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
			this.ui_button_hotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ui_button_hotkey.Location = new System.Drawing.Point(10, 118);
			this.ui_button_hotkey.Name = "ui_button_hotkey";
			this.ui_button_hotkey.Size = new System.Drawing.Size(240, 25);
			this.ui_button_hotkey.TabIndex = 9;
			this.ui_button_hotkey.TabStop = false;
			this.ui_button_hotkey.Text = "No Hotkey Set (Click To Set)";
			this.ui_button_hotkey.UseMnemonic = false;
			this.ui_button_hotkey.UseVisualStyleBackColor = false;
			// 
			// ui_button_cancel
			// 
			this.ui_button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_button_cancel.Location = new System.Drawing.Point(192, 357);
			this.ui_button_cancel.Name = "ui_button_cancel";
			this.ui_button_cancel.Size = new System.Drawing.Size(75, 23);
			this.ui_button_cancel.TabIndex = 10;
			this.ui_button_cancel.Text = "Cancel";
			this.ui_button_cancel.UseVisualStyleBackColor = true;
			this.ui_button_cancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_button_cancel_MouseClick);
			// 
			// AddSoundForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 392);
			this.Controls.Add(this.ui_button_cancel);
			this.Controls.Add(this.ui_button_hotkey);
			this.Controls.Add(this.ui_button_clearHotkey);
			this.Controls.Add(this.ui_combobox_PreviewDevice);
			this.Controls.Add(this.ui_button_OK);
			this.Controls.Add(this.ui_mediaControl);
			this.Controls.Add(this.ui_labelNickname);
			this.Controls.Add(this.ui_textboxNickname);
			this.Controls.Add(this.ui_labelFile);
			this.Controls.Add(this.ui_buttonBrowse);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MinimumSize = new System.Drawing.Size(16, 431);
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
		private System.Windows.Forms.ComboBox ui_combobox_PreviewDevice;
		private System.Windows.Forms.ToolTip ui_tooltip;
		private System.Windows.Forms.Button ui_button_clearHotkey;
		private System.Windows.Forms.Button ui_button_hotkey;
		private System.Windows.Forms.Button ui_button_cancel;
	}
}