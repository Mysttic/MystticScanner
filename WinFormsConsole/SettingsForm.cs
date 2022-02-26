using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsConsole.Models;
using static WinFormsConsole.Models.SettingsModel;

namespace WinFormsConsole
{
    public partial class SettingsForm : Form
    {
        public SettingsModel Settings { get; set; }
        private MainForm MainForm { get; set; }
        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            if (File.Exists("settings.json"))
                Settings = JsonSerializer.Deserialize<SettingsModel>(File.ReadAllText("settings.json"));
            else
                Settings = new SettingsModel();
            int i = 0;
            foreach (MonitorDirectoryItem item in Settings.MonitorDirectories)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i++].Cells["Path"].Value = item.Path;
            }
            MainForm = mainForm;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Settings != null)
            {
                Settings.MonitorDirectories = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[0].Value != null).Select(r => new MonitorDirectoryItem() { Path = r.Cells[0].Value.ToString() }).Cast<MonitorDirectoryItem>().ToList();
                File.WriteAllText("settings.json", JsonSerializer.Serialize(Settings));
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Settings != null)
            {                
                Settings.MonitorDirectories = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[0].Value != null).Select(r => new MonitorDirectoryItem() { Path = r.Cells[0].Value.ToString() }).Cast<MonitorDirectoryItem>().ToList();
                File.WriteAllText("settings.json", JsonSerializer.Serialize(Settings));
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Init();
        }
    }
}
