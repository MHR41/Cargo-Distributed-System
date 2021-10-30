using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Cargo_Distributed_System
{
    static class Program
    {
        public static DistanceCalculator DistanceCalculator = new DistanceCalculator();
        public static GMapOverlay MarkerOverlay = new GMapOverlay("markers");
        public static GMapOverlay RouteOverlay = new GMapOverlay("routes");
        public static TSPCalculator tspCalculator = new TSPCalculator();

        public static List<PointLatLng> Points { get; internal set; } = new List<PointLatLng>();

        //public static GMapRoute TestRoute;
        [STAThread]
        static void Main()
        {
            AddBasePoint(new PointLatLng(40.771383942187754, 29.917686172310578));
            AddPoint(new PointLatLng(40.77178207461923, 29.914542623600436));
            AddPoint(new PointLatLng(40.76824755023011, 29.91296548482778));
            AddPoint(new PointLatLng(40.76365592770402, 29.913329527041864));

            /*TestRoute = new GMapRoute(DistanceCalculator.Points, "testRoute");
            RouteOverlay.Routes.Add(TestRoute);*/
            RouteOverlay.Routes.Add(DistanceCalculator.Route);            
            //MarkerOverlay.Routes.Add(TestRoute);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DeliveryAdressScreenForm());
            Application.Exit();
        }

        public static void AddPoint(PointLatLng point)
        {
            DistanceCalculator.AddPoint(point);
            Points.Add(point);
            MarkerOverlay.Markers.Add(new GMarkerGoogle(point, GMarkerGoogleType.red_small));
        }
        public static void AddBasePoint(PointLatLng point)
        {
            DistanceCalculator.BaseOfOperations = point;
            DistanceCalculator.AddPoint(point);
            Points.Add(point);
            tspCalculator.start = point;
            MarkerOverlay.Markers.Add(new GMarkerGoogle(point, GMarkerGoogleType.red_small));
        }
    }
}
