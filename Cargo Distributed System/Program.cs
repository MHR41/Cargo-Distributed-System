using System;
using System.Windows.Forms;

namespace Cargo_Distributed_System
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DeliveryAdressScreenForm());
            Application.Exit();
        }
    }
}
