using Daikin.PAP.DistributorNet.API.Controllers.Admin;
using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.DTO_Response;
using Daikin.PAP.DistributorNet.Domain.Service.AdminTools.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTests.TestObjects;

namespace UnitTests.Controller
{
    [TestClass]
    public class DistributorControllerTests
    {
        private readonly Mock<IDistributorService> distributorService;
        private readonly DistributorController distributorController; 
        
        public DistributorControllerTests()
        {
            distributorService = new Mock<IDistributorService>();
            distributorController = new DistributorController(distributorService.Object);
        }

        [TestMethod]
        public async Task Distributor_GetAllDistributors_Success()
        {
            // Arrange
            List<DistributorResponseDTO> mockData = DistributorTestObject.GetAllDistributors();
            var cancellationToken = new CancellationToken();

            distributorService.Setup(x => x.GetAllDistributors(It.IsAny<CancellationToken>())).ReturnsAsync(mockData);

            // Act
            var result = await distributorController.GetAllDistributors(cancellationToken);
            var response = result.Result as ObjectResult; 

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Distributor_GetAllDistributors_Exception()
        {
            // Arrange
            var cancellationToken = new CancellationToken();

            distributorService.Setup(x => x.GetAllDistributors(It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await distributorController.GetAllDistributors(cancellationToken);
            var response = result.Result as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);
            distributorService.Verify(x => x.GetAllDistributors(It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Distributor_GetDistributorById_Success()
        {
            // Arrange
            var distributorId = "14141414";
            var cancellationToken = new CancellationToken();
            DistributorResponseDTO mockData = DistributorTestObject.GetDistributor();

            distributorService.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(mockData);

            // Act
            var result = await distributorController.GetDistributorById(distributorId, cancellationToken);
            var response = result.Result as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Distributor_GetDistributorById_Exception()
        {
            // Arrange
            var distributorId = "14141414";
            var cancellationToken = new CancellationToken();

            distributorService.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await distributorController.GetDistributorById(distributorId, cancellationToken);
            var response = result.Result as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);
            distributorService.Verify(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Distributor_GetDistributorById_NotFound()
        {
            // Arrange
            var distributorId = "14141414";
            DistributorResponseDTO distributor = null;
            var cancellationToken = new CancellationToken();

            distributorService.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(distributor);

            // Act
            var result = await distributorController.GetDistributorById(distributorId, cancellationToken);
            var response = result.Result as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);
            distributorService.Verify(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Distributor_CreateDistributor_Success()
        {
            // Arrange
            DistributorResponseDTO mockData = DistributorTestObject.GetDistributor();
            DistributorRequestDto distributorRequest = new DistributorRequestDto
            {
                DistributorId = "12345678",
                DistributorName = "Test",
                DistributorRole = "Distributor",
                DistributorType = "IND"
            };
            var cancellationToken = new CancellationToken();

            distributorService.Setup(x => x.AddDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()));

            // Act
            var result = await distributorController.CreateDistributor(distributorRequest,cancellationToken);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Distributor_CreateDistributor_Exception()
        {
            // Arrange
            var cancellationToken = new CancellationToken();
            DistributorRequestDto distributorRequest = new DistributorRequestDto
            {
                DistributorId = "12345678",
                DistributorName = "Test",
                DistributorRole = "Distributor",
                DistributorType = "IND"
            };

            distributorService.Setup(x => x.AddDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await distributorController.CreateDistributor(distributorRequest, cancellationToken);
            //var response = result.Result as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);
            distributorService.Verify(x => x.AddDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Distributor_UpdateDistributors_Success()
        {
            // Arrange
            List<DistributorResponseDTO> mockData = DistributorTestObject.GetAllDistributors();
            DistributorRequestDto distributorRequest = new DistributorRequestDto
            {
                DistributorId = "12345678",
                DistributorName = "Test",
                DistributorRole = "Distributor",
                DistributorType = "IND"
            };
            var cancellationToken = new CancellationToken();

            distributorService.Setup(x => x.UpdateDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()));

            // Act
            var result = await distributorController.UpdateDistributor(distributorRequest, cancellationToken);
            //var response = result.Result as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Distributor_UpdateDistributors_Exception()
        {
            // Arrange
            var cancellationToken = new CancellationToken();
            DistributorRequestDto distributorRequest = new DistributorRequestDto
            {
                DistributorId = "12345678",
                DistributorName = "Test",
                DistributorRole = "Distributor",
                DistributorType = "IND"
            };

            distributorService.Setup(x => x.UpdateDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await distributorController.UpdateDistributor(distributorRequest, cancellationToken);
            //var response = result.Result as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);
            distributorService.Verify(x => x.UpdateDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}