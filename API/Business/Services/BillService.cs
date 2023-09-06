using API.Business.DTOs.BillDTO;
using API.Business.Repository;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;

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

        public async Task createBill(CreateBillDTO bill)
        {
            var cbill =  _mapper.Map<Bill>(bill);
           _repo._billRepository.createBill(cbill);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<Bill>> GetAll(bool trackChanges)
        {
            var bill = await  _repo._billRepository.GetAllBill(trackChanges);
                return bill;
        }

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomer(Guid? customerId, bool trackChanges)
        {
            var customer = await _repo._customerRepository.GetCustomerByCondition(p => p.Id == customerId, trackChanges);
            if (customer == null || !customer.Any())
            {
                throw new CustomerNotFoundException(customerId);
            }
                var bill = await _repo._billRepository.GetAllBillFromCustomer(customerId, trackChanges);
                    return bill;
        }
    }
}
