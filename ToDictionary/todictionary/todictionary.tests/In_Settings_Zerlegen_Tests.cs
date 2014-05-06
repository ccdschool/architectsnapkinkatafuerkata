using NUnit.Framework;

namespace todictionary.tests
{
    [TestFixture]
    public class In_Settings_Zerlegen_Tests
    {
        [Test]
        public void Am_Semikolon_zerlegen() {
            var result = StringUtils.In_Settings_zerlegen("x;y;z");
            Assert.That(result, Is.EqualTo(new[]{"x", "y", "z"}));
        } 
    }
}