using Daikin.PAP.DistributorNet.Domain.DTO_Request;
using Daikin.PAP.DistributorNet.Domain.DTO_Response;
using Daikin.PAP.DistributorNet.Domain.Service.AdminTools.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Daikin.PAP.DistributorNet.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IDistributorService distributorService;
        public DistributorController(IDistributorService distributorService)
        {
            this.distributorService = distributorService;
        }

        [HttpGet]
        [Route("GetAllDistributors")]
        public async Task<ActionResult<IEnumerable<DistributorResponseDTO>>> GetAllDistributors(CancellationToken cancellationToken)
        {
            try
            {
                var result = await distributorService.GetAllDistributors(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log Error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetDistributorById")]
        public async Task<ActionResult<DistributorResponseDTO>> GetDistributorById(string distributorId, CancellationToken cancellationToken)
        {
            try
            {
                DistributorResponseDTO distributor = await distributorService.GetDistributorById(distributorId, cancellationToken);
                if (distributor == null)
                {
                    return NotFound("Distributor with Id '" + distributorId + "' not found in PAP.");
                }
                return Ok(distributor);
            }
            catch (Exception ex)
            {
                // Log Error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("CreateDistributor")]
        public async Task<IActionResult> CreateDistributor([FromBody] DistributorRequestDto distributorRequest, CancellationToken cancellationToken)
        {
            try
            {
                var result = await distributorService.AddDistributor(distributorRequest, cancellationToken);
                if (result == true)
                {
                    return Ok("Distributor added successfully.");
                }
                else
                {
                    return BadRequest("Distributor with Id '" + distributorRequest.DistributorId + "' already present in PAP.");
                }
                    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("UpdateDistributor")]
        public async Task<IActionResult> UpdateDistributor([FromBody] DistributorRequestDto distributorRequest, CancellationToken cancellationToken)
        {
            try
            {
                var result = await distributorService.UpdateDistributor(distributorRequest, cancellationToken);
                if (result == true)
                {
                    return Ok("Distributor Updated successfully.");
                }
                else
                {
                    return BadRequest("Distributor with Id '" + distributorRequest.DistributorId + "' not present in PAP.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetDistributorUsersByDistributorId")]
        public async Task<ActionResult<IEnumerable<DistributorUsersResponseDto>>> GetDistributorUsersByDistributorId(string DistributorId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await distributorService.GetAllDistributors(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log Error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}