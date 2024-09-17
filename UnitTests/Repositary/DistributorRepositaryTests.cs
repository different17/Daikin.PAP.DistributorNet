using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.Repositary;
using Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools;
using Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools.RepositaryContracts;
using Daikin.PAP.DistributorNet.Domain.Service.AdminTools;
using Dapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Repositary
{
    [TestClass]
    public class DistributorRepositaryTests
    {
        private readonly Mock<IDbConnection> dbConnection;
        private readonly DistributorRepositary distributorRepositary;

        public DistributorRepositaryTests()
        {
            dbConnection = new Mock<IDbConnection>();
            distributorRepositary = new DistributorRepositary(dbConnection.Object);
        }

        [TestMethod]
        public async Task AddDistributor_ShouldCallExecuteAsync_WithCorrectParameters()
        {
            // Arrange
            var distributor = new DistributorRequestDto
            {
                DistributorId = "14526398",
                DistributorName = "ABC",
                DistributorRole = "Distributor",
                DistributorType = "IND",
                AddedBy = 1875
            };
            var cancellationToken = new CancellationToken();

            //dbConnection
            //    .Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), null, null, CommandType.StoredProcedure))
            //    .ReturnsAsync(1);

            // Act
            await distributorRepositary.AddDistributor(distributor, cancellationToken);

            // Assert
            dbConnection.Verify(db => db.ExecuteAsync(
                StroredProcedures.AddNewDistributor,
                It.Is<object>(parameters =>
                    parameters.GetType().GetProperty("DistributorId").GetValue(parameters).ToString() == "14526398" &&
                    parameters.GetType().GetProperty("DistributorName").GetValue(parameters).ToString() == "ABC" &&
                    parameters.GetType().GetProperty("DistributorRole").GetValue(parameters).ToString() == "Distributor" &&
                    parameters.GetType().GetProperty("DistributorType").GetValue(parameters).ToString() == "IND" &&
                    parameters.GetType().GetProperty("AddedBy").GetValue(parameters).ToString() == "User1"
                ),
                null, null, CommandType.StoredProcedure
            ), Times.Once);
        }
    }
}
