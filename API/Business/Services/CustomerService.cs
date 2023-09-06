using API.Business.DTOs.CustomerDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;

namespace API.Business.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly  IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public CustomerService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Customer> addCustomer(CreateCustomerDTO customer)
        {
             var convert = _mapper.Map<Customer>(customer);
            _repo._customerRepository.addCustomer(convert); 
            await  _repo.SaveAsync();
            return convert;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges)
        {          
              var customer = await _repo._customerRepository.GetAllCustomer(trackChanges) 
                ?? throw new Exception ("Customer is null");
                return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerByID(Guid? Id, bool trackChanges)
        {
            var customer =  await _repo._customerRepository.GetCustomerByCondition(e=> e.Id == Id, trackChanges);
            return customer;
        }

        
    }
}
