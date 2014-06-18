using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appfragen.contracts.beispieldaten
{
    public class Antwortbogenfabrik
    {
        public static Antwortbogen InBearbeitung
        {
            get {
                return new Antwortbogen {
                    Fragestellungen = new[]
                        {
                            new Fragestellung
                                {
                                    Frage = "Welches Tier ist kein Säugetier?",
                                    Antwortmöglichkeiten = new[] {"Hund", "Katze", "Ameise", "Maus", "Keine Ahnung"}
                                },
                            new Fragestellung
                                {
                                    Frage = "Wie lautet die ultimative Antwort?",
                                    Antwortmöglichkeiten = new[] {"0815", "42", "007", "Keine Ahnung"}
                                }
                        },
                    Antworten = new[] {2},
                    IstAuswertbar = false
                };
            }
        }


        public static Antwortbogen Fertig
        {
            get { 
                var awb = InBearbeitung;
                awb.Antworten = new[] {2,7};
                awb.IstAuswertbar = true;
                return awb;
            }
        }
    }
}
