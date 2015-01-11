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
    public partial class ListEntryWindow : Form
    {
        /// <summary>
        /// Creates a new customizable ListEntryWindow.
        /// </summary>
        public ListEntryWindow()
        {
            InitializeComponent();
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {

        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Display the BinaryEntryWindow as a dialog.
        /// </summary>
        /// <param name="p_name">The name to display on the window</param>
        /// <param name="p_text">The prompt text</param>
        /// <param name="p_buttonOne">The text to display for option 1</param>
        /// <param name="p_buttonTwo">The text to display for option 2</param>
        /// <returns>Index of selected value</returns>
        public int ShowDialog(string p_name, string p_text, IEnumerable<string> p_items)
        {
            this.Text = p_name;
            this.labelText.Text = p_text;
            this.listBox.Items.AddRange(p_items.ToArray());
            return (this.ShowDialog() == DialogResult.OK) ? this.listBox.SelectedIndex : -1;
        }
    }
}
