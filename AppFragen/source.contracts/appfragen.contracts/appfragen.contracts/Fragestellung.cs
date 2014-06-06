using System.Collections.Generic;

namespace appfragen.contracts
{
    public class Fragestellung
    {
        public Fragestellung() {
            Antwortmöglichkeiten = new List<string>();
        }

        public string Frage { get; set; }

        public List<string> Antwortmöglichkeiten { get; set; }
    }
}