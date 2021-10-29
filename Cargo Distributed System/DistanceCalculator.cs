using GMap.NET;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;


namespace Cargo_Distributed_System
{
    class DistanceCalculator
    {
        // Multi Threading fields
        private ManualResetEvent _mre = new ManualResetEvent(false);
        private Thread _Thread;
        private readonly object _spLock = new object();

        // fields for Dijkstra 
        private Dictionary<PointLatLng, List<Tuple<PointLatLng, long>>> PointGraph = new Dictionary<PointLatLng, List<Tuple<PointLatLng, long>>>();
        public PointLatLng BaseOfOperations { get; set; }
        public GMapRoute Route { get; set; } = new GMapRoute("shorthest");
        public HashSet<PointLatLng> Points { get; set; }

        // Sets BaseOfOperations to default place i selected
        public DistanceCalculator()
        {
            _Thread = new Thread(new ThreadStart(Dijkstra)) { Name = "shorthest-path", IsBackground = true };

            InitPoints(); // Initializes Points

            _Thread.Start();
        }

        // Sets BaseOfOperations to custom place
        public DistanceCalculator(PointLatLng baseOfOperations)
        {
            _Thread = new Thread(new ThreadStart(Dijkstra)) { Name = "shorthest-path", IsBackground = true };


            InitPoints(); // Initializes Points

            BaseOfOperations = baseOfOperations;
            Points.Add(BaseOfOperations);

            _Thread.Start();
        }

        // TODO: Use distance matrix api here
        private void CalculatePointGraph()
        {
            System.Windows.Forms.MessageBox.Show("Point graph calculating");
            List<PointLatLng> orginPoints = new List<PointLatLng>();
            List<PointLatLng> destinationPoints = new List<PointLatLng>();
            var destinations = "destinations=";
            var origins = "&origins=";
            foreach (var point in Points)
            {
                orginPoints.Add(point);
                origins += $"{point.Lat}%2C{point.Lng}{(point == Points.Last() ? "" : "%7C")}";
                
                if (point == BaseOfOperations) continue;
                destinationPoints.Add(point);
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
            var rows = myDeserializedClass.rows;
            for (int i = 0; i < orginPoints.Count; i++)
            {
                var adjList = new List<Tuple<PointLatLng, long>>();
                var orginPoint = orginPoints[i];
                Row row = rows[i];
                for (int j = 0; j < destinationPoints.Count; j++)
                {
                    var destPoint = destinationPoints[j];
                    var distance = row.elements[j].distance.value;
                    var graphNode = new Tuple<PointLatLng, long>(destPoint, distance);
                    adjList.Add(graphNode);
                }
                if (PointGraph.ContainsKey(orginPoint))
                {
                    PointGraph[orginPoint] = adjList;
                }
                else
                {
                    PointGraph.Add(orginPoint, adjList);
                }
            }
            System.Windows.Forms.MessageBox.Show("Point graph DONE");
        }

        // TODO: Get data from database here
        private void InitPoints()
        {
            Points = new HashSet<PointLatLng>();
        }

        /* 
         * !! After adding a point to list DON'T forget to calculate PointGraph !!
         * !! BUT don't calculate it until you finish adding points !!
         */
        public void AddPoint(PointLatLng point)
        {
            Points.Add(point);
        }

        /* 
         * !! After removeing a point to list DON'T forget to calculate PointGraph !!
         * !! BUT don't calculate it until you finish removing points !!
         */
        public void RemovePoint(PointLatLng point)
        {
            _ = Points.Remove(point);
        }

        // MultiThreading stuff
        public void Resume() => _mre.Set();
        public void Pause() => _mre.Reset();

        /* Dijkstra's algorithm implementation
         * 
         * changes route field as (start, waypoints, end)
         */
        private void Dijkstra()
        {
            while (true)
            {
                _mre.WaitOne();
                CalculatePointGraph();
                lock (_spLock)
                {
                    var Q = new HashSet<PointLatLng>(PointGraph.Keys);
                    var dist = new Dictionary<PointLatLng, long>();
                    var prev = new Dictionary<PointLatLng, PointLatLng?>();

                    foreach (var v in PointGraph.Keys)
                    {
                        dist.Add(v, long.MaxValue);
                        prev.Add(v, null);
                    }

                    dist[BaseOfOperations] = 0;
                    PointLatLng last = BaseOfOperations;
                    
                    while (Q.Any())
                    {
                        PointLatLng u = dist.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                        last = u;
                        Q.Remove(u);
                        foreach (var v in PointGraph[u])
                        {
                            long temp = dist[u] + v.Item2;
                            if (!Q.Contains(v.Item1)) continue;

                            if (temp < dist[v.Item1])
                            {
                                dist[v.Item1] = temp;
                                prev[v.Item1] = u;
                            }
                        }
                        dist.Remove(u);
                    }
                    var path = new List<PointLatLng>();
                    PointLatLng target = last;
                    while(prev[target] != null)
                    {
                        path.Add(target);
                        target = (PointLatLng) prev[target];
                    }
                    path.Add(BaseOfOperations);
                    path.Reverse();

                    Route = new GMapRoute(path, "shorthest")
                    {
                        Stroke = new Pen(Color.Red, 3)
                    };
                    if (Program.RouteOverlay.Routes.Contains(Route))
                    {
                        Program.RouteOverlay.Routes.Remove(Route);
                    }

                    Program.RouteOverlay.Routes.Add(Route);
                    System.Windows.Forms.MessageBox.Show(Route.IsVisible.ToString());
                    System.Windows.Forms.MessageBox.Show("Dijkstra Done");
                }
                Pause();
            }
        }
    }

    // https://json2csharp.com/ is used to generate the template below
    // only change is distance value type from int to long
    
    public class Distance
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
    }

    public class EqualityPointLatLng : EqualityComparer<PointLatLng>
    {
        public override bool Equals(PointLatLng p1, PointLatLng p2)
        {
            return PointLatLng.Equals(p1, p2);
        }

        public override int GetHashCode(PointLatLng p)
        {
            return p.GetHashCode();
        }
    }
}
