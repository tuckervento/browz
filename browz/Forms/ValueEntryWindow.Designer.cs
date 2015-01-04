namespace browz.Forms
{
    partial class ValueEntryWindow
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
            this.labelText = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonOne = new System.Windows.Forms.Button();
            this.buttonTwo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(13, 13);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(35, 13);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "TEXT";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(13, 41);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(277, 20);
            this.textBox.TabIndex = 1;
            // 
            // buttonOne
            // 
            this.buttonOne.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOne.Location = new System.Drawing.Point(44, 73);
            this.buttonOne.Name = "buttonOne";
            this.buttonOne.Size = new System.Drawing.Size(75, 23);
            this.buttonOne.TabIndex = 2;
            this.buttonOne.Text = "OK";
            this.buttonOne.UseVisualStyleBackColor = true;
            this.buttonOne.Click += new System.EventHandler(this.buttonOne_Click);
            // 
            // buttonTwo
            // 
            this.buttonTwo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonTwo.Location = new System.Drawing.Point(184, 72);
            this.buttonTwo.Name = "buttonTwo";
            this.buttonTwo.Size = new System.Drawing.Size(75, 23);
            this.buttonTwo.TabIndex = 3;
            this.buttonTwo.Text = "Cancel";
            this.buttonTwo.UseVisualStyleBackColor = true;
            this.buttonTwo.Click += new System.EventHandler(this.buttonTwo_Click);
            // 
            // ValueEntryWindow
            // 
            this.AcceptButton = this.buttonOne;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonTwo;
            this.ClientSize = new System.Drawing.Size(302, 108);
            this.Controls.Add(this.buttonTwo);
            this.Controls.Add(this.buttonOne);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ValueEntryWindow";
            this.Text = "NAME";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonOne;
        private System.Windows.Forms.Button buttonTwo;
    }
}