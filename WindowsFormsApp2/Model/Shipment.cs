using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTableApp.Model
{
    public class Shipment
    {
        public DateTime Date { get; set; }
        public string Org { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Manager { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
