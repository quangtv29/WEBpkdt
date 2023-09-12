using API.Business.DTOs.CustomerDTO;
using API.Business.Services.Interface;
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

        public async Task<IActionResult> getAllCustomerById (Guid? Id)
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
                    data = _mapper.Map<List<GetAllCustomerDTO>>(convert)
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
    }
}
