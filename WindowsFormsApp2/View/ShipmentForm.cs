using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShipmentTableApp.Common;
using ShipmentTableApp.Model;
using ShipmentTableApp.Presenter;
using ShipmentTableApp.View;

namespace ShipmentTableApp
{
    public partial class ShipmentForm : MaterialForm, IShipmentView
    {
        private static readonly Font _regularFont = new Font("Bahnschrift", 9.75f, FontStyle.Regular);
        private static readonly Font _highlightedFont = new Font("Bahnschrift", 10.00f, FontStyle.Underline);

        private readonly HashSet<string> _selectedColumns = new HashSet<string>();

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

        public IEnumerable<Shipment> Shipments
        {
            get => (IEnumerable<Shipment>)MainGridView.DataSource;
            set => MainGridView.DataSource = value?.ToList() ?? MainGridView.DataSource;
        }

        public ShipmentPresenter Presenter { private get; set; }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainGridView.Columns.Count; i++)
            {
                MainGridView.Columns[i].HeaderCell.Style.Font = _regularFont;
            }
            SelectedColsTextField.ResetText();
            _selectedColumns.Clear();

            Presenter.UpdateShipmentDataView();
        }

        private void MainGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnName = MainGridView.Columns[e.ColumnIndex].DataPropertyName;

            if (columnName == "Total" || columnName == "Quantity") return;

            if (_selectedColumns.Contains(columnName))
            {
                _selectedColumns.Remove(columnName);
                MainGridView.Columns[e.ColumnIndex].HeaderCell.Style.Font = _regularFont;
            }
            else 
            {
                _selectedColumns.Add(columnName);
                MainGridView.Columns[e.ColumnIndex].HeaderCell.Style.Font = _highlightedFont;
            }

            SelectedColsTextField.Text = string.Join(", ", _selectedColumns);
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            Presenter.UpdateShipmentDataViewGrouped(_selectedColumns.ToArray());
        }
    }
}
