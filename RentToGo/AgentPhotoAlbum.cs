using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace RentToGo
{
    class AgentPhotoAlbum
    {
        static int[] listPhoto =
            {
            Resource.Drawable.agent1,
            Resource.Drawable.agent2,
            Resource.Drawable.agent3,
            
        };
        private int[] photos;
        public AgentPhotoAlbum()
        {
            this.photos = listPhoto;
        }
        public int numPhoto
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