using System;
using System.Text;
using System.Threading.Tasks;
using ttt.application.data;

namespace ttt.application.backend
{
    class Integrationen
    {
        private readonly Spielbrett _spielbrett;
        private readonly Spielregeln _spielregeln;
        private readonly Projektionen _projektionen;

        public Integrationen(Spielbrett spielbrett)
        {
            _spielbrett = spielbrett;
            _projektionen = new Projektionen();
            _spielregeln = new Spielregeln();
        }

        public void Starten()
        {
            Neues_Spiel_erzeugen();   
        }

        public void Spielstein_setzen(int spielfeldIndex)
        {
            _spielbrett.Zug_registrieren(spielfeldIndex);
            var hinweis = _spielregeln.Spieler_bestimmen(_spielbrett.Züge);
            var spielstand = _projektionen.Spielstand_erzeugen(_spielbrett.Züge, hinweis);
            this.Spielstand(spielstand);
        }

        public void Neues_Spiel_erzeugen()
        {
            _spielbrett.Leeren();
            var hinweis = "X am Zug";
            var spielstand = _projektionen.Spielstand_erzeugen(_spielbrett.Züge, hinweis);
            this.Spielstand(spielstand);
        }

        public event Action<Spielstand> Spielstand;
    }
}
