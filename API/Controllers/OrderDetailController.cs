using API.Business.DTOs.OrderDetailDTO;
using API.Database;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderDetailController : BaseApiController
    {
        public readonly DataContext _db;
        public OrderDetailController(DataContext db)
        {
            _db = db;
        }

        [HttpPut("updateTotalMoney")]

        public async Task <string> UpdateTotalMoney (int Price, int Quantity)
        {
           var totalMoney = Price * Quantity;

           string totalMoneyy = string.Format("đ{0:N0}", totalMoney).Replace(",", ".");
            return totalMoneyy;
        }
    }
}
