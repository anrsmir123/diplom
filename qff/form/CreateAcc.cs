using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace qff
{
    public partial class CreateAcc : Form
    {
        string Login_Sms = "m0morty";
        string Password_Sms = "25172015";
        static string telephone;
        static string rand;

        public CreateAcc()
        {
            InitializeComponent();
            mysql ms = new mysql();
            comboBox1 = ms.ComboBoxLoadInfo_Tarif(comboBox1);
            Random rm = new Random();
            rand = rm.Next(1000, 9999) + " - ваш код для регистрации в приложении Вельтелеком";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (button2.Text == "Отправить смс")
                {
                    WebRequest reqGET = WebRequest.Create(@"https://smsc.ru/sys/send.php?login=" + Login_Sms + "&psw=" + Password_Sms + "&phones=" + textBox2 + "&mes=" + rand);
                    WebResponse resp = reqGET.GetResponse();
                    Stream stream = resp.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string s = sr.ReadToEnd();
                    telephone = textBox2.Text;
                    button2.Text = "Подтвердить код";
                    label6.Text = "Код подтверждения";
                    textBox2.Text = "";
                }
                else if (button2.Text == "Подтвердить код")
                {
                    if (rand.Split(' ')[0] == textBox2.Text)
                    {
                        panel1.Visible = true;
                        panel2.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Код был введен не правильно ");

                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" 
                && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && comboBox1.Text != "")
            {
                mysql ms = new mysql();
                ms.Add_Rows(textBox9.Text, textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text,telephone,textBox7.Text,textBox8.Text,"0",comboBox1.Text);
                MessageBox.Show("Вы успешно зарегистрировались. Приложение будет перезапущено.");
                Application.Restart();
            }
            else { MessageBox.Show("Введите все поля"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateAcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
