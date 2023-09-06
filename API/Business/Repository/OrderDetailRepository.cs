using API.Business.DTOs.OrderDetailDTO;
using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Business.Repository
{
    public class OrderDetailRepository :  RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DataContext db) : base(db)
        {
        }

        public void addOrderDetail(OrderDetail orderDetail)
        {
            Create(orderDetail);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail(bool trackChanges)
        {
          var orderDetail =   await GetAll(trackChanges).Where(p => p.isDelete == false).ToListAsync();
            return orderDetail;
        }

        public async Task<OrderDetail> GetOrderDetailById(Guid? Id)
        {
            var orderDetail = await GetAllByCondition(p => p.Id == Id, true).Where(p => p.isDelete == false).FirstOrDefaultAsync() ?? throw new Exception($"The OrderDetail with id : {Id} doesn't exist in the databse.");
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerID(IEnumerable<Bill> bills)
        {
            List<OrderDetail> orderDetails = new ();
            foreach (var bill in bills)
            {
                var order = await GetAllByCondition(p => p.BillId == bill.Id, false).Where(p => p.isDelete == false).ToListAsync();
                orderDetails.AddRange(order.ToList());
            }

            return orderDetails;
        }

       
    }
}
