using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using appfragen.dialoge;

namespace appfragen.applikation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var fbDlg = new FragebogenDialog();
            var auswDlg = new AuswertungDialog();
            var inter = new Interaktoren();
            var app = new Applikation(fbDlg, auswDlg, inter);

            app.Run();
        }
    }
}
