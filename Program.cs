using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Model;
using WindowsFormsApp2.Presenter;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repository = new ShipmentRepository();
            var view = new ShipmentForm();
            var presenter = new ShipmentPresenter(view, repository);

            Application.Run(view);
        }
    }
}
