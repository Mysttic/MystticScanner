using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MystticScanner.Models
{
    public class ItemModel
    {
        public override string ToString()
        {
            return NameKey;
        }
        public ItemModel(string nameKey)
        {
            NameKey = nameKey;            
        }

        public string NameKey { get; set; }
        
        public string Analysis { get; set; }

        internal string Name => NameKey.Replace(Key, "");
        internal string Key => NameKey.Split(' ').Last();
    }
}
