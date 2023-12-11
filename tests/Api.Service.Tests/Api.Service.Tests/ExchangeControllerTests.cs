using Api.Models;
using Api.Service.Controllers;
using Domain.Abstractions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Api.Service.Tests.Api.Service.Tests
{
    public class ExchangeControllerTests
    {
        private Mock<IExchangeService> _mockExchangeService;
        private Mock<ILogger<ExchangeController>> _mockLogger;
        private ExchangeController _controller;

        [SetUp]
        public void Setup()
        {
            _mockExchangeService = new Mock<IExchangeService>(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<ExchangeController>>(MockBehavior.Loose);

            _controller = new ExchangeController(
                _mockLogger.Object,
                _mockExchangeService.Object
            );
        }

        [TearDown]
        public void TearDown()
        {
            _mockExchangeService.VerifyAll();
            _mockLogger.VerifyAll();
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_IfLoggerIsNull()
        {
            // Arrange
            // Act
            Action action = () => new ExchangeController(
                null,
                _mockExchangeService.Object
            );

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_IfExchangeServiceIsNull()
        {
            // Arrange
            // Act
            Action action = () => new ExchangeController(
                _mockLogger.Object,
                null
            );

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task ListAsync_ThrowsException()
        {
            // Arrange
            var mockedRecords = new List<StockExchange>()
            {
                new() {
                    Ticker = "TEST",
                    BrokerId = 1,
                    Quantity = 1,
                    Price = 100
                }
            };
            var mockedResponse = new OkObjectResult(mockedRecords);
            _mockExchangeService.Setup(x => x.ListExchanges()).ReturnsAsync(mockedRecords);

            // Act
            var result = await _controller.ListExchangesAsync();

            // Assert
            result.Should().BeEquivalentTo(mockedResponse);
        }
    }
}