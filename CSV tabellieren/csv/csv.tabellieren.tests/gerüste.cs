using System;
using System.Reflection;
using NUnit.Framework;

namespace csv.tabellieren.tests
{
    [TestFixture]
    public class gerüste
    {
        [Test]
        public void Spaltenbreiten_ermitteln()
        {
            var mi = typeof (CsvTabellierer).GetMethod("Spaltenbreiten_ermitteln", BindingFlags.NonPublic | BindingFlags.Instance);
            var sut = new CsvTabellierer();

            var tabellenteile = new Tuple<string[], string[][]>(
                new[]{"1", "22", "333"},
                new[]{new[]{"a", "b", "cccc"}});

            var result = mi.Invoke(sut, new object[]{ tabellenteile });

            Assert.AreEqual(new[]{1, 2, 4}, result);
        } 
    }
}