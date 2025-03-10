using InsuranceQuoteApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceQuoteApp.Data.Repositories
{
    public class InsuranceQuoteRepository : IInsuranceQuoteRepository
    {
        private readonly InsuranceQuoteAppDbContext _context;

        public InsuranceQuoteRepository(InsuranceQuoteAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotesAsync()
        {
            return await _context.Quotes.ToListAsync();
        }

        public async Task<Quote> GetQuoteByIdAsync(int id)
        {
            return await _context.Quotes.FindAsync(id);
        }

        public async Task AddQuoteAsync(Quote quote)
        {
            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuoteAsync(Quote quote)
        {
            _context.Quotes.Update(quote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuoteAsync(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
