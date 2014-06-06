using System.Collections.Generic;

namespace appfragen.contracts
{
    public class Antwortbogen
    {
        public Antwortbogen() {
            Fragestellungen = new List<Fragestellung>();
            Antworten = new List<int>();
        }

        public List<Fragestellung> Fragestellungen { get; set; }

        public List<int> Antworten { get; set; }

        public bool IstAuswertbar { get; set; }
    }
}