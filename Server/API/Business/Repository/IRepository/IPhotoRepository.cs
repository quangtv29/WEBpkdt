using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IPhotoRepository : IRepositoryBase<Photo>
    {
       void CreatePhoto(Photo photo);
    }
}
