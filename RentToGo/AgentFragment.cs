using Android.App;
using Android.Content;
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
        public override void OnCreate(Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View v = inflater.Inflate(Resource.Layout.fragment_map, container, false);

            ImageView imgMapFrag = v.FindViewById<ImageView>(Resource.Id.imgMapFrag);
            imgMapFrag.SetImageResource(Resource.Drawable.P1);

            var mapFrag = MapFragment.NewInstance();
            ChildFragmentManager.BeginTransaction()
                .Add(Resource.Id.mapFrgContainer, mapFrag, "map")
                .Commit();

            mapFrag.GetMapAsync(this);

            Button btnShare = v.FindViewById<Button>(Resource.Id.btnShare);
            Button btnSMS = v.FindViewById<Button>(Resource.Id.btnSMS);

            btnShare.Click += BtnShare_Click;
            btnSMS.Click += BtnSMS_Click;

            return v;

            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private async void BtnSMS_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "Hi i am <> saw your details on the Rent-a-Go app. could you please send me details of more houses for rent in the same price range?" 
                string recipient = "101";
                var message = new SmsMessage(text, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                Toast.MakeText(Activity, "Exception Found", ToastLength.Long).Show();
            }

            private async void BtnShare_Click(object sender, EventArgs e)
            {
                string locDetails = "";
                locDetails += "Latitude: " + curLocation.Latitude + "\nLongitude: " + curLocation.Longitude;
                await ShareText(locDetails);

            }
            public async Task ShareText(string text)
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = text,
                    Title = "Agent Details Share"
                });
                public async void OnMapReady(GoogleMap googleMap)
                {
                    gmap = googleMap;
                    googleMap.MapType = GoogleMap.MapTypeNormal;
                    googleMap.UiSettings.ZoomControlsEnabled = true;
                    googleMap.UiSettings.CompassEnabled = true;

                    LatLng loc = new LatLng(-36.84966, 174.76526);
                    CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                    builder.Target(loc);
                    builder.Zoom(20);
                    builder.Tilt(65);

                    CameraPosition cPos = builder.Build();
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cPos);
                    googleMap.MoveCamera(cameraUpdate);

                    MarkerOptions markerOptions = new MarkerOptions();
                    markerOptions.SetPosition(loc);
                    markerOptions.SetTitle("NZSE City Campus");
                    googleMap.AddMarker(markerOptions);

                    var address = await Geocoding.GetPlacemarksAsync(loc.Latitude, loc.Longitude);
                    var placemark = address?.FirstOrDefault();
                    var geocodeAddress = "";
                    if (placemark != null)
                    {
                        geocodeAddress =
                            $"AdminArea:       {placemark.AdminArea}\n" +
                            $"CountryCode:     {placemark.CountryCode}\n" +
                            $"CountryName:     {placemark.CountryName}\n" +
                            $"FeatureName:     {placemark.FeatureName}\n" +
                            $"Locality:        {placemark.Locality}\n" +
                            $"PostalCode:      {placemark.PostalCode}\n" +
                            $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                            $"SubLocality:     {placemark.SubLocality}\n" +
                            $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                            $"Thoroughfare:    {placemark.Thoroughfare}\n";

                    }
                }
        }
    }
}