namespace Daikin.PAP.DistributorNet.Domain.DTO_Response
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DisplayName => GetDisplayName();
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public string GetDisplayName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}