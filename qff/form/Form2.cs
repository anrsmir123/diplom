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
    public partial class Form2 : Form
    {
        DataGridView DataGridView;
        public Form2(DataGridView dw)
        {
            InitializeComponent();
            DataGridView = dw;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mysql ms = new mysql();
            comboBox1 = ms.ComboBoxLoadInfo_FIO(comboBox1, "SELECT Familia, Ima, Otchestvo from users");
            comboBox2 = ms.ComboBoxLoadInfo_Tarif(comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox2.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                numericUpDown1.Enabled = false;
            }
            else
            {
                comboBox2.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                numericUpDown1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (comboBox1.Text != "" && comboBox2.Text != "")
                {
                    string fam = comboBox1.Text.Split(' ')[0];
                    string ima = comboBox1.Text.Split(' ')[1];
                    string otc = comboBox1.Text.Split(' ')[2];
                    string name_tarif = comboBox2.Text;
                    mysql ms = new mysql();
                    ms.Update_Tarif(fam, ima, otc, name_tarif, this, DataGridView);
                    this.Hide();
                }
                else MessageBox.Show("Выберите ФИО и Тариф");
            }
            else
            {
                if (comboBox1.Text != "" && textBox4.Text != ""&& textBox5.Text != ""&& textBox6.Text != ""&& textBox7.Text != ""&& textBox8.Text != "")
                {
                    string fam = comboBox1.Text.Split(' ')[0];
                    string ima = comboBox1.Text.Split(' ')[1];
                    string otc = comboBox1.Text.Split(' ')[2];
                    string login = textBox4.Text;
                    string password = textBox5.Text;
                    string number_phone = textBox6.Text;
                    string email = textBox7.Text;
                    string Adres = textBox8.Text;
                    string balance = numericUpDown1.Value + "";
                    mysql ms = new mysql();
                    ms.UpdateInfoUser(fam, ima, otc, login, password, number_phone, email, Adres, balance, DataGridView);
                    this.Hide();
                }
                else MessageBox.Show("Введите все данные");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string fam = comboBox1.Text.Split(' ')[0];
            string ima = comboBox1.Text.Split(' ')[1];
            string otc = comboBox1.Text.Split(' ')[2];
            mysql ms = new mysql();
            string Info = ms.GetInfoUser(fam, ima, otc);
            textBox4.Text = Info.Split(';')[4];
            textBox5.Text = Info.Split(';')[5];
            textBox6.Text = Info.Split(';')[0];
            textBox7.Text = Info.Split(';')[1];
            textBox8.Text = Info.Split(';')[2];
            numericUpDown1.Value = Convert.ToInt64(Info.Split(';')[3]);
        }
    }
}
