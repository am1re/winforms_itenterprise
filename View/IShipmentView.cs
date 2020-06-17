using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Model;
using WindowsFormsApp2.Presenter;

namespace WindowsFormsApp2.View
{
    public interface IShipmentView
    {
        IEnumerable<Shipment> Shipments { get; set; }
        ShipmentPresenter Presenter { set; }
    }
}
