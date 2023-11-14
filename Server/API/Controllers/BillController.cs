using API.Business.Services.Interface;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Business.DTOs.BillDTO;
using API.Business.Helper;
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
                   p =>
                   {
                       p.ConvertDiscount = Helper.ConvertToMoney<double?>(p.Discount);
                       p.ConvertTotalMoney = Helper.ConvertToMoney<int?>(p.TotalMoney);
                       return p;
                   })
                   .ToList();
                return Ok(new
                {
                    message = "Success",
                    data = _mapper.Map<List<GetAllBillDTO>>(convert)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
        [Authorize(Roles = "Manager")]
        [HttpGet("{customerId}/bills")]
        public async Task<IActionResult> getAllBillFromCustomer(string? customerId)
        {
            try
            {
                var bills = await _service.billService.GetAllBillFromCustomer(customerId, trackChanges: false);
                //var convert = bills.Select(
                //    p => {
                //        p.ConvertDiscount = Helper.ConvertToMoney<double?>(p.Discount);
                //        p.ConvertTotalMoney = Helper.ConvertToMoney<int?>(p.TotalMoney);
                //        return p;
                //    })
                //    .ToList();

                var convert = bills.Select(p =>
                {
                    p.FormatDate = p.Time.ToString("dd/MM/yyyy HH:mm:ss");
                    return p;
                }).ToList();

                return Ok(_mapper.Map<List<GetAllBillDTO>>(convert));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("createBill")]

        public async Task<IActionResult> createBillWithDiscountCode(CreateBillDTO bill, string code)
        {
            try
            {
                if (bill == null)
                {
                    return Ok(new ApiResponse
                    {
                        Message = "Bill is null",
                        StatusCode = HttpStatusCode.BadRequest
                    });
                }
                var status = await _service.billService.createBill(bill, code);
                if (status == null)
                    return Ok(new ApiResponse
                    {
                        Message = "Mã giảm giá không hợp lệ",
                    });
                else if (status.CustomerID == null)
                {
                    return Ok(new ApiResponse
                    {
                        Message = "Mã giảm giá đã hết số lượt sử dụng"
                    });
                }

                else
                {
                    return Ok(new
                    {
                        StatusCode = HttpStatusCode.Created,
                        Data = status
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });
            }
        }
        [HttpPost("getBillById")]
        public async Task<IActionResult> getBillById(Guid? Id)
        {
            try
            {
                if (Id == null)
                {
                    return Ok(
                        new
                        {
                            StatusCode = HttpStatusCode.NotFound
                        });
                }
                var result = await _service.billService.getBillById(Id);
                 result.FormatDate = result.Time.ToString("dd/MM/yyyy HH:mm:ss");
                return Ok(result);
            }

            catch (Exception ex)
            {
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("updateBill")]
        public async Task<IActionResult> updateBillById (UpdateBillDTO bill)
        {
            try
            {
                var bills = await _service.billService.updateBillById(bill);
                return Ok("done");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }
    }
}
