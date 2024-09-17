using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.DTO_Response;
using Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools.RepositaryContracts;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Daikin.PAP.DistributorNet.Domain.Repositary.AdminTools
{
    public class DistributorRepositary : IDistributorRepositary
    {
        private readonly IDbConnection dbConnection;
        public DistributorRepositary(IDbConnection dbConnection) => this.dbConnection = dbConnection;

        //public DistributorRepositary(IDbConnection dbConnection)
        //{
        //    this.dbConnection = dbConnection;
        //}

        public static List<DistributorResponseDTO> GetData()
        {
            List<DistributorResponseDTO> data = new List<DistributorResponseDTO>()
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

            return data;
        }

        public async Task AddDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken)
        {
            try
            {
                await dbConnection.ExecuteAsync(StroredProcedures.AddNewDistributor, new
                {
                    DistributorId = distributor.DistributorId,
                    DistributorName = distributor.DistributorName,
                    DistributorRole = distributor.DistributorRole,
                    DistributorType = distributor.DistributorType,
                    AddedBy = distributor.AddedBy
                }, 
                null, null, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<IEnumerable<DistributorResponseDTO>> GetAllDistributors(CancellationToken cancellationToken)
        {
            //var returndata = GetData();
            //return await Task.FromResult(returndata);

            try
            {
                return await Task.FromResult(dbConnection.Query<DistributorResponseDTO>(StroredProcedures.GetAllDistributors, commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("Sql Connection error", ex);
            }
        }

        public async Task<DistributorResponseDTO> GetDistributorById(string DistributorId, CancellationToken cancellationToken)
        {
            //var returndata = GetData();
            //return await Task.FromResult(returndata.Where(x => x.DistributorId == DistributorId).FirstOrDefault());
            try
            {
                return await Task.FromResult(dbConnection.QuerySingleOrDefault<DistributorResponseDTO>
                    (StroredProcedures.GetDistributorById, new { DistributorId = DistributorId }, commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("Sql Connection error", ex);
            }
        }

        public async Task UpdateDistributor(DistributorRequestDto distributor, CancellationToken cancellationToken)
        {
            try
            {
                await dbConnection.ExecuteAsync(StroredProcedures.UpdateDistributor, new
                {
                    distributor.DistributorId,
                    distributor.DistributorName,
                    distributor.DistributorRole,
                    distributor.DistributorType,
                    distributor.IsActive,
                    distributor.UpdatedBy
                }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Sql Connection error", ex);
            }
        }
    }
}