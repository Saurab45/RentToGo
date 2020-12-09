using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.Util;
using Android.Gms.Common;
using Test;

namespace RentToGo
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {

        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        Housephoto mPhotoAlbum;
        HouseAdapter mAdapter;
        List<HouseData> dList = new List<HouseData>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            IsPlayServicesAvailable();
            CreateNotificationChannel();

            mPhotoAlbum = new Housephoto();
            putData();
            mLayoutManager = new LinearLayoutManager(this);

            mAdapter = new HouseAdapter(mPhotoAlbum, dList);
            mAdapter.ItemClick += MAdapter_ItemClick;

            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mRecycleView.SetAdapter(mAdapter);


            // Create your application here
        }
        private void putData()
        {
            /*
            dList.Add(new Data("Database", "This is the database description"));
            dList.Add(new Data("Programming", "This is the programming description"));
            dList.Add(new Data("GitHub", "This is the github description"));
            dList.Add(new Data("Math", "This is Math description"));
            dList.Add(new Data("MongoDB", "This is MongoDB description"));
            dList.Add(new Data("C#", "This is a C# description"));
            */

            string url = "https://10.0.2.2:5001/api/Data";
            string response = APIConnect.Get(url);
            dList = JsonConvert.DeserializeObject<List<HouseData>>(response);
        }


        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();

            Intent i = new Intent(this, typeof(NavigationActivity));
            StartActivity(i);
        }
    }
}