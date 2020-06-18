using System.Collections.Generic;
using ShipmentTableApp.Model;
using ShipmentTableApp.Presenter;

namespace ShipmentTableApp.View
{
    public interface IShipmentView
    {
        IEnumerable<Shipment> Shipments { get; set; }
        ShipmentPresenter Presenter { set; }
        void ShowError(string message);
    }
}
