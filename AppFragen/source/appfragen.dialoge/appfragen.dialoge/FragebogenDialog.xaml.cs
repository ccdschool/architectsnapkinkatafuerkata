using System;
using System.Linq;
using System.Windows;
using appfragen.contracts;

namespace appfragen.dialoge
{
    public partial class FragebogenDialog : Window
    {
        public FragebogenDialog() {
            InitializeComponent();

            btnAuswerten.Click += (o, e) => Auswerten();
            btnStart.Click += (o, e) => Befragung_starten();
            btnAntworten.Click += (o, e) => Antwort_gegeben(42);
        }

        public void Antwortbogen_anzeigen(Antwortbogen antwortbogen) {
            btnAuswerten.IsEnabled = antwortbogen.IstAuswertbar;
            lblFrage.Text = antwortbogen.Fragestellungen.First().Frage;
        }

        public event Action Befragung_starten;
        public event Action<int> Antwort_gegeben;
        public event Action Auswerten;
    }
}