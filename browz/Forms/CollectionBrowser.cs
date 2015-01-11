using browz.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private string _selectedView;

        public CollectionBrowser(CollectionsDatabase p_database)
        {
            InitializeComponent();
            _database = p_database;
            if (!_database.Empty)
            {
                _selectedView = _database.CollectionNames.First();
                PopulateTags();
                PopulateEntries();
            }
        }

        private void PopulateTags()
        {
            listBoxTags.DataSource = _database.GetCollection(_selectedView).Tags.OrderBy(t => t);//, (IComparer<string>)new CaseInsensitiveComparer());
            listBoxTags.SelectedIndex = 0;
        }

        private void PopulateEntries()
        {
            if (listBoxTags.SelectedItem != null)
            {
                listBoxEntries.DataSource = _database.GetEntriesTaggedAs(_selectedView, (string)listBoxTags.SelectedItem);
                listBoxEntries.DisplayMember = "FileName";
                listBoxEntries.ValueMember = "FullPath";
            }
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
            PopulateTags();
            PopulateEntries();
        }

        private void addNewCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if we want we can check if this returns false and inform the user
            _selectedView = _database.AddCollection(new ValueEntryWindow().ShowDialog("Name", "Enter the name of the new view:"));
            PopulateTags();
            PopulateEntries();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedView = _database.RenameCollection(_selectedView, new ValueEntryWindow().ShowDialog("Rename", "Enter the new name for " + _selectedView + ":"));
            PopulateTags();
            PopulateEntries();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt to double check, remove from db
            if ((new BinaryEntryWindow()).ShowDialog("Are you sure?", "Remove the view " + _selectedView + "?", "Yes", "No"))
            {
                _database.RemoveCollection(_selectedView);
                _selectedView = _database.CollectionNames.First();
                PopulateTags();
                PopulateEntries();
            }
        }

        private void selectAViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt with a list, then populate browser
        }

        #endregion
    }
}
