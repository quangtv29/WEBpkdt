using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Database;
using API.Entities;
using API.Exceptions.NotFoundExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net;

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
        public IActionResult GetAll()
        {
            var list = _customerService.GetAllCustomer(trackChanges : false);
            if (list == null)
            {
                return BadRequest(HttpStatusCode.NoContent);
            }
            return Ok(list);
        }

        [HttpGet("getCustomerById/{Id}")]

        public  IActionResult getAllCustomerById (Guid? Id)
        {
            try
            {
                var customer = _customerService.GetCustomerByID(Id, trackChanges: false);
                if (customer == null)
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }
                var message = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "succcess",
                    data = customer
                };
                return Ok(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = ex.Message });
            }
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
