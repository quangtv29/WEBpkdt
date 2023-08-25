using API.Business.DTOs.CustomerDTO;
using API.Business.Services.Interface;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public CustomerController( ICustomerService customerService,IMapper mapper, ILoggerManager logger)
        {
          
            _customerService = customerService;
            _mapper=mapper;
            _logger = logger;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _customerService.GetAllCustomer(trackChanges: false);
                if (!list.Any())
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
                if (customer == null|| !customer.Any())
                {
                    _logger.LogInfo($"The Customer with id = {Id} does n't exists in the database ");
                    return BadRequest(HttpStatusCode.NotFound);
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
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message });
            }
        }
        
    }
}
