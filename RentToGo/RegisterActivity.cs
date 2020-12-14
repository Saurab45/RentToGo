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
using Newtonsoft.Json;

namespace RentToGo
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_register);

            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += BtnRegister_Click;

        }


        private void BtnRegister_Click(object sender, EventArgs e)
        {
            
            EditText UserName = FindViewById<EditText>(Resource.Id.username);
            EditText Password = FindViewById<EditText>(Resource.Id.password);
            EditText Email = FindViewById<EditText>(Resource.Id.email);

            EditText fName = FindViewById<EditText>(Resource.Id.firstname);
            EditText lName = FindViewById<EditText>(Resource.Id.lastname);
            EditText num = FindViewById<EditText>(Resource.Id.number);
            EditText add = FindViewById<EditText>(Resource.Id.address);
            EditText coun = FindViewById<EditText>(Resource.Id.country);

            User u = new User();
            u.username = UserName.Text;
            u.password = Password.Text;
            u.email = Email.Text;

            u.firstname = fName.Text;
            u.lastname = lName.Text;
            u.number = num.Text;
            u.address = add.Text;
            u.country = coun.Text;

            string uname = UserName.Text;
            if (checkexist(uname))
            {
                Toast.MakeText(this, "Invalid username or password", ToastLength.Long).Show();
            }
            else
            {
                PostUser(u);

            }


            
        }

        public string getQuotedString(string str)
        {
            return "\"" + str + "\"";
        }

        public void PostUser(User User)
        {
            string url = "https://10.0.2.2:5001/api/Users";//my ipv4 ip for device and 10.0.2.2 for emulators

            string json =
            "{" +
            
            getQuotedString("username") + ":" + getQuotedString(User.username) + "," +
            getQuotedString("password") + ":" + getQuotedString(User.password) + "," +
            getQuotedString("email") + ":" + getQuotedString(User.email) + "," +

            getQuotedString("firstname") + ":" + getQuotedString(User.firstname) + "," +
            getQuotedString("lastname") + ":" + getQuotedString(User.lastname) + "," +
            getQuotedString("number") + ":" + getQuotedString(User.number) + "," +
            getQuotedString("address") + ":" + getQuotedString(User.address) + "," +
            getQuotedString("country") + ":" + getQuotedString(User.country) + "," +

            "}";

            if (APIConnect.Post(url, json))
            {
                Toast.MakeText(this, "User created successfully", ToastLength.Long).Show();
                Intent loginActivity = new Intent(this, typeof(LoginActivity));
                StartActivity(loginActivity);
            }

        }



        private bool checkexist(string uname)
        {
            bool status = true;
            string url = "https://10.0.2.2/api/Users";
            string response = APIConnect.Get(url);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(response);

            foreach (User user in users)
            {
                if (user.username == uname)
                {
                    status = false;
                    break;
                }
            }

            return status;
        }




    }
}