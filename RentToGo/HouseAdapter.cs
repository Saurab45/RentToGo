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
        public int rent { get; set; }

        public int bathroom { get; set; }
        public int bedroom { get; set; }
        public HouseData(string h, string d,int b,int r , int s)
        {
            heading = h;
            detail = d;
            bedroom = b;
            rent = r;
            bathroom = s;
        }
    }
    class HouseAdapter : RecyclerView.Adapter
    {
        List<HouseData> houseList = new List<HouseData>();
        public event EventHandler<int> ItemClick;

        public Housephoto mPhotoAlbum;
        public HouseAdapter(Housephoto houseAlbum, List<HouseData> list)
        {
            mPhotoAlbum = houseAlbum;
            houseList = list;
        }

        public override int ItemCount
        {
            get { return houseList.Count(); }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder hold, int position)
        {
            HouseViewHolde vh = hold as HouseViewHolde;
            vh.image.SetImageResource(mPhotoAlbum[position]);
            vh.heading.Text = houseList[position].heading;
            vh.detail.Text = houseList[position].detail;
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