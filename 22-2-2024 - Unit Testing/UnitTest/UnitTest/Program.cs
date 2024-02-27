using System;
using UnitTest.Tests;

namespace UnitTest {

    public class Program {
        public static void Main(string[] args) {
            ReservationTests reservationTests = new ReservationTests();
            reservationTests.GenerateReservation_ValidName_ReturnsPNRInfo();
        }
    }

}