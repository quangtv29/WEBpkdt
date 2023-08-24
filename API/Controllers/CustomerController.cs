using API.Business.DTOs.BillDTO;
using API.Business.DTOs.CustomerDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Database;
using API.Entities;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public CustomerController(DataContext db, ICustomerService customerService,IMapper mapper)
        {
            _db = db;
            _customerService = customerService;
            _mapper=mapper;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _customerService.GetAllCustomer(trackChanges: false);
                if (list == null)
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }
                var mappedCustomers = list.Select(c => _mapper.Map<GetAllCustomerDTO>(c));
                var message = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "succcess",
                    data = mappedCustomers
                };
                return Ok(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = ex.Message });
            }
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
                var mappedCustomers = customer.Select(c => _mapper.Map<GetAllCustomerDTO>(c));
                var message = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "succcess",
                    data = mappedCustomers
                };
                return Ok(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = ex.Message });
            }
        }
        
    }
}
