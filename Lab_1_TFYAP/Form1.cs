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
using DSM;

namespace Lab_1_TFYAP
{
    public partial class Form1 : Form
    {
        string FileName = string.Empty;
        bool Changed = false;

        public Form1()
        {
            InitializeComponent();
            //Form1.ActiveForm.Name = FileName + "TFYAP";
        }
        void SaveAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {

                saveFileDialog.Filter = "Text files(*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                    File.WriteAllLines(FileName, InputRTP.Lines);
                    Changed = false;
                }
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
                InputRTP.Lines = File.ReadAllLines(FileName);
                Changed = false;
                InputRTP.ClearUndo();
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
                    InputRTP.Text = string.Empty;
                    FileName = string.Empty;
                    InputRTP.ClearUndo();
                }
                else if (Result == DialogResult.No)
                {
                    InputRTP.Text = string.Empty;
                    FileName = string.Empty;
                    Changed = false; //?
                    InputRTP.ClearUndo();
                }
            }
            else
            {
                InputRTP.Text = string.Empty;
                FileName = string.Empty;
                Changed = false; //?
                InputRTP.ClearUndo();

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
                File.WriteAllText(FileName, InputRTP.Text);
                Changed = false;//?
            }
        }

        void CloseFile()
        {
            InputRTP.Text = string.Empty;
            FileName = string.Empty;
            Changed = false;
        }

        void ANIGILATORNAYA_PUSHKA()
        {
            string str1 = InputRTP.Text;
            StateMachine<State, char> stateMachine = new StateMachine<State, char>(
                State.Q0 /*начальное состояние Q0*/,
                new[] { State.Q4 }/*финальные состояния Q1,Q3*/,
                Transit /*функция переходов*/);
            OutputRTB.Text = (String.Format("Результат работы автомата для строки {0} : {1}", str1, stateMachine.Check(str1)));
        }

        void AVTOMAT()
        {
            string str1 = InputRTP.Text;
            StateMachine<State, char> stateMachine = new StateMachine<State, char>(
                State.Q0 /*начальное состояние Q0*/,
                new[] { State.Q0 }/*финальные состояния Q1,Q3*/,
                TransitAVTOMATA /*функция переходов*/);
            OutputRTB.Text = (String.Format("Результат работы автомата для строки {0} : {1}", str1, stateMachine.Check(str1)));
        }

        void PULEMET()
        {
            string str1 = InputRTP.Text;
            StateMachine<State, char> stateMachine = new StateMachine<State, char>(
                State.Q0 /*начальное состояние Q0*/,
                new[] { State.Q0, State.Q1 }/*финальные состояния Q1,Q3*/,
                TransitPULEMETA /*функция переходов*/);
            OutputRTB.Text = (String.Format("Результат работы автомата для строки {0} : {1}", str1, stateMachine.Check(str1)));
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
            this.Text = FileName + "TFYAP"; //TODO: ETO KRIVAAA
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
            string SelectedText = string.Empty;
            SelectedText = InputRTP.SelectedText;
            Clipboard.SetText(SelectedText);
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputRTP.SelectedText = Clipboard.GetText();
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
            if(InputRTP.CanRedo == true)
            {
                вернутьToolStripMenuItem.Enabled = true;
            }
            else
            {
                вернутьToolStripMenuItem.Enabled = false;
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputRTP.Undo();
        }

        private void вернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputRTP.Redo();
        }

        private void ANIGILATORNAYAPUSHKAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ANIGILATORNAYA_PUSHKA();
        }

        private void AVTOMATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AVTOMAT();
        }

        private void PULEMETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PULEMET();
        }

        enum State { Q0, Q1, Q2, Q3, Q4, Error }
        static State Transit(State s, char c)
        {
            switch (s)
            {
                case State.Q0:
                    if (c == 'a')    //по a переходим в q1, остальные символы воспринимаем как ошибку
                        return State.Q1;
                    return State.Error;
                case State.Q1:
                    if (c == 'a')
                        return State.Q2;
                    else if (c == 'b')
                        return State.Q3;
                    return State.Error;
                case State.Q2:
                    if (c == 'a')
                        return State.Q2;
                    else if (c == 'b')
                        return State.Q3;
                    return State.Error;
                case State.Q3:
                    if (c == 'a')
                        return State.Q4;
                    else if (c == 'b')
                        return State.Q3;
                    return State.Error;         
                default:
                    return State.Error;     //все нераспознанные символы переводят в состояние Error
            }
        }

        static State TransitAVTOMATA(State s, char c)
        {
            switch (s)
            {
                case State.Q0:
                    if (c == 'a' || c == 'c')
                        return State.Q0;
                    else if (c == 'b')
                        return State.Q1;
                    return State.Error;
                case State.Q1:
                    if (c == 'c')
                        return State.Q0;
                    return State.Error;
                default:
                    return State.Error;
            }
        }

        static State TransitPULEMETA(State s, char c)
        {
            switch (s)
            {
                case State.Q0:
                    if (c == 'a' || c == 'c')
                        return State.Q0;
                    else if (c == 'b')
                        return State.Q1;
                    return State.Error;
                case State.Q1:
                    if (c == 'a')
                        return State.Q0;
                    else if (c == 'b')
                        return State.Q1;
                    return State.Error;
                default:
                    return State.Error;
            }
        }
    }
}