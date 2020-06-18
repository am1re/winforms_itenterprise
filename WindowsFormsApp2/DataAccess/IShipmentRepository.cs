using System.Collections.Generic;

namespace ShipmentTableApp.Model
{
    public interface IShipmentRepository
    {
        IEnumerable<Shipment> GetAllShipments();
        IEnumerable<Shipment> GetGroupedShipments(string[] columnNames);
        Shipment GetShipment(int id);
        void SaveShipment(int id, Shipment shipment);
    }
}
