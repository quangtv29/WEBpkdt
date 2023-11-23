﻿using API.Business.DTOs.OrderDetailDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Business.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public OrderDetailService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllOrderDetail>> GetAll(bool trackChanges)
        {
            var orderDetail = await _repo.OrderDetail.GetAllOrderDetail(trackChanges);
            return _mapper.Map<List<GetAllOrderDetail>>(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailById(Guid? Id)
        {
            var orderDetail = await _repo.OrderDetail.GetOrderDetailById(Id);
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(string? customerId)
        {
            var bill = await _repo.Bill.GetAllBillFromCustomer(customerId, false);
            var orderDetail = await _repo.OrderDetail.GetOrderDetailFromCustomerID(bill);
            return orderDetail;
        }


        public async Task<int?> UpdateTotalMoneyDTO(Guid? Id, int? Quantity )
        {
            var product = await _repo.Product.GetProductById(Id);
            int? quantityValue = Quantity ?? 1;
           return product.Price * quantityValue;
        }

        public async Task<IEnumerable<PurchaseHistoryDTO>> purchaseHistory (string? CustomerId)
        {
            var result =  await (from kh in _repo.Customer.GetAll(false)
                                join bill in _repo.Bill.GetAll(false) on  kh.Id equals bill.CustomerID 
                                join order in _repo.OrderDetail.GetAll(false) on bill.Id equals order.BillId 
                                join product in _repo.Product.GetAll(false) on order.ProductId equals product.Id 
                                where kh.Id == CustomerId && order.isCart == "Bought"
                                orderby bill.Time
                                select new PurchaseHistoryDTO
                                {
                                    Id = order.Id,
                                    Quantity = order.Quantity,
                                    Product = product.Name,
                                    Price = (order.Price),
                                    ProductId = order.Id,
                                    Image = product.Image,
                                    TotalMoney = ( order.TotalMoney),
                                    Time = bill.Time
                                }
                                
            ).ToListAsync();

            return result;
           
        }

        public async Task createOrderDetail(CreateOrderDetailDTO orderDetail)
        {
            var product = await _repo.Product.GetProductById(orderDetail.ProductId);
            orderDetail.Price = product.Price;
            var order = _mapper.Map<OrderDetail>(orderDetail);
            _repo.OrderDetail.addOrderDetail(order);
             await _repo.SaveAsync();
        }



        public async Task<GetAllOrderDetail> createCart(CreateCartDTO orderDetail)
        {
            var product = await _repo.Product.GetProductById(orderDetail.ProductId);
            orderDetail.Price = product.Price;
            var order = _mapper.Map<OrderDetail>(orderDetail);
            order.isCart = "Cart";
            _repo.OrderDetail.addOrderDetail(order);
            await _repo.SaveAsync();
            return _mapper.Map<GetAllOrderDetail>(order);
        }


        public async Task<IEnumerable<OrderDetail>> updateOrderDetail(Guid? orderDetailId, string? isCart)
        {
            using (var transaction = _repo.Transaction())
            {
                    var bill = await _repo.OrderDetail.GetOrderDetailByBillID(orderDetailId);
                    foreach ( var order in bill)
                    {
                        var product = await _repo.Product.GetProductById(order.ProductId);
                        if (product.Quantity >= order.Quantity)
                        {
                            if (isCart == "canceled")
                            {
                                if (order.isCart == "Cart")
                                {
                                    order.isCart = "Canceled";

                                }
                                else if (order.isCart == "Delivering")
                                {
                                    order.isCart = "Canceled";
                                    product.Quantity += order.Quantity;
                                }
                            }
                            else if (isCart == "delivering")
                            {
                                order.isCart = "Delivering";
                                product.Quantity -= order.Quantity;
                            }
                            else if (isCart == "confirm")
                            {
                                order.isCart = "Confirm";
                                product.Sold += 1;
                            }
                        _repo.OrderDetail.UpdateOrder(order);
                        await _repo.SaveAsync();
                        }
                        else
                        {
                            transaction.Rollback();
                             return null;
                        }
                    }
                    transaction.Commit();
                return bill;
            }
        }
        public async Task<IEnumerable<PurchaseHistoryDTO>> listCart(string? CustomerId)
        {
            var result = await (from kh in _repo.Customer.GetAll(false)
                                join bill in _repo.Bill.GetAll(false) on kh.Id equals bill.CustomerID
                                join order in _repo.OrderDetail.GetAll(false) on bill.Id equals order.BillId
                                join product in _repo.Product.GetAll(false) on order.ProductId equals product.Id
                                where kh.Id == CustomerId && order.isCart == "Cart"
                                orderby bill.Time
                                select new PurchaseHistoryDTO
                                {
                                    Id = order.Id,
                                    Quantity = order.Quantity,
                                    Product = product.Name,
                                    Price = order.Price,
                                    ProductId = order.Id,
                                    Image = product.Image,
                                    TotalMoney = order.TotalMoney,
                                    Time = bill.Time,
                                    Warehouse = product.Quantity
                                }

            ).ToListAsync();

            return result;

        }

        public async Task<GetAllOrderDetail> updateTotal(Guid? Id, int? quantity)
        {
            var result = await _repo.OrderDetail.GetOrderDetailById(Id);
            result.Quantity = quantity;
            result.TotalMoney = result.Price * quantity;
            await _repo.SaveAsync();
            var results = _mapper.Map<GetAllOrderDetail>(result);
            return results;
        }

        public async Task<IEnumerable<OrderDetail>> getOrderDetailByBillId (Guid? Id)
        {
            var result = await _repo.OrderDetail.GetOrderDetailByBillID(Id);
            return result;
        }

        public async Task<OrderDetail> updateOrderDetailBillId(Guid? orderDetailId, Guid? BillId)
        {
            var order = await _repo.OrderDetail.GetOrderDetailById(orderDetailId);
            order.BillId = BillId;
            await _repo.SaveAsync();
            return order;
        }

        public async Task<CountCartDTO> countCart(string? customerId)
        {
            var result = await (from kh in _repo.Customer.GetAll(false)
                                join bill in _repo.Bill.GetAll(false) on kh.Id equals bill.CustomerID
                                join order in _repo.OrderDetail.GetAll(false) on bill.Id equals order.BillId
                                join product in _repo.Product.GetAll(false) on order.ProductId equals product.Id
                                where kh.Id == customerId && order.isCart == "Cart"
                                select new PurchaseHistoryDTO
                                {
                                    TotalMoney=order.TotalMoney
                                }).CountAsync();
            var results = await (from kh in _repo.Customer.GetAll(false)
                                join bill in _repo.Bill.GetAll(false) on kh.Id equals bill.CustomerID
                                join order in _repo.OrderDetail.GetAll(false) on bill.Id equals order.BillId
                                join product in _repo.Product.GetAll(false) on order.ProductId equals product.Id
                                where kh.Id == customerId && order.isCart == "Cart"
                                select new PurchaseHistoryDTO
                                {
                                    TotalMoney = order.TotalMoney
                                }).ToListAsync();
            int? sum = 0;
            foreach (var re in results)
            {
                sum += re.TotalMoney;
            }    
            return new CountCartDTO
            {
                Count = result,
                TotalMoney = sum
            };
        }
    }
}
