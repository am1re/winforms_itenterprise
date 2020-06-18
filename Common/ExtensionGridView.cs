using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Common
{
    public static class ExtensionGridView
    {
        public static bool IsEmpty(this DataGridViewCell cell)
        {
            var value = cell.Value;
            return value == null || value == DBNull.Value || (value as string) == string.Empty;
        }
        public static IEnumerable<DataGridViewColumn> EmptyColumns(this DataGridView gridView)
        {
            return gridView.Columns.Cast<DataGridViewColumn>()
                .Where(c => gridView.Rows.Cast<DataGridViewRow>().All(r => r.Cells[c.Index].IsEmpty()));
        }
        public static IEnumerable<DataGridViewColumn> NotEmptyColumns(this DataGridView gridView)
        {
            return gridView.Columns.Cast<DataGridViewColumn>()
                .Where(c => gridView.Rows.Cast<DataGridViewRow>().All(r => !r.Cells[c.Index].IsEmpty()));
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
