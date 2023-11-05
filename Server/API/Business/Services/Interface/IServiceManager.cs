namespace API.Business.Services.Interface
{
    public interface IServiceManager
    {
        ICustomerService customerService { get; }

        IBillService billService { get; }   

        IOrderDetailService orderDetailService { get; }

        IProductService productService { get; }

        IProductTypeService productTypeService { get; }

        IAuthenticationService authenticationService { get; }

        ISaleService saleService { get; }

        IFeedbackService feedbackService { get; }

    }
}
