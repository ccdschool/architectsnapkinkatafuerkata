using NUnit.Framework;
using ttt.application.backend;
using ttt.application.data;

namespace ttt.application.tests
{
    [TestFixture]
    public class test_Projektionen
    {
        [Test]
        public void Spielstand_ohne_Züge()
        {
            var sut = new Projektionen();

            var result = sut.Spielstand_erzeugen(new int[0], "abc");

            Assert.AreEqual(new Spielstein[9], result.Spielbrett);
            Assert.AreEqual("abc", result.Hinweis);
        }


        [Test]
        public void Spielstand_mit_Zügen()
        {
            var sut = new Projektionen();

            var result = sut.Spielstand_erzeugen(new[]{0,8,4}, "");

            var spielbrett = new Spielstein[9];
            spielbrett[0] = Spielstein.X;
            spielbrett[4] = Spielstein.X;
            spielbrett[8] = Spielstein.O;

            Assert.AreEqual(spielbrett, result.Spielbrett);
        }
    }
}
