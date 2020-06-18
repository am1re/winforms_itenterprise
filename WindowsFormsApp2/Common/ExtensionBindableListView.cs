using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipmentTableApp.Common
{
    public static class ExtensionBindableListView
    {
        public static BindableListView RemoveEmptyColumns(this BindableListView listView)
        {
            //var columnNames = new List<string> { "one", "two", "three" };

            //listView.Columns.RemoveAt(0);
            //var columnsToDelete = listView.Columns.RemoveByKey("Date");

            //.AsQueryable().Expression(c => !columnNames.Contains(c.Name));

            //foreach (var column in columnsToDelete)
            //{
            //    listView.Columns.Remove(column);
            //}


            //for (int i = listView.Items.Count - 1; i >= 0; i--)
            //{
            //    if (string.IsNullOrWhiteSpace(listView.Items[i].Text))
            //    {
            //        listView.Items[i].Remove();
            //        MessageBox.Show("sd");
            //    }
            //}


            //for (int i = 0; i < listView.Items.Count; i++)
            //{
            //    if (listView.Items[i].Selected)
            //    {
            //        listView.Items[i].Remove();
            //        i--;
            //    }
            //}


            //if (listView.Items.Count == 0) return listView;

            //var col = listView.Columns.Cast<ColumnHeader>()
            //                    .Select((x, i) => new { x, i })
            //                    .FirstOrDefault(a => a.x.Text == "Date");

            //if (col == null) return listView;

            //foreach (ListViewItem item in listView.Items)
            //{
            //    item.SubItems[col.i].Text = "";
            //}

            //var col = listView.Columns.Cast<ColumnHeader>()
            //                    .Select((x, i) => new { x, i })
            //                    .FirstOrDefault(a => a.x.Text == "Date");

            return listView;
        }
    }
}
