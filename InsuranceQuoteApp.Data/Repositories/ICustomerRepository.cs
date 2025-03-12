using InsuranceQuoteApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceQuoteApp.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerAsync(int ID);
        Task CreateCustomer(Customer Customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int ID);
    }
}
