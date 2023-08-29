using API.Business.Services.Interface;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Business.DTOs.BillDTO;
using API.Business.Helper;

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

      

    }
}
