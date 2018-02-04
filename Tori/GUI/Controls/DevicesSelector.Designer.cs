using Soundboard.GUI.Controls.Components;

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
            this.components = new System.ComponentModel.Container();
            this.ui_DataGridView = new Soundboard.GUI.Controls.Components.CDataGridView(this.components);
            this.ui_RecordingDeviceSelector = new Soundboard.GUI.SingleDeviceSelector();
            ((System.ComponentModel.ISupportInitialize)(this.ui_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_DataGridView
            // 
            this.ui_DataGridView.AllowUserToAddRows = false;
            this.ui_DataGridView.AllowUserToDeleteRows = false;
            this.ui_DataGridView.AllowUserToResizeColumns = false;
            this.ui_DataGridView.AllowUserToResizeRows = false;
            this.ui_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_DataGridView.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.ui_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ui_DataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.ui_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_DataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ui_DataGridView.Location = new System.Drawing.Point(4, 4);
            this.ui_DataGridView.MultiSelect = false;
            this.ui_DataGridView.Name = "ui_DataGridView";
            this.ui_DataGridView.RowHeadersVisible = false;
            this.ui_DataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ui_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_DataGridView.ShowCellErrors = false;
            this.ui_DataGridView.ShowEditingIcon = false;
            this.ui_DataGridView.ShowRowErrors = false;
            this.ui_DataGridView.Size = new System.Drawing.Size(398, 213);
            this.ui_DataGridView.TabIndex = 3;
            this.ui_DataGridView.TabStop = false;
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
            // DevicesSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_DataGridView);
            this.Controls.Add(this.ui_RecordingDeviceSelector);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DevicesSelector";
            this.Size = new System.Drawing.Size(405, 255);
            ((System.ComponentModel.ISupportInitialize)(this.ui_DataGridView)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private SingleDeviceSelector ui_RecordingDeviceSelector;
        private CDataGridView ui_DataGridView;
    }
}
