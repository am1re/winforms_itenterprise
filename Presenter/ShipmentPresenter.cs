using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Model;
using WindowsFormsApp2.View;

namespace WindowsFormsApp2.Presenter
{
    public class ShipmentPresenter
    {
        private readonly IShipmentView _view;
        private readonly IShipmentRepository _repository;

        public ShipmentPresenter(IShipmentView view, IShipmentRepository repository)
        {
            _view = view;
            _repository = repository;

            view.Presenter = this;
            UpdateShipmentDataView();
        }

        public void UpdateShipmentDataView()
        {
            //_view.Shipments = _repository.GetAllShipments();
            var result = new List<Shipment> {
                new Shipment { Date = DateTime.Now, City="City1", Country="Country1", Manager="Manager1", Org="Org1", Quantity=100, Total=2000},
                new Shipment { Date = DateTime.Now, City="City2", Country="Country2", Manager="Manager2", Org="Org2", Quantity=100, Total=2000},
                new Shipment { Date = DateTime.Now, City="City3", Country="Country3", Manager="Manager3", Org="Org3", Quantity=100, Total=2000},
            };
            _view.Shipments = result;
        }

        public void UpdateShipmentDataView2()
        {
            //_view.Shipments = _repository.GetAllShipments();
            var result = new List<Shipment> {
                new Shipment { Date = DateTime.Now, Org="Org1", Quantity=100, Total=2000},
                new Shipment { Date = DateTime.Now, Org="Org2", Quantity=100, Total=2000},
                new Shipment { Date = DateTime.Now, Org="Org3", Quantity=100, Total=2000},
            };
            _view.Shipments = result;
        }

        //private void UpdateCustomerListView()
        //{
        //    var customerNames = from customer in _repository.GetAllCustomers() select customer.Name;
        //    int selectedCustomer = _view.SelectedCustomer >= 0 ? _view.SelectedCustomer : 0;
        //    _view.CustomerList = customerNames.ToList();
        //    _view.SelectedCustomer = selectedCustomer;
        //}

        //public void UpdateCustomerView(int p)
        //{
        //    // customer list can be cached instead of re-fetching the customer each time
        //    // this may be infeasible if the list is large
        //    Customer customer = _repository.GetCustomer(p);
        //    _view.CustomerName = customer.Name;
        //    _view.Address = customer.Address;
        //    _view.Phone = customer.Phone;
        //}

        //public void SaveCustomer()
        //{
        //    Customer customer = new Customer { Name = _view.CustomerName, Address = _view.Address, Phone = _view.Phone };
        //    _repository.SaveCustomer(_view.SelectedCustomer, customer);
        //    UpdateCustomerListView();
        //}
    }
}
