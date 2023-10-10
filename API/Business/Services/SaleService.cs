using API.Business.DTOs.SaleDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;

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
            var sale = _mapper.Map<Sale>(discount);
            _repo.Sale.createSale(sale);
           await _repo.SaveAsync();
            return sale;
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
