using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipmentTableApp.Model
{
    public class ShipmentRepository : IShipmentRepository
    {
        public ShipmentRepository() { }

        public IEnumerable<Shipment> GetAllShipments()
        {
            var dataset = ExecuteSqlQuery("SELECT * FROM shipment");
            if (dataset == null || dataset.Tables.Count <= 0) return null;

            var result = DataTableToShipmentList(dataset.Tables[0]);

            return result;
        }

        public IEnumerable<Shipment> GetGroupedShipments(string[] columnNames)
        {
            if (columnNames == null) throw new ArgumentNullException(nameof(columnNames));

            var cols = string.Join(",", columnNames);
            var query = $"SELECT {cols}, SUM(quantity) as Quantity, SUM(total) as Total FROM shipment GROUP BY {cols}";

            var dataset = ExecuteSqlQuery(query);
            if (dataset == null || dataset.Tables.Count <= 0) return null;

            var result = DataTableToShipmentList(dataset.Tables[0]);
            return result;
        }

        public Shipment GetShipment(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveShipment(int id, Shipment shipment)
        {
            throw new NotImplementedException();
        }

        private static IList<Shipment> DataTableToShipmentList (DataTable table)
        {
            return table
                .AsEnumerable()
                .Select(dataRow => new Shipment
                {
                    Date = table.Columns.Contains("Date") ? dataRow.Field<DateTime>("Date") : DateTime.MinValue,
                    Org = table.Columns.Contains("Org") ? dataRow.Field<string>("Org") : null,
                    City = table.Columns.Contains("City") ? dataRow.Field<string>("City") : null,
                    Country = table.Columns.Contains("Country") ? dataRow.Field<string>("Country") : null,
                    Manager = table.Columns.Contains("Manager") ? dataRow.Field<string>("Manager") : null,
                    Quantity = table.Columns.Contains("Quantity") ? dataRow.Field<int>("Quantity") : -1,
                    Total = table.Columns.Contains("Total") ? dataRow.Field<double>("Total") : -1
                })
                .ToList();
        }

        private static DataSet ExecuteSqlQuery(string query)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=wfdb1;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    connection.Close();
                    return dataSet;
                }
            }
            catch (SqlException ex)
            {
                // log
                throw ex;
            }
        }
    }
}
