using System;
using NUnit.Framework;
using ttt.application.data;

namespace ttt.application.tests
{
    [TestFixture]
    public class test_Spielbrett
    {
        [Test]
        public void Jedes_Spielfeld_darf_nur_einmal_besetzt_werden()
        {
            var sut = new Spielbrett();

            sut.Leeren();
            sut.Zug_registrieren(0);
            sut.Zug_registrieren(1);

            Assert.Throws<InvalidOperationException>(() => sut.Zug_registrieren(0));
        } 
    }
}