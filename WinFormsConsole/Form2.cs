using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsConsole.Models;

namespace WinFormsConsole
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ItemModel itemModel)
        {            
            InitializeComponent();
            textBox1.Text = itemModel.Name;
            textBox2.Text = itemModel.Key;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";            
            string result = Tools.VTInteractive.GetAnalysis(textBox2.Text);
            Task.Delay(1000);
            richTextBox1.Text = result.Replace("\n","\r\n");
            Tools.Colors.ColorAllRichTextBoxFragment(ref richTextBox1);
            Task.Delay(1000);
        }
    }
}
