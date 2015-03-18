using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
    [TestFixture()]
    public class FlightTest
    {
        private readonly DateTime startDate = new DateTime();
        private readonly DateTime endDate = new DateTime();
        private readonly int someMiles = 1;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, someMiles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDay()
        {
            var sDate = new DateTime(1993, 3, 3);
            var eDate = sDate.AddDays(1);
            var lengthOfSpread = (eDate - sDate).Days;
            Assert.AreEqual(200 + lengthOfSpread * 20, new Flight(sDate, eDate, someMiles).getBasePrice());

        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayOtherTest()
        {
            var sDate = new DateTime(1993, 3, 3);
            var eDate = new DateTime(1993, 3, 4);
            var lengthOfSpread = 1;
            Assert.AreEqual(200 + lengthOfSpread * 20, new Flight(sDate, eDate, someMiles).getBasePrice());

        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForFifteenDays()
        {
            var sDate = new DateTime(1993, 3, 3);
            var eDate = sDate.AddDays(15);
            var lengthOfSpread = (eDate - sDate).Days;
            Assert.AreEqual(200 + lengthOfSpread * 20, new Flight(sDate, eDate, someMiles).getBasePrice());

        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForThreeHundredDays()
        {
            var sDate = new DateTime(1993, 3, 3);
            var eDate = sDate.AddDays(300);
            var lengthOfSpread = (eDate - sDate).Days;
            Assert.AreEqual(200 + lengthOfSpread * 20, new Flight(sDate, eDate, someMiles).getBasePrice());

        }


        [Test()]
        public void TestThatFlightEquals()
        {
            var sDate1 = new DateTime(1993, 3, 3);
            var eDate1 = new DateTime(1995, 8, 3);
            var sDate2 = new DateTime(1993, 3, 3);
            var eDate2 = new DateTime(1995, 8, 3);
            var miles = 30;
            var flight1 = new Flight(sDate1, eDate1, miles);
            var flight2 = new Flight(sDate2, eDate2, miles);
            Assert.IsTrue(flight1.Equals(flight2));
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsInvalidOperation()
        {
            var sDate = new DateTime(1995, 3, 10);
            var eDate = new DateTime(1993, 8, 3);
            new Flight(sDate, eDate, someMiles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsArgumentOutOfRange()
        {
            var sDate = new DateTime(1993, 3, 10);
            var eDate = new DateTime(1995, 8, 3);
            var miles = -1;
            new Flight(sDate, eDate, miles);
        }

    }
}
