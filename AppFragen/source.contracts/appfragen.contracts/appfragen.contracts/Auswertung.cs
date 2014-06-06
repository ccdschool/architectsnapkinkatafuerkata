using System.Collections.Generic;

namespace appfragen.contracts
{
    public class Auswertung
    {
        public Auswertung() {
            Auflösungen = new List<Auflösung>();
        }

        public int AnzahlFragestellungen { get; set; }
        public int KorrekteAntworten { get; set; }

        public List<Auflösung> Auflösungen { get; set; }
    }
}