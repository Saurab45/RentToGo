using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace RentToGo
{
    [Activity(Label = "bottonNavigationBar")]
    public class bottonNavigationBar : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        [System.Obsolete]

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            TextView tvNavigationText = FindViewById<TextView>(Resource.Id.tvNavigationText);
            FrameLayout content_frame = FindViewById<FrameLayout>(Resource.Id.content_frame);
            FragmentTransaction transaction;
            switch (item.ItemId)
            {
                case Resource.Id.customer_profile:
                    tvNavigationText.Text = "customer_profile Clicked";
                    customerprofileFragment sFrag = new customerprofileFragment();
                    content_frame.RemoveAllViewsInLayout();
                    transaction = FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.content_frame, sFrag, "c");
                    transaction.AddToBackStack("customer_profile");
                    transaction.Commit();
                    return true;

                case Resource.Id.action_location:
                    AgentFragment mFrag = new AgentFragment();
                    content_frame.RemoveAllViewsInLayout();
                    
                    transaction = FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.content_frame, mFrag, "Location");
                    transaction.AddToBackStack("Location");
                    transaction.Commit();
                    tvNavigationText.Text = "Location Clicked";
                    return true;

                case Resource.Id.logout:
                    content_frame.RemoveAllViewsInLayout();
                    tvNavigationText.Text = "logout Clicked";
                    return true;

            }
            return false;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_main);

            bottonNavigationBar  navigationView = FindViewById <bottonNavigationBar> (Resource.Id.bottom_navigation);
            navigationView.SetOnNavigationItemSelectedListener(this);
        }
    }
}