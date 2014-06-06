using System.Collections.Generic;

namespace appfragen.contracts
{
    public class Auswertung
    {
        public Auswertung() {
            Auflösungen = new List<Auflösung>();
        }

        public int KorrekteAntworten { get; set; }

        public int AnzahlFragestellungen { get; set; }

        public List<Auflösung> Auflösungen { get; set; }
    }
}