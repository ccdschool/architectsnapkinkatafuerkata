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

        public void Auswertung_Anzeigen(Auswertung auswertung)
        {
            txtStatus.Text = string.Format("{0} Fragen, {1} korrekte Antworten", 
                                           auswertung.AnzahlFragestellungen,
                                           auswertung.KorrekteAntworten);
            ShowDialog();
        }

        public event Action Auswertung_beendet;
    }
}