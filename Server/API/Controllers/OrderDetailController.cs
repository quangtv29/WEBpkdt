using API.Business.DTOs.OrderDetailDTO;
using API.Business.Helper;
using API.Business.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class OrderDetailController : BaseApiController
    {
        private readonly IServiceManager _service;

        public OrderDetailController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("getAllOrderDetail")]
       
        public async Task<IActionResult> getAllOrderDetail ()
        {
            try
            {
                var orderDetail = await _service.orderDetailService.GetAll(trackChanges: false);
                if (orderDetail == null )
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }
                return Ok(orderDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });   
            }
        }

        [HttpGet("getOrderDetailFromCustomerId")]
        [Authorize(Roles ="Customer")]

        public async Task<IActionResult> getOrderDetailFromCustomerId (string? CustomerId)
        {
            var orderDetail = await _service.orderDetailService.GetOrderDetailFromCustomerId(CustomerId);
            return Ok(orderDetail);
        }

        [HttpPut("updateTotalMoney")]

        public async Task<IActionResult> updateTotalMoney (Guid? productID, int? Quantity)
        {
            var update = await _service.orderDetailService.UpdateTotalMoneyDTO(productID, Quantity);
            return Ok(update);
        }

        [HttpGet("history")]
        [Authorize(Roles ="Manager")]
        public async Task<IActionResult> getHistory (string? CustomerId)
        {
            var history = await _service.orderDetailService.purchaseHistory(CustomerId);
            return Ok(history);
        }
        [HttpGet("listCart")]
        public async Task<IActionResult> listCart(string CustomerId)
        {
            if (CustomerId == null)
            {
                return BadRequest();
            }    
            var result = await _service.orderDetailService.listCart(CustomerId);
            return Ok(result);
        }

        [HttpPost("createCart")]
       

        public async Task<IActionResult> createOrderDetail(CreateCartDTO order, string customerid)
        {
            try
            {
                if (order == null)
                {
                    return Ok(new ApiResponse
                    {
                        Message = "Order is null",
                        StatusCode = HttpStatusCode.BadRequest
                    });
                }
                await _service.orderDetailService.createCart(order, customerid);
                return Ok(new ApiResponse
                {
                    Message = "Create Success",
                    StatusCode = HttpStatusCode.Created
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = ex.Message
                });
            }
        }
        [HttpPost("updateTotal")]
        public async Task<IActionResult> updateTotal (UpdateTotalMoneyDTO update)
        {
            if (update.Quantity == null)
            {
                update.Quantity = 1;
            }    
            var result = await _service.orderDetailService.updateTotal(update.Id, update.Quantity);
            return Ok(result);
        }

        [HttpPost("getOrderDetailByBillId")]

        public async Task<IActionResult> getOrderDetailByBillId (Guid? Id)
        {
            if (Id == null)
                return BadRequest(HttpStatusCode.NotFound);
            var result = await _service.orderDetailService.getOrderDetailByBillId(Id);
            return Ok(result);
        }

        [HttpPost("updateOrderDetailBillId")]

        public async Task<IActionResult> updateOrderDetailBillId (UpdateByBillIdDTO update)
        {
            var result = await _service.orderDetailService.updateOrderDetailBillId(update.orderDetailId, update.BillId);
             if (result == null)
            {
                return BadRequest("Quantity is 0");
            }    
            return Ok(new
            {
                Message = "Update success"
            });
        }

        [HttpPost ("updateOrderDetail")]

        public async Task<IActionResult> updateOrderDetail (Guid? Id, string? isCart)
        {
            var result = await _service.orderDetailService.updateOrderDetail(Id, isCart);
            if (result != null)
            {
                return Ok("update done");
            }
            else
            {
                return Ok(new
                {
                    Message = "Thêm hoá đơn bị lỗi"
                });
            }
        }
        [HttpPost ("Count")]

        public async Task<IActionResult> countCart (string? CustomerId)
        {
            try
            {
                if (CustomerId == null)
                {
                    return BadRequest(HttpStatusCode.NotFound);
                }    
                var result = await _service.orderDetailService.countCart(CustomerId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getTotalProfitByLast12Months")]
        public async Task<IActionResult> getTotalProfit ()
        {
            var result = await _service.orderDetailService.totalProfit();
            return Ok(result);
        }
        [HttpPost("deleteOrder")]

        public async Task<IActionResult> deleteOrder (Guid? Id)
        {
            try
            {
                await _service.orderDetailService.deleteOrder(Id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }


    }
}
