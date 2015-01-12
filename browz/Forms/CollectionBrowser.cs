using browz.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace browz.Forms
{
    public partial class CollectionBrowser : Form
    {
        private CollectionsDatabase _database;
        private int _selectedView = 0;

        public CollectionBrowser(CollectionsDatabase p_database)
        {
            InitializeComponent();
            _database = p_database;
            listBoxEntries.DisplayMember = "FileName";
            listBoxEntries.ValueMember = "FullPath";
            if (!_database.Empty) { Populate(); }
        }

        private void Populate()
        {
            listBoxTags.DataSource = _database.GetCollection(_selectedView).Tags.OrderBy(t => t).ToList();//, (IComparer<string>)new CaseInsensitiveComparer());
            if (listBoxTags.SelectedIndex != 1)
            {
                listBoxEntries.DataSource = _database.GetEntriesTaggedAs(_selectedView, (string)listBoxTags.SelectedItem).ToList();
            }
        }

        private void PopulateEntries()
        {
            listBoxEntries.DataSource = _database.GetEntriesTaggedAs(_selectedView, (string)listBoxTags.SelectedItem).ToList();
        }

        #region Menu items

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show folder browser dialog, then prompt for recursive or not
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _database.DirectoryList.Add(folderBrowserDialog.SelectedPath,
                    (new BinaryEntryWindow()).ShowDialog("Recursive?", "Search this directory recursively?", "Yes", "No"));
            }
        }

        private void addManuallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = new ValueEntryWindow().ShowDialog("Directory", "Enter the full path:");
            if (!String.IsNullOrEmpty(result))
            {
                _database.DirectoryList.Add(result,
                    (new BinaryEntryWindow()).ShowDialog("Recursive?", "Search this directory recursively?", "Yes", "No"));
            }
        }

        private void editDirsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //eh...just display for now
            (new ListEntryWindow()).ShowDialog("Directory List", "Directory List:", _database.DirectoryList.Directories);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((new BinaryEntryWindow()).ShowDialog("Are you sure?", "Clear the directory list?", "Yes", "No"))
            {
                _database.DirectoryList.Clear();
            }
        }

        private void generateMasterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _database.GenerateMasterList();
            if (!_database.Empty) { Populate(); }
        }

        private void addNewCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if we want we can check if this returns false and inform the user
            _selectedView = _database.AddCollection(new ValueEntryWindow().ShowDialog("Name", "Enter the name of the new view:"));
            Populate();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedView = _database.RenameCollection(_selectedView, new ValueEntryWindow().ShowDialog("Rename", "Enter the new name for " + _selectedView + ":"));
            Populate();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt to double check, remove from db
            if ((new BinaryEntryWindow()).ShowDialog("Are you sure?", "Remove the view " + _selectedView + "?", "Yes", "No"))
            {
                _database.RemoveCollection(_selectedView);
                _selectedView -= (_selectedView > 0) ? 1 : 0;
                Populate();
            }
        }

        private void selectAViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt with a list, then populate browser
            var temp = new ListEntryWindow().ShowDialog("View", "Select a view:", _database.CollectionNames);
            if (temp >= 0)
            {
                _selectedView = temp;
                Populate();
            }
        }

        private void tagAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _database.GetCollection(_selectedView).TagEntriesAs(new ValueEntryWindow().ShowDialog("Tag", "Enter tag:"), listBoxEntries.SelectedItems);
            Populate();
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _database.GetCollection(_selectedView).RemoveEntries(listBoxEntries.SelectedItems);
            Populate();
        }

        private void listBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateEntries();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("vlc", "-vvv \"" + ((FileEntry)listBoxEntries.SelectedItem).FullPath + "\"");
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void addExtensionsToIgnoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = new ValueEntryWindow().ShowDialog("Extensions", "Enter extensions to ignore: (; delineates)");
            _database.AddExcludedExtensions(result.Split(';'));
        }

        private void clearExtensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _database.ClearExcludedExtensions();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxEntries.DisplayMember = "FileName";
            PopulateEntries();
        }

        private void fullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxEntries.DisplayMember = "FullPath";
            PopulateEntries();
        }
    }
}
