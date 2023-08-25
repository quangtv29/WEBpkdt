namespace API.Business.Services.Interface
{
    public interface IServiceManager
    {
        ICustomerService customerService { get; }

        IBillService billService { get; }   

    }
}
