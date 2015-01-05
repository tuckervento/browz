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

        public CollectionBrowser(CollectionsDatabase p_database)
        {
            InitializeComponent();
            _database = p_database;
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
        }

        private void addNewCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt for name of view then add to db
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt for new value, rename in db
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt to double check, remove from db
        }

        private void selectAViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt with a list, then populate browser
        }

        #endregion
    }
}
