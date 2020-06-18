using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    public class ShipmentRepository : IShipmentRepository
    {
        public ShipmentRepository()
        {

        }

        public IEnumerable<Shipment> GetAllShipments()
        {
            DataSet ds = SqlQuery("SELECT * FROM shipment");
            var result = ds.Tables[0]
                .AsEnumerable()
                .Select(dataRow => new Shipment
                {
                    Date = dataRow.Field<DateTime>("Date"),
                    Org = dataRow.Field<string>("Org"),
                    City = dataRow.Field<string>("City"),
                    Country = dataRow.Field<string>("Country"),
                    Manager = dataRow.Field<string>("Manager"),
                    Quantity = dataRow.Field<int>("Quantity"),
                    Total = dataRow.Field<double>("Total")
                })
                .ToList();

            return result;
        }

        public IEnumerable<Shipment> GetGroupedShipments(string[] columnNames)
        {
            throw new NotImplementedException();
        }

        public Shipment GetShipment(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveShipment(int id, Shipment shipment)
        {
            throw new NotImplementedException();
        }

        private DataSet SqlQuery(string query)
        {
            DataSet dataSet = null;
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=wfdb1;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return dataSet;
        }
    }
}
