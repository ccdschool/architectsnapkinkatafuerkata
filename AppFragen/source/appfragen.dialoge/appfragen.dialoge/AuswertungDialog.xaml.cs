using System;
using System.Windows;
using appfragen.contracts;

namespace appfragen.dialoge
{
    public partial class AuswertungDialog : Window
    {
        public AuswertungDialog() {
            InitializeComponent();

            this.Closed += (o, e) => Auswertung_beendet(); 
        }


        public void Auswertung_Anzeigen(Auswertung auswertung) {
            ShowDialog();
        }


        public event Action Auswertung_beendet;
    }
}