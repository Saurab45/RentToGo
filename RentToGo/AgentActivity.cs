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
using Android.Support.V7.Widget;


namespace RentToGo
{
    [Activity(Label = "AgentActivity")]
    public class AgentActivity : Activity
    {
        public const string TAG = "AgentActivity";
        internal static readonly string CHANNEL_ID = "RentToGo";

        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        AgentPhotoAlbum mPhotoAlbum;
        AgentAdapter mAdapter;
        List<Data> dList = new List<Data>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();

            Intent i = new Intent(this, typeof(bottonNavigationBar));
            StartActivity(i);
        }
        
    }
}