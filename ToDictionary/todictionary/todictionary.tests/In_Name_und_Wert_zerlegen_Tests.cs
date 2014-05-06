using System.Collections.Generic;
using NUnit.Framework;

namespace todictionary.tests
{
    [TestFixture]
    public class In_Name_und_Wert_zerlegen_Tests
    {
        [Test]
        public void Name_und_Wert() {
            var result = StringUtils.In_Name_und_Wert_zerlegen(new[] { "a=1", "b=2" });
            Assert.That(result, Is.EqualTo(expected : new[] {
                new KeyValuePair<string, string>("a", "1"),
                new KeyValuePair<string, string>("b", "2")
            }));
        } 
    }
}