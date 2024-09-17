using Daikin.PAP.DistributorNet.Domain.DTO_Response;

namespace UnitTests.TestObjects
{
    public static class DistributorTestObject
    {
        public static List<DistributorResponseDTO> GetAllDistributors()
        {
            List<DistributorResponseDTO> mockDistributorResponses = new List<DistributorResponseDTO>()
            {
                new DistributorResponseDTO
                {
                    DistributorId = "14526398",
                    DistributorName = "ABC",
                    DistributorRole = "Distributor",
                    DistributorType = "IND",
                    ID = Guid.NewGuid(),
                    IsActive = true
                },
                new DistributorResponseDTO
                {
                    DistributorId = "98745632",
                    DistributorName = "TEST",
                    DistributorRole = "DodDistributor",
                    DistributorType = "DOD",
                    ID = Guid.NewGuid(),
                    IsActive = true
                }
            };
            return mockDistributorResponses;
        }

        public static DistributorResponseDTO GetDistributor()
        {
            DistributorResponseDTO mockDistributorResponses = new DistributorResponseDTO
            {
                DistributorId = "14526398",
                DistributorName = "ABC",
                DistributorRole = "Distributor",
                DistributorType = "IND",
                ID = Guid.NewGuid(),
                IsActive = true
            };
            return mockDistributorResponses;
        }
    }
}