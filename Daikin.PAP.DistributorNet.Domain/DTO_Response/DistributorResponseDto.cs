namespace Daikin.PAP.DistributorNet.Domain.DTO_Response
{
    public class DistributorResponseDTO
    {
        public Guid ID { get; set; }
        public string DistributorName { get; set; } = string.Empty;
        public string DistributorId { get; set; } = string.Empty;
        public string DistributorRole { get; set; } = string.Empty;
        public string DistributorType { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}