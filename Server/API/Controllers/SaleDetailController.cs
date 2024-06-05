using API.Business.DTOs.SaleDetailDTO;
using API.Business.Services.Interface;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SaleDetailController : BaseApiController
    {
        private readonly IServiceManager _service;

        public SaleDetailController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("getMoney")]
        public async Task<IActionResult> getMoney(string discount, string id, double totalMoney)
        {
            var money = await _service.saleDetailService.getMoney(discount,id, totalMoney);
            if (money == 0)
            {
                return Ok(new
                {
                    Data = 0,
                    Message = "Chưa đạt giá trị đơn hàng tối thiểu!"
                });
            }
            else if (money == -1)
            {
                return Ok(new
                {
                    Data = -1,
                    Message = "Mã giảm giá không tồn tại!"
                });
            }
            else if (money == -2)
            {
                return Ok(new
                {
                    Data = -2,
                    Message = "Mã giảm giá đã hết hạn"
                });
            }
            return Ok(new
            {
                Message = money
            });
        }
        [HttpPost("CreateSD")]

        public async Task<IActionResult> createSaleDetail(CreateSaleDetailDTO saleDetail)
        {
                var result = await _service.saleDetailService.createSaleDetail(saleDetail);
                if (result == null)
                {
                    return Ok("Mã giảm giá đã được lưu hết");
                }    
                return Ok(result);
        }
        [HttpPost("check")]

      public async  Task<IActionResult> check(Guid? SaleId, string? customerId)
        {
            var result = await _service.saleDetailService.check(SaleId, customerId);
            var data = 0;
            if (result == null)
            {
                data = 1;
            }
            return Ok(data);
        }
        [HttpPost("updateSaleDetail")]
        public async Task<IActionResult> updateSaleDetail(string discount, string id)
        {
            var result = await _service.saleDetailService.updateSaleDetail(discount, id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
