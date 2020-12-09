using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.Widget;
using Android.Support.V7.RecyclerView;

namespace RentToGo
{
    class HouseData
    {
        public int id { get; set; }
        public string heading { get; set; }
        public string detail { get; set; }

        public int bedroom { get; set; }
        public HouseData(string h, string d,int n)
        {
            heading = h;
            detail = d;
            bedroom = n;
        }
    }
    class HouseAdapter : RecyclerView.Adapter
    {
        List<Data> dataList = new List<Data>();
        public event EventHandler<int> ItemClick;

        public PhotoAlbum mPhotoAlbum;
        public PhotoAdapter(PhotoAlbum photoAlbum, List<Data> list)
        {
            mPhotoAlbum = photoAlbum;
            dataList = list;
        }

        public override int ItemCount
        {
            get { return dataList.Count(); }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.image.SetImageResource(mPhotoAlbum[position]);
            vh.heading.Text = dataList[position].heading;
            vh.description.Text = dataList[position].description;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.content_recycler, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}