using System;
using System.Windows;
using appfragen.dialoge;

namespace appfragen.applikation
{
    public static class Program
    {
        [STAThread]
        public static void Main() {
            var fbDlg = new FragebogenDialog();
            var auswDlg = new AuswertungDialog();
            var inter = new Interaktoren();
            var app = new Applikation(fbDlg, auswDlg, inter);

            app.Run();

            var application = new Application { MainWindow = fbDlg };
            application.Run(fbDlg);
        }
    }
}