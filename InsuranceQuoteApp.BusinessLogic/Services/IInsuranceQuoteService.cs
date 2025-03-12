using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceQuoteApp.BusinessLogic.Models; // We'll define this next

namespace InsuranceQuoteApp.BusinessLogic.Services
{
    public interface IInsuranceQuoteService
    {
        Task<IEnumerable<InsuranceQuoteDto>> GetAllQuotesAsync();
        Task AddQuoteAsync(InsuranceQuoteDto QuoteDto);
    }
}
