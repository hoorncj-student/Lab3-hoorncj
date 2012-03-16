using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        Flight f1;
        Flight f2;
        Flight f3;

        [SetUp()]
        public void SetupFlight()
        {
            f1 = new Flight(new DateTime(2012, 3, 30), new DateTime(2012, 4, 7),500);
            f2 = new Flight(new DateTime(2012, 6, 30), new DateTime(2012, 7, 7), 1000);
            f3 = new Flight(new DateTime(2012, 1, 1), new DateTime(2012, 1, 1), 100);
        }

        [Test()]
        public void TestThatFlightConstructsNonNull()
        {
            Assert.IsNotNull(f1);
        }

        [Test()]
        public void TestThatFlightHasValidMiles()
        {
            Assert.AreEqual(500, f1.Miles);
        }

        [Test()]
        public void TestEqualsOnEqual()
        {
            Assert.IsTrue(f1.Equals(new Flight(new DateTime(2012, 3, 30), new DateTime(2012, 4, 7),500)));
        }

        [Test()]
        public void TestEqualsOnSelf()
        {
            Assert.IsTrue(f1.Equals(f1));
        }

        [Test()]
        public void TestEqualsOnFalse()
        {
            Assert.IsFalse(f1.Equals(f2));
        }

        [Test()]
        public void TestBasePriceSingleDay()
        {
            Assert.AreEqual(200, f3.getBasePrice());
        }

        [Test()]
        public void TestBasePriceWeek()
        {
            Assert.AreEqual(360, f1.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(new DateTime(2012,1,1),new DateTime(2012,1,2),-2);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnInvalidFlightDates()
        {
            new Flight(new DateTime(2012, 1, 2), new DateTime(2012, 1, 1), 50);
        }
	}
}
