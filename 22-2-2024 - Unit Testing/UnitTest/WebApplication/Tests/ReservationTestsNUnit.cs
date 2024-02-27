using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services;
using WebGrease.Activities;

namespace WebApplication.Tests
{
    [TestFixture]
    public class ReservationTestsNUnit {
        private Mock<IReservation> reservationMock;
        private ReservationService reservationService;

        [SetUp]
        public void Setup() {
            reservationMock = new Mock<IReservation>();
            reservationService = new ReservationService(reservationMock.Object);
        }

        [TearDown]
        public void TearDown() {
            Console.WriteLine("Hello!");
        }

        void MyMethod() {
            throw new Exception("Exception message");
        }

        [Test]
        public void GenerateReservation_ValidName_ReturnsPNRInfo_Test() {
            // Arrange
            string validName = "John Doe";
            string inValidName = "Raju";
            PNRInfo expectedPNRInfoValidResult = new PNRInfo {
                CreatedAt = DateTime.Now,
                Pnr = "sc7suc",
                Status = true
            };
            PNRInfo expectedPNRInfoInValidResult = new PNRInfo {
                CreatedAt = DateTime.Now,
                Pnr = "zjsnc",
                Status = true
            };

            // Example of Mock
            reservationMock.Setup(r => r.Generate(validName)).Returns(expectedPNRInfoValidResult);
            reservationMock.Setup(r => r.Generate(inValidName)).Returns(expectedPNRInfoInValidResult);
            PNRInfo nope = null;
            reservationMock.Setup(r => r.Generate(null)).Returns(nope);

            // Act
            PNRInfo nullInfo = reservationService.GenerateReservation(null);
            PNRInfo actualPNRInfo = reservationService.GenerateReservation(validName);
            PNRInfo actualPNRInfoInvalid = reservationService.GenerateReservation(inValidName);

            // Assert
            Assert.That(5, Is.EqualTo(5));
            Assert.That(expectedPNRInfoValidResult, Is.EqualTo(actualPNRInfo));
            Assert.That(expectedPNRInfoInValidResult, Is.EqualTo(actualPNRInfoInvalid));
            Assert.That(nullInfo, Is.EqualTo(null));
            reservationMock.Verify(m => m.Generate(null), Times.Once);
            Assert.That("Hello", Is.EqualTo("Hello"));
            Assert.That(10 > 5, Is.EqualTo(true));
            object a = null;
            Assert.That(a, Is.EqualTo(null));
            Exception exception = Assert.Throws<Exception>(() => {
                throw new Exception("Hi!");
            });
            Assert.That(exception.Message, Is.EqualTo("Hi!"));
        }

        [Test]
        public void Random_Test() {
            Console.WriteLine("Working!");
        }

    }

}
