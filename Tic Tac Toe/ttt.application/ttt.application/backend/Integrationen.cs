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
            _spielregeln = new Spielregeln(_spielbrett);
        }

        public void Starten()
        {
            Neues_Spiel_erzeugen();   
        }

        public void Spielstein_setzen(int spielfeldIndex)
        {
            var hinweis = "";
            _spielregeln.Zug_validieren(spielfeldIndex,
                index => {
                    _spielbrett.Zug_registrieren(spielfeldIndex);
                    Spielende_prüfen(
                        gewinner => hinweis = gewinner,
                        () => hinweis = _spielregeln.Spieler_bestimmen());
                },
                err => hinweis = _spielregeln.Spieler_bestimmen(err));
            var spielstand = _projektionen.Spielstand_erzeugen(_spielbrett.Züge, hinweis);
            this.Spielstand(spielstand);
        }

        private void Spielende_prüfen(Action<string> spielende, Action weiter)
        {
            _spielregeln.Gewinner_ermitteln(
                spielende,
                () => _spielregeln.Unentschieden_ermitteln(
                    spielende,
                    weiter));
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
