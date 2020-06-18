using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipmentTableApp.Common
{
    public static class ExtensionGridView
    {
        public static bool IsEmpty(this DataGridViewCell cell)
        {
            var obj = cell.Value;
            return obj == null || obj == DBNull.Value || (obj as string) == string.Empty ||
                ((obj is DateTime time) && time == DateTime.MinValue) || ((obj is int val) && val == -1);
        }
        public static IEnumerable<DataGridViewColumn> EmptyColumns(this DataGridView gridView)
        {
            return gridView.Columns.Cast<DataGridViewColumn>()
                .Where(c => gridView.Rows.Cast<DataGridViewRow>()
                .All(r => r.Cells[c.Index].IsEmpty()));
        }
        public static IEnumerable<DataGridViewColumn> NotEmptyColumns(this DataGridView gridView)
        {
            return gridView.Columns.Cast<DataGridViewColumn>()
                .Where(c => gridView.Rows.Cast<DataGridViewRow>()
                .All(r => !r.Cells[c.Index].IsEmpty()));
        }
        public static DataGridView RemoveEmptyColumns(this DataGridView gridView)
        {
            foreach (var column in gridView.EmptyColumns())
                column.Visible = false;

            foreach (var column in gridView.NotEmptyColumns())
                column.Visible = true;

            return gridView;
        }
    }
}
