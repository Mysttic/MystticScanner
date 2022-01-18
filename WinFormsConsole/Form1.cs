using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;

namespace WinFormsConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Code();
        }

        public async void Code()
        {
            await Task.Run(() => StartCode());
        }

        public void StartCode()
        {
            int start = 1;
            int step = 1;
            int end = 5;
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = $"/c  for /L %G IN ({start},{step},{end}) DO ( timeout 1 &echo Hello World %G >> WinFormsConsoleLog.txt ) ";
            cmd.Start();    
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            
            textBox1.Invoke(new Action(delegate ()
            {
                var reader = new Tools.ReverseLineReader("WinFormsConsoleLog.txt");
                    textBox1.AppendText(reader.First()+ Environment.NewLine);
            }));
                        
        }
                
    }
}
