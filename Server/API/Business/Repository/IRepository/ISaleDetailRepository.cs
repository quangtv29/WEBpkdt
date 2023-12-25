using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface ISaleDetailRepository : IRepositoryBase<SaleDetail>
    {
      void  CreateSaleDetail(SaleDetail saleDetail);
    }
}
