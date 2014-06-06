using System.Collections.Generic;

namespace appfragen.contracts
{
    public class Auswertung
    {
        public Auswertung() {
            Auflösungen = new Auflösung[0];
        }

        public int AnzahlFragestellungen { get; set; }
        public int KorrekteAntworten { get; set; }

        public Auflösung[] Auflösungen { get; set; }
    }
}