using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
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
        private readonly ICustomerService _customerService;
        public CustomerController(DataContext db, ICustomerService customerService)
        {
            _db = db;
            _customerService = customerService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var list = _customerService.GetAllCustomer(trackChanges : false);
            return Ok(list);
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
