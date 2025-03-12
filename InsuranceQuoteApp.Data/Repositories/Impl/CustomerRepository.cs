using InsuranceQuoteApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceQuoteApp.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceQuoteAppDbContext _context;
        
        public CustomerRepository(InsuranceQuoteAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync(){
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int ID){
            var Customer = await _context.Customers.FindAsync(ID);
            return Customer ?? throw new Exception("Customer not found");
        }

        public async Task CreateCustomer(Customer Customer){
            await _context.Customers.AddAsync(Customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer){
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int ID){
            var Customer = await _context.Customers.FindAsync(ID);
            if(Customer != null){
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
            }

        }

    }
}