using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Unit
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            // NotFound
            Assert.That(result, Is.TypeOf<NotFound>());

            //NotFound or one of tis derivatives
            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsPositiveIntegerGreaterThanZero_ReturnOk()
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(12);

            Assert.That(result, Is.TypeOf<Ok>());

            Assert.That(result, Is.InstanceOf<ActionResult>());
        }
    }
}
