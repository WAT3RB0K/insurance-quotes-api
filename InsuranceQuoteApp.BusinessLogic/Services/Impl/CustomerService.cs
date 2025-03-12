using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceQuoteApp.BusinessLogic.Models;
using InsuranceQuoteApp.BusinessLogic.Services;
using InsuranceQuoteApp.Data;
using InsuranceQuoteApp.Data.Repositories; // We will define this later

public class CustomerService : ICustomerService
{
        private readonly ICustomerRepository _iCustomerRepository;

        public CustomerService(ICustomerRepository iCustomerRepository)
        {
            _iCustomerRepository = iCustomerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomerList(){
            var Customer = await _iCustomerRepository.GetAllCustomerAsync();

            var CustomerDtoList = Customer.Select(a => new CustomerDto
            {
                Id = a.Id,
                FirstName = a.FirstName
            });

            return CustomerDtoList;
        }

        public async Task<CustomerDto> GetCustomerByID(int ID){
            var Customer = await _iCustomerRepository.GetCustomerAsync(ID)
            ;
            var CustomerDto = new CustomerDto{
                    Id = Customer.Id,
                    FirstName = Customer.FirstName
            };

            return CustomerDto;
        }

        public async Task CreateCustomer(CustomerDto customerDto){
            var Customer = new Customer{
                FirstName = customerDto.FirstName,
                LastName = "No Last Name",
                Email = "enriquemoutinho@gmail.com",
                PhoneNumber = "066 207 8512"
            };

            await _iCustomerRepository.CreateCustomer(Customer);
        }

}