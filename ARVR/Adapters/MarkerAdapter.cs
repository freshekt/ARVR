using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Pikkart.AR.Geo;

namespace ARVR.Adapters
{
    public class MarkerAdapter: MarkerViewAdapter
    {
        public MarkerAdapter(Context context, int width, int height) : base(context,width,height)
        {
            IsDefaultMarker = false;
        }

        public override View GetView(GeoElement p0)
        {
            ImageView imageView = (ImageView)MarkerView.FindViewById(Resource.Id.image);
            imageView.SetImageResource(Resource.Drawable.max);
            imageView.Invalidate();
            return MarkerView;
        }

        public override View GetSelectedView(GeoElement p0)
        {
            ImageView imageView = (ImageView)MarkerView.FindViewById(Resource.Id.image);
            imageView.SetImageResource(Resource.Drawable.max);
            imageView.Invalidate();
            return MarkerView;
        }
    }
}
