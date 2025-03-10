using InsuranceQuoteApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceQuoteApp.API.Controllers
{
    public class InsuranceQuotesController : BaseApiController
    {
        private readonly IInsuranceQuoteService _insuranceQuoteService;

        public InsuranceQuotesController(IInsuranceQuoteService insuranceQuoteService)
        {
            _insuranceQuoteService = insuranceQuoteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _insuranceQuoteService.GetAllQuotesAsync();
            return Ok(quotes);
        }
    }
}
