using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceQuoteApp.BusinessLogic.Models;
using InsuranceQuoteApp.Data;

namespace InsuranceQuoteApp.BusinessLogic.Services
{
    public interface ICustomerService{
        Task<IEnumerable<CustomerDto>> GetCustomerList();
        Task<CustomerDto> GetCustomerByID(int ID);
        Task CreateCustomer(CustomerDto customerDto);
    }
}