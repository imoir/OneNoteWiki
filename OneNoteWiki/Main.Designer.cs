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
            this.TextBoxLink = new System.Windows.Forms.TextBox();
            this.TextBoxIgnorePage = new System.Windows.Forms.TextBox();
            this.LabelLink = new System.Windows.Forms.Label();
            this.LabelDivider = new System.Windows.Forms.Label();
            this.ButtonMhtmlBrowse = new System.Windows.Forms.Button();
            this.ButtonExportBrowse = new System.Windows.Forms.Button();
            this.LabelIgnorePage = new System.Windows.Forms.Label();
            this.ComboBoxDivider = new System.Windows.Forms.ComboBox();
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
            this.TextBoxRootName.Text = "OneNote";
            // 
            // TextBoxLink
            // 
            this.TextBoxLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxLink.Location = new System.Drawing.Point(100, 93);
            this.TextBoxLink.Name = "TextBoxLink";
            this.TextBoxLink.Size = new System.Drawing.Size(418, 20);
            this.TextBoxLink.TabIndex = 8;
            this.TextBoxLink.Text = "Main_Page|Main Page";
            // 
            // TextBoxIgnorePage
            // 
            this.TextBoxIgnorePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxIgnorePage.Location = new System.Drawing.Point(100, 120);
            this.TextBoxIgnorePage.Name = "TextBoxIgnorePage";
            this.TextBoxIgnorePage.Size = new System.Drawing.Size(308, 20);
            this.TextBoxIgnorePage.TabIndex = 9;
            this.TextBoxIgnorePage.Text = "Archives";
            // 
            // LabelLink
            // 
            this.LabelLink.AutoSize = true;
            this.LabelLink.Location = new System.Drawing.Point(12, 96);
            this.LabelLink.Name = "LabelLink";
            this.LabelLink.Size = new System.Drawing.Size(27, 13);
            this.LabelLink.TabIndex = 10;
            this.LabelLink.Text = "Link";
            // 
            // LabelDivider
            // 
            this.LabelDivider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelDivider.AutoSize = true;
            this.LabelDivider.Location = new System.Drawing.Point(414, 123);
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
            // LabelIgnorePage
            // 
            this.LabelIgnorePage.AutoSize = true;
            this.LabelIgnorePage.Location = new System.Drawing.Point(12, 123);
            this.LabelIgnorePage.Name = "LabelIgnorePage";
            this.LabelIgnorePage.Size = new System.Drawing.Size(64, 13);
            this.LabelIgnorePage.TabIndex = 14;
            this.LabelIgnorePage.Text = "Ignore page";
            // 
            // ComboBoxDivider
            // 
            this.ComboBoxDivider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxDivider.FormattingEnabled = true;
            this.ComboBoxDivider.Items.AddRange(new object[] {
            "/",
            "!",
            "_",
            "+",
            ":"});
            this.ComboBoxDivider.Location = new System.Drawing.Point(460, 119);
            this.ComboBoxDivider.Name = "ComboBoxDivider";
            this.ComboBoxDivider.Size = new System.Drawing.Size(58, 21);
            this.ComboBoxDivider.TabIndex = 15;
            this.ComboBoxDivider.Text = "/";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 412);
            this.Controls.Add(this.ComboBoxDivider);
            this.Controls.Add(this.LabelIgnorePage);
            this.Controls.Add(this.ButtonExportBrowse);
            this.Controls.Add(this.ButtonMhtmlBrowse);
            this.Controls.Add(this.LabelDivider);
            this.Controls.Add(this.LabelLink);
            this.Controls.Add(this.TextBoxIgnorePage);
            this.Controls.Add(this.TextBoxLink);
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
        private System.Windows.Forms.TextBox TextBoxLink;
        private System.Windows.Forms.TextBox TextBoxIgnorePage;
        private System.Windows.Forms.Label LabelLink;
        private System.Windows.Forms.Label LabelDivider;
        private System.Windows.Forms.Button ButtonMhtmlBrowse;
        private System.Windows.Forms.Button ButtonExportBrowse;
        private System.Windows.Forms.Label LabelIgnorePage;
        private System.Windows.Forms.ComboBox ComboBoxDivider;
    }
}

