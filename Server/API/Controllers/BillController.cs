using API.Business.Services.Interface;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Business.DTOs.BillDTO;
using API.Business.Helper;
using API.Entities.Enum;
using API.Business.Shared;

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


        [HttpPost("getAll")]
        public async Task<IActionResult> getAll( Status status,[FromBody] BillParameters billParameters)
        {
                var bills = await _service.billService.GetAll(trackChanges: false, status, billParameters);
                if (bills.Item1 == null)
                {
                    _logger.LogInfo("List Bill is empty");
                    return BadRequest(HttpStatusCode.NotFound);
                }
                if (bills.Item1.Any())
                {
                    foreach (var bi in bills.Item1)
                    {
                        bi.FormatDate = bi.Time.ToString("dd/MM/yyyy HH:mm:ss");
                        bi.FormatShippingDate = bi.ShippingDate.ToString("dd/MM/yyyy HH:mm:ss");
                        var a = await _service.authenticationService.getInfoById(bi.CustomerID);
                        bi.UserName = a.UserName;
                    }
                }
                return Ok(new
                {
                    message = "Success",
                    data = _mapper.Map<List<GetAllBillDTO>>(bills.Item1),
                    totalPage = bills.Item2
                }) ;
        }
        
        [HttpPost("{customerId}/bills")]
        public async Task<IActionResult> getAllBillFromCustomer(string? customerId, Status status)
        {       
                var bills = await _service.billService.GetAllBillFromCustomer(customerId, trackChanges: false, status );
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
                    p.FormatShippingDate = p.ShippingDate.ToString("dd/MM/yyyy HH:mm:ss");
                    return p;
                }).ToList();

                return Ok(_mapper.Map<List<GetAllBillDTO>>(convert));
        }

        [HttpPost("createBill")]

        public async Task<IActionResult> createBillWithDiscountCode(CreateBillDTO bill, string code)
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
        [HttpPost("getBillById")]
        public async Task<IActionResult> getBillById(Guid? Id)
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

        [HttpPost("updateBill")]
        public async Task<IActionResult> updateBillById (UpdateBillDTO bill)
        {
                if(bill ==null)
                {
                    return BadRequest();
                }    
                 await _service.billService.updateBillById(bill);
                return Ok();   
        }

        [HttpPost("getInfoOrder")]

        public async Task<IActionResult> getInfoOrder (string? Id)
        {
            var result = await _service.billService.getInfoOrder(Id);
            return Ok(result);
        }

        [HttpPost("updateStatusBill")]
        public async Task<IActionResult> updateStatusBill(Guid? Id, Status status)
        {
                var result = await _service.billService.updateStatusBill(Id, status);
                return Ok("done");
        }

        [HttpPost("totalRevenue")]

        public async Task<IActionResult> totalRevenue()
        {
            var result = await _service.billService.TotalRevenueLast12Months();
            return Ok(result);
        }

        [HttpPost("statiscal")]

        public async Task<IActionResult> statisticalProduct(DateTime a)
        {
            var result = await _service.billService.statisticalProduct(a);
            return Ok(result);
        }

        [HttpPost("payVNPay")]
       public async Task<string> payVNPay(CreateVNPayDTO vnpay)
        {
            var result = await _service.billService.payVNPay(vnpay);
            return result;
        }
        [HttpPost("updatePayDone")]
         public async Task<IActionResult> updatePayDone(Guid? Id)
        {        
                var result = await _service.billService.updatePayDone(Id);
                if (result != null)
                {
                    return Ok("Update done");

                }
                return BadRequest("Id null");
        }
    }
}
