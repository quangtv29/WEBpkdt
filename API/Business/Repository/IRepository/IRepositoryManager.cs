namespace API.Business.Repository.IRepository
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        IBillRepository Bill { get; }
        IOrderDetailRepository OrderDetail {get;}

        IProductRepository Product { get; }
        IProductTypeRepository ProductType { get; }

        IAccountRepository Account { get; }

        ISaleRepository Sale { get; }

        IProductListRepository ProductList { get; }
        Task SaveAsync();
    }
}
