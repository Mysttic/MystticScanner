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
        }

        public override string ToString()
        {
            return Name + " - " + Key;
        }
        public string Name => NameKey.Replace(Key, "");
        public string Key => NameKey.Split(' ').Last();
    }
}
