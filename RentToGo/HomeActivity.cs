using Android.App;
using Android.Content;
using Android.OS;
using System;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.App.AlertDialog;
using Android.Content;



using Android.Support.V7.Widget;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.Util;
using Android.Gms.Common;


namespace RentToGo
{
    [Activity(Label = "Home Activity", Theme = "@style/AppTheme.NoActionBar")]
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
            SetContentView(Resource.Layout.home_act);
            //IsPlayServicesAvailable();
            //CreateNotificationChannel();

            mPhotoAlbum = new Housephoto();
            putData();
            mLayoutManager = new LinearLayoutManager(this);
             
            mAdapter = new HouseAdapter(mPhotoAlbum, dList);
            mAdapter.ItemClick += MAdapter_ItemClick;

            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView); 
            mRecycleView.SetLayoutManager(mLayoutManager);
            mRecycleView.SetAdapter(mAdapter);


        }
       
           



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


 private void putData()
        {
            string url = "https://10.0.2.2:5001/api/DataHouse";
            string response = APIConnect.Get(url);
            dList = JsonConvert.DeserializeObject<List<HouseData>>(response);
        }


        private void MAdapter_ItemClick(object sender, int e)
        {
            //int photoNum = e + 1;
            //Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();

            Intent i = new Intent(this, typeof(NavigationActivity));
            StartActivity(i);
        } 
    }
    }
}
