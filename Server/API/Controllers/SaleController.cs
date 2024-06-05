using API.Business.DTOs.SaleDTO;
using API.Business.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class SaleController : BaseApiController
    {
        private readonly IServiceManager _service;

        public SaleController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult?> getMoney(string discountCode, int? totalMoney)
        {
            var money = await _service.saleService.getMoney(discountCode,totalMoney);
            if (money == 0) {
                return Ok(new
                {
                    Data = 0,
                    Message = "Chưa đạt giá trị đơn hàng tối thiểu!"
                });
            }
            else if (money == -1) {
                return Ok(new
                {
                    Data = -1,
                    Message = "Mã giảm giá không tồn tại!"
                });
            }
            else if (money == -2) {
                return Ok(new
                {
                    Data = -2,
                    Message = "Mã giảm giá đã được sử dụng hết!"
                });
            }
       return Ok(new
            {
                Message = money
            });
        }
        [HttpPost("createSale")]

        public async Task<IActionResult> createSale(CreateDiscountCode discount)
        {
            if (discount != null)
            {
              var result = await _service.saleService.createSale(discount);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllSale")]

        public async Task<IActionResult> getAll(string customerid)
        {
                var sale = await _service.saleService.getAll(customerid);
                foreach(var sa in sale)
                {
                    sa.FormatDate = sa.EndDate.ToString("dd/MM/yyyy");
                }    
                return Ok(sale);
        }

    }
}
