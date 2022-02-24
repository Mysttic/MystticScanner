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
using WinFormsConsole.Models;
using System.Text.Json;

namespace WinFormsConsole
{
    public partial class Form1 : Form
    {
        //List<ItemModel> models;
        //List<ItemModel> Models { get => models; set { models = value; listBox1.DataSource = value; listBox1.Refresh(); } }
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("db.json"))
                listBox1.Items.AddRange(JsonSerializer.Deserialize<List<ItemModelBase>>(File.ReadAllText("db.json")).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Downloads");            
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                string result = Tools.VTInteractive.ScanFile(selectedFileName);
                listBox1.Items.Add(new ItemModel(result));
                //Models.Add(new ItemModel(result));
                //Models = Models;
                File.WriteAllText("db.json",JsonSerializer.Serialize(listBox1.Items.Cast<ItemModelBase>()));
            }            
        }
        
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form2 form = new Form2(listBox1.SelectedItem as ItemModel);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            //Models = Models;
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModelBase>()));
        }

        //public async void Code()
        //{
        //    await Task.Run(() => StartCode());
        //}

        //public void StartCode()
        //{
        //    int start = 1;
        //    int step = 1;
        //    int end = 5;
        //    Process cmd = new Process();
        //    cmd.StartInfo.FileName = "cmd.exe";
        //    cmd.StartInfo.Arguments = $"/c  for /L %G IN ({start},{step},{end}) DO ( timeout 1 &echo Hello World %G >> WinFormsConsoleLog.txt ) ";
        //    cmd.Start();    
        //}

        //private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        //{

        //    textBox1.Invoke(new Action(delegate ()
        //    {
        //        var reader = new Tools.ReverseLineReader("WinFormsConsoleLog.txt");
        //            textBox1.AppendText(reader.First()+ Environment.NewLine);
        //    }));

        //}

    }
}
