namespace API.Business.Repository.IRepository
{
    public interface IRepositoryManager
    {
        ICustomerRepository _customerRepository { get; }
        IBillRepository _billRepository { get; }
        IOrderDetailRepository _orderDetailRepository {get;}

        IProductRepository _productRepository { get; }

        Task SaveAsync();
    }
}
