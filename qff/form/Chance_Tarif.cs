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
    public partial class Chance_Tarif : Form
    {
        static Label lb;
        public Chance_Tarif(string id_, Label lbs)
        {
            InitializeComponent();
            label2.Text = id_;
            lb = lbs;
            mysql ms = new mysql();
            comboBox1 = ms.ComboBoxLoadInfo_Tarif(comboBox1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                mysql ms = new mysql();
                ms.Update_Tarif(label2.Text, comboBox1.Text);
                MessageBox.Show(label1.Text + " сменился");
                lb.Text = comboBox1.Text;
                this.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mysql ms = new mysql();
            textBox1.Text = ms.Get_Money_Tarif(comboBox1.Text);
        }
    }
}
