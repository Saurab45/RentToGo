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
using Android.Support.Design.Widget;

namespace RentToGo
{
    [Activity(Label = "NaviAct")]
    public class NaviAct : Activity
    {
        [System.Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.navg);

            BottomNavigationView navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottomNavBar);
            navigationView.SetOnNavigationItemSelectedListener(this);

        }
    }
}