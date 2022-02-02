using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Unit
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElemenet()
        {
            var formater = new HtmlFormatter();

            var result = formater.FormatAsBold("abc");

            // Specific
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            // More general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("abc").IgnoreCase);


        }
    }
}
