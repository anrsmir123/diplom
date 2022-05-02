using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace qff
{
    public partial class Admin_F : Form
    {
        private string stringToPrint;
        private string documentContents; private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();


        public Admin_F(string adm)
        {
           
            InitializeComponent();
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            dateTimePicker2.Value = DateTime.Today;
            richTextBox1.Text += adm;
            mysql ms = new mysql();
            dataGridView1 = ms.dm(dataGridView1, "SELECT Cena_Mes as 'Цена в месяц',Name_Tarif as 'Наименование тарифа' FROM `tariff`, `server`, `provader`, `predstavitel` where tariff.ID_server_tarif = server.ID_Server_Tarif and server.ID_Provader = provader.ID_Provader and" +
            " provader.id_predstavitel = predstavitel.id_predstavitel");
            dataGridView5 = ms.dm(dataGridView5, "SELECT Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', Emaile as 'Email', Adres as 'Адрес', balance as 'Баланс' FROM `delete_users`,`users` where users.id_user = delete_users.id_user ");
            dataGridView3 = ms.dm(dataGridView3, "SELECT Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', Emaile as 'Email', Adres as 'Адрес', balance as 'Баланс' FROM `users` where balance = '0'");
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
            comboBox1 = ms.ComboBoxLoadInfo_Tarif(comboBox1);
        }
        private void button7_Click(object sender, EventArgs e)
        {

            label12.Visible = false;
            label11.Visible = false;
            dataGridView7.Visible = false; 
            dataGridView4.Visible = false;
            button17.Visible = false;
            checkBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dataGridView6.Visible = false;
            mysql ms = new mysql();
            dataGridView2 = ms.dm(dataGridView2, "SET sql_mode = '';SELECT DISTINCT  Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', Emaile as 'Email', Adres as 'Адрес', balance as 'Баланс', Name_Tarif as 'Наименование тарифа', Cena_Mes as 'Цена в месяц' FROM `users`,`tariff`,`zakaz`, `delete_users` where zakaz.ID_Tarif = tariff.ID_Tarif and users.id_user = zakaz.id_user and balance <> '0' AND delete_users.id_user <> users.id_user  GROUP BY delete_users.id_, users.id_user");
            button4.Visible = false;
            button8.Visible = true;
            button10.Visible = true;
            dataGridView2.Visible = true;
            richTextBox1.Visible = false;
            dataGridView1.Visible = false;
            New_User.Visible = false;
            richTextBox3.Visible = false;
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;
            dataGridView4.Visible = false;
        }

        private void Main_menu_Click(object sender, EventArgs e)
        {

            label12.Visible = false;
            label11.Visible = false; 
            dataGridView7.Visible = false;
            dataGridView4.Visible = false;
            button17.Visible = false;
            checkBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dataGridView6.Visible = false;
            dataGridView2.Visible = false;
            richTextBox1.Visible = true;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            dataGridView1.Visible = false;
            richTextBox3.Visible = false;
            dataGridView1.Visible = false;
            New_User.Visible = false;
            richTextBox3.Visible = false;
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            label12.Visible = false;
            label11.Visible = false;
            dataGridView7.Visible = false;
            dataGridView4.Visible = false; 
            button17.Visible = false;
            checkBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dataGridView6.Visible = false; 
            richTextBox3.Visible = true;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            New_User.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            label12.Visible = false;
            label11.Visible = false;
            dataGridView7.Visible = false; 
            dataGridView4.Visible = false;
            button17.Visible = false;
            checkBox1.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false; 
            dataGridView6.Visible = false;
            dataGridView1.Visible = true;
            New_User.Visible = false;
            button4.Visible = false;
            button8.Visible = false;
            button4.Visible = true;
            button10.Visible = false;
            
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;
            dataGridView2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            label12.Visible = false;
            label11.Visible = false;
            dataGridView7.Visible = false;
            dataGridView4.Visible = false;
            button17.Visible = false;
            checkBox1.Visible = false; 
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dataGridView6.Visible = false;
            New_User.Visible = true;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;
        }

        private void Admin_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

            label12.Visible = false;
            label11.Visible = false;
            dataGridView7.Visible = false; 
            dataGridView4.Visible = false;
            button17.Visible = true;
            checkBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dataGridView6.Visible = false; 
            dataGridView3.Visible = true;
            New_User.Visible = false;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            dataGridView5.Visible = false;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            mysql ms = new mysql();

            string result = ms.GetUserOtchetDB(checkBox1.Checked);
            stringToPrint = result;
            documentContents = result;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2(dataGridView2);
            fm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            string fam = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            string ima = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            string otc = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            mysql ms = new mysql();
            ms.delete_user(fam, ima,otc, dataGridView2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView4.Visible = false;
            button17.Visible = false;
            checkBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dataGridView3.Visible = false;
            New_User.Visible = false;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            dataGridView4.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = true;
            mysql ms = new mysql();
            dataGridView7 = ms.dm(dataGridView7, "SELECT Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', Emaile as 'Email', Adres as 'Адрес', balance as 'Баланс' FROM `delete_users`,`users` where users.id_user = delete_users.id_user");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить эту запись?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                mysql ms = new mysql();
                ms.Add_Rows(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text
                    , textBox7.Text, textBox8.Text, Convert.ToString(numericUpDown1.Value), comboBox1.Text);
                MessageBox.Show("Пользователь добавлен");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                numericUpDown1.Value = 0;
                comboBox1.Text = "";
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите очистить форму?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                numericUpDown1.Value = 0;
                comboBox1.Text = null;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            label12.Visible = false;
            label11.Visible = false;
            dataGridView7.Visible = false;
            dataGridView4.Visible = false;
            button17.Visible = false;
            checkBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false; 
            dataGridView3.Visible = false;
            New_User.Visible = false;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            dataGridView4.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = true;
            mysql ms = new mysql();
            dataGridView6 = ms.dm(dataGridView6, "SELECT  tariff.Name_Tarif as 'Наименование тарифа', tariff.Cena_Mes as 'Цена в месяц', COUNT(*) as 'Количество подключенных' FROM zakaz,tariff where zakaz.ID_Tarif = tariff.ID_Tarif GROUP BY tariff.ID_Tarif ");

        }

        private void button16_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label11.Visible = true;
            dataGridView7.Visible = false;
            dataGridView4.Visible = false;
            button17.Visible = false;
            checkBox1.Visible = false; 
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            dataGridView3.Visible = false;
            New_User.Visible = false;
            button4.Visible = false;
            button8.Visible = false;
            button10.Visible = false;
            dataGridView4.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            mysql ms = new mysql();
            dataGridView4 = ms.dm(dataGridView4, "SELECT data_opl as 'Дата оплаты', data_opl.balance as 'Пополнение',  Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', users.balance as 'Текущий баланс' FROM `data_opl`, `users` where data_opl.id_user = users.id_user");

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string d1 = dateTimePicker1.Value.ToString("yyyy.MM.dd");
            string d2 = dateTimePicker2.Value.ToString("yyyy.MM.dd");
            mysql ms = new mysql();
            dataGridView4 = ms.dm(dataGridView4, "SET sql_mode = ''; SELECT data_opl as 'Дата оплаты', data_opl.balance as 'Пополнение', Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', users.balance as 'Текущий баланс' FROM `data_opl`, `users` where data_opl.id_user = users.id_user and `data_opl` <= '" + d2+"' AND `data_opl` >= '"+d1+"' GROUP BY users.id_user");

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string d1 = dateTimePicker1.Value.ToString("yyyy.MM.dd");
            string d2 = dateTimePicker2.Value.ToString("yyyy.MM.dd");
            mysql ms = new mysql();
            dataGridView4 = ms.dm(dataGridView4, "SET sql_mode = ''; SELECT data_opl as 'Дата оплаты', data_opl.balance as 'Пополнение', Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', users.balance as 'Текущий баланс' FROM `data_opl`, `users` where data_opl.id_user = users.id_user and `data_opl` <= '" + d2 + "' AND `data_opl` >= '" + d1 + "' GROUP BY users.id_user");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mysql ms = new mysql();
            if (checkBox1.Checked)
            {
                dataGridView1 = ms.dm(dataGridView1, "SELECT Cena_Mes as 'Цена в месяц',Name_Tarif as 'Наименование тарифа', name_server as 'Наименование сервера',ip_server as 'IP сервера', Name_provadeer as 'Провайдер', provader.INN as 'ИНН', Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество',NumberPhone as 'Номер телефона' FROM `tariff`, `server`, `provader`, `predstavitel` where tariff.ID_server_tarif = server.ID_Server_Tarif and server.ID_Provader = provader.ID_Provader and" +
                    " provader.id_predstavitel = predstavitel.id_predstavitel");
            }
            else
            {
                dataGridView1 = ms.dm(dataGridView1, "SELECT Cena_Mes as 'Цена в месяц',Name_Tarif as 'Наименование тарифа' FROM `tariff`, `server`, `provader`, `predstavitel` where tariff.ID_server_tarif = server.ID_Server_Tarif and server.ID_Provader = provader.ID_Provader and" +
                " provader.id_predstavitel = predstavitel.id_predstavitel");
            }
            
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            
            SendEmailAsync(dataGridView3.SelectedRows[0].Cells[4].Value, dataGridView3.SelectedRows[0].Cells[0].Value + " " + dataGridView3.SelectedRows[0].Cells[1].Value + " " + dataGridView3.SelectedRows[0].Cells[2].Value);

        }
        private static void SendEmailAsync(object email, string FIO)
        {
            string login = "***********", password = "******";//логин пароль от почты(яндекс)
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(login);
            // кому отправляем
            MailAddress to = new MailAddress(email + "");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "ВЕЛЬТЕЛЕКОМ";
            // текст письма
            m.Body = "<h2>Здравствуйте "+FIO+"</h2><br>У вас имеется задолженность по тарифу. Просим оплатить Вас счёт или написать заявление на отключение, если вы не собираетесь пользоваться нашими услугами.";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(login, password);
            smtp.EnableSsl = true;
            smtp.Send(m);
            MessageBox.Show("Письмо отправлено.");
        }

        private void Admin_F_Load(object sender, EventArgs e)
        {

        }
    }
}
