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
            Zug_ausführen(spielfeldIndex,
                () => hinweis = Spielstand_ermitteln(),
                err => hinweis = err);
            var spielstand = _projektionen.Spielstand_erzeugen(_spielbrett.Züge, hinweis);
            this.Spielstand(spielstand);
        }

        private void Zug_ausführen(int spielfeldindex, Action validerZug, Action<string> invaliderZug)
        {
            _spielregeln.Zug_validieren(spielfeldindex,
                index => {
                    _spielbrett.Zug_registrieren(spielfeldindex);
                    validerZug();
                },
                err => {
                    var hinweis = _spielregeln.Spieler_bestimmen(err);
                    invaliderZug(hinweis);
                });
        }

        private string Spielstand_ermitteln()
        {
            var hinweis = "";
            Spielende_prüfen(
                gewinner => hinweis = gewinner,
                () => hinweis = _spielregeln.Spieler_bestimmen());
            return hinweis;
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
            var hinweis = _spielregeln.Spieler_bestimmen();
            var spielstand = _projektionen.Spielstand_erzeugen(_spielbrett.Züge, hinweis);
            this.Spielstand(spielstand);
        }


        public event Action<Spielstand> Spielstand;
    }
}
