using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo_Distributed_System.Entity
{
    class Cargo
    {
        public string cargoId { get; set; }
        public string customerId { get; set; }
        public string customerPhoneNumber { get; set; }
        public string cargoAddressLang { get; set; }
        public string cargoAddressLong { get; set; }
    }
}

