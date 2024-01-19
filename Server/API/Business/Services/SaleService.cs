using API.Business.DTOs.SaleDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Services
{
    public class SaleService : ISaleService
    {
        public readonly IRepositoryManager _repo;
        public readonly IMapper _mapper;

        public SaleService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public  async Task<Sale> createSale(CreateDiscountCode discount)
        {
            var check = await _repo.Sale.GetAllByCondition(p => p.DiscountCode == discount.DiscountCode, true)
                .Where(p => p.isDelete == false).FirstOrDefaultAsync();
            if (check != null)
            {
                check.Percent = discount.Percent;
                check.Quantity = discount.Quantity;
                check.Money = discount.Money;
                check.MinBill = discount.MinBill;
                check.EndDate = discount.EndDate;
                await _repo.SaveAsync();
                return check;
            }
                
            var sale = _mapper.Map<Sale>(discount);
            _repo.Sale.createSale(sale);
           await _repo.SaveAsync();
            return sale;
        }

        public async Task<IEnumerable<Sale>> getAll(string customerId)
        {
            if (customerId == null)
            {
                var sale = await _repo.Sale.GetAll(false).Where(p => p.isDelete == false)
                    .ToListAsync();
                return sale;
            }
            else
            {
                var sale = await _repo.Sale.GetAll(false).Where(p => p.isDelete == false)
                    .ToListAsync();
                foreach(var sa in sale )
                {
                    var sd = await _repo.SaleDetail.GetAllByCondition(p => p.CustomerId == customerId && p.SaleId == sa.Id,false)
                        .Where(p=>p.isDelete==false)
                        .FirstOrDefaultAsync();
                    if (sd == null)
                    {
                        sa.isActive = false;
                    }    
                    else
                    {
                        sa.isActive = true;
                    }    
                }
                return sale;
            }
           
        }

        public async Task<double?> getMoney(string discountCode, int? totalMoney)
        {
            var result = await _repo.Sale.GetMoney(discountCode);
            var sale = await _repo.Sale.GetSaleByCode(discountCode);
            if (sale == null)
            {
                return -1; // mã giảm giá không hợp lệ
            }    
            double? discount = 0; // chưa đủ giá trị đơn hàng tối thiểu
            
            if (totalMoney >= sale.MinBill)
            {
                discount = totalMoney*sale.Percent <= sale.Money 
                    ? totalMoney * sale.Percent
                    : result;
               if (sale.Count >= sale.Quantity)
                {
                    return -2; //hết lượt sử dụng mã giảm giá
                }    
            }    
            return discount;
        }
    }
}
