using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.DTO_Response;
using Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools.RepositaryContracts;
using Daikin.PAP.DistributorNet.Domain.Service.AdminTools;
using Moq;
using UnitTests.TestObjects;

namespace UnitTests.Service
{
    [TestClass]
    public class DistributorServiceTests
    {
        private readonly Mock<IDistributorRepositary> distributorRepositary;
        private readonly DistributorService distributorService;
        public DistributorServiceTests()
        {
            distributorRepositary = new Mock<IDistributorRepositary>();
            distributorService = new DistributorService(distributorRepositary.Object);
        }

        [TestMethod]
        public async Task Distributor_GetAllDistributors_Success()
        {
            // Arrange
            List<DistributorResponseDTO> mockData = DistributorTestObject.GetAllDistributors();
            var cancellationToken = new CancellationToken();

            distributorRepositary.Setup(x => x.GetAllDistributors(It.IsAny<CancellationToken>())).ReturnsAsync(mockData);

            // Act
            var result = await distributorService.GetAllDistributors(cancellationToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mockData, result);
        }

        [TestMethod]
        public async Task Distributor_AddDistributor_Success_True()
        {
            // Arrange
            var distributorRequest = new DistributorRequestDto { DistributorId = "1" };
            var cancellationToken = new CancellationToken();

            distributorRepositary.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((DistributorResponseDTO)null);

            distributorRepositary.Setup(x => x.AddDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()));

            // Act
            var result = await distributorService.AddDistributor(distributorRequest, cancellationToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Distributor_AddDistributor_Success_False()
        {
            // Arrange
            DistributorRequestDto distributorRequest = new DistributorRequestDto
            {
                DistributorId = "12345678",
                DistributorName = "Test",
                DistributorRole = "Distributor",
                DistributorType = "IND"
            };
            var cancellationToken = new CancellationToken();
            DistributorResponseDTO mockData = DistributorTestObject.GetDistributor();

            distributorRepositary.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(mockData);

            distributorRepositary.Setup(x => x.AddDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()));

            // Act
            var result = await distributorService.AddDistributor(distributorRequest, cancellationToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!result);
        }

        [TestMethod]
        public async Task Distributor_GetDistributorById_Success()
        {
            // Arrange
            DistributorResponseDTO mockData = DistributorTestObject.GetDistributor();
            var cancellationToken = new CancellationToken();
            var distributorById = "12121212";

            distributorRepositary.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(mockData);

            // Act
            var result = await distributorService.GetDistributorById(distributorById, cancellationToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mockData, result);
        }

        [TestMethod]
        public async Task Distributor_UpdateDistributor_Success_True()
        {
            // Arrange
            DistributorRequestDto distributorRequest = new DistributorRequestDto
            {
                DistributorId = "12345678",
                DistributorName = "Test",
                DistributorRole = "Distributor",
                DistributorType = "IND"
            };
            var cancellationToken = new CancellationToken();
            DistributorResponseDTO mockData = DistributorTestObject.GetDistributor();

            distributorRepositary.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(mockData);

            distributorRepositary.Setup(x => x.UpdateDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()));

            // Act
            var result = await distributorService.UpdateDistributor(distributorRequest, cancellationToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Distributor_UpdateDistributor_Success_False()
        {
            // Arrange
            var distributorRequest = new DistributorRequestDto { DistributorId = "1" };
            var cancellationToken = new CancellationToken();

            distributorRepositary.Setup(x => x.GetDistributorById(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((DistributorResponseDTO)null);

            distributorRepositary.Setup(x => x.UpdateDistributor(It.IsAny<DistributorRequestDto>(), It.IsAny<CancellationToken>()));

            // Act
            var result = await distributorService.UpdateDistributor(distributorRequest, cancellationToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!result);
        }
    }
}