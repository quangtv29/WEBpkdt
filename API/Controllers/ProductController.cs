using API.Business.DTOs.ProductDTO.cs;
using API.Business.Helper;
using API.Business.Services.Interface;
using API.Database;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net;
using System.Net.WebSockets;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public ProductController(IServiceManager service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

 

        [HttpGet("getAllProduct")]

        public async Task<IActionResult> getAllProduct()
        {
            try
            {
                var products = await _service.productService.GetAll();
                if (products == null)
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }
                var convert = products.Select(p =>
                {
                    p.formatPrice = Helper.ConvertToMoney<int?>(p.Price);
                    p.formatImportPrice = Helper.ConvertToMoney<int?>(p.ImportPrice);
                    return p;
                }).ToList();

                var productDTO = _mapper.Map<List<GetAllProductDTO>>(convert);

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}



