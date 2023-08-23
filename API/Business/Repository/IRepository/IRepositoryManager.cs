namespace API.Business.Repository.IRepository
{
    public interface IRepositoryManager
    {
        ICustomerRepository _customerRepository { get; }

        void Save();
    }
}
