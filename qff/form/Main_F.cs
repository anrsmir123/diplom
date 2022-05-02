using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Drawing.Printing;
using System.Net.Sockets;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;

namespace qff
{
    public partial class Main_F : Form
    {
        string number_phone = "************";
        string token = "************";
		//тут идет номер и токен от киви(https://qiwi.com/api)
        public Main_F(string id_users)
        {
            InitializeComponent();
            label13.Text = id_users;
            UpDate();
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
            DateTime dt = DateTime.Now;
            dateTimePicker2.Value = dt.AddDays(1);
        }
        void UpDate()
        {
            mysql ms = new mysql();
            string sq = "SELECT * FROM `lock_internet` WHERE `id_user` = " + label13.Text + " and data_1 <= '" + DateTime.Now.ToString("yyyy.MM.dd")
                + "' and data_2 >= '" + DateTime.Now.ToString("yyyy.MM.dd") + "'";
            if (ms.checkZap(sq))
            {
                label18.Visible = true;
                Main_menu.Enabled = false;
                button5.Enabled = false;
                button13.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                button4.Enabled = false;
                button10.Enabled = false;
                button12.Enabled = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker1.Visible = false;
                label16.Visible = false;
                label17.Visible = false;

            }
            sq = "SELECT * FROM `users` WHERE `id_user` = " + label13.Text + " and balance = 0";
            if (ms.checkZap(sq))
            {
                label19.Visible = true;
                Main_menu.Enabled = false;
                button5.Enabled = false;
                button13.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                button4.Enabled = false;
                button10.Enabled = false;
                button12.Enabled = false;
                button5.Enabled = true;
            }
            DateTime moment = DateTime.Now;
            int year = moment.Year;
            int month = moment.Month;
            int days = DateTime.DaysInMonth(year, month);
            object FIO, Telephon, Emaile, Adres, balance, Cena_Mes, Name_Tarif;
            string sd = ms.GetReaderDB("SELECT * FROM `users` WHERE `id_user` = " + label13.Text, "SELECT * FROM `users`,`zakaz`,`tariff` where zakaz.id_user = " + label13.Text + " and users.id_user = zakaz.id_user and tariff.ID_Tarif = zakaz.ID_Tarif");
            FIO = sd.Split(':')[0];
            Telephon = sd.Split(':')[1];
            Emaile = sd.Split(':')[2];
            Adres = sd.Split(':')[3];
            balance = sd.Split(':')[4];
            Cena_Mes = sd.Split(':')[5];
            Name_Tarif = sd.Split(':')[6];
            string day_spis = Convert.ToString(Convert.ToInt32(Cena_Mes) / days);//ежедневное списание
            double kolvo_opl_day = Convert.ToInt32(balance)/ Convert.ToInt32(day_spis);
            DateTime date = moment.AddDays(kolvo_opl_day);
            string data_do_end = date.Day + "." + date.Month + "." + date.Year;
            label3.Text = data_do_end;
            richTextBox1.Text = @"Тариф: " + Name_Tarif + @"
Стоимость: " + Cena_Mes + @"руб в " + days + @" дней
Оплата: ежедневное списание в размере " + day_spis + @" руб
Владелец: " + FIO + Environment.NewLine + "Адрес: " + Adres;
            label7.Text = Telephon.ToString();
            label2.Text = balance.ToString() + " руб";
            label9.Text = Emaile.ToString();
            label14.Text = Name_Tarif.ToString();
            int rec_plat = Convert.ToInt32(Cena_Mes) - Convert.ToInt32(balance);
            if (rec_plat < 0)
            {

            }
            label5.Text = rec_plat + " рублей.";
        }
        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }

        private void Main_menu_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button12.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            button8.Visible = true;
            button4.Visible = true;
            button10.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            richTextBox1.Visible = false;
            richTextBox2.Visible = false;
            richTextBox3.Visible = false;

            numericUpDown1.Visible = false;
            label11.Visible = false;
            button11.Visible = false;
            label12.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button12.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            button8.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            richTextBox1.Visible = false;
            richTextBox2.Visible = false;
            richTextBox3.Visible = false;

