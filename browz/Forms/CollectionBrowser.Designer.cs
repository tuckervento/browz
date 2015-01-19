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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addManuallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDirsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExtensionsToIgnoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearExtensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateMasterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentCollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.listBoxEntries = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.saveAndCloseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAndCloseToolStripMenuItem
            // 
            this.saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            this.saveAndCloseToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAndCloseToolStripMenuItem.Text = "Save and Close...";
            this.saveAndCloseToolStripMenuItem.Click += new System.EventHandler(this.saveAndCloseToolStripMenuItem_Click);
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
            this.addManuallyToolStripMenuItem,
            this.editDirsToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.addExtensionsToIgnoreToolStripMenuItem,
            this.clearExtensionsToolStripMenuItem});
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.directoryToolStripMenuItem.Text = "Directories";
            // 
            // addDirectoryToolStripMenuItem
            // 
            this.addDirectoryToolStripMenuItem.Name = "addDirectoryToolStripMenuItem";
            this.addDirectoryToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addDirectoryToolStripMenuItem.Text = "Add...";
            this.addDirectoryToolStripMenuItem.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // addManuallyToolStripMenuItem
            // 
            this.addManuallyToolStripMenuItem.Name = "addManuallyToolStripMenuItem";
            this.addManuallyToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addManuallyToolStripMenuItem.Text = "Add Manually...";
            this.addManuallyToolStripMenuItem.Click += new System.EventHandler(this.addManuallyToolStripMenuItem_Click);
            // 
            // editDirsToolStripMenuItem
            // 
            this.editDirsToolStripMenuItem.Name = "editDirsToolStripMenuItem";
            this.editDirsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.editDirsToolStripMenuItem.Text = "Remove or Edit...";
            this.editDirsToolStripMenuItem.Click += new System.EventHandler(this.editDirsToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.clearToolStripMenuItem.Text = "Clear...";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // addExtensionsToIgnoreToolStripMenuItem
            // 
            this.addExtensionsToIgnoreToolStripMenuItem.Name = "addExtensionsToIgnoreToolStripMenuItem";
            this.addExtensionsToIgnoreToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addExtensionsToIgnoreToolStripMenuItem.Text = "Add Extensions To Ignore...";
            this.addExtensionsToIgnoreToolStripMenuItem.Click += new System.EventHandler(this.addExtensionsToIgnoreToolStripMenuItem_Click);
            // 
            // clearExtensionsToolStripMenuItem
            // 
            this.clearExtensionsToolStripMenuItem.Name = "clearExtensionsToolStripMenuItem";
            this.clearExtensionsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.clearExtensionsToolStripMenuItem.Text = "Clear Extensions...";
            this.clearExtensionsToolStripMenuItem.Click += new System.EventHandler(this.clearExtensionsToolStripMenuItem_Click);
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
            this.currentCollToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.searchToolStripMenuItem});
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
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.renameToolStripMenuItem.Text = "Rename...";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.removeToolStripMenuItem.Text = "Remove...";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.fullPathToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.nameToolStripMenuItem.Text = "Name...";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // fullPathToolStripMenuItem
            // 
            this.fullPathToolStripMenuItem.Name = "fullPathToolStripMenuItem";
            this.fullPathToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fullPathToolStripMenuItem.Text = "Full Path...";
            this.fullPathToolStripMenuItem.Click += new System.EventHandler(this.fullPathToolStripMenuItem_Click);
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
            this.listBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(12, 27);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(102, 667);
            this.listBoxTags.TabIndex = 1;
            this.listBoxTags.SelectedIndexChanged += new System.EventHandler(this.listBoxTags_SelectedIndexChanged);
            // 
            // listBoxEntries
            // 
            this.listBoxEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxEntries.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxEntries.FormattingEnabled = true;
            this.listBoxEntries.Location = new System.Drawing.Point(121, 27);
            this.listBoxEntries.Name = "listBoxEntries";
            this.listBoxEntries.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxEntries.Size = new System.Drawing.Size(559, 667);
            this.listBoxEntries.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.tagAsToolStripMenuItem,
            this.removeTagToolStripMenuItem,
            this.removeToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 92);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // tagAsToolStripMenuItem
            // 
            this.tagAsToolStripMenuItem.Name = "tagAsToolStripMenuItem";
            this.tagAsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.tagAsToolStripMenuItem.Text = "Tag As...";
            this.tagAsToolStripMenuItem.Click += new System.EventHandler(this.tagAsToolStripMenuItem_Click);
            // 
            // removeTagToolStripMenuItem
            // 
            this.removeTagToolStripMenuItem.Name = "removeTagToolStripMenuItem";
            this.removeTagToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeTagToolStripMenuItem.Text = "Remove Tag...";
            this.removeTagToolStripMenuItem.Click += new System.EventHandler(this.removeTagToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.removeToolStripMenuItem1.Text = "Remove...";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem1_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.searchToolStripMenuItem.Text = "Search...";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndCloseToolStripMenuItem;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tagAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addManuallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExtensionsToIgnoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearExtensionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
    }
}