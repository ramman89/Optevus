using Microsoft.AspNetCore.Mvc.Rendering;
using OptevusApi.Repositories.Models;

namespace OptevusApi.Repositories
{
    public interface IPolicyRepository
    {
        public Task<List<PolicyDetails>> GetPolicyDetails();
        public Task UpdatePolicyDetails(PolicyDetails policyDetails);
        public Task<List<ReportData>> GetReportData(string origin);
    }
}
