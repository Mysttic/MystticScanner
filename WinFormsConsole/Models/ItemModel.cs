using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsConsole.Models
{
    public class ItemModel : ItemModelBase
    {
        public ItemModel(string nameKey) : base(nameKey)
        {
            Key = NameKey.Split(' ').Last();
            Name = NameKey.Replace(Key, "");
        }

        public override string ToString()
        {
            return Name + " - " + Key;
        }
        public string Name { get; set; }
        public string Key { get; set; }
    }
}
