namespace Daikin.PAP.DistributorNet.Domain.DTO_Request
{
    public class DistributorRequestDto
    {
        public string DistributorName { get; set; } = string.Empty;
        public string DistributorId { get; set; } = string.Empty;
        public string DistributorRole { get; set; } = string.Empty;
        public string DistributorType { get; set; } = string.Empty;
        public int AddedBy { get; set; } = 0;
        public int UpdatedBy { get; set;} = 0;
        public bool IsActive { get; set; } = true;
    }
}