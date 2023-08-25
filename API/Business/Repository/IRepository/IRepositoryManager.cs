namespace API.Business.Repository.IRepository
{
    public interface IRepositoryManager
    {
        ICustomerRepository _customerRepository { get; }
        IBillRepository _billRepository { get; }

        void Save();
    }
}
