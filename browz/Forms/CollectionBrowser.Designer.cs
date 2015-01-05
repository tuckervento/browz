namespace browz.Forms
{
    partial class CollectionBrowser
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDirsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateMasterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentCollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.listBoxEntries = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.selectAViewToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(692, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAndCloseToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            // 
            // saveAndCloseToolStripMenuItem
            // 
            this.saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            this.saveAndCloseToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAndCloseToolStripMenuItem.Text = "Save and Close...";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.closeToolStripMenuItem.Text = "Close...";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoryToolStripMenuItem,
            this.generateMasterListToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.editToolStripMenuItem.Text = "Master Collection";
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDirectoryToolStripMenuItem,
            this.editDirsToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.directoryToolStripMenuItem.Text = "Directories";
            // 
            // addDirectoryToolStripMenuItem
            // 
            this.addDirectoryToolStripMenuItem.Name = "addDirectoryToolStripMenuItem";
            this.addDirectoryToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addDirectoryToolStripMenuItem.Text = "Add...";
            this.addDirectoryToolStripMenuItem.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // editDirsToolStripMenuItem
            // 
            this.editDirsToolStripMenuItem.Name = "editDirsToolStripMenuItem";
            this.editDirsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editDirsToolStripMenuItem.Text = "Remove or Edit...";
            this.editDirsToolStripMenuItem.Click += new System.EventHandler(this.editDirsToolStripMenuItem_Click);
            // 
            // generateMasterListToolStripMenuItem
            // 
            this.generateMasterListToolStripMenuItem.Name = "generateMasterListToolStripMenuItem";
            this.generateMasterListToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.generateMasterListToolStripMenuItem.Text = "Generate Master List...";
            this.generateMasterListToolStripMenuItem.Click += new System.EventHandler(this.generateMasterListToolStripMenuItem_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCollectionToolStripMenuItem,
            this.currentCollToolStripMenuItem});
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.viewsToolStripMenuItem.Text = "Organizational Views";
            // 
            // addNewCollectionToolStripMenuItem
            // 
            this.addNewCollectionToolStripMenuItem.Name = "addNewCollectionToolStripMenuItem";
            this.addNewCollectionToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addNewCollectionToolStripMenuItem.Text = "Add New View...";
            this.addNewCollectionToolStripMenuItem.Click += new System.EventHandler(this.addNewCollectionToolStripMenuItem_Click);
            // 
            // currentCollToolStripMenuItem
            // 
            this.currentCollToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.currentCollToolStripMenuItem.Name = "currentCollToolStripMenuItem";
            this.currentCollToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.currentCollToolStripMenuItem.Text = "Current View";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameToolStripMenuItem.Text = "Rename...";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove...";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // selectAViewToolStripMenuItem
            // 
            this.selectAViewToolStripMenuItem.Name = "selectAViewToolStripMenuItem";
            this.selectAViewToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.selectAViewToolStripMenuItem.Text = "Select a View...";
            this.selectAViewToolStripMenuItem.Click += new System.EventHandler(this.selectAViewToolStripMenuItem_Click);
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(12, 27);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(102, 667);
            this.listBoxTags.TabIndex = 1;
            // 
            // listBoxEntries
            // 
            this.listBoxEntries.FormattingEnabled = true;
            this.listBoxEntries.Location = new System.Drawing.Point(121, 27);
            this.listBoxEntries.Name = "listBoxEntries";
            this.listBoxEntries.Size = new System.Drawing.Size(559, 667);
            this.listBoxEntries.TabIndex = 2;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.clearToolStripMenuItem.Text = "Clear...";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // CollectionBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 703);
            this.Controls.Add(this.listBoxEntries);
            this.Controls.Add(this.listBoxTags);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "CollectionBrowser";
            this.Text = "CollectionBrowser";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDirsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateMasterListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentCollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAViewToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.ListBox listBoxEntries;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}