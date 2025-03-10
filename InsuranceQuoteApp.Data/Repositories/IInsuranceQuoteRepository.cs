using InsuranceQuoteApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceQuoteApp.Data.Repositories
{
    public interface IInsuranceQuoteRepository
    {
        Task<IEnumerable<Quote>> GetAllQuotesAsync();
        Task<Quote> GetQuoteByIdAsync(int id);
        Task AddQuoteAsync(Quote quote);
        Task UpdateQuoteAsync(Quote quote);
        Task DeleteQuoteAsync(int id);
    }
}
