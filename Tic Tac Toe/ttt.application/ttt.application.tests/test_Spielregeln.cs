using NUnit.Framework;
using ttt.application.backend;

namespace ttt.application.tests
{
    [TestFixture]
    public class test_Spielregeln
    {
        [Test]
        public void Spieler_bestimmen()
        {
            var sut = new Spielregeln();

            var result = sut.Spieler_bestimmen(new int[0]);
            Assert.AreEqual("X am Zug", result);

            result = sut.Spieler_bestimmen(new[] {0});
            Assert.AreEqual("O am Zug", result);

            result = sut.Spieler_bestimmen(new[] { 0, 8 });
            Assert.AreEqual("X am Zug", result);
        } 
    }
}