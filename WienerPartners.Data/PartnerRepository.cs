using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using WienerPartners.Core.Models;
using System.Linq;
using System;

namespace WienerPartners.Data
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly IDbConnection _db;
        public PartnerRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<int> CreateAsync(Partner p)
        {
            var sql = @"
INSERT INTO Partners
(FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreatedAtUtc, CreateByUser, IsForeign, ExternalCode, Gender)
VALUES
(@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN, @PartnerTypeId, @CreatedAtUtc, @CreateByUser, @IsForeign, @ExternalCode, @Gender);
SELECT CAST(SCOPE_IDENTITY() as int);
";
            p.CreatedAtUtc = DateTime.UtcNow;
            var id = await _db.QuerySingleAsync<int>(sql, p);
            return id;
        }

        public async Task<int> CreatePolicyAsync(Policy policy)
        {
            var sql = @"
INSERT INTO Policies
(PolicyNumber, PolicyAmount, PartnerId, CreatedAtUtc)
VALUES (@PolicyNumber, @PolicyAmount, @PartnerId, @CreatedAtUtc);
SELECT CAST(SCOPE_IDENTITY() as int);
";
            policy.CreatedAtUtc = DateTime.UtcNow;
            var id = await _db.QuerySingleAsync<int>(sql, policy);
            return id;
        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            var sql = @"
SELECT p.*, 
    ISNULL(cnt.Count,0) as PoliciesCount, ISNULL(cnt.SumAmount,0) as PoliciesSum
FROM Partners p
LEFT JOIN (
    SELECT PartnerId, COUNT(*) as Count, SUM(PolicyAmount) as SumAmount
    FROM Policies GROUP BY PartnerId
) cnt ON cnt.PartnerId = p.Id
ORDER BY p.CreatedAtUtc DESC;
";
            var res = await _db.QueryAsync<Partner>(sql);
            return res;
        }

        public async Task<Partner?> GetByIdAsync(int id)
        {
            var p = await _db.QuerySingleOrDefaultAsync<Partner>("SELECT * FROM Partners WHERE Id=@Id", new { Id = id });
            if (p == null) return null;
            var policies = await GetPoliciesByPartnerIdAsync(id);
            p.PoliciesCount = policies.Count();
            p.PoliciesSum = policies.Sum(x => x.PolicyAmount);
            return p;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesByPartnerIdAsync(int partnerId)
        {
            var sql = "SELECT * FROM Policies WHERE PartnerId=@partnerId ORDER BY CreatedAtUtc DESC";
            return await _db.QueryAsync<Policy>(sql, new { partnerId });
        }
    }
}
