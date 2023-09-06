using API.Business.DTOs.ProductTypeDTO;
using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class ProductTypeRepository :RepositoryBase<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DataContext db) : base(db)
        {
        }

        public void addProductType(ProductType productTypeDTO)
        {
            Create(productTypeDTO);
            
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
             var productType = await GetAll(false).Where(p => p.isDelete == false).ToListAsync();
            return productType;
        }

        public async Task<IEnumerable<ProductType>> GetProductTypeById(Guid? Id)
        {
            var producttype = await GetAllByCondition(p=>p.Id == Id, true).Where(p=>p.isDelete ==  false).ToListAsync();
            return producttype;
        }
    }
}
