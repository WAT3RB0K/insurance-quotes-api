using InsuranceQuoteApp.BusinessLogic.Services;
using InsuranceQuoteApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceQuoteApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[CustomerCRUD]")]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _iCusomerService;

        public CustomerController(ICustomerService iCustomerService){
            _iCusomerService = iCustomerService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomerList(){
            var CustomerList = await _iCusomerService.GetCustomerList();
            return Ok(CustomerList);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerByID(int id){
            var CustomerDetails = await _iCusomerService.GetCustomerByID(id);
            return Ok(CustomerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(string Name){
            var Customer = new CustomerDto{FirstName = Name};
            await _iCusomerService.CreateCustomer(Customer);
            return Ok();
        }
    }
}