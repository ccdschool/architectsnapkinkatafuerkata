using System.Collections.Generic;

namespace appfragen.contracts
{
    public class Fragestellung
    {
        public Fragestellung() {
            Antwortmöglichkeiten = new string[0];
        }

        public string Frage { get; set; }

        public string[] Antwortmöglichkeiten { get; set; }
    }
}