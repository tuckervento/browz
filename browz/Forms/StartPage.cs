using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using browz.DataModel;

namespace browz.Forms
{
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var nameWindow = new ValueEntryWindow();
            var result = nameWindow.ShowDialog("New Database", "Please enter a name for this database:");
            if (!String.IsNullOrEmpty(result))
            {
                Browz.Database = new CollectionsDatabase(result);
                this.Close();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            //this is where we will deserialize!
        }
    }
}
