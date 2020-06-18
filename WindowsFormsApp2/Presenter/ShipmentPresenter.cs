using System;
using ShipmentTableApp.Model;
using ShipmentTableApp.View;

namespace ShipmentTableApp.Presenter
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
            try
            {
                _view.Shipments = _repository.GetAllShipments();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        public void UpdateShipmentDataViewGrouped(string[] columns)
        {
            if (columns == null || columns.Length <= 0)
            {
                _view.ShowError("You did not select any fields!");
                return;
            }

            try
            {
                _view.Shipments = _repository.GetGroupedShipments(columns);
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}
