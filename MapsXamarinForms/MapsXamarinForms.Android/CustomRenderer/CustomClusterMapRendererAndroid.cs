using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using AndroidX.Fragment.App;
using Com.Google.Maps.Android.Clustering;
using MapsXamarinForms.CustomRenderer;
using MapsXamarinForms.Droid.CustomRenderer;
using Sample.Droid.Utils;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomClusterMapRenderer), typeof(CustomClusterMapRendererAndroid))]
namespace MapsXamarinForms.Droid.CustomRenderer
{
    [Obsolete]
    public class CustomClusterMapRendererAndroid : MapRenderer
    {
        private ClusterManager clusterManager;

        protected GoogleMap googleMap { get; private set; }
        protected MapFragment mapFragment { get; private set; }

        public CustomClusterMapRendererAndroid(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            try
            {
                MainActivity.Instance.SetContentView(LayoutId());
                InitElements();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
            }

        }

        private void StartMap()
        {
            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(51.503186, -0.126446), 10));
            clusterManager = new ClusterManager(this.Context, googleMap);
            googleMap.SetOnCameraIdleListener(clusterManager);

            try
            {
                ReadJson();
            }
            catch (Exception)
            {
                Toast.MakeText(this.Context, "Problem reading list of markers.", ToastLength.Long).Show();
            }
        }

        private void ReadJson()
        {
            Stream stream = Resources.OpenRawResource(Resource.Raw.radar_search);
            var items = ItemReader.StreamToClusterMarker(stream);
            clusterManager.AddItems(items);
        }

        protected override void OnMapReady(GoogleMap googleMap)
        {
            base.OnMapReady(googleMap);

            if (googleMap == null)
                return;

            this.googleMap = googleMap;
            StartMap();
        }

        private void InitElements()
        {
            mapFragment = MainActivity.Instance.FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

        protected virtual int LayoutId()
        {
            return Resource.Layout.MapLayout;
        }
    }
}