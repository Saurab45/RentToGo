﻿using Android.App;
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
        public TextView heading { get; set; }
        public TextView description { get; set; }
        public PhotoViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            image = itemview.FindViewById<ImageView>(Resource.Id.imgRecycler);
            heading = itemview.FindViewById<TextView>(Resource.Id.tvHeading);
            description = itemview.FindViewById<TextView>(Resource.Id.tvDescription);
            itemview.Click += (sender, e) => listener(Position);
        }

    }
}