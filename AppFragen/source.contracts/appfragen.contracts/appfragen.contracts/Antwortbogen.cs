using System.Collections.Generic;

namespace appfragen.contracts
{
    public class Antwortbogen
    {
        public Antwortbogen() {
            Fragestellungen = new Fragestellung[0];
            Antworten = new int[0];
        }

        public Fragestellung[] Fragestellungen { get; set; }

        public int[] Antworten { get; set; }

        public bool IstAuswertbar { get; set; }
    }
}