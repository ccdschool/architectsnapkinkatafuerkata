namespace appfragen.contracts.beispieldaten
{
    public class Auswertungsfabrik
    {
        public static Auswertung Herstellen()
        {
            return new Auswertung {
                AnzahlFragestellungen = 2,
                KorrekteAntworten = 1,
                Auflösungen = new[] {
                    new Auflösung{Frage = "Welches Tier ist kein Säugetier?", Antwort = "Ameise", Lösung = "Ameise"},
                    new Auflösung{Frage="Wie lautet die ultimative Antwort?", Antwort = "007", Lösung = "42"}
                }
            };
        }
    }
}