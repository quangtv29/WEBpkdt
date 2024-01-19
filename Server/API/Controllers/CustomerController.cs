using API.Business.DTOs.CustomerDTO;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public CustomerController(IServiceManager service, IMapper mapper, ILoggerManager logger)
        {
          
            _service = service;
            _mapper=mapper;
            _logger = logger;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _service.customerService.GetAllCustomer(trackChanges: false);
                if (!list.Any())
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }
                var convert = list.Select(p => {
                    p.FormatDate = p.DateOfBirth.ToString("dd/MM/yyyy");
                    return p; 
                    }).ToList();
                var message = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "succcess",
                    data = _mapper.Map<List<GetAllCustomerDTO>>(convert)
                };
                return Ok(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> getAllCustomerById (string? Id)
        {
            try
            {
                var customer = await _service.customerService.GetCustomerByID(Id, trackChanges: false);
                if (customer == null|| !customer.Any())
                {
                    _logger.LogInfo($"The Customer with id = {Id} does n't exists in the database ");
                    return BadRequest(HttpStatusCode.NotFound);
                }
                var convert = customer.Select(p => {
                    p.FormatDate = p.DateOfBirth.ToString("dd/MM/yyyy");
                    return p;
                }).ToList();
                var message = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "succcess",
                    data = convert
                };
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("createCustomer")]
        
        public async Task<IActionResult> createCustomer ([FromBody ]CreateCustomerDTO input)
        {
            try
            {
                var customer = await _service.customerService.addCustomer(input);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new
                {
                    message = ex.Message
                }) ;
            }
        }

        [HttpPost("updateCustomer")]

        public async Task<IActionResult> updateCustomer(string? Id, string? lastName, string? firstName, UpdateCustomerDTO update)
        {
            try
            {
                var result = await _service.customerService.updateCustomer(Id, update);
                var user = await _service.authenticationService.UpdateUser(Id, firstName, lastName);
                return Ok("Update done");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addAvatar")]
        public async Task<IActionResult> addAvatar([FromForm] AddCustomerDTO image, string? CustomerId)
        {
            try
            {
                var result = await _service.customerService.addAvatar(image.Image, CustomerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("lockAccount")]
       public async Task<IActionResult> lockAccount(string? id)
        {
            var result = await _service.customerService.lockAccount(id);
            if (result == null)
            {
                return BadRequest();
            }    
            else
            {
                return Ok(result);
            }
        }
    }
}
