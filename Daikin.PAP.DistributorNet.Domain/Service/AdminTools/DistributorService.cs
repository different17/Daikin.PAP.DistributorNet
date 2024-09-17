using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.DTO_Response;
using Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools.RepositaryContracts;
using Daikin.PAP.DistributorNet.Domain.Service.AdminTools.ServiceContracts;

namespace Daikin.PAP.DistributorNet.Domain.Service.AdminTools
{
    public class DistributorService : IDistributorService
    {
        private readonly IDistributorRepositary distributorRepositary;
        public DistributorService(IDistributorRepositary distributorRepositary)
        {
            this.distributorRepositary = distributorRepositary;
        }

        public async Task<bool> AddDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken)
        {
            var Existeddistributor = await distributorRepositary.GetDistributorById(distributor.DistributorId, cancellationToken);
            if (Existeddistributor == null)
            {
                await distributorRepositary.AddDistributor(distributor, cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<DistributorResponseDTO>> GetAllDistributors(CancellationToken cancellationToken)
        {
            return await distributorRepositary.GetAllDistributors(cancellationToken);
        }

        public async Task<DistributorResponseDTO> GetDistributorById(string DistributorId, CancellationToken cancellationToken)
        {
            return await distributorRepositary.GetDistributorById(DistributorId, cancellationToken);
        }

        public async Task<bool> UpdateDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken)
        {
            var Existeddistributor = await distributorRepositary.GetDistributorById(distributor.DistributorId, cancellationToken);
            if (Existeddistributor != null)
            {
                await distributorRepositary.UpdateDistributor(distributor, cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}