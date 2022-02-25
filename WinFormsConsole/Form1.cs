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
            MonitorDirectory(Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Downloads"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Downloads");            
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddItem(openFileDialog1.FileName);
            }            
        }
        
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ItemModel item = listBox1.SelectedItem as ItemModel;
            Form2 form = new Form2(item);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            //Models = Models;
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModelBase>()));
        }
        private void AddItem(string name)
        {
            string result = Tools.VTInteractive.ScanFile(name);
            listBox1.Items.Add(new ItemModel(result));
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModelBase>()));
            
        }
        private void UpdateItem(string name, string oldname)
        {
            var thisitem = listBox1.Items.Cast<ItemModelBase>()?.FirstOrDefault(i => i.NameKey.Contains(oldname));
            int index = listBox1.Items.IndexOf(thisitem);
            ItemModel item = listBox1.Items[index] as ItemModel;            
            item.NameKey = item.NameKey.Replace(oldname, name);
            listBox1.Items.RemoveAt(index);
            listBox1.Items.Insert(index, item);
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModelBase>()));
        }
        private void DeleteItem(string name)
        {
            int index = listBox1.Items.IndexOf(listBox1.Items.Cast<ItemModelBase>()?.FirstOrDefault(i => i.NameKey.Contains(name)));
            listBox1.Items.RemoveAt(index);
            //listBox1.Items.Remove(listBox1.Items.Cast<ItemModelBase>().FirstOrDefault(i => i.NameKey.Contains(name)));
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModelBase>()));
        }

        private void MonitorDirectory(string path)

        {

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

            fileSystemWatcher.Path = path;

            fileSystemWatcher.Created += FileSystemWatcher_Created;

            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;

            fileSystemWatcher.EnableRaisingEvents = true;

        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)        {
            listBox1.Invoke(new Action(delegate () { AddItem(e.FullPath); }));            
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)        {
            if (e.ChangeType == WatcherChangeTypes.Renamed)
                listBox1.Invoke(new Action(delegate () { UpdateItem(e.Name, e.OldName); }));
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)        {
            listBox1.Invoke(new Action(delegate () { DeleteItem(e.FullPath); }));            
        }

    }
}
