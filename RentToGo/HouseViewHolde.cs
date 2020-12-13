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


namespace RentToGo
{
   
    public class HouseViewHolde : RecyclerView.ViewHolder
    {
        public ImageView image { get; set; }
        public TextView heading { get; set; }
        public TextView detail { get; set; }
        public TextView bedroom { get; set; }
        public TextView bathroom { get; set; }

        public TextView rent { get; set; }
        public HouseViewHolde(View itemview, Action<int> listener) : base(itemview)
        {
            image = itemview.FindViewById<ImageView>(Resource.Id.imgRecycler);
            heading = itemview.FindViewById<TextView>(Resource.Id.tvHeading);
            detail = itemview.FindViewById<TextView>(Resource.Id.tvDetail);
            bedroom = itemview.FindViewById<TextView>(Resource.Id.tvBedroom);
            bathroom = itemview.FindViewById<TextView>(Resource.Id.tvBathroom);
            rent = itemview.FindViewById<TextView>(Resource.Id.tvRent);
            itemview.Click += (sender, e) => listener(Position);
        }
    }
}