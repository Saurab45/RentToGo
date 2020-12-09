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
        public HouseViewHolde(View itemview, Action<int> listener) : base(itemview)
        {
            image = itemview.FindViewById<ImageView>(Resource.Id.imgRecycler);
            heading = itemview.FindViewById<TextView>(Resource.Id.tvHeading);
            detail = itemview.FindViewById<TextView>(Resource.Id.tvDetail);
            itemview.Click += (sender, e) => listener(Position);
        }
    }
}