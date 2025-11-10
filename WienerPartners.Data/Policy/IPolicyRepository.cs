using System.Collections.Generic;
using System.Threading.Tasks;
using WienerPartners.Core.Models;

namespace WienerPartners.Data;

public interface IPolicyRepository
{
    Task<int> CreateAsync(Policy policy);
    Task<IEnumerable<Policy>> GetByPartnerIdAsync(int partnerId);
}
