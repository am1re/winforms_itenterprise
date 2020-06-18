using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    public interface IShipmentRepository
    {
        IEnumerable<Shipment> GetAllShipments();
        IEnumerable<Shipment> GetGroupedShipments(string[] columnNames);
        Shipment GetShipment(int id);
        void SaveShipment(int id, Shipment shipment);
    }
}
