using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptevusApi.Repositories;
using OptevusApi.Repositories.Models;

namespace OptevusApi.Controllers
{
    [Route("api/Policy")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;
       public PolicyController(IPolicyRepository policyRepository)
        {
            _policyRepository=policyRepository;
        }

        [HttpGet]
        [Route("Data")]
        public async Task<IActionResult> GetPolicyDetails()
        {
            return  Ok(await _policyRepository.GetPolicyDetails());
        }

        [HttpPost]
        [Route("SavePolicy")]
        public async Task<IActionResult> UpdatePolicyDetails([FromBody]PolicyDetails policyDetails)
        {
            await _policyRepository.UpdatePolicyDetails(policyDetails);
            return Ok();
        }

        [HttpGet]
        [Route("ReportData")]
        public async Task<IActionResult> GetReportData(string origin)
        {
            return Ok(await _policyRepository.GetReportData(origin));
        }
    }
}
