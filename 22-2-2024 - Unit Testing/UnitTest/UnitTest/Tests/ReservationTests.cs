using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Models;
using UnitTest.Services;

namespace UnitTest.Tests
{
    [TestFixture]
    public class ReservationTests {
        private Mock<IReservation> reservationMock;
        private ReservationService reservationService;

        [SetUp]
        public void Setup() {
            reservationMock = new Mock<IReservation>();
            reservationService = new ReservationService(reservationMock.Object);
        }

        [Test]
        public void GenerateReservation_ValidName_ReturnsPNRInfo() {
            // Arrange
            string name = "John Doe";
            PNRInfo expectedPNRInfo = new PNRInfo {
                CreatedAt = DateTime.Now,
                Pnr = "sc7suc",
                Status = true
            };

            reservationMock.Setup(r => r.Generate(name)).Returns(expectedPNRInfo);

            // Act
            PNRInfo actualPNRInfo = reservationService.GenerateReservation(name);

            // Assert
            Assert.Equals(expectedPNRInfo, actualPNRInfo);
        }
    }

}
