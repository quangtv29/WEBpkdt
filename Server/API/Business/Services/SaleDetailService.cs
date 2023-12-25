using API.Business.DTOs.SaleDetailDTO;
using API.Business.DTOs.SaleDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Services
{
    public class SaleDetailService : ISaleDetailService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        public SaleDetailService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;   
            _mapper = mapper;
        }

        public async Task<double?> getMoney (string discount, string id, double totalMoney)
        {
            var result = await (from sd in _repo.SaleDetail.GetAll(false)
                                join s in _repo.Sale.GetAll(false) on sd.SaleId equals s.Id
                                where sd.CustomerId == id && s.DiscountCode == discount
                                select new
                                {
                                    s.MinBill,
                                    s.Quantity,
                                    s.Count,
                                    s.Money,
                                    s.EndDate,
                                    s.Percent
                                }
                                ).FirstOrDefaultAsync();

            if (result == null ) {
                return -1; //mã giảm giá không hợp lệ
            }
            double? discounts = 0; // chưa đủ giá trị đơn hàng tối thiểu

            if (totalMoney >= result.MinBill)
            {
                discounts = totalMoney * result.Percent <= result.Money
                    ? totalMoney * result.Percent
                    : result.Money;
                if (result.EndDate < DateTime.Now )
                {
                    return -2; //hết hạn
                }
            }
            return discounts;
        }

        public async Task<SaleDetail> createSaleDetail(CreateSaleDetailDTO saleDetail)
        {
            var sale = await _repo.Sale.GetAllByCondition(p => p.Id == saleDetail.SaleId, true)
               .Where(p => p.isDelete == false)
               .FirstOrDefaultAsync();
            if (sale.Count < sale.Quantity)
            {
                var sd = _mapper.Map<SaleDetail>(saleDetail);
                _repo.SaleDetail.CreateSaleDetail(sd);
                sale.Count += 1;
                await _repo.SaveAsync();
                return sd;
            }
            return null;   
        }

        public async Task<SaleDetail> check (Guid? SaleId, string? customerId)
        {
            var result = await _repo.SaleDetail.GetAllByCondition(p => p.SaleId == SaleId && p.CustomerId == customerId, false)
                .Where(p => p.isDelete == false)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
