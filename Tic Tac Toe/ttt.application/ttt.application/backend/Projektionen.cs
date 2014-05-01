using System.Collections.Generic;
using System.Linq;
using ttt.application.data;

namespace ttt.application.backend
{
    internal class Projektionen
    {
        public Spielstand Spielstand_erzeugen(IEnumerable<int> züge, string hinweis)
        {
            var spielstand = new Spielstand {Hinweis = hinweis, Spielbrett = new Spielstein[9]};

            züge.Select((z,i) => new {Spielfeldindex = z, Spielstein = i%2==0? Spielstein.X : Spielstein.O}).ToList()
                .ForEach(z => spielstand.Spielbrett[z.Spielfeldindex] = z.Spielstein);

            return spielstand;
        }
    }
}