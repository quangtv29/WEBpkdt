﻿using Microsoft.EntityFrameworkCore.Storage;

namespace API.Business.Repository.IRepository
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        IBillRepository Bill { get; }
        IOrderDetailRepository OrderDetail {get;}

        IProductRepository Product { get; }
        IProductTypeRepository ProductType { get; }
        IFeedbackRepository Feedback { get; }
        ISaleRepository Sale { get; }
        INotificationRepository Notification { get; }

        IDbContextTransaction Transaction();
        Task SaveAsync();
    }
}
