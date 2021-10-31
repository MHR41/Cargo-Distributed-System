using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cargo_Distributed_System
{
    public partial class DeliveryAdressScreenForm : Form
    {
        public DeliveryAdressScreenForm()
        {
            InitializeComponent();
        }

        private void Splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {
            gmap.DragButton = MouseButtons.Left;

            GMapProviders.GoogleMap.ApiKey = "AIzaSyCZJefF7Cf5vk_c0f6FzpYsJ7-pYcjPh0o";
            gmap.MapProvider = GMapProviders.GoogleMap;

            gmap.Position = new PointLatLng(40.76260455973796, 29.920291474244223);
            gmap.ShowCenter = false;
            gmap.Overlays.Add(Program.MarkerOverlay);
            gmap.Overlays.Add(Program.RouteOverlay);
        }

        private void InsertAddressButton_Click(object sender, EventArgs e)
        {
            // Inserts properly don't remove until end so we dont waste api free useage
           // return;
            var address = AddressInputBox.Text;
            var point = gmap.GeocodingProvider.GetPoint(address, out GeoCoderStatusCode status);
            if (status != GeoCoderStatusCode.OK)
            {
                MessageBox.Show($"Couldn't add address status: {status}");
                return;
            }
            Program.AddPoint((PointLatLng)point);
        }

        private void Gmap_MouseClick(object sender, MouseEventArgs e)
        {
            // Inserts properly don't remove until end so we dont waste api free useage
            if (e.Button == MouseButtons.Right)
            {
                var point = gmap.FromLocalToLatLng(e.X, e.Y);
                Program.AddPoint(point);
            }
        }

        private void AddressInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculateShorthestPathButton(object sender, EventArgs e)
        {
            Program.tspCalculator.Resume();
        }

    }
}
