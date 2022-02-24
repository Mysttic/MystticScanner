using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsConsole
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string item)
        {            
            InitializeComponent();
            var items = item.Split(' ');
            textBox1.Text = item.Replace(items[items.Count() - 1], "");
            textBox2.Text = items[items.Count() - 1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";            
            string result = Tools.VTInteractive.GetAnalysis(textBox2.Text);
            Task.Delay(1000);
            textBox3.Text = result.Replace("\n","\r\n");
        }
    }
}
