using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;




namespace RentToGo
{


    public class AgentFragment : Fragment, IOnMapReadyCallback
    {
        GoogleMap gmap;
        LatLng curLocation;

        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);


        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.fragment_agent, container, false);

            ImageView imgMapFrag = v.FindViewById<ImageView>(Resource.Id.imgMapFrag);
            imgMapFrag.SetImageResource(Resource.Drawable.agent1);

            var mapFrag = MapFragment.NewInstance();
            ChildFragmentManager.BeginTransaction()
                .Add(Resource.Id.mapFrgContainer, mapFrag, "map")
                .Commit();

            mapFrag.GetMapAsync(this);

            Button btnSMS = v.FindViewById<Button>(Resource.Id.btnSMS);
            btnSMS.Click += BtnSMS_Click;

            return v;

        }
        public void OnMapReady(GoogleMap map)
        {
            map.MapType = GoogleMap.MapTypeHybrid;
            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(new LatLng(50.379444, 2.773611));
            markerOpt1.SetTitle("430 Queen Street");
            markerOpt1.SetSnippet("RENT-TO-GO REAL ESTATE");

            map.AddMarker(markerOpt1);


            MarkerOptions markerOpt2 = new MarkerOptions();
            markerOpt2.SetPosition(new LatLng(40.4272414, -3.7020037));
            markerOpt2.SetTitle("96 New North Road, Eden Terrace");
            markerOpt2.SetSnippet("BARFOOT REAL ESTATE");

            map.AddMarker(markerOpt2);

            MarkerOptions markerOpt3 = new MarkerOptions();
            markerOpt3.SetPosition(new LatLng(43.2568193, -2.9225534));
            markerOpt3.SetTitle("20 upper Queen street");
            markerOpt3.SetSnippet("AP REAL ESTATE");
            map.AddMarker(markerOpt3);




            LatLng location = new LatLng(50.897778, 3.013333);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            builder.Bearing(155);
            builder.Tilt(65);

            CameraPosition cameraPosition = builder.Build();

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);
        }
        private async void BtnSMS_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "Hi i am property agent saw your details on the Rent-a-Go app. could you please send me details of more houses for rent in the same price range?";
                string recipient = "02348387";
                var message = new SmsMessage(text, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                Toast.MakeText(Activity, "Exception Found", ToastLength.Long).Show();
            }
        }
    }
}

       

        
    



















        
    
            
   