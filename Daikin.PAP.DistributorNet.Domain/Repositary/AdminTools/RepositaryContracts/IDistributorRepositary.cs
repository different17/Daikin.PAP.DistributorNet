using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.DTO_Response;

namespace Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools.RepositaryContracts
{
    public interface IDistributorRepositary
    {
        Task<IEnumerable<DistributorResponseDTO>> GetAllDistributors(CancellationToken cancellationToken);
        Task<DistributorResponseDTO> GetDistributorById(string DistributorId, CancellationToken cancellationToken);
        Task AddDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken);
        Task UpdateDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken);
    }
}