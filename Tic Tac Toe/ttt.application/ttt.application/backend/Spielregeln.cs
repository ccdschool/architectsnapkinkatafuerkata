using System;
using System.Collections.Generic;
using System.Linq;
using ttt.application.data;

namespace ttt.application.backend
{
    class Spielregeln
    {
        private readonly Spielbrett _spielbrett;

        public Spielregeln(Spielbrett spielbrett)
        {
            _spielbrett = spielbrett;
        } 

        public string Spieler_bestimmen(IEnumerable<int> züge, string hinweis = "")
        {
            var spielerhinweis = züge.Count()%2 == 0 ? "X am Zug" : "O am Zug";
            return hinweis + (hinweis == "" ? "" : " ") + spielerhinweis;
        }

        public void Zug_validieren(int spielfeldindex, Action<int> validerZug, Action<string> invaliderZug)
        {
            if (_spielbrett.Wurde_Zug_schon_ausgeführt(spielfeldindex))
                invaliderZug("Ungültiger Zug!");
            else
                validerZug(spielfeldindex);
        }
    }
}