using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qff
{
    public partial class Chance_ : Form
    {
        static Label lb;
        public Chance_(string id_, string types, Label lbs)
        {
            InitializeComponent();
            label1.Text = types;
            label2.Text = id_;
            button4.Text += types;
            lb = lbs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mysql ms = new mysql();
            ms.Update_Email_Or_NumPhone(label1.Text, label2.Text, textBox1.Text);
            MessageBox.Show(label1.Text + " сменился");
            lb.Text = textBox1.Text;
            this.Close();

        }

        private void Chance__Load(object sender, EventArgs e)
        {

        }
    }
}
