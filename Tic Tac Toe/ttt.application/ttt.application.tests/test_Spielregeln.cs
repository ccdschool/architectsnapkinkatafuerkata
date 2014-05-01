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
    }
}