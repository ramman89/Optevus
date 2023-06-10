using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OptevusApi.Repositories.Models;
using System.Xml;

namespace OptevusApi.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        OpDbContext _OpDbContext;
        public PolicyRepository(OpDbContext dbcontext)
        {
            _OpDbContext = dbcontext;
        }
        public async Task<List<PolicyDetails>> GetPolicyDetails()
        {
            return await Task.Run(() => _OpDbContext.Policies.Select(x => x).ToList());
        }

        public async Task<List<ReportData>> GetReportData(string origin)
        {
            var da = await Task.Run(() => _OpDbContext.Policies.Where(x=>x.CustomerRegion==origin || origin=="all") .OrderByDescending(x => x.DateOfPurchase)
                .GroupBy(x => new { x.DateOfPurchase.Year, x.DateOfPurchase.Month })

                .Select(x => new ReportData
                {
                    Date = string.Format("{0}|{1}", x.Key.Year, x.Key.Month),
                    Count = x.Sum(c=>c.Premium)
                }).ToList()

                );

            return da;

        }

        public async Task UpdatePolicyDetails(PolicyDetails policyDetails)
        {
            var existedItem = _OpDbContext.Policies.Where(x => x.PolicyId == policyDetails.PolicyId).FirstOrDefault();
            if (existedItem != null)
            {
                _OpDbContext.Entry(existedItem).CurrentValues.SetValues(policyDetails);
            }
            await _OpDbContext.SaveChangesAsync();
        }
    }
}
