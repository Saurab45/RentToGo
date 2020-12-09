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
    public class AgentViewHolder: RecyclerView.ViewHolder
    {
        public ImageView image { get; set; }
        public TextView id  { get; set; }
        public TextView agentName  { get; set; }
        public TextView email { get; set; }
        public TextView phoneNumber  { get; set; }
        public TextView officeLocation  { get; set; }

        public PhotoViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            image = itemview.FindViewById<ImageView>(Resource.Id.imgRecycler);
            id = itemview.FindViewById<TextView>(Resource.Id.tvid);
             agentName = itemview.FindViewById<TextView>(Resource.Id.tvagentName);
             email = itemview.FindViewById<TextView>(Resource.Id.tvemail);
             phoneNumber = itemview.FindViewById<TextView>(Resource.Id.tvphoneNumber);
             officeLocation = itemview.FindViewById<TextView>(Resource.Id.tvofficeLocation);
            itemview.Click += (sender, e) => listener(Position);
        }

    }
}