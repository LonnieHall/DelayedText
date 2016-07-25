using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelayedText
{
    public partial class Form1 : Form
    {
        string msg;        

        public Form1()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            backgroundWorker1.WorkerReportsProgress = true;
            progressBar1.Step = 1;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            textBox2.Text = "";
            progressBar1.Maximum = textBox1.Text.Length;
            progressBar1.Value = 0;

            if (backgroundWorker1.IsBusy) { backgroundWorker1.CancelAsync(); }
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            msg = textBox1.Text;                        
            for (int i = 0; i < msg.Length; i++)
            {
                System.Threading.Thread.Sleep(70);             
                backgroundWorker1.ReportProgress( i / msg.Length);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = textBox2.Text.Length;
            textBox2.AppendText(msg.Substring(i, 1));            
            progressBar1.PerformStep();
        }
    }
}
