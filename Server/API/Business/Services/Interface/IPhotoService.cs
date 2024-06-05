using API.Business.DTOs.PhotoDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IPhotoService
    {
     Task CreatePhoto(CreatePhotoDTO photo);
     Task<IEnumerable<Photo>> getPhotoByProduct(Guid Id);
    }
}
