namespace Soundboard.GUI
{
	partial class SoundViewer
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
			this.ui_soundList = new System.Windows.Forms.ListView();
			this.Header_Filenames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Header_Hotkey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ui_textboxSearch = new System.Windows.Forms.TextBox();
			this.ui_buttonAdd = new System.Windows.Forms.Button();
			this.ui_contextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ui_context_edit = new System.Windows.Forms.ToolStripMenuItem();
			this.ui_context_delete = new System.Windows.Forms.ToolStripMenuItem();
			this.ui_contextStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ui_soundList
			// 
			this.ui_soundList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.ui_soundList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ui_soundList.BackColor = System.Drawing.SystemColors.Window;
			this.ui_soundList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Header_Filenames,
            this.Header_Hotkey});
			this.ui_soundList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_soundList.FullRowSelect = true;
			this.ui_soundList.GridLines = true;
			this.ui_soundList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ui_soundList.HideSelection = false;
			this.ui_soundList.LabelWrap = false;
			this.ui_soundList.Location = new System.Drawing.Point(3, 38);
			this.ui_soundList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_soundList.MultiSelect = false;
			this.ui_soundList.Name = "ui_soundList";
			this.ui_soundList.ShowGroups = false;
			this.ui_soundList.Size = new System.Drawing.Size(465, 360);
			this.ui_soundList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ui_soundList.TabIndex = 2;
			this.ui_soundList.TabStop = false;
			this.ui_soundList.UseCompatibleStateImageBehavior = false;
			this.ui_soundList.View = System.Windows.Forms.View.Details;
			this.ui_soundList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SoundList_MouseClick);
			this.ui_soundList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EV_ListView_MouseDoubleClick);
			this.ui_soundList.Resize += new System.EventHandler(this.EV_SoundList_Resize);
			// 
			// Header_Filenames
			// 
			this.Header_Filenames.Text = "Files";
			this.Header_Filenames.Width = 37;
			// 
			// Header_Hotkey
			// 
			this.Header_Hotkey.Text = "Hotkeys";
			this.Header_Hotkey.Width = 424;
			// 
			// ui_textboxSearch
			// 
			this.ui_textboxSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_textboxSearch.Location = new System.Drawing.Point(3, 6);
			this.ui_textboxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_textboxSearch.MinimumSize = new System.Drawing.Size(186, 20);
			this.ui_textboxSearch.Name = "ui_textboxSearch";
			this.ui_textboxSearch.Size = new System.Drawing.Size(186, 23);
			this.ui_textboxSearch.TabIndex = 3;
			this.ui_textboxSearch.TabStop = false;
			this.ui_textboxSearch.WordWrap = false;
			this.ui_textboxSearch.TextChanged += new System.EventHandler(this.EV_Searchbox_TextChanged);
			// 
			// ui_buttonAdd
			// 
			this.ui_buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ui_buttonAdd.Location = new System.Drawing.Point(195, 6);
			this.ui_buttonAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ui_buttonAdd.MinimumSize = new System.Drawing.Size(83, 26);
			this.ui_buttonAdd.Name = "ui_buttonAdd";
			this.ui_buttonAdd.Size = new System.Drawing.Size(83, 26);
			this.ui_buttonAdd.TabIndex = 4;
			this.ui_buttonAdd.Text = "Add Sound";
			this.ui_buttonAdd.UseVisualStyleBackColor = true;
			this.ui_buttonAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EV_Button_AddSound_MouseClick);
			// 
			// ui_contextStrip
			// 
			this.ui_contextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_context_edit,
            this.ui_context_delete});
			this.ui_contextStrip.Name = "ui_contextStrip";
			this.ui_contextStrip.Size = new System.Drawing.Size(108, 48);
			// 
			// ui_context_edit
			// 
			this.ui_context_edit.Name = "ui_context_edit";
			this.ui_context_edit.Size = new System.Drawing.Size(107, 22);
			this.ui_context_edit.Text = "Edit";
			this.ui_context_edit.Click += new System.EventHandler(this.ui_context_edit_Click);
			// 
			// ui_context_delete
			// 
			this.ui_context_delete.Name = "ui_context_delete";
			this.ui_context_delete.Size = new System.Drawing.Size(107, 22);
			this.ui_context_delete.Text = "Delete";
			this.ui_context_delete.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// SoundViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ui_buttonAdd);
			this.Controls.Add(this.ui_textboxSearch);
			this.Controls.Add(this.ui_soundList);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SoundViewer";
			this.Size = new System.Drawing.Size(473, 402);
			this.ui_contextStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ColumnHeader Header_Filenames;
		private System.Windows.Forms.ColumnHeader Header_Hotkey;
		private System.Windows.Forms.TextBox ui_textboxSearch;
		private System.Windows.Forms.Button ui_buttonAdd;
		private System.Windows.Forms.ListView ui_soundList;
		private System.Windows.Forms.ContextMenuStrip ui_contextStrip;
		private System.Windows.Forms.ToolStripMenuItem ui_context_edit;
		private System.Windows.Forms.ToolStripMenuItem ui_context_delete;
	}
}
