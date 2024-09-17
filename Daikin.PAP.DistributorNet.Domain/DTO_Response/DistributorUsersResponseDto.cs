namespace Daikin.PAP.DistributorNet.Domain.DTO_Response
{
    public class DistributorUsersResponseDto
    {
        public string DistributorId { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}