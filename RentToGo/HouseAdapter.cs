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
    class HouseData
    {
        public int id { get; set; }
        public string heading { get; set; }
        public string detail { get; set; }

        public string bedroom { get; set; }
        public HouseData(string h, string d,string n)
        {
            heading = h;
            detail = d;
            bedroom = n;
        }
    }
    class HouseAdapter : RecyclerView.Adapter
    {
        List<HouseData> dataList = new List<HouseData>();
        public event EventHandler<int> ItemClick;

        public Housephoto mPhotoAlbum;
        public HouseAdapter(Housephoto houseAlbum, List<HouseData> list)
        {
            mPhotoAlbum = houseAlbum;
            dataList = list;
        }

        public override int ItemCount
        {
            get { return dataList.Count(); }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder hold, int position)
        {
            HouseViewHolde vh = hold as HouseViewHolde;
            vh.image.SetImageResource(mPhotoAlbum[position]);
            vh.heading.Text = dataList[position].heading;
            vh.detail.Text = dataList[position].detail;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.House_recycler, parent, false);
            HouseViewHolde vh = new HouseViewHolde(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}