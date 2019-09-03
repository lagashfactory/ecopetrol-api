using Ecopetrol.Api.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecopetrol.Api.Services.Contracts
{
    public interface IFAQService
    {
        Task<FAQ> CreateAsync(FAQ faq);

        Task<bool> UpdateAsync(FAQ faq);

        Task<bool> DeleteAsync(string id);

        Task<FAQ> GetAsync(string id);
        Task<IEnumerable<FAQ>> GetAllAsync();
        
    }
}