            numericUpDown1.Visible = true;
            label11.Visible = true;
            button11.Visible = true;
            label12.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оплатите в открывшимся окне, платеж будет зачислен автоматически.");
            Process.Start("https://qiwi.com/payment/form/99?extra%5B%27account%27%5D=79953970845&amountInteger="+numericUpDown1.Value+"&amountFraction=0&extra%5B%27comment%27%5D=1764449933&currency=643&blocked[1]=comment&blocked[2]=account");
            Thread th = new Thread(check_history);
            
        }


        void check_history()
        {
            while (true)
            {
                WebRequest request = WebRequest.Create("https://edge.qiwi.com/payment-history/v2/persons/" + number_phone + "/payments?rows=5");//создаём новый объект WebRequest, который будет отправлять запрос по указанному url
                request.Headers.Add("Authorization", "Bearer " + token);
                request.ContentType = "application/json";
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                dynamic stuff = JsonConvert.DeserializeObject(responseFromServer);
                bool bl = false;
                for (int i = 0; i < 5; i++)
                {
                    string cena = Convert.ToString(stuff.data[i].sum.amount);
                    if (Convert.ToString(numericUpDown1.Value) == cena)
                    {
                        mysql ms = new mysql();
                        ms.cance_balance(label13.Text, Convert.ToInt32(numericUpDown1.Value));
                        bl = true;
                    }
                }
                if (bl == true)
                {
                    UpDate();
                    string d1 = DateTime.Now.ToString("yyyy-MM-dd");
                    mysql ms = new mysql();
                    ms.Add_Rows_Data_Opl(numericUpDown1.Value + "", d1, label13.Text);
                    MessageBox.Show("Баланс пополнен.");

                    break;
                }
            }
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button12.Visible = false;
            label14.Visible = false;
            label15.Visible = false; 
            button8.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            numericUpDown1.Visible = false;
            label11.Visible = false;
            button11.Visible = false;
            richTextBox2.Visible = false;
            richTextBox3.Visible = false;
            label12.Visible = false;

            richTextBox1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button14.Visible = false; 
            label16.Visible = false;
            label17.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button12.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            button8.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            numericUpDown1.Visible = false;
            label11.Visible = false;
            button11.Visible = false;
            richTextBox3.Visible = false;
            richTextBox1.Visible = false;
            richTextBox2.Visible = true;
            label12.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            button12.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            button8.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            numericUpDown1.Visible = false;
            label11.Visible = false;
            button11.Visible = false;
            richTextBox2.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = true;
            label12.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Main_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Chance_ chance_ = new Chance_(label13.Text,"number", label7);
            chance_.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Chance_ chance_ = new Chance_(label13.Text, "email",label9);
            chance_.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string result = label1.Text + " " + label2.Text + "\n"  + label4.Text + " " + label3.Text + "\n" + label6.Text + " " + label5.Text
               + "\n" + label8.Text + " " + label7.Text + "\n" + label10.Text + " " + label9.Text + "\n"+richTextBox1.Text;

            stringToPrint = result;
            documentContents = result;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private string stringToPrint;
        private string documentContents; private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        private void button12_Click(object sender, EventArgs e)
        {
            Chance_Tarif chance = new Chance_Tarif(label13.Text,label14);
            chance.ShowDialog();
            UpDate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button14.Visible = true;
            button12.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            button8.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            numericUpDown1.Visible = false;
            label11.Visible = false;
            button11.Visible = false;
            richTextBox2.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            label12.Visible = false;
            label16.Visible = true;
            label17.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string d1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string d2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            mysql ms = new mysql();
            if (!ms.checkZap("SELECT * FROM `lock_internet` WHERE `id_user` = " + label13.Text))
            {
                ms.BlockInternet(label13.Text, d1, d2);
                UpDate();
                MessageBox.Show("Вы заблокировали интернет от " + dateTimePicker1.Value + " до " + dateTimePicker2.Value);
            }
            else
            {
                MessageBox.Show("У вас уже стоит бронь на блокирование интернета.");
            }
        }

        private void Main_F_Load(object sender, EventArgs e)
        {

        }
    }
}
