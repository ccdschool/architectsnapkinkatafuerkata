using appfragen.dialoge;

namespace appfragen.applikation
{
    internal class Applikation
    {
        private readonly FragebogenDialog _fbDlg;
        private readonly Interaktoren _inter;

        public Applikation(FragebogenDialog fbDlg, AuswertungDialog auswDlg, Interaktoren inter) {
            _fbDlg = fbDlg;
            _inter = inter;

            fbDlg.Antwort_gegeben += inter.Antworten;
            fbDlg.Auswerten += inter.Auswerten;
            fbDlg.Befragung_starten += inter.Befragung_starten;
            auswDlg.Auswertung_beendet += inter.Befragung_starten;

            _inter.Antwortbogen += fbDlg.Antwortbogen_anzeigen;
            _inter.Auswertung += auswDlg.Auswertung_Anzeigen;
        }

        public void Run() {
            _inter.Starten();
            _fbDlg.Show();
        }
    }
}