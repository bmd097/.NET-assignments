using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Tests {
    [TestClass]
    public class ReservationTestsMSTest {
        private Mock<IReservation> reservationMock;
        private ReservationService reservationService;

        [TestInitialize]
        public void Setup() {
            reservationMock = new Mock<IReservation>();
            reservationService = new ReservationService(reservationMock.Object);
        }

        [TestCleanup]
        public void TearDown() {
            Console.WriteLine("Hello!");
        }

        void MyMethod() {
            throw new Exception("Exception message");
        }

        [TestMethod]
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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, 5);
            Assert.AreEqual(expectedPNRInfoValidResult, actualPNRInfo);
            Assert.AreEqual(expectedPNRInfoInValidResult, actualPNRInfoInvalid);
            Assert.IsNull(nullInfo);
            reservationMock.Verify(m => m.Generate(null), Times.Once);
            Assert.AreEqual("Hello", "Hello");
            Assert.IsTrue(10 > 5);
            object a = null;
            Assert.IsNull(a);
            Exception exception = Assert.ThrowsException<Exception>(() =>
            {
                throw new Exception("Hi!");
            });
            Assert.AreEqual("Hi!", exception.Message);
        }

        [TestMethod]
        public void Random_Test() {
            Console.WriteLine("Working!");
        }
    }
}