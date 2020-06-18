using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
