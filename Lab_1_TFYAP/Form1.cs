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

namespace Lab_1_TFYAP
{
    public partial class Form1 : Form
    {
        string FileName = string.Empty;
        string FileText = string.Empty;
        bool Changed = false;

        public Form1()
        {
            InitializeComponent();
            //Form1.ActiveForm.Name = FileName + "TFYAP";
        }
        void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = saveFileDialog.FileName;
                File.WriteAllText(FileName, richTextBox1.Text);
                Changed = false;
            }
        }

        void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                FileText = File.ReadAllText(FileName);
                richTextBox1.Text = FileText;
                Changed = false;
            }
        }

        void Create()
        {
            if (Changed)
            {
                DialogResult Result = MessageBox.Show("Save?", "SAVE?!", MessageBoxButtons.YesNoCancel);
                if (Result == DialogResult.Yes)
                {
                    SaveAs();
                }
                else if (Result == DialogResult.No)
                {
                    richTextBox1.Text = string.Empty;
                    Changed = false; //?
                }
            }
            else
            {
                richTextBox1.Text = string.Empty;
                Changed = false; //?
            }
        }

        void Save()
        {
            if (FileName == string.Empty)
            {
                SaveAs();
            }
            else
            {
                File.WriteAllText(FileName, richTextBox1.Text);
                Changed = false;//?
            }
        }

        void CloseFile()
        {
            richTextBox1.Text = string.Empty;
            FileName = string.Empty;
            Changed = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Changed)
            {
                DialogResult Result = MessageBox.Show("Save?", "SAVE?!", MessageBoxButtons.YesNoCancel);
                if (Result == DialogResult.Yes)
                {
                    SaveAs();
                    Open();
                }
                else if (Result == DialogResult.No)
                {
                    Open();
                }
            }
            else
            {
                Open();
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Changed)
            {
                DialogResult Result = MessageBox.Show("Save?", "SAVE?!", MessageBoxButtons.YesNoCancel);
                if (Result == DialogResult.Yes)
                {
                    Save();
                    CloseFile();
                }
                else if (Result == DialogResult.No)
                {
                    CloseFile();
                }
            }
            else
            {
                CloseFile();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Changed = true;
        }
    }
}
