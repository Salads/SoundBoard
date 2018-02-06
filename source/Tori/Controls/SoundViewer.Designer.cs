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
            this.ui_buttonAdd = new System.Windows.Forms.Button();
            this.ui_contextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_context_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_context_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_DataGridView_Sounds = new Soundboard.GUI.Controls.Components.CDataGridView(this.components);
            this.ui_textboxSearch = new Soundboard.GUI.Controls.Components.CTextBox();
            this.ui_contextStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_DataGridView_Sounds)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_buttonAdd
            // 
            this.ui_buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_buttonAdd.Location = new System.Drawing.Point(195, 5);
            this.ui_buttonAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ui_buttonAdd.MinimumSize = new System.Drawing.Size(83, 25);
            this.ui_buttonAdd.Name = "ui_buttonAdd";
            this.ui_buttonAdd.Size = new System.Drawing.Size(83, 25);
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
            this.ui_contextStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // ui_context_edit
            // 
            this.ui_context_edit.Name = "ui_context_edit";
            this.ui_context_edit.Size = new System.Drawing.Size(152, 22);
            this.ui_context_edit.Text = "Edit";
            this.ui_context_edit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EV_ToolStripEdit_MouseDown);
            // 
            // ui_context_delete
            // 
            this.ui_context_delete.Name = "ui_context_delete";
            this.ui_context_delete.Size = new System.Drawing.Size(152, 22);
            this.ui_context_delete.Text = "Delete";
            this.ui_context_delete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EV_ToolStripDelete_MouseDown);
            // 
            // ui_DataGridView_Sounds
            // 
            this.ui_DataGridView_Sounds.AllowUserToAddRows = false;
            this.ui_DataGridView_Sounds.AllowUserToResizeColumns = false;
            this.ui_DataGridView_Sounds.AllowUserToResizeRows = false;
            this.ui_DataGridView_Sounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_DataGridView_Sounds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_DataGridView_Sounds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ui_DataGridView_Sounds.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ui_DataGridView_Sounds.Location = new System.Drawing.Point(4, 37);
            this.ui_DataGridView_Sounds.MultiSelect = false;
            this.ui_DataGridView_Sounds.Name = "ui_DataGridView_Sounds";
            this.ui_DataGridView_Sounds.ReadOnly = true;
            this.ui_DataGridView_Sounds.RowHeadersVisible = false;
            this.ui_DataGridView_Sounds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ui_DataGridView_Sounds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_DataGridView_Sounds.Size = new System.Drawing.Size(466, 362);
            this.ui_DataGridView_Sounds.TabIndex = 5;
            this.ui_DataGridView_Sounds.TabStop = false;
            // 
            // ui_textboxSearch
            // 
            this.ui_textboxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ui_textboxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.ui_textboxSearch.BannerText = "Search...";
            this.ui_textboxSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_textboxSearch.Location = new System.Drawing.Point(3, 6);
            this.ui_textboxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ui_textboxSearch.MinimumSize = new System.Drawing.Size(186, 20);
            this.ui_textboxSearch.Name = "ui_textboxSearch";
            this.ui_textboxSearch.Size = new System.Drawing.Size(186, 23);
            this.ui_textboxSearch.TabIndex = 3;
            this.ui_textboxSearch.TabStop = false;
            this.ui_textboxSearch.WordWrap = false;
            this.ui_textboxSearch.TextChanged += new System.EventHandler(this.EV_TextboxSearch_TextChanged);
            // 
            // SoundViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ui_DataGridView_Sounds);
            this.Controls.Add(this.ui_buttonAdd);
            this.Controls.Add(this.ui_textboxSearch);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SoundViewer";
            this.Size = new System.Drawing.Size(473, 402);
            this.ui_contextStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_DataGridView_Sounds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private Soundboard.GUI.Controls.Components.CTextBox ui_textboxSearch;
		private System.Windows.Forms.Button ui_buttonAdd;
		private System.Windows.Forms.ContextMenuStrip ui_contextStrip;
		private System.Windows.Forms.ToolStripMenuItem ui_context_edit;
		private System.Windows.Forms.ToolStripMenuItem ui_context_delete;
        private Controls.Components.CDataGridView ui_DataGridView_Sounds;
    }
}
