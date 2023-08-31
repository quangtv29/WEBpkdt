using API.Entities;

namespace API.Exceptions.NotFoundExceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid? productId) : base($"The product with id : {productId} doesn't exist in the databse.")
        {
        }
    }
}
