using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using Com.Google.Maps.Android.Clustering;
using MapsXamarinForms.CustomRenderer;
using MapsXamarinForms.Droid.CustomRenderer;
using MapsXamarinForms.Models;
using Sample.Droid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private List<ClusterMarker> ClusterList { get; set; } = new List<ClusterMarker>();

        public CustomClusterMapRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "ClusterData")
            {
                var clusterData = (CustomClusterMapRenderer)sender;
                foreach (Cluster cluster in clusterData.ClusterData)
                {
                    ClusterList.Add(new ClusterMarker
                    {
                        Position = new LatLng(cluster.Lat, cluster.Lng),
                        Snippet = cluster.Snippet,
                        Title = cluster.Title
                    });
                }

                try
                {
                    StartMap();
                    clusterManager.AddItems(ClusterList);
                }
                catch (Exception)
                {
                    Toast.MakeText(this.Context, "Problem reading list of markers.", ToastLength.Long).Show();
                }
            }
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
        }

        protected override void OnMapReady(GoogleMap googleMap)
        {
            base.OnMapReady(googleMap);

            if (googleMap == null)
                return;

            this.googleMap = googleMap;
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