using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qff
{
    class mysql
    {
        const string host = "127.0.0.1", database = "veltelecom", username = "mysql", password = "mysql";

        #region подключение к базе
        static MySqlConnection GetDBConnection()
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                +  ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
        #endregion

        #region изменение баланса(cance_balance)
        public void cance_balance(string id_, int add_bal)
        {
            int new_balance = Convert.ToInt32(check_balance(id_)) + add_bal;
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            MySqlCommand com = new MySqlCommand(
                "UPDATE `users` SET `balance` = '"+ new_balance + "' WHERE `users`.`id_user` = "+id_+";", ms);
            com.ExecuteNonQuery();
            ms.Close();
        }
        string check_balance(string id_)
        {
            MySqlConnection conn = GetDBConnection();
            string inns = "";
            string sql = "SELECT balance FROM `users` WHERE `users`.`id_user` = " + id_ + ";";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                inns = reader[0].ToString();
            }
            reader.Close();
            conn.Close();
            return inns;
        }
        #endregion

        #region Добавление записи в data_Opl
        public void Add_Rows_Data_Opl(string balance, string date1, string ID_)
        {
            //INSERT INTO `data_opl` (`id_opl`, `id_user`, `data_opl`, `balance`) VALUES (NULL, '3', '2021-06-02', '50');
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            MySqlCommand com = new MySqlCommand("INSERT INTO `data_opl` (`id_opl`, `id_user`, `data_opl`, `balance`) VALUES (NULL, '"+ ID_ + "', '"+ date1 + "', '"+balance+"');", ms);
            com.ExecuteNonQuery();
            ms.Close();
        }
        #endregion

        #region обновление информации о юзере (Update_Email_Or_NumPhone)
        public void UpdateInfoUser(string fam, string ima, string otchestvo, string login, string password, string number_phone, 
            string email, string Adres, string balance, DataGridView dt)
        {
            string id_FIO = Get_ID_FIO(fam, ima, otchestvo);
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            MySqlCommand com = new MySqlCommand(
                "UPDATE `users` SET `Telephon`='" + number_phone + "',`Emaile`='" + email + "',`Adres`='" + Adres + "',`balance`='" + balance +"' WHERE `users`.`id_user` = " + id_FIO + "; " , ms);
            com.ExecuteNonQuery();
            com = new MySqlCommand(
                            "UPDATE `login_` SET `login_` = '"+login+"',`passwords` = '"+password+"' WHERE `login_`.`id_user` = " + id_FIO + "; " , ms);
            com.ExecuteNonQuery();

            ms.Close();
            dm(dt, "SET sql_mode = '';SELECT Familia as 'Фамилия', Ima, Otchestvo, Telephon, Emaile, Adres, balance, Name_Tarif, Cena_Mes FROM `users`,`tariff`,`zakaz` where zakaz.ID_Tarif = tariff.ID_Tarif and users.id_user = zakaz.id_user GROUP BY users.id_user ");
        }
        #endregion

        #region обновление тарифа (Update_Tarif)
        public void Update_Tarif(string id, string texts)
        {
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            MySqlCommand com = new MySqlCommand(
            "UPDATE `zakaz` SET `ID_Tarif` = '" + Get_ID_Tarif(texts) + "' WHERE `zakaz`.`id_user` = " + id, ms);
            com.ExecuteNonQuery();
            ms.Close();

        }
        #endregion

        #region обновление email/номера телефона (Update_Email_Or_NumPhone)
        public void Update_Email_Or_NumPhone(string types, string id, string texts)
        {
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            if (types == "email")
            {
                MySqlCommand com = new MySqlCommand(
                "UPDATE `users` SET `Emaile` = '" + texts + "' WHERE `users`.`id_user` = " + id, ms);
                com.ExecuteNonQuery();
            }
            else
            {
                MySqlCommand com = new MySqlCommand(
                "UPDATE `users` SET `Telephon` = '" + texts + "' WHERE `users`.`id_user` = " + id, ms);
                com.ExecuteNonQuery();
            }
            ms.Close();

        }
        #endregion

        #region проверка логина и пароля у пользователя (CheckLoginPassword)
        public string CheckLoginPassword(string login, string password)
        {
            MySqlConnection conn = GetDBConnection();
            string inns = "0111";
            string sql = "SELECT * FROM `login_` WHERE `login_` = '" + login + "' AND `passwords` = '"+ password + "'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                inns = reader[3].ToString();
            }
            reader.Close();
            conn.Close();
            return inns;
        }
        #endregion

        #region сверка логина и пароля администратора (CheckLoginPasswordAdm) и вывод информации об админе (GetReaderDB_Admin)
        public string CheckLoginPasswordAdm(string login, string password)
        {
            MySqlConnection conn = GetDBConnection();
            string inns = "0121";
            string sql = "SELECT * FROM `admin` WHERE `login_` = '" + login + "' AND `password_` = '" + password + "'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                inns = reader[0].ToString();
            }
            reader.Close();
            conn.Close();
            if (inns != "0121")
            {
                inns = GetReaderDB_Admin(inns);
            }
            return inns;
        }
        
        string GetReaderDB_Admin(string id)
        {
            string zapros = "SELECT * FROM `admin` where id_ = "+ id;
            string reader = "";
            MySqlConnection conn = GetDBConnection();
            string sql = zapros;
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reades = command.ExecuteReader();

            while (reades.Read())
            {
                reader = reades[3] + " " + reades[4] + " " + reades[5];
            }
            reades.Close();
            conn.Close();
            return reader;
        }
        #endregion

        #region вывод в DataGridView (dm)
        public DataGridView dm(DataGridView dv, string zapros)
        {
            BindingSource bs1 = new BindingSource();
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            MySqlCommand com = new MySqlCommand(zapros, ms); //исполнение запроса 
            MySqlDataAdapter dba = new MySqlDataAdapter(com);
            DataTable table1 = new DataTable("");
            dba.Fill(table1);
            bs1.DataSource = table1;
            dv.DataSource = bs1;
            dv.Update();
            ms.Close();
            return dv;
        }
        #endregion

        #region получение строки с информацией о пользователе (GetReaderDB)
        public string GetReaderDB(string zapros, string sql1)
        {
            object Familia, Ima, Otchestvo,Telephon, Emaile, Adres, balance, Name_Tarif, Cena_Mes;
            string reader = "";
            MySqlConnection conn = GetDBConnection();
            string sql = zapros;
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reades = command.ExecuteReader();

            while (reades.Read())
            {
                Familia = reades[1];
                Ima = reades[2];
                Otchestvo = reades[3];
                Telephon = reades[4];
                Emaile = reades[5];
                Adres = reades[6];
                balance = reades[7];
                reader = Familia + " " + Ima + " " + Otchestvo + ":" + Telephon + ":" + Emaile + ":" + Adres + ":" + balance;
            }
            reades.Close();

            command = new MySqlCommand(sql1, conn);
            reades = command.ExecuteReader();

            while (reades.Read())
            {
                Cena_Mes = reades[13];
                Name_Tarif = reades[14];
                reader += ":" + Cena_Mes + ":" + Name_Tarif;
            }
            reades.Close();

            conn.Close();
            return reader;
        }
        #endregion

        #region Вывод информации на отчет(GetUserOtchetDB)
        public string GetUserOtchetDB(bool bbbs)
        {
            object Familia, Ima, Otchestvo, Telephon, inn, Adres, balance, Name_Tarif, Cena_Mes;
            if (bbbs)
            {
                string sql = "SELECT Cena_Mes,Name_Tarif, name_server,ip_server, Name_provadeer, provader.INN, Familia  as 'Фамилия', Ima, Otchestvo, NumberPhone, predstavitel.Inn FROM `tariff`, `server`, `provader`, `predstavitel` where tariff.ID_server_tarif = server.ID_Server_Tarif and server.ID_Provader = provader.ID_Provader and" +
                " provader.id_predstavitel = predstavitel.id_predstavitel";
                string reader = "";
                MySqlConnection conn = GetDBConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reades = command.ExecuteReader();

                while (reades.Read())
                {
                    Familia = reades[6];
                    Ima = reades[7];
                    Otchestvo = reades[8];
                    Telephon = reades[9];
                    inn = reades[10];
                    Adres = reades[3];
                    balance = reades[2];
                    Name_Tarif = reades[1];
                    Cena_Mes = reades[0];
                    reader += Familia + " " + Ima + " " + Otchestvo + " Телефон: " + Telephon + " Инн: " + inn + " IP-адрес сервера: " + Adres + " Имя сервера: " + balance + " Наименование тарифа:" + Name_Tarif + " Цена в месяц: " + Cena_Mes + "руб.\n\n";
                }
                reades.Close();
                conn.Close();
                return reader;
            }
            else
            {
                string sql = "SELECT Cena_Mes,Name_Tarif, name_server,ip_server, Name_provadeer, provader.INN, Familia  as 'Фамилия', Ima, Otchestvo, NumberPhone, predstavitel.Inn FROM `tariff`, `server`, `provader`, `predstavitel` where tariff.ID_server_tarif = server.ID_Server_Tarif and server.ID_Provader = provader.ID_Provader and" +
               " provader.id_predstavitel = predstavitel.id_predstavitel";
                string reader = "";
                MySqlConnection conn = GetDBConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reades = command.ExecuteReader();

                while (reades.Read())
                {
                    Name_Tarif = reades[1];
                    Cena_Mes = reades[0];
                    reader +="Наименование тарифа:" + Name_Tarif + " Цена в месяц: " + Cena_Mes + "руб.\n\n";
                }
                reades.Close();
                conn.Close();
                return reader;
            }
            
        }
        #endregion

        #region загрузка информации в комбобокс по ФИО (ComboBoxLoadInfo_FIO)
        public ComboBox ComboBoxLoadInfo_FIO(ComboBox dvs, string zapros)
        {
            MySqlConnection ms = GetDBConnection();

            ms.Open();
            MySqlCommand command = new MySqlCommand(zapros, ms);

            MySqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                dvs.Items.Add(reader[0] + " " + reader[1] + " " + reader[2]);
            }

            // Call Close when done reading.
            reader.Close();
            ms.Close();

            return dvs;
        }
        #endregion

        #region загрузка информации в комбобокс по тарифам (ComboBoxLoadInfo_Tarif)
        public ComboBox ComboBoxLoadInfo_Tarif(ComboBox dvs)
        {
            MySqlConnection ms = GetDBConnection();

            ms.Open();
            MySqlCommand command = new MySqlCommand("SELECT Name_Tarif FROM `tariff`", ms);

            MySqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                dvs.Items.Add(reader[0]);
            }

            // Call Close when done reading.
            reader.Close();
            ms.Close();

            return dvs;
        }
        #endregion

        #region Обновление тарифа (Update_Tarif)
        public void Update_Tarif(string fam, string ima, string otchestvo, string name_tarif, Form fm, DataGridView dw)
        {
            string id_tarif = Get_ID_Tarif(name_tarif);
            string id_FIO = Get_ID_FIO(fam, ima, otchestvo);
            bool ch = check_zap("SELECT * FROM `zakaz` where id_user = " + id_FIO);
            MessageBox.Show(Convert.ToString(ch));
            if (ch)
            {
                MySqlConnection ms = GetDBConnection();
                ms.Open();
                MySqlCommand com = new MySqlCommand("UPDATE `zakaz` SET `ID_Tarif` = '" + id_tarif + "' WHERE `id_user` = " + id_FIO + ";", ms); //исполнение запроса 
                com.ExecuteNonQuery();
                ms.Close();
            }
            else
            {
                MySqlConnection ms = GetDBConnection();
                ms.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO `zakaz` (`Id_zakaz`, `id_user`, `ID_Tarif`) VALUES (NULL, '"+ id_FIO + "', '"+ id_tarif+"');", ms); //исполнение запроса 
                com.ExecuteNonQuery();
                ms.Close();
            }
            dm(dw, "SET sql_mode = '';SELECT DISTINCT  Familia as 'Фамилия', Ima as 'Имя', Otchestvo as 'Отчество', Telephon as 'Телефон', Emaile as 'Email', Adres as 'Адрес', balance as 'Баланс', Name_Tarif as 'Наименование тарифа', Cena_Mes as 'Цена в месяц' FROM `users`,`tariff`,`zakaz`, `delete_users` where zakaz.ID_Tarif = tariff.ID_Tarif and users.id_user = zakaz.id_user and balance <> '0' AND delete_users.id_user <> users.id_user  GROUP BY delete_users.id_, users.id_user");
        
        }
        #endregion

        #region заметка на удаление(delete_user)
        public void delete_user(string fam, string ima, string otchestvo, DataGridView dw)
        {
            string id_FIO = Get_ID_FIO(fam, ima, otchestvo);
            if (true)
            {
                MySqlConnection ms = GetDBConnection();
                ms.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO `delete_users` (`id_`, `id_user`) VALUES (NULL, '" + id_FIO + "');", ms); //исполнение запроса 
                com.ExecuteNonQuery();
                ms.Close();
            }
            dm(dw, "SET sql_mode = '';SELECT Familia  as 'Фамилия', Ima, Otchestvo, Telephon, Emaile, Adres, balance, Name_Tarif, Cena_Mes FROM `users`,`tariff`,`zakaz` where zakaz.ID_Tarif = tariff.ID_Tarif and users.id_user = zakaz.id_user and balance <> '0' GROUP BY users.id_user ");

        }
        #endregion

        #region проверка на наличии записи по заданому запросу (check_zap)
        bool check_zap(string zapros)
        {
            bool ch = false;
            MySqlConnection ms = GetDBConnection();

            ms.Open();
            MySqlCommand command = new MySqlCommand(zapros, ms);

            MySqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                ch = true;
                break;
            }

            // Call Close when done reading.
            reader.Close();
            ms.Close();

            return ch;
        }
        #endregion

        #region добавление записи юзера (Add_Rows)
        public void Add_Rows(string F, string I, string O, string L, string P, string T, string E, string A, string B, string T_N)
        {
            string id_Tarif = Get_ID_Tarif(T_N);
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            bool bl = false;
            string sql = "SELECT * FROM `users` WHERE `Telephon` = '" + T + "' OR `Emaile` = '" + E + "'";
            MySqlCommand command = new MySqlCommand(sql, ms);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bl = true;
                break;
            }
            ms.Close();
            if (bl)
            {
                MessageBox.Show("С таким номером или Email уже есть аккаунт");
            }
            else
            {
                ms.Open();
                bool bl1 = false;
                sql = "SELECT * FROM `login_` WHERE `login_` = '" + T + "'";
                command = new MySqlCommand(sql, ms);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bl1 = true;
                    break;
                }
                ms.Close();
                if (bl1)
                {
                    MessageBox.Show("Данный логин занят.");
                }
                else
                {
                    ms.Open();
                    MySqlCommand com = new MySqlCommand("INSERT INTO `users` (`id_user`, `Familia`, `Ima`, `Otchestvo`, `Telephon`, `Emaile`, `Adres`, `balance`) VALUES (NULL, '" + F + "', '" + I + "', '" + O + "', '" + T + "', '" + E + "', '" + A + "', '" + B + "');", ms);
                    com.ExecuteNonQuery();
                    string id_FIO = Get_ID_FIO(F, I, O);

                    com = new MySqlCommand("INSERT INTO `zakaz` (`Id_zakaz`, `id_user`, `ID_Tarif`) VALUES (NULL, '" + id_FIO + "', '" + id_Tarif + "');", ms);
                    com.ExecuteNonQuery();

                    com = new MySqlCommand("INSERT INTO `login_` (`id_login`, `login_`, `passwords`, `id_user`) VALUES (NULL, '" + L + "', '" + P + "', '" + id_FIO + "');", ms);
                    com.ExecuteNonQuery();
                    ms.Close();
                }
            }
        }
        #endregion

        #region Получение цены тарифа(Get_Money_Tarif)
        public string Get_Money_Tarif(string name_tarif)
        {
            string Cena = "";
            MySqlConnection ms = GetDBConnection();

            ms.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tariff` where Name_Tarif = '" + name_tarif + "'", ms);

            MySqlDataReader reader = command.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                Cena = Convert.ToString(reader[2]);
            }

            // Call Close when done reading.
            reader.Close();
            ms.Close();
            return Cena;
        }
        #endregion

        #region проверка записи на существование
        public bool checkZap(string zapros)
        {
            return check_zap(zapros);
        }
        #endregion

        #region Блокировка интернета
        public void BlockInternet(string userID, string d1, string d2)
        {
            MySqlConnection ms = GetDBConnection();
            ms.Open();
            MySqlCommand com = new MySqlCommand("INSERT INTO `lock_internet` (`id_Lock`, `data_1`, `data_2`, `id_user`) VALUES (NULL, '"+d1+"', '"+ d2 + "', '"+userID+"');", ms);
            com.ExecuteNonQuery();
            ms.Close();
        }
        #endregion

        #region получение ID тарифа (Get_ID_Tarif)
        string Get_ID_Tarif(string name_tarif)
        {
            MySqlConnection ms = GetDBConnection();

            ms.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tariff` where Name_Tarif = '" + name_tarif + "'", ms);

            MySqlDataReader reader = command.ExecuteReader();
            string id_tarif = "";
            // Call Read before accessing data.
            while (reader.Read())
            {
                id_tarif = Convert.ToString(reader[0]);
            }

            // Call Close when done reading.
            reader.Close();
            ms.Close();
            return id_tarif;
        }
        #endregion

        #region получение ID ФИО (Get_ID_FIO)
        string Get_ID_FIO(string fam, string ima, string otchestvo)
        {
            MySqlConnection ms = GetDBConnection();

            ms.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` where Familia = '" + fam + "' and Ima = '"+ima + "' and Otchestvo = '" + otchestvo+"'", ms);

            MySqlDataReader reader = command.ExecuteReader();
            string id_FIO = "";
            // Call Read before accessing data.
            while (reader.Read())
            {
                id_FIO = Convert.ToString(reader[0]);
            }

            // Call Close when done reading.
            reader.Close();
            ms.Close();
            return id_FIO;
        }
        #endregion

        #region Получение полной информации о пользователе (GetInfoUser)
        public string GetInfoUser(string fam, string ima, string otc)
        {
            string ID_FIO = Get_ID_FIO(fam, ima, otc);
            MySqlConnection ms = GetDBConnection();

            ms.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users`,`login_` where login_.id_user = users.id_user and users.id_user = " + ID_FIO, ms);

            MySqlDataReader reader = command.ExecuteReader();
            string All_Info = "";
            while (reader.Read())
            {
                All_Info = Convert.ToString(reader[4] + ";" + reader[5] + ";" + reader[6] + ";" + reader[7] + ";" + reader[9] + ";" + reader[10]);
            }

            // Call Close when done reading.
            reader.Close();
            ms.Close();
            return All_Info;
        }
        #endregion
    }
}
