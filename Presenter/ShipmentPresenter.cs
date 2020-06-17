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

        private void UpdateShipmentDataView()
        {
            _view.Shipments = _repository.GetAllShipments();
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
