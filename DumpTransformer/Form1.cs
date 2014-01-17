using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumpTransformer
{
    public partial class Form1 : Form
    {
        private string[] dBStructure;
        private string[] dBData;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dBStructure = ReadFile(openFileDialog1);
            if (dBStructure == null)
            {
                label1.Text = @"File not located";
            }
            else
            {
                label1.Text = openFileDialog1.SafeFileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dBData = ReadFile(openFileDialog2);
            if (dBData == null)
            {
                label2.Text = @"File not located";
            }
            else
            {
                label2.Text = openFileDialog2.SafeFileName;
            }
        }

        private string[] ReadFile(OpenFileDialog fileDialog)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return File.ReadAllLines(fileDialog.FileName);
            }
            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dBStructure != null && dBStructure.Length > 0 && dBData != null && dBData.Length > 0)
            {
                List<string> assemliedLines = Transformer.Assemble(dBStructure, dBData);
                List<string> clinedAssemlied = Transformer.CleanUp(assemliedLines);
                StringBuilder output = new StringBuilder();
                foreach (var str in clinedAssemlied)
                {
                    output.Append(str).AppendLine();
                }
                richTextBox1.Text = output.ToString();
            }
            else
            {
                MessageBox.Show("Please, locate files (or correct) before generating.");
            }
        }
    }
}
