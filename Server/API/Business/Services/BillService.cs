using API.Business.DTOs.BillDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;
using System.Reflection.Metadata.Ecma335;

namespace API.Business.Services
{
    public sealed class BillService : IBillService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;


        public BillService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Bill> createBill(CreateBillDTO bill, string code)
        {
            var bills =  _mapper.Map<Bill>(bill);
            if (code == null)
            {
                bills.Discount = 0;
                bills.IntoMoney = bills.TotalMoney;
                _repo.Bill.createBill(bills);
                await _repo.SaveAsync();
                return bills;
            }
            else
            {
                var sale = await _repo.Sale.GetSaleByCode(code);
                if (sale == null)
                {
                    return null;
                }
                double? discount = 0;
                if (bills.TotalMoney > sale.MinBill)
                {
                    discount = bills.TotalMoney * sale.Percent > sale.Money
                       ? sale.Money
                       : bills.TotalMoney * sale.Percent;
                }
                if (sale.Count < sale.Quantity)
                {
                    bills.Discount = discount;
                    bills.IntoMoney = bills.TotalMoney - discount >= 0
                        ? bills.TotalMoney - discount
                        : 0;

                    sale.Count += 1;
                    _repo.Bill.createBill(bills);
                    await _repo.SaveAsync();
                    return bills;   
                }
                return new Bill { };
            }
        }

        public async Task<IEnumerable<Bill>> GetAll(bool trackChanges)
        {
            var bill = await  _repo.Bill.GetAllBill(trackChanges);
                return bill;
        }

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges)
        {
            var customer = await _repo.Customer.GetCustomerByCondition(p => p.Id == customerId, trackChanges);
            if (customer == null || !customer.Any())
            {
                throw new CustomerNotFoundException(customerId);
            }
                var bill = await _repo.Bill.GetAllBillFromCustomer(customerId, trackChanges);
                    return bill;
        }

       
    }
}
