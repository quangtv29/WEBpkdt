using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.DTOs.AccountDTO;
using API.Entities;
using AutoMapper;

namespace API.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public AccountService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async  Task<Account> Login(LoginDTO login)
        {
            var account = await _repo.Account.Login(_mapper.Map<Account>(login));
            return account;
        }
    }
}
