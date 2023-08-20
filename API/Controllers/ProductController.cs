using API.Business.DTOs.ProductDTO.cs;
using API.Database;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.WebSockets;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly DataContext _db;
        public ProductController(DataContext db)
        {
            _db = db;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> Getall(int pageNumber, int pageSize)
        {
            try
            {
                var pagedProducts = await _db.Product.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
                List<Product> productList = new List<Product>();
                foreach (var pro in pagedProducts)
                {
                    Product productformattedPrice = new Product
                    {
                        Id = pro.Id,
                        Image = pro.Image,
                        Name = pro.Name,
                        Describe = pro.Describe,
                        Price = pro.Price,
                        ProductTypeID = pro.ProductTypeID,
                        ImportPrice = pro.ImportPrice,
                        Quantity = pro.Quantity,
                        Producer = pro.Producer,
                        formatPrice = string.Format("đ{0:N0}", pro.Price).Replace(",", "."),
                        formatImportPrice = string.Format("đ{0:N0}", pro.ImportPrice).Replace(",", ".")
                    };
                    productList.Add(productformattedPrice);
                }
                var totalPages  = (int)Math.Ceiling((await _db.Product.CountAsync() /(double) pageSize));
                var response = new
                {
                    status = 200,
                    message = "Success",
                    data = productList,
                    totalPages = totalPages
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getProductById/{id}")]

       public async Task<List<Product>> GetProductbyId (Guid? id)
        {
            var product = await _db.Product.Where(p => p.Id == id).AsNoTracking().ToListAsync();
            string formattedPrice, formatImportPrice;
            List<Product> listProduct = new List<Product>();
            foreach(var pro in product)
            {

                formattedPrice = string.Format("đ{0:N0}", pro.Price).Replace(",", ".");
                formatImportPrice = string.Format("đ{0:N0}", pro.ImportPrice).Replace(",", ".");
                Product productformattedPrice = new Product
                {
                    Id = pro.Id,
                    Image = pro.Image,
                    Name = pro.Name,
                    Describe = pro.Describe,
                    Price = pro.Price,
                    ProductTypeID = pro.ProductTypeID,
                    ImportPrice = pro.ImportPrice,
                    Quantity = pro.Quantity,
                    Producer = pro.Producer,
                    formatPrice = formattedPrice,
                    formatImportPrice = formatImportPrice
                };
                listProduct.Add(productformattedPrice);
            }    
            return listProduct;
        }


        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct (CreateProductDTO input)
        {
            var products = new Product
            {
                Id = new Guid(),
                Name = input.Name,
                Quantity = input.Quatity,
                ImportPrice = input.ImportPrice,
                Price = input.Price,
                Image = input.Image,
                ProductTypeID = input.ProductTypeID,
                Producer = input.Producer,
                Describe = input.Describe
            };
        await _db.Product.AddAsync(products);
          await  _db.SaveChangesAsync();
            return new JsonResult("Done");
        }





    }
}
//1. API lấy danh sách dịch vụ bảng WebServiceBookingItem
//[HttpGet]
//public async Task<IActionResult> GetServiceBookingItems([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string query = "")
//{
//    try
//    {
//        var items = await _WebServiceBookingItem.GetAll(pageIndex, pageSize, query);
//        int total = (int)Math.Ceiling((double)items.Count / pageSize);
//        var response = new
//        {
//            status = 200,
//            message = "Success",
//            total,
//            data = items.Select(item => new
//            {
//                id = item.Id,
//                serviceId = item.ServiceId,
//                title = item.Title,
//                subtitle = item.Subtitle
//            })
//        };

//        return Ok(response);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e);
//        return StatusCode(500, new { message = e.Message });
//    }
//}
//[HttpGet("getAll")]
//public async Task<IActionResult> GetPagedProducts(int pageNumber, int pageSize)
//{
//    try
//    {
//        var pagedProducts = await _db.Product
//            .OrderBy(p => p.Id)
//            .Skip((pageNumber - 1) * pageSize)
//            .Take(pageSize)
//            .AsNoTracking()
//            .ToListAsync();

//        List<Product> productList = pagedProducts.Select(pro => new Product
//        {
//            Id = pro.Id,
//            Image = pro.Image,
//            Name = pro.Name,
//            Describe = pro.Describe,
//            Price = pro.Price,
//            ProductTypeID = pro.ProductTypeID,
//            ImportPrice = pro.ImportPrice,
//            Quantity = pro.Quantity,
//            Producer = pro.Producer,
//            formatPrice = string.Format("đ{0:N0}", pro.Price).Replace(",", "."),
//            formatImportPrice = string.Format("đ{0:N0}", pro.ImportPrice).Replace(",", ".")
//        }).ToList();

//        int totalProducts = await _db.Product.CountAsync();
//        int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

//        var response = new
//        {
//            status = 200,
//            message = "Success",
//            total = totalPages,
//            data = productList
//        };

//        return Ok(response);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e);
//        return StatusCode(500, new { message = e.Message });
//    }
//}


