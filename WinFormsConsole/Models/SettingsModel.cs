using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsConsole.Models
{
    public class SettingsModel
    {
        public SettingsModel()
        {
        }

        public List<MonitorDirectoryItem> MonitorDirectories { get; set; }

        public class MonitorDirectoryItem
        {
            public override string ToString()
            {
                return Path;
            }
            public string Path { get; set; }
        }
    }
}
