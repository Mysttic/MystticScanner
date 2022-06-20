using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MystticScanner.Models;

namespace MystticScanner
{
    public partial class ItemModelForm : Form
    {
        public ItemModelForm()
        {
            InitializeComponent();
        }
        private ItemModel ItemModel;
        public ItemModelForm(ItemModel itemModel)
        {            
            InitializeComponent();
            ItemModel = itemModel;
            textBox2.Text = itemModel.Name;
            textBox1.Text = itemModel.Key;
            richTextBox1.Text = itemModel.Analysis;
            this.Text = Path.GetFileName(itemModel.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";            
            string result = Tools.VTInteractive.GetAnalysis(textBox1.Text);
            Task.Delay(1000);
            ItemModel.Analysis = result;
            richTextBox1.Text = result.Replace("\n","\r\n");
            Tools.Colors.ColorAllRichTextBoxFragment(ref richTextBox1);
            Task.Delay(1000);
        }

    }
}
