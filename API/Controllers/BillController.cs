using API.Business.Services.Interface;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Business.DTOs.BillDTO;
using API.Business.Helper;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class BillController : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;

        public BillController(IMapper mapper, IServiceManager service, ILoggerManager logger)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }


        [HttpGet("getAll")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var bills = await _service.billService.GetAll(trackChanges: false);
                if (bills == null || !bills.Any())
                {
                    _logger.LogInfo("List Bill is empty");
                    return BadRequest(HttpStatusCode.NotFound);
                }
                var convert = bills.Select(
                   p => {
                       p.ConvertDiscount = Helper.ConvertToMoney<int?>(p.Discount);
                       p.ConvertTotalMoney = Helper.ConvertToMoney<int?>(p.TotalMoney);
                       return p;
                   })
                   .ToList();
                return Ok(new
                {
                    message = "Success",
                    data = _mapper.Map<List<GetAllBillDTO>>(convert)
                }) ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
        [HttpGet("{customerId}/bills")]
        public async Task<IActionResult> getAllBillFromCustomer (Guid? customerId)
        {
           try
            {
                var bills = await _service.billService.GetAllBillFromCustomer(customerId,trackChanges: false);
                var convert = bills.Select(
                    p => {
                        p.ConvertDiscount = Helper.ConvertToMoney<int?>(p.Discount);
                        p.ConvertTotalMoney = Helper.ConvertToMoney<int?>(p.TotalMoney);
                        return p;
                    })
                    .ToList();

                return Ok(_mapper.Map<List<GetAllBillDTO>>(convert));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("createBill")]

        public async Task<IActionResult> createBill (CreateBillDTO bill) 
        {
            try
            {
                if ( bill == null)
                {
                    return Ok(new ApiResponse
                    {
                        Message = "Bill is null",
                        StatusCode = HttpStatusCode.BadRequest
                    });
                }    
                await _service.billService.createBill(bill);
                return Ok(new ApiResponse
                {
                    Message = "Create Success",
                    StatusCode = HttpStatusCode.Created
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                }) ;
            }
        }

    }
}
