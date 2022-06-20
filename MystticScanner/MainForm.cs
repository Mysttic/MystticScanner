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
using MystticScanner.Models;
using System.Text.Json;
using static MystticScanner.Models.SettingsModel;
using System.Media;

namespace MystticScanner
{
    public partial class MainForm : Form
    {
        public SettingsModel Settings { get; set; }
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        internal void Init()
        {
            listBox1.Items.Clear();
            if (File.Exists("db.json"))
                listBox1.Items.AddRange(JsonSerializer.Deserialize<List<ItemModel>>(File.ReadAllText("db.json")).ToArray());
            if(File.Exists("settings.json"))
                Settings = JsonSerializer.Deserialize<SettingsModel>(File.ReadAllText("settings.json"));
            if(Settings != null)
                foreach(MonitorDirectoryItem directory in Settings?.MonitorDirectories)
                    MonitorDirectory(directory.Path); //MonitorDirectory(Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Downloads"));
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
            ItemModelForm form = new ItemModelForm(item);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModel>()));
        }
        private async void AddItem(string name)
        {
            if (listBox1.Items.Contains(name))
                return;
            if (String.IsNullOrEmpty(Settings.EnabledFileExtensions) ? false : !Settings.EnabledFileExtensions.Contains(Path.GetExtension(name)))
                return;
            if (Settings.MaxFileSize == 0 ? false : Settings.MaxFileSize < (new FileInfo(name).Length / (1024 * 1024)))
                return;
            string result = await Task.Run(() => Tools.VTInteractive.ScanFile(name));
            listBox1.Items.Add(new ItemModel(result));
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModel>()));
            
        }
        private void UpdateItem(string name, string oldname)
        {
            var thisitem = listBox1.Items.Cast<ItemModel>()?.FirstOrDefault(i => i.NameKey.Contains(oldname));
            int index = listBox1.Items.IndexOf(thisitem);
            ItemModel item = listBox1.Items[index] as ItemModel;            
            item.NameKey = item.NameKey.Replace(oldname, name);
            listBox1.Items.RemoveAt(index);
            listBox1.Items.Insert(index, item);
            File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModel>()));
        }
        private void DeleteItem(string name)
        {
            if (listBox1.Items.Count > 0)
            {
                int index = listBox1.Items.IndexOf(listBox1.Items.Cast<ItemModel>()?.FirstOrDefault(i => i.NameKey.Contains(name)));
                listBox1.Items.RemoveAt(index);
                //listBox1.Items.Remove(listBox1.Items.Cast<ItemModelBase>().FirstOrDefault(i => i.NameKey.Contains(name)));
                File.WriteAllText("db.json", JsonSerializer.Serialize(listBox1.Items.Cast<ItemModel>()));
            }
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
            listBox1.Invoke(new Action(delegate () { AddItem(e.FullPath); SystemSounds.Asterisk.Play(); Console.WriteLine($"Add {e.FullPath}"); }));            
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)        {
            if (e.ChangeType == WatcherChangeTypes.Renamed)
                listBox1.Invoke(new Action(delegate () { UpdateItem(e.Name, e.OldName); Console.WriteLine($"Update {e.OldName}, {e.Name}"); }));
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)        {
            listBox1.Invoke(new Action(delegate () { DeleteItem(e.FullPath); Console.WriteLine($"Delete {e.FullPath}"); }));            
        }

        private void SettingsBT_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(this);
            form.ShowDialog();
        }
    }
}
