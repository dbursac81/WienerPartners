using System.Collections.Generic;
using System.Threading.Tasks;
using WienerPartners.Core.Models;

namespace WienerPartners.Data
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner?> GetByIdAsync(int id);
        Task<int> CreateAsync(Partner p);
        Task<int> CreatePolicyAsync(Policy policy);
        Task<IEnumerable<Policy>> GetPoliciesByPartnerIdAsync(int partnerId);
    }
}
