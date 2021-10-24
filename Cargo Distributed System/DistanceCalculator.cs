using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Cargo_Distributed_System
{
    class DistanceCalculator
    {
        // Multi Threading fields
        private ManualResetEvent _mre = new ManualResetEvent(false);
        private Thread _Thread;
        private object _spLock = new object();

        // fields for Dijkstra 
        private List<PointLatLng> Points;
        private Dictionary<PointLatLng, List<Tuple<PointLatLng, double>>> PointGraph;
        private PointLatLng BaseOfOperations { get; set; }
        private Tuple<PointLatLng, List<PointLatLng>, PointLatLng> Route { get; set; }

        // Sets BaseOfOperations to default place i selected
        public DistanceCalculator()
        {
            _Thread = new Thread(new ThreadStart(Dijkstra)) { Name="shorthest-path", IsBackground=true};

            InitPoints(); // Initializes Points

            BaseOfOperations = new PointLatLng(40.76260455973796, 29.920291474244223);
            Points.Add(BaseOfOperations);

            
            CalculatePointGraph(); // initializes PointGraph

            _Thread.Start();
        }

        // Sets BaseOfOperations to custom place
        public DistanceCalculator(PointLatLng baseOfOperations)
        {
            _Thread = new Thread(new ThreadStart(Dijkstra)) { Name = "shorthest-path", IsBackground = true };


            InitPoints(); // Initializes Points

            BaseOfOperations = baseOfOperations;
            Points.Add(BaseOfOperations);


            CalculatePointGraph(); // initializes PointGraph

            _Thread.Start();
        }

        // TODO: Use distance matrix api here
        private void CalculatePointGraph()
        {

        }

        // TODO: Get data from database here
        private void InitPoints()
        {

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
            _mre.WaitOne();
            lock (_spLock)
            {
                var Q = new HashSet<PointLatLng>();
                var dist = new Dictionary<PointLatLng, double>();
                var prev = new Dictionary<PointLatLng, PointLatLng?>();

                foreach (var v in Points)
                {
                    dist.Add(v, double.PositiveInfinity);
                    prev.Add(v, null);
                    Q.Add(v);
                }

                dist[BaseOfOperations] = 0;

                PointLatLng last = BaseOfOperations;
                while (Q.Count > 0)
                {
                    PointLatLng u = dist.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                    Q.Remove(u);
                    last = u;
                    foreach (var v in PointGraph[u])
                    {
                        double temp = dist[u] + v.Item2;
                        if (temp < dist[v.Item1])
                        {
                            dist[v.Item1] = temp;
                            prev[v.Item1] = u;
                        }
                    }
                }

                List<PointLatLng> waypoints = new List<PointLatLng>();
                for (PointLatLng? p = prev[last]; p == null; p = prev[(PointLatLng)p])
                    waypoints.Add((PointLatLng)p);

                Route = new Tuple<PointLatLng, List<PointLatLng>, PointLatLng>(BaseOfOperations, waypoints, last);
            }
            _mre.Reset();
        }
    }
}
