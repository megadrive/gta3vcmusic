namespace gta3vcMusic
{
    partial class GTA3VCMusic
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
            if (disposing && (components != null))
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
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblDropHelp = new System.Windows.Forms.Label();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnCreateSymLinks = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderDialog
            // 
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(15, 63);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(483, 184);
            this.lstFiles.TabIndex = 3;
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(12, 12);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(322, 20);
            this.txtFolderPath.TabIndex = 4;
            this.txtFolderPath.Text = "Path to GTA3 or VC\'s mp3 folder";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(340, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(78, 19);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            // 
            // lblDropHelp
            // 
            this.lblDropHelp.AutoSize = true;
            this.lblDropHelp.Location = new System.Drawing.Point(12, 47);
            this.lblDropHelp.Name = "lblDropHelp";
            this.lblDropHelp.Size = new System.Drawing.Size(198, 13);
            this.lblDropHelp.TabIndex = 6;
            this.lblDropHelp.Text = "Drop .mp3 files onto the list below to add";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(234, 38);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(129, 19);
            this.btnRemoveSelected.TabIndex = 7;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnCreateSymLinks
            // 
            this.btnCreateSymLinks.Location = new System.Drawing.Point(13, 254);
            this.btnCreateSymLinks.Name = "btnCreateSymLinks";
            this.btnCreateSymLinks.Size = new System.Drawing.Size(485, 23);
            this.btnCreateSymLinks.TabIndex = 8;
            this.btnCreateSymLinks.Text = "!!! Create SymLinks !!!";
            this.btnCreateSymLinks.UseVisualStyleBackColor = true;
            this.btnCreateSymLinks.Click += new System.EventHandler(this.btnCreateSymLinks_Click);
            this.btnCreateSymLinks.MouseEnter += new System.EventHandler(this.btnCreateSymLinks_MouseEnter);
            this.btnCreateSymLinks.MouseLeave += new System.EventHandler(this.btnCreateSymLinks_MouseLeave);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(369, 38);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(129, 19);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(420, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(78, 19);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // GTA3VCMusic
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 289);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreateSymLinks);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.lblDropHelp);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.lstFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "GTA3VCMusic";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GTA3VC Music";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Label lblDropHelp;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnCreateSymLinks;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAbout;

    }
}

