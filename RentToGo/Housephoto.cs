using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentToGo
{
    class Housephoto
    {
        static int[] listhousePhoto =
            {
            Resource.Drawable.house1,
            Resource.Drawable.house2,
            Resource.Drawable.house3,
            Resource.Drawable.house4
        };

        private int[] photos;
        public Housephoto()
        {
            this.photos = listhousePhoto;
        }

        public int numhousePhoto
        {
            get
            {
                return photos.Length;
            }
        }
        public int this[int i]
        {
            get { return photos[i % 4]; }
        }
    }
}
