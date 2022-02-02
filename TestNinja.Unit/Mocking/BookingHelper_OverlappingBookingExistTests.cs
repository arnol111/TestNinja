using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Unit.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingExistTests
    {
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_RetunrEmptyString()
        {
            var repositroy = new Mock<IBookingRepositroy>();

            repositroy.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id=2,
                    ArrivalDate = new DateTime(2017,1,15,14,0,0),
                    DepartureDate = new DateTime(2017,1,20,10,0,0),
                    Reference = "a"
                }
            }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2017, 1, 10, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 14, 10, 0, 0)
            }, repositroy.Object);

            Assert.That(result, Is.Empty);
        }
    }
}
