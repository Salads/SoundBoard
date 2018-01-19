namespace Soundboard.GUI
{
	partial class NewSoundForm
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
            this.ui_label_filename = new System.Windows.Forms.Label();
            this.ui_textbox_nickname = new System.Windows.Forms.TextBox();
            this.ui_labelNickname = new System.Windows.Forms.Label();
            this.ui_button_OK = new System.Windows.Forms.Button();
            this.ui_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ui_button_ClearHotkey = new System.Windows.Forms.Button();
            this.ui_button_Hotkey = new System.Windows.Forms.Button();
            this.ui_button_cancel = new System.Windows.Forms.Button();
            this.ui_PreviewDeviceSelector = new Soundboard.GUI.Controls.Components.SingleDeviceSelector();
            this.ui_mediaControl = new Soundboard.MediaControl();
            this.SuspendLayout();
            // 
            // ui_buttonBrowse
            // 
            this.ui_buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_buttonBrowse.Location = new System.Drawing.Point(249, 14);
            this.ui_buttonBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ui_buttonBrowse.Name = "ui_buttonBrowse";
            this.ui_buttonBrowse.Size = new System.Drawing.Size(87, 26);
            this.ui_buttonBrowse.TabIndex = 0;
            this.ui_buttonBrowse.TabStop = false;
            this.ui_buttonBrowse.Text = "Browse";
            this.ui_buttonBrowse.UseVisualStyleBackColor = true;
            this.ui_buttonBrowse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_Browse_MouseClick);
            // 
            // ui_label_filename
            // 
            this.ui_label_filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_label_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_label_filename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_label_filename.Location = new System.Drawing.Point(10, 14);
            this.ui_label_filename.Name = "ui_label_filename";
            this.ui_label_filename.Size = new System.Drawing.Size(237, 26);
            this.ui_label_filename.TabIndex = 1;
            this.ui_label_filename.Text = "No File Selected";
            this.ui_label_filename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ui_label_filename.UseMnemonic = false;
            // 
            // ui_textbox_nickname
            // 
            this.ui_textbox_nickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_textbox_nickname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_textbox_nickname.Location = new System.Drawing.Point(10, 69);
            this.ui_textbox_nickname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ui_textbox_nickname.Name = "ui_textbox_nickname";
            this.ui_textbox_nickname.Size = new System.Drawing.Size(326, 23);
            this.ui_textbox_nickname.TabIndex = 2;
            this.ui_textbox_nickname.TabStop = false;
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
            this.ui_button_OK.Location = new System.Drawing.Point(261, 366);
            this.ui_button_OK.Name = "ui_button_OK";
            this.ui_button_OK.Size = new System.Drawing.Size(75, 23);
            this.ui_button_OK.TabIndex = 5;
            this.ui_button_OK.Text = "OK";
            this.ui_button_OK.UseVisualStyleBackColor = true;
            this.ui_button_OK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_OK_MouseClick);
            // 
            // ui_tooltip
            // 
            this.ui_tooltip.AutoPopDelay = 5000;
            this.ui_tooltip.InitialDelay = 100;
            this.ui_tooltip.ReshowDelay = 100;
            // 
            // ui_button_ClearHotkey
            // 
            this.ui_button_ClearHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_button_ClearHotkey.Location = new System.Drawing.Point(253, 119);
            this.ui_button_ClearHotkey.Name = "ui_button_ClearHotkey";
            this.ui_button_ClearHotkey.Size = new System.Drawing.Size(83, 23);
            this.ui_button_ClearHotkey.TabIndex = 8;
            this.ui_button_ClearHotkey.Text = "Clear";
            this.ui_button_ClearHotkey.UseVisualStyleBackColor = true;
            this.ui_button_ClearHotkey.Click += new System.EventHandler(this.EV_Button_ClearHotkey_Click);
            // 
            // ui_button_Hotkey
            // 
            this.ui_button_Hotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_button_Hotkey.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ui_button_Hotkey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.ui_button_Hotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ui_button_Hotkey.Location = new System.Drawing.Point(10, 118);
            this.ui_button_Hotkey.Name = "ui_button_Hotkey";
            this.ui_button_Hotkey.Size = new System.Drawing.Size(237, 25);
            this.ui_button_Hotkey.TabIndex = 9;
            this.ui_button_Hotkey.TabStop = false;
            this.ui_button_Hotkey.Text = "No Hotkey Set (Click To Set)";
            this.ui_button_Hotkey.UseMnemonic = false;
            this.ui_button_Hotkey.UseVisualStyleBackColor = false;
            // 
            // ui_button_cancel
            // 
            this.ui_button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_button_cancel.Location = new System.Drawing.Point(180, 366);
            this.ui_button_cancel.Name = "ui_button_cancel";
            this.ui_button_cancel.Size = new System.Drawing.Size(75, 23);
            this.ui_button_cancel.TabIndex = 10;
            this.ui_button_cancel.Text = "Cancel";
            this.ui_button_cancel.UseVisualStyleBackColor = true;
            this.ui_button_cancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_Button_Cancel_MouseClick);
            // 
            // ui_PreviewDeviceSelector
            // 
            this.ui_PreviewDeviceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_PreviewDeviceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_PreviewDeviceSelector.FormattingEnabled = true;
            this.ui_PreviewDeviceSelector.Location = new System.Drawing.Point(10, 173);
            this.ui_PreviewDeviceSelector.Name = "ui_PreviewDeviceSelector";
            this.ui_PreviewDeviceSelector.Size = new System.Drawing.Size(326, 23);
            this.ui_PreviewDeviceSelector.TabIndex = 11;
            this.ui_PreviewDeviceSelector.TabStop = false;
            // 
            // ui_mediaControl
            // 
            this.ui_mediaControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_mediaControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_mediaControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_mediaControl.Location = new System.Drawing.Point(10, 203);
            this.ui_mediaControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ui_mediaControl.Name = "ui_mediaControl";
            this.ui_mediaControl.ShowName = false;
            this.ui_mediaControl.Size = new System.Drawing.Size(326, 153);
            this.ui_mediaControl.SoundPlayer = null;
            this.ui_mediaControl.TabIndex = 4;
            this.ui_mediaControl.UsePreviewDevice = false;
            // 
            // NewSoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 401);
            this.Controls.Add(this.ui_PreviewDeviceSelector);
            this.Controls.Add(this.ui_button_cancel);
            this.Controls.Add(this.ui_button_Hotkey);
            this.Controls.Add(this.ui_button_ClearHotkey);
            this.Controls.Add(this.ui_button_OK);
            this.Controls.Add(this.ui_mediaControl);
            this.Controls.Add(this.ui_labelNickname);
            this.Controls.Add(this.ui_textbox_nickname);
            this.Controls.Add(this.ui_label_filename);
            this.Controls.Add(this.ui_buttonBrowse);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(360, 440);
            this.Name = "NewSoundForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Sound";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EV_AddSoundForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ui_buttonBrowse;
		private System.Windows.Forms.Label ui_label_filename;
		private System.Windows.Forms.TextBox ui_textbox_nickname;
		private System.Windows.Forms.Label ui_labelNickname;
		private MediaControl ui_mediaControl;
		private System.Windows.Forms.Button ui_button_OK;
		private System.Windows.Forms.ToolTip ui_tooltip;
		private System.Windows.Forms.Button ui_button_ClearHotkey;
		private System.Windows.Forms.Button ui_button_Hotkey;
		private System.Windows.Forms.Button ui_button_cancel;
		private Controls.Components.SingleDeviceSelector ui_PreviewDeviceSelector;
	}
}