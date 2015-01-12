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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
            if (result == DialogResult.OK)
            {
                var formatter = new BinaryFormatter();
                var stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                Browz.Database = (CollectionsDatabase)formatter.Deserialize(stream);
                this.Close();
            }
        }
    }
}
