
using System.Threading;
using GMap.NET;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using GMap.NET.WindowsForms;
using System.Drawing;

namespace Cargo_Distributed_System
{
    class TSPCalculator
    {
        private Thread thread;
        private object lockObject = new object();
        private ManualResetEvent manualReset = new ManualResetEvent(false);

        private List<PointLatLng> Points;
        private Dictionary<PointLatLng, int> PointIndex = new Dictionary<PointLatLng, int>();
        private Dictionary<int, PointLatLng> IndexPoint = new Dictionary<int, PointLatLng>();
        private GMapRoute Route = new GMapRoute("best-route");
        public PointLatLng start { get; set; }

        public TSPCalculator()
        {
            thread = new Thread(new ThreadStart(NearestNeighbor)) { IsBackground = true, Name = "tsp-calculator-thread" };

            Points = Program.Points;

            thread.Start();
        }

        public TSPCalculator(PointLatLng start)
        {
            thread = new Thread(new ThreadStart(NearestNeighbor)) { IsBackground = true, Name = "tsp-calculator-thread" };

            Points = Program.Points;

            this.start = start;

            InitPointIndex();

            thread.Start();
        }

        public void Pause() => manualReset.Reset();
        public void Resume() => manualReset.Set();

        private void InitPointIndex()
        {
            for (int i = 0; i < Points.Count; i++)
            {
                PointIndex.Add(Points[i], i);
                IndexPoint.Add(i, Points[i]);
            }
        }

        private void ReconstructRoute(List<int> routeAsIndex)
        {
            System.Windows.Forms.MessageBox.Show("Reconstructing Route");
            List<PointLatLng> pointLatLngs = new List<PointLatLng>();
            foreach (var index in routeAsIndex)
            {
                pointLatLngs.Add(IndexPoint[index]);
            }

            Route = new GMapRoute(pointLatLngs, "best-route")
            {
                Stroke = new Pen(Color.Red, 3)
            };
            if (Program.RouteOverlay.Routes.Contains(Route))
            {
                Program.RouteOverlay.Routes.Remove(Route);
            }

            Program.RouteOverlay.Routes.Add(Route);
        }

        private void NearestNeighbor()
        {
            manualReset.WaitOne();
            lock (lockObject)
            {

                Points = Program.Points;
                InitPointIndex();
                List<int> route = new List<int>();

                var adjMatrix = DistMatrixRequest(start);

                System.Windows.Forms.MessageBox.Show("NN start");

                var unVisited = new HashSet<int>();
                for (int i = 0; i < adjMatrix.GetLength(0); i++)
                {
                    unVisited.Add(i);
                }

                int startIndex = PointIndex[start];

                int currIndex = startIndex;
                while (unVisited.Any())
                {
                    unVisited.Remove(currIndex);
                    route.Add(currIndex);

                    int minNeighborIdx = int.MinValue;
                    long minNeighborVal = long.MaxValue;
                    for (int j = 0; j < adjMatrix.GetLength(0); j++)
                    {
                        if (route.Contains(j)) continue;
                        var neighborIdx = j;
                        var neighborVal = adjMatrix[startIndex, neighborIdx];
                        if (neighborVal < minNeighborVal)
                        {
                            minNeighborIdx = neighborIdx;
                            minNeighborVal = neighborVal;
                        }
                    }

                    currIndex = minNeighborIdx;
                }
                System.Windows.Forms.MessageBox.Show("NN End");

                ReconstructRoute(route);
                manualReset.Reset();
            }
        }


        private long[,] AdjMatrixInit(Root root)
        {
            System.Windows.Forms.MessageBox.Show("Adj Matrix Init Start");
            var adjMatrix = new long[Points.Count, Points.Count];
            var rows = root.rows;
            for (int i = 0; i < Points.Count; i++)
            {
                var orginIndex = PointIndex[Points[i]];
                Row row = rows[i];
                for (int j = 0; j < Points.Count; j++)
                {
                    var destIndex = PointIndex[Points[j]];
                    var distance = row.elements[j].distance.value;
                    adjMatrix[orginIndex, destIndex] = distance;
                }
            }
            System.Windows.Forms.MessageBox.Show("Adj Matrix Init End");

            return adjMatrix;
        }

        private long[,] DistMatrixRequest(PointLatLng start)
        {
            System.Windows.Forms.MessageBox.Show("DistMatrixRequest Start");
            var destinations = "destinations=";
            var origins = "&origins=";
            foreach (var point in Points)
            {
                origins += $"{point.Lat}%2C{point.Lng}{(point == Points.Last() ? "" : "%7C")}";
                destinations += $"{point.Lat}%2C{point.Lng}{(point == Points.Last() ? "" : "%7C")}";
            }

            var uri = "https://maps.googleapis.com/maps/api/distancematrix/json?"
                        + destinations
                        + origins
                        + "&units=metric"
                        + "&language=tr"
                        + "&key=AIzaSyCZJefF7Cf5vk_c0f6FzpYsJ7-pYcjPh0o";

            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.Accept = "application/json";

            var response = request.GetResponse();

            Root myDeserializedClass;


            using (Stream dStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dStream);
                var responseStr = reader.ReadToEnd();
                myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseStr);
            }
            response.Close();

            System.Windows.Forms.MessageBox.Show("DistMatrixRequest END");
            return AdjMatrixInit(myDeserializedClass);
        }

    }


  /*  public class Distance
    {
        public string text { get; set; }
        public long value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public List<Element> elements { get; set; }
    }

    public class Root
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }
    }*/
}