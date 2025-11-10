using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WienerPartners.Core.Models;

namespace WienerPartners.Data;

public class PolicyRepository : IPolicyRepository
{

    private readonly IDbConnection _db;

    public PolicyRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<int> CreateAsync(Policy policy)
    {
        var sql = @"
                   INSERT INTO Policies
                   (Number, Value, PartnerId, CreatedAtUtc)
                   VALUES (@Number, @Value, @PartnerId, @CreatedAtUtc);
                   SELECT CAST(SCOPE_IDENTITY() as int);
                        ";
        policy.CreatedAtUtc = DateTime.UtcNow;
        var id = await _db.QuerySingleAsync<int>(sql, policy);
        return id;
    }

    public async Task<IEnumerable<Policy>> GetByPartnerIdAsync(int partnerId)
    {
        var sql = "SELECT * FROM Policies WHERE PartnerId=@partnerId ORDER BY CreatedAtUtc DESC";
        return await _db.QueryAsync<Policy>(sql, new { partnerId });
    }
}
