namespace OneNoteWiki
{
    partial class Main
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
            this.TextBoxMhtmlFile = new System.Windows.Forms.TextBox();
            this.TextBoxLog = new System.Windows.Forms.TextBox();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.LabelMhtmlFile = new System.Windows.Forms.Label();
            this.LabelExportDirectory = new System.Windows.Forms.Label();
            this.TextBoxExportDirectory = new System.Windows.Forms.TextBox();
            this.LabelRootName = new System.Windows.Forms.Label();
            this.TextBoxRootName = new System.Windows.Forms.TextBox();
            this.TextBoxNotebookName = new System.Windows.Forms.TextBox();
            this.TextBoxDivider = new System.Windows.Forms.TextBox();
            this.LabelNotebookName = new System.Windows.Forms.Label();
            this.LabelDivider = new System.Windows.Forms.Label();
            this.ButtonMhtmlBrowse = new System.Windows.Forms.Button();
            this.ButtonExportBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxMhtmlFile
            // 
            this.TextBoxMhtmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxMhtmlFile.Location = new System.Drawing.Point(100, 12);
            this.TextBoxMhtmlFile.Name = "TextBoxMhtmlFile";
            this.TextBoxMhtmlFile.Size = new System.Drawing.Size(337, 20);
            this.TextBoxMhtmlFile.TabIndex = 0;
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxLog.Location = new System.Drawing.Point(12, 175);
            this.TextBoxLog.Multiline = true;
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ReadOnly = true;
            this.TextBoxLog.Size = new System.Drawing.Size(506, 225);
            this.TextBoxLog.TabIndex = 1;
            // 
            // ButtonExport
            // 
            this.ButtonExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonExport.Location = new System.Drawing.Point(12, 146);
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(506, 23);
            this.ButtonExport.TabIndex = 2;
            this.ButtonExport.Text = "Export";
            this.ButtonExport.UseVisualStyleBackColor = true;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // LabelMhtmlFile
            // 
            this.LabelMhtmlFile.AutoSize = true;
            this.LabelMhtmlFile.Location = new System.Drawing.Point(12, 15);
            this.LabelMhtmlFile.Name = "LabelMhtmlFile";
            this.LabelMhtmlFile.Size = new System.Drawing.Size(62, 13);
            this.LabelMhtmlFile.TabIndex = 3;
            this.LabelMhtmlFile.Text = "MHTML file";
            // 
            // LabelExportDirectory
            // 
            this.LabelExportDirectory.AutoSize = true;
            this.LabelExportDirectory.Location = new System.Drawing.Point(12, 42);
            this.LabelExportDirectory.Name = "LabelExportDirectory";
            this.LabelExportDirectory.Size = new System.Drawing.Size(80, 13);
            this.LabelExportDirectory.TabIndex = 4;
            this.LabelExportDirectory.Text = "Export directory";
            // 
            // TextBoxExportDirectory
            // 
            this.TextBoxExportDirectory.Location = new System.Drawing.Point(100, 39);
            this.TextBoxExportDirectory.Name = "TextBoxExportDirectory";
            this.TextBoxExportDirectory.Size = new System.Drawing.Size(337, 20);
            this.TextBoxExportDirectory.TabIndex = 5;
            // 
            // LabelRootName
            // 
            this.LabelRootName.AutoSize = true;
            this.LabelRootName.Location = new System.Drawing.Point(12, 69);
            this.LabelRootName.Name = "LabelRootName";
            this.LabelRootName.Size = new System.Drawing.Size(59, 13);
            this.LabelRootName.TabIndex = 6;
            this.LabelRootName.Text = "Root name";
            // 
            // TextBoxRootName
            // 
            this.TextBoxRootName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxRootName.Location = new System.Drawing.Point(100, 66);
            this.TextBoxRootName.Name = "TextBoxRootName";
            this.TextBoxRootName.Size = new System.Drawing.Size(418, 20);
            this.TextBoxRootName.TabIndex = 7;
            this.TextBoxRootName.Text = "OneNote0x";
            // 
            // TextBoxNotebookName
            // 
            this.TextBoxNotebookName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNotebookName.Location = new System.Drawing.Point(100, 93);
            this.TextBoxNotebookName.Name = "TextBoxNotebookName";
            this.TextBoxNotebookName.Size = new System.Drawing.Size(418, 20);
            this.TextBoxNotebookName.TabIndex = 8;
            this.TextBoxNotebookName.Text = "Knowledge";
            // 
            // TextBoxDivider
            // 
            this.TextBoxDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDivider.Location = new System.Drawing.Point(100, 120);
            this.TextBoxDivider.Name = "TextBoxDivider";
            this.TextBoxDivider.Size = new System.Drawing.Size(418, 20);
            this.TextBoxDivider.TabIndex = 9;
            this.TextBoxDivider.Text = "!";
            // 
            // LabelNotebookName
            // 
            this.LabelNotebookName.AutoSize = true;
            this.LabelNotebookName.Location = new System.Drawing.Point(12, 96);
            this.LabelNotebookName.Name = "LabelNotebookName";
            this.LabelNotebookName.Size = new System.Drawing.Size(83, 13);
            this.LabelNotebookName.TabIndex = 10;
            this.LabelNotebookName.Text = "Notebook name";
            // 
            // LabelDivider
            // 
            this.LabelDivider.AutoSize = true;
            this.LabelDivider.Location = new System.Drawing.Point(12, 123);
            this.LabelDivider.Name = "LabelDivider";
            this.LabelDivider.Size = new System.Drawing.Size(40, 13);
            this.LabelDivider.TabIndex = 11;
            this.LabelDivider.Text = "Divider";
            // 
            // ButtonMhtmlBrowse
            // 
            this.ButtonMhtmlBrowse.Location = new System.Drawing.Point(443, 10);
            this.ButtonMhtmlBrowse.Name = "ButtonMhtmlBrowse";
            this.ButtonMhtmlBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonMhtmlBrowse.TabIndex = 12;
            this.ButtonMhtmlBrowse.Text = "Browse";
            this.ButtonMhtmlBrowse.UseVisualStyleBackColor = true;
            this.ButtonMhtmlBrowse.Click += new System.EventHandler(this.ButtonMhtmlBrowse_Click);
            // 
            // ButtonExportBrowse
            // 
            this.ButtonExportBrowse.Location = new System.Drawing.Point(443, 37);
            this.ButtonExportBrowse.Name = "ButtonExportBrowse";
            this.ButtonExportBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonExportBrowse.TabIndex = 13;
            this.ButtonExportBrowse.Text = "Browse";
            this.ButtonExportBrowse.UseVisualStyleBackColor = true;
            this.ButtonExportBrowse.Click += new System.EventHandler(this.ButtonExportBrowse_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 412);
            this.Controls.Add(this.ButtonExportBrowse);
            this.Controls.Add(this.ButtonMhtmlBrowse);
            this.Controls.Add(this.LabelDivider);
            this.Controls.Add(this.LabelNotebookName);
            this.Controls.Add(this.TextBoxDivider);
            this.Controls.Add(this.TextBoxNotebookName);
            this.Controls.Add(this.TextBoxRootName);
            this.Controls.Add(this.LabelRootName);
            this.Controls.Add(this.TextBoxExportDirectory);
            this.Controls.Add(this.LabelExportDirectory);
            this.Controls.Add(this.LabelMhtmlFile);
            this.Controls.Add(this.ButtonExport);
            this.Controls.Add(this.TextBoxLog);
            this.Controls.Add(this.TextBoxMhtmlFile);
            this.Name = "Main";
            this.Text = "MHTML to zip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxMhtmlFile;
        private System.Windows.Forms.TextBox TextBoxLog;
        private System.Windows.Forms.Button ButtonExport;
        private System.Windows.Forms.Label LabelMhtmlFile;
        private System.Windows.Forms.Label LabelExportDirectory;
        private System.Windows.Forms.TextBox TextBoxExportDirectory;
        private System.Windows.Forms.Label LabelRootName;
        private System.Windows.Forms.TextBox TextBoxRootName;
        private System.Windows.Forms.TextBox TextBoxNotebookName;
        private System.Windows.Forms.TextBox TextBoxDivider;
        private System.Windows.Forms.Label LabelNotebookName;
        private System.Windows.Forms.Label LabelDivider;
        private System.Windows.Forms.Button ButtonMhtmlBrowse;
        private System.Windows.Forms.Button ButtonExportBrowse;
    }
}

