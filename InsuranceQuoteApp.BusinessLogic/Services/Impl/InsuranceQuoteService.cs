using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceQuoteApp.BusinessLogic.Models;
using InsuranceQuoteApp.Data;
using InsuranceQuoteApp.Data.Repositories; // We will define this later

namespace InsuranceQuoteApp.BusinessLogic.Services
{
    public class InsuranceQuoteService : IInsuranceQuoteService
    {
        private readonly IInsuranceQuoteRepository _insuranceQuoteRepository;

        public InsuranceQuoteService(IInsuranceQuoteRepository insuranceQuoteRepository)
        {
            _insuranceQuoteRepository = insuranceQuoteRepository;
        }

       public async Task<IEnumerable<InsuranceQuoteDto>> GetAllQuotesAsync()
        {
            var quotes = await _insuranceQuoteRepository.GetAllQuotesAsync();

            return quotes.Select(q => new InsuranceQuoteDto
            {
                Id = q.Id,
                CustomerName = q.Customer?.FirstName ?? "Nameless", 
                InsurancePlanName = q.InsurancePlan?.Name ?? "No Plan", 
                QuoteAmount = q.Amount
            });
        }

        public async Task AddQuoteAsync(InsuranceQuoteDto QuoteDto){

            var Quote = new Quote{
                CustomerId = 1,
                Amount = 1,
                InsurancePlanId = 1
            };
            await _insuranceQuoteRepository.AddQuoteAsync(Quote);
        }
    }
}
