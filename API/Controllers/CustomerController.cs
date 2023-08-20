using API.Business.Interfaces.ICustomerService;
using API.Database;
using API.Entities;
using API.Exceptions.NotFoundExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly DataContext _db;
        private readonly ICustomerService _customerAppService;
        public CustomerController(DataContext db, ICustomerService customerAppService)
        {
            _db = db;
            _customerAppService = customerAppService;
        }
        [HttpGet("getall")]
        public async Task<List<Customer>> GetAll()
        {
            var list = await _customerAppService.GetAll();
            return list;
        }

        [HttpPut("update")]

        public async Task<Customer> Update(Customer input)
        {
            var customerId = await _db.Customer.FindAsync(input.Id);

            if (customerId == null)
            {
                throw new CustomerNotFoundException(input.Id);
            }
            return customerId;
        }
    }
}
