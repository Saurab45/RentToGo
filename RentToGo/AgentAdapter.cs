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

    class Data
    {
        public int id { get; set; }
        public string heading { get; set; }
        public string description { get; set; }

        public Data(string h, string d)
        {
            heading = h;
            description = d;
        }
    }

    class AgentAdapter : RecyclerView.Adapter
    {
        List<Data> dataList = new List<Data>();
        public event EventHandler<int> ItemClick;

        public AgentPhotoAlbum mPhotoAlbum;
        public AgentAdapter(AgentPhotoAlbum AgentphotoAlbum, List<Data> list)
        {
            mPhotoAlbum = AgentphotoAlbum;
            dataList = list;
        }

        public override int ItemCount
        {
            get { return dataList.Count(); }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            AgentViewHolder vh = holder as AgentViewHolder;
            vh.image.SetImageResource(mPhotoAlbum[position]);
            vh.heading.Text = dataList[position].heading;
            vh.description.Text = dataList[position].description;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.agent_recycler, parent, false);
            AgentViewHolder vh = new AgentViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);







        }
    }
}

  
