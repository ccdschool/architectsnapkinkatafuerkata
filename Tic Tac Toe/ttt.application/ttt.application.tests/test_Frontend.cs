using NUnit.Framework;
using ttt.application.data;

namespace ttt.application.tests
{
    [TestFixture]
    public class test_Frontend
    {
        [Test, Explicit]
        public void Spielstand_anzeigen()
        {
            var sut = new Frontend();

            var spielstand = new Spielstand {
                Hinweis = "abc",
                Spielbrett = new[] {Spielstein.X, Spielstein.Leer, Spielstein.O}
            };

            sut.Spielstand_anzeigen(spielstand);

            sut.ShowDialog();
        } 
    }
}