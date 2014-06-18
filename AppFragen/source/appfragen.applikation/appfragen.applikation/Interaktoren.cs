using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appfragen.contracts;
using appfragen.contracts.beispieldaten;

namespace appfragen.applikation
{
    class Interaktoren
    {
        public void Starten()
        {
            Befragung_starten();
        }


        public void Befragung_starten()
        {
            Antwortbogen(Antwortbogenfabrik.InBearbeitung);
        }

        // iteration 2: Antwort loggen
        public void Antworten(int antwort)
        {
            Antwortbogen(Antwortbogenfabrik.Fertig);
        }


        public void Auswerten()
        {
            Auswertung(Auswertungsfabrik.Herstellen());
        }


        public event Action<Antwortbogen> Antwortbogen;
        public event Action<Auswertung> Auswertung;
    }
}
