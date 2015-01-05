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
    public partial class ValueEntryWindow : Form
    {
        /// <summary>
        /// Creates a new customizable ValueEntryWindow.
        /// </summary>
        public ValueEntryWindow()
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
        /// Display the ValueEntryWindow as a dialog.
        /// </summary>
        /// <param name="p_name">The name to display on the window</param>
        /// <param name="p_text">The prompt text</param>
        /// <returns>The value entered, or null if canceled</returns>
        public string ShowDialog(string p_name, string p_text)
        {
            this.Text = p_name;
            this.labelText.Text = p_text;
            return (this.ShowDialog() == DialogResult.OK) ? this.textBox.Text : null;
        }

        /// <summary>
        /// Display the ValueEntryWindow as a dialog.
        /// </summary>
        /// <param name="p_name">The name to display on the window</param>
        /// <param name="p_text">The prompt text</param>
        /// <param name="p_textBoxText">The initial text to display in the text box</param>
        /// <returns>The value entered, or null if canceled</returns>
        public string ShowDialog(string p_name, string p_text, string p_textBoxText)
        {
            this.textBox.Text = p_textBoxText;
            return this.ShowDialog(p_name, p_text);
        }
    }
}
