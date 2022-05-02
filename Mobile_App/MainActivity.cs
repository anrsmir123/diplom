using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using System.Net.Http;
using System.Web;
using System.Net;

namespace Mobile_App
{
    [Activity(Label = "@ВЕЛЬТЕЛЕКОМ", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        const string ip_ = "192.168.1.213:81";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            TextView tw = (TextView)FindViewById(Resource.Id.textView4);
            tw.Visibility = ViewStates.Invisible;


            Button but_d_1 = FindViewById<Button>(Resource.Id.button1);
            but_d_1.Click += async delegate
            {
                EditText edit1 = (EditText)FindViewById(Resource.Id.editText1);
                EditText edit2 = (EditText)FindViewById(Resource.Id.editText2);
                TextView tw1 = (TextView)FindViewById(Resource.Id.textView1);
                TextView tw2 = (TextView)FindViewById(Resource.Id.textView2);

                string url = "http://"+ip_+"/?login=" + edit1.Text + "&pass=" + edit2.Text;
                // Создаём объект WebClient
                using (var webClient = new WebClient())
                {
                    // Выполняем запрос по адресу и получаем ответ в виде строки
                    var response = webClient.DownloadString(url);
                    if (response != "")
                    {
                        //Скрытие всех активных форм
                        //response
                        but_d_1.Visibility = ViewStates.Invisible;
                        edit1.Visibility = ViewStates.Invisible;
                        edit2.Visibility = ViewStates.Invisible;
                        tw1.Visibility = ViewStates.Invisible;
                        tw2.Visibility = ViewStates.Invisible;
                        tw.Visibility = ViewStates.Visible;
                        string fio, n, e, a, b, t_c, t_n;
                        fio = "ФИО: " + response.Split(':')[0];
                        n = "Номер телефона: " + response.Split(':')[1];
                        e = "Email: " + response.Split(':')[2];
                        a = "Адрес: " + response.Split(':')[3];
                        b = "Баланс: " + response.Split(':')[4];
                        t_c = "Стоимость тарифа: " + response.Split(':')[5];
                        t_n = "Название тарифа: " + response.Split(':')[6];
                        tw.Text = fio + '\n' + n + '\n' +e + '\n' +a + '\n' +b + '\n' +t_c + '\n' +t_n;
                    }
                    else
                    {
                        View view = base.FindViewById(Resource.Id.button1);
                        Snackbar.Make(view, "Неправильный Логин/Пароль", Snackbar.LengthLong)
                            .SetAction("Action", (View.IOnClickListener)null).Show();

                    }
                }
                //_addressManual.Visibility = ViewStates.Invisible;
                
            };

        }
        
        public void OnButtonClicked(View sender)
        {
            
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
