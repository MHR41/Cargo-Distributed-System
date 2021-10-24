using GMap.NET;
using GMap.NET.MapProviders;
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

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gmap.DragButton = MouseButtons.Left;

            GMapProviders.GoogleMap.ApiKey = "AIzaSyCZJefF7Cf5vk_c0f6FzpYsJ7-pYcjPh0o";
            gmap.MapProvider = GMapProviders.GoogleMap;

            gmap.Position = new PointLatLng(40.76260455973796, 29.920291474244223);
            gmap.ShowCenter = false;
        }
    }
}
