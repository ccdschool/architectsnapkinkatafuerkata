using System.Linq;
using NUnit.Framework;
using ttt.application.backend;
using ttt.application.data;

namespace ttt.application.tests
{
    [TestFixture]
    public class test_Spielregeln
    {
        [Test]
        public void Spieler_bestimmen()
        {
            var spielbrett = new Spielbrett();
            var sut = new Spielregeln(spielbrett);
            spielbrett.Leeren();

            var result = sut.Spieler_bestimmen();
            Assert.AreEqual("X am Zug", result);

            spielbrett.Zug_registrieren(0);
            result = sut.Spieler_bestimmen("@@@");
            Assert.AreEqual("@@@ O am Zug", result);

            spielbrett.Zug_registrieren(8);
            result = sut.Spieler_bestimmen();
            Assert.AreEqual("X am Zug", result);
        }


        [Test]
        public void Gewinn_ermitteln()
        {
            var spielbrett = new Spielbrett();
            spielbrett.Leeren();

            spielbrett.Zug_registrieren(0); // X
            spielbrett.Zug_registrieren(1); // O
            spielbrett.Zug_registrieren(4); // X
            spielbrett.Zug_registrieren(5); // O
            spielbrett.Zug_registrieren(8); // X

            var sut = new Spielregeln(spielbrett);

            var result = "";
            sut.Gewinner_ermitteln(_ => result = _, null);

            Assert.AreNotEqual("", result);
        }

        [Test]
        public void Züge_nach_Spielern_trennen()
        {
            var spielbrett = new Spielbrett();
            spielbrett.Leeren();

            spielbrett.Zug_registrieren(0); // X
            spielbrett.Zug_registrieren(1); // O
            spielbrett.Zug_registrieren(4); // X
            spielbrett.Zug_registrieren(5); // O
            spielbrett.Zug_registrieren(8); // X

            var sut = new Spielregeln(spielbrett);

            var result = sut.Züge_nach_Spielern_trennen();

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(new[]{0,4,8}, result[0]);
            Assert.AreEqual(new[] { 1, 5}, result[1]);
        }

        [Test]
        public void Gewinnreihe_generieren()
        {
            var sut = new Spielregeln(null);

            var result = sut.Gewinnreihe_generieren(0, 4, 3).ToArray();

            Assert.That(result, Is.EquivalentTo(new[]{0,4,8}));
        }

        [Test]
        public void Spielergewinn_prüfen()
        {
            var sut = new Spielregeln(null);

            var gewinnreihen = new[] {new[] {1, 2, 3}, new[] {2, 4, 6}};
            var result = "";

            var spielerzüge = new[] {6, 4, 2};
            sut.Spielergewinn_prüfen(gewinnreihen, spielerzüge, () => result = "gewinn", null);
            Assert.AreEqual("gewinn", result);

            spielerzüge = new[] { 6, 4 };
            sut.Spielergewinn_prüfen(gewinnreihen, spielerzüge, null, () => result = "weiter");
            Assert.AreEqual("weiter", result);
        }
    }
}