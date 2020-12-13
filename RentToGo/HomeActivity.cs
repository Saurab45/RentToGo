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
using Newtonsoft.Json;
using Android.Util;
using Android.Support.V7.Widget;
using Android.Gms.Common;

namespace RentToGo
{
    class HomeActivity : Activity
    {

        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        Housephoto mPhotoAlbum;
        HouseAdapter mAdapter;
        List<HouseData> dList = new List<HouseData>();

        string TAG = "RentToGo";
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Debug(TAG, GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Log.Debug(TAG, "This device is not supported");
                    Finish();
                }
                return false;
            }

            Log.Debug(TAG, "Google Play Services is available.");
            return true;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    if (key != null)
                    {
                        var value = Intent.Extras.GetString(key);
                        Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                    }
                }
            }

            IsPlayServicesAvailable();
            CreateNotificationChannel();

            mPhotoAlbum = new PhotoAlbum();
            putData();
            mLayoutManager = new LinearLayoutManager(this);

            mAdapter = new PhotoAdapter(mPhotoAlbum, dList);
            mAdapter.ItemClick += MAdapter_ItemClick;

            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mRecycleView.SetAdapter(mAdapter);
        }
    }