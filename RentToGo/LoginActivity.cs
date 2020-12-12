using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.App.AlertDialog;

using Android.Content;

using RentToGo.model;
using Newtonsoft.Json;

namespace RentToGo
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login);


            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += BtnLogin_Click;

            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += BtnRegister_Click;
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {

            EditText edUserName = FindViewById<EditText>(Resource.Id.edUserName);
            EditText edPassword = FindViewById<EditText>(Resource.Id.edPassword);

            string uname = edUserName.Text.Trim();
            string pass = edPassword.Text.Trim();
            string name;
            int id;
            if (checkLogin(uname, pass, out id, out name))
            {
                Intent NewActivity = new Intent(this, typeof(HomeActivity));

                Bundle bundle = new Bundle();
                bundle.PutString("name", name);
                bundle.PutInt("id", id);
                NewActivity.PutExtra("data", bundle);

                StartActivity(NewActivity);
            }
            else
            {
                Toast.MakeText(this, "Invalid username or password", ToastLength.Long).Show();
            }


        }


        private void BtnRegister_Click(object sender, EventArgs e)
        {
            Intent NewActivity = new Intent(this, typeof(RegisterActivity));

            StartActivity(NewActivity);
        }


        private bool checkLogin(string uname, string pass, out int id, out string name)
        {
            bool status = false;
            string url = "https://192.168.18.7/api/Users";
            string response = APIConnect.Get(url);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(response);
            id = 0;
            name = "";
            foreach (User user in users)
            {
                if (user.username == uname && user.password == pass)
                {
                    status = true;
                    id = user.id;
                    name = user.name;
                    break;
                }
            }

            return status;
        }


    }
}