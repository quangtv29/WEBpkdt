using API.Business.DTOs.OrderDetailDTO;
using API.Business.Helper;
using API.Business.Services.Interface;
using API.Entities;
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

        public async Task<IActionResult> getOrderDetailFromCustomerId (Guid? CustomerId)
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

        public async Task<IActionResult> getHistory (Guid? CustomerId)
        {
            var history = await _service.orderDetailService.purchaseHistory(CustomerId);
            return Ok(history);
        }

        [HttpPost("createOrderDetail")]

        public async Task<IActionResult> createOrderDetail(CreateOrderDetailDTO order)
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
                await _service.orderDetailService.createOrderDetail(order);
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
    }
}
