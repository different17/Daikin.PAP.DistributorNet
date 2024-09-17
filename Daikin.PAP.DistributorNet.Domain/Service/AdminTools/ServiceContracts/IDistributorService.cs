using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.DTO_Response;

namespace Daikin.PAP.DistributorNet.Domain.Service.AdminTools.ServiceContracts
{
    public interface IDistributorService
    {
        Task<IEnumerable<DistributorResponseDTO>> GetAllDistributors(CancellationToken cancellationToken);
        Task<DistributorResponseDTO> GetDistributorById(string DistributorId, CancellationToken cancellationToken);
        Task<bool> AddDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken);
        Task<bool> UpdateDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken);
    }
}