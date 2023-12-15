using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {

        public string sText;
        string[] errorAnswers = new string[30];
        int errorFlag = 0;
        char[] correctAnswers = { 'B', 'D', 'A', 'A', 'C', 'A', 'B', 'A', 'C', 'D', 'B', 'C', 'D', 'A', 'D', 'C', 'C', 'B', 'D', 'A' };

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void startTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            char[] userAnswers;
            int errors = 0;
            errorFlag = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                StreamReader f = new StreamReader(filePath);
                int answerCounter = 0;
                
                
                while (!f.EndOfStream)
                {
                    sText = f.ReadLine();
                    userAnswers = sText.ToCharArray();
                    MessageBox.Show(sText);
                    for (int i = 0; i < userAnswers.Length; i++) 
                    {
                        answerCounter++;
                        if (userAnswers[i] != correctAnswers[i])
                        {
                            errors++;
                            errorFlag = 1;
                            string wrongAnswer = answerCounter.ToString()+"-"+userAnswers[i].ToString();
                            errorAnswers[i] = wrongAnswer;
                        }
                    }
                }
                f.Close();
            }

            label1.Text = "Total number of correctly answered questions: " + (correctAnswers.Length - errors).ToString();
            label2.Text = "Total number of wrong answered questions: " + errors.ToString();
            if (errors < 5)
            {
                label3.Text = label3.Text + " Passed";
            }
            else 
            {
                label3.Text = label3.Text + " Failed";
            } 
        }

        private void seeWrongAnswers_Click(object sender, EventArgs e)
        {
            if (errorFlag == 0)
            {
                return;
            }
            else 
            {
                string betaS = "";
                for (int i = 0; i < errorAnswers.Length; i++)
                {
                    if (errorAnswers[i] == null)
                    {
                        continue;
                    }
                    else{
                        string a = errorAnswers[i] + "\n";
                        betaS = betaS + a;
                    }                 
                }
                MessageBox.Show(betaS);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
