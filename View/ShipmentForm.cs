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
using WindowsFormsApp2.Model;
using WindowsFormsApp2.Presenter;
using WindowsFormsApp2.View;

namespace WindowsFormsApp2
{
    public partial class ShipmentForm : MaterialForm, IShipmentView
    {
        public IEnumerable<Shipment> Shipments 
        {
            get => (IEnumerable<Shipment>)dataGridView1.DataSource;
            set => dataGridView1.DataSource = value;
        }
        public ShipmentPresenter Presenter { private get; set; }

        public ShipmentForm()
        {
            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            dataGridView1.DataSource = new List<Customer>
            {
                new Customer { Id = 1, Name = "The Very Big Corporation of America" },
                new Customer { Id = 2, Name = "Old Accountants Ltd" }
            };
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2");
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
