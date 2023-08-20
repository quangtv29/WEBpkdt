using API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Business.DTOs.ProductDTO.cs;
using API.Business.DTOs.ProductTypeDTO;

namespace API.Controllers
{
    public class ProductTypeController : BaseApiController
    {
        private readonly DataContext _db;

        public ProductTypeController(DataContext db)
        {
            _db = db;
        }

        [HttpGet("getAll")]

        public async Task<IActionResult> GetAll()
        {
            var producttype = await _db.ProductType.AsNoTracking().ToListAsync();
            if (producttype == null)
                return BadRequest();
            else
            {
                return Ok(producttype);
            }
        }
        [HttpPost("createProDuctType")]

        public async Task<IActionResult> CreateProductType(CreateProductTypeDTO input)
        {
            ProductType productType = new ProductType
            {
                Id = new Guid(),
                Name = input.Name
            };
           await  _db.ProductType.AddAsync(productType);
           await _db.SaveChangesAsync();
            return Ok("Create Done");
        }



    }
}
