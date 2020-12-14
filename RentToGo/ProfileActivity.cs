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

using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RentToGo
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity
    {
        string usname;
        string uspass;
        string usemail;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_profile);


            Button BtnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            BtnUpdate.Click += BtnUpdate_Click;


            Button BtnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            BtnCancel.Click += BtnCancel_Click;


            Button btnShare = FindViewById<Button>(Resource.Id.btnShare);
            Button btnSMS = FindViewById<Button>(Resource.Id.btnSMS);

            btnShare.Click += BtnShare_Click;
            btnSMS.Click += BtnSMS_Click;


            Bundle data = Intent.GetBundleExtra("data");
            usname = data.GetString("uname");
            uspass = data.GetString("upass");
            usemail = data.GetString("uemail");


            Toast.MakeText(this, "Edit profile for " + usname, ToastLength.Long).Show();


            FrameLayout mapFrgContainer = FindViewById<FrameLayout>(Resource.Id.mapFrgContainer);
            ProfileFragment mFrag = new ProfileFragment();
            mapFrgContainer.RemoveAllViewsInLayout();


        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Intent homeActivity = new Intent(this, typeof(HomeActivity));
            StartActivity(homeActivity);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {


            EditText fName = FindViewById<EditText>(Resource.Id.firstname);
            EditText lName = FindViewById<EditText>(Resource.Id.lastname);
            EditText num = FindViewById<EditText>(Resource.Id.number);
            EditText add = FindViewById<EditText>(Resource.Id.address);
            EditText coun = FindViewById<EditText>(Resource.Id.country);

            /*User u = new User();
            u.username = usname;
            u.password = uspass;
            u.email = usemail;

            u.firstname = fName.Text;
            u.lastname = lName.Text;
            u.number = num.Text;
            u.address = add.Text;
            u.country = coun.Text;*/
            try
            {
                editu(usname, uspass, fName.Text, lName.Text, num.Text, add.Text, coun.Text);

                Toast.MakeText(this, "User updated successfully please relog", ToastLength.Long).Show();

                Intent loginActivity = new Intent(this, typeof(LoginActivity));
                StartActivity(loginActivity);
            }
            catch (Exception)
            {
                Toast.MakeText(this, "User updated unsuccessfull", ToastLength.Long).Show();
            }
            

                //PostUser(u);

            






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
                Toast.MakeText(this, "User updated successfully please relog", ToastLength.Long).Show();
                Intent loginActivity = new Intent(this, typeof(LoginActivity));
                StartActivity(loginActivity);
            }

        }



        private bool editu(string upname, string uppass, string fn, string ln, string nu, string ad, string co)
        {
            bool status = true;
            string url = "https://10.0.2.2/api/Users";
            string response = APIConnect.Get(url);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(response);

            foreach (User user in users)
            {
                if (user.username == upname && user.password == uppass)
                {
                    status = true;


                    user.firstname = fn;
                    user.lastname = ln;
                    user.number = nu;
                    user.address = ad;
                    user.country = co;
                    
                    break;
                }
            }

            return status;
        }


        string smsnum = "#not found";
        string shemail = "#not found";
        string shfname = "#not found";
        string shlname = "#not found";
        string shadd = "#not found";
        string shco = "#not found";
        private bool getall(string upname, string uppass)
        {
            
            string url = "https://10.0.2.2/api/Users";
            string response = APIConnect.Get(url);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(response);

            foreach (User user in users)
            {
                if (user.username == upname && user.password == uppass)
                {

                    smsnum = user.number;
                    shemail = user.email;
                    shfname = user.firstname;
                    shlname = user.lastname;
                    shadd = user.address;
                    shco = user.country;
                    break;
                }
            }

            return true;
        }

         

        private async void BtnSMS_Click(object sender, EventArgs e)
        {
            getall(usname, uspass);
            try
            {
                string text = "Hi,Please find my contact details as requested, Email: "+usemail+" Phone Number: "+smsnum;
                string recipient = "";
                var message = new SmsMessage(text, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Exception Found", ToastLength.Long).Show();
            }
        }



        private async void BtnShare_Click(object sender, EventArgs e)
        {
            string Details = shfname+" "+shlname+", Phone number: "+smsnum+", Email: "+shemail+", Address: "+shadd+", Country: "+shco;
            
            await ShareText(Details);

        }

        public async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = " -Sharing my details- "
            });
        }



    }
}