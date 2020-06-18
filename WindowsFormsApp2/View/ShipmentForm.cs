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
        public IEnumerable<Shipment> Shipments
        {
            get => (IEnumerable<Shipment>)dataGridView1.DataSource;
            set
            {
                dataGridView1.DataSource = value?.ToList() ?? dataGridView1.DataSource;
                //materialListView1.D = value?.ToList() ?? dataGridView1.DataSource;
                //bindableListView1.DataSource = value?.ToList() ?? dataGridView1.DataSource;
                //dataListView1.DataSource = value?.ToList() ?? dataGridView1.DataSource;
            }
        }
        public ShipmentPresenter Presenter { private get; set; }

        public ShipmentForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.LightBlue800, 
                Primary.LightBlue900, 
                Primary.LightBlue500, 
                Accent.LightBlue200, 
                TextShade.WHITE);


            dataGridView1.DataSourceChanged += (s, e) => dataGridView1.RemoveEmptyColumns();
            //bindableListView1.DataSourceChanged += (s, e) => bindableListView1.RemoveEmptyColumns();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            Presenter.UpdateShipmentDataView();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            Presenter.UpdateShipmentDataView2();
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            Presenter.UpdateShipmentDataView3();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
