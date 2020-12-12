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

using RentToGo.model;

namespace RentToGo
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += BtnRegister_Click;

        }


        private void BtnRegister_Click(object sender, EventArgs e)
        {
            EditText Name = FindViewById<EditText>(Resource.Id.name);
            EditText UserName = FindViewById<EditText>(Resource.Id.username);
            EditText Password = FindViewById<EditText>(Resource.Id.password);

            User u = new User();
            u.name = Name.Text;
            u.username = UserName.Text;
            u.password = Password.Text;

            PostUser(u);
        }

        public string getQuotedString(string str)
        {
            return "\"" + str + "\"";
        }

        public void PostUser(User User)
        {
            string url = "https://192.168.18.7:5001/api/Users";//my ipv4 ip for device and 10.0.2.2 for emulators

            string json =
            "{" +
            getQuotedString("name") + ":" + getQuotedString(User.name) + "," +
            getQuotedString("username") + ":" + getQuotedString(User.username) + "," +
            getQuotedString("password") + ":" + getQuotedString(User.password) + "," +

            "}";

            if (APIConnect.Post(url, json))
            {
                Toast.MakeText(this, "User created successfully", ToastLength.Long).Show();
            }

        }


    }
}