using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShipmentTableApp.Common;
using ShipmentTableApp.Model;
using ShipmentTableApp.Presenter;
using ShipmentTableApp.View;

namespace ShipmentTableApp
{
    public partial class ShipmentForm : MaterialForm, IShipmentView
    {
        private readonly HashSet<string> _selectedColumns = new HashSet<string>();

        public IEnumerable<Shipment> Shipments
        {
            get => (IEnumerable<Shipment>)MainGridView.DataSource;
            set => MainGridView.DataSource = value?.ToList() ?? MainGridView.DataSource;
        }
        public ShipmentPresenter Presenter { private get; set; }

        public ShipmentForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.LightBlue800, 
                Primary.LightBlue900, 
                Primary.LightBlue500, 
                Accent.LightBlue200, 
                TextShade.WHITE);

            MainGridView.DataSourceChanged += (s, e) => MainGridView.RemoveEmptyColumns();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            _selectedColumns.Clear();
            SelectedColsTextField.ResetText();

            Presenter.UpdateShipmentDataView();
        }

        private void MainGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnName = MainGridView.Columns[e.ColumnIndex].DataPropertyName;
            if (_selectedColumns.Contains(columnName))
            {
                _selectedColumns.Remove(columnName);
                MainGridView.Columns[e.ColumnIndex].HeaderCell.Style.Font = new Font("Bahnschrift", 9.75f, FontStyle.Regular);
            }
            else 
            {
                _selectedColumns.Add(columnName);
                MainGridView.Columns[e.ColumnIndex].HeaderCell.Style.Font = new Font("Bahnschrift", 10.00f, FontStyle.Underline);
            }

            SelectedColsTextField.Text = string.Join(", ", _selectedColumns);
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            Presenter.UpdateShipmentDataViewGrouped(_selectedColumns.ToArray());
        }
    }
}
