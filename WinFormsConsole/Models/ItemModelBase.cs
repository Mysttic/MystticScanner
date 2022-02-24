using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsConsole.Models
{
    public class ItemModelBase
    {
        public override string ToString()
        {
            return NameKey;
        }
        public ItemModelBase(string nameKey)
        {
            NameKey = nameKey;            
        }

        public string NameKey { get; set; }
        
        public string Analysis { get; set; }
    }
}
