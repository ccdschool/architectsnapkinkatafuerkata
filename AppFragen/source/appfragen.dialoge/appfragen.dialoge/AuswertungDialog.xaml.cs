using System;
using System.ComponentModel;
using System.Windows;
using appfragen.contracts;

namespace appfragen.dialoge
{
    public partial class AuswertungDialog : Window
    {
        public AuswertungDialog() {
            InitializeComponent();

            Closed += (o, e) => Auswertung_beendet();
        }

        protected override void OnClosing(CancelEventArgs e) {
            e.Cancel = true;
            Hide();
        }

        public void Auswertung_Anzeigen(Auswertung auswertung) {
            ShowDialog();
        }

        public event Action Auswertung_beendet;
    }
}