using API.Business.Repository;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;

namespace API.Business.Services
{
    public sealed class BillService : IBillService
    {
        private readonly IRepositoryManager _repositoryBill;

        public BillService(IRepositoryManager repositoryBill)
        {
            _repositoryBill = repositoryBill;
        }

       

        public async Task<IEnumerable<Bill>> GetAll(bool trackChanges)
        {
            var bill = await  _repositoryBill._billRepository.GetAllBill(trackChanges);
                return bill;
        }
    }
}
