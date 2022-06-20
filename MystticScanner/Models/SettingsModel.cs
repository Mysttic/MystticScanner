using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MystticScanner.Models
{
    public class SettingsModel
    {
        public SettingsModel()
        {
            MonitorDirectories = new List<MonitorDirectoryItem>();
        }

        public List<MonitorDirectoryItem> MonitorDirectories { get; set; }
        public long MaxFileSize { get; set; }
        public string EnabledFileExtensions { get; set; }

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
