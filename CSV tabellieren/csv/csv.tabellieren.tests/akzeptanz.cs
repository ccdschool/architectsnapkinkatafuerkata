using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace csv.tabellieren.tests
{
    [TestFixture]
    public class akzeptanz
    {
        [Test]
        public void Ganz_simple_Datei_tabellieren()
        {
            var sut = new CsvTabellierer();

            var tabelle = sut.Tabellieren(File.ReadLines("simpel.csv")).ToArray();

            Assert.AreEqual(File.ReadLines("simpeltabelle.txt").ToArray(), tabelle);
        }


        [Test]
        public void Datei_tabellieren_mit_unterschiedlichen_Spaltenbreiten()
        {
            var sut = new CsvTabellierer();

            var tabelle = sut.Tabellieren(File.ReadLines("personen.csv")).ToArray();

            Assert.AreEqual(File.ReadLines("personentabelle.txt").ToArray(), tabelle);
        }
    }
}
