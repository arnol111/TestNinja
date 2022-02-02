using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Unit
{
    [TestFixture]
    public class ReservationTests
    {
        // Convention We use to name and organize our tests method
        // Name of method + Scenario + Expected Behavior
        // 
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Triple AAA
            // Arrange 
            // this is de part where we initialize our objects

            var reservation = new Reservation();

            // Act 
            // The Act part is where we act on this object
            // Where are going to call a method (The method that's wer are going to test)

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert

            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
            //Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelliongReservation_ReturnFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);

        }
    }
}
