namespace DumpTransformer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The database structure.
        /// </summary>
        private string[] databaseStructure;

        /// <summary>
        /// The database data.
        /// </summary>
        private string[] databaseData;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = @"*.sql|*.sql";
        }

        /// <summary>
        /// The button1 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Button1Click(object sender, EventArgs e)
        {
            databaseStructure = ReadFile(openFileDialog1);
            if (databaseStructure == null)
            {
                label1.Text = @"File not located";
            }
            else
            {
                label1.Text = openFileDialog1.SafeFileName;
            }
        }

        /// <summary>
        /// The button2 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Button2Click(object sender, EventArgs e)
        {
            databaseData = ReadFile(openFileDialog2);
            label2.Text = databaseData == null ? @"File not located" : openFileDialog2.SafeFileName;
        }

        /// <summary>
        /// The read file.
        /// </summary>
        /// <param name="fileDialog">
        /// The file dialog.
        /// </param>
        /// <returns>
        /// The <see cref="string[]"/>.
        /// </returns>
        private string[] ReadFile(OpenFileDialog fileDialog)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return File.ReadAllLines(fileDialog.FileName);
            }

            return null;
        }

        /// <summary>
        /// The button 3 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Button3Click(object sender, EventArgs e)
        {
            if (databaseStructure != null && databaseStructure.Length > 0 && databaseData != null && databaseData.Length > 0)
            {
                var assembler = new Assembler(DateTime.Now.ToString(), DateTime.Now.ToString());
                List<string> assemliedLines = assembler.Assemble(databaseStructure, databaseData);
                var output = new StringBuilder();
                foreach (var str in assemliedLines)
                {
                    output.Append(str).AppendLine();
                }

                File.WriteAllText("Output.sql", output.ToString());

                richTextBox1.Text = output.ToString();
            }
            else
            {
                MessageBox.Show(@"Please, locate files (or correct) before generating.");
            }
        }
    }
}
